using backend.Objects.Models.Entities;

namespace backend.Repositories.Interfaces;
public interface IThematicRepository
{
    Task<IEnumerable<ThematicModel>> GetAll();
    Task<ThematicModel> GetById(int id);
    Task<ThematicModel> Create(ThematicModel thematicModel);
    Task<ThematicModel> Update(ThematicModel thematicModel);
    Task<ThematicModel> Delete(ThematicModel thematicModel);
}