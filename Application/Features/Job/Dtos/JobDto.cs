namespace Application.Features.Customer.DTOs;
public record JobDto(Guid id, DateTime startdate, DateTime duedate, double budget, string description, int acceptedby);
