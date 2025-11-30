using BL.DTOs.GiftcardDTOs;
using DAL.Models;
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

        Task<Result<GiftcardCodeValidationDto>> ValidateCodeAsync(string code);

        Task<Result<GiftcardCode>> GetCodeByValueAsync(string code);
    }
}
