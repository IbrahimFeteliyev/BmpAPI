﻿using Bmp.Business.Abstarct;
using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Core.Utilities.Results.Concrete.ErrorResults;
using Bmp.Core.Utilities.Results.Concrete.SuccessResults;
using Bmp.DataAccess.Abstarct;
using Bmp.DataAccess.Concrete.EntityFramework;
using Bmp.Entities.DTOs.DoctorDTOs;
using Bmp.Entities.DTOs.HospitalBranchDTOs;

namespace Bmp.Business.Concrete
{
    public class DoctorManager : IDoctorService
    {
        private readonly IDoctorDAL _doctorDAL;

        public DoctorManager(IDoctorDAL doctorDAL)
        {
            _doctorDAL = doctorDAL;
        }

        public async Task<IResult> AddDoctorByLanguageAsync(DoctorAddDTO doctorAddDTO, string webRootPath)
        {
            var result = await _doctorDAL.AddDoctor(doctorAddDTO, webRootPath);
            if (result)
            {
                return new SuccessResult("Doctor created successfully");
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IDataResult<List<DoctorListDTO>> GetAllDoctors(string langCode)
        {
            try
            {
                var result = _doctorDAL.GetAllDoctorList(langCode);
                return new SuccessDataResult<List<DoctorListDTO>>(result, "Listed");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<DoctorListDTO>>(ex.Message);
            }
        }

        public IResult RemoveDoctor(int id)
        {
            var doctor = _doctorDAL.Get(x => x.Id == id);
            _doctorDAL.Delete(doctor);
            return new SuccessResult("Deleted Successfully");
        }
    }
}
