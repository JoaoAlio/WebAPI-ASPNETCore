using Data;
using Dto;
using Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public bool CreateUser(Usuario user)
        {
            //var task = _context.Tarefas.Where(t => t.Id == taskId).ToList();

            var usuario = new Usuario()
            {
                Nome = user.Nome,
                Sobrenome = user.Sobrenome
            };

            _context.Add(usuario);

            return Save();
        }

        public bool UpdateUser(Usuario user) 
        {
            _context.Update(user);
            return Save();
        }

        public bool DeleteUser(Usuario user) 
        {
            _context.Remove(user);
            return Save();
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

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UserExists(int id)
        {
            return _context.Usuarios.Any(u => u.Id == id);
        }
    }
}
