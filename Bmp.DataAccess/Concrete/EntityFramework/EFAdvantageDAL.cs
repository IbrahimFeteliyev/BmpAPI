using Bmp.Core.DataAccess.EntityFramework;
using Bmp.Core.Helper;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.AdvantageDTOs;
using Microsoft.EntityFrameworkCore;


namespace Bmp.DataAccess.Concrete.EntityFramework
{
    public class EFAdvantageDAL : EfEntityRepositoryBase<Advantage, AppDbContext>, IAdvantageDAL
    {
        public async Task<bool> AddAdvantage(AdvantageAddDTO advantageAddDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                Advantage advantage = new()
                {
                    PhotoUrl = await advantageAddDTO.PhotoUrl.SaveFileAsync(webRootPath),
                };

                await context.Advantages.AddAsync(advantage);
                await context.SaveChangesAsync();

                for (int i = 0; i < advantageAddDTO.Title.Count; i++)
                {
                    AdvantageLanguage advantageLanguage = new()
                    {
                        AdvantageId = advantage.Id,
                        Title = advantageAddDTO.Title[i],
                        LangCode = advantageAddDTO.LangCode[i]
                    };
                    await context.AdvantageLanguages.AddAsync(advantageLanguage);
                }

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public AdvantageAdminDetailDTO GetAdvantageByIdAdmin(int id)
        {
            using var context = new AppDbContext();

            var result = context.Advantages.Include(x => x.AdvantageLanguages)
                .Select(x => new AdvantageAdminDetailDTO()
                {
                    Id = x.Id,
                    PhotoUrl = x.PhotoUrl,
                    Title = x.AdvantageLanguages.Select(x => x.Title).ToList(),
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                }).FirstOrDefault(x => x.Id == id);

            return result;
        }

        public List<AdvantageAdminListDTO> GetAllAdvantagesAdminList(string langCode)
        {
            using var context = new AppDbContext();

            var result = context.Advantages.Select(x => new AdvantageAdminListDTO
            {
                Id = x.Id,
                Title = x.AdvantageLanguages.FirstOrDefault(x => x.LangCode == langCode).Title,
                PhotoUrl = x.PhotoUrl,
            }).ToList();

            return result;
        }

        public async Task<bool> UpdateAdvantage(int Id, AdvantageAdminUpdateDTO advantageEditDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                var advantage = context.Advantages.FirstOrDefault(x => x.Id == Id);

                if (advantageEditDTO.PhotoUrl != null)
                {
                    advantage.PhotoUrl = await advantageEditDTO.PhotoUrl.SaveFileAsync(webRootPath);
                    context.Advantages.Update(advantage);
                    await context.SaveChangesAsync();
                }

                var advantageLanguage = context.AdvantageLanguages.Where(x => x.AdvantageId == advantage.Id).ToList();

                for (int i = 0; i < advantageLanguage.Count; i++)
                {
                    advantageLanguage[i].Title = advantageEditDTO.Title[i];
                }
                context.AdvantageLanguages.UpdateRange(advantageLanguage);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
