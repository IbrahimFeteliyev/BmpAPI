using Bmp.Core.DataAccess;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.ShortInfoDTOs;


namespace Bmp.DataAccess.Abstarct
{
    public interface IShortInfoDAL : IEntityRepository<ShortInfo>
    {
        Task<bool> AddShortInfo(ShortInfoAddDTO shortInfoAddDTO);
        Task<bool> UpdateShortInfo(ShortInfoUpdateDTO shortInfoUpdateDTO, int Id);
        List<ShortInfoAdminListDTO> GetAllShortInfosAdminList(string langCode);
        ShortInfoAdminDetailDTO GetShortInfoByIdAdmin(int Id);
    }
}
