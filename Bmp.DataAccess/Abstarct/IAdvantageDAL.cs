using Bmp.Core.DataAccess;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.AdvantageDTOs;


namespace Bmp.DataAccess.Abstarct
{
    public interface IAdvantageDAL : IEntityRepository<Advantage>
    {
        Task<bool> AddAdvantage(AdvantageAddDTO advantageAddDTO, string webRootPath);
        Task<bool> UpdateAdvantage(int Id, AdvantageAdminUpdateDTO advantageEditDTO, string webRootPath);
        List<AdvantageAdminListDTO> GetAllAdvantagesAdminList(string langCode);
        AdvantageAdminDetailDTO GetAdvantageByIdAdmin(int id);
    }
}
