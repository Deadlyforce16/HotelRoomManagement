using HotelRoomManagement.Data;
using Microsoft.EntityFrameworkCore;
using HotelRoomManagement.Data.Interfaces;
using HotelRoomManagement.Data.Repositories;
using HotelRoomManagement.Service.Interfaces;
using HotelRoomManagement.Service.Services;
using AutoMapper;
using HotelRoomManagement.Service.Profiles;

namespace HotelRoomManagement.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<HotelRoomManagementDataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IGuestRepository, GuestRepository>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();

            builder.Services.AddScoped<IGuestService, GuestService>();
            builder.Services.AddScoped<IRoomService, RoomService>();

            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly, typeof(Program).Assembly);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
