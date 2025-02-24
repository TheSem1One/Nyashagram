
using System.Reflection;
using Auth.Domain.Entities;
using Auth.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Auth.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Auth.Infrastructure.Configuration;
using Auth.Infrastructure.Helpers;

namespace Auth.API
{
    public class Program
    {
      
        public static void Main(string[] args)
        {
          
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerGen(c=>c.SwaggerDoc("v1", new OpenApiInfo{Title ="Auth.API", Version = "v1"}));
            builder.Services.AddControllers();
            //Register AutoMapper
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            //RegisterMediator 
            builder.Services.AddMediatR(cfg=> cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            //Register App Services
           
            builder.Services.AddScoped<UserProps>();
            builder.Services.AddScoped<TokenManipulation>();
            builder.Services.AddScoped<HashPassword>();

            builder.Services.AddDbContext<UserContext>(opts =>
                opts
                    .UseNpgsql(builder.Configuration.GetConnectionString("ApiDatabase"))
            );
            builder.Services.AddCors(o => o.AddPolicy("AllowAny", corsPolicyBuilder =>
            {
                corsPolicyBuilder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            }));
           
            var app = builder.Build();

         
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapControllers();

            app.Run();
        }
    }
}
