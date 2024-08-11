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
        var tables = await _tableRepository.GetAll();
        return _mapper.Map<IEnumerable<TableDTO>>(tables);
    }

    public async Task<IEnumerable<TableDTO>> GetTablesRelatedRestaurant(int idRestaurant)
    {
        var tables = await _tableRepository.GetTablesRelatedRestaurant(idRestaurant);
        return _mapper.Map<IEnumerable<TableDTO>>(tables);
    }

    public async Task<TableDTO> GetById(int id)
    {
        var table = await _tableRepository.GetById(id);
        return _mapper.Map<TableDTO>(table);
    }

    public async Task Create(TableDTO tableDTO)
    {
        var table = _mapper.Map<TableModel>(tableDTO);
        await _tableRepository.Create(table);
        tableDTO.Id = table.Id;
    }

    public async Task Update(TableDTO tableDTO)
    {
        var table = _mapper.Map<TableModel>(tableDTO);
        await _tableRepository.Update(table);
    }

    public async Task Delete(int id)
    {
        await _tableRepository.Delete(id);
    }
}