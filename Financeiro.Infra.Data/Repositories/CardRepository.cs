using Financeiro.Domain.Entities;
using Financeiro.Domain.Interfaces;
using Financeiro.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Financeiro.Infra.Data.Repositories
{
    public class CardRepository : ICardRepository
    {
        private AppDbContext _cardContext;

        public CardRepository(AppDbContext cardContext)
        {
            _cardContext = cardContext;
        }
        public async Task<Card> Create(Card card)
        {
            _cardContext.Add(card);
            await _cardContext.SaveChangesAsync();
            return card;
        }

        public async Task<Card> GetById(int? id)
        {
            return await _cardContext.Cards.FindAsync(id);
        }

        public async Task<IEnumerable<Card>> GetCards()
        {
            return await _cardContext.Cards.ToListAsync();
        }

        public async Task<IEnumerable<Purchase>> GetPurchases()
        {
            return await _cardContext.Purchases.ToListAsync();
        }

        public async Task<Card> Remove(Card card)
        {
            _cardContext.Remove(card);
            await _cardContext.SaveChangesAsync();
            return card;
        }

        public async Task<Card> Update(Card card)
        {
            _cardContext.Update(card);
            await _cardContext.SaveChangesAsync();
            return card;
        }
    }
}