using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface.Services
{
    public interface ISupplierService
    {
         Task<IEnumerable<Supplier>> ToList();
        Task<Supplier> Find();
         Task AddSupplier(SupplierJuridical supplier);
         Task AddSupplier(SupplierPhysical supplier);
    }
}