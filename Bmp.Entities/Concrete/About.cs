using Bmp.Core.Entity;

namespace Bmp.Entities.Concrete
{
    public class About : BaseEntity, IEntity
    {
        public string PhotoUrl { get; set; }
        public List<AboutLanguage> AboutLanguages { get; set; }

    }
}
