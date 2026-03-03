using MediatR;

namespace Application.Features.Job.Command.Update;

public record AcceptJobCommand(Guid id, string acceptedby) : IRequest<bool>;