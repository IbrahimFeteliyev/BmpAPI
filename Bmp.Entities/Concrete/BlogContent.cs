using Bmp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.Concrete
{
    public class BlogContent : BaseEntity, IEntity
    {
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public List<BlogContentLanguage> BlogContentLanguages { get; set; } = new List<BlogContentLanguage>();
    }
}
