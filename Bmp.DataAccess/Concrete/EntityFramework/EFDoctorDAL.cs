using Bmp.Core.DataAccess.EntityFramework;
using Bmp.Core.Helper;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.DoctorDTOs;

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

    }
}
