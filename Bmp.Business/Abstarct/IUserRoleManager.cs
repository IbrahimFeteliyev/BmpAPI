
namespace Bmp.Business.Abstarct
{
    public interface IUserRoleManager
    {
        void AddUserRole(int userId, int roleId);
        void RemoveUserRole(int userId, int roleId);
        void AddDefaultRole(int userId);
    }
}
