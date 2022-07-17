using Financeiro.Domain.Entities;
using Financeiro.Domain.Interfaces;
using Financeiro.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Financeiro.Infra.Data.Repositories
{
    public class BankRepository : IBankRepository
    {
        private AppDbContext _bankContext;
        public BankRepository(AppDbContext bankContext)
        {
            _bankContext = bankContext;
        }

        public async Task<Bank> Create(Bank bank)
        {
            _bankContext.Add(bank);
            await _bankContext.SaveChangesAsync();
            return bank;
        }

        public async Task<IEnumerable<Bank>> GetBanks()
        {
            return await _bankContext.Banks.ToListAsync();
        }

        public async Task<Bank> GetById(int? id)
        {
            return await _bankContext.Banks.FindAsync(id);
        }

        public async Task<IEnumerable<Card>> GetCards()
        {
            return await _bankContext.Cards.ToListAsync();
        }

        public async Task<Bank> Remove(Bank bank)
        {
            _bankContext.Remove(bank);
            await _bankContext.SaveChangesAsync();
            return bank;
        }

        public async Task<Bank> Update(Bank bank)
        {
            _bankContext.Update(bank);
            await _bankContext.SaveChangesAsync();
            return bank;
        }
    }
}