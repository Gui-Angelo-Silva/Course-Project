using backend.Context;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using backend.Objects.Models.Entities;

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

    public async Task<UserModel> Create(UserModel user)
    {
        _dbContext.User.Add(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<UserModel> Update(UserModel user)
    {
        _dbContext.Entry(user).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<UserModel> Delete(int id)
    {
        var user = await GetById(id);
        _dbContext.User.Remove(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }
}