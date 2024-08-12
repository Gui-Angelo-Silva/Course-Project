using backend.Objects.Models.Entities;

namespace backend.Repositories.Interfaces;
public interface IReservationRepository
{
    Task<IEnumerable<ReservationModel>> GetAll();
    Task<IEnumerable<ReservationModel>> GetReservationsRelatedUser(int idUser);
    Task<IEnumerable<ReservationModel>> GetReservationsRelatedTable(int idTable);
    Task<ReservationModel> GetById(int id);
    Task<ReservationModel> Create(ReservationModel reservation);
    Task<ReservationModel> Update(ReservationModel reservation);
    Task<ReservationModel> Delete(int id);
}