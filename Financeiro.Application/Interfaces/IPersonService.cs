using Financeiro.Application.DTOs;
namespace Financeiro.Application.Interfaces
{
    public interface IPersonService
    {
        Task<PersonDTO> GetById(int? id);
        Task<IEnumerable<PersonDTO>> GetPeople();
        Task Create(PersonDTO personDto);
        Task Update(PersonDTO personDto);
        Task Remove(PersonDTO personDto);
    }
}