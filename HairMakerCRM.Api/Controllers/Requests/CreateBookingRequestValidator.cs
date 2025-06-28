using FluentValidation;

namespace HairMakerCRM.Api.Controllers.Requests;

public class CreateBookingRequestValidator : AbstractValidator<CreateBookingRequest>
{
    public CreateBookingRequestValidator()
    {
        RuleFor(r => r.BargainItems).NotEmpty();

        RuleFor(r => r.ChosenMaster).NotNull();

        RuleFor(r => r.StartTime).Must(BeInFuture);
    }

    private bool BeInFuture(DateTime date)
        => date >= DateTime.Now;
}
