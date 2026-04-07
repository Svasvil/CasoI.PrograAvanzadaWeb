using CasoI.API.BussinessLogic.Interfaces;
using CasoI.API.Models.BoardViewModel;

namespace CasoI.API.BussinessLogic.Logic.Observers
{
    public class AlertaDificultadObserver : ITaskObserver
    {
        public async Task NotifyAsync(BoardViewModel task)
        {
            if (task.Dificultad > 10)
            {
                Console.WriteLine($"!!! alerta  de  DIFICULTAD: {task.Nombre} !!!");
            }
            await Task.CompletedTask;
        }
    }
}