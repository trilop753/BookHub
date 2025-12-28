using BL.DTOs.PublisherDTOs;
using BL.Mappers;
using BL.Services.Interfaces;
using DAL.Models;
using FluentResults;
using Infrastructure.Repository.Interfaces;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IBookRepository _bookRepository;

    public PublisherService(
        IPublisherRepository publisherRepository,
        IBookRepository bookRepository
    )
    {
        _publisherRepository = publisherRepository;
        _bookRepository = bookRepository;
    }

    #region Get

    public async Task<Result<PublisherDto>> GetPublisherByIdAsync(int id)
    {
        var publisher = await _publisherRepository.GetByIdAsync(id);
        if (publisher == null)
        {
            return Result.Fail($"Publisher with id {id} does not exist.");
        }

        return Result.Ok(publisher.MapToDto());
    }

    public async Task<IEnumerable<PublisherDto>> GetAllPublishersAsync()
    {
        var publishers = await _publisherRepository.GetAllWithBooksAsync();
        return publishers.Select(p => p.MapToDto()).ToList();
    }

    #endregion

    public async Task<Result<PublisherDto>> CreatePublisherAsync(PublisherCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            return Result.Fail("Publisher name cannot be empty.");
        }

        var existing = await _publisherRepository.GetByNameAsync(dto.Name);
        if (existing != null)
        {
            return Result.Fail($"Publisher '{dto.Name}' already exists.");
        }

        var publisher = new Publisher { Name = dto.Name };

        await _publisherRepository.AddAsync(publisher);
        await _publisherRepository.SaveChangesAsync();

        return Result.Ok(publisher.MapToDto());
    }

    public async Task<Result> UpdatePublisherAsync(int id, PublisherUpdateDto dto)
    {
        var existing = await _publisherRepository.GetByIdAsync(id);
        if (existing == null)
        {
            return Result.Fail($"Publisher with id {id} does not exist.");
        }

        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            return Result.Fail("Publisher name cannot be empty.");
        }

        var duplicate = await _publisherRepository.GetByNameAsync(dto.Name);
        if (duplicate != null && duplicate.Id != id)
        {
            return Result.Fail($"Publisher '{dto.Name}' already exists.");
        }

        existing.Name = dto.Name;
        await _publisherRepository.SaveChangesAsync();

        return Result.Ok();
    }

    public async Task<Result> DeletePublisherAsync(int id)
    {
        var publisher = await _publisherRepository.GetByIdAsync(id);
        if (publisher == null)
        {
            return Result.Fail($"Publisher with id {id} does not exist.");
        }

        var books = (await _bookRepository.GetBooksAsync()).Items;
        var hasBooks =
            (publisher.Books != null && publisher.Books.Any())
            || books.Any(b => b.PublisherId == id);

        if (hasBooks)
        {
            return Result.Fail(
                $"Cannot delete publisher with id {id} because they have assigned books."
            );
        }

        _publisherRepository.Delete(publisher);
        await _publisherRepository.SaveChangesAsync();

        return Result.Ok();
    }
}
