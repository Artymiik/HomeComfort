using HomeComfort.Data;
using HomeComfort.Data.Enum;
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
        string filePath =
            "C:\\Users\\Artemiik\\Documents\\git\\Home Comfort\\HomeComfort\\HomeComfort\\Python\\DataByDatabase\\applications.csv";
        var applications = new List<Applications>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] values = line.Split(",");

                if (values[2].StartsWith("\"") && values[2].EndsWith("\""))
                {
                    values[2] = values[2].Substring(1, values[2].Length - 2);
                }

                var application = new Applications
                {
                    Id = int.Parse(values[0]),
                    Title = values[1],
                    Description = values[2],
                    Support_like = int.Parse(values[3]),
                    AppUserId = values[4],
                    AddressId = int.Parse(values[5]),
                    Category = (Category)Enum.Parse(typeof(Category), values[6]),
                    Priority = (Priority)Enum.Parse(typeof(Priority), values[7]),
                    CreatedAt = DateTime.Parse(values[8]),
                };
                
                applications.Add(application);
            }
        }

        return applications;
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