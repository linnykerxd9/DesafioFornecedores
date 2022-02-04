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
        
        
       [Authorize(Policy = "AdminOnly")]
        [HttpGet]
       public async Task<IActionResult> Create(){
            var categories = await _categoryService.ToList();
            var suppliers = await _supplierService.ToList();
            ViewBag.Category  = new SelectList(categories,"Id","Name");
            ViewBag.Supplier  = new SelectList(suppliers,"Id","FantasyName");
           return View();
        }
        
       [Authorize(Policy = "AdminOnly")]
        [HttpPost]
       public async Task<IActionResult> Create(ProductCreateViewModel viewModel){
           if(!ModelState.IsValid){
                var categories = await _categoryService.ToList();
                var suppliers = await _supplierService.ToList();
                ViewBag.Category  = new SelectList(categories,"Id","Name");
                ViewBag.Supplier  = new SelectList(suppliers,"Id","FantasyName");
                return View(viewModel);
           }
            viewModel.Image.Add(viewModel.ImageUpload);
           var product =  _mapper.Map<Product>(viewModel);
           await _productService.AddProduct(product);

            if(OperationValid()){
                 var categories = await _categoryService.ToList();
                var suppliers = await _supplierService.ToList();
                ViewBag.Category  = new SelectList(categories,"Id","Name");
                ViewBag.Supplier  = new SelectList(suppliers,"Id","FantasyName");
                return View(viewModel);
            }

           return RedirectToAction(nameof(Index));
        }
        
        
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
        
       [Authorize(Policy = "AdminOnly")]
        [HttpGet]
       public async  Task<IActionResult> Edit(Guid id){
           if(id == Guid.Empty) return RedirectToAction(nameof(Index));

           var product = await _productService.Find(x => x.Id == id);
           if(product == null){
               _notificationService.AddError("product not found");
               return RedirectToAction(nameof(Index));
           }
           return View(_mapper.Map<ProductEditViewModel>(product));
        }
        
       [Authorize(Policy = "AdminOnly")]
        [HttpPost]
       public async Task<IActionResult> Edit(ProductEditViewModel viewModel){
           if(!ModelState.IsValid) return View(viewModel);

            await _productService.UpdateProduct(_mapper.Map<Product>(viewModel));
           if(OperationValid()) return View(viewModel);

           return RedirectToAction(nameof(Index));
        }
        
       [Authorize(Policy = "AdminOnly")]
        [HttpGet]
       public async Task<IActionResult> Delete(Guid id){
          if(id == Guid.Empty) RedirectToAction(nameof(Index));

           var product = await _productService.Find(x => x.Id == id);
           
          if(product == null){
               _notificationService.AddError("product not found");
               return RedirectToAction(nameof(Index));
           }

           return View(_mapper.Map<ProductDeleteViewModel>(product));
        }
        
       [Authorize(Policy = "AdminOnly")]
        [HttpPost]
       public async Task<IActionResult> DeleteConfirmed(ProductDeleteViewModel viewModel){
            if(!ModelState.IsValid) return View(nameof(Delete),viewModel);

            await _productService.RemoveProduct(_mapper.Map<Product>(viewModel));

            if(OperationValid()) return View(nameof(Delete),viewModel);

            return RedirectToAction("Index","Product");
        }
        
       [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public async Task<IActionResult> InsertImage(Guid idenfitication)
        {
            if (idenfitication == Guid.Empty) return RedirectToAction(nameof(Index));
            
            Product product = await _productService.Find(x => x.Id == idenfitication);
            if(product == null){
                return RedirectToAction(nameof(Index));
            }
            return View(new ImageInsertOrDeleteViewModel(){
                ProductId = product.Id,
                Name = product.Name
            });
        }
        
       [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> InsertImage(ImageInsertOrDeleteViewModel viewModel){
            if(!ModelState.IsValid) return View(viewModel);
            var image = _mapper.Map<Image>(viewModel);
            await _productService.InsertImage(image);

            if(OperationValid()) return View(viewModel);

            return RedirectToAction("Index","Product");
        }
        
       [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public  IActionResult DeleteImage(ImageInsertOrDeleteViewModel Identi){
            if (Identi == null) return RedirectToAction(nameof(Index));
            return View(Identi);
        }

        
       [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> DeletePhoneConfirmed(ImageInsertOrDeleteViewModel image){
            if(!ModelState.IsValid) return View(nameof(DeleteImage),image);

            await _productService.RemoveImage(_mapper.Map<Image>(image));

            if(OperationValid()) return View(nameof(DeleteImage),image);

            return RedirectToAction(nameof(Index));
        }
    }
}