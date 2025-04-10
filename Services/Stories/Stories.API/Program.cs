using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Stories.Application.Features.Stories;
using Stories.Domain.Repositories;
using Stories.Infrastructure.Data;
using Stories.Infrastructure.Persistence;
using Stories.Infrastructure.Services;
using System.Net.Mime;
using System.Text.Json.Serialization;
using Stories.API.Transformers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Post.API", Version = "v1" }));
// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<MongoDbSettings>(
            builder.Configuration.GetSection(nameof(MongoDbSettings)));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateStoryCommand).Assembly));
builder.Services.AddAutoMapper(typeof(Program).Assembly);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddTransient<IStoriesContext, StoriesContext>();
builder.Services.AddScoped<IStoriesRepository, StoriesService>();
builder.Services.AddTransient<IStoriesRepository, StoriesService>();
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
