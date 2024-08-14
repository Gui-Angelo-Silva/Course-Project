using AutoMapper;
using backend.Objects.DTOs.Entities;
using backend.Objects.Models.Entities;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Entities;
public class RestaurantService : IRestaurantService
{

    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IMapper _mapper;

    public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
    {
        _restaurantRepository = restaurantRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RestaurantDTO>> GetAll()
    {
        var restaurantsModel = await _restaurantRepository.GetAll();
        return _mapper.Map<IEnumerable<RestaurantDTO>>(restaurantsModel);
    }

    public async Task<RestaurantDTO> GetById(int id)
    {
        var restaurantModel = await _restaurantRepository.GetById(id);
        return _mapper.Map<RestaurantDTO>(restaurantModel);
    }

    public async Task Create(RestaurantDTO restaurantDTO)
    {
        var restaurantModel = _mapper.Map<RestaurantModel>(restaurantDTO);
        await _restaurantRepository.Create(restaurantModel);

        restaurantDTO.Id = restaurantModel.Id;
    }

    public async Task Update(RestaurantDTO restaurantDTO)
    {
        var restaurantModel = _mapper.Map<RestaurantModel>(restaurantDTO);
        await _restaurantRepository.Update(restaurantModel);
    }

    public async Task Delete(RestaurantDTO restaurantDTO)
    {
        var restaurantModel = _mapper.Map<RestaurantModel>(restaurantDTO);
        await _restaurantRepository.Delete(restaurantModel);
    }
}