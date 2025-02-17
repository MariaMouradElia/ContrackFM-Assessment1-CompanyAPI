using Microsoft.EntityFrameworkCore;
using CompanyAPI.Data;
var builder = WebApplication.CreateBuilder(args);

// Adding MySQL Database Connection
builder.Services.AddDbContext<CompanyDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 31))));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Company API V1");
    c.RoutePrefix = string.Empty; // To open Swagger by default
});


app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();