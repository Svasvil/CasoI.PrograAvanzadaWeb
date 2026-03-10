using CasoI.PrograAvanzada.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var apiBase = builder.Configuration.GetValue<string>("ApiBaseUrl") ?? "https://localhost:5001/";

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