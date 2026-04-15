using Scalar.AspNetCore;

namespace BloggingPlatformAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddOpenApi();
        builder.Services.AddControllers();

        var app = builder.Build();
        app.Configuration.GetConnectionString("DefaultConnection");
        app.MapControllers();
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }
        app.Run();
    }
}