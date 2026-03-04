namespace CasoI.API.Models.BoardViewModel
{
    public enum UserStoryStatus { Backlog, ToDo, InProgress, Done }

    public class BoardViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public UserStoryStatus Estado { get; set; } = UserStoryStatus.Backlog;
    }
}