using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Models;
using DesafioFornecedores.Infra.Data;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DesafioFornecedores.Infra.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProdForneContext context) : base(context)
        {
        }

         public override async Task<Category> Find(Expression<Func<Category, bool>> expression)
        {
           return await _dbSet.AsNoTracking().Include(x => x.Product).ThenInclude(x => x.Image)
                                .Where(expression).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Category>> ToList()
        {
           return await _dbSet.Include(x => x.Product).ToListAsync();
        }

    }
}