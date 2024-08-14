using backend.Context;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using backend.Objects.Models.Entities;

namespace backend.Repositories.Entities;
public class ThematicRestaurantRepository : IThematicRestaurantRepository
{

    private readonly AppDBContext _dbContext;

    public ThematicRestaurantRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ThematicRestaurantModel>> GetAll()
    {
        return await _dbContext.ThematicRestaurant.AsNoTracking().ToListAsync();
    }

    public async Task<ThematicRestaurantModel> GetById(int id)
    {
        return await _dbContext.ThematicRestaurant.AsNoTracking().FirstOrDefaultAsync(tr => tr.Id == id);
    }

    public async Task<ThematicRestaurantModel> Create(ThematicRestaurantModel thematicRestaurantModel)
    {
        _dbContext.ThematicRestaurant.Add(thematicRestaurantModel);
        await _dbContext.SaveChangesAsync();

        return thematicRestaurantModel;
    }

    public async Task<ThematicRestaurantModel> Update(ThematicRestaurantModel thematicRestaurantModel)
    {
        _dbContext.Entry(thematicRestaurantModel).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return thematicRestaurantModel;
    }

    public async Task<ThematicRestaurantModel> Delete(ThematicRestaurantModel thematicRestaurantModel)
    {
        _dbContext.ThematicRestaurant.Remove(thematicRestaurantModel);
        await _dbContext.SaveChangesAsync();

        return thematicRestaurantModel;
    }
}