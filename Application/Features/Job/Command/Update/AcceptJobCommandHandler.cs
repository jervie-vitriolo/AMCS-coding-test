using Application.Features.Job.Command.Update;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;

namespace Application.Features.Job.Command.Update;

public class AcceptJobCommandHandler(AppDbContext context) : IRequestHandler<AcceptJobCommand,bool>
{
    public  async Task<bool> Handle(AcceptJobCommand command, CancellationToken cancellationToken)
    {
        var job = await context.Jobs
           .FindAsync(command.id, cancellationToken);

        var customer = await context.Customers
           .FindAsync(command.acceptedby, cancellationToken);

        if (job is null || customer is null) return false;

        job.AcceptedBy = command.acceptedby;

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
