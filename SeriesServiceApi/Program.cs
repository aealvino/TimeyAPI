using Microsoft.EntityFrameworkCore;
using DAL.EF;
using DAL.DataSource;
using Abstraction.Interfaces.DataSourse;
using Abstraction.Interfaces.Services;
using SeriesServiceApi.Extensions;
using SeriesServiceApi.Services;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddDataSourceServices();
builder.Services.AddBllServices();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Logging.ClearProviders();
builder.Host.UseNLog();
builder.Services.AddLogger();

var app = builder.Build();

app.AddExceptionHandler();
app.InitMapping();
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