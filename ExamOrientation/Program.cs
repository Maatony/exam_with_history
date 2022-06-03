using Microsoft.EntityFrameworkCore;
using ExamOrientation.Databases;
using ExamOrientation.Interfaces;
using ExamOrientation.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddScoped<IXXXService, XXXService>();

ConfigureDb(builder.Services);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.MapControllers();

app.Run();

static void ConfigureDb(IServiceCollection services)
{
    var config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
    var connectionString = config.GetConnectionString("Default");
    services.AddDbContext<OEDb>(b => b.UseSqlServer(connectionString));
}
