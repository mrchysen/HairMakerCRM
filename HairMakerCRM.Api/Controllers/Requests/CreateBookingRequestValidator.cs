using FluentValidation;

namespace HairMakerCRM.Api.Controllers.Requests;

public class CreateBookingRequestValidator : AbstractValidator<CreateBookingRequest>
{
    public CreateBookingRequestValidator()
    {
        RuleFor(r => r.BargainItemIds).NotEmpty();

        RuleFor(r => r.ChosenMasterId).NotNull();

        RuleFor(r => r.StartTime).Must(BeInFuture);
    }

    private bool BeInFuture(DateTime date)
        => date >= DateTime.Now;
}
