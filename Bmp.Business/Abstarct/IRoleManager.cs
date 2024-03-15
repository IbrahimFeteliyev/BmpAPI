using Bmp.Core.Entity.Models;
using Bmp.Entities.DTOs;

namespace Bmp.Business.Abstarct
{
    public interface IRoleManager
    {
        void AddRole(AddRoleDTO addRoleDTO);
        void Remove(Role role);
        void Update(Role role);
        List<Role> GetAllRoles();
        Role GetRole(int userId);
        Role GetRoleById(int id);

    }
}
