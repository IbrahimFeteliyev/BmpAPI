using Bmp.Core.DataAccess.EntityFramework;
using Bmp.Core.Helper;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.AboutDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Bmp.DataAccess.Concrete.EntityFramework
{
    public class EFAboutDAL : EfEntityRepositoryBase<About, AppDbContext>, IAboutDAL
    {
        public async Task<bool> AddAbout(AboutAddDTO aboutAddDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                About about = new()
                {
                    PhotoUrl = await aboutAddDTO.PhotoUrl.SaveFileAsync(webRootPath),
                };

                await context.Abouts.AddAsync(about);
                await context.SaveChangesAsync();

                for (int i = 0; i < aboutAddDTO.Content.Count; i++)
                {
                    AboutLanguage aboutLanguage = new()
                    {
                        AboutId = about.Id,
                        Content = aboutAddDTO.Content[i],
                        LangCode = aboutAddDTO.LangCode[i]
                    };
                    await context.AboutLanguages.AddAsync(aboutLanguage);
                }

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public AboutAdminDetailDTO GetAboutByIdAdmin(int Id)
        {
            using var context = new AppDbContext();

            var result = context.Abouts.Include(x => x.AboutLanguages)
                .Select(x => new AboutAdminDetailDTO()
                {
                    Id = x.Id,
                    PhotoUrl = x.PhotoUrl,
                    Content = x.AboutLanguages.Select(x => x.Content).ToList(),
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                }).FirstOrDefault(x => x.Id == Id);

            return result;
        }
        public AboutAdminListDTO GetAboutAdmin(string langCode)
        {
            using var context = new AppDbContext();

            var result = context.Abouts.Select(x => new AboutAdminListDTO
            {
                Id = x.Id,
                Content = x.AboutLanguages.FirstOrDefault(x => x.LangCode == langCode).Content,
                PhotoUrl = x.PhotoUrl,
            }).FirstOrDefault();

            return result;
        }

        public List<AboutAdminListDTO> GetAllAboutsAdminList(string langCode)
        {
            using var context = new AppDbContext();

            var result = context.Abouts.Select(x => new AboutAdminListDTO
            {
                Id = x.Id,
                Content = x.AboutLanguages.FirstOrDefault(x => x.LangCode == langCode).Content,
                PhotoUrl = x.PhotoUrl,
            }).ToList();

            return result;
        }

        public async Task<bool> UpdateAbout(int Id, AboutAdminUpdateDTO aboutEditDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                var about = context.Abouts.FirstOrDefault(x => x.Id == Id);

                if (aboutEditDTO.PhotoUrl != null)
                {
                    about.PhotoUrl = await aboutEditDTO.PhotoUrl.SaveFileAsync(webRootPath);
                    context.Abouts.Update(about);
                    await context.SaveChangesAsync();
                }

                var aboutLanguage = context.AboutLanguages.Where(x => x.AboutId == about.Id).ToList();

                for (int i = 0; i < aboutLanguage.Count; i++)
                {
                    aboutLanguage[i].Content = aboutEditDTO.Content[i];
                }
                context.AboutLanguages.UpdateRange(aboutLanguage);
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
