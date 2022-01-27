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
    public class SupplierController : MainController
    {

        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(){
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult CreateJuridical(){
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateJuridical(SupplierViewModel viewModel){
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult CreatePhysical(){
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreatePhysical(SupplierViewModel viewModel){
            if(!ModelState.IsValid) return View(viewModel);

            var funcionario = _mapper.Map<SupplierPhysical>(viewModel);
            await _supplierService.AddSupplier(funcionario);
            return View();
        }
    }
}