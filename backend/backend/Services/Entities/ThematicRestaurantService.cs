using AutoMapper;
using backend.Objects.DTOs.Entities;
using backend.Objects.Models.Entities;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Entities;
public class ThematicRestaurantService : IThematicRestaurantService
{

    private readonly IThematicRestaurantRepository _thematicRestaurantRepository;
    private readonly IMapper _mapper;

    public ThematicRestaurantService(IThematicRestaurantRepository thematicRestaurantRepository, IMapper mapper)
    {
        _thematicRestaurantRepository = thematicRestaurantRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ThematicRestaurantDTO>> GetAll()
    {
        var thematicRestaurantsModel = await _thematicRestaurantRepository.GetAll();
        return _mapper.Map<IEnumerable<ThematicRestaurantDTO>>(thematicRestaurantsModel);
    }

    public async Task<ThematicRestaurantDTO> GetById(int id)
    {
        var thematicRestaurantModel = await _thematicRestaurantRepository.GetById(id);
        return _mapper.Map<ThematicRestaurantDTO>(thematicRestaurantModel);
    }

    public async Task Create(ThematicRestaurantDTO thematicRestaurantDTO)
    {
        var thematicRestaurantModel = _mapper.Map<ThematicRestaurantModel>(thematicRestaurantDTO);
        await _thematicRestaurantRepository.Create(thematicRestaurantModel);

        thematicRestaurantDTO.Id = thematicRestaurantModel.Id;
    }

    public async Task Update(ThematicRestaurantDTO thematicRestaurantDTO)
    {
        var thematicRestaurantModel = _mapper.Map<ThematicRestaurantModel>(thematicRestaurantDTO);
        await _thematicRestaurantRepository.Update(thematicRestaurantModel);
    }

    public async Task Delete(ThematicRestaurantDTO thematicRestaurantDTO)
    {
        var thematicRestaurantModel = _mapper.Map<ThematicRestaurantModel>(thematicRestaurantDTO);
        await _thematicRestaurantRepository.Delete(thematicRestaurantModel);
    }
}