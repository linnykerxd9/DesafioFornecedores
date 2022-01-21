using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Interface;
using DesafioFornecedores.Domain.Models;
using DesafioFornecedores.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace DesafioFornecedores.Infra.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private ProdForneContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ProdForneContext context)
        {
            this._dbSet = context.Set<T>();
        }

        public  async Task<T> Find(Expression<Func<T, bool>> expression)
        {
           return await _dbSet.Where(expression).FirstOrDefaultAsync();
        }

        public async Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task Remove(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public  Task Update(T entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }
        public void Dispose()
        {
           _context?.Dispose();
        }
    }
}