using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Entities.DTOs.AdvantageDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Business.Abstarct
{
    public interface IAdvantageService
    {
        Task<Core.Utilities.Results.Abstract.IResult> AddAdvantageByLanguageAsync(AdvantageAddDTO advantageAddDTO, string webRootPath);
        Task<Core.Utilities.Results.Abstract.IResult> UpdateAdvantageByLanguageAsync(int Id, AdvantageAdminUpdateDTO advantageEditDTO, string webRootPath);
        Core.Utilities.Results.Abstract.IResult RemoveAdvantage(int id);
        IDataResult<List<AdvantageAdminListDTO>> GetAllAdvantagesAdmin(string langCode);
        IDataResult<AdvantageAdminDetailDTO> GetAdvantageById(int id);
    }
}
