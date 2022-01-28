using AutoMapper;
using DesafioFornecedores.Domain.Interface.Services;
using DesafioFornecedores.WebApp.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFornecedores.WebApp.Controllers
{
    public class ProductController : MainController
    {

         private readonly IProductService _productService;

        public ProductController(IProductService productService, IMapper mapper, INotificationService notificationService)
                                 : base(mapper, notificationService)
        {
            _productService = productService;
        }

         [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(){
            return View();
        }
        
    }
}