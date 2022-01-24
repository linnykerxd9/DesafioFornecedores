using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface
{
    public interface ISupplier
    {
        Task UpdateEmail(Email email);

        Task UpdateAddress(Address address);

        Task InsertPhone(Phone phone);
        Task RemovePhone(Phone phone);
        Task UpdatePhone(Phone phone);

    }
}