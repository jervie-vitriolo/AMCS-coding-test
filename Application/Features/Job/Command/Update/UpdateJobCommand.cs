using MediatR;

namespace Application.Features.Job.Command.Update;

public record UpdateJobCommand(Guid Id, DateTime startdate, DateTime duedate, double budget, string description, int acceptedby) : IRequest;