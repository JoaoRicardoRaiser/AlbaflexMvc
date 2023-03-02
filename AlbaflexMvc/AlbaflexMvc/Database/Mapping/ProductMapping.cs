using AlbaflexMvc.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlbaflexMvc.Database.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");
            builder.HasKey(x => x.Code);
            builder.HasIndex(x => x.Code);
            builder.Property(x => x.Code).HasColumnName("code").IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").IsRequired();
            builder.Property(x => x.Value).HasColumnName("value").IsRequired();
            builder.Property(x => x.Type).HasColumnName("type").HasConversion<string>().IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").IsRequired();
        }
    }
}
