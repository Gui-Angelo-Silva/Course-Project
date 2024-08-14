using AutoMapper;
using backend.Objects.DTOs.Entities;
using backend.Objects.Models.Entities;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Entities;
public class TableService : ITableService
{

    private readonly ITableRepository _tableRepository;
    private readonly IMapper _mapper;

    public TableService(ITableRepository tableRepository, IMapper mapper)
    {
        _tableRepository = tableRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TableDTO>> GetAll()
    {
        var tablesModel = await _tableRepository.GetAll();
        return _mapper.Map<IEnumerable<TableDTO>>(tablesModel);
    }

    public async Task<IEnumerable<TableDTO>> GetTablesRelatedRestaurant(int idRestaurant)
    {
        var tablesModel = await _tableRepository.GetTablesRelatedRestaurant(idRestaurant);
        return _mapper.Map<IEnumerable<TableDTO>>(tablesModel);
    }

    public async Task<TableDTO> GetById(int id)
    {
        var tableModel = await _tableRepository.GetById(id);
        return _mapper.Map<TableDTO>(tableModel);
    }

    public async Task Create(TableDTO tableDTO)
    {
        var tableModel = _mapper.Map<TableModel>(tableDTO);
        await _tableRepository.Create(tableModel);

        tableDTO.Id = tableModel.Id;
    }

    public async Task Update(TableDTO tableDTO)
    {
        var tableModel = _mapper.Map<TableModel>(tableDTO);
        await _tableRepository.Update(tableModel);
    }

    public async Task Delete(TableDTO tableDTO)
    {
        var tableModel = _mapper.Map<TableModel>(tableDTO);
        await _tableRepository.Delete(tableModel);
    }
}