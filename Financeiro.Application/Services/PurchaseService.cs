using AutoMapper;
using Financeiro.Application.DTOs;
using Financeiro.Application.Interfaces;
using Financeiro.Domain.Entities;
using Financeiro.Domain.Interfaces;

namespace Financeiro.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;
        public PurchaseService(IPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        public async Task<PurchaseDTO> GetById(int? id)
        {
            var purchaseEntity = await _purchaseRepository.GetById(id);
            return _mapper.Map<PurchaseDTO>(purchaseEntity);
        }

        public async Task<IEnumerable<PurchaseDTO>> GetPurchases()
        {
            var purchaseEntity = await _purchaseRepository.GetPurchases();
            return _mapper.Map<IEnumerable<PurchaseDTO>>(purchaseEntity);
        }

        public async Task Create(PurchaseDTO purchaseDto)
        {
            var purchaseEntity = _mapper.Map<Purchase>(purchaseDto);
            await _purchaseRepository.Create(purchaseEntity);
        }

        public async Task Update(PurchaseDTO purchaseDto)
        {
            var purchaseEntity = _mapper.Map<Purchase>(purchaseDto);
            await _purchaseRepository.Update(purchaseEntity);
        }

        public async Task Remove(int? id)
        {
            var purchaseEntity = _purchaseRepository.GetById(id).Result;
            await _purchaseRepository.Remove(purchaseEntity);
        }
    }
}