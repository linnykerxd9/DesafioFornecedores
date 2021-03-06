using System;
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
    public abstract class Repository<T> : IRepository<T> where T : Entity, IAggregateRoot
    {
        protected readonly ProdForneContext _context;
        protected readonly DbSet<T> _dbSet;
        public Repository(ProdForneContext context)
        {
            _context = context;
            this._dbSet = context.Set<T>();
        }

        public virtual async Task<T> Find(Expression<Func<T, bool>> expression)
        {
           return await _dbSet.Where(expression).FirstOrDefaultAsync();
        }
        public virtual async Task<PaginationModel<T>> Pagination(int page, int size, Expression<Func<T, bool>> expression = null)
        {
            IPagedList<T> listPagination;
            if(expression == null){
                listPagination = await _dbSet.AsNoTracking().ToPagedListAsync(page,size);
            }else{
                listPagination = await _dbSet.Where(expression).AsNoTracking().ToPagedListAsync(page,size);
            }

            return new PaginationModel<T>(){
                List = listPagination.ToList(),
                PageIndex = page,
                PageSize = size,
                Query = null,
                TotalResult = listPagination.TotalItemCount
            };
        }

        public async Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Remove(T entity)
        {
            _dbSet.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public  async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
           _context?.Dispose();
        }

    }
}