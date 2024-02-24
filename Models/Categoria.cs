namespace Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public List<Tarefas> Tarefas { get; set; }
        public enum Rank
        {
            Baixa,
            Media,
            Alta
        }

    }
}
