
using Microsoft.EntityFrameworkCore;
using SocialMedia.Data;
using SocialMedia.Repos;
using SocialMedia.Repositories;
using SocialMedia.Services;
using System;
using System.Text.Json.Serialization;

namespace SocialMedia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<SocialMediaDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            
            builder.Services.AddScoped<IPostRepo, PostRepo>();
            builder.Services.AddScoped<IPostService, PostService>();

            builder.Services.AddControllers(options =>
            options.Filters.Add<ExecutionTimeFilter>())
            .AddJsonOptions(options =>
            {
                
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            builder.Services.AddScoped<ExecutionTimeFilter>();

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
