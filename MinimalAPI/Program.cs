var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var valoresDificultad = new[] { 2, 3, 5, 8, 13 };

app.MapGet("/api/estimate", () =>
{
    var random = new Random();
    var value = valoresDificultad[random.Next(valoresDificultad.Length)];
    return Results.Ok(value);
});

app.Run();