using Bmp.Core.DataAccess.EntityFramework;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.ShortInfoDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.DataAccess.Concrete.EntityFramework
{
    public class EFShortInfoDAL : EfEntityRepositoryBase<ShortInfo, AppDbContext>, IShortInfoDAL
    {
        public async Task<bool> AddShortInfo(ShortInfoAddDTO shortInfoAddDTO)
        {
            try
            {
                using var context = new AppDbContext();
                ShortInfo shortInfo = new()
                {
                    Count = shortInfoAddDTO.Count
                };

                await context.ShortInfos.AddAsync(shortInfo);
                await context.SaveChangesAsync();

                for (int i = 0; i < shortInfoAddDTO.Description.Count; i++)
                {
                    ShortInfoLanguage shortInfoLanguage = new()
                    {
                        ShortInfoId = shortInfo.Id,
                        Description = shortInfoAddDTO.Description[i],
                        LangCode = shortInfoAddDTO.LangCode[i],

                    };
                    await context.ShortInfoLanguages.AddAsync(shortInfoLanguage);
                }

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<ShortInfoAdminListDTO> GetAllShortInfosAdminList(string langCode)
        {
            using var context = new AppDbContext();

            var result = context.ShortInfos.Select(x => new ShortInfoAdminListDTO
            {
                Id = x.Id,
                Description = x.ShortInfoLanguages.FirstOrDefault(x => x.LangCode == langCode).Description,
                Count = x.Count,
            }).ToList();

            return result;
        }

        public ShortInfoAdminDetailDTO GetShortInfoByIdAdmin(int Id)
        {
            using var context = new AppDbContext();

            var result = context.ShortInfos.Include(x => x.ShortInfoLanguages)
                .Select(x => new ShortInfoAdminDetailDTO()
                {
                    Id = x.Id,
                    Count = x.Count,
                    Description = x.ShortInfoLanguages.Select(x => x.Description).ToList(),
                })
                .FirstOrDefault(x => x.Id == Id);
            return result;
        }


        public async Task<bool> UpdateShortInfo(ShortInfoUpdateDTO shortInfoUpdateDTO, int Id)
        {
            try
            {
                using var context = new AppDbContext();
                var shortInfo = context.ShortInfos.FirstOrDefault(x => x.Id == Id);

                shortInfo.Count = shortInfoUpdateDTO.Count;


                context.ShortInfos.Update(shortInfo);
                await context.SaveChangesAsync();

                var shortInfoLanguage = context.ShortInfoLanguages.Where(x => x.ShortInfoId == shortInfo.Id).ToList();

                for (int i = 0; i < shortInfoLanguage.Count; i++)
                {
                    shortInfoLanguage[i].Description = shortInfoUpdateDTO.Description[i];
                }
                context.ShortInfoLanguages.UpdateRange(shortInfoLanguage);
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
