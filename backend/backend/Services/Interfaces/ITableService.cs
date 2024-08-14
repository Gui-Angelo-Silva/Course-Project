using backend.Objects.DTOs.Entities;
using backend.Objects.Models.Entities;

namespace backend.Services.Interfaces
{
    public interface ITableService
    {
        Task<IEnumerable<TableDTO>> GetAll();
        Task<IEnumerable<TableDTO>> GetTablesRelatedRestaurant(int idRestaurant);
        Task<TableDTO> GetById(int id);
        Task Create(TableDTO tableDTO);
        Task Update(TableDTO tableDTO);
        Task Delete(TableDTO tableDTO);
    }
}