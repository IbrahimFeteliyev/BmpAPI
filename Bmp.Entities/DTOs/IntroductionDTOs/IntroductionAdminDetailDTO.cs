using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.DTOs.IntroductionDTOs
{
    public class IntroductionAdminDetailDTO
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public List<string> Title { get; set; }
        public List<string> Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
