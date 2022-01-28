using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Interface.Services;
using DesafioFornecedores.Domain.Models;
using DesafioFornecedores.Domain.Tools;

namespace DesafioFornecedores.Infra.Services
{
    public class SupplierService : ISupplierService
    {
         private readonly ISupplierRepository _supplierRepository;
        private readonly INotificationService _notificationService;
        public SupplierService(ISupplierRepository supplierRepository, INotificationService notificationService)
        {
            _supplierRepository = supplierRepository;
            _notificationService = notificationService;
        }

        public async Task AddSupplier(SupplierPhysical supplier)
        {
           if(!supplier.Cpf.IsCpf()){
               _notificationService.AddError($"CPF: {supplier.FantasyName} is not a valid");
               return;
           }
           if(!supplier.BirthDate.IsOlderAge()){
               _notificationService.AddError($"you're not old enough");
               return;
           }
           if(!supplier.Email.EmailAddress.IsValidEmail()){
                _notificationService.AddError($"it's not a valid email");
               return;
           }
           var SupplierFind = _supplierRepository.FindPhysical(x => x.Cpf.Contains(supplier.Cpf) ||
                                                            x.FantasyName == supplier.FantasyName);
           if(SupplierFind != null) {
               if(SupplierFind.Result.Cpf.Contains(supplier.Cpf))
                    _notificationService.AddError($"Cpf: {supplier.Cpf} already registered ");

                if(SupplierFind.Result.FantasyName == supplier.FantasyName)
                _notificationService.AddError($"Fantasy Name: {supplier.FantasyName} already registered ");

               return;
           }
            await _supplierRepository.Insert(supplier);
            await _supplierRepository.SaveChanges();
        }
        public async Task AddSupplier(SupplierJuridical supplier)
        {
            if(!supplier.Cnpj.IsCnpj()){
               _notificationService.AddError($"CPF: {supplier.FantasyName} is not a valid");
               return;
           }
             var SupplierFind = _supplierRepository.FindJuridical(x => x.Cnpj.Contains(supplier.Cnpj) ||
                                                            x.FantasyName == supplier.FantasyName);
           if(SupplierFind != null) {
               if(SupplierFind.Result.Cnpj.Contains(supplier.Cnpj))
                    _notificationService.AddError($"Cpf: {supplier.Cnpj} already registered ");

                if(SupplierFind.Result.FantasyName == supplier.FantasyName)
                _notificationService.AddError($"Fantasy Name: {supplier.FantasyName} already registered ");

               return;
           }

            await _supplierRepository.Insert(supplier);
            await _supplierRepository.SaveChanges();
        }

        public Task<Supplier> Find()
        {
            return _supplierRepository.Find(x => x.Id != null);
        }

        public async Task<IEnumerable<Supplier>> ToList()
        {
           return await _supplierRepository.ToList();
        }
    }
}