using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Models;
using DesafioFornecedores.Infra.Data;

namespace DesafioFornecedores.Infra.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProdForneContext context) : base(context)
        {
        }

        public Task<IEnumerable<Category>> ToList()
        {
            throw new System.NotImplementedException();
        }
    }
}