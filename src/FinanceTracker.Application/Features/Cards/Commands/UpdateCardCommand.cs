using FinanceTracker.Application.DTOs;
using FinanceTracker.Domain.Interfaces;
using FinanceTracker.Domain.Models;
using MediatR;

namespace FinanceTracker.Application.Features.Cards.Commands
{
    public sealed record UpdateCardCommand(CardPutDto CardPutDto) : IRequest<Unit>;

    public class UpdateCardCommandHandler(ICardRepository cardRepository) : IRequestHandler<UpdateCardCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var card = new Card
            {
                Id = request.CardPutDto.Id,
                Currency = request.CardPutDto.Currency,
                Amount = request.CardPutDto.Amount,
                Holder = request.CardPutDto.Holder,
                Expiry = request.CardPutDto.Expiry,
                Cvv = request.CardPutDto.Cvv,
                CurrencyLogo = request.CardPutDto.CurrencyLogo,
                ProviderLogo = request.CardPutDto.ProviderLogo
            };

            await cardRepository.UpdateAsync(card, cancellationToken);
            return Unit.Value;
        }
    }
}
