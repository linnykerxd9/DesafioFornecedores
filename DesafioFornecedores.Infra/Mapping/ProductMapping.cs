using DesafioFornecedores.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFornecedores.Infra.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(x => x.CategoryId.ToString()).WithOne().HasForeignKey<Category>(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired();

            builder.Property(x => x.BarCode)
                   .IsRequired();

            builder.Property(x => x.QuantityStock)
                   .IsRequired();

            builder.Property(x => x.PriceSales)
                   .IsRequired();

            builder.Property(x => x.PricePurchase)
                   .IsRequired();        

            builder.Property(x => x.Active)
                   .IsRequired();
            builder.ToTable("TB_Product");
        }
    }
}