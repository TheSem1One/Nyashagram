using FileManager.Application.Commands;
using FileManager.Domain.Reposetories;
using FileManager.Infrastructure.Helpers;
using FileManager.Infrastructure.Persistance;
using FileManager.Infrastructure.Reposetories;
using Microsoft.EntityFrameworkCore;
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
builder.Services.AddDbContext<ImageContext>(opts =>
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
builder.Services.AddTransient<ImageContext>();
builder.Services.AddTransient<IFileManagerReposetory, FileManagerReposetory>();
builder.Services.AddScoped<FileHelper>();
builder.Services.AddTransient<IFileManagerReposetory, FileManagerReposetory>();
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
