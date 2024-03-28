using Bmp.Core.Entity;


namespace Bmp.Entities.Concrete
{
    public class NewsContent : BaseEntity, IEntity
    {
        public int NewsId { get; set; }
        public News News { get; set; }
        public List<NewsContentLanguage> NewsContentLanguages { get; set; } = new List<NewsContentLanguage>();
    }
}
