using Application.Features.Contractor.DTOs;
using MediatR;

namespace Application.Features.Customer.Queries;

public record GetContractorQuery(string param) : IRequest<List<ContractorDto>>;