using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.DTOs.AboutDTOs
{
    public class AboutAdminUpdateDTO
    {
        public IFormFile? PhotoUrl { get; set; }
        public List<string> Content { get; set; }
    }
}
