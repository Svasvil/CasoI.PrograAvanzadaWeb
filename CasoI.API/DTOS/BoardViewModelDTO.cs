using CasoI.API.Models.BoardViewModel;
using CasoI.API.Models.BoardViewModel;

namespace CasoI.API.DTOS
{
    public class BoardViewModelDTO
    {
        public record CreateTaskDTO(
int id,
              string Nombre,
            string Descripcion,
              UserStoryStatus Estado,
            string AsignadoA
                 

          );
    }
}
