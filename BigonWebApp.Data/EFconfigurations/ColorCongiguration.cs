using BigonWebApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BigonWebApp.Data.EFconfigurations
{
    public class ColorCongiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ColorName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.HaxCode).HasMaxLength(10).IsRequired();
        }
    }
}
