using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Post.Infrastructure.Presistence;

namespace Post.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Post.API", Version = "v1" }));

            builder.Services.AddControllers();
            builder.Services.AddDbContext<PostContext>(opts =>
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
