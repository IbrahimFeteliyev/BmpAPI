using Bmp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.Concrete
{
    public class AdvantageLanguage : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LangCode { get; set; }
        public int AdvantageId { get; set; }
        public Advantage Advantage { get; set; }
    }
}
