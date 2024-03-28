using Bmp.Core.Entity;

namespace Bmp.Entities.Concrete
{
    public class BlogPhoto : BaseEntity, IEntity
    {
        public string PhotoUrl { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
