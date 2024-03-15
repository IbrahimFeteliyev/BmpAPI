using Bmp.Business.Abstarct;
using Bmp.Core.Entity.Models;
using Bmp.DataAccess.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Business.Concrete
{
    public class UserRoleManager : IUserRoleManager
    {
        private readonly IUserRoleDal _userRoleDal;

        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }

        public void AddDefaultRole(int userId)
        {
            UserRole userRole = new UserRole()
            {
                RoleId = 2,
                UserId = userId
            };
            _userRoleDal.Add(userRole);
        }
        public void AddUserRole(int userId, int roleId)
        {
            UserRole userRole = new UserRole()
            {
                RoleId = roleId,
                UserId = userId
            };
            _userRoleDal.Add(userRole);
        }



        public void RemoveUserRole(int userId, int roleId)
        {
            var userRole = _userRoleDal.Get(ur => ur.UserId == userId && ur.RoleId == roleId);
            if (userRole != null)
            {
                _userRoleDal.Delete(userRole);
            }
        }
    }
}
