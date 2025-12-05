using BL.DTOs.OrderDTOs;
using BL.DTOs.UserDTOs;
using BL.Mappers;
using BL.Services.Interfaces;
using DAL.Models;
using DAL.UtilityModels;
using FluentResults;
using Infrastructure.Repository.Interfaces;

namespace BL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IGiftcardRepository _giftcardRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IGiftcardRepository giftcardRepository
        )
        {
            _orderRepository = orderRepository;
            _giftcardRepository = giftcardRepository;
        }

        public async Task<Result<OrderDto>> CreateOrderFromUserCartAsync(UserCartDto user)
        {
            if (!user.Cart.Any())
            {
                return Result.Fail($"User with id {user.Id} has an empty cart.");
            }

            var items = user
                .Cart.Select(i => new OrderItem()
                {
                    Quantity = i.Quantity,
                    BookTitle = i.Book.Title,
                    BookISBN = i.Book.ISBN,
                    BookPrice = i.Book.Price,
                    BookPublisher = i.Book.PublisherName,
                    BookAuthor = i.Book.AuthorName,
                })
                .ToList();

            var order = new Order()
            {
                Date = DateTime.Now,
                Items = items,
                UserId = user.Id,
            };

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();

            var loaded = await _orderRepository.GetDetailByIdAsync(order.Id);
            return Result.Ok(loaded!.MapToOrderDto());
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var order = await _orderRepository.GetDetailByIdAsync(id);

            if (order == null)
            {
                return Result.Fail($"Order with id {id} does not exist.");
            }

            _orderRepository.Delete(order);
            await _orderRepository.SaveChangesAsync();
            return Result.Ok();
        }

        public async Task<Result<IEnumerable<OrderDto>>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllDetailedAsync();
            return Result.Ok(orders.Select(o => o.MapToOrderDto()));
        }

        public async Task<Result<OrderDto>> GetByIdAsync(int id)
        {
            var order = await _orderRepository.GetDetailByIdAsync(id);
            if (order == null)
            {
                return Result.Fail($"Order with id {id} does not exist.");
            }

            return Result.Ok(order.MapToOrderDto());
        }

        public async Task<Result<IEnumerable<OrderDto>>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return Result.Ok(orders.Select(o => o.MapToOrderDto()));
        }

        public async Task<Result<OrderDto>> UpdateOrderPaymentStatusAsync(
            int id,
            PaymentStatus status
        )
        {
            var order = await _orderRepository.GetDetailByIdAsync(id);
            if (order == null)
            {
                return Result.Fail($"Order with id {id} does not exist.");
            }

            order.PaymentStatus = status;

            await _orderRepository.SaveChangesAsync();

            return Result.Ok(order.MapToOrderDto());
        }

        public async Task<Result> AssignGiftcardCodeAsync(int orderId, int giftcardCodeId)
        {
            var order = await _orderRepository.GetDetailByIdAsync(orderId);
            if (order == null)
            {
                return Result.Fail("Order not found.");
            }

            var code = await _giftcardRepository.GetCodeByIdAsync(giftcardCodeId);
            if (code == null)
            {
                return Result.Fail("Giftcard code not found.");
            }

            if (code.IsUsed)
            {
                return Result.Fail("This giftcard code has already been used.");
            }

            var now = DateTime.UtcNow;
            var gc = code.Giftcard;

            if (gc == null)
            {
                return Result.Fail("Giftcard data not loaded.");
            }

            if (now < gc.ValidFrom || now > gc.ValidTo)
            {
                return Result.Fail("Giftcard code is expired or not yet active.");
            }

            code.IsUsed = true;
            code.OrderId = orderId;

            order.GiftcardCodeId = giftcardCodeId;

            await _orderRepository.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
