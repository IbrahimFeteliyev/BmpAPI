using Bmp.Core.DataAccess;
using Bmp.Core.Entity.Models;


namespace Bmp.DataAccess.Abstarct
{
    public interface IAuthDal : IEntityRepository<User>
    {
    }
}
