using FluentValidation;

namespace Application.Features.Job.Command.Create;

public class CreateJobOfferCommandValidator : AbstractValidator<CreateJobOfferCommand>
{
    public CreateJobOfferCommandValidator()
    {
        RuleFor(v => v.id).NotEmpty();
        RuleFor(v => v.budget).NotEmpty()
                              .GreaterThan(0);
    }
}
