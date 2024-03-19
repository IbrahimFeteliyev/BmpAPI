using Bmp.Entities.DTOs.HospitalBranchDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.DTOs.DepartmentDTOs
{
    public class DepartmentAddDTO
    {
        public IFormFile IconUrl { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public List<string> DepartmentName { get; set; }
        public List<string> LangCode { get; set; }

        public List<DepartmentFeatureAddDTO> DepartmentFeatures { get; set; }
    }
    public class DepartmentFeatureAddDTO
    {
        public List<string> DepartmentFeatureText { get; set; }
    }

}
