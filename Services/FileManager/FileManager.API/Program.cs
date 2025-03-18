using FileManager.Domain.Reposetories;
using FileManager.Infrastructure.Helpers;
using FileManager.Infrastructure.Persistance;
using FileManager.Infrastructure.Reposetories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
builder.Services.AddScoped<FileHelper>();
builder.Services.AddTransient<IFileManagerReposetory, FileManagerReposetory>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "ImageFolder")),
    RequestPath = "/Resources"
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
