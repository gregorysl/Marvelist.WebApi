using System.Data.Entity.ModelConfiguration;
using Marvelist.Entities;

namespace Marvelist.DataAccess.Configurations
{
    public class UserSeriesConfiguration : EntityTypeConfiguration<UserSeries>
    {
        public UserSeriesConfiguration()
        {
            ToTable("UserSeries");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            Property(c => c.Date).HasColumnType("datetime2");

            //HasRequired(e => e.Series).WithMany(x=>x.UserSeries).Map(s => s.MapKey("SeriesId")).WillCascadeOnDelete(false);
            //HasRequired(e => e.User).WithMany(x=>x.Series).Map(s => s.MapKey("UserId")).WillCascadeOnDelete(false);
        }
    }
}
