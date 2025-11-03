using BL.DTOs.WishlistItemDTOs;
using BL.Mappers;
using BL.Services.Interfaces;
using FluentResults;
using Infrastructure.Repository.Interfaces;

namespace BL.Services
{
    public class WishlistItemService : IWishlistItemService
    {
        private readonly IWishlistItemRepository _repository;

        public WishlistItemService(IWishlistItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<WishlistItemDto>> CreateWishlistItemAsync(
            WishlistItemCreateDto wishlistItem
        )
        {
            var model = wishlistItem.MapToModel();
            await _repository.AddAsync(model);
            await _repository.SaveChangesAsync();
            return Result.Ok(model.MapToDto());
        }

        public async Task<Result> DeleteWishlistItemAsync(int userId, int bookId)
        {
            var wishlistItem = await _repository.GetByUserIdAndBookIdAsync(userId, bookId);
            if (wishlistItem == null)
            {
                return Result.Fail(
                    $"User with id {userId} does not wishlist book with id {bookId}"
                );
            }
            _repository.Delete(wishlistItem);
            await _repository.SaveChangesAsync();
            return Result.Ok();
        }

        public async Task<IEnumerable<WishlistItemDto>> GetAllBookWishlistItemsAsync(int bookId)
        {
            var items = await _repository.GetAllWithBookIdAsync(bookId);
            return items.Select(wishlistItem => wishlistItem.MapToDto());
        }

        public async Task<IEnumerable<WishlistItemDto>> GetAllUserWishlistItemsAsync(int userId)
        {
            var items = await _repository.GetAllByUserIdAsync(userId);
            return items.Select(wishlistItem => wishlistItem.MapToDto());
        }
    }
}
