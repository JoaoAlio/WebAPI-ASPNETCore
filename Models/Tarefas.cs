namespace Models
{
    public class Tarefas
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int CategoriaId { get; set; } 
        public Categoria Categoria { get; set; } 
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } 
    }
}
