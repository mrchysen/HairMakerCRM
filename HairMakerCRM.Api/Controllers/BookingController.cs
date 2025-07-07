using FluentValidation;
using HairMakerCRM.Api.Controllers.Requests;
using HairMakerCRM.Core.Booking;
using HairMakerCRM.Core.Booking.Models;
using Microsoft.AspNetCore.Mvc;

namespace HairMakerCRM.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController(
    ICreateBookingService createBookingService,
    IBookingCanceler bookingCanceler,
    IBookingRepository bookingRepository,
    IValidator<CreateBookingRequest> createBookingRequestValidator) : ControllerBase
{
    /// <summary>
    /// Customer try to book time for service.
    /// Master, BargainItems and StartTime must be chosen.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("create-booking")]
    public async Task<BookingItem> CreateBooking(CreateBookingRequest request)
    {
        await createBookingRequestValidator.ValidateAndThrowAsync(request);

        return await createBookingService.CreateBooking(
            request.StartTime,
            request.BargainItemIds,
            request.ChosenMasterId);
    }

    /// <summary>
    /// Customers and masters can cancel booking.
    /// </summary>
    /// <param name="bookingId"></param>
    /// <returns></returns>
    [HttpPut("cancel")]
    public async Task CancelBooking(string bookingId)
        => await bookingCanceler.Cancel(bookingId);

    [HttpGet]
    public async Task<List<BookingItem>> GetBookings(GetBookingRequest request)
    {

    }

    /// <summary>
    /// Customers can see booking by id if it exists
    /// </summary>
    /// <param name="bookingId"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<BookingItem?> GetBookingById(Guid bookingId) 
        => await bookingRepository.GetById(bookingId);
}
