
using FinanceTracker.Application.DTOs;
using FinanceTracker.Application.Features.Cards.Commands;
using FinanceTracker.Domain.Interfaces;
using FinanceTracker.Domain.Models;
using Moq;

namespace FinanceTracker.Application.Tests.Features.Cards
{
    public class CardCommandHandlersTests
    {
        [Fact]
        public async Task AddCardCommandHandler_Should_Call_AddAsync_And_Return_CardDto()
        {
            // Arrange
            var mockRepo = new Mock<ICardRepository>();
            var cardPostDto = new CardPostDto
            {
                Currency = "USD",
                Amount = 100,
                Holder = "Test User",
                Expiry = DateTime.UtcNow.AddYears(1),
                Cvv = "123",
                CurrencyLogo = "usd.png",
                ProviderLogo = "visa.png"
            };
            var userId = 1;
            var handler = new AddCardCommandHandler(mockRepo.Object);

            // Act
            await handler.Handle(new AddCardCommand(cardPostDto, userId), CancellationToken.None);

            // Assert
            mockRepo.Verify(r => r.AddAsync(It.IsAny<Card>(), userId, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateCardCommandHandler_Should_Call_UpdateAsync()
        {
            // Arrange
            var mockRepo = new Mock<ICardRepository>();
            var cardPutDto = new CardPutDto
            {
                Id = 1,
                Currency = "USD",
                Amount = 200,
                Holder = "Test User",
                Expiry = DateTime.UtcNow.AddYears(2),
                Cvv = "321",
                CurrencyLogo = "usd.png",
                ProviderLogo = "visa.png"
            };
            var handler = new UpdateCardCommandHandler(mockRepo.Object);

            // Act
            await handler.Handle(new UpdateCardCommand(cardPutDto), CancellationToken.None);

            // Assert
            mockRepo.Verify(r => r.UpdateAsync(It.Is<Card>(c => c.Id == cardPutDto.Id), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
