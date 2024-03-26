using Bmp.Core.DataAccess;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.DoctorDTOs;

namespace Bmp.DataAccess.Abstarct
{
    public interface IDoctorDAL : IEntityRepository<Doctor>
    {
        Task<bool> AddDoctor(DoctorAddDTO hospitalBranchAddDTO, string webRootPath);
        List<DoctorListDTO> GetAllDoctorList(string langCode);
    }
}
