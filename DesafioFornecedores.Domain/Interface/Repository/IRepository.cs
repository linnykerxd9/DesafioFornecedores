using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface.Repository
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        Task<T> Find(Expression<Func<T,bool>> expression);
        Task Insert(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task<PaginationModel<T>> Pagination(int page, int size, Expression<Func<T, bool>> expression = null);
        Task<int> SaveChanges();
    }
}