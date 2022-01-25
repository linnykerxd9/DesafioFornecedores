using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface.Repository
{
    public interface ISupplierPhysicalRepository : IRepository<SupplierPhysical>, ISupplier
    {
        Task<IEnumerable<SupplierPhysical>> ToList();
    }
}