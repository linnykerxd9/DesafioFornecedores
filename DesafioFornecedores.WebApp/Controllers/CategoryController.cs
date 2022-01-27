using DesafioFornecedores.WebApp.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFornecedores.WebApp.Controllers
{
    public class CategoryController : MainController
    {
         [AllowAnonymous]
        [HttpGet]
        public IActionResult index(){
            return View();
        }
    }
}