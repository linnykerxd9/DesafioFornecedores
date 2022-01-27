using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface.Repository
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<IEnumerable<Supplier>> ToList();
        Task UpdateEmail(Email email);

        Task UpdateAddress(Address address);

        Task InsertPhone(Phone phone);
        Task RemovePhone(Phone phone);
        Task UpdatePhone(Phone phone);

    }
}