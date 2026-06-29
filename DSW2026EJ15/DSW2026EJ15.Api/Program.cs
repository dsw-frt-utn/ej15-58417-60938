using DSW2026EJ15.Domain.Interfaces;
using DSW2026EJ15.Domain.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using DSW2026EJ15.Api.Middleware;
using DSW2025EJ15.Data.Sources.Persistences;
using Microsoft.EntityFrameworkCore;
using DSW2025EJ15.Data.Entities;

namespace DSW2026EJ15.Api;
public class Program
{
    public static void Main(string[] args)
    {


        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<IPersistence, PersistenceInMemory>();

        //DB
        //trae de la configuracion del builder las intrucciones en DefaultConnection 
        var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection"); 
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionstring));


        builder.Services.AddHealthChecks();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

        
        
        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();
        if (app.Environment.IsDevelopment())
        {
            app.UseAuthorization();
            app.MapControllers();
        }   
        // Configure the HTTP request pipeline.
        //Middlewares
        
        
        
        
        app.MapHealthChecks("/healt-check"); //le da una respuesta de funcionaminento, necesario para otra app
        //si le no diese una respuesta, significa que el servidor no esta funcionando
        //es para no tener que estar pasando por cada endpoint para ver si esta funcionando
        
        app.UseMiddleware<ExceptionMiddleware>();  //registra middleware en la app

        app.Run();
    }
}
