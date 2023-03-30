//using EmployeeDirectoryApp.Models;
using AutoMapper;
using EmployeeDirectoryApp;
using EmployeeDirectoryApp.DTO;
using EmployeeDirectoryApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ServiceLibrary.Context;

internal class Program
{
    private static void Main(string[] args)
    {
        Employee emp = new Employee();

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IApplicationBuilder, ApplicationBuilder>();
        builder.Services.AddDbContext<EmployeeDirectoryContext>(options =>
        {

            options.UseSqlServer("name=ConnectionStrings:DefaultConnection"); options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
        
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MapperConfig());
        });
        IMapper mapper1 = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper1);

        var app = builder.Build();

        app.UseCors(builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });

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