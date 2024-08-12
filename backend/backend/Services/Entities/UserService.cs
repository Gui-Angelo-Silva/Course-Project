using AutoMapper;
using backend.Objects.DTOs.Entities;
using backend.Objects.Models.Entities;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Entities;
public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDTO>> GetAll()
    {
        var users = await _userRepository.GetAll();
        return _mapper.Map<IEnumerable<UserDTO>>(users);
    }

    public async Task<UserDTO> GetById(int id)
    {
        var user = await _userRepository.GetById(id);
        return _mapper.Map<UserDTO>(user);
    }

    public async Task Create(UserDTO userDTO)
    {
        var user = _mapper.Map<UserModel>(userDTO);
        await _userRepository.Create(user);
        userDTO.Id = user.Id;
    }

    public async Task Update(UserDTO userDTO)
    {
        var user = _mapper.Map<UserModel>(userDTO);
        await _userRepository.Update(user);
    }

    public async Task Delete(int id)
    {
        await _userRepository.Delete(id);
    }
}