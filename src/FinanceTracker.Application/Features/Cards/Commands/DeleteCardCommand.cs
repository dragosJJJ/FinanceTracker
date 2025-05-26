using FinanceTracker.Domain.Interfaces;
using MediatR;

namespace FinanceTracker.Application.Features.Cards.Commands
{
    public sealed record DeleteCardCommand(int id) : IRequest<Unit>;
    public class DeleteCardCommandHandler(
        ICardRepository cardRepository
    ) : IRequestHandler<DeleteCardCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            await cardRepository.DeleteAsync(request.id, cancellationToken);
            return Unit.Value;
        }
    }
}
