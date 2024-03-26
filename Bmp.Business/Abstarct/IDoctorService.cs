using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Entities.DTOs.DoctorDTOs;

namespace Bmp.Business.Abstarct
{
    public interface IDoctorService
    {
        Task<IResult> AddDoctorByLanguageAsync(DoctorAddDTO doctorAddDTO, string webRootPath);
        IDataResult<List<DoctorListDTO>> GetAllDoctors(string langCode);
        IResult RemoveDoctor(int id);
    }
}
