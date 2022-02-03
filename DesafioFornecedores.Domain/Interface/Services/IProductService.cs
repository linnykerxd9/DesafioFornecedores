using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Domain.Interface.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ToList();
        Task<PaginationModel<Product>> Pagination(int page, int size, string query);
        Task<Product> Find(Expression<Func<Product,bool>> expression);
        Task AddProduct(Product product);
         Task UpdateProduct(Product product);
         Task RemoveProduct(Product product);
         Task InsertImage(Image image);
         Task RemoveImage(Image image);
    }
}