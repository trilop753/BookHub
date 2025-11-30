using BL.DTOs.GiftcardDTOs;
using BL.Mappers;
using BL.Services.Interfaces;
using DAL.Models;
using FluentResults;
using Infrastructure.Repository.Interfaces;

namespace BL.Services
{
    public class GiftcardService : IGiftcardService
    {
        private readonly IGiftcardRepository _giftcardRepository;

        public GiftcardService(IGiftcardRepository giftcardRepository)
        {
            _giftcardRepository = giftcardRepository;
        }

        public async Task<Result<IEnumerable<GiftcardDto>>> GetAllAsync()
        {
            var cards = await _giftcardRepository.GetAllAsync();
            return Result.Ok(cards.Select(c => c.MapToDto()));
        }

        public async Task<Result<GiftcardSummaryDto>> GetByIdAsync(int id)
        {
            var card = await _giftcardRepository.GetByIdAsync(id);
            if (card == null)
            {
                return Result.Fail($"Giftcard with id {id} does not exist.");
            }

            return Result.Ok(card.MapToSummaryDto());
        }

        public async Task<Result<GiftcardSummaryDto>> CreateAsync(GiftcardCreateDto dto)
        {
            if (dto.ValidTo < dto.ValidFrom)
            {
                return Result.Fail("ValidTo cannot be earlier than ValidFrom.");
            }

            var card = new Giftcard
            {
                Name = dto.Name,
                Amount = dto.Amount,
                ValidFrom = dto.ValidFrom,
                ValidTo = dto.ValidTo,
                Codes = GenerateCodes(dto.NumberOfCodes),
            };

            await _giftcardRepository.AddAsync(card);
            await _giftcardRepository.SaveChangesAsync();

            return Result.Ok(card.MapToSummaryDto());
        }

        public async Task<Result<GiftcardSummaryDto>> UpdateAsync(int id, GiftcardUpdateDto dto)
        {
            var card = await _giftcardRepository.GetByIdAsync(id);
            if (card == null)
            {
                return Result.Fail($"Giftcard with id {id} does not exist.");
            }

            if (dto.ValidTo < dto.ValidFrom)
            {
                return Result.Fail("ValidTo cannot be earlier than ValidFrom.");
            }

            card.Name = dto.Name;
            card.Amount = dto.Amount;
            card.ValidFrom = dto.ValidFrom;
            card.ValidTo = dto.ValidTo;

            await _giftcardRepository.SaveChangesAsync();

            return Result.Ok(card.MapToSummaryDto());
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var card = await _giftcardRepository.GetByIdAsync(id);
            if (card == null)
            {
                return Result.Fail($"Giftcard with id {id} does not exist.");
            }

            _giftcardRepository.Delete(card);
            await _giftcardRepository.SaveChangesAsync();

            return Result.Ok();
        }

        public async Task<Result<GiftcardCodeValidationDto>> ValidateCodeAsync(string code)
        {
            var codeEntity = await _giftcardRepository.GetCodeByValueAsync(code);

            if (codeEntity == null)
            {
                return Result.Fail("Giftcard code does not exist.");
            }

            if (codeEntity.IsUsed)
            {
                return Result.Fail("Giftcard code has already been used.");
            }

            var giftcard = codeEntity.Giftcard;

            var now = DateTime.UtcNow;

            if (now < giftcard.ValidFrom || now > giftcard.ValidTo)
            {
                return Result.Fail("Giftcard code is expired or not valid yet.");
            }

            return Result.Ok(
                new GiftcardCodeValidationDto
                {
                    Code = code,
                    Amount = giftcard.Amount,
                    GiftcardId = giftcard.Id,
                }
            );
        }

        private static IEnumerable<GiftcardCode> GenerateCodes(int count)
        {
            var list = new List<GiftcardCode>();
            for (int i = 0; i < count; i++)
            {
                list.Add(
                    new GiftcardCode
                    {
                        Code = Guid.NewGuid().ToString("N")[..10].ToUpper(),
                        IsUsed = false,
                    }
                );
            }
            return list;
        }

        public async Task<Result<GiftcardCode>> GetCodeByValueAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return Result.Fail("Code cannot be empty.");
            }

            var entity = await _giftcardRepository.GetCodeByValueAsync(code);

            if (entity == null)
            {
                return Result.Fail("Giftcard code not found.");
            }

            return Result.Ok(entity);
        }
    }
}
