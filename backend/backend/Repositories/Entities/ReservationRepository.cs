using backend.Context;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using backend.Objects.Models.Entities;

namespace backend.Repositories.Entities;
public class ReservationRepository : IReservationRepository
{

    private readonly AppDBContext _dbContext;

    public ReservationRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ReservationModel>> GetAll()
    {
        return await _dbContext.Reservation.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<ReservationModel>> GetReservationsRelatedUser(int idUser)
    {
        return await _dbContext.Reservation.AsNoTracking().Where(r => r.IdUser == idUser).ToListAsync();
    }

    public async Task<IEnumerable<ReservationModel>> GetReservationsRelatedTable(int idTable)
    {
        return await _dbContext.Reservation.AsNoTracking().Where(r => r.IdTable == idTable).ToListAsync();
    }

    public async Task<ReservationModel> GetById(int id)
    {
        return await _dbContext.Reservation.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<ReservationModel> Create(ReservationModel reservationModel)
    {
        _dbContext.Reservation.Add(reservationModel);
        await _dbContext.SaveChangesAsync();

        return reservationModel;
    }

    public async Task<ReservationModel> Update(ReservationModel reservationModel)
    {
        _dbContext.Entry(reservationModel).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return reservationModel;
    }

    public async Task<ReservationModel> Delete(ReservationModel reservationModel)
    {
        _dbContext.Reservation.Remove(reservationModel);
        await _dbContext.SaveChangesAsync();

        return reservationModel;
    }
}