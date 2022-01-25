using DesafioFornecedores.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFornecedores.Infra.Mapping
{
    public class SupplierPhysicalMapping : IEntityTypeConfiguration<SupplierPhysical>
    {
        public void Configure(EntityTypeBuilder<SupplierPhysical> builder)
        {
             builder.HasKey(k => k.Id);

            builder.Property(x => x.FullName)
                   .IsRequired();

            builder.Property(x => x.FantasyName)
                   .IsRequired();

            builder.Property(x => x.Cpf)
                   .IsRequired()
                   .HasColumnType("varchar(11)");

            builder.Property(x => x.BirthDate)
                   .IsRequired();

            builder.ToTable("TB_SupplierPhysical");
        }
    }
}