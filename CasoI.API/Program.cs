using CasoI.API.BussinessLogic.Interfaces;
using CasoI.API.BussinessLogic.Interfaces.USERS;
using CasoI.API.BussinessLogic.Logic;
using CasoI.API.BussinessLogic.Logic.Observers;
using CasoI.API.BussinessLogic.Logic.USERS;
using CasoI.API.Data;
using CasoI.API.DataAccess.Interfaces;
using CasoI.API.DataAccess.Interfaces.USERS;
using CasoI.API.DataAccess.Logic;
using CasoI.API.DataAccess.Logic.USERS;
using CasoI.API.BussinessLogic.Interfaces.Factory;
using CasoI.API.BussinessLogic.Factory;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ObjContexto>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBoardViewModelFactory, BoardViewModelFactory>();

builder.Services.AddScoped<I_TaskBL, TaskBL>();
builder.Services.AddScoped<I_TaskDA, CreateTaskDA>();

builder.Services.AddScoped<ITaskObserver, AlertaDificultadObserver>();

builder.Services.AddScoped<I_UsersBL, UsersBL>();
builder.Services.AddScoped<_CreateUserDA, CreateUserDA>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();