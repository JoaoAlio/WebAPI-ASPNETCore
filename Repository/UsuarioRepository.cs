using Data;
using Interfaces;
using Models;

namespace Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private DataContext _context;
        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }
        public Usuario GetUser(int id)
        {
            return _context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
        }

        public ICollection<Usuario> GetUserByName(string username)
        {
            return _context.Usuarios.Where(u => u.Nome == username).ToList();
        }

        public ICollection<Usuario> GetUsers()
        {
            return _context.Usuarios.OrderBy(u => u.Nome).ToList();
        }

        public bool UserExists(int id)
        {
            return _context.Usuarios.Any(u => u.Id == id);
        }
    }
}
