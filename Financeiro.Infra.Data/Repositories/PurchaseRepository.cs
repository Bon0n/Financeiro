using Financeiro.Domain.Entities;
using Financeiro.Domain.Interfaces;
using Financeiro.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Financeiro.Infra.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private AppDbContext _purchaseContext;

        public PurchaseRepository(AppDbContext purchaseContext)
        {
            _purchaseContext = purchaseContext;
        }
        public async Task<Purchase> Create(Purchase purchase)
        {
            _purchaseContext.Add(purchase);
            await _purchaseContext.SaveChangesAsync();
            return purchase;
        }

        public async Task<Purchase> GetById(int? id)
        {
            return await _purchaseContext.Purchases.FindAsync(id);
        }

        public async Task<IEnumerable<Purchase>> GetPurchases()
        {
            return await _purchaseContext.Purchases.ToListAsync();
        }

        public async Task<Purchase> Remove(Purchase purchase)
        {
            _purchaseContext.Remove(purchase);
            await _purchaseContext.SaveChangesAsync();
            return purchase;
        }

        public async Task<Purchase> Update(Purchase purchase)
        {
            _purchaseContext.Update(purchase);
            await _purchaseContext.SaveChangesAsync();
            return purchase;
        }
    }
}