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
        public async Task<IActionResult> Index(){
            var suppliers = await _supplierService.ToList();
            return View(_mapper.Map<IEnumerable<SupplierListViewModel>>(suppliers));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult CreateJuridical(){
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateJuridical(CreateOrEditSupplierViewModel viewModel){
            if(!ModelState.IsValid) return View(viewModel);
            viewModel = AddPhonesForList(viewModel);
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
        public async Task<IActionResult> CreatePhysical(CreateOrEditSupplierViewModel viewModel){
            if(!ModelState.IsValid) return View(viewModel);
            viewModel = AddPhonesForList(viewModel);
            var supplierPhysical = _mapper.Map<SupplierPhysical>(viewModel);
            await _supplierService.AddSupplier(supplierPhysical);

            if(OperationValid()) return View(viewModel);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(string identification){
            if (identification == null)
                return RedirectToAction(nameof(Index));
            Supplier supplier;
            if (identification.Length == 11)
                 supplier = await _supplierService.FindPhysical(x => x.Cpf.Contains(identification));
            else
                 supplier = await _supplierService.FindJuridical(x => x.Cnpj.Contains(identification));

            if(supplier == null){
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<SupplierListViewModel>(supplier));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Edit(string? identification){
             if (identification == null)
                return RedirectToAction(nameof(Index));
            Supplier supplier;
            if (identification.Length == 11)
                 supplier = await _supplierService.FindPhysical(x => x.Cpf.Contains(identification));
            else
                 supplier = await _supplierService.FindJuridical(x => x.Cnpj.Contains(identification));

            if(supplier == null){
                return RedirectToAction(nameof(Index));
            }
            var SupplierMapping = AddPhonesForHtml(_mapper.Map<CreateOrEditSupplierViewModel>(supplier));
            return View(SupplierMapping);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Edit(CreateOrEditSupplierViewModel viewModel){
            if(!ModelState.IsValid) return View(viewModel);

            viewModel = AddPhonesForList(viewModel);
            if(viewModel.Cnpj != null && viewModel.Cnpj.Length == 14){
                var supplier = _mapper.Map<SupplierJuridical>(viewModel);
                await _supplierService.UpdateSupplier(supplier);
            }else{
                var supplier = _mapper.Map<SupplierPhysical>(viewModel);
                await _supplierService.UpdateSupplier(supplier);
            }

            if(OperationValid()) return View(viewModel);

            return RedirectToAction(nameof(Index));
        }
        
        public async void DeletePhone(InsertPhoneViewModel viewModel){
            var phone = _mapper.Map<Phone>(viewModel);
            await _supplierService.InsertPhone(phone);


             RedirectToAction(nameof(Index));
        }
        private CreateOrEditSupplierViewModel AddPhonesForHtml(CreateOrEditSupplierViewModel viewModel){

            if(viewModel.Phone.Count >= 1)
                viewModel.FirstPhone = viewModel.Phone[0];
             if(viewModel.Phone.Count >= 2)
                viewModel.SecondPhone = viewModel.Phone[1];
             if(viewModel.Phone.Count == 3)
                viewModel.ThirdPhone = viewModel.Phone[2];

            return viewModel;
        }
        private CreateOrEditSupplierViewModel AddPhonesForList(CreateOrEditSupplierViewModel viewModel){

            if(viewModel.FirstPhone.Number != null){
                if(viewModel.FirstPhone.Id == Guid.Empty) viewModel.FirstPhone.Id = Guid.NewGuid();
                viewModel.Phone.Add(viewModel.FirstPhone);
            }
             if(viewModel.SecondPhone.Number != null){
                if(viewModel.SecondPhone.Id == Guid.Empty) viewModel.SecondPhone.Id = Guid.NewGuid();
                viewModel.Phone.Add(viewModel.SecondPhone);
             }
             if(viewModel.ThirdPhone.Number != null){
                if(viewModel.ThirdPhone.Id == Guid.Empty) viewModel.ThirdPhone.Id = Guid.NewGuid();
                viewModel.Phone.Add(viewModel.ThirdPhone);
             }
            return viewModel;
        }
    }
}