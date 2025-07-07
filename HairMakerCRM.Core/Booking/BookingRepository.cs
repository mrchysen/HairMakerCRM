using HairMakerCRM.Core.Booking.Models;
using HairMakerCRM.Core.Masters;

namespace HairMakerCRM.Core.Booking;

public interface IBookingRepository
{
    Task<IEnumerable<BookingItem>> GetAll();

    Task<IEnumerable<BookingItem>> GetAllByParams();

    Task<BookingItem?> GetById(Guid id);

    Task Add(BookingItem bookingItem);

    Task Update(BookingItem bookingItem);

    Task Delete(Guid id);

    Task<IEnumerable<BookingItem>> GetByDateRangeAndMaster(
        DateTime startTime, 
        DateTime endTime, 
        Master master);

    Task UpdateStatus(Guid id, BookingStatus newStatus);
}

public class BookingRepository : IBookingRepository
{
    public Task Add(BookingItem bookingItem)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BookingItem>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BookingItem>> GetByDateRange(DateTime startTime, DateTime endTime)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BookingItem>> GetByDateRangeAndMaster(DateTime startTime, DateTime endTime, Master master)
    {
        throw new NotImplementedException();
    }

    public Task<BookingItem?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Update(BookingItem bookingItem)
    {
        throw new NotImplementedException();
    }

    public Task UpdateStatus(Guid id, BookingStatus newStatus)
    {
        throw new NotImplementedException();
    }
}

public class BookingRepositoryMock : IBookingRepository
{
    private List<BookingItem> _bookingItems = new List<BookingItem>();

    public Task Add(BookingItem bookingItem)
    {
        _bookingItems.Add(bookingItem);

        return Task.CompletedTask;
    }

    public Task Delete(Guid id)
    {
        _bookingItems.RemoveAll(c => c.Id == id);

        return Task.CompletedTask;
    }

    public async Task<IEnumerable<BookingItem>> GetAll()
    {
        return await Task.FromResult(_bookingItems);
    }

    public async Task<IEnumerable<BookingItem>> GetByDateRange(
        DateTime startTime, 
        DateTime endTime,
        Master master)
    {
        return await Task.FromResult(
            _bookingItems.Where(el => 
                master.Name == el.Master.Name &&
                el.StartTime <=  startTime && 
                el.EndTime <= endTime &&
                el.BookingStatus != BookingStatus.Canceled)
            .ToList());
    }

    public Task<IEnumerable<BookingItem>> GetByDateRangeAndMaster(DateTime startTime, DateTime endTime, Master master)
    {
        throw new NotImplementedException();
    }

    public async Task<BookingItem?> GetById(Guid id)
    {
        return await Task.FromResult(
            _bookingItems.FirstOrDefault(c => c?.Id == id, null));
    }

    public Task Update(BookingItem bookingItem)
    {
        var index = _bookingItems.FindIndex(c => c.Id == bookingItem.Id);

        if(index == -1)
            return Task.CompletedTask;

        _bookingItems[index] = bookingItem;

        return Task.CompletedTask;
    }

    public Task UpdateStatus(Guid id, BookingStatus newStatus)
    {
        var index = _bookingItems.FindIndex(c => c.Id == id);

        if (index == -1)
            return Task.CompletedTask;

        _bookingItems[index] = _bookingItems[index] with { BookingStatus = newStatus };

        return Task.CompletedTask;
    }
}
