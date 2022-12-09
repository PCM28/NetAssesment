using Microsoft.EntityFrameworkCore;
using NetMySql;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using NetMySql.Data;
using NetMySql.Data.Repositories;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://example.com",
                                              "http://www.contoso.com").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mysqlconfig = new MySQLConfiguration(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddSingleton(mysqlconfig);
builder.Services.AddSingleton(new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IClaimRepository, ClaimRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
