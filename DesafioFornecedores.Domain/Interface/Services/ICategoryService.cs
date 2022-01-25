using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface.Services
{
    public interface ICategoryService
    {
         Task<IEnumerable<Category>> ToList();

         Task AddCategory(Category category);
    }
}