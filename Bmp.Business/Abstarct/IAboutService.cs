using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Entities.DTOs.AboutDTOs;
using Microsoft.AspNetCore.Http;

namespace Bmp.Business.Abstarct
{
    public interface IAboutService
    {
        Task<Core.Utilities.Results.Abstract.IResult> AddAboutByLanguageAsync(AboutAddDTO aboutAddDTO, string webRootPath);
        Task<Core.Utilities.Results.Abstract.IResult> UpdateAboutByLanguageAsync(int Id, AboutAdminUpdateDTO aboutEditDTO, string webRootPath);
        Core.Utilities.Results.Abstract.IResult RemoveAbout(int id);
        IDataResult<List<AboutAdminListDTO>> GetAllAboutsAdmin(string langCode);
        IDataResult<AboutAdminListDTO> GetAboutAdmin(string langCode);
        IDataResult<AboutAdminDetailDTO> GetAboutById(int id);

    }
}
