using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Smart_Travel_Planner_API.Data;


var builder = WebApplication.CreateBuilder(args);


// DATABASE
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));


// CONTROLLERS
builder.Services.AddControllers();


// SWAGGER
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();



var app = builder.Build();


// SWAGGER
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.MapControllers();

app.Run();