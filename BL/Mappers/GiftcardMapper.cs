using BL.DTOs.GiftcardDTOs;
using DAL.Models;

namespace BL.Mappers
{
    public static class GiftcardMapper
    {
        public static GiftcardDto MapToDto(this Giftcard giftcard)
        {
            return new GiftcardDto
            {
                Id = giftcard.Id,
                Name = giftcard.Name,
                Amount = giftcard.Amount,
                ValidFrom = giftcard.ValidFrom,
                ValidTo = giftcard.ValidTo,
                TotalCodes = giftcard.Codes?.Count() ?? 0,
                UsedCodes = giftcard.Codes?.Count(c => c.IsUsed) ?? 0
            };
        }

        public static GiftcardSummaryDto MapToSummaryDto(this Giftcard giftcard)
        {
            return new GiftcardSummaryDto
            {
                Id = giftcard.Id,
                Name = giftcard.Name,
                Amount = giftcard.Amount,
                ValidFrom = giftcard.ValidFrom,
                ValidTo = giftcard.ValidTo,
                Codes = giftcard.Codes?
                            .Select(c => c.MapToCodeDto())
                        ?? Enumerable.Empty<GiftcardCodeDto>()
            };
        }

        public static GiftcardCodeDto MapToCodeDto(this GiftcardCode code)
        {
            return new GiftcardCodeDto
            {
                Id = code.Id,
                Code = code.Code,
                IsUsed = code.IsUsed,
                OrderId = code.OrderId
            };
        }
    }
}