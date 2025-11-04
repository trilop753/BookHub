using BL.DTOs.CartItemDTOs;
using BL.Mappers;
using BL.Services.Interfaces;
using DAL.Models;
using FluentResults;
using Infrastructure.Repository.Interfaces;

namespace BL.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _repository;

        public CartItemService(ICartItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<CartItemDto>> CreateCartItemAsync(
            int userId,
            int bookId,
            int quantity = 1
        )
        {
            if (quantity < 0)
            {
                return Result.Fail("CartItem cannot have negative quantity.");
            }

            var existing = await _repository.GetByUserIdAndBookIdAsync(userId, bookId);
            if (existing != null)
            {
                return await UpdateItemQuantityAsync(existing.Id, existing.Quantity + quantity);
            }

            var item = new CartItem()
            {
                UserId = userId,
                BookId = bookId,
                Quantity = quantity,
            };
            await _repository.AddAsync(item);
            await _repository.SaveChangesAsync();
            return Result.Ok(item.MapToDto());
        }

        public async Task<Result> DeleteCartItemAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);

            if (item == null)
            {
                return Result.Fail($"CartItem with id {id} does not exist.");
            }

            _repository.Delete(item);
            await _repository.SaveChangesAsync();

            return Result.Ok();
        }

        public async Task<Result> DeleteCartItemsAsync(IEnumerable<int> ids)
        {
            var exist = await _repository.GetExistingIdsAsync(ids);
            var notExist = ids.Except(exist);
            if (notExist.Any())
            {
                var result = Result.Ok();
                foreach (var id in notExist)
                {
                    result.WithError($"CartItem with id {id} does not exist.");
                }
                return result;
            }

            await _repository.DeleteCartItemsAsync(ids);

            return Result.Ok();
        }

        public async Task<Result<IEnumerable<CartItemDto>>> GetCartItemsByUserIdAsync(int userId)
        {
            var items = await _repository.GetByUserIdAsync(userId);
            return Result.Ok(items.Select(i => i.MapToDto()));
        }

        public async Task<Result<CartItemDto>> UpdateItemQuantityAsync(int id, int quantity)
        {
            if (quantity < 0)
            {
                return Result.Fail("CartItem cannot have negative quantity.");
            }

            var item = await _repository.UpdateItemQuantityAsync(id, quantity);

            if (item == null)
            {
                return Result.Fail($"CartItem with id {id} does not exist.");
            }
            return Result.Ok(item.MapToDto());
        }
    }
}
