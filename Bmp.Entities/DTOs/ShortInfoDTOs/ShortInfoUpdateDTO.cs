using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.DTOs.ShortInfoDTOs
{
    public class ShortInfoUpdateDTO
    {
        public string Count { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<string> Description { get; set; }
    }
}
