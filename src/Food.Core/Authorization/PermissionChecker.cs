using Abp.Authorization;
using Food.Authorization.Roles;
using Food.Authorization.Users;

namespace Food.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
