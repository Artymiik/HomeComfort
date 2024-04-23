using HomeComfort.Models;

namespace HomeComfort.Interfaces;

public interface IApplicationRepository
{
    Task<IEnumerable<Applications>> GetAll();
    Task<Applications> GetByIdAsync(int id);
    bool Add(Applications applications);
    bool Update(Applications applications);
    bool Delete(Applications applications);
    bool Save();
}