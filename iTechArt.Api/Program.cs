using iTechArt.Database.DbContexts;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Repository.Repositories;
using iTechArt.Serivce.Services;
using iTechArt.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IAirportsService, AirportService>();
builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<IGroceryService, GroceryService>();
builder.Services.AddScoped<IPupilService, PupilService>();
builder.Services.AddScoped<IMedStaffService, MedStaffService>();
builder.Services.AddScoped<IPoliceService, PoliceService>();
builder.Services.AddScoped<ITotalStatisticsService, TotalStatisticsService>();
builder.Services.AddScoped<IPupilRepository, PupilRepository>();
builder.Services.AddScoped<IPupilService, PupilService>();

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("iTechArtConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
