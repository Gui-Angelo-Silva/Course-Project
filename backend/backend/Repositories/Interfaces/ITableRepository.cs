using backend.Objects.Models.Entities;

namespace backend.Repositories.Interfaces;
public interface ITableRepository
{
    Task<IEnumerable<TableModel>> GetAll();
    Task<IEnumerable<TableModel>> GetTablesRelatedRestaurant(int idRestaurant);
    Task<TableModel> GetById(int id);
    Task<TableModel> Create(TableModel tableModel);
    Task<TableModel> Update(TableModel tableModel);
    Task<TableModel> Delete(TableModel tableModel);
}