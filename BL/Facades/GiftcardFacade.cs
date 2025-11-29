using BL.DTOs.GiftcardDTOs;
using BL.Facades.Interfaces;
using BL.Services.Interfaces;
using DAL.Models;
using FluentResults;

namespace BL.Facades
{
    public class GiftcardFacade : IGiftcardFacade
    {
        private readonly IGiftcardService _giftcardService;

        public GiftcardFacade(IGiftcardService giftcardService)
        {
            _giftcardService = giftcardService;
        }

        public async Task<Result<GiftcardSummaryDto>> CreateAsync(GiftcardCreateDto dto)
        {
            var result = await _giftcardService.CreateAsync(dto);
            if (result.IsFailed)
                return Result.Fail(result.Errors);

            return Result.Ok(result.Value);
        }

        public async Task<Result> DeleteAsync(int id)
        {
            return await _giftcardService.DeleteAsync(id);
        }

        public async Task<Result<IEnumerable<GiftcardDto>>> GetAllAsync()
        {
            return await _giftcardService.GetAllAsync();
        }

        public async Task<Result<GiftcardSummaryDto>> GetByIdAsync(int id)
        {
            var result = await _giftcardService.GetByIdAsync(id);
            if (result.IsFailed)
                return Result.Fail(result.Errors);

            return Result.Ok(result.Value);
        }

        public async Task<Result<GiftcardSummaryDto>> UpdateAsync(int id, GiftcardUpdateDto dto)
        {
            var result = await _giftcardService.UpdateAsync(id, dto);
            if (result.IsFailed)
                return Result.Fail(result.Errors);

            return Result.Ok(result.Value);
        }

        public async Task<Result<GiftcardCodeValidationDto>> ValidateCodeAsync(string code)
        {
            var result = await _giftcardService.ValidateCodeAsync(code);
            if (result.IsFailed)
                return Result.Fail(result.Errors);

            return Result.Ok(result.Value);
        }

        public Task<GiftcardCode?> GetCodeByValueAsync(string code)
        {
            return _giftcardService.GetCodeByValueAsync(code);
        }
    }
}
