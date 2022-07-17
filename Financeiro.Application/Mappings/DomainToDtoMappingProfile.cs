using AutoMapper;
using Financeiro.Application.DTOs;
using Financeiro.Domain.Entities;

namespace Financeiro.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Bank, BankDTO>().ReverseMap();
            CreateMap<Card, CardDTO>().ReverseMap();
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Purchase, PurchaseDTO>().ReverseMap();
        }
    }
}