using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ToDoList.Data;
using ToDoList.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<TarefaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddControllers();
builder.Services.AddScoped<TarefaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}


app.MapControllers();
app.UseHttpsRedirection();


app.Run();
