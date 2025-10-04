using Business.DTOs.BookDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IBookService
    {
        public Task<BookDto?> GetBookByIdAsync(int id);
        public Task<IEnumerable<BookDto>> GetAllBooksAsync();
        //public Task<BookDto> CreateBookAsync(BookDto dto);
        public Task<bool> UpdateBookAsync(BookDto dto);
        public Task<bool> DeleteBookAsync(int id);

    }
}
