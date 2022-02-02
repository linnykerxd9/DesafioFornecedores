using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Interface.Services;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Infra.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly INotificationService _notificationService;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository, INotificationService notificationService)
        {
            _categoryRepository = categoryRepository;
            _notificationService = notificationService;
        }
        public async Task<IEnumerable<Category>> ToList()
        {
           return await _categoryRepository.ToList();
        }
        public async Task AddCategory(Category category)
        {
            if(category == null ||
                category.Id == Guid.Empty ||
                category.Name == null ||
                category.Name.Length > 100)
                {
                    if(category == null)
                        _notificationService.AddError("Category is null");
                    if(category.Id == Guid.Empty)
                        _notificationService.AddError("CategoryId is null");
                    if(category.Name == null)
                        _notificationService.AddError("Name is null");
                    if(category.Name.Length > 100)
                        _notificationService.AddError("the maximum character in the name is 100");
                    return;
                }
            var result = await _categoryRepository.Find(x => x.Name == category.Name);
            if(result != null){
                    _notificationService.AddError("category already registered");
                return;
            }
            await _categoryRepository.Insert(category);
            await _categoryRepository.SaveChanges();
        }

        public async Task RemoveCategory(Category category)
        {
            if(category == null ||
                category.Id == Guid.Empty)
                {
                    if(category == null)
                        _notificationService.AddError("Category is null");
                    if(category.Id == Guid.Empty)
                        _notificationService.AddError("CategoryId is null");
                    return;
                }
            var result = await _categoryRepository.Find(x => x.Id == category.Id);
            if(result == null){
                _notificationService.AddError("Category NotFound");
                return;
            }
            await _categoryRepository.Remove(result);
            await _categoryRepository.SaveChanges();
        }

        public async Task UpdateCategory(Category category)
        {
            if(category == null ||
                category.Id == Guid.Empty ||
                category.Name == null ||
                category.Name.Length > 100)
                {
                    if(category == null)
                        _notificationService.AddError("Category is null");
                    if(category.Id == Guid.Empty)
                        _notificationService.AddError("CategoryId is null");
                    if(category.Name == null)
                        _notificationService.AddError("Name is null");
                    if(category.Name.Length > 100)
                        _notificationService.AddError("the maximum character in the name is 100");
                    return;
                }
            var result = await _categoryRepository.Find(x => x.Id == category.Id);
            if(result == null){
                _notificationService.AddError("Category not found");
                return;
            }
            result.SetName(category.Name);
            result.setActive(category.Active);
            await _categoryRepository.Update(result);
            await _categoryRepository.SaveChanges();
        }

        public async Task<PaginationModel<Category>> Pagination(int page, int size, string query)
        {
            if(query == null){
                return await _categoryRepository.Pagination(page,size);
            }
            return await _categoryRepository.Pagination(page,size,x => x.Name.ToLower().Contains(query.ToLower()));
        }
    }
}