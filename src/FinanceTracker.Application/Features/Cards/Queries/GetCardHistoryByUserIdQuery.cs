using FinanceTracker.Application.DTOs;
using FinanceTracker.Domain.Interfaces;
using MediatR;

namespace FinanceTracker.Application.Features.Cards.Queries
{
    public sealed record GetCardHistoryByUserIdQuery(int userId) : IRequest<List<CardHistoryDto>>;

    internal class GetCardHistoryByUserIdQueryHandler(
        ICardRepository cardRepository
    ) : IRequestHandler<GetCardHistoryByUserIdQuery, List<CardHistoryDto>>
    {
        public async Task<List<CardHistoryDto>> Handle(GetCardHistoryByUserIdQuery request, CancellationToken cancellationToken)
        {
            var cards = await cardRepository.GetAllByUserIdAsync(request.userId);

            var cardHistories = cards.Select(card =>
            {
                var cardHistoryDto = new CardHistoryDto
                {
                    Label = card.Currency,
                    Data = card.AmountHistory
                        .OrderBy(h => h.Month)
                        .Select(h => h.Amount)
                        .ToList()
                };

                cardHistoryDto.SetBorderColor(card.Currency);

                return cardHistoryDto;
            }).ToList();

            return cardHistories;
        }
    }
}
