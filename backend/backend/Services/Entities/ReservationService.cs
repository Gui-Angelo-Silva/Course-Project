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
        var reservations = await _reservationRepository.GetAll();
        return _mapper.Map<IEnumerable<ReservationDTO>>(reservations);
    }

    public async Task<IEnumerable<ReservationDTO>> GetReservationsRelatedUser(int idUser)
    {
        var reservations = await _reservationRepository.GetReservationsRelatedUser(idUser);
        return _mapper.Map<IEnumerable<ReservationDTO>>(reservations);
    }

    public async Task<ReservationDTO> GetById(int id)
    {
        var reservation = await _reservationRepository.GetById(id);
        return _mapper.Map<ReservationDTO>(reservation);
    }

    public async Task Create(ReservationDTO reservationDTO)
    {
        var reservation = _mapper.Map<ReservationModel>(reservationDTO);
        await _reservationRepository.Create(reservation);
        reservationDTO.Id = reservation.Id;
    }

    public async Task Update(ReservationDTO reservationDTO)
    {
        var reservation = _mapper.Map<ReservationModel>(reservationDTO);
        await _reservationRepository.Update(reservation);
    }

    public async Task Delete(int id)
    {
        await _reservationRepository.Delete(id);
    }
}