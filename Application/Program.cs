
using Persistence;
using MediatR;
using System.Reflection;
using Application.Features.Customer.Queries;
using Application.Features.Job.Command.Create;
using Application.Features.Job.Command.Delete;

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

//Customers Endpoint
app.MapGet("/customers/{IdOrLastName}", async (string param, ISender mediatr) =>
{
    var customer = await mediatr.Send(new GetCustomerQuery(param));
    if (customer == null) return Results.NotFound();
    return Results.Ok(customer);
}).WithSummary("Retrieves a specific customers by Id or Last Name");


//Contractors Endpoint
app.MapGet("/contractors/{IdOrBusinessName}", async (string param, ISender mediatr) =>
{
    var customer = await mediatr.Send(new GetContractorQuery(param));
    if (customer == null) return Results.NotFound();
    return Results.Ok(customer);

}).WithSummary("Retrieves a specific contractors by Id or Business Name");


//Jobs Endpoint
app.MapPost("/jobs", async (CreateJobCommand command, IMediator mediatr) =>
{
    var productId = await mediatr.Send(command);
    if (Guid.Empty == productId) return Results.BadRequest();
    return Results.Created($"/products/{productId}", new { id = productId });
}).WithSummary("Create new job");

app.MapDelete("/jobs/{id:guid}", async (Guid id, ISender mediatr) =>
{
    await mediatr.Send(new DeleteJobCommand(id));
    return Results.NoContent();
}).WithSummary("Delete job");


app.MapGet("/jobs/{JobDescription}", async (string JobDescription, ISender mediatr) =>
{
    var jobs = await mediatr.Send(new GetJobQuery(JobDescription));
    if (jobs == null) return Results.NotFound();
    return Results.Ok(jobs);

}).WithSummary("Retrieves a specific jobs by Job Description");

app.UseHttpsRedirection();
app.Run();
