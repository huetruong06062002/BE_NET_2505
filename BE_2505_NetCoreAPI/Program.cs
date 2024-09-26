using BE_2505_NetCoreAPI;
using BE_2505_NetCoreAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//DEPENDECY INJECTION
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductServiceImpl>();
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

app.UseCustomMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
