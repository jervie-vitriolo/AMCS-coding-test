using MediatR;

namespace Application.Features.Job.Command.Create;

public record CreateJobCommand( DateTime startdate, DateTime duedate, double budget, string description, string acceptedby) : IRequest<Guid>;
