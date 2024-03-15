using Bmp.Business.Abstarct;
using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Core.Utilities.Results.Concrete.ErrorResults;
using Bmp.Core.Utilities.Results.Concrete.SuccessResults;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.DTOs.AboutDTOs;
using Microsoft.AspNetCore.Http;
using IResult = Bmp.Core.Utilities.Results.Abstract.IResult;

namespace Bmp.Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDAL _aboutDAL;
        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }

        public async Task<IResult> AddAboutByLanguageAsync(AboutAddDTO aboutAddDTO, string webRootPath)
        {
            var result = await _aboutDAL.AddAbout(aboutAddDTO, webRootPath);
            if (result)
            {
                return new SuccessResult("About created successfully");
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IDataResult<AboutAdminDetailDTO> GetAboutById(int id)
        {
            var result = _aboutDAL.GetAboutByIdAdmin(id);
            return new SuccessDataResult<AboutAdminDetailDTO>(result);
        }

        public IDataResult<List<AboutAdminListDTO>> GetAllAboutsAdmin(string langCode)
        {
            try
            {
                var result = _aboutDAL.GetAllAboutsAdminList(langCode);
                return new SuccessDataResult<List<AboutAdminListDTO>>(result, "Listed");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<AboutAdminListDTO>>(ex.Message);
            }
        }

        public IResult RemoveAbout(int id)
        {
            var about = _aboutDAL.Get(x => x.Id == id);
            _aboutDAL.Delete(about);
            return new SuccessResult("Deleted Successfully");
        }

        public async Task<IResult> UpdateAboutByLanguageAsync(int Id, AboutAdminUpdateDTO aboutEditDTO, string webRootPath)
        {
            var result = await _aboutDAL.UpdateAbout(Id, aboutEditDTO, webRootPath);
            if (result)
            {
                return new SuccessResult("Success");
            }
            return new ErrorResult("Error");
        }
    }
}
