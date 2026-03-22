using CasoI.API.Models.BoardViewModel;

namespace CasoI.API.DTOS.CreateTask_DTO
{
    public record CreateTaskDTO(
        int id,
        string Nombre,
        string Descripcion,
        UserStoryStatus Estado,
        int UserId,
        string? NombreAsignado,  
        string? AvatarAsignado,
        int Dificultad
    );
}