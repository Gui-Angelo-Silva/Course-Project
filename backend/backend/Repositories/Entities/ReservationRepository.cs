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

    public async Task<ReservationModel> GetById(int id)
    {
        return await _dbContext.Reservation.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<ReservationModel> Create(ReservationModel reservation)
    {
        _dbContext.Reservation.Add(reservation);
        await _dbContext.SaveChangesAsync();

        return reservation;
    }

    public async Task<ReservationModel> Update(ReservationModel reservation)
    {
        _dbContext.Entry(reservation).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return reservation;
    }

    public async Task<ReservationModel> Delete(int id)
    {
        var reservation = await GetById(id);
        _dbContext.Reservation.Remove(reservation);
        await _dbContext.SaveChangesAsync();

        return reservation;
    }
}