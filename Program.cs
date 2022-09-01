using Microsoft.EntityFrameworkCore;
using src.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Using in memory database
builder.Services.AddDbContext<Context>(options => options.UseInMemoryDatabase("dbContracts"));
// Remove comment below to use Microsoft SQL Server Express
//builder.Services.AddDbContext<Context>(options => options.UseSqlServer());

builder.Services.AddScoped<Context, Context>();

builder.Services.AddControllers();
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
