using Microsoft.EntityFrameworkCore;
using UpdatePolicyService.Middlewares;
using UpdatePolicyService.Models.Database;
using UpdatePolicyService.Repositories;
using UpdatePolicyService.Repositories.Interfaces;
using UpdatePolicyService.Services;
using UpdatePolicyService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Controller
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Register Service
builder.Services.AddScoped<IPolicyService, PolicyService>();

// Register Repository
builder.Services.AddScoped<IPolicyRepository, PolicyRepository>();

// Database
builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 2))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseMiddleware<ExceptionHandling>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();