using DevCA.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevCa.Data.Mapping
{
    public class ReserveMapping : IEntityTypeConfiguration<Reserve>
    {
        public void Configure(EntityTypeBuilder<Reserve> builder)
        {
            builder.HasKey(r => r.Id);

            builder.ToTable("Reserve");
        }
    }
}