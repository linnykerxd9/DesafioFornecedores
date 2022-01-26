using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Models;
using DesafioFornecedores.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace DesafioFornecedores.Infra.Repository
{
    public class SupplierJuridicalRepository : Repository<SupplierJuridical>, ISupplierJuridicalRepository
    {
        public SupplierJuridicalRepository(ProdForneContext context) : base(context)
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

        public async Task<IEnumerable<SupplierJuridical>> ToList()
        {
            return await _dbSet.Include("Emails").Include("Addresses").Include("Phones").ToListAsync();
        }
    }
}