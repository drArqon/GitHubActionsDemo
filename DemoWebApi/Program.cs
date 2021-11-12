using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DemoWebApi.Test")]

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
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



var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/forecast", () =>
{
    var forecast = Enumerable.Range(0, 5).Select(i =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(i),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)])
        )
    .ToArray();

    return forecast;
}).WithName("GetWeatherForecast");



app.Run();
