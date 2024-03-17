using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.DTOs.AdvantageDTOs
{
    public class AdvantageAddDTO
    {
        public IFormFile PhotoUrl { get; set; }
        public List<string> Title { get; set; }
        public List<string> LangCode { get; set; }
    }
}
