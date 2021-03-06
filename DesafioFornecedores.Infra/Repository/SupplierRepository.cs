using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Models;
using DesafioFornecedores.Infra.Data;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DesafioFornecedores.Infra.Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ProdForneContext context) : base(context)
        {
        }
         public async Task<ICollection<Phone>> FindPhonesToSupplier(Guid id)
        {
           return await _context.Phones.AsNoTracking().Where(x => x.SupplierId == id).ToListAsync();
        }
         public override async Task<PaginationModel<Supplier>> Pagination(int page, int size,Expression<Func<Supplier, bool>> expression = null)
        {
            IPagedList<Supplier> listPagination;
            if(expression == null){
                listPagination = await _dbSet.Include(x => x.Address)
                                             .Include(x => x.Phone)
                                             .Include(x => x.Email)
                                             .Include(x => x.Product)
                                             .AsNoTracking()
                                             .ToPagedListAsync(page,size);
            }else{
                listPagination = await _dbSet.Include(x => x.Address)
                                             .Include(x => x.Phone)
                                             .Include(x => x.Email)
                                             .Include(x => x.Product)
                                             .Where(expression).AsNoTracking()
                                             .ToPagedListAsync(page,size);
            }

            return new PaginationModel<Supplier>(){
                List = listPagination.ToList(),
                PageIndex = page,
                PageSize = size,
                Query = null,
                TotalResult = listPagination.TotalItemCount
            };
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
        
        public async Task<IEnumerable<Supplier>> ToList()
        {
            return await _dbSet.Include(x => x.Address)
                                .Include(x => x.Phone)
                                .Include(x => x.Email)
                                .Include(x => x.Product)
                                .ThenInclude(x => x.Category)
                                .ToListAsync();
        }
        
         public  async Task<SupplierJuridical> FindJuridical(Expression<Func<SupplierJuridical, bool>> expression)
        {
           return await _context.SupplierJuridical.Include(x => x.Address)
                                             .Include(x => x.Phone)
                                             .Include(x => x.Email)
                                             .Include(x => x.Product)
                                             .Where(expression).FirstOrDefaultAsync();
        }

          public async Task<SupplierPhysical> FindPhysical(Expression<Func<SupplierPhysical, bool>> expression)
        {
           return await _context.SupplierPhysical.Include(x => x.Address)
                                             .Include(x => x.Phone)
                                             .Include(x => x.Email)
                                             .Include(x => x.Product)
                                             .Where(expression).FirstOrDefaultAsync();
        }
        public override async Task<Supplier> Find(Expression<Func<Supplier, bool>> expression)
        {
           return await _dbSet.Include(x => x.Address)
                                .Include(x => x.Phone)
                                .Include(x => x.Email)
                                .Include(x => x.Product).ThenInclude(x => x.Image)
                                .Where(expression).FirstOrDefaultAsync();
        }
    }
}