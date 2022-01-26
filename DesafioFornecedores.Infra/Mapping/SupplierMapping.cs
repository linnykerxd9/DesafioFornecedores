using DesafioFornecedores.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFornecedores.Infra.Mapping
{
    public class SupplierMapping : IEntityTypeConfiguration<Supplier>
    {
         public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(k => k.Id);


            builder.Property(x => x.FantasyName)
                   .IsRequired();

            builder.Property(x => x.Active)
                   .IsRequired();

            builder.ToTable("TB_Supplier");
        }
    }
}