namespace Models
{
    public class Tarefas
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public Usuario Usuario { get; set; }
        public Categoria Categoria { get; set; }
    }
}
