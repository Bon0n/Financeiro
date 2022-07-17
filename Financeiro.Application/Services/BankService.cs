using AutoMapper;
using Financeiro.Application.DTOs;
using Financeiro.Application.Interfaces;
using Financeiro.Domain.Entities;
using Financeiro.Domain.Interfaces;

namespace Financeiro.Application.Services
{
    public class BankService : IBankService
    {
        private IBankRepository _bankRepository;
        private readonly IMapper _mapper;
        public BankService(IBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }
        public async Task Create(BankDTO bankDto)
        {
            var bankEntity = _mapper.Map<Bank>(bankDto);
            await _bankRepository.Create(bankEntity);
        }

        public async Task<IEnumerable<BankDTO>> GetBanks()
        {
            var bankEntity = await _bankRepository.GetBanks();
            return _mapper.Map<IEnumerable<BankDTO>>(bankEntity);
        }

        public async Task<BankDTO> GetById(int? id)
        {
            var bankEntity = await _bankRepository.GetById(id);
            return _mapper.Map<BankDTO>(bankEntity);
        }

        public async Task Remove(BankDTO bankDto)
        {
            var bankEntity = _mapper.Map<Bank>(bankDto);
            await _bankRepository.Remove(bankEntity);

        }

        public async Task Update(BankDTO bankDto)
        {
            var bankEntity = _mapper.Map<Bank>(bankDto);
            await _bankRepository.Update(bankEntity);
;        }
    }
}