using Bmp.Core.DataAccess;
using Bmp.Core.Entity.Models;


namespace Bmp.DataAccess.Abstarct
{
    public interface IRoleDal : IEntityRepository<Role>
    {
        Role GetUserRole(int userId);
    }
}
