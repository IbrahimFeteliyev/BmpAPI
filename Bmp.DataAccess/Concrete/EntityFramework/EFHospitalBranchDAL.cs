using Bmp.Core.DataAccess.EntityFramework;
using Bmp.Core.Helper;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.HospitalBranchDTOs;
using Microsoft.EntityFrameworkCore;


namespace Bmp.DataAccess.Concrete.EntityFramework
{
    public class EFHospitalBranchDAL : EfEntityRepositoryBase<HospitalBranch, AppDbContext>, IHospitalBranchDAL
    {
        public async Task<bool> AddHospitalBranch(HospitalBranchAddDTO hospitalBranchAddDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                HospitalBranch hospitalBranch = new()
                {
                    CoverPhoto = await hospitalBranchAddDTO.CoverPhoto.SaveFileAsync(webRootPath),
                };

                //await context.HospitalBranchs.AddAsync(hospitalBranch);
                //await context.SaveChangesAsync();

                for (int i = 0; i < hospitalBranchAddDTO.BranchName.Count; i++)
                {
                    HospitalBranchLanguage hospitalBranchLanguage = new()
                    {
                        HospitalBranchId = hospitalBranch.Id,
                        BranchName = hospitalBranchAddDTO.BranchName[i],
                        Description = hospitalBranchAddDTO.Description[i],
                        LangCode = hospitalBranchAddDTO.LangCode[i]
                    };

                    hospitalBranch.HospitalBranchLanguages.Add(hospitalBranchLanguage);
                    //await context.HospitalBranchLanguages.AddAsync(hospitalBranchLanguage);
                }

                for (int i = 0; i < hospitalBranchAddDTO.HospitalBranchFeatures.Count; i++)
                {
                    HospitalBranchFeature hospitalBranchFeature = new()
                    {
                        HospitalBranchId = hospitalBranch.Id,
                        Count = hospitalBranchAddDTO.HospitalBranchFeatures[i].Count,
                        PhotoUrl = await hospitalBranchAddDTO.HospitalBranchFeatures[i].FeaturePhotoUrl.SaveFileAsync(webRootPath),
                    };
                    await context.HospitalBranchFeatures.AddAsync(hospitalBranchFeature);

                    for (int j = 0; j < hospitalBranchAddDTO.HospitalBranchFeatures[i].FeatureDescription.Count; j++)
                    {
                        HospitalBranchFeatureLanguage hospitalBranchFeatureLanguage = new()
                        {
                            HospitalBranchFeatureId = hospitalBranchFeature.Id,
                            Description = hospitalBranchAddDTO.HospitalBranchFeatures[i].FeatureDescription[j],
                            LangCode = hospitalBranchAddDTO.LangCode[j]
                        };
                        hospitalBranchFeature.HospitalBranchFeatureLanguages.Add(hospitalBranchFeatureLanguage);
                        //await context.HospitalBranchFeatureLanguages.AddAsync(hospit
                        //alBranchFeatureLanguage);
                    }

                    hospitalBranch.HospitalBranchFeatures.Add(hospitalBranchFeature);
                }

                for (int i = 0; i < hospitalBranchAddDTO.PhotoUrl.Count; i++)
                {
                    HospitalBranchPhoto hospitalBranchPhoto = new()
                    {
                        HospitalBranchId = hospitalBranch.Id,
                        PhotoUrl = await hospitalBranchAddDTO.PhotoUrl[i].SaveFileAsync(webRootPath),
                    };
                    hospitalBranch.HospitalBranchPhotos.Add(hospitalBranchPhoto);
                    //await context.HospitalBranchPhotos.AddAsync(hospitalBranchPhoto);
                }

                await context.HospitalBranchs.AddAsync(hospitalBranch);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<HospitalBranchListDTO> GetAllHospitalBranchList(string langCode)
        {
            using var context = new AppDbContext();

            var result = context.HospitalBranchs.Select(x => new HospitalBranchListDTO
            {
                Id = x.Id,
                BranchName = x.HospitalBranchLanguages.FirstOrDefault(x => x.LangCode == langCode).BranchName,
                Description = x.HospitalBranchLanguages.FirstOrDefault(x => x.LangCode == langCode).Description,
                PhotoUrl = x.HospitalBranchPhotos.Select(x => x.PhotoUrl).ToList(),
                CoverPhoto = x.CoverPhoto,
                Features = x.HospitalBranchFeatures.Select(f => new HospitalBranchFeatureListDTO
                {
                    Count = f.Count,
                    FeatureDescription = f.HospitalBranchFeatureLanguages
                                         .Where(l => l.LangCode == langCode)
                                         .Select(l => l.Description)
                                         .ToList(),
                    FeaturePhotoUrl = f.PhotoUrl
                }).ToList()
            }).ToList();

            return result;
        }

        public HospitalBranchDetailDTO GetHospitalBranchByIdAdmin(int Id)
        {
            using var context = new AppDbContext();

            var result = context.HospitalBranchs
                .Include(x => x.HospitalBranchLanguages)
                .Include(x => x.HospitalBranchFeatures)
                .Include(x => x.HospitalBranchPhotos)
                .Select(x => new HospitalBranchDetailDTO()
                {
                    Id = x.Id,
                    CoverPhoto = x.CoverPhoto,
                    UpdatedDate = x.UpdatedDate,
                    CreatedDate = x.CreatedDate,
                    BranchName = x.HospitalBranchLanguages.Select(x => x.BranchName).ToList(),
                    Description = x.HospitalBranchLanguages.Select(x => x.Description).ToList(),
                    PhotoUrl = x.HospitalBranchPhotos.Select(x => x.PhotoUrl).ToList(),
                    Features = x.HospitalBranchFeatures.Select(f => new HospitalBranchFeatureListDTO
                    {
                        Count = f.Count,
                        FeatureDescription = f.HospitalBranchFeatureLanguages.Select(l => l.Description).ToList(),
                        FeaturePhotoUrl = f.PhotoUrl
                    }).ToList()
                })
                .FirstOrDefault(x => x.Id == Id);
            return result;
        }

        public async Task<bool> UpdateHospitalBranch(HospitalBranchUpdateDTO hospitalBranchUpdateDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                var hospitalBranch = context.HospitalBranchs.FirstOrDefault(x => x.Id == hospitalBranchUpdateDTO.Id);

                //if (hospitalBranch == null)
                //{
                //    return false;
                //}

                if (hospitalBranchUpdateDTO.CoverPhoto != null)
                {
                    hospitalBranch.CoverPhoto = await hospitalBranchUpdateDTO.CoverPhoto.SaveFileAsync(webRootPath);
                }

                /////////////////////////////////////////////////////////////////////// 

                var hospitalBranchLanguages = context.HospitalBranchLanguages.Where(x => x.HospitalBranchId == hospitalBranch.Id).ToList();
                for (int i = 0; i < hospitalBranchLanguages.Count; i++)
                {
                    hospitalBranchLanguages[i].BranchName = hospitalBranchUpdateDTO.BranchName[i];
                    hospitalBranchLanguages[i].Description = hospitalBranchUpdateDTO.Description[i];
                }
                context.HospitalBranchLanguages.UpdateRange(hospitalBranchLanguages);

                ///////////////////////////////////////////////////////////////////////

                if (hospitalBranchUpdateDTO.PhotoUrl != null)
                {
                    var hospitalBranchPhotos = context.HospitalBranchPhotos.Where(x => x.HospitalBranchId == hospitalBranch.Id).ToList();

                    for (int i = 0; i < hospitalBranchPhotos.Count; i++)
                    {
                        hospitalBranchPhotos[i].PhotoUrl = await hospitalBranchUpdateDTO.PhotoUrl[i].SaveFileAsync(webRootPath);
                    }
                    context.HospitalBranchPhotos.UpdateRange(hospitalBranchPhotos);
                }
                

                ///////////////////////////////////////////////////////////////////////

                var hospitalBranchFeatures = context.HospitalBranchFeatures.Include(f => f.HospitalBranchFeatureLanguages).Where(x => x.HospitalBranchId == hospitalBranch.Id).ToList();

                for (int i = 0; i < hospitalBranchFeatures.Count; i++)
                {
                    hospitalBranchFeatures[i].Count = hospitalBranchUpdateDTO.HospitalBranchFeatures[i].Count;
                    if (hospitalBranchUpdateDTO.HospitalBranchFeatures[i].FeaturePhotoUrl != null)
                    {
                        hospitalBranchFeatures[i].PhotoUrl = await hospitalBranchUpdateDTO.HospitalBranchFeatures[i].FeaturePhotoUrl.SaveFileAsync(webRootPath);
                    }
                    for (int j = 0; j < hospitalBranchFeatures[i].HospitalBranchFeatureLanguages.Count; j++)
                    {
                        hospitalBranchFeatures[i].HospitalBranchFeatureLanguages[j].Description = hospitalBranchUpdateDTO.HospitalBranchFeatures[i].FeatureDescription[j];
                    }
                }

                ///////////////////////////////////////////////////////////////////////

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


    }
}
