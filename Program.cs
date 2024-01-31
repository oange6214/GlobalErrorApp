using GlobalErrorApp.Configurations;
using GlobalErrorApp.Data;
using GlobalErrorApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddEntityFrameworkNpgsql()
    .AddDbContext<AppDbContext>(opt => 
        opt.UseNpgsql(builder.Configuration.GetConnectionString("SampleConnection")));

builder.Services.AddScoped<IDriverService, DriverService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapControllers();

app.AddGlobalErrorHandler();

app.Run();