using BL.DTOs.PublisherDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IPublisherService
    {
        Task<Result<PublisherDto>> GetPublisherByIdAsync(int id);
        Task<IEnumerable<PublisherDto>> GetAllPublishersAsync();
        Task<Result<PublisherDto>> CreatePublisherAsync(PublisherCreateDto dto);
        Task<Result> UpdatePublisherAsync(int id, PublisherUpdateDto dto);
        Task<Result> DeletePublisherAsync(int id);
    }
}
