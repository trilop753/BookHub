using BL.DTOs.UtilityDTOs;

namespace BL.Facades.Interfaces
{
    public interface ISearchFacade
    {
        Task<SearchResultDto> QuerySearch(string query, SearchMode mode);
    }
}
