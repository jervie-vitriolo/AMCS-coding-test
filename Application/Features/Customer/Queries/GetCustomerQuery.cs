using Application.Features.Customer.DTOs;
using MediatR;

namespace Application.Features.Customer.Queries;

public record GetCustomerQuery(string param) : IRequest<List<CustomerDto>>;