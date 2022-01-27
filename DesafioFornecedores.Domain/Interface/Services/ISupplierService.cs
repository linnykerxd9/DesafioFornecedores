using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface.Services
{
    public interface ISupplierService
    {
         Task<IEnumerable<Supplier>> ToList();

         Task AddSupplier(Supplier supplier);
    }
}