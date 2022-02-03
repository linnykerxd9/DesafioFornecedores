using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DesafioFornecedores.Domain.Interface.Services;
using DesafioFornecedores.Domain.Models;
using DesafioFornecedores.WebApp.Extensions;
using DesafioFornecedores.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesafioFornecedores.WebApp.Controllers
{
    public class ProductController : MainController
    {

         private readonly IProductService _productService;
         private readonly ICategoryService _categoryService;
         private readonly ISupplierService _supplierService;

        public ProductController(IProductService productService, IMapper mapper, INotificationService notificationService, ICategoryService categoryService, ISupplierService supplierService)
                                 : base(mapper, notificationService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }

        [AllowAnonymous]
        [HttpGet]
       public async Task<IActionResult> Index(int pageSize = 10,int pageIndex = 1, string query = null){
            var result = await _productService.Pagination(pageIndex,pageSize,query);
            ICollection<ProductViewModel> listProducts = new List<ProductViewModel>();
            foreach (var item in result.List)
            {
                listProducts.Add(_mapper.Map<ProductViewModel>(item));
            }
            return View(new PaginationViewModel<ProductViewModel>(){
                List = listProducts,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query,
                ReferenceAction= "Index",
                TotalResult = result.TotalResult
            });
        }
        
        [AllowAnonymous]
        [HttpGet]
       public async Task<IActionResult> Create(){
            var categories = await _categoryService.ToList();
            var suppliers = await _supplierService.ToList();
            ViewBag.Category  = new SelectList(categories,"Id","Name");
            ViewBag.Supplier  = new SelectList(suppliers,"Id","FantasyName");
           return View();
        }
        [AllowAnonymous]
        [HttpPost]
       public async Task<IActionResult> Create(ProductCreateViewModel viewModel){
           if(!ModelState.IsValid) return View(viewModel);
            viewModel.Image.Add(viewModel.ImageUpload);
           var product =  _mapper.Map<Product>(viewModel);
           await _productService.AddProduct(product);

            if(OperationValid()) return View(viewModel);

           return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        [HttpGet]
       public async Task<IActionResult> Details(Guid id){
           if(id == Guid.Empty) RedirectToAction(nameof(Index));

           var product = await _productService.Find(x => x.Id == id);
           
          if(product == null){
               _notificationService.AddError("product not found");
               return RedirectToAction(nameof(Index));
           }

           return View(_mapper.Map<ProductDetailsViewModel>(product));
        }
        /*[AllowAnonymous]
        [HttpGet]
       public async  Task<IActionResult> Edit(string Name){
           if(Name == null) return RedirectToAction(nameof(Index));

           var category = await _.Find(x => x.Name == Name);
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
        }*/
    }
}