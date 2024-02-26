using AutoMapper;
using Data;
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
    }
}
