using AutoMapper;
using Data;
using Dto;
using Interfaces;
using Models;

namespace Repository
{
    public class CategoriaRankRepository : ICategoriaRankRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CategoriaRankRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public bool CategoryRankExists(int id)
        {
            return _context.CategoriaRank.Any(cr => cr.CategoriaRankId == id);
        }

        public bool CreateCategoryRank(CategoriaRank categoryRank)
        {        
            var categoriaRank = new CategoriaRank
            {
                CategoriaRankDescricao = categoryRank.CategoriaRankDescricao
            };

            _context.Add(categoriaRank);

            return Save();
        }

        public bool UpdateCategoryRank(CategoriaRank categoriaRank)
        {
            _context.Update(categoriaRank);
            return Save();
        }

        public bool DeleteCategoryRank(CategoriaRank categoriaRank) 
        {
            _context.Remove(categoriaRank);
            return Save();  
        }

        public CategoriaRank GetCategoryRankById(int id)
        {
            return _context.CategoriaRank.Where(cr => cr.CategoriaRankId == id).FirstOrDefault();
        }

        public CategoriaRank GetCategoryRankByDescription(string description)
        {
            return _context.CategoriaRank.Where(cr => cr.CategoriaRankDescricao == description).FirstOrDefault();
        }

        public ICollection<CategoriaRank> GetCategorysRank()
        {
            return _context.CategoriaRank.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
