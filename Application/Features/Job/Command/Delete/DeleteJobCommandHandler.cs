using MediatR;
using Persistence;

namespace Application.Features.Job.Command.Delete;

public class DeleteJobCommandHandler(AppDbContext context) : IRequestHandler<DeleteJobCommand>
{
    public async Task Handle(DeleteJobCommand command, CancellationToken cancellationToken)
    {
        var job = await context.Jobs.FindAsync(command.Id);
        if (job is null) return;
        context.Jobs.Remove(job);
        await context.SaveChangesAsync();
    }
}
