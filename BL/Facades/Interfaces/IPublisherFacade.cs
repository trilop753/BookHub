using BL.DTOs.PublisherDTOs;
using FluentResults;

namespace BL.Facades.Interfaces
{
    public interface IPublisherFacade
    {
        Task<Result<IEnumerable<PublisherDto>>> GetAllAsync();
        Task<Result<PublisherDto>> GetByIdAsync(int id);
        Task<Result<PublisherDto>> CreateAsync(PublisherCreateDto dto);
        Task<Result> UpdateAsync(int id, PublisherUpdateDto dto);
        Task<Result> DeleteAsync(int id);
    }
}
