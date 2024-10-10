using DayMapper_BE.DatabaseConfig;
using DayMapper_BE.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DayMapperAppContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlServerConnection")));

builder.Services.AddScoped<IAddressService, AddressService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DayMapperAppContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Addition of a custom middleware
//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
