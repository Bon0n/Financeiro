using Financeiro.Domain.Entities;

namespace Financeiro.Domain.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<Purchase> GetById(int? id);
        Task<IEnumerable<Purchase>> GetPurchases();
        Task<Purchase> Create(Purchase purchase);
        Task<Purchase> Update(Purchase purchase);
        Task<Purchase> Remove(Purchase purchase);
    }
}