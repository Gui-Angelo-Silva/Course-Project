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

    public async Task<TableModel> Create(TableModel tableModel)
    {
        _dbContext.Table.Add(tableModel);
        await _dbContext.SaveChangesAsync();

        return tableModel;
    }

    public async Task<TableModel> Update(TableModel tableModel)
    {
        _dbContext.Entry(tableModel).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return tableModel;
    }

    public async Task<TableModel> Delete(TableModel tableModel)
    {
        _dbContext.Table.Remove(tableModel);
        await _dbContext.SaveChangesAsync();

        return tableModel;
    }
}