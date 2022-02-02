using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DesafioFornecedores.Domain.Interface.Services;
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
    }
}