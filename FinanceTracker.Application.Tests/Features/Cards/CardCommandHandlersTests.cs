
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

        [Fact]
        public async Task GetCardsByUserIdQueryHandler_Should_Return_Cards_List()
        {
            // Arrange
            var mockRepo = new Mock<ICardRepository>();
            var userId = 1;
            var cards = new List<Card>
            {
                new Card { Id = 1, Holder = "Test User", Currency = "USD", Amount = 100 },
                new Card { Id = 2, Holder = "Test User", Currency = "EUR", Amount = 200 }
            };
            mockRepo.Setup(r => r.GetByUserIdAsync(userId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(cards);

            var handler = new GetCardsByUserIdQueryHandler(mockRepo.Object);

            // Act
            var result = await handler.Handle(new GetCardsByUserIdQuery(userId), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            mockRepo.Verify(r => r.GetByUserIdAsync(userId, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteCardCommandHandler_Should_Call_DeleteAsync()
        {
            // Arrange
            var mockRepo = new Mock<ICardRepository>();
            var cardId = 1;
            var handler = new DeleteCardCommandHandler(mockRepo.Object);

            // Act
            await handler.Handle(new DeleteCardCommand(cardId), CancellationToken.None);

            // Assert
            mockRepo.Verify(r => r.DeleteAsync(cardId, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
