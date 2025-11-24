using BL.DTOs.BookDTOs;
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

        public async Task<Result<WishlistItemDto>> WishlistBookAsync(
            WishlistItemCreateDto wishlistItem
        )
        {
            var check = await CheckUserAndBookExistAsync(wishlistItem.UserId, wishlistItem.BookId);
            if (check.IsFailed)
            {
                return check;
            }
            return await _wishlistItemService.CreateWishlistItemAsync(wishlistItem);
        }

        public async Task<Result<WishlistItemDto>> RemoveFromWishlistAsync(int userId, int bookId)
        {
            var check = await CheckUserAndBookExistAsync(userId, bookId);
            if (check.IsFailed)
            {
                return check;
            }
            return await _wishlistItemService.DeleteWishlistItemAsync(userId, bookId);
        }

        public async Task<Result<IEnumerable<WishlistItemDto>>> GetAllWishlistedByUserIdAsync(
            int userId
        )
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user.IsFailed)
            {
                return Result.Fail(user.Errors);
            }
            var wishlisted = await _wishlistItemService.GetAllUserWishlistItemsAsync(userId);
            return Result.Ok(wishlisted);
        }

        public async Task<Result<IEnumerable<WishlistItemDto>>> GetAllWishlistedByBookIdAsync(
            int bookId
        )
        {
            var book = await _bookService.GetBookByIdAsync(bookId);
            if (book.IsFailed)
            {
                return Result.Fail(book.Errors);
            }
            var wishlisted = await _wishlistItemService.GetAllBookWishlistItemsAsync(bookId);
            return Result.Ok(wishlisted);
        }

        public async Task<Result<IEnumerable<BookDto>>> GetAllWishlistedBooksByUserIdAsync(
            int userId
        )
        {
            var userRes = await _userService.GetUserByIdAsync(userId);

            if (userRes.IsFailed)
            {
                return Result.Fail(userRes.Errors);
            }
            var wishlistedItems = await _wishlistItemService.GetAllUserWishlistItemsAsync(userId);
            var wishlistedBooksIds = wishlistedItems.Select(w => w.Book.Id).ToArray();
            return await _bookService.GetBooksByIdsAsync(wishlistedBooksIds);
        }

        private async Task<Result<WishlistItemDto>> CheckUserAndBookExistAsync(
            int userId,
            int bookId
        )
        {
            var book = await _bookService.GetBookByIdAsync(bookId);
            var user = await _userService.GetUserByIdAsync(userId);

            var result = Result.Ok();

            if (book.IsFailed)
            {
                result.WithErrors(book.Errors);
            }

            if (user.IsFailed)
            {
                result.WithErrors(user.Errors);
            }

            if (result.IsFailed)
            {
                return Result.Fail(result.Errors);
            }
            return result;
        }

        private async Task<Result> ValidateUserAsync(int userId)
        {
            var userRes = await _userService.GetUserByIdAsync(userId);

            if (userRes.IsFailed)
            {
                return Result.Fail(userRes.Errors);
            }
            return Result.Ok();
        }
    }
}
