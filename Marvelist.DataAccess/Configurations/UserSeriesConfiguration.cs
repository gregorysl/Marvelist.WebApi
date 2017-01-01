using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
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
            Property(t => t.SeriesId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_SeriesUser", 1) { IsUnique = true }));
            Property(t => t.UserId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_SeriesUser", 2) { IsUnique = true }));
            
        }
    }
}
