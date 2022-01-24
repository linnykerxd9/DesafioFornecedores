using DesafioFornecedores.Domain.Interface;
using DesafioFornecedores.Domain.Models;
using DesafioFornecedores.Infra.Data;

namespace DesafioFornecedores.Infra.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProdForneContext context) : base(context)
        {
        }
    }
}