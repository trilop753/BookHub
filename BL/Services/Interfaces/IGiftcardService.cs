using BL.DTOs.GiftcardDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IGiftcardService
    {
        Task<Result<IEnumerable<GiftcardDto>>> GetAllAsync();

        Task<Result<GiftcardSummaryDto>> GetByIdAsync(int id);

        Task<Result<GiftcardSummaryDto>> CreateAsync(GiftcardCreateDto dto);

        Task<Result<GiftcardSummaryDto>> UpdateAsync(int id, GiftcardUpdateDto dto);

        Task<Result> DeleteAsync(int id);

        Task<Result<GiftcardCodeValidationDto>> ValidateCodeAsync(string code);
    }
}