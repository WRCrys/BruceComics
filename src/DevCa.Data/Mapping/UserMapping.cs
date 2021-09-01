using DevCA.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevCa.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(u => u.Password)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasMany(u => u.Books)
                .WithOne(b => b.UserCreation)
                .HasForeignKey(b => b.UserCreationId);

            builder.HasMany(u => u.Reserves)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            builder.ToTable("User");
        }
    }
}