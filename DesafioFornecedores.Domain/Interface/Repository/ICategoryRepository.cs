using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
         Task<IEnumerable<Category>> ToList();
    }
}