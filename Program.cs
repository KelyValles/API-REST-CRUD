using API.Models;
using API.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<Settings>
    (builder.Configuration.GetSection(nameof(Settings)));

builder.Services.AddScoped<ISettings>
    (d => d.GetRequiredService<IOptions<Settings>>().Value);


builder.Services.AddScoped<ICarCollection, CarCollection>();
builder.Services.AddScoped<ICategoriesCollection, CategoriesCollection>();

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
