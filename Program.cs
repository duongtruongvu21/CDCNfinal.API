using CDCNfinal.API.Data;
using CDCNfinal.API.Mapping;
using CDCNfinal.API.Services._AuthServices;
using CDCNfinal.API.Services.ProductServices.cs;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var connectionString = builder.Configuration.GetConnectionString("Default"); // Default là tên cấu hình ở appsetting.json

// Add services to the container.
builder.Services.AddControllers();
// builder.WebHost.ConfigureKestrel(options => options.Listen(System.Net.IPAddress.Parse("192.168.1.24"), 7149));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myCORS",
                      policy =>
                      {
                          policy.WithOrigins("*")
                          .AllowAnyMethod().AllowAnyHeader();
                      });
});

var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
// Replace 'YourDbContext' with the name of your own DbContext derived class.
services.AddDbContext<DataContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

services.AddScoped<IAuthService, AuthService>();
services.AddScoped<IProductService, ProductService>();
services.AddAutoMapper(typeof(AutoMappingConfiguration).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("_myCORS");

app.MapControllers();

app.Run();
