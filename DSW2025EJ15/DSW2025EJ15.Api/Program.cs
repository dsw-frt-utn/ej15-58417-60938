using DSW2025EJ15.Data.Sources;
using DSW2025EJ15.Domain.Interfaces;
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
        app.UseSwagger();

        app.UseSwaggerUI();
        // Configure the HTTP request pipeline.

        if (app.Environment.IsDevelopment())
        {
            app.UseAuthorization();


            app.MapControllers();
        }

        app.Run();
    }
}
