using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Marvelist.Entities;

namespace Marvelist.DataAccess.Configurations
{
    public class CreatorConfiguration : EntityTypeConfiguration<Creator>
    {
        public CreatorConfiguration()
        {
            ToTable("Creators");

            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Id).IsRequired();

            Property(c => c.Modified).HasColumnType("datetime2");
        }
    }
}
