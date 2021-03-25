using System.Threading.Tasks;
using BakuCreativeProjects.DTO.User;
using BakuCreativeProjects.Models;

namespace BakuCreativeProjects.Repo
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(UserForLoginDto userForLoginDto);
        Task<bool> UserExists(string userName); 
    }
}