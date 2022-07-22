using AutoMapper;
using Financeiro.Application.DTOs;
using Financeiro.Application.Interfaces;
using Financeiro.Domain.Entities;
using Financeiro.Domain.Interfaces;

namespace Financeiro.Application.Services
{
    public class CardService : ICardService
    {
        private ICardRepository _cardRepository;
        private readonly IMapper _mapper;

        public CardService(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }
        public async Task Create(CardDTO cardDto)
        {
            var cardEntity = _mapper.Map<Card>(cardDto);
            await _cardRepository.Create(cardEntity);
        }

        public async Task<CardDTO> GetById(int? id)
        {
            var cardEntity = await _cardRepository.GetById(id);
            return _mapper.Map<CardDTO>(cardEntity);
        }

        public async Task<IEnumerable<CardDTO>> GetCards()
        {
            var cardEntity = await _cardRepository.GetCards();
            return _mapper.Map<IEnumerable<CardDTO>>(cardEntity);
        }

        public async Task Remove(int? id)
        {
            var cardEntity = _cardRepository.GetById(id).Result;
            await _cardRepository.Remove(cardEntity);
        }

        public async Task Update(CardDTO cardDto)
        {
            var cardEntity = _mapper.Map<Card>(cardDto);
            await _cardRepository.Update(cardEntity);
        }
    }
}