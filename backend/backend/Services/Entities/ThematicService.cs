using AutoMapper;
using backend.Objects.DTOs.Entities;
using backend.Objects.Models.Entities;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Entities;
public class ThematicService : IThematicService
{

    private readonly IThematicRepository _thematicRepository;
    private readonly IMapper _mapper;

    public ThematicService(IThematicRepository thematicRepository, IMapper mapper)
    {
        _thematicRepository = thematicRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ThematicDTO>> GetAll()
    {
        var thematicsModel = await _thematicRepository.GetAll();
        return _mapper.Map<IEnumerable<ThematicDTO>>(thematicsModel);
    }

    public async Task<ThematicDTO> GetById(int id)
    {
        var thematicModel = await _thematicRepository.GetById(id);
        return _mapper.Map<ThematicDTO>(thematicModel);
    }

    public async Task Create(ThematicDTO thematicDTO)
    {
        var thematicModel = _mapper.Map<ThematicModel>(thematicDTO);
        await _thematicRepository.Create(thematicModel);

        thematicDTO.Id = thematicModel.Id;
    }

    public async Task Update(ThematicDTO thematicDTO)
    {
        var thematicModel = _mapper.Map<ThematicModel>(thematicDTO);
        await _thematicRepository.Update(thematicModel);
    }

    public async Task Delete(ThematicDTO thematicDTO)
    {
        var thematicModel = _mapper.Map<ThematicModel>(thematicDTO);
        await _thematicRepository.Delete(thematicModel);
    }
}