using Business.DTOs.BookDTOs;
using Business.DTOs.UserDTOs;
using DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.DTOs.BookReviewDTOs
{
    public class BookReviewDto
    {
        public int Id { get; set; }

        public int Stars { get; set; }

        public string Body { get; set; }

        public UserSummaryDto User { get; set; }

        public BookSummaryDto Book { get; set; }
    }
}