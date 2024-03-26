using Bmp.Core.DataAccess;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.HospitalBranchDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.DataAccess.Abstarct
{
    public interface IHospitalBranchDAL : IEntityRepository<HospitalBranch>
    {
        Task<bool> AddHospitalBranch(HospitalBranchAddDTO hospitalBranchAddDTO, string webRootPath);
        Task<bool> UpdateHospitalBranch(HospitalBranchUpdateDTO hospitalBranchUpdateDTO, string webRootPath);
        HospitalBranchDetailDTO GetHospitalBranchByIdAdmin(int Id);
        HospitalBranchDetailDTO GetHospitalBranchLangById(int Id, string langCode);
        List<HospitalBranchListDTO> GetAllHospitalBranchList(string langCode);
    }
}
