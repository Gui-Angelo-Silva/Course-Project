using backend.Context;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using backend.Objects.Models.Entities;

namespace backend.Repositories.Entities;
public class TableRepository : ITableRepository
{

    private readonly AppDBContext _dbContext;

    public TableRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<TableModel>> GetAll()
    {
        return await _dbContext.Table.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<TableModel>> GetTablesRelatedRestaurant(int idRestaurant)
    {
        return await _dbContext.Table.AsNoTracking().Where(t => t.IdRestaurant == idRestaurant).ToListAsync();
    }

    public async Task<TableModel> GetById(int id)
    {
        return await _dbContext.Table.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<TableModel> Create(TableModel table)
    {
        _dbContext.Table.Add(table);
        await _dbContext.SaveChangesAsync();

        return table;
    }

    public async Task<TableModel> Update(TableModel table)
    {
        _dbContext.Entry(table).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return table;
    }

    public async Task<TableModel> Delete(int id)
    {
        var table = await GetById(id);
        _dbContext.Table.Remove(table);
        await _dbContext.SaveChangesAsync();

        return table;
    }
}