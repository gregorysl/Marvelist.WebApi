using System.Data.Entity.ModelConfiguration;
using Marvelist.Entities;

namespace Marvelist.DataAccess.Configurations
{
    internal class UserConfgiuration : EntityTypeConfiguration<ApplicationUser>
    {
        internal UserConfgiuration()
        {
            ToTable("Users");
            Ignore(x => x.PhoneNumber);
            Ignore(x => x.PhoneNumberConfirmed);
            Property(c => c.Email).IsRequired();
            

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.SecurityStamp)
                .HasColumnName("SecurityStamp")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.UserName).HasColumnName("UserName").HasColumnType("nvarchar").HasMaxLength(256).IsRequired();
            
        }
    }
}