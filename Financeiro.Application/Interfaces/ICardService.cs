using Financeiro.Application.DTOs;

namespace Financeiro.Application.Interfaces
{
    public interface ICardService
    {
        Task<CardDTO> GetById(int? id);
        Task<IEnumerable<CardDTO>> GetCards();
        Task Create(CardDTO cardDto);
        Task Update(CardDTO cardDto);
        Task Remove(CardDTO cardDto);        
    }
}