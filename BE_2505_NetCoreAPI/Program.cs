using System.Text;
using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DALImpl;
using BE_2505.DataAccess.Netcore.DBContext;
using BE_2505.DataAccess.Netcore.UnitOfWork;
using BE_2505_NetCoreAPI;
using BE_2505_NetCoreAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
//DEPENDECY INJECTION
builder.Services.AddControllers();

builder.Services.AddDbContext<BE_25_05_DbContext>(options =>
			   options.UseSqlServer(configuration.GetConnectionString("ConnStr")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = false,
		ValidateAudience = false,
		ValidateLifetime = false,
		ValidateIssuerSigningKey = false,
		ValidIssuer = builder.Configuration["Jwt:ValidAudience"],
		ValidAudience = builder.Configuration["Jwt:ValidIssuer"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
	};
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductServiceImpl>();
builder.Services.AddScoped<IAccountDAO, AccountDAOImpl>();
builder.Services.AddScoped<IStudentDAL, StudentManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUnitOfWork_BE_2505, UnitOfWork_BE_2505>();
builder.Services.AddScoped<IProductGenericRepository, ProductGenericRepository>();

var app = builder.Build();

//MiDDLEWARE
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.Run(async context =>
//{
//	await context.Response.WriteAsync("Hello world!");
//});

//app.UseMiddleware<MyCustomMiddleWare>();

app.UseAuthentication();
app.UseAuthorization();


app.UseCustomMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
