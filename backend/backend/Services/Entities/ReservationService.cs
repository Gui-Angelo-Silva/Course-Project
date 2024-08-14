using AutoMapper;
using backend.Objects.DTOs.Entities;
using backend.Objects.Models.Entities;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Entities;
public class ReservationService : IReservationService
{

    private readonly IReservationRepository _reservationRepository;
    private readonly IMapper _mapper;

    public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
    {
        _reservationRepository = reservationRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReservationDTO>> GetAll()
    {
        var reservationsModel = await _reservationRepository.GetAll();
        return _mapper.Map<IEnumerable<ReservationDTO>>(reservationsModel);
    }

    public async Task<IEnumerable<ReservationDTO>> GetReservationsRelatedUser(int idUser)
    {
        var reservationsModel = await _reservationRepository.GetReservationsRelatedUser(idUser);
        return _mapper.Map<IEnumerable<ReservationDTO>>(reservationsModel);
    }

    public async Task<IEnumerable<ReservationDTO>> GetReservationsRelatedTable(int idTable)
    {
        var reservationsModel = await _reservationRepository.GetReservationsRelatedTable(idTable);
        return _mapper.Map<IEnumerable<ReservationDTO>>(reservationsModel);
    }

    public async Task<ReservationDTO> GetById(int id)
    {
        var reservationModel = await _reservationRepository.GetById(id);
        return _mapper.Map<ReservationDTO>(reservationModel);
    }

    public async Task Create(ReservationDTO reservationDTO)
    {
        var reservationModel = _mapper.Map<ReservationModel>(reservationDTO);
        await _reservationRepository.Create(reservationModel);

        reservationDTO.Id = reservationModel.Id;
    }

    public async Task Update(ReservationDTO reservationDTO)
    {
        var reservationModel = _mapper.Map<ReservationModel>(reservationDTO);
        await _reservationRepository.Update(reservationModel);
    }

    public async Task Delete(ReservationDTO reservationDTO)
    {
        var reservationModel = _mapper.Map<ReservationModel>(reservationDTO);
        await _reservationRepository.Delete(reservationModel);
    }
}