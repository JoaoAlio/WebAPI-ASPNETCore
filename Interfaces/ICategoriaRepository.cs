using Models;

namespace Interfaces
{
    public interface ICategoriaRepository
    {
        ICollection<Categoria> GetCategorys();
        Categoria GetCategory(int id);
        Categoria GetCategoryByTitle(string title);
        bool CategoryExists(int id);
    }
}
