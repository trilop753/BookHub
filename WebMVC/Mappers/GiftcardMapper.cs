using BL.DTOs.GiftcardDTOs;
using WebMVC.Models.Giftcard;

namespace WebMVC.Mappers
{
    public static class GiftcardMapper
    {
        public static GiftcardViewModel MapToView(this GiftcardDto dto)
        {
            return new GiftcardViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Amount = dto.Amount,
                ValidFrom = dto.ValidFrom,
                ValidTo = dto.ValidTo,
                TotalCodes = dto.Codes?.Count() ?? 0,
                UsedCodes = dto.Codes?.Count(c => c.IsUsed) ?? 0,
            };
        }

        public static GiftcardDetailViewModel MapToDetailView(this GiftcardDto dto)
        {
            return new GiftcardDetailViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Amount = dto.Amount,
                ValidFrom = dto.ValidFrom,
                ValidTo = dto.ValidTo,
                TotalCodes = dto.Codes?.Count() ?? 0,
                UsedCodes = dto.Codes?.Count(c => c.IsUsed) ?? 0,
                Codes =
                    dto.Codes?.Select(c => new GiftcardCodeSummaryViewModel
                        {
                            Id = c.Id,
                            Code = c.Code,
                            IsUsed = c.IsUsed,
                            OrderId = c.OrderId,
                        })
                        .ToList() ?? new List<GiftcardCodeSummaryViewModel>(),
            };
        }

        public static GiftcardCodesViewModel MapToCodesView(this GiftcardDto dto)
        {
            return new GiftcardCodesViewModel
            {
                GiftcardId = dto.Id,
                GiftcardName = dto.Name,
                Codes =
                    dto.Codes?.Select(c => new GiftcardCodeItemViewModel
                        {
                            Id = c.Id,
                            Code = c.Code,
                            IsUsed = c.IsUsed,
                            OrderId = c.OrderId,
                        })
                        .ToList() ?? new List<GiftcardCodeItemViewModel>(),
            };
        }

        public static GiftcardCreateDto MapToCreateDto(this GiftcardCreateViewModel vm)
        {
            return new GiftcardCreateDto
            {
                Name = vm.Name,
                Amount = vm.Amount,
                ValidFrom = vm.ValidFrom,
                ValidTo = vm.ValidTo,
                NumberOfCodes = vm.NumberOfCodes,
            };
        }
    }
}
