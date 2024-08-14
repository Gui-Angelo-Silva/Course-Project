using backend.Objects.Models.Entities;

namespace backend.Repositories.Interfaces;
public interface IReservationRepository
{
    Task<IEnumerable<ReservationModel>> GetAll();
    Task<IEnumerable<ReservationModel>> GetReservationsRelatedUser(int idUser);
    Task<IEnumerable<ReservationModel>> GetReservationsRelatedTable(int idTable);
    Task<ReservationModel> GetById(int id);
    Task<ReservationModel> Create(ReservationModel reservationModel);
    Task<ReservationModel> Update(ReservationModel reservationModel);
    Task<ReservationModel> Delete(ReservationModel reservationModel);
}