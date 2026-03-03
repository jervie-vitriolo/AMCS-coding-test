
using Persistence;
using MediatR;
using System.Reflection;
using Application.Features.Customer.Queries;
using Application.Features.Job.Command.Create;
using Application.Features.Job.Command.Delete;
using Application.Features.Job.Command.Update;

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
    if (customer.Count() == 0) return Results.NotFound();
    return Results.Ok(customer);
}).WithSummary("Retrieves a specific customers by Id or Last Name");


//Contractors Endpoint
app.MapGet("/contractors/{IdOrBusinessName}", async (string param, ISender mediatr) =>
{
    var customer = await mediatr.Send(new GetContractorQuery(param));
    if (customer.Count() == 0) return Results.NotFound();
    return Results.Ok(customer);

}).WithSummary("Retrieves a specific contractors by Id or Business Name");


//Jobs Endpoint
app.MapPost("/job", async (CreateJobCommand command, IMediator mediatr) =>
{
    var jobId = await mediatr.Send(command);
    if (Guid.Empty == jobId) return Results.BadRequest();
    return Results.Created($"/job/{jobId}", new { id = jobId });
}).WithSummary("Create new job");

app.MapGet("/jobs/{JobDescription}", async (string JobDescription, ISender mediatr) =>
{
    var jobs = await mediatr.Send(new GetJobQuery(JobDescription));
    if (jobs.Count() == 0) return Results.NotFound();
    return Results.Ok(jobs);

}).WithSummary("Retrieves a specific jobs by Job Description");


app.MapPut("/job", async (UpdateJobCommand command, IMediator mediatr) =>
{
    var result = await mediatr.Send(command);
    if (!result) return Results.BadRequest();
    return Results.Created($"/jobs/{result}", new { id = result });
}).WithSummary("Update job");


app.MapPut("/job/joboffer", async (AcceptJobCommand command, IMediator mediatr) =>
{
    var result = await mediatr.Send(command);
    if (!result) return Results.BadRequest();
    return Results.Created($"/jobs/{result}", new { id = result });
}).WithSummary("Accept job");


app.MapDelete("/jobs/{id:guid}", async (Guid id, ISender mediatr) =>
{
    await mediatr.Send(new DeleteJobCommand(id));
    return Results.NoContent();
}).WithSummary("Delete job");


app.UseHttpsRedirection();
app.Run();
