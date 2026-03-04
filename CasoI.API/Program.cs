using CasoI.API.BussinessLogic.Interfaces;
using CasoI.API.BussinessLogic.Logic;
using CasoI.API.Data;
using CasoI.API.DataAccess.Interfaces;
using CasoI.API.DataAccess.Logic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ObjContexto>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<I_TaskBL, TaskBL>();
builder.Services.AddScoped<I_TaskDA, CreateTaskDA>();

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