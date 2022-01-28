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
    public class SupplierController : MainController
    {

        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService, IMapper mapper, INotificationService notificationService)
                                 : base(mapper, notificationService)
        {
            _supplierService = supplierService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(){
            var suppliers = _supplierService.Find();
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult CreateJuridical(){
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateJuridical(SupplierViewModel viewModel){
            if(ModelState.IsValid) return View(viewModel);

            var supplierJuridical = _mapper.Map<SupplierJuridical>(viewModel);
            await _supplierService.AddSupplier(supplierJuridical);

            if(OperationValid()) return View(viewModel);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult CreatePhysical(){
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreatePhysical(SupplierViewModel viewModel){
            if(ModelState.IsValid) return View(viewModel);

            var supplierPhysical = _mapper.Map<SupplierPhysical>(viewModel);
            await _supplierService.AddSupplier(supplierPhysical);

            if(OperationValid()) return View(viewModel);

            return RedirectToAction(nameof(Index));
        }
    }
}