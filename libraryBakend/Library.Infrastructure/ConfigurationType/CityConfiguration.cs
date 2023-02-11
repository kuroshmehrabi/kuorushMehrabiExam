using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Library.Data;

namespace Library.Infrastructure.Entities
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");

            builder.HasKey(e => e.CityId).HasName("PK__City__3214EC07F8E418B9");

            builder.Property(e => e.CityName).HasMaxLength(150);


            builder.HasOne(d => d.Province).WithMany(p => p.Citys).HasForeignKey(d => d.ProvinceId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Province_Book_FK");
        }
    }
}
