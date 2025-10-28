using BL.DTOs.CartItemDTOs;
using BL.Facades.Interfaces;
using BL.Services.Interfaces;
using FluentResults;

namespace BL.Facades
{
    public class CartFacade : ICartFacade
    {
        private readonly ICartItemService _cartItemService;
        private readonly IUserService _userService;
        private readonly IBookService _bookService;

        public CartFacade(
            ICartItemService cartItemService,
            IUserService userService,
            IBookService bookService
        )
        {
            _cartItemService = cartItemService;
            _userService = userService;
            _bookService = bookService;
        }

        public async Task<Result<CartItemDto>> CreateCartItemAsync(
            int userId,
            int bookId,
            int quantity = 1
        )
        {
            var userRes = await ValidateUserAsync(userId);
            var bookRes = await ValidateBookAsync(bookId);

            var result = Result.Ok();

            if (userRes.IsFailed)
            {
                result.WithErrors(userRes.Errors);
            }

            if (bookRes.IsFailed)
            {
                result.WithErrors(bookRes.Errors);
            }

            if (result.IsFailed)
            {
                return result;
            }

            return await _cartItemService.CreateCartItemAsync(userId, bookId, quantity);
        }

        public async Task<Result> DeleteCartItemAsync(int id)
        {
            return await _cartItemService.DeleteCartItemAsync(id);
        }

        public async Task<Result<IEnumerable<CartItemDto>>> GetCartItemsByUserIdAsync(int userId)
        {
            var userRes = await ValidateUserAsync(userId);
            if (userRes.IsFailed)
            {
                return userRes;
            }

            return await _cartItemService.GetCartItemsByUserIdAsync(userId);
        }

        public async Task<Result<CartItemDto>> UpdateItemQuantityAsync(int id, int quantity)
        {
            return await _cartItemService.UpdateItemQuantityAsync(id, quantity);
        }

        private async Task<Result> ValidateUserAsync(int userId)
        {
            var userRes = await _userService.GetUserByIdAsync(userId);

            return userRes.IsFailed ? Result.Fail(userRes.Errors) : Result.Ok();
        }

        private async Task<Result> ValidateBookAsync(int bookId)
        {
            var bookRes = await _bookService.GetBookByIdAsync(bookId);

            return bookRes.IsFailed ? Result.Fail(bookRes.Errors) : Result.Ok();
        }
    }
}
