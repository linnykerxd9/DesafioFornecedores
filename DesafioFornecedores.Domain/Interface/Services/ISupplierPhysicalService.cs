using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface.Services
{
    public interface ISupplierPhysicalService
    {
        Task<IEnumerable<SupplierPhysical>> ToList();

         Task AddCategory(SupplierPhysical supplierPhysical);
    }
}