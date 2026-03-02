using Application.Features.Job.Command.Update;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;

namespace Application.Features.Job.Command.Update;

public class UpdateJobCommandHandler(AppDbContext context) : IRequestHandler<UpdateJobCommand>
{
    public  async Task Handle(UpdateJobCommand command, CancellationToken cancellationToken)
    {
        var job = await context.Jobs
           .FindAsync(command.Id, cancellationToken);

        if (job is null) return;

        job.StartDate = command.startdate;
        job.DueDate = command.duedate;
        job.Budget = command.budget;
        job.Description = command.description;
        job.AcceptedBy = command.acceptedby;

        await context.SaveChangesAsync(cancellationToken);
    }
}
