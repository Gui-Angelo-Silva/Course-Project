using backend.Objects.DTOs.Entities;
using backend.Objects.Models.Entities;

namespace backend.Services.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDTO>> GetAll();
        Task<IEnumerable<ReservationDTO>> GetReservationsRelatedUser(int idUser);
        Task<ReservationDTO> GetById(int id);
        Task Create(ReservationDTO reservationDTO);
        Task Update(ReservationDTO reservationDTO);
        Task Delete(int id);
    }
}