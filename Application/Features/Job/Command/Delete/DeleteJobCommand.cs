using MediatR;

namespace Application.Features.Job.Command.Delete;

public record DeleteJobCommand(Guid Id) : IRequest;
