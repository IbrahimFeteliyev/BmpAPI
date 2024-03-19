using Bmp.Core.DataAccess;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.DepartmentDTOs;

namespace Bmp.DataAccess.Abstarct
{
    public interface IDepartmentDAL : IEntityRepository<Department>
    {
        Task<bool> AddDepartment(DepartmentAddDTO departmentAddDTO, string webRootPath);
        Task<bool> UpdateDepartment(DepartmentUpdateDTO departmentUpdateDTO, string webRootPath);
        DepartmentDetailDTO GetDepartmentByIdAdmin(int Id);
        List<DepartmentListDTO> GetAllDepartmentList(string langCode);
    }
}
