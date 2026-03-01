using Application.Features.Products.DTOs;
using MediatR;

namespace Application.Features.Customer.Queries;

public record GetCustomerQuery(string lastname) : IRequest<List<CustomerDto>>;