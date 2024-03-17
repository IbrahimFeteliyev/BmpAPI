using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.DTOs.AdvantageDTOs
{
    public class AdvantageAdminDetailDTO
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public List<string> Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
