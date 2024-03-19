using Bmp.Entities.DTOs.HospitalBranchDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.DTOs.DepartmentDTOs
{
    public class DepartmentDetailDTO
    {
        public int Id { get; set; }
        public string IconUrl { get; set; }
        public string PhotoUrl { get; set; }
        public List<string> DepartmentName { get; set; }
        public List<DepartmentFeatureListDTO> Features { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
