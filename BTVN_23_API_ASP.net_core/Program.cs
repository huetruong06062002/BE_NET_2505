using BTVN_23_API_ASP.net_core.Repositories.Interface;
using BTVN_23_API_ASP.net_core.Repositories;
using BTVN_23_API_ASP.net_core.Models;
using Microsoft.EntityFrameworkCore;

namespace BTVN_23_API_ASP.net_core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Đăng ký ApplicationDbContext với Dependency Injection
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Đăng ký UnitOfWork sau khi ApplicationDbContext đã được đăng ký
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
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
