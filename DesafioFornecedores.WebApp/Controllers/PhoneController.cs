using System;
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

namespace DesafioFornecedores.WebApp.Controllers
{
    public class PhoneController : MainController
    {
        private readonly ISupplierService _supplierService;
        public PhoneController(ISupplierService supplierService, IMapper mapper, INotificationService notificationService)
                                 : base(mapper, notificationService)
        {
            _supplierService = supplierService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> InsertPhone(Guid id){
            if (id == null)
                return RedirectToAction(nameof(Index));
            Supplier supplier = await _supplierService.Find(x => x.Id == id);
            if(supplier == null){
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<InsertPhoneViewModel>(new InsertPhoneViewModel(){
                SupplierId = supplier.Id,
                Name = supplier.FantasyName
            }));
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> InsertPhone(InsertPhoneViewModel viewModel){
            if(!ModelState.IsValid) return View(viewModel);
            var phone = _mapper.Map<Phone>(viewModel);
            await _supplierService.InsertPhone(phone);

            if(OperationValid()) return View(viewModel);

            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> DeletePhone(UpdateOrDeletePhoneViewModel Identi){
            if (Identi == null) return RedirectToAction(nameof(Index));
            return View(Identi);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> DeletePhoneConfirmed(UpdateOrDeletePhoneViewModel phone){
            if (phone == null) return RedirectToAction(nameof(Index));

            await _supplierService.RemovePhone(_mapper.Map<Phone>(phone));

            if(OperationValid()) return View(phone);

            return RedirectToAction("Index","Supplier");
        }
    }
}