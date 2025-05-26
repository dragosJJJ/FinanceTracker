using FinanceTracker.Application.DTOs;
using FinanceTracker.Application.Features.Cards.Commands;
using FinanceTracker.Application.Features.Cards.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinSAD.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CardController(IMediator mediator) : ControllerBase
    {
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetCardsByUserId(int userId)
        {
            var cards = await mediator.Send(new GetCardsByUserIdQuery(userId));

            return cards?.Count > 0 ?
                Ok(cards)
                : NotFound("Cards not found.");
        }

        [HttpGet("user/{userId}/history")]
        public async Task<IActionResult> GetCardHistory(int userId)
        {
            var cards = await mediator.Send(new GetCardHistoryByUserIdQuery(userId));

            return cards?.Count > 0 ?
                Ok(cards)
                : NotFound("Cards not found.");
        }

        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody] CardPostDto cardPostDto, int userId)
        {
            if (cardPostDto == null)
            {
                return BadRequest("Invalid card data.");
            }

            var result = await mediator.Send(new AddCardCommand(cardPostDto, userId));

            return CreatedAtAction(nameof(GetCardsByUserId), new { userId = result.Holder }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            await mediator.Send(new DeleteCardCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCard(int id, [FromBody] CardPutDto cardPutDto)
        {
            if (cardPutDto == null || cardPutDto.Id != id)
            {
                return BadRequest("Invalid card data.");
            }

            await mediator.Send(new UpdateCardCommand(cardPutDto));
            return NoContent(); 
        }

    }
}
