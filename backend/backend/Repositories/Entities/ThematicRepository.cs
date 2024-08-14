using backend.Context;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using backend.Objects.Models.Entities;

namespace backend.Repositories.Entities;
public class ThematicRepository : IThematicRepository
{

    private readonly AppDBContext _dbContext;

    public ThematicRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ThematicModel>> GetAll()
    {
        return await _dbContext.Thematic.AsNoTracking().ToListAsync();
    }

    public async Task<ThematicModel> GetById(int id)
    {
        return await _dbContext.Thematic.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<ThematicModel> Create(ThematicModel thematicModel)
    {
        _dbContext.Thematic.Add(thematicModel);
        await _dbContext.SaveChangesAsync();

        return thematicModel;
    }

    public async Task<ThematicModel> Update(ThematicModel thematicModel)
    {
        _dbContext.Entry(thematicModel).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return thematicModel;
    }

    public async Task<ThematicModel> Delete(ThematicModel thematicModel)
    {
        _dbContext.Thematic.Remove(thematicModel);
        await _dbContext.SaveChangesAsync();

        return thematicModel;
    }
}