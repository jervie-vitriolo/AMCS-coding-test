
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

app.MapGet("/customers/{lastname:alpha}", async (string lastname, ISender mediatr) =>
{
    var customer = await mediatr.Send(new GetCustomerQuery(lastname));
    if (customer == null) return Results.NotFound();
    return Results.Ok(customer);
});


app.UseHttpsRedirection();
app.Run();
