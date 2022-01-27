using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Interface.Services;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Infra.Services
{
    public class SupplierService : ISupplierService
    {
         private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task AddSupplier(Supplier supplier)
        {
             /*
                Falta validar
            */
            await _supplierRepository.Insert(supplier);
        }

        public async Task<IEnumerable<Supplier>> ToList()
        {
           return await _supplierRepository.ToList();
        }
    }
}