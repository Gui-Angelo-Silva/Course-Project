using backend.Objects.Models.Entities;

namespace backend.Repositories.Interfaces;
public interface IRestaurantRepository
{
    Task<IEnumerable<RestaurantModel>> GetAll();
    Task<RestaurantModel> GetById(int id);
    Task<RestaurantModel> Create(RestaurantModel restaurant);
    Task<RestaurantModel> Update(RestaurantModel restaurant);
    Task<RestaurantModel> Delete(int id);
}