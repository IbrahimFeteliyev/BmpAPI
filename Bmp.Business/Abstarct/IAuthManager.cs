using Bmp.Core.Entity.Models;
using Bmp.Entities.DTOs;

namespace Bmp.Business.Abstarct
{
    public interface IAuthManager
    {
        void Register(RegisterDTO model);
        User GetUserByEmail(string email);
        User Login(string email);
        List<User> GetUsers();
    }
}
