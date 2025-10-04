using Business.DTOs.BookDTOs;
using DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.DTOs.BookReviewDTOs
{
    public class BookReviewDto
    {
        public int Id { get; set; }

        public int Stars { get; set; }

        public string Body { get; set; }

        public UserDto User { get; set; }

        public BookDto Book { get; set; }
    }
}