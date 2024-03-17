using Bmp.Business.Abstarct;
using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Core.Utilities.Results.Concrete.ErrorResults;
using Bmp.Core.Utilities.Results.Concrete.SuccessResults;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.DTOs.IntroductionDTOs;


namespace Bmp.Business.Concrete
{
    public class IntroductionManager : IIntroductionService
    {
        private readonly IIntroductionDAL _introductionDAL;

        public IntroductionManager(IIntroductionDAL introductionDAL)
        {
            _introductionDAL = introductionDAL;
        }

        public async Task<IResult> AddIntroductionByLanguageAsync(IntroductionAddDTO introductionAddDTO, string webRootPath)
        {
            var result = await _introductionDAL.AddIntroduction(introductionAddDTO, webRootPath);
            if (result)
            {
                return new SuccessResult("Introduction created successfully");
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IDataResult<IntroductionAdminListDTO> GetIntroductionAdmin(string langCode)
        {
            try
            {
                var result = _introductionDAL.GetIntroductionAdmin(langCode);
                return new SuccessDataResult<IntroductionAdminListDTO>(result, "Listed");
            }
            catch (Exception ex)
            {
                return new SuccessDataResult<IntroductionAdminListDTO>(ex.Message);
            }
        }

        public IDataResult<IntroductionAdminDetailDTO> GetIntroductionById(int id)
        {
            var result = _introductionDAL.GetIntroductionByIdAdmin(id);
            return new SuccessDataResult<IntroductionAdminDetailDTO>(result);
        }


        public IResult RemoveIntroduction(int id)
        {
            var introduction = _introductionDAL.Get(x => x.Id == id);
            _introductionDAL.Delete(introduction);
            return new SuccessResult("Deleted Successfully");
        }

        public async Task<IResult> UpdateIntroductionByLanguageAsync(int Id, IntroductionAdminUpdateDTO introductionEditDTO, string webRootPath)
        {
            var result = await _introductionDAL.UpdateIntroduction(Id, introductionEditDTO, webRootPath);
            if (result)
            {
                return new SuccessResult("Success");
            }
            return new ErrorResult("Error");
        }
    }
}
