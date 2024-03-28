using Bmp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.Concrete
{
    public class NewsContentLanguage : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string LangCode { get; set; }
        public int NewsContentId { get; set; }
        public NewsContent NewsContent { get; set; }
    }
}
