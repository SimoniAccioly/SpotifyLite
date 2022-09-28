using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SpofityLite.Application;
using SpotifyLite.Repository;

namespace SpotifyLite.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services
                   .RegisterApplication()
                   .AddHttpClient()
                   .RegisterRepository(builder.Configuration.GetConnectionString("SpotifyLite"));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Carteira do Investidor", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.


            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Carteira do Investidor v1"));

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}