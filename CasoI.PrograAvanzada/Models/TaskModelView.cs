namespace CasoI.PrograAvanzada.Models
{
    public enum UserStoryStatus { Backlog, ToDo, InProgress, Done }

    public class TaskModelView
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public UserStoryStatus Estado { get; set; } = UserStoryStatus.Backlog;
        public string AsignadoA { get; set; }

    }
}
