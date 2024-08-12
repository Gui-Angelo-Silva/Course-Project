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

    public async Task<IEnumerable<RestaurantModel>> GetReservationRelatedUser(int idUser)
    {
        return await _dbContext.Restaurant.AsNoTracking().Where(r => r.IdUser == idUser).ToListAsync();
    }

    public async Task<IEnumerable<RestaurantModel>> GetReservationRelatedTable(int idTable)
    {
        return await _dbContext.Restaurant.AsNoTracking().Where(r => r.IdTable == idTable).ToListAsync();
    }

    public async Task<RestaurantModel> GetById(int id)
    {
        return await _dbContext.Restaurant.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<RestaurantModel> Create(RestaurantModel restaurant)
    {
        _dbContext.Restaurant.Add(restaurant);
        await _dbContext.SaveChangesAsync();

        return restaurant;
    }

    public async Task<RestaurantModel> Update(RestaurantModel restaurant)
    {
        _dbContext.Entry(restaurant).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return restaurant;
    }

    public async Task<RestaurantModel> Delete(int id)
    {
        var restaurant = await GetById(id);
        _dbContext.Restaurant.Remove(restaurant);
        await _dbContext.SaveChangesAsync();

        return restaurant;
    }
}