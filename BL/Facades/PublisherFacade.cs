using BL.DTOs.PublisherDTOs;
using BL.Facades.Interfaces;
using BL.Services.Interfaces;
using FluentResults;

namespace BL.Facades
{
    public class PublisherFacade : IPublisherFacade
    {
        private readonly IPublisherService _publisherService;

        public PublisherFacade(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        public async Task<Result<IEnumerable<PublisherDto>>> GetAllAsync()
        {
            var publishers = await _publisherService.GetAllPublishersAsync();
            return Result.Ok(publishers);
        }

        public async Task<Result<PublisherDto>> GetByIdAsync(int id)
        {
            return await _publisherService.GetPublisherByIdAsync(id);
        }

        public async Task<Result<PublisherDto>> CreateAsync(PublisherCreateDto dto)
        {
            return await _publisherService.CreatePublisherAsync(dto);
        }

        public async Task<Result> UpdateAsync(int id, PublisherUpdateDto dto)
        {
            return await _publisherService.UpdatePublisherAsync(id, dto);
        }

        public async Task<Result> DeleteAsync(int id)
        {
            return await _publisherService.DeletePublisherAsync(id);
        }
    }
}
