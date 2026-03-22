using CasoI.PrograAvanzada.Services;
using CasoI.PrograAvanzada.Services.USERS;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var apiBase = builder.Configuration.GetValue<string>("ApiBaseUrl") ?? "http://localhost:5001/";
builder.Services.AddHttpClient<I_ApiCall, ApiCall>(client =>
{
    client.BaseAddress = new Uri(apiBase);
});

builder.Services.AddHttpClient<I_UsersApiCall, UserApiCall>(client =>
{
    client.BaseAddress = new Uri(apiBase);
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();