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
    }
}
