using ConfigLibrary.BL.Interfaces;
using ConfigLibrary.BL.Services;
using ConfigLibrary.DAL.Interfaces;
using ConfigLibrary.DAL.Repositories;
using ConfigLibrary.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ConfigDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConfigDb"))); // iþte bunu dinamik olarak deðiþtireceksin. metotla bir connstr gelecek


builder.Services.AddScoped<IConfigRepository, ConfigRepository>();
builder.Services.AddScoped<IConfigService,ConfigService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
