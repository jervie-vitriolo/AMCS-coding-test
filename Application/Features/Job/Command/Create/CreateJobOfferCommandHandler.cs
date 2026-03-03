using Application.Features.Job.Command.Update;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;

namespace Application.Features.Job.Command.Create;

public class CreateJobOfferCommandHandler(AppDbContext context) : IRequestHandler<CreateJobOfferCommand, bool>
{
    public  async Task<bool> Handle(CreateJobOfferCommand command, CancellationToken cancellationToken)
    {
        var job = await context.Jobs
           .FindAsync(command.id, cancellationToken);

        if (job is null) return false;

        job.Budget = command.Budget;

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
