using Financeiro.Application.DTOs;

namespace Financeiro.Application.Interfaces
{
    public interface IBankService
    {
        Task<BankDTO> GetById(int? id);
        Task<IEnumerable<BankDTO>> GetBanks();
        Task Create(BankDTO bankDto);
        Task Update(BankDTO bankDto);
        Task Remove(BankDTO bankDto);
    }
}