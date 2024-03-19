using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.DTOs.MapDTOs
{
    public class MapAdminDTO
    {
        public int Id { get; set; }
        public string MapUrl { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string UpdatedDate { get; set; }
        public string CreatedDate { get; set; }
    }
}
