using AutoMapper;
using DesafioFornecedores.Domain.Interface.Services;
using DesafioFornecedores.WebApp.Extensions;
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
        public IActionResult Index(){
            return View();
        }
    }
}