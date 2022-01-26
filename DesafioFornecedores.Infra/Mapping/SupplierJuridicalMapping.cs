using DesafioFornecedores.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFornecedores.Infra.Mapping
{
    public class SupplierJuridicalMapping : IEntityTypeConfiguration<SupplierJuridical>
    {
        public void Configure(EntityTypeBuilder<SupplierJuridical> builder)
        {

            builder.Property(x => x.CompanyName)
                   .IsRequired();

            builder.Property(x => x.Cnpj)
                   .IsRequired()
                   .HasColumnType("varchar(14)");

        }
    }
}