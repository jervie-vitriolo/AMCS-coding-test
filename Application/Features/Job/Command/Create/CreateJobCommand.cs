using MediatR;

namespace Application.Features.Job.Command.Create;

public record CreateJobCommand(Guid Id,DateTime startdate, DateTime duedate, double budget, string description, string acceptedby) : IRequest<Guid>;
