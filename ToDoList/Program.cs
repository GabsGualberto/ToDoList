using Microsoft.EntityFrameworkCore;
using ToDoList.Application;
using ToDoList.Domain.Interfaces;
using ToDoList.Infrastructure.Configuration;
using ToDoList.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(ApplicationMarker).Assembly));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<IAssignmentRepository, AssigmentRepository>();

builder.Services.AddSwaggerGen(configuration =>
{
    configuration.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "ToDoList API",
        Version = "v1"
    });

    configuration.AddServer(new Microsoft.OpenApi.Models.OpenApiServer()
    {
        Description = "Localhost",
        Url = "http://localhost:5000/"
    });
});

builder.Services.AddCors(builder =>
{
    builder.AddPolicy("ApiCors", policy =>
    {
        policy
        .WithOrigins("*")
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetPreflightMaxAge(TimeSpan.MaxValue)
        .Build();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("ApiCors");

app.Run();
