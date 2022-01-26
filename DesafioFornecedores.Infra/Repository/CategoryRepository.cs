using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Models;
using DesafioFornecedores.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace DesafioFornecedores.Infra.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProdForneContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> ToList()
        {
           return await _dbSet.Include("Products").ToListAsync();
        }
    }
}