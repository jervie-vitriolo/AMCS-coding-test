using MediatR;
using Persistence;

namespace Application.Features.Job.Command.Create;

public class CreateJobCommandHandler(AppDbContext context) : IRequestHandler<CreateJobCommand, Guid>
{
    public async Task<Guid> Handle(CreateJobCommand command, CancellationToken cancellationToken)
    {
        var job = new Domain.Job(command.Id,command.startdate,command.duedate,command.budget,command.description,command.acceptedby);
        await context.Jobs.AddAsync(job);
        await context.SaveChangesAsync();
        return job.Id;
    }
}
