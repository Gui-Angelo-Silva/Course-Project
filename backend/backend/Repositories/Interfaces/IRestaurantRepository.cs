using backend.Objects.Models.Entities;

namespace backend.Repositories.Interfaces;
public interface IRestaurantRepository
{
    Task<IEnumerable<RestaurantModel>> GetAll();
    Task<RestaurantModel> GetById(int id);
    Task<RestaurantModel> Create(RestaurantModel restaurantModel);
    Task<RestaurantModel> Update(RestaurantModel restaurantModel);
    Task<RestaurantModel> Delete(RestaurantModel restaurantModel);
}