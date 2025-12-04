using BL.DTOs.PublisherDTOs;
using WebMVC.Models.Publisher;

namespace WebMVC.Mappers
{
    public static class PublisherMapper
    {
        public static PublisherViewModel MapToView(this PublisherSummaryDto publisher)
        {
            return new PublisherViewModel() { Id = publisher.Id, Name = publisher.Name };
        }

        public static PublisherViewModel MapToView(this PublisherDto publisher)
        {
            return new PublisherViewModel() { Id = publisher.Id, Name = publisher.Name };
        }

        public static PublisherUpdateViewModel MapToUpdateView(this PublisherDto publisher)
        {
            return new PublisherUpdateViewModel() { Id = publisher.Id, Name = publisher.Name };
        }

        public static PublisherUpdateDto MapToDto(this PublisherUpdateViewModel publisher)
        {
            return new PublisherUpdateDto() { Name = publisher.Name };
        }

        public static PublisherCreateDto MapToDto(this PublisherCreateViewModel publisher)
        {
            return new PublisherCreateDto() { Name = publisher.Name };
        }
    }
}
