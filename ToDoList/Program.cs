using ToDoList.Application;
using ToDoList.Domain.Interfaces;
using ToDoList.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IAssignmentRepository, AssigmentRepository>();

builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(ApplicationMarker).Assembly));

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
        Url = "https://localhost:5000/"
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

app.Run();
