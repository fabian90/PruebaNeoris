using Microsoft.EntityFrameworkCore;
using TransaccionesBancarias.Infrastructure.Data.Context;
using FluentValidation.AspNetCore;
using TransaccionesBancarias.Middleware;

var allowSpecificOrigins = "AllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
string[] lOrigins = builder.Configuration.GetValue<string>("Origins").Split(",");
//Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins(lOrigins);
                          policy.AllowAnyMethod();
                          policy.AllowAnyHeader();
                      });
});
//Servicios
IoC.AddDependency(builder.Services);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
    conf.AutomaticValidationEnabled = false;
});


string connString = builder.Configuration.GetConnectionString("ConexionApp");
builder.Services.AddDbContext<bancoNeorisContext>(options =>
{
    options.UseSqlServer(connString);
    options.UseSqlServer(connString, b => b.MigrationsAssembly("PruebaNeoris"));
});
//Configure Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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
