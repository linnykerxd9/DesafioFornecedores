using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Interface.Services;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Infra.Services
{
    public class SupplierPhysicalService : ISupplierPhysicalService
    {
        private readonly ISupplierPhysicalRepository _supplierPhysicalRepository;

        public SupplierPhysicalService(ISupplierPhysicalRepository supplierPhysicalRepository)
        {
            _supplierPhysicalRepository = supplierPhysicalRepository;
        }

        public async Task<IEnumerable<SupplierPhysical>> ToList()
        {
           return await _supplierPhysicalRepository.ToList();
        }
        public async Task AddSupplierPhysical(SupplierPhysical supplierPhysical)
        {
            /*
                Falta validar
            */
            await _supplierPhysicalRepository.Insert(supplierPhysical);
        }

    }
}