using DevCA.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevCa.Data.Mapping
{
    public class BookGenderMapping : IEntityTypeConfiguration<BookGender>
    {
        public void Configure(EntityTypeBuilder<BookGender> builder)
        {
            builder.HasKey(bg => bg.Id);

            builder.Property(bg => bg.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("BookGender");
        }
    }
}