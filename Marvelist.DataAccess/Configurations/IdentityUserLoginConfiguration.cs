using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Marvelist.DataAccess.Configurations
{
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            ToTable("UserLogins");
            HasKey(login => new { login.UserId, login.LoginProvider, login.ProviderKey });
        }
    }

}
