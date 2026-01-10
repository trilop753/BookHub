using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models.Admin;

public class AdminResetPasswordViewModel
{
    public string? Query { get; set; }

    public List<UserOptionViewModel> Results { get; set; } = [];

    [Required]
    public string? SelectedUserId { get; set; }

    public string? SelectedUserName { get; set; }
    public string? SelectedEmail { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [MinLength(6)]
    public string NewPassword { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(NewPassword), ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}

public class UserOptionViewModel
{
    public string Id { get; set; } = string.Empty;
    public string? UserName { get; set; }
    public string? Email { get; set; }
}
