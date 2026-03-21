using Microsoft.SqlServer.Management.Smo;
using System.ComponentModel.DataAnnotations;

namespace CasoI.API.Models
{
    public class UsersModel
    {
        [Required] public int Id { get; set; }
        [Required] [MaxLength(25)] public string Nombre { get; set; }
        [Required][MaxLength(50)] public string Apellidos { get; set; }
        [Required][MaxLength(100)] public string email { get; set; }
        public int PokeApiAvatar  { get; set; } = 1;

    }
}
