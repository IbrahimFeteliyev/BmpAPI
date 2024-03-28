using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Entities.DTOs.DoctorDTOs;

namespace Bmp.Business.Abstarct
{
    public interface IDoctorService
    {
        Task<IResult> AddDoctorByLanguageAsync(DoctorAddDTO doctorAddDTO, string webRootPath);
        Task<IResult> UpdateDoctorByLanguageAsync(DoctorUpdateDTO doctorUpdateDTO, string webRootPath);
        IDataResult<List<DoctorListDTO>> GetAllDoctors(string langCode);
        IDataResult<DoctorDetailDTO> GetDoctorById(int id);
        IDataResult<DoctorDetailLangDTO> GetDoctorLangById(int id, string langCode);
        IResult RemoveDoctor(int id);
    }
}
