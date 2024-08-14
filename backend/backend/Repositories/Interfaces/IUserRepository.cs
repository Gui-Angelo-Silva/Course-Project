using backend.Objects.DTOs.Entities;
using backend.Objects.Models.Entities;

namespace backend.Repositories.Interfaces;
public interface IUserRepository
{
    Task<IEnumerable<UserModel>> GetAll();
    Task<UserModel> GetById(int id);
    Task<UserModel> Login(Login login);
    Task<UserModel> Create(UserModel userModel);
    Task<UserModel> Update(UserModel userModel);
    Task<UserModel> Delete(UserModel userModel);
}