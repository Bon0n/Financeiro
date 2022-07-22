using AutoMapper;
using Financeiro.Application.DTOs;
using Financeiro.Application.Interfaces;
using Financeiro.Domain.Entities;
using Financeiro.Domain.Interfaces;

namespace Financeiro.Application.Services
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task Create(PersonDTO personDto)
        {
            var personEntity = _mapper.Map<Person>(personDto);
            await _personRepository.Create(personEntity);
        }

        public async Task<PersonDTO> GetById(int? id)
        {
            var personEntity = await _personRepository.GetById(id);
            return _mapper.Map<PersonDTO>(personEntity);
        }

        public async Task<IEnumerable<PersonDTO>> GetPeople()
        {
            var personEntity = await _personRepository.GetPeople();
            return _mapper.Map<IEnumerable<PersonDTO>>(personEntity);
        }

        public async Task Remove(int? id)
        {
            var personEntity = _personRepository.GetById(id).Result;
            await _personRepository.Remove(personEntity);
        }

        public async Task Update(PersonDTO personDto)
        {
            var personEntity = _mapper.Map<Person>(personDto);
            await _personRepository.Update(personEntity);
        }

        public async Task<IEnumerable<BankDTO>> GetBanks(int? id)
        {
            var personEntity = await _personRepository.GetBanks(id);
            return _mapper.Map<IEnumerable<BankDTO>>(personEntity);
        }
    }
}