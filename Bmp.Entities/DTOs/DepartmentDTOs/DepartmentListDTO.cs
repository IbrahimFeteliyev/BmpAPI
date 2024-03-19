using Bmp.Entities.DTOs.HospitalBranchDTOs;


namespace Bmp.Entities.DTOs.DepartmentDTOs
{
    public class DepartmentListDTO
    {
        public int Id { get; set; }
        public string IconUrl { get; set; }
        public string PhotoUrl { get; set; }
        public string DepartmentName { get; set; }
        public List<DepartmentFeatureListDTO> Features { get; set; }
    }
}
