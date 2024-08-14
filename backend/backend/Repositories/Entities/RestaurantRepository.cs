using backend.Context;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using backend.Objects.Models.Entities;

namespace backend.Repositories.Entities;
public class RestaurantRepository : IRestaurantRepository
{

    private readonly AppDBContext _dbContext;

    public RestaurantRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<RestaurantModel>> GetAll()
    {
        return await _dbContext.Restaurant.AsNoTracking().ToListAsync();
    }

    public async Task<RestaurantModel> GetById(int id)
    {
        return await _dbContext.Restaurant.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<RestaurantModel> Create(RestaurantModel restaurantModel)
    {
        _dbContext.Restaurant.Add(restaurantModel);
        await _dbContext.SaveChangesAsync();

        return restaurantModel;
    }

    public async Task<RestaurantModel> Update(RestaurantModel restaurantModel)
    {
        _dbContext.Entry(restaurantModel).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return restaurantModel;
    }

    public async Task<RestaurantModel> Delete(RestaurantModel restaurantModel)
    {
        _dbContext.Restaurant.Remove(restaurantModel);
        await _dbContext.SaveChangesAsync();

        return restaurantModel;
    }
}