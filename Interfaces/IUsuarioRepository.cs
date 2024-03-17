using Dto;
using Models;

namespace Interfaces
{
    public interface IUsuarioRepository
    {
        ICollection<Usuario> GetUsers();
        Usuario GetUser(int id);
        ICollection<Usuario> GetUserByName(string username);
        bool UserExists(int id);
        bool CreateUser(Usuario user);
        bool UpdateUser(Usuario user);
        bool DeleteUser(Usuario id);
        bool Save();
    }
}
