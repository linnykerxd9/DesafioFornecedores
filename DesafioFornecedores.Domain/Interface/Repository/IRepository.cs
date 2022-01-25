using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioFornecedores.Domain.Interface.Repository
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        Task<T> Find(Expression<Func<T,bool>> expression);
        Task Insert(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task<int> SaveChanges();
    }
}