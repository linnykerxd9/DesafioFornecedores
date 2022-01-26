using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Interface.Services;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Infra.Services
{
    public class SupplierJuridicalService : ISupplierJuridicalService
    {
        private readonly ISupplierJuridicalRepository _supplierJuridicalRepository;

        public SupplierJuridicalService(ISupplierJuridicalRepository supplierJuridicalRepository)
        {
            _supplierJuridicalRepository = supplierJuridicalRepository;
        }

        public async Task<IEnumerable<SupplierJuridical>> ToList()
        {
            return await _supplierJuridicalRepository.ToList();
        }
        public async Task AddSupplierJuridical(SupplierJuridical supplierJuridical)
        {
             /*
                Falta validar
            */
            await _supplierJuridicalRepository.Insert(supplierJuridical);
        }

    }
}