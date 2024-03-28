using Bmp.Core.DataAccess.EntityFramework;
using Bmp.Core.Helper;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.DoctorDTOs;
using Microsoft.EntityFrameworkCore;

namespace Bmp.DataAccess.Concrete.EntityFramework
{
    public class EFDoctorDAL : EfEntityRepositoryBase<Doctor, AppDbContext>, IDoctorDAL
    {
        public async Task<bool> AddDoctor(DoctorAddDTO doctorAddDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                Doctor doctor = new()
                {
                    ContactNumber = doctorAddDTO.ContactNumber,
                    PhotoUrl = await doctorAddDTO.PhotoUrl.SaveFileAsync(webRootPath),
                    DepartmentId = doctorAddDTO.DepartmentId,
                    HospitalBranchId = doctorAddDTO.HospitalBranchId,
                };

                await context.Doctors.AddAsync(doctor);
                await context.SaveChangesAsync();

                for (int i = 0; i < doctorAddDTO.DoctorName.Count; i++)
                {
                    DoctorLanguage doctorLanguage = new()
                    {
                        DoctorId = doctor.Id,
                        DoctorName = doctorAddDTO.DoctorName[i],
                        DoctorSurname = doctorAddDTO.DoctorSurname[i],
                        LangCode = doctorAddDTO.LangCode[i],
                        Specialty = doctorAddDTO.Specialty[i]
                    };
                    doctor.DoctorLanguages.Add(doctorLanguage);
                }

                for (int i = 0; i < doctorAddDTO.DoctorEducations.Count; i++)
                {
                    DoctorEducation doctorEducation = new()
                    {
                        DoctorId = doctor.Id,
                    };
                    await context.DoctorEducations.AddAsync(doctorEducation);

                    for (int j = 0; j < doctorAddDTO.DoctorEducations[i].EducationText.Count; j++)
                    {
                        DoctorEducationLanguage doctorEducationLanguage = new()
                        {
                            DoctorEducationId = doctorEducation.Id,
                            EducationText = doctorAddDTO.DoctorEducations[i].EducationText[j],
                            LangCode = doctorAddDTO.LangCode[j]
                        };
                        doctorEducation.DoctorEducationLanguages.Add(doctorEducationLanguage);
                    }
                }

                for (int i = 0; i < doctorAddDTO.DoctorWorkExperiences.Count; i++)
                {
                    DoctorWorkExperience doctorWorkExperience = new()
                    {
                        DoctorId = doctor.Id,
                    };
                    await context.DoctorWorkExperiences.AddAsync(doctorWorkExperience);

                    for (int j = 0; j < doctorAddDTO.DoctorWorkExperiences[i].WorkExperienceText.Count; j++)
                    {
                        DoctorWorkExperienceLanguage doctorWorkExperienceLanguage = new()
                        {
                            DoctorWorkExperienceId = doctorWorkExperience.Id,
                            WorkExperienceText = doctorAddDTO.DoctorWorkExperiences[i].WorkExperienceText[j],
                            LangCode = doctorAddDTO.LangCode[j]
                        };
                        doctorWorkExperience.DoctorWorkExperienceLanguages.Add(doctorWorkExperienceLanguage);
                    }
                }

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<DoctorListDTO> GetAllDoctorList(string langCode)
        {
            using var context = new AppDbContext();

            var result = context.Doctors.Select(x => new DoctorListDTO
            {
                Id = x.Id,
                ContactNumber = x.ContactNumber,
                PhotoUrl = x.PhotoUrl,
                DoctorName = x.DoctorLanguages.FirstOrDefault(x => x.LangCode == langCode).DoctorName,
                DoctorSurname = x.DoctorLanguages.FirstOrDefault(x => x.LangCode == langCode).DoctorSurname,
                Specialty = x.DoctorLanguages.FirstOrDefault(x => x.LangCode == langCode).Specialty,
                DepartmentName = context.Departments.FirstOrDefault(h => h.Id == x.DepartmentId).DepartmentLanguages.FirstOrDefault(l => l.LangCode == langCode).DepartmentName,
                HospitalBranchName = context.HospitalBranchs.FirstOrDefault(h => h.Id == x.HospitalBranchId).HospitalBranchLanguages.FirstOrDefault(l => l.LangCode == langCode).BranchName,
                DoctorEducations = x.DoctorEducations.Select(e => new DoctorEducationListDTO
                {
                    EducationText = e.DoctorEducationLanguages
                                    .Where(l => l.LangCode == langCode)
                                    .Select(l => l.EducationText)
                                    .ToList()
                }).ToList(),
                DoctorWorkExperiences = x.DoctorWorkExperiences.Select(w => new DoctorWorkExperienceListDTO
                {
                    WorkExperienceText = w.DoctorWorkExperienceLanguages
                                         .Where(l => l.LangCode == langCode)
                                         .Select(l => l.WorkExperienceText)
                                         .ToList()
                }).ToList(),
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate
            }).ToList();

            return result;
        }

        public DoctorDetailDTO GetDoctorByIdAdmin(int Id)
        {
            using var context = new AppDbContext();

            var result = context.Doctors
                .Include(x => x.DoctorLanguages)
                .Include(x => x.DoctorEducations)
                .Include(x => x.DoctorWorkExperiences)
                .Include(x => x.Department) 
                .Include(x => x.HospitalBranch)
                .Select(x => new DoctorDetailDTO()
                {
                    Id = x.Id,
                    PhotoUrl = x.PhotoUrl,
                    ContactNumber = x.ContactNumber,

                    DepartmentId = x.Department.Id,
                    HospitalBranchId = x.HospitalBranch.Id,

                    UpdatedDate = x.UpdatedDate,
                    CreatedDate = x.CreatedDate,

                    DoctorName = x.DoctorLanguages.Select(x => x.DoctorName).ToList(),
                    DoctorSurname = x.DoctorLanguages.Select(x => x.DoctorSurname).ToList(),
                    Specialty = x.DoctorLanguages.Select(x => x.Specialty).ToList(),

                    DoctorEducations = x.DoctorEducations.Select(f => new DoctorEducationListDTO
                    {
                        EducationText = f.DoctorEducationLanguages.Select(l => l.EducationText).ToList(),
                    }).ToList(),
                    DoctorWorkExperiences = x.DoctorWorkExperiences.Select(f => new DoctorWorkExperienceListDTO
                    {
                        WorkExperienceText = f.DoctorWorkExperienceLanguages.Select(l => l.WorkExperienceText).ToList(),
                    }).ToList()
                })
                .FirstOrDefault(x => x.Id == Id);
            return result;
        }

        public DoctorDetailLangDTO GetDoctorLangById(int Id, string langCode)
        {
            using var context = new AppDbContext();

            var result = context.Doctors
                .Include(x => x.DoctorLanguages)
                .Include(x => x.DoctorEducations)
                .Include(x => x.DoctorWorkExperiences)
                .Include(x => x.Department)
                .Include(x => x.HospitalBranch)
                .Select(x => new DoctorDetailLangDTO()
                {
                    Id = x.Id,
                    PhotoUrl = x.PhotoUrl,
                    ContactNumber = x.ContactNumber,

                    DepartmentName = x.Department.DepartmentLanguages.FirstOrDefault(dl => dl.LangCode == "az-AZ").DepartmentName,
                    BranchName = x.HospitalBranch.HospitalBranchLanguages.FirstOrDefault(hbl => hbl.LangCode == "az-AZ").BranchName,

                    UpdatedDate = x.UpdatedDate,
                    CreatedDate = x.CreatedDate,

                    DoctorName = x.DoctorLanguages.Where(hbl => hbl.LangCode == langCode)
                        .Select(hbl => hbl.DoctorName)
                        .FirstOrDefault(),
                    DoctorSurname = x.DoctorLanguages.Where(hbl => hbl.LangCode == langCode)
                        .Select(hbl => hbl.DoctorSurname)
                        .FirstOrDefault(),
                    Specialty = x.DoctorLanguages.Where(hbl => hbl.LangCode == langCode)
                        .Select(hbl => hbl.Specialty)
                        .FirstOrDefault(),

                    DoctorEducations = x.DoctorEducations.Select(f => new DoctorEducationLangDTO
                    {
                        EducationText = f.DoctorEducationLanguages.Where(hbfl => hbfl.LangCode == langCode)
                            .Select(hbfl => hbfl.EducationText)
                            .FirstOrDefault(),
                    }).ToList(),
                    DoctorWorkExperiences = x.DoctorWorkExperiences.Select(f => new DoctorWorkExperienceLangDTO
                    {
                        WorkExperienceText = f.DoctorWorkExperienceLanguages.Where(hbfl => hbfl.LangCode == langCode)
                            .Select(hbfl => hbfl.WorkExperienceText)
                            .FirstOrDefault(),
                    }).ToList()
                })
                .FirstOrDefault(x => x.Id == Id);
            return result;
        }

        public async Task<bool> UpdateDoctor(DoctorUpdateDTO doctorUpdateDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                var doctor = context.Doctors.FirstOrDefault(x => x.Id == doctorUpdateDTO.Id);

                doctor.ContactNumber = doctorUpdateDTO.ContactNumber;
                doctor.DepartmentId = doctorUpdateDTO.DepartmentId;
                doctor.HospitalBranchId = doctorUpdateDTO.HospitalBranchId;


                if (doctorUpdateDTO.PhotoUrl != null)
                {
                    doctor.PhotoUrl = await doctorUpdateDTO.PhotoUrl.SaveFileAsync(webRootPath);
                }


                var doctorLanguages = context.DoctorLanguages.Where(x => x.DoctorId == doctor.Id).ToList();
                for (int i = 0; i < doctorLanguages.Count; i++)
                {
                    doctorLanguages[i].DoctorName = doctorUpdateDTO.DoctorName[i];
                    doctorLanguages[i].DoctorSurname = doctorUpdateDTO.DoctorSurname[i];
                    doctorLanguages[i].Specialty = doctorUpdateDTO.Specialty[i];
                }
                context.DoctorLanguages.UpdateRange(doctorLanguages);


                var doctorEducations = context.DoctorEducations.Include(f => f.DoctorEducationLanguages).Where(x => x.DoctorId == doctor.Id).ToList();

                for (int i = 0; i < doctorEducations.Count; i++)
                {
                    for (int j = 0; j < doctorEducations[i].DoctorEducationLanguages.Count; j++)
                    {
                        doctorEducations[i].DoctorEducationLanguages[j].EducationText = doctorUpdateDTO.DoctorEducations[i].EducationText[j];
                    }
                }

                var doctorWorkExperiences = context.DoctorWorkExperiences.Include(f => f.DoctorWorkExperienceLanguages).Where(x => x.DoctorId == doctor.Id).ToList();

                for (int i = 0; i < doctorWorkExperiences.Count; i++)
                {
                    for (int j = 0; j < doctorWorkExperiences[i].DoctorWorkExperienceLanguages.Count; j++)
                    {
                        doctorWorkExperiences[i].DoctorWorkExperienceLanguages[j].WorkExperienceText = doctorUpdateDTO.DoctorWorkExperiences[i].WorkExperienceText[j];
                    }
                }


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
