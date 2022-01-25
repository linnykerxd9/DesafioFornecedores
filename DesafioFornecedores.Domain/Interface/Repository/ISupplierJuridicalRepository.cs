
using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface.Repository
{
    public interface ISupplierJuridicalRepository : IRepository<SupplierJuridical> , ISupplier
    {
        Task<IEnumerable<SupplierJuridical>> ToList();
    }
}