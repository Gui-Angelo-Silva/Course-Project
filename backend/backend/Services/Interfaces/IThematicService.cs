using backend.Objects.DTOs.Entities;

namespace backend.Services.Interfaces
{
    public interface IThematicRestaurantService
    {
        Task<IEnumerable<ThematicRestaurantDTO>> GetAll();
        Task<ThematicRestaurantDTO> GetById(int id);
        Task Create(ThematicRestaurantDTO thematicRestaurantDTO);
        Task Update(ThematicRestaurantDTO thematicRestaurantDTO);
        Task Delete(ThematicRestaurantDTO thematicRestaurantDTO);
    }
}