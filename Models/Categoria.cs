namespace Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public int CategoriaRankId { get; set; }
        public CategoriaRank CatRank { get; set; }

        public enum Rank
        {
            Baixa,
            Media,
            Alta
        }

    }
}
