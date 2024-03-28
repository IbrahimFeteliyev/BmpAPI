using Bmp.Core.Entity;


namespace Bmp.Entities.Concrete
{
    public class BlogContentLanguage : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string LangCode { get; set; }
        public int BlogContentId { get; set; }
        public BlogContent BlogContent { get; set; }
    }
}
