var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

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
});



app.Run();
