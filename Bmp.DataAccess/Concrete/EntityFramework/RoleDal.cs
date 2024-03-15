using Bmp.Core.DataAccess.EntityFramework;
using Bmp.Core.Entity.Models;
using Bmp.DataAccess.Abstarct;
using Microsoft.EntityFrameworkCore;

namespace Bmp.DataAccess.Concrete.EntityFramework
{
    public class RoleDal : EfEntityRepositoryBase<Role, AppDbContext>, IRoleDal
    {
        public Role GetUserRole(int userId)
        {
            using AppDbContext context = new();

            var roleUser = context.UserRoles.Include(x => x.Role).FirstOrDefault(x => x.UserId == userId);

            if (roleUser == null)
            {
                return null; // or throw an exception, depending on your logic
            }

            var role = new Role()
            {
                Id = roleUser.RoleId,
                Name = roleUser.Role.Name,
            };

            return role;
        }

    }
}
