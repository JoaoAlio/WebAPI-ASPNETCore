using Models;

namespace Interfaces
{
    public interface IUsuarioRepository
    {
        ICollection<Usuario> GetUsers();
        Usuario GetUser(int id);
        ICollection<Usuario> GetUserByName(string username);
        bool UserExists(int id);
    }
}
