using InMemoryDbDemo.Data;
using Microsoft.EntityFrameworkCore;
using InMemoryDbDemo.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); // Added this temporary to avoid Infinite Looping of Navigational Properties of Entities
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Config to Use SQL Server
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
//    builder.Configuration.GetConnectionString("DefaultConnection")
//    )); 
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(databaseName: "CitiesDb")); // Using InMemory Db instead of Actual DB
builder.Services.AddScoped<ICityRepo, CityRepo>();

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

var scope = app.Services.CreateScope();
var context =  scope.ServiceProvider.GetService<ApplicationDbContext>();
DataInitializer.SeedData(context);

app.Run();
