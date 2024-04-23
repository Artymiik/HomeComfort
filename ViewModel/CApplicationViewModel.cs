using System.ComponentModel.DataAnnotations;
using HomeComfort.Data.Enum;
using HomeComfort.Models;

namespace HomeComfort.ViewModel;

public class CApplicationViewModel
{
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Priority is required")]
    public Priority Priority { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public Address Address { get; set; }
    
    [Required(ErrorMessage = "Category is required")]
    public Category Category { get; set; }
}