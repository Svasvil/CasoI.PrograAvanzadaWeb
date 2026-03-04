using CasoI.PrograAvanzada.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// UNIFICADO: Configura el JSON aquí mismo para que coincida con la API
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Asegúrate de que este puerto sea el que ves en el navegador al abrir la API
var apiBase = builder.Configuration.GetValue<string>("ApiBaseUrl")?? "https://localhost:5001/";
builder.Services.AddHttpClient<I_ApiCall, ApiCall>(client =>
{
    client.BaseAddress = new Uri(apiBase);
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();