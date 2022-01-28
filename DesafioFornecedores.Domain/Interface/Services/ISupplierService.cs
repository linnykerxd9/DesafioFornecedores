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
         Task AddSupplier(SupplierJuridical supplier);
         Task AddSupplier(SupplierPhysical supplier);
    }
}