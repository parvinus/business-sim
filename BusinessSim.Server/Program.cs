using AutoMapper;
using BusinessSim.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configure the BusinessSim database provider
builder.Services.AddDbContext<BusinessSimDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("BusinessSim"))
);

// Can also use assembly names:
var configuration = new MapperConfiguration(cfg =>
    cfg.AddMaps(new[] {
        "BusinessSim.Data",
        "BusinessSim.Services",
        "BusinessSim.Server"
    })
);

builder.Services.AddScoped<IMapper>(x => configuration.CreateMapper());

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
