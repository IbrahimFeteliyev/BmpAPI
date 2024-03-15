using Bmp.Business.Abstarct;
using Bmp.Core.Entity.Models;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.DTOs;

namespace Bmp.Business.Concrete
{
    public class RoleManager : IRoleManager
    {
        private readonly IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public void AddRole(AddRoleDTO addRoleDTO)
        {
            Role role = new()
            {
                Name = addRoleDTO.Name,
            };

            _roleDal.Add(role);
        }

        public List<Role> GetAllRoles()
        {
            return _roleDal.GetAll();
        }

        public Role GetRoleById(int id)
        {
            return _roleDal.Get(x => x.Id == id);
        }
        public Role GetRole(int userId)
        {
            return _roleDal.GetUserRole(userId);
        }
        public void Remove(Role role)
        {
            _roleDal.Delete(role);
        }

        public void Update(Role role)
        {
            _roleDal.Update(role);
        }
    }
}
