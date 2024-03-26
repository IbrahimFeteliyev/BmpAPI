using Bmp.Core.DataAccess.EntityFramework;
using Bmp.Core.Helper;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.DepartmentDTOs;
using Bmp.Entities.DTOs.HospitalBranchDTOs;
using Microsoft.EntityFrameworkCore;

namespace Bmp.DataAccess.Concrete.EntityFramework
{
    public class EFDepartmentDAL : EfEntityRepositoryBase<Department, AppDbContext>, IDepartmentDAL
    {
        public async Task<bool> AddDepartment(DepartmentAddDTO departmentAddDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                Department Department = new()
                {
                    IconUrl = await departmentAddDTO.IconUrl.SaveFileAsync(webRootPath),
                    PhotoUrl = await departmentAddDTO.PhotoUrl.SaveFileAsync(webRootPath)
                };


                for (int i = 0; i < departmentAddDTO.DepartmentName.Count; i++)
                {
                    DepartmentLanguage DepartmentLanguage = new()
                    {
                        DepartmentId = Department.Id,
                        DepartmentName = departmentAddDTO.DepartmentName[i],
                        LangCode = departmentAddDTO.LangCode[i]
                    };

                    Department.DepartmentLanguages.Add(DepartmentLanguage);
                }

                for (int i = 0; i < departmentAddDTO.DepartmentFeatures.Count; i++)
                {
                    DepartmentFeature DepartmentFeature = new()
                    {
                        DepartmentId = Department.Id,
                    };
                    await context.DepartmentFeatures.AddAsync(DepartmentFeature);

                    for (int j = 0; j < departmentAddDTO.DepartmentFeatures[i].DepartmentFeatureText.Count; j++)
                    {
                        DepartmentFeatureLanguage DepartmentFeatureLanguage = new()
                        {
                            DepartmentFeatureId = DepartmentFeature.Id,
                            DepartmentFeatureText = departmentAddDTO.DepartmentFeatures[i].DepartmentFeatureText[j],
                            LangCode = departmentAddDTO.LangCode[j]
                        };
                        DepartmentFeature.DepartmentFeatureLanguages.Add(DepartmentFeatureLanguage);
                    }

                    Department.DepartmentFeatures.Add(DepartmentFeature);
                }

                await context.Departments.AddAsync(Department);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<DepartmentListDTO> GetAllDepartmentList(string langCode)
        {
            using var context = new AppDbContext();

            var result = context.Departments.Select(x => new DepartmentListDTO
            {
                Id = x.Id,
                DepartmentName = x.DepartmentLanguages.FirstOrDefault(x => x.LangCode == langCode).DepartmentName,
                PhotoUrl = x.PhotoUrl,
                IconUrl = x.IconUrl,
                Features = x.DepartmentFeatures.Select(f => new DepartmentFeatureListDTO
                {
                    DepartmentFeatureText = f.DepartmentFeatureLanguages.Where(l => l.LangCode == langCode).Select(l => l.DepartmentFeatureText).ToList()
                }).ToList()
            }).ToList();

            return result;
        }

        public DepartmentDetailDTO GetDepartmentByIdAdmin(int Id)
        {
            using var context = new AppDbContext();

            var result = context.Departments
                .Include(x => x.DepartmentLanguages)
                .Include(x => x.DepartmentFeatures)
                .Select(x => new DepartmentDetailDTO()
                {
                    Id = x.Id,
                    IconUrl = x.IconUrl,
                    PhotoUrl = x.PhotoUrl,
                    UpdatedDate = x.UpdatedDate,
                    CreatedDate = x.CreatedDate,
                    DepartmentName = x.DepartmentLanguages.Select(x => x.DepartmentName).ToList(),
                    Features = x.DepartmentFeatures.Select(f => new DepartmentFeatureListDTO
                    {
                        DepartmentFeatureText = f.DepartmentFeatureLanguages.Select(l => l.DepartmentFeatureText).ToList(),
                    }).ToList()
                })
                .FirstOrDefault(x => x.Id == Id);
            return result;
        }

        public async Task<bool> UpdateDepartment(DepartmentUpdateDTO departmentUpdateDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                var department = context.Departments.FirstOrDefault(x => x.Id == departmentUpdateDTO.Id);

                if (department == null)
                {
                    return false;
                }

                if (departmentUpdateDTO.PhotoUrl != null)
                {
                    department.PhotoUrl = await departmentUpdateDTO.PhotoUrl.SaveFileAsync(webRootPath);
                }

                if (departmentUpdateDTO.IconUrl != null)
                {
                    department.IconUrl = await departmentUpdateDTO.IconUrl.SaveFileAsync(webRootPath);
                }
                

                /////////////////////////////////////////////////////////////////////// 

                var departmentLanguages = context.DepartmentLanguages.Where(x => x.DepartmentId == department.Id).ToList();

                for (int i = 0; i < departmentLanguages.Count; i++)
                {
                    departmentLanguages[i].DepartmentName = departmentUpdateDTO.DepartmentName[i];
                }
                context.DepartmentLanguages.UpdateRange(departmentLanguages);

                ///////////////////////////////////////////////////////////////////////

                var departmentFeatures = context.DepartmentFeatures.Include(f => f.DepartmentFeatureLanguages).Where(x => x.DepartmentId == department.Id).ToList();

                for (int i = 0; i < departmentFeatures.Count; i++)
                {
                    for (int j = 0; j < departmentFeatures[i].DepartmentFeatureLanguages.Count; j++)
                    {
                        departmentFeatures[i].DepartmentFeatureLanguages[j].DepartmentFeatureText = departmentUpdateDTO.DepartmentFeatures[i].DepartmentFeatureText[j];
                    }
                }

                ///////////////////////////////////////////////////////////////////////

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
