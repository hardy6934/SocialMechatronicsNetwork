
using Microsoft.AspNetCore.Cors.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using System.Security.Principal;
using SocialMechatronicsNetwork.Entities;
using Microsoft.EntityFrameworkCore;

namespace SocialMechatronicsNetwork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("Default");
            //dependency Injection DataBase
            builder.Services.AddDbContext<SocialMechatronicsNetworkContext>(optionsBuilder => optionsBuilder.UseNpgsql(connectionString));

            //dependency Injection AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Dependency Injection Services   
            //builder.Services.AddScoped<IJWTUtil, JWTUtilSha256>();

            //Dependency Injection GenericRepository  
            //builder.Services.AddScoped<IRepository<BTSensorsSerialsPermission>, Repository<BTSensorsSerialsPermission>>();



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
    }
}
