using BloggingPlatformAPI.classes;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace BloggingPlatformAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddOpenApi();
        builder.Services.AddControllers();

        string? connectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<BlogDbContext>(options => options.UseNpgsql(connectionStr).UseSnakeCaseNamingConvention());

        var app = builder.Build();
        app.MapControllers();
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }
        app.Run();
    }
}