using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Marvelist.Entities;

namespace Marvelist.DataAccess.Configurations
{
    public class SeriesConfiguration : EntityTypeConfiguration<Series>
    {
        public SeriesConfiguration()
        {
            ToTable("Series");

            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(c => c.Id).IsRequired();
            
            Property(c => c.Modified).HasColumnType("datetime2");
        }
    }
}
