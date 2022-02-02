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
        Task<PaginationModel<Supplier>> Pagination(int page, int size, string query);
        Task<Supplier> Find(Expression<Func<Supplier,bool>> expression);
        Task<SupplierJuridical> FindJuridical(Expression<Func<SupplierJuridical,bool>> expression);
        Task<SupplierPhysical> FindPhysical(Expression<Func<SupplierPhysical,bool>> expression);
         Task AddSupplier(SupplierJuridical supplier);
         Task AddSupplier(SupplierPhysical supplier);
         Task UpdateSupplier(SupplierJuridical supplier);
         Task UpdateSupplier(SupplierPhysical supplier);
         Task RemoveSupplier(Supplier supplier);
         
         Task InsertPhone(Phone phone);
         Task RemovePhone(Phone phone);

    }
}