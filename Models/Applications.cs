using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeComfort.Models;

public class Applications
{
    [Key] public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }

    public Address Address { get; set; }
    public Data.Enum.Category Category { get; set; }
    
    public int Support_like { get; set; }

    [ForeignKey("AppUser")]
    public string? AppUserId { get; set; }
}