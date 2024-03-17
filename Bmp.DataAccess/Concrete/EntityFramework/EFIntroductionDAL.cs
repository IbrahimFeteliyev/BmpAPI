using Bmp.Core.DataAccess.EntityFramework;
using Bmp.Core.Helper;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.IntroductionDTOs;
using Microsoft.EntityFrameworkCore;

namespace Bmp.DataAccess.Concrete.EntityFramework
{
    public class EFIntroductionDAL : EfEntityRepositoryBase<Introduction, AppDbContext>, IIntroductionDAL
    {
        public async Task<bool> AddIntroduction(IntroductionAddDTO introductionAddDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                Introduction introduction = new()
                {
                    PhotoUrl = await introductionAddDTO.PhotoUrl.SaveFileAsync(webRootPath),
                };

                await context.Introductions.AddAsync(introduction);
                await context.SaveChangesAsync();

                for (int i = 0; i < introductionAddDTO.Title.Count; i++)
                {
                    IntroductionLanguage introductionLanguage = new()
                    {
                        IntroductionId = introduction.Id,
                        Title = introductionAddDTO.Title[i],
                        Description = introductionAddDTO.Description[i],
                        LangCode = introductionAddDTO.LangCode[i]
                    };
                    await context.IntroductionLanguages.AddAsync(introductionLanguage);
                }

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IntroductionAdminDetailDTO GetIntroductionByIdAdmin(int id)
        {
            using var context = new AppDbContext();

            var result = context.Introductions.Include(x => x.IntroductionLanguages)
                .Select(x => new IntroductionAdminDetailDTO()
                {
                    Id = x.Id,
                    PhotoUrl = x.PhotoUrl,
                    Title = x.IntroductionLanguages.Select(x => x.Title).ToList(),
                    Description = x.IntroductionLanguages.Select(x => x.Description).ToList(),
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                }).FirstOrDefault(x => x.Id == id);

            return result;
        }
        public IntroductionAdminListDTO GetIntroductionAdmin(string langCode)
        {
            using var context = new AppDbContext();

            var result = context.Introductions.Select(x => new IntroductionAdminListDTO
            {
                Id = x.Id,
                Title = x.IntroductionLanguages.FirstOrDefault(x => x.LangCode == langCode).Title,
                Description = x.IntroductionLanguages.FirstOrDefault(x => x.LangCode == langCode).Description,
                PhotoUrl = x.PhotoUrl,
            }).FirstOrDefault();

            return result;
        }

        public async Task<bool> UpdateIntroduction(int Id, IntroductionAdminUpdateDTO introductionEditDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                var introduction = context.Introductions.FirstOrDefault(x => x.Id == Id);

                if (introductionEditDTO.PhotoUrl != null)
                {
                    introduction.PhotoUrl = await introductionEditDTO.PhotoUrl.SaveFileAsync(webRootPath);
                    context.Introductions.Update(introduction);
                    await context.SaveChangesAsync();
                }

                var introductionLanguage = context.IntroductionLanguages.Where(x => x.IntroductionId == introduction.Id).ToList();

                for (int i = 0; i < introductionLanguage.Count; i++)
                {
                    introductionLanguage[i].Title = introductionEditDTO.Title[i];
                    introductionLanguage[i].Description = introductionEditDTO.Description[i];
                }
                context.IntroductionLanguages.UpdateRange(introductionLanguage);
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
