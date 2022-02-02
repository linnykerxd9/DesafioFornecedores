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
        public async Task<PaginationModel<Supplier>> Pagination(int page, int size, string query)
        {
            if(string.IsNullOrEmpty(query)){
                return await _supplierRepository.Pagination(page,size);
            }else{
                return await _supplierRepository.Pagination(page,size, x => x.FantasyName.ToLower().Contains(query.ToLower()));
            }
        }
        public async Task AddSupplier(SupplierPhysical supplier)
        {
            var ResultSupplierValidation = !SupplierPhysicalValidationIsValid(supplier);
            var ResultPhoneValidation = !PhoneIsValid(supplier.Phone);
            var ResulTAddressValidation = !AddressIsValid(supplier.Address);
            if(ResultSupplierValidation || ResultPhoneValidation || ResulTAddressValidation)
                return;

           var SupplierFind = await _supplierRepository.FindPhysical(x => x.Cpf == supplier.Cpf
                                                                    || x.FantasyName == supplier.FantasyName);

           if(SupplierFind != null) {
                if(SupplierFind.Cpf.Contains(supplier.Cpf))
                    _notificationService.AddError($"Cpf: {supplier.Cpf} already registered ");

                if(SupplierFind.FantasyName == supplier.FantasyName)
                    _notificationService.AddError($"Fantasy Name: {supplier.FantasyName} already registered ");

               return;
           }

                await _supplierRepository.Insert(supplier);
                await _supplierRepository.SaveChanges();

        }
        public async Task AddSupplier(SupplierJuridical supplier)
        {
           
            var ResultCnpjValidation = !supplier.Cnpj.IsCnpj();
            var ResultPhoneValidation = !PhoneIsValid(supplier.Phone);
            var ResulTAddressValidation = !AddressIsValid(supplier.Address);
            if(ResultCnpjValidation || ResultPhoneValidation || ResulTAddressValidation){
                 if(!supplier.Cnpj.IsCnpj())
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
            
                await _supplierRepository.Insert(supplier);
                await _supplierRepository.SaveChanges();
        }

        public async Task UpdateSupplier(SupplierJuridical supplier)
        {
            var ResultCnpjValidation = !supplier.Cnpj.IsCnpj();
            var ResultPhoneValidation = !PhoneIsValid(supplier.Phone);
            var ResulTAddressValidation = !AddressIsValid(supplier.Address);
            if(ResultCnpjValidation || ResultPhoneValidation || ResulTAddressValidation){
                 if(!supplier.Cnpj.IsCnpj())
                    _notificationService.AddError($"Cnpj: {supplier.Cnpj} is not a valid");
               return;
           }
            var supplierJuridical = await _supplierRepository.FindJuridical(x => x.Id == supplier.Id);
            if(supplierJuridical == null){
                _notificationService.AddError("Supplier not found");
                return;
            }
            supplierJuridical.SetActive(supplier.Active);
            supplierJuridical.SetCnpj(supplier.Cnpj);
            supplierJuridical.SetCompanyName(supplier.CompanyName);
            supplierJuridical.SetFantasyName(supplier.FantasyName);
            supplierJuridical.SetOpenDate(supplier.OpenDate);
            supplierJuridical.Email.SetEmail(supplier.Email.EmailAddress);
            supplierJuridical.Address.SetCity(supplier.Address.City);
            if(supplier.Address.Complement != null)
            supplierJuridical.Address.SetComplement(supplier.Address.Complement);
            if(supplier.Address.Reference != null)
            supplierJuridical.Address.SetReference(supplier.Address.Reference);
            supplierJuridical.Address.SetNeighborhood(supplier.Address.Neighborhood);
            supplierJuridical.Address.SetNumber(supplier.Address.Number);
            supplierJuridical.Address.SetState(supplier.Address.State);
            supplierJuridical.Address.SetStreet(supplier.Address.Street);
            supplierJuridical.Address.SetZipCode(supplier.Address.ZipCode);
           foreach (var item in supplierJuridical.Phone)
           {
               foreach (var phone in supplier.Phone)
               {
                    item.SetDdd(item.Id == phone.Id ? phone.Ddd : item.Ddd);
                    item.SetNumber(item.Id == phone.Id ? phone.Number : item.Number);
               }
            }

            await _supplierRepository.Update(supplierJuridical);
            await _supplierRepository.SaveChanges();
        }

        public async Task UpdateSupplier(SupplierPhysical supplier)
        {
            var ResultSupplierValidation = !SupplierPhysicalValidationIsValid(supplier);
            var ResultPhoneValidation = !PhoneIsValid(supplier.Phone);
            var ResulTAddressValidation = !AddressIsValid(supplier.Address);
            if(ResultSupplierValidation || ResultPhoneValidation || ResulTAddressValidation)
                return;
            var supplierPhysical = await _supplierRepository.FindPhysical(x => x.Id == supplier.Id);
            if(supplierPhysical == null){
                _notificationService.AddError("Supplier not found");
                return;
            }

            supplierPhysical.SetActive(supplier.Active);
            supplierPhysical.SetCpf(supplier.Cpf);
            supplierPhysical.SetFullName(supplier.FullName);
            supplierPhysical.SetFantasyName(supplier.FantasyName);
            supplierPhysical.SetBirthDate(supplier.BirthDate);
            supplierPhysical.Email.SetEmail(supplier.Email.EmailAddress);
            if(supplier.Address.Complement != null)
            supplierPhysical.Address.SetComplement(supplier.Address.Complement);
            if(supplier.Address.Reference != null)
            supplierPhysical.Address.SetReference(supplier.Address.Reference);
            supplierPhysical.Address.SetCity(supplier.Address.City);
            supplierPhysical.Address.SetNeighborhood(supplier.Address.Neighborhood);
            supplierPhysical.Address.SetNumber(supplier.Address.Number);
            supplierPhysical.Address.SetState(supplier.Address.State);
            supplierPhysical.Address.SetStreet(supplier.Address.Street);
            supplierPhysical.Address.SetZipCode(supplier.Address.ZipCode);
           foreach (var item in supplierPhysical.Phone)
           {
               foreach (var phone in supplier.Phone)
               {
                    item.SetDdd(item.Id == phone.Id ? phone.Ddd : item.Ddd);
                    item.SetNumber(item.Id == phone.Id ? phone.Number : item.Number);
               }
            }

            await _supplierRepository.Update(supplierPhysical);
            await _supplierRepository.SaveChanges();
        }

        public async Task RemoveSupplier(Supplier supplier){
            if(supplier == null || supplier.Id == Guid.Empty){
               if(supplier == null )
                    _notificationService.AddError($"The Supplier object is null");
                if(supplier.Id == Guid.Empty)
                    _notificationService.AddError($"Required Id for remove Supplier");
                return;
            }
            var removeSupplier = await _supplierRepository.Find(x => x.Id == supplier.Id);
            if(removeSupplier == null){
                _notificationService.AddError($"Supplier not found");
                return;
            }

                await _supplierRepository.Remove(removeSupplier);
                await _supplierRepository.SaveChanges();
            
        }
        public async Task InsertPhone(Phone phone){
            if(!PhoneIsValid(new List<Phone>(){phone})) return;

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
                if(phone.Id == Guid.Empty)
                    _notificationService.AddError($"Required Id for remove Phone");
                return;
            }
            var phones = await _supplierRepository.FindPhonesToSupplier(phone.SupplierId);
            if(phones.Count == 1){
                _notificationService.AddError($"you need to have at least one phone registered");
                return;
            }
            await _supplierRepository.RemovePhone(phone);
            await _supplierRepository.SaveChanges();
        }
        private bool SupplierPhysicalValidationIsValid(SupplierPhysical supplier){
              if(!supplier.Cpf.IsCpf() ||
              !supplier.BirthDate.IsOlderAge() ||
              !supplier.Email.EmailAddress.IsValidEmail() ||
              supplier.FullName == null ||
              supplier.FullName.Length > 256 ||
              supplier.FantasyName == null ||
              supplier.FantasyName.Length > 256)
           {
               if(!supplier.Cpf.IsCpf())
                    _notificationService.AddError($"CPF: {supplier.Cpf} is not a valid");

                if(!supplier.BirthDate.IsOlderAge())
                    _notificationService.AddError($"you're not old enough");

                if(!supplier.Email.EmailAddress.IsValidEmail())
                    _notificationService.AddError($"it's not a valid email");

                if( supplier.FullName == null || supplier.FantasyName == null)
                    _notificationService.AddError($"Fantasy name or Full name is null");
                if(supplier.FullName.Length > 256)
                    _notificationService.AddError($"the Full Name can only be a maximum of 256 characters");
                if(supplier.FantasyName.Length > 256)
                    _notificationService.AddError($"the Fantasy Name can only be a maximum of 256 characters");
                return false;
           }
            return true;
        }
        private bool PhoneIsValid(ICollection<Phone> phones){
            bool HisValid = true;
            if(phones.Count < 1 || phones.Count > 3)
                _notificationService.AddError($"mandatory 1 phone and maximum 3");
            foreach (var item in phones)
            {
                if(item.Ddd == null ||
                   item.Number == null ||
                   item.Ddd.Length < 2 ||
                   item.Ddd.Length > 3 ||
                   item.Number.Length > 9 ||
                   item.Number.Length < 8||
                   item.Id == Guid.Empty ||
                   item.SupplierId == Guid.Empty ||
                   item == null)
                   {
                       if(item == null)
                            _notificationService.AddError($"Phone cannot be null");
                        if(item.Ddd == null || item.Number == null)
                        _notificationService.AddError($"DDD or Number is null");
                        if(item.Ddd.Length < 2 || item.Ddd.Length > 3 )
                        _notificationService.AddError($"DDD must have between 2 to 3 digits");
                        if( item.Number.Length > 9 || item.Number.Length < 8)
                            _notificationService.AddError($"Number {item.Number} must be between 8 to 9 digits");
                         if(item.SupplierId == Guid.Empty)
                             _notificationService.AddError($"number  is not connected to any supplier");
                        if(item.Id == Guid.Empty)
                            _notificationService.AddError($"Phone id is null");
                        HisValid = false;
                   }
            }
            return HisValid;
        }
        private bool AddressIsValid(Address address){
            if(address.City == null ||
              address.Id == Guid.Empty ||
              address.Neighborhood == null ||
              address.Number == null ||
              address.State == null ||
              address.Street == null ||
              address.ZipCode == null ||
              address.SupplierId == Guid.Empty ||
              address.ZipCode.Length != 8 ||
              address.Number.Length > 10
              ){
                  if(address.Id == Guid.Empty)
                    _notificationService.AddError($"id is null");
                  if(address.SupplierId == Guid.Empty)
                    _notificationService.AddError($"Supplier id is null");
                  if(address.Neighborhood == null)
                    _notificationService.AddError($"Neighborhood  is null");
                  if(address.Number == null)
                    _notificationService.AddError($"Number  is null");
                  if(address.City == null)
                    _notificationService.AddError($"City  is null");
                  if( address.State == null)
                    _notificationService.AddError($"State is null");
                  if(address.Street == null )
                    _notificationService.AddError($"Street is null");
                  if(address.ZipCode == null)
                    _notificationService.AddError($"ZipCode is null");
                  if(address.ZipCode.Length != 8 )
                    _notificationService.AddError($"Zip code size is 8 digits");
                  if(address.Number.Length > 10)
                    _notificationService.AddError($"The size of field number is up to 10 digits");

                    return false;
              }

              return true;
        }

    }
}