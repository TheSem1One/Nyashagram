using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Post.Application.Commands;
using Post.Application.Handles;
using Post.Application.Queries;
using Post.Application.Responses;
using Post.Domain.Reposetories;
using Post.Infrastructure.Data;
using Post.Infrastructure.Presistence;
using Post.Infrastructure.Repositories;


namespace Post.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Post.API", Version = "v1" }));

            builder.Services.AddControllers();
            builder.Services.Configure<MongoDbSettings>(
                builder.Configuration.GetSection(nameof(MongoDbSettings)));
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            //RegisterMediator 
            builder.Services.AddTransient<IPostContext, PostContext>();
            builder.Services.AddTransient<IPostRepository, PostRepositories>();
           
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


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
