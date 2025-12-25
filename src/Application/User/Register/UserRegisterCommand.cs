
using System.ComponentModel.DataAnnotations;

public class UserRegisterCommand: ICommand
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage =" Email is not valid")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public required string Password { get; set; }
}