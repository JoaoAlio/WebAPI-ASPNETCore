using AutoMapper;
using Data;
using Dto;
using Interfaces;
using Models;

namespace Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CategoriaRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
              
        }
        public bool CategoryExists(int id)
        {
            return _context.Categorias.Any(c => c.Id == id);
        }

        public bool CreateCategory(Categoria category, int catRankId)
        {
            var catRank = _context.CategoriaRank.Where(cr => cr.CategoriaRankId == catRankId).FirstOrDefault();

            var categoria = new Categoria
            {
                Titulo = category.Titulo,
                CategoriaRankId = catRank.CategoriaRankId
            };

            _context.Add(categoria);

            return Save();
        }

        public bool UpdateCategory(Categoria category, int catRankId)
        {
            category.CategoriaRankId = catRankId;
            _context.Update(category);
            return Save();  
        }

        public bool DeleteCategory(Categoria category) 
        {
            _context.Remove(category);
            return Save();
        }

        public Categoria GetCategory(int id)
        {
            return _context.Categorias.Where(c => c.Id == id).FirstOrDefault();
        }

        public Categoria GetCategoryByTitle(string title)
        {
            return _context.Categorias.Where(c => c.Titulo == title).FirstOrDefault();
        }

        public ICollection<Categoria> GetCategorys()
        {
            return _context.Categorias.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
