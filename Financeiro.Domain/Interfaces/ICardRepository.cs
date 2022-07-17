using Financeiro.Domain.Entities;

namespace Financeiro.Domain.Interfaces
{
    public interface ICardRepository
    {
        Task<Card> GetById(int? id);
        Task<IEnumerable<Card>> GetCards();
        Task<IEnumerable<Purchase>> GetPurchases();
        Task<Card> Create(Card card);
        Task<Card> Update(Card card);
        Task<Card> Remove(Card card);
    }
}