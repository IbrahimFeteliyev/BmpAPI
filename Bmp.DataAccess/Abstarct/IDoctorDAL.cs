using Bmp.Core.DataAccess;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.DoctorDTOs;

namespace Bmp.DataAccess.Abstarct
{
    public interface IDoctorDAL : IEntityRepository<Doctor>
    {
        Task<bool> AddDoctor(DoctorAddDTO doctorAddDTO, string webRootPath);
        Task<bool> UpdateDoctor(DoctorUpdateDTO doctorUpdateDTO, string webRootPath);
        DoctorDetailDTO GetDoctorByIdAdmin(int Id);
        DoctorDetailLangDTO GetDoctorLangById(int Id, string langCode);
        List<DoctorListDTO> GetAllDoctorList(string langCode);
    }
}
