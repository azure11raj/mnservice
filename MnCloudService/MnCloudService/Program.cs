
global using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MnCloudService.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IRepository, MemoryRepository>();
builder.Services.AddDbContext<MnCloudContext>(options =>

//{ options.UseSqlServer("\"Data Source=LAPTOP-E6N19S8K;Initial Catalog=MnCloud;Integrated Security=True;Trust Server Certificate=True\""); });
{ options.UseSqlServer("\"Data Source=178.212.35.110;Initial Catalog=Nlabs_MNC; connect timeout = 350; Max Pool Size=2500; uid=Mnc;password=7mbhz7?2jNMje4Hfs;\"Trust Server Certificate=True"); });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
