using FluentValidation;

namespace Application.Features.Job.Command.Update;

public class AcceptJobCommandValidator : AbstractValidator<AcceptJobCommand>
{
    public AcceptJobCommandValidator()
    {
        RuleFor(v => v.id).NotEmpty();
        RuleFor(v => v.acceptedby).NotEmpty();
    }
}
