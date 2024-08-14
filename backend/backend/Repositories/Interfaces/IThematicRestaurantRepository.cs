using backend.Objects.Models.Entities;

namespace backend.Repositories.Interfaces;
public interface IThematicRestaurantRepository
{
    Task<IEnumerable<ThematicRestaurantModel>> GetAll();
    Task<ThematicRestaurantModel> GetById(int id);
    Task<ThematicRestaurantModel> Create(ThematicRestaurantModel thematicRestaurantModel);
    Task<ThematicRestaurantModel> Update(ThematicRestaurantModel thematicRestaurantModel);
    Task<ThematicRestaurantModel> Delete(ThematicRestaurantModel thematicRestaurantModel);
}