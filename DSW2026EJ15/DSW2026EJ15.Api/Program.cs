using DSW2026EJ15.Data.Sources;
using DSW2026EJ15.Domain.Interfaces;
using DSW2026EJ15.Api.Middleware;
using Microsoft.EntityFrameworkCore;

namespace DSW2026EJ15.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddScoped<IPersistence, PersistenceEf>();

        builder.Services.AddHealthChecks();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseAuthorization();

        app.MapControllers();

        app.MapGet("/health-check", () => Results.Ok("Healthy"));

        app.Run();
    }
}