using Financeiro.Domain.Entities;

namespace Financeiro.Domain.Interfaces
{
    public interface IBankRepository
    {
        Task<Bank> GetById(int? id);
        Task<IEnumerable<Bank>> GetBanks();
        Task<IEnumerable<Card>> GetCards();
        Task<Bank> Create(Bank bank);
        Task<Bank> Update(Bank bank);
        Task<Bank> Remove(Bank bank);
    }
}