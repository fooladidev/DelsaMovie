using DelsaMovie.Configurations;
using DelsaMovie.Data;
using DelsaMovie.IRepository;
using DelsaMovie.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace DelsaMovie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnString")));
            // builder.Services.AddSwaggerGen();


            builder.Services .AddAutoMapper(typeof(MapperInitializer));
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}