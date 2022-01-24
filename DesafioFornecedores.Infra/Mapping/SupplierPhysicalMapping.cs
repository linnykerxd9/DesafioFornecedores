using DesafioFornecedores.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFornecedores.Infra.Mapping
{
    public class SupplierPhysicalMapping : IEntityTypeConfiguration<SupplierJuridical>
    {
        public void Configure(EntityTypeBuilder<SupplierJuridical> builder)
        {
             builder.HasKey(k => k.Id);



            builder.ToTable("TB_SupplierPhysical");
        }
    }
}