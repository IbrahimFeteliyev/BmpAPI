using Bmp.Core.Entity;


namespace Bmp.Entities.Concrete
{
    public class News : BaseEntity, IEntity
    {
        public string CoverPhoto { get; set; }
        public List<NewsPhoto> NewsPhotos { get; set; } = new List<NewsPhoto>();
        public List<NewsLanguage> NewsLanguages { get; set; } = new List<NewsLanguage>();
        public List<NewsContent> NewsContents { get; set; } = new List<NewsContent>();
    }
}
