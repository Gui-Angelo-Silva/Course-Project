using backend.Objects.Models.Entities;

namespace backend.Repositories.Interfaces;
public interface IUserRepository
{
    Task<IEnumerable<UserModel>> GetAll();
    Task<UserModel> GetById(int id);
    Task<UserModel> Create(UserModel user);
    Task<UserModel> Update(UserModel user);
    Task<UserModel> Delete(int id);
}