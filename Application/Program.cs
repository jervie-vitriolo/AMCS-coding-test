
using Persistence;
using MediatR;
using System.Reflection;
using Application.Features.Customer.Queries;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/customers/{IdOrLastName}", async (string param, ISender mediatr) =>
{
    var customer = await mediatr.Send(new GetCustomerQuery(param));
    if (customer == null) return Results.NotFound();
    return Results.Ok(customer);
}).WithSummary("Retrieves a specific customers by Id or Last Name");


/// <summary>
/// Retrieves a specific contractors by Id or Business Name
/// </summary>
app.MapGet("/contractors/{IdOrBusinessName}", async (string param, ISender mediatr) =>
{
    var customer = await mediatr.Send(new GetContractorQuery(param));
    if (customer == null) return Results.NotFound();
    return Results.Ok(customer);

}).WithSummary("Retrieves a specific contractors by Id or Business Name"); 

app.UseHttpsRedirection();
app.Run();
