using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Marvelist.DataAccess.Configurations
{
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {

            ToTable("UserRoles");
            HasKey(role => new { role.RoleId, role.UserId });
        }
    }

}
