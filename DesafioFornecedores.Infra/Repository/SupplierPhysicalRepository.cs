using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Models;
using DesafioFornecedores.Infra.Data;

namespace DesafioFornecedores.Infra.Repository
{
    public class SupplierPhysicalRepository : Repository<SupplierPhysical>, ISupplierPhysicalRepository
    {
        public SupplierPhysicalRepository(ProdForneContext context) : base(context)
        {
        }

        public async Task InsertPhone(Phone phone)
        {
           await _context.Phones.AddAsync(phone);
        }

        public Task RemovePhone(Phone phone)
        {
           _context.Phones.Remove(phone);
           return Task.CompletedTask;
        }
        public Task UpdatePhone(Phone phone)
        {
            _context.Phones.Update(phone);
           return Task.CompletedTask;
        }

        public Task UpdateAddress(Address address)
        {
            _context.Addresses.Update(address);
           return Task.CompletedTask;
        }

        public Task UpdateEmail(Email email)
        {
             _context.Emails.Update(email);
           return Task.CompletedTask;
        }

        public Task<IEnumerable<SupplierPhysical>> ToList()
        {
            throw new System.NotImplementedException();
        }
    }
}