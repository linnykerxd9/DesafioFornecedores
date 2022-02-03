using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Interface;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Models;
using DesafioFornecedores.Infra.Data;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DesafioFornecedores.Infra.Repository
{
    public class ProductRepository : Repository<Product>, IProductsRepository
    {
        public ProductRepository(ProdForneContext context) : base(context)
        {
        }
        public override async Task<Product> Find(Expression<Func<Product, bool>> expression)
        {
           return await _dbSet.Include(x => x.Supplier)
                              .Include(x => x.Category)
                              .Include(x => x.Image)
                              .Where(expression)
                              .FirstOrDefaultAsync();
        }
        public async Task InsertImage(Image image)
        {
            await _context.Images.AddAsync(image);
        }
        public Task RemoveImage(Image image)
        {
            _context.Images.Remove(image);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> ToList()
        {
            return await _dbSet.Include(x => x.Image)
                                .Include(x => x.Category)
                                .Include(x => x.Supplier)
                                .ToListAsync();
        }

         public override async Task<PaginationModel<Product>> Pagination(int page, int size,Expression<Func<Product, bool>> expression = null)
        {
            IPagedList<Product> listPagination;
            if(expression == null){
                listPagination = await _dbSet.Include(x => x.Supplier)
                                             .Include(x => x.Category)
                                             .AsNoTracking()
                                             .ToPagedListAsync(page,size);
            }else{
                listPagination = await _dbSet.Include(x => x.Supplier)
                                             .Include(x => x.Category)
                                             .Where(expression).AsNoTracking()
                                             .ToPagedListAsync(page,size);
            }
             return new PaginationModel<Product>(){
                List = listPagination.ToList(),
                PageIndex = page,
                PageSize = size,
                Query = null,
                TotalResult = listPagination.TotalItemCount
            };
        }
    }
}