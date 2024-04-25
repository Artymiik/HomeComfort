using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeComfort.Data.Enum;

namespace HomeComfort.Models;

public class Applications
{
    [Key] public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority Priority { get; set; }

    [ForeignKey("Address")] 
    public int AddressId { get; set; }
    public Address Address { get; set; }
    public Category Category { get; set; }
    
    public int? Support_like { get; set; }
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("AppUser")]
    public string? AppUserId { get; set; }

    public Applications()
    {
        DateTime now = DateTime.Now;
        
        Support_like = 0;
        CreatedAt = now;
    }
}