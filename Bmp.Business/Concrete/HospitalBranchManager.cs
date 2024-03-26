using Bmp.Business.Abstarct;
using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Core.Utilities.Results.Concrete.ErrorResults;
using Bmp.Core.Utilities.Results.Concrete.SuccessResults;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.DTOs.HospitalBranchDTOs;


namespace Bmp.Business.Concrete
{
    public class HospitalBranchManager : IHospitalBranchService
    {
        private readonly IHospitalBranchDAL _hospitalBranchDAL;

        public HospitalBranchManager(IHospitalBranchDAL hospitalBranchDAL)
        {
            _hospitalBranchDAL = hospitalBranchDAL;
        }

        public async Task<IResult> AddHospitalBranchByLanguageAsync(HospitalBranchAddDTO hospitalBranchAddDTO, string webRootPath)
        {
            var result = await _hospitalBranchDAL.AddHospitalBranch(hospitalBranchAddDTO, webRootPath);
            if (result)
            {
                return new SuccessResult("HospitalBranch created successfully");
            }
            else
            {
                return new ErrorResult();
            }
        }
        public IDataResult<List<HospitalBranchListDTO>> GetAllHospitalBranchs(string langCode)
        {
            try
            {
                var result = _hospitalBranchDAL.GetAllHospitalBranchList(langCode);
                return new SuccessDataResult<List<HospitalBranchListDTO>>(result, "Listed");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<HospitalBranchListDTO>>(ex.Message);
            }
        }

        public IDataResult<HospitalBranchDetailDTO> GetHospitalBranchById(int id)
        {
            var result = _hospitalBranchDAL.GetHospitalBranchByIdAdmin(id);
            return new SuccessDataResult<HospitalBranchDetailDTO>(result);
        }

        public IDataResult<HospitalBranchDetailDTO> GetHospitalBranchLangById(int id, string langCode)
        {
            var result = _hospitalBranchDAL.GetHospitalBranchLangById(id, langCode);
            return new SuccessDataResult<HospitalBranchDetailDTO>(result);
        }

        public IResult RemoveHospitalBranch(int id)
        {
            var hospitalBranch = _hospitalBranchDAL.Get(x => x.Id == id);
            _hospitalBranchDAL.Delete(hospitalBranch);
            return new SuccessResult("Deleted Successfully");
        }

        public async Task<IResult> UpdateHospitalBranchByLanguageAsync(HospitalBranchUpdateDTO hospitalBranchUpdateDTO, string webRootPath)
        {
            var result = await _hospitalBranchDAL.UpdateHospitalBranch(hospitalBranchUpdateDTO, webRootPath);
            if (result)
            {
                return new SuccessResult("HospitalBranch updated successfully");
            }
            else
            {
                return new ErrorResult();
            }
        }
    }
}
