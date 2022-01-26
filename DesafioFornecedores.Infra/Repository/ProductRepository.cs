using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Interface;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Models;
using DesafioFornecedores.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace DesafioFornecedores.Infra.Repository
{
    public class ProductRepository : Repository<Product>, IProductsRepository
    {
        public ProductRepository(ProdForneContext context) : base(context)
        {
        }
        public async Task InsertImage(Image image)
        {
            await _context.Images.AddAsync(image);
        }

        public  Task RemoveImage(Image image)
        {
            _context.Images.Remove(image);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> ToList()
        {
            return await _dbSet.Include("Images").Include("Categories").ToListAsync();
        }

        public  Task Update(Image image)
        {
           _context.Images.Update(image);
            return Task.CompletedTask;
        }
    }
}