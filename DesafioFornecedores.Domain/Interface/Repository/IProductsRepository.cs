using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface.Repository
{
    public interface IProductsRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> ToList();
        Task InsertImage(Image image);
        Task RemoveImage(Image image);
    }
}