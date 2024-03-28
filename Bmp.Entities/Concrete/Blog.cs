using Bmp.Core.Entity;


namespace Bmp.Entities.Concrete
{
    public class Blog : BaseEntity, IEntity
    {
        public string CoverPhoto { get; set; }
        public List<BlogPhoto> BlogPhotos { get; set; } = new List<BlogPhoto>();
        public List<BlogLanguage> BlogLanguages { get; set; } = new List<BlogLanguage>();
        public List<BlogContent> BlogContents { get; set; } = new List<BlogContent>();
    }
}
