using Microsoft.AspNetCore.Identity;

namespace HomeComfort.Models;

public class AppUser : IdentityUser
{
    public string Name { get; set; }
    public string Fname { get; set; }
    public ICollection<Applications> Applications { get; set; }
}