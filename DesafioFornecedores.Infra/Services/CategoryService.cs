using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Interface.Services;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Infra.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> ToList()
        {
           return await _categoryRepository.ToList();
        }
        public async Task AddCategory(Category category)
        {
            /*
                Falta validar
            */
            await _categoryRepository.Insert(category);
        }

       
    }
}