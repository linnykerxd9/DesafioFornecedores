using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task<T> Find(Expression<Func<T,bool>> expression);
        Task Insert(T entity);
        Task Update(T entity);
        Task Remove(T entity);
    }
}