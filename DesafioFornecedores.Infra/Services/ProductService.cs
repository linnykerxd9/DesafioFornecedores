using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Interface.Services;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Infra.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task<IEnumerable<Product>> ToList()
        {
            return await _productsRepository.ToList();
        }

        public async Task AddProduct(Product product)
        {
            /*
                Falta validar
            */
            await _productsRepository.Insert(product);
        }

    }
}