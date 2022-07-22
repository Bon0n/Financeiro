using Financeiro.Domain.Entities;
using Financeiro.Domain.Interfaces;
using Financeiro.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Financeiro.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private AppDbContext _personContext;

        public PersonRepository(AppDbContext personContext)
        {
            _personContext = personContext;            
        }
        public async Task<Person> Create(Person person)
        {
            _personContext.Add(person);
            await _personContext.SaveChangesAsync();
            return person;
        }

        public async Task<IEnumerable<Bank>> GetBanks(int? id)
        {
            return await _personContext.Banks.ToListAsync();
        }

        public async Task<Person> GetById(int? id)
        {
            return await _personContext.People.FindAsync(id);
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            return await _personContext.People.ToListAsync();
        }

        public async Task<Person> Remove(Person person)
        {
            _personContext.Remove(person);
            await _personContext.SaveChangesAsync();
            return person;
        }

        public async Task<Person> Update(Person person)
        {
            _personContext.Update(person);
            await _personContext.SaveChangesAsync();
            return person;
        }
    }
}