using DesafioFornecedores.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFornecedores.Infra.Mapping
{
    public class PhoneMapping : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(k => k.Id);
            
            builder.Property(x => x.Ddd)
                   .IsRequired()
                   .HasColumnType("varchar(3)");

            builder.Property(x => x.Number)
                   .IsRequired()
                   .HasColumnType("varchar(9)");

            builder.ToTable("TB_Phone");
        }
    }
}