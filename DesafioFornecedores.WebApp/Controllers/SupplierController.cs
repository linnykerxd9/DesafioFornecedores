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
        public async Task<IActionResult> Index(int pageSize = 10,int pageIndex = 1, string query = null){
            var result = await _supplierService.Pagination(pageIndex,pageSize,query);
            ICollection<SupplierListViewModel> listSuppliers = new List<SupplierListViewModel>();
            foreach (var item in result.List)
            {
                listSuppliers.Add(_mapper.Map<SupplierListViewModel>(item));
            }
            return View(new PaginationViewModel<SupplierListViewModel>(){
                List = listSuppliers,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query,
                TotalResult = result.TotalResult
            });
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult CreateJuridical(){
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateJuridical(CreateSupplierViewModel viewModel){
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
        public async Task<IActionResult> CreatePhysical(CreateSupplierViewModel viewModel){
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
        public async Task<IActionResult> Edit(string identification){
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
            var SupplierMapping = AddPhonesForHtml(_mapper.Map<EditSupplierViewModel>(supplier));
            return View(SupplierMapping);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Edit(EditSupplierViewModel viewModel){
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Delete(string identification){
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
            var teste = _mapper.Map<DeleteSupplierViewModel>(supplier);
            return View(teste);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> DeleteSupplierConfirmed(DeleteSupplierViewModel supplier){
          if (supplier == null)
                return RedirectToAction(nameof(Index));
            
            await _supplierService.RemoveSupplier(_mapper.Map<Supplier>(supplier));
           
           if(OperationValid()) return View("Delete",supplier);

            return RedirectToAction(nameof(Index));
        }
        private EditSupplierViewModel AddPhonesForHtml(EditSupplierViewModel viewModel){

            if(viewModel.Phone.Count >= 1)
                viewModel.FirstPhone = viewModel.Phone[0];
             if(viewModel.Phone.Count >= 2)
                viewModel.SecondPhone = viewModel.Phone[1];
             if(viewModel.Phone.Count == 3)
                viewModel.ThirdPhone = viewModel.Phone[2];

            return viewModel;
        }
        private EditSupplierViewModel AddPhonesForList(EditSupplierViewModel viewModel){

            if(viewModel.FirstPhone.Number != null){
                viewModel.Phone.Add(viewModel.FirstPhone);
            }
             if(viewModel.SecondPhone.Number != null){
                viewModel.Phone.Add(viewModel.SecondPhone);
             }
             if(viewModel.ThirdPhone.Number != null){
                viewModel.Phone.Add(viewModel.ThirdPhone);
             }
            return viewModel;
        }
        private CreateSupplierViewModel AddPhonesForList(CreateSupplierViewModel viewModel){

            if(viewModel.FirstPhone.Number != null){
                viewModel.Phone.Add(viewModel.FirstPhone);
            }
             if(viewModel.SecondPhone.Number != null){
                viewModel.Phone.Add(viewModel.SecondPhone);
             }
             if(viewModel.ThirdPhone.Number != null){
                viewModel.Phone.Add(viewModel.ThirdPhone);
             }
            return viewModel;
        }
    }
}