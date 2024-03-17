using Dto;
using Models;

namespace Interfaces
{
    public interface ICategoriaRepository
    {
        ICollection<Categoria> GetCategorys();
        Categoria GetCategory(int id);
        Categoria GetCategoryByTitle(string title);
        bool CategoryExists(int id);
        bool CreateCategory(Categoria category, int catRankId);
        bool UpdateCategory(Categoria category, int catRankId);
        bool DeleteCategory(Categoria category);
        bool Save();
    }
}
