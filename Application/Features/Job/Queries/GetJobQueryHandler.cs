using Application.Features.Customer.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;

namespace Application.Features.Customer.Queries;

public class GetJobQueryHandler(AppDbContext context)
    : IRequestHandler<GetJobQuery, List<JobDto>>
{
    public async Task<List<JobDto>> Handle(GetJobQuery request, CancellationToken cancellationToken)
    {
        return await context.Jobs
         .Select(c => new JobDto(c.Id,c.StartDate,c.DueDate,c.Budget,c.Description,c.AcceptedBy))
         .Where(c=> c.description.ToUpper().Contains(request.JobDescription))
         .ToListAsync();
    }
}
