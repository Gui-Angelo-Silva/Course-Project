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
        var restaurants = await _restaurantRepository.GetAll();
        return _mapper.Map<IEnumerable<RestaurantDTO>>(restaurants);
    }

    public async Task<RestaurantDTO> GetById(int id)
    {
        var restaurant = await _restaurantRepository.GetById(id);
        return _mapper.Map<RestaurantDTO>(restaurant);
    }

    public async Task Create(RestaurantDTO restaurantDTO)
    {
        var restaurant = _mapper.Map<RestaurantModel>(restaurantDTO);
        await _restaurantRepository.Create(restaurant);
        restaurantDTO.Id = restaurant.Id;
    }

    public async Task Update(RestaurantDTO restaurantDTO)
    {
        var restaurant = _mapper.Map<RestaurantModel>(restaurantDTO);
        await _restaurantRepository.Update(restaurant);
    }

    public async Task Delete(int id)
    {
        await _restaurantRepository.Delete(id);
    }
}