namespace Dto
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public enum Rank
        {
            Baixa,
            Media,
            Alta
        }
    }
}
