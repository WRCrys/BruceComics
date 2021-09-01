using DevCA.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevCa.Data.Mapping
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(b => b.Synopsis)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.HasMany(b => b.BookGenders)
                .WithOne(bg => bg.Book)
                .HasForeignKey(bg => bg.BookId);

            builder.HasMany(b => b.Reserves)
                .WithOne(r => r.Book)
                .HasForeignKey(r => r.BookId);

            builder.ToTable("Book");
        }
    }
}