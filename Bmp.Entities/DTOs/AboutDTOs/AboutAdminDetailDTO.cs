using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.DTOs.AboutDTOs
{
    public class AboutAdminDetailDTO
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public List<string> Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
