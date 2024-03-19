using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.DTOs.DepartmentDTOs
{
    public class DepartmentUpdateDTO
    {
        public int Id { get; set; }
        public IFormFile IconUrl { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public List<string> DepartmentName { get; set; }

        public List<DepartmentFeatureUpdateDTO> DepartmentFeatures { get; set; }
    }
    public class DepartmentFeatureUpdateDTO
    {
        public List<string> DepartmentFeatureText { get; set; }
    }
}
