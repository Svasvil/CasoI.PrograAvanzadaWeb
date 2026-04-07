using CasoI.API.BussinessLogic.Interfaces.Factory;
using CasoI.API.DTOS.CreateTask_DTO;
using CasoI.API.Models.BoardViewModel;

namespace CasoI.API.BussinessLogic.Factory
{
    public class BoardViewModelFactory : IBoardViewModelFactory
    {
        public BoardViewModel Create(CreateTaskDTO dto, int dificultad)
        {
            return new BoardViewModel
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Estado = UserStoryStatus.Backlog,

                UserId = dto.UserId,

                Dificultad = dificultad
            };
        }
    }
}