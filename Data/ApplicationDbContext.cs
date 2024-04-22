using HomeComfort.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeComfort.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }
    
    public DbSet<AppUser> AppUser { get; set; }
    public DbSet<Applications> Applications { get; set; }
    public DbSet<Address> Addresses { get; set; }
}