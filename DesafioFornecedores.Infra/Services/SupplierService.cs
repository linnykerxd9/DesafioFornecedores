using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        public async Task<Supplier> Find(Expression<Func<Supplier,bool>> expression)
        {
            return await _supplierRepository.Find(expression);
        }
         public async Task<SupplierJuridical> FindJuridical(Expression<Func<SupplierJuridical,bool>> expression)
        {
            return await _supplierRepository.FindJuridical(expression);
        }
         public async Task<SupplierPhysical> FindPhysical(Expression<Func<SupplierPhysical,bool>> expression)
        {
            return await _supplierRepository.FindPhysical(expression);
        }

        public async Task<IEnumerable<Supplier>> ToList()
        {
           return await _supplierRepository.ToList();
        }

        public async Task AddSupplier(SupplierPhysical supplier)
        {
            if(SupplierPhysicalValidation(supplier)) return;

           var SupplierFind = await _supplierRepository.FindPhysical(x => x.Cpf == supplier.Cpf
                                                                    || x.FantasyName == supplier.FantasyName);

           if(SupplierFind != null) {
                if(SupplierFind.Cpf.Contains(supplier.Cpf))
                    _notificationService.AddError($"Cpf: {supplier.Cpf} already registered ");

                if(SupplierFind.FantasyName == supplier.FantasyName)
                    _notificationService.AddError($"Fantasy Name: {supplier.FantasyName} already registered ");

               return;
           }
            if(supplier.Phone.Count >= 1 && supplier.Phone.Count <= 3){
                 _notificationService.AddError($"mandatory 1 phone and maximum 3");

                 return;
            }
                await _supplierRepository.Insert(supplier);
                await _supplierRepository.SaveChanges();

        }
        public async Task AddSupplier(SupplierJuridical supplier)
        {
            if(!supplier.Cnpj.IsCnpj()){
               _notificationService.AddError($"Cnpj: {supplier.Cnpj} is not a valid");
               return;
           }
             var SupplierFind = await _supplierRepository.FindJuridical(x => x.Cnpj.Contains(supplier.Cnpj) ||
                                                            x.FantasyName == supplier.FantasyName);
           if(SupplierFind != null) {
               if(SupplierFind.Cnpj.Contains(supplier.Cnpj))
                    _notificationService.AddError($"Cnpj: {supplier.Cnpj} already registered ");

                if(SupplierFind.FantasyName == supplier.FantasyName)
                _notificationService.AddError($"Fantasy Name: {supplier.FantasyName} already registered ");

               return;
           }
            if(supplier.Phone.Count >= 1 && supplier.Phone.Count <= 3){
                 _notificationService.AddError($"mandatory 1 phone and maximum 3");

                 return;
            }
                await _supplierRepository.Insert(supplier);
                await _supplierRepository.SaveChanges();
        }

        public async Task UpdateSupplier(SupplierJuridical supplier)
        {
            if(!supplier.Cnpj.IsCnpj()){
               _notificationService.AddError($"Cnpj: {supplier.Cnpj} is not a valid");
               return;
           }
            await _supplierRepository.Update(supplier);
            await _supplierRepository.SaveChanges();
        }

        public async Task UpdateSupplier(SupplierPhysical supplier)
        {
            if(SupplierPhysicalValidation(supplier)) return;

            await _supplierRepository.Update(supplier);
            await _supplierRepository.SaveChanges();
        }

        public async Task InsertPhone(Phone phone){
            if(phone.Number == null ||
                phone.Number.Length < 8 ||
                phone.Number.Length > 9 ||
                phone.Ddd == null ||
                phone.Ddd.Length > 3 ||
                phone.Ddd.Length < 2 ||
                phone == null ||
                phone.SupplierId == Guid.Empty)
               {
                if(phone.Number == null)
                    _notificationService.AddError($"Number cannot be null");
                if(phone.Number.Length > 9 || phone.Number.Length < 8)
                    _notificationService.AddError($"Number must be between 8 to 9 digits");

                if(phone.Ddd == null)
                    _notificationService.AddError($"DDD cannot be null");
                if(phone.Ddd.Length > 3 || phone.Ddd.Length < 2)
                    _notificationService.AddError($"DDD must be between 2 to 3 digits");

                if(phone == null)
                    _notificationService.AddError($"Phone cannot be null");

                if(phone.SupplierId == Guid.Empty)
                    _notificationService.AddError($"The number must be connected to any supplier");

                   return;
               }
            var supplier = await _supplierRepository.Find(x => x.Id == phone.SupplierId);
            if(supplier.Phone.Count == 3){
                _notificationService.AddError($"you can only have registered 3 phones");

                   return;
            }
            await _supplierRepository.InsertPhone(phone);
            await _supplierRepository.SaveChanges();
        }
        public async Task RemovePhone(Phone phone)
        {
            if(phone == null || phone.Id == Guid.Empty){
               if(phone == null )
                    _notificationService.AddError($"The Phone object is null");
                if( phone.Id == Guid.Empty)
                    _notificationService.AddError($"Required Id for remove Phone");
                return;
            }
            await _supplierRepository.RemovePhone(phone);
            await _supplierRepository.SaveChanges();
        }
        private bool SupplierPhysicalValidation(SupplierPhysical supplier){
              if(!supplier.Cpf.IsCpf() ||
              !supplier.BirthDate.IsOlderAge() ||
              !supplier.Email.EmailAddress.IsValidEmail())
           {
               if(!supplier.Cpf.IsCpf())
                    _notificationService.AddError($"CPF: {supplier.Cpf} is not a valid");

                if(!supplier.BirthDate.IsOlderAge())
                    _notificationService.AddError($"you're not old enough");

                if(!supplier.Email.EmailAddress.IsValidEmail())
                    _notificationService.AddError($"it's not a valid email");

                return true;
           }
            return false;
        }

    }
}