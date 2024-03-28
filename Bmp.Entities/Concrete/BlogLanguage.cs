using Bmp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.Concrete
{
    public class BlogLanguage : IEntity
    {
        public int Id { get; set; }
        public string MainTitle { get; set; }
        public string MainContent { get; set; }
        public string LangCode { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
