using Bmp.Core.DataAccess.EntityFramework;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.Concrete;

namespace Bmp.DataAccess.Concrete.EntityFramework
{
    public class EFContactDAL : EfEntityRepositoryBase<Contact, AppDbContext>, IContactDAL
    {
    }
}
