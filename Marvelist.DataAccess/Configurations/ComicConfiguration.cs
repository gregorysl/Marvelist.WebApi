using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Marvelist.Entities;

namespace Marvelist.DataAccess.Configurations
{
    public class ComicConfiguration : EntityTypeConfiguration<Comic>
    {
        public ComicConfiguration()
        {
            ToTable("Comics");

            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(c => c.Id).IsRequired();

            Property(c => c.Modified).HasColumnType("datetime2");
            Property(c => c.Date).HasColumnType("datetime2");

            //HasRequired(e => e.Series).WithMany(x=>x.Comics).Map(s => s.MapKey("SeriesId"));
        }
    }
}
