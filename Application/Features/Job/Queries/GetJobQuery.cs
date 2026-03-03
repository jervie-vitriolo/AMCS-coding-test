using Application.Features.Customer.DTOs;
using MediatR;

namespace Application.Features.Customer.Queries;

public record GetJobQuery(string JobDescription) : IRequest<List<JobDto>>;