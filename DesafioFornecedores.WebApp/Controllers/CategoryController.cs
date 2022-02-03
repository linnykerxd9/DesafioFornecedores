using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DesafioFornecedores.Domain.Interface.Services;
using DesafioFornecedores.Domain.Models;
using DesafioFornecedores.WebApp.Extensions;
using DesafioFornecedores.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFornecedores.WebApp.Controllers
{
    public class CategoryController : MainController
    {
         private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService, IMapper mapper, INotificationService notificationService)
                                 : base(mapper, notificationService)
        {
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        [HttpGet]
       public async Task<IActionResult> Index(int pageSize = 10,int pageIndex = 1, string query = null){
            var result = await _categoryService.Pagination(pageIndex,pageSize,query);
            ICollection<CategoryViewModel> listCategories = new List<CategoryViewModel>();
            foreach (var item in result.List)
            {
                listCategories.Add(_mapper.Map<CategoryViewModel>(item));
            }
            return View(new PaginationViewModel<CategoryViewModel>(){
                List = listCategories,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query,
                ReferenceAction= "Index",
                TotalResult = result.TotalResult
            });
        }
        [AllowAnonymous]
        [HttpGet]
       public  IActionResult Create(){
           return View();
        }
        [AllowAnonymous]
        [HttpPost]
       public async Task<IActionResult> Create(CategoryCreateViewModel viewModel){
           if(!ModelState.IsValid) return View(viewModel);

           var category =  _mapper.Map<Category>(viewModel);
           await _categoryService.AddCategory(category);

            if(OperationValid()) return View(viewModel);

           return RedirectToAction(nameof(Index));
        }
         [AllowAnonymous]
        [HttpGet]
       public async  Task<IActionResult> Edit(string Name){
           if(Name == null) return RedirectToAction(nameof(Index));

           var category = await _categoryService.Find(x => x.Name == Name);
           if(category == null){
               _notificationService.AddError("Category not found");
               return RedirectToAction(nameof(Index));
           }
           return View(_mapper.Map<CategoryUpdateOrEditViewModel>(category));
        }
        [AllowAnonymous]
        [HttpPost]
       public async Task<IActionResult> Edit(CategoryUpdateOrEditViewModel viewModel){
           if(!ModelState.IsValid) return View(viewModel);

            await _categoryService.UpdateCategory(_mapper.Map<Category>(viewModel));
           if(OperationValid()) return View(viewModel);

           return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        [HttpGet]
       public async Task<IActionResult> Details(string Name){
           if(Name == null) RedirectToAction(nameof(Index));

           var category =await _categoryService.Find(x => x.Name == Name);
           
          if(category == null){
               _notificationService.AddError("Category not found");
               return RedirectToAction(nameof(Index));
           }

           return View(_mapper.Map<CategoryViewModel>(category));
        }
        [AllowAnonymous]
        [HttpGet]
       public async Task<IActionResult> Delete(string Name){
          if(Name == null) RedirectToAction(nameof(Index));

           var category = await _categoryService.Find(x => x.Name == Name);
           
          if(category == null){
               _notificationService.AddError("Category not found");
               return RedirectToAction(nameof(Index));
           }

           return View(_mapper.Map<CategoryUpdateOrEditViewModel>(category));
        }
        [AllowAnonymous]
        [HttpPost]
       public async Task<IActionResult> DeleteConfirmed(CategoryUpdateOrEditViewModel viewModel){
            if(!ModelState.IsValid) return View(nameof(Delete),viewModel);

            await _categoryService.RemoveCategory(_mapper.Map<Category>(viewModel));

            if(OperationValid()) return View(nameof(Delete),viewModel);

            return RedirectToAction("Index","Category");
        }
    }
}