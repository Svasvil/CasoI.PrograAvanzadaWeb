using CasoI.API.Models.BoardViewModel;

namespace CasoI.API.BussinessLogic.Interfaces
{
    public interface ITaskObserver
    {
        Task NotifyAsync(BoardViewModel task);
    }
}