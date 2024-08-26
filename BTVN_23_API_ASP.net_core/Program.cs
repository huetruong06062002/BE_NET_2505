using BTVN_23_API_ASP.net_core.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using BTVN_23_API_ASP.net_core.DB;
using BTVN_23_API_ASP.net_core.Repositories.Implement;

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

            // Đăng ký dịch vụ CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin() // Thay thế bằng URL của frontend của bạn
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                     
                    });
            });

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

            app.UseRouting(); // Phải đặt trước UseCors và UseAuthorization

            app.UseCors("AllowSpecificOrigins"); // Đặt trước UseAuthorization

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
