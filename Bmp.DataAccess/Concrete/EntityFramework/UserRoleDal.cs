using Bmp.Core.DataAccess.EntityFramework;
using Bmp.Core.Entity.Models;
using Bmp.DataAccess.Abstarct;


namespace Bmp.DataAccess.Concrete.EntityFramework
{
    public class UserRoleDal : EfEntityRepositoryBase<UserRole, AppDbContext>, IUserRoleDal
    {
    }
}
