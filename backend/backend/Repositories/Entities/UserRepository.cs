using backend.Context;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using backend.Objects.Models.Entities;
using backend.Objects.DTOs.Entities;
using backend.Objects.Utilities;

namespace backend.Repositories.Entities;
public class UserRepository : IUserRepository
{

    private readonly AppDBContext _dbContext;

    public UserRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<UserModel>> GetAll()
    {
        return await _dbContext.User.AsNoTracking().ToListAsync();
    }

    public async Task<UserModel> GetById(int id)
    {
        return await _dbContext.User.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<UserModel> Login(Login login)
    {
        return await _dbContext.User.AsNoTracking().FirstOrDefaultAsync(u => u.EmailUser == login.Email && u.PasswordUser == login.Password);
    }

    public async Task<UserModel> Create(UserModel userModel)
    {
        _dbContext.User.Add(userModel);
        await _dbContext.SaveChangesAsync();

        return userModel;
    }

    public async Task<UserModel> Update(UserModel userModel)
    {
        _dbContext.Entry(userModel).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return userModel;
    }

    public async Task<UserModel> Delete(UserModel userModel)
    {
        _dbContext.User.Remove(userModel);
        await _dbContext.SaveChangesAsync();

        return userModel;
    }
}