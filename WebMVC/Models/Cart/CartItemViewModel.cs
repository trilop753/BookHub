using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebMVC.Models.Book;

namespace WebMVC.Models.Cart;

public class CartItemViewModel
{
    public int Id { get; set; }

    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    [ValidateNever]
    public BookViewModel Book { get; set; }
}
