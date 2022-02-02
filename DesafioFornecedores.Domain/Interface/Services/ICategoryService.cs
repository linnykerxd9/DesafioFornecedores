using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface.Services
{
    public interface ICategoryService
    {
         Task<IEnumerable<Category>> ToList();
        Task<PaginationModel<Category>> Pagination(int page, int size, string query);
         Task AddCategory(Category category);
         Task RemoveCategory(Category category);
         Task UpdateCategory(Category category);
    }
}