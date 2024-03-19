using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.DTOs.ShortInfoDTOs
{
    public class ShortInfoAddDTO
    {
        public string Count { get; set; }
        public List<string> Description { get; set; }
        public List<string> LangCode { get; set; }
    }
}
