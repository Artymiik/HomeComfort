using HomeComfort.Data;
using HomeComfort.Interfaces;
using HomeComfort.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeComfort.Repository;

public class ApplicationRepository : IApplicationRepository
{
    private readonly ApplicationDbContext _context;

    public ApplicationRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public bool Add(Applications applications)
    {
        _context.Add(applications);
        return Save();
    }

    public bool Delete(Applications applications)
    {
        _context.Remove(applications);
        return Save();
    }

    public async Task<IEnumerable<Applications>> GetAll()
    {
        /*return await _context.Applications.ToListAsync();*/
        return await _context.Applications.OrderByDescending(r => r.CreatedAt).ToListAsync();
    }

    public async Task<Applications> GetByIdAsync(int id)
    {
        return await _context.Applications.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool Update(Applications applications)
    {
        _context.Update(applications);
        return Save();
    }
}