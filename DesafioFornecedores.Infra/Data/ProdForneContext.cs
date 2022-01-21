using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioFornecedores.Infra.Data
{
    public class ProdForneContext : DbContext
    {
        public ProdForneContext(DbContextOptions<ProdForneContext> options) : base(options)
        {
        }

        public DbSet<Product> Products {get; set;}

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
                                                  CancellationToken cancellationToken = default)
        {
            foreach (var entity in ChangeTracker.Entries().Where(entity => entity.Entity.GetType().GetProperty("InsertDate") != null ||
                                                                         entity.Entity.GetType().GetProperty("UpdateDate") != null))
            {
                if(entity.State == EntityState.Added)
                {
                   entity.Property("InsertDate").CurrentValue = DateTime.Now;
                   entity.Property("UpdateDate").IsModified = false;
                }
                else if(entity.State == EntityState.Modified)
                {
                    entity.Property("UpdateDate").CurrentValue = DateTime.Now;
                    entity.Property("InsertDate").IsModified = false;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(256)");
            }
             foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}