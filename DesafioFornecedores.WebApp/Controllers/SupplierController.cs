using DesafioFornecedores.WebApp.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFornecedores.WebApp.Controllers
{
    public class SupplierController : MainController
    {
        public IActionResult index(){
            return View();
        }
    }
}