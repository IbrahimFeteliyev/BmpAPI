using Bmp.Core.Entity;

namespace Bmp.Entities.Concrete
{
    public class AboutLanguage : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string LangCode { get; set; }
        public int AboutId { get; set; }
        public About About { get; set; }
    }
}
