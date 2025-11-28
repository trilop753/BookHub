using BL.DTOs.GiftcardDTOs;
using FluentResults;

namespace BL.Facades.Interfaces
{
    public interface IGiftcardFacade
    {
        Task<Result<GiftcardSummaryDto>> GetByIdAsync(int id);

        Task<Result<IEnumerable<GiftcardDto>>> GetAllAsync();

        Task<Result<GiftcardSummaryDto>> CreateAsync(GiftcardCreateDto dto);

        Task<Result<GiftcardSummaryDto>> UpdateAsync(int id, GiftcardUpdateDto dto);

        Task<Result> DeleteAsync(int id);

        // Additional: Validate code in Cart (optional)
        Task<Result<GiftcardCodeValidationDto>> ValidateCodeAsync(string code);
    }
}