using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Entities.DTOs.HospitalBranchDTOs;


namespace Bmp.Business.Abstarct
{
    public interface IHospitalBranchService
    {
        Task<IResult> AddHospitalBranchByLanguageAsync(HospitalBranchAddDTO hospitalBranchAddDTO, string webRootPath);
        Task<IResult> UpdateHospitalBranchByLanguageAsync(HospitalBranchUpdateDTO hospitalBranchUpdateDTO, string webRootPath);
        IDataResult<HospitalBranchDetailDTO> GetHospitalBranchById(int id);
        IDataResult<List<HospitalBranchListDTO>> GetAllHospitalBranchs(string langCode);
        IResult RemoveHospitalBranch(int id);
    }
}
