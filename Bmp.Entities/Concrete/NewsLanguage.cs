using Bmp.Core.Entity;


namespace Bmp.Entities.Concrete
{
    public class NewsLanguage : IEntity
    {
        public int Id { get; set; }
        public string MainTitle { get; set; }
        public string MainContent { get; set; }
        public string LangCode { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
    }
}
