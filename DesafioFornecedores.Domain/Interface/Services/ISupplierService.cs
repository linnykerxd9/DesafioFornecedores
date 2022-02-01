using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface.Services
{
    public interface ISupplierService
    {
         Task<IEnumerable<Supplier>> ToList();
        Task<Supplier> Find(Expression<Func<Supplier,bool>> expression);
        Task<SupplierJuridical> FindJuridical(Expression<Func<SupplierJuridical,bool>> expression);
        Task<SupplierPhysical> FindPhysical(Expression<Func<SupplierPhysical,bool>> expression);
         Task AddSupplier(SupplierJuridical supplier);
         Task AddSupplier(SupplierPhysical supplier);
         Task UpdateSupplier(SupplierJuridical supplier);
         Task UpdateSupplier(SupplierPhysical supplier);
         
         Task InsertPhone(Phone phone);
         Task RemovePhone(Phone phone);

    }
}