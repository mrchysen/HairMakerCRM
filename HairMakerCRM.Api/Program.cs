using FluentValidation;
using HairMakerCRM.Api.Controllers.Requests;
using HairMakerCRM.Core.Booking;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<IBookingRepository, BookingRepositoryMock>();
builder.Services.AddScoped<ICreateBookingService, BookingService>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingRequestValidator>();

var app = builder.Build();

app.MapControllers();

app.Run();
