using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Entities.DTOs.IntroductionDTOs;


namespace Bmp.Business.Abstarct
{
    public interface IIntroductionService
    {
        Task<Core.Utilities.Results.Abstract.IResult> AddIntroductionByLanguageAsync(IntroductionAddDTO introductionAddDTO, string webRootPath);
        Task<Core.Utilities.Results.Abstract.IResult> UpdateIntroductionByLanguageAsync(int Id, IntroductionAdminUpdateDTO introductionEditDTO, string webRootPath);
        Core.Utilities.Results.Abstract.IResult RemoveIntroduction(int id);
        IDataResult<IntroductionAdminListDTO> GetIntroductionAdmin(string langCode);
        IDataResult<IntroductionAdminDetailDTO> GetIntroductionById(int id);
    }
}
