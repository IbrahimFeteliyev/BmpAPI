using Bmp.Business.Abstarct;
using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Core.Utilities.Results.Concrete.ErrorResults;
using Bmp.Core.Utilities.Results.Concrete.SuccessResults;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.DTOs.DepartmentDTOs;


namespace Bmp.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDAL _departmentDAL;

        public DepartmentManager(IDepartmentDAL departmentDAL)
        {
            _departmentDAL = departmentDAL;
        }

        public async Task<IResult> AddDepartmentByLanguageAsync(DepartmentAddDTO departmentAddDTO, string webRootPath)
        {
            var result = await _departmentDAL.AddDepartment(departmentAddDTO, webRootPath);
            if (result)
            {
                return new SuccessResult("Department created successfully");
            }
            else
            {
                return new ErrorResult();
            }
        }
        public IDataResult<List<DepartmentListDTO>> GetAllDepartments(string langCode)
        {
            try
            {
                var result = _departmentDAL.GetAllDepartmentList(langCode);
                return new SuccessDataResult<List<DepartmentListDTO>>(result, "Listed");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<DepartmentListDTO>>(ex.Message);
            }
        }

        public IDataResult<DepartmentDetailDTO> GetDepartmentById(int id)
        {
            var result = _departmentDAL.GetDepartmentByIdAdmin(id);
            return new SuccessDataResult<DepartmentDetailDTO>(result);
        }
        public IResult RemoveDepartment(int id)
        {
            var department = _departmentDAL.Get(x => x.Id == id);
            _departmentDAL.Delete(department);
            return new SuccessResult("Deleted Successfully");
        }

        public async Task<IResult> UpdateDepartmentByLanguageAsync(DepartmentUpdateDTO departmentUpdateDTO, string webRootPath)
        {
            var result = await _departmentDAL.UpdateDepartment(departmentUpdateDTO, webRootPath);
            if (result)
            {
                return new SuccessResult("Department updated successfully");
            }
            else
            {
                return new ErrorResult();
            }
        }
    }
}
