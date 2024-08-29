using Microsoft.EntityFrameworkCore;
using WebAPI.Models;


var MyAllowSpecificOrigins = "http://localhost:5173";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddDbContext<DonationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("devConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                     policy =>
                      {
                         policy.WithOrigins("http://localhost:5173"
                                              ).AllowAnyMethod()
                                              .AllowAnyHeader();
                      });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
