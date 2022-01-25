using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ToList();

         Task AddCategory(Product product);
    }
}