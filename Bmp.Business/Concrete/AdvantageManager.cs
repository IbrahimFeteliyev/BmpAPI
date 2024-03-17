using Bmp.Business.Abstarct;
using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Core.Utilities.Results.Concrete.ErrorResults;
using Bmp.Core.Utilities.Results.Concrete.SuccessResults;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.DTOs.AdvantageDTOs;


namespace Bmp.Business.Concrete
{
    internal class AdvantageManager : IAdvantageService
    {
        private readonly IAdvantageDAL _advantageDAL;

        public AdvantageManager(IAdvantageDAL advantageDAL)
        {
            _advantageDAL = advantageDAL;
        }

        public async Task<IResult> AddAdvantageByLanguageAsync(AdvantageAddDTO advantageAddDTO, string webRootPath)
        {
            var result = await _advantageDAL.AddAdvantage(advantageAddDTO, webRootPath);
            if (result)
            {
                return new SuccessResult("Advantage created successfully");
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IDataResult<AdvantageAdminDetailDTO> GetAdvantageById(int id)
        {
            var result = _advantageDAL.GetAdvantageByIdAdmin(id);
            return new SuccessDataResult<AdvantageAdminDetailDTO>(result);
        }

        public IDataResult<List<AdvantageAdminListDTO>> GetAllAdvantagesAdmin(string langCode)
        {
            try
            {
                var result = _advantageDAL.GetAllAdvantagesAdminList(langCode);
                return new SuccessDataResult<List<AdvantageAdminListDTO>>(result, "Listed");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<AdvantageAdminListDTO>>(ex.Message);
            }
        }

        public IResult RemoveAdvantage(int id)
        {
            var advantage = _advantageDAL.Get(x => x.Id == id);
            _advantageDAL.Delete(advantage);
            return new SuccessResult("Deleted Successfully");
        }

        public async Task<IResult> UpdateAdvantageByLanguageAsync(int Id, AdvantageAdminUpdateDTO advantageEditDTO, string webRootPath)
        {
            var result = await _advantageDAL.UpdateAdvantage(Id, advantageEditDTO, webRootPath);
            if (result)
            {
                return new SuccessResult("Success");
            }
            return new ErrorResult("Error");
        }
    }
}
