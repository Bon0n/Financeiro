using Financeiro.Domain.Entities;

namespace Financeiro.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> GetById(int? id);
        Task<IEnumerable<Person>> GetPeople();
        Task<Person> GetBanks(int? id);
        Task<Person> Create(Person person);
        Task<Person> Update(Person person);
        Task<Person> Remove(Person person);
    }
}