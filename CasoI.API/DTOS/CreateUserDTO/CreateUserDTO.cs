namespace CasoI.API.DTOS.CreateUserDTO
{
    public record CreateUserDTO
    (

         int Id,
         string Nombre,
         string Apellidos,
         string email,
         int PokeApiAvatar

    );
}
