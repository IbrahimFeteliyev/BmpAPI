using Bmp.Core.DataAccess;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.AboutDTOs;


namespace Bmp.DataAccess.Abstarct
{
    public interface IAboutDAL : IEntityRepository<About>
    {
        Task<bool> AddAbout(AboutAddDTO aboutAddDTO, string webRootPath);
        Task<bool> UpdateAbout(int Id, AboutAdminUpdateDTO aboutEditDTO, string webRootPath);
        List<AboutAdminListDTO> GetAllAboutsAdminList(string langCode);
        AboutAdminDetailDTO GetAboutByIdAdmin(int id);

    }
}
