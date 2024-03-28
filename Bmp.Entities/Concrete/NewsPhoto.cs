using Bmp.Core.Entity;

namespace Bmp.Entities.Concrete
{
    public class NewsPhoto : BaseEntity, IEntity
    {
        public string PhotoUrl { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
    }
}
