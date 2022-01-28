using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DesafioFornecedores.Domain.Interface.Services;
using DesafioFornecedores.Domain.Models;
using DesafioFornecedores.Infra.Data;
using DesafioFornecedores.WebApp.Extensions;
using DesafioFornecedores.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioFornecedores.WebApp.Controllers
{
    public class SupplierController : MainController
    {

        private readonly ISupplierService _supplierService;
        private readonly ProdForneContext context;
        public SupplierController(ProdForneContext contexts,ISupplierService supplierService, IMapper mapper, INotificationService notificationService)
                                 : base(mapper, notificationService)
        {
            _supplierService = supplierService;
            context = contexts;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(){
            var suppliers = await _supplierService.ToList();
            //var mappeade = _mapper.Map<IEnumerable<SupplierViewModel>>(suppliers);
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