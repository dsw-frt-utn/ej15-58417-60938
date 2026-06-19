
using DSW2025EJ15.Data.Sources;
using DSW2025EJ15.Domain.Interfaces;
using DSW2025EJ15.Domain.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using DSW2025EJ15.Domain.Exceptions;

namespace DSW2025EJ15.Api;
public class Program
{
    public static void Main(string[] args)
    {
        
        
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<IPersistence, PersistenceInMemory>();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }   
        // Configure the HTTP request pipeline.
        //Middlewares
        
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseAuthorization();
        app.MapControllers();
        
        app.Use(async (context,next) =>
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {

                if (e.GetType() != typeof(ValidationException))
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync("problem");
                }
                else
                {
                    await next(context);
                }


            }
            

        });
        
        app.Use(async (context, next) =>
        {
            try
            {
                await next.Invoke(context); //sigue avanzando hasta llegar al controller
            }
            catch (ValidationException e)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest; //le da el numero de error al usuario
                await context.Response.WriteAsync(e.Message); //le da mensaje al usuario
            }
            
        });
        
        
        
        

        app.Run();
    }
}
