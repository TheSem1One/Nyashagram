﻿using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Post.API.Transformers;
using Post.Application.Features.Post;
using Post.Domain.Repositories;
using Post.Infrastructure.Data;
using Post.Infrastructure.Persistence;
using Post.Infrastructure.Services;
using System.Net.Mime;
using System.Text.Json.Serialization;
using Post.API.Middelwares;
using Serilog;


namespace Post.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();
            builder.Host.UseSerilog(logger);
            builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Post.API", Version = "v1" }));

            builder.Services.AddControllers();
            builder.Services.Configure<MongoDbSettings>(
                builder.Configuration.GetSection(nameof(MongoDbSettings)));
            // У Startup.cs в ConfigureServices


            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreatePostCommand).Assembly));
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            //RegisterMediator 
            builder.Services.AddTransient<IPostContext, PostContext>();
            builder.Services.AddScoped<IPostRepository, PostService>();
            builder.Services.AddTransient<IPostRepository, PostService>();

            builder.Services
                .AddControllers(options =>
                {
                    options.Filters.Add(new ProducesAttribute(MediaTypeNames.Application.Json));
                    options.Conventions.Add(new RouteTokenTransformerConvention(new ToKebabParameterTransformer()));
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            builder.Services.AddCors(o => o.AddPolicy("AllowAny", corsPolicyBuilder =>
            {
                corsPolicyBuilder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            })); 

            var app = builder.Build();
            app.UseCors("AllowAny");
            app.UseMiddleware<ExceptionHandlingMiddleware>();
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
