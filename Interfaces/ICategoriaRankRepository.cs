using Dto;
using Models;

namespace Interfaces
{
    public interface ICategoriaRankRepository
    {
        ICollection<CategoriaRank> GetCategorysRank();
        CategoriaRank GetCategoryRankById(int categoryRankId);
        CategoriaRank GetCategoryRankByDescription(string description);
        bool CategoryRankExists(int catRankId);
        bool CreateCategoryRank(CategoriaRank categoriaRank);
        bool UpdateCategoryRank(CategoriaRank categoriaRank);
        bool DeleteCategoryRank(CategoriaRank categoriaRank);    
        bool Save();
    }
}
