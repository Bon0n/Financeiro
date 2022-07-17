using Financeiro.Application.DTOs;

namespace Financeiro.Application.Interfaces
{
    public interface IPurchaseService
    {
        Task<PurchaseDTO> GetById(int? id);
        Task<IEnumerable<PurchaseDTO>> GetPurchases();
        Task Create(PurchaseDTO PurchaseDto);
        Task Update(PurchaseDTO PurchaseDto);
        Task Remove(PurchaseDTO PurchaseDto);       
    }
}