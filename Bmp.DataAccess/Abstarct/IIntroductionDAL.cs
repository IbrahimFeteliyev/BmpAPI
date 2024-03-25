using Bmp.Core.DataAccess;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.IntroductionDTOs;

namespace Bmp.DataAccess.Abstarct
{
    public interface IIntroductionDAL : IEntityRepository<Introduction>
    {
        Task<bool> AddIntroduction(IntroductionAddDTO introductionAddDTO, string webRootPath);
        Task<bool> UpdateIntroduction(int Id, IntroductionAdminUpdateDTO introductionEditDTO, string webRootPath);
        IntroductionAdminListDTO GetIntroductionAdmin(string langCode);
        List<IntroductionAdminListDTO> GetAllIntroductionsAdminList(string langCode);
        IntroductionAdminDetailDTO GetIntroductionByIdAdmin(int Id);

    }
}
