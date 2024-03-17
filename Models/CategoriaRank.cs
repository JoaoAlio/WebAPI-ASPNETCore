namespace Models
{
    public class CategoriaRank
    {
        public int CategoriaRankId { get; set; }
        public string CategoriaRankDescricao { get; set; }
        public List<Categoria> Categoria { get; set; }
    }
}
