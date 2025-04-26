using System.Net.Mime;
using System.Text.Json.Serialization;
using FileManager.API.Transformer;
using FileManager.Application.Features.FileManager;
using FileManager.Domain.Repositories;
using FileManager.Infrastructure.Helpers;
using FileManager.Infrastructure.Persistence;
using FileManager.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "FileManager.API", Version = "v1" }));
//Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);
//RegisterMediator 
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateFileCommand).Assembly));
//register DB
builder.Services.AddDbContext<FileManagerContext>(opts =>
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
builder.Services.AddTransient<FileManagerContext>();
builder.Services.AddTransient<IFileManagerRepository, FileManagerService>();
builder.Services.AddScoped<FileHelper>();
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
var app = builder.Build();
app.UseCors("AllowAny");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(
    new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(builder.Environment.ContentRootPath,
                "Uploads")),
        RequestPath = "/Resources"
    });
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
