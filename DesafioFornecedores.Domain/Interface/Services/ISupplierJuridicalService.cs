using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface.Services
{
    public interface ISupplierJuridicalService
    {
        Task<IEnumerable<SupplierJuridical>> ToList();

        Task AddCategory(SupplierJuridical supplierJuridical);
    }
}