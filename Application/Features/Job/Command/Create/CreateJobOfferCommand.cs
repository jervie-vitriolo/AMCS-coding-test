using MediatR;

namespace Application.Features.Job.Command.Create;

public record CreateJobOfferCommand(Guid id, double budget) : IRequest<bool>;