using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SocialMechatronicsNetwork.Buisness.Services;
using SocialMechatronicsNetwork.Core.Abstractions;
using SocialMechatronicsNetwork.CQS.Commands;
using SocialMechatronicsNetwork.CQS.Handlers.CommandHandlers;
using SocialMechatronicsNetwork.DataBase;
using System.Reflection;

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

            //dependency Injection Handlers  
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(AddChatCommand)));


            //dependency Injection Services 
            builder.Services.AddScoped<IChatService, ChatService>();

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
