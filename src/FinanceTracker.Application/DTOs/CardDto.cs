using AutoMapper;
using FinanceTracker.Domain.Models;

namespace FinanceTracker.Application.DTOs
{
    public class CardDto
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public string Holder { get; set; }
        public string Expiry { get; set; }
        public string Cvv { get; set; }
        public string CurrencyLogo { get; set; }
        public string ProviderLogo { get; set; }
    }

    public class CardDtoProfile : Profile
    {
        public CardDtoProfile()
        {
            CreateMap<Card, CardDto>();
        }
    }
}
