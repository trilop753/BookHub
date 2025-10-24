using BL.DTOs.WishlistItemDTOs;
using BL.Facades.Interfaces;
using BL.Services.Interfaces;
using FluentResults;

namespace BL.Facades
{
    public class WishlistFacade : IWishlistFacade
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly IWishlistItemService _wishlistItemService;

        public WishlistFacade(
            IBookService bookService,
            IUserService userService,
            IWishlistItemService wishlistItemService
        )
        {
            _bookService = bookService;
            _userService = userService;
            _wishlistItemService = wishlistItemService;
        }

        public async Task<Result<WishlistItemDto>> WishlistBook(int userId, int bookId)
        {
            var check = await CheckUserAndBookExistAsync(userId, bookId);
            if (check.IsFailed)
            {
                return check.ToResult<WishlistItemDto>();
            }
            return await _wishlistItemService.CreateWishlistItemAsync(userId, bookId);
        }

        public async Task<Result<WishlistItemDto>> RemoveFromWishlist(int userId, int bookId)
        {
            var check = await CheckUserAndBookExistAsync(userId, bookId);
            if (check.IsFailed)
            {
                return check.ToResult<WishlistItemDto>();
            }
            return await _wishlistItemService.DeleteWishlistItemAsync(userId, bookId);
        }

        private async Task<Result> CheckUserAndBookExistAsync(int userId, int bookId)
        {
            var book = await _bookService.GetBookByIdAsync(bookId);
            var user = await _userService.GetUserByIdAsync(userId);

            var result = Result.Ok();

            if (book.IsFailed)
                result.WithErrors(book.Errors);

            if (user.IsFailed)
                result.WithErrors(user.Errors);

            if (result.IsFailed)
                return Result.Fail(result.Errors);

            return result;
        }
    }
}
