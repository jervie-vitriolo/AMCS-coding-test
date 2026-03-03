using FluentValidation;

namespace Application.Features.Job.Command.Create;

public class CreateJobCommandValidator: AbstractValidator<CreateJobCommand>
{
    public CreateJobCommandValidator()
    {
        RuleFor(v => v.startdate).NotEmpty().WithMessage("Start date is required");
        RuleFor(v => v.duedate).NotEmpty().WithMessage("Due date is required")
                               .GreaterThan(v => v.startdate).WithMessage("Due date must be after Start date");
        RuleFor(v => v.budget).GreaterThan(0);
    }
}
