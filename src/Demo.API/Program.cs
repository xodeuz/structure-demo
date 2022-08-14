using Demo.API.SeedWork;
using Demo.Domain.Configuration;
using Demo.Infrastructure.Persistence.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDomainLayer();
builder.Services.AddPersistenceLayer();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
await app.SeedForDemo();
app.Run();
