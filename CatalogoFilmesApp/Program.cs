using FluentValidation;
using CatalogoFilmesApp.API.Middleware;
using CatalogoFilmesApp.Application.CommandsHandler;
using CatalogoFilmesApp.Domain.Interfaces;
using CatalogoFilmesApp.Infrastructure.Repositories;
using CatalogoFilmesApp.Infrastructure.Service;
using MediatR;
using Microsoft.OpenApi.Models;
using CatalogoFilmesApp.API.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
builder.Services.AddSingleton<IFilmesRepository, FilmesRepository>();

builder.Services.AddValidatorsFromAssembly(typeof(CreateFilmeValidator).Assembly);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddControllers(options => 
    options.Filters.Add<ValidationFilter>()
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Catalogo de Filmes", Version = "v1", });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalogo de Filmes API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
