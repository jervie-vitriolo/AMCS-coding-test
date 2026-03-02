using Application.Features.Customer.DTOs;
using Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customer.Queries;

public class GetCustomerQueryHandler(AppDbContext context)
    : IRequestHandler<GetCustomerQuery, List<CustomerDto>>
{
    public async Task<List<CustomerDto>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        return await context.Customers
         .Select(c => new CustomerDto(c.Id,c.FirstName,c.LastName))
         .Where(c=>c.lastname.ToUpper().Contains(request.param.ToUpper()) || c.id.ToUpper().Equals(request.param.ToUpper()))
         .ToListAsync();
    }
}
