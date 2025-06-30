using FluentValidation;
using HairMakerCRM.Api.Controllers.Requests;
using HairMakerCRM.Core.Booking;
using Microsoft.AspNetCore.Mvc;

namespace HairMakerCRM.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController(
    IBookingService bookingService,
    IValidator<CreateBookingRequest> createBookingRequestValidator) : ControllerBase
{
    /// <summary>
    /// Customer try to book time for service.
    /// Master, BargainItems and StartTime must be chosen.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<BookingItem> CreateBooking(CreateBookingRequest request)
    {
        await createBookingRequestValidator.ValidateAndThrowAsync(request);

        return await bookingService.CreateBooking(
            request.StartTime, 
            request.BargainItemIds, 
            request.ChosenMasterId);
    }

    public async Task<BookingItem> CancelBooking(string bookingId)
    {

    }
}
