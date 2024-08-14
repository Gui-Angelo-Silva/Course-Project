using backend.Objects.DTOs.Entities;

namespace backend.Services.Interfaces
{
    public interface IThematicService
    {
        Task<IEnumerable<ThematicDTO>> GetAll();
        Task<ThematicDTO> GetById(int id);
        Task Create(ThematicDTO thematicDTO);
        Task Update(ThematicDTO thematicDTO);
        Task Delete(ThematicDTO thematicDTO);
    }
}