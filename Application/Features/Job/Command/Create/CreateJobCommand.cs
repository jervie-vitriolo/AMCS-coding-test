using MediatR;

namespace Application.Features.Job_.Command.Create;

public record CreateJobCommand(Guid Id,DateTime startdate, DateTime duedate, double budget, string description, int acceptedby) : IRequest<Guid>;
