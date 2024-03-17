using Bmp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.Concrete
{
    public class Introduction : BaseEntity, IEntity
    {
        public string PhotoUrl { get; set; }
        public List<IntroductionLanguage> IntroductionLanguages { get; set; }
    }
}
