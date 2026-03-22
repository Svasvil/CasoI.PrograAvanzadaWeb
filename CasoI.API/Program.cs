using CasoI.API.BussinessLogic.Interfaces;
using CasoI.API.BussinessLogic.Interfaces.USERS;
using CasoI.API.BussinessLogic.Logic;
using CasoI.API.BussinessLogic.Logic.USERS;
using CasoI.API.Data;
using CasoI.API.DataAccess.Interfaces;
using CasoI.API.DataAccess.Interfaces.USERS;
using CasoI.API.DataAccess.Logic;
using CasoI.API.DataAccess.Logic.USERS;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de Controladores y JSON
builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Base de Datos
builder.Services.AddDbContext<ObjContexto>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Registro de Dependencias
// --- SERVICIOS DE TAREAS ---
builder.Services.AddScoped<I_TaskBL, TaskBL>();
builder.Services.AddScoped<I_TaskDA, CreateTaskDA>();

// --- SERVICIOS DE USUARIOS ---
builder.Services.AddScoped<I_UsersBL, UsersBL>();
builder.Services.AddScoped<_CreateUserDA, CreateUserDA>();

var app = builder.Build();

// 4. Pipeline de HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();