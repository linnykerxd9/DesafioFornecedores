using DesafioFornecedores.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DesafioFornecedores.Infra.Mapping
{
    public class ImageMapping : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ProductId.ToString()).WithOne().HasForeignKey<Product>(x => x.Id);

            builder.Property(x => x.ImagePath)
                   .IsRequired();


            builder.ToTable("TB_Image");
        }
    }
}