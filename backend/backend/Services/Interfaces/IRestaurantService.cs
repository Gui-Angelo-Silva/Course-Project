using backend.Objects.DTOs.Entities;

namespace backend.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantDTO>> GetAll();
        Task<RestaurantDTO> GetById(int id);
        Task Create(RestaurantDTO restaurantDTO);
        Task Update(RestaurantDTO restaurantDTO);
        Task Delete(RestaurantDTO restaurantDTO);
    }
}