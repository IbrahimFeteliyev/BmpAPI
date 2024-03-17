using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.DTOs.IntroductionDTOs
{
    public class IntroductionAdminListDTO
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
