using DesafioFornecedores.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFornecedores.Infra.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Active)
                   .IsRequired();

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasColumnType("varchar(100)");


            builder.ToTable("TB_Category");
        }
    }
}