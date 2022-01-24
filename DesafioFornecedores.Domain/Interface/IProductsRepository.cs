using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface
{
    public interface IProductsRepository : IRepository<Product>
    {
        Task InsertImage(Image image);
        Task RemoveImage(Image image);
        Task Update(Image image);
    }
}