using Abp.Authorization;
using OneAppHNI.Authorization.Roles;
using OneAppHNI.Authorization.Users;

namespace OneAppHNI.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
