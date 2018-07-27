using System.Threading.Tasks;
using Secretary.API.Models;

namespace Secretary.API.Interfaces
{
    public interface IAuthRepository
    {
         Task<Usuario> Register(Usuario usuario, string password);

        Task<Usuario> Login(string username, string password);

        Task<bool> UserExist(string username);
    }
}