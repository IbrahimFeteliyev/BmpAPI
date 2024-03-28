using Bmp.Entities.DTOs.HospitalBranchDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.DTOs.BlogDTOs
{
    public class BlogDetailDTO
    {
        public int Id { get; set; }
        public string CoverPhoto { get; set; }
        public List<string> MainTitle { get; set; }
        public List<string> MainContent { get; set; }
        public List<string> PhotoUrl { get; set; }
        public List<BlogContentListDTO> Contents { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
