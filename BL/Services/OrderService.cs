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

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<OrderDto>> CreateOrderFromUserCartAsync(UserCartDto user)
        {
            if (!user.Cart.Any())
            {
                return Result.Fail($"User with id {user.Id} has an empty cart.");
            }

            var items = user
                .Cart.Select(i => new OrderItem() { BookId = i.Book.Id, Quantity = i.Quantity })
                .ToList();

            var order = new Order()
            {
                Date = DateTime.Now,
                Items = items,
                UserId = user.Id,
            };

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();
            return Result.Ok(order.MapToOrderDto());
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

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
            var orders = await _orderRepository.GetAllAsync();
            return Result.Ok(orders.Select(o => o.MapToOrderDto()));
        }

        public async Task<Result<OrderDto>> GetByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
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
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return Result.Fail($"Book with id {id} does not exist.");
            }

            order.PaymentStatus = status;
            await _orderRepository.SaveChangesAsync();

            return Result.Ok(order.MapToOrderDto());
        }
    }
}
