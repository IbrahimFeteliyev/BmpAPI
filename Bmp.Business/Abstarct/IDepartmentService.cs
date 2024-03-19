using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Entities.DTOs.DepartmentDTOs;

namespace Bmp.Business.Abstarct
{
    public interface IDepartmentService
    {
        Task<IResult> AddDepartmentByLanguageAsync(DepartmentAddDTO departmentAddDTO, string webRootPath);
        Task<IResult> UpdateDepartmentByLanguageAsync(DepartmentUpdateDTO departmentUpdateDTO, string webRootPath);
        IDataResult<DepartmentDetailDTO> GetDepartmentById(int id);
        IDataResult<List<DepartmentListDTO>> GetAllDepartments(string langCode);
        IResult RemoveDepartment(int id);
    }
}
