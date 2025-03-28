using Auth.Application.Queries;
using Auth.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Auth.Infrastructure.Persistence;
using Auth.Infrastructure.Helpers;
using Auth.Infrastructure.Reposetories;

namespace Auth.API
{
    public class Program
    {

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth.API", Version = "v1" }));
            builder.Services.AddControllers();
            //Register AutoMapper
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            //RegisterMediator 
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUserQuery).Assembly));
            //Register App Services
            builder.Services.AddScoped<IAuth, AuthRepository>();
            builder.Services.AddScoped<TokenManipulation>();
            builder.Services.AddScoped<HashPassword>();
            builder.Services.AddScoped<UserIdentity>();
            builder.Services.AddScoped<ClaimCreator>();

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
            app.ApplyMigration();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.ApplyMigration();
            }
            app.MapControllers();

            app.Run();
        }
    }
}
