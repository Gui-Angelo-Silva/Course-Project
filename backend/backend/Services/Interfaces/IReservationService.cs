using backend.Objects.DTOs.Entities;
using backend.Objects.Models.Entities;

namespace backend.Services.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDTO>> GetAll();
        Task<IEnumerable<ReservationDTO>> GetReservationsRelatedUser(int idUser);
        Task<IEnumerable<ReservationDTO>> GetReservationsRelatedTable(int idTable);
        Task<ReservationDTO> GetById(int id);
        Task Create(ReservationDTO reservationDTO);
        Task Update(ReservationDTO reservationDTO);
        Task Delete(ReservationDTO reservationDTO);
    }
}