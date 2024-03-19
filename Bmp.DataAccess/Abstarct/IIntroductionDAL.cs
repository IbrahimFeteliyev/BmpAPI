using Bmp.Core.DataAccess;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.AboutDTOs;
using Bmp.Entities.DTOs.IntroductionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.DataAccess.Abstarct
{
    public interface IIntroductionDAL : IEntityRepository<Introduction>
    {
        Task<bool> AddIntroduction(IntroductionAddDTO introductionAddDTO, string webRootPath);
        Task<bool> UpdateIntroduction(int Id, IntroductionAdminUpdateDTO introductionEditDTO, string webRootPath);
        IntroductionAdminListDTO GetIntroductionAdmin(string langCode);
        IntroductionAdminDetailDTO GetIntroductionByIdAdmin(int Id);

    }
}
