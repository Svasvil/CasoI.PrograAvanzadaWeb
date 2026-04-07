using CasoI.API.DTOS.CreateTask_DTO;
using CasoI.API.Models.BoardViewModel;

namespace CasoI.API.BussinessLogic.Interfaces.Factory
{
    public interface IBoardViewModelFactory
    {
        BoardViewModel Create(CreateTaskDTO dto, int dificultad);

    }
}
