namespace FinanceTracker.API.Controllers
{
    public class TransactionsController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class TransactionsController : ApiControllerBase
        {
            [HttpGet]
            public async Task<ActionResult<List<TransactionDto>>> GetAll()
            {
                var result = await Mediator.Send(new GetTransactionsQuery());

                if (!result.Succeeded)
                    return BadRequest(result.Errors);

                return Ok(result.Data);
            }
        }
    }
}
