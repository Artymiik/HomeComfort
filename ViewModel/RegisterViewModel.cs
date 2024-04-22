using System.ComponentModel.DataAnnotations;

namespace HomeComfort.ViewModel;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Fname is required")]
    public string Fname { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email address is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}