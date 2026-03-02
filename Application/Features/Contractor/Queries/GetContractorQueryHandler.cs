using Application.Features.Contractor.DTOs;
using Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customer.Queries;

public class GetContractorQueryHandler(AppDbContext context)
    : IRequestHandler<GetContractorQuery, List<ContractorDto>>
{
    public async Task<List<ContractorDto>> Handle(GetContractorQuery request, CancellationToken cancellationToken)
    {
        return await context.Contractors
         .Select(c => new ContractorDto(c.Id,c.Name,c.Rating))
         .Where(c=>c.name.ToUpper().Contains(request.param.ToUpper()) || c.id.ToUpper().Equals(request.param.ToUpper()))
         .ToListAsync();
    }
}
