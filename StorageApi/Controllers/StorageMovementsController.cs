using MediatR;
using Microsoft.AspNetCore.Mvc;
using StorageApi.DTO;
using StorageApi.Properties.Mediatr.Handler;
using StorageApi.Properties.Mediatr.Request;

namespace StorageApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StorageMovementsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StorageMovementsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("item/{itemId}")]
        public async Task<ActionResult<IEnumerable<StorageMovementDTO>>> GetMovements(int itemId)
        {
            var query = new GetStorageMovementsQuery(itemId);
            var movements = await _mediator.Send(query);

            return Ok(movements);
        }

        [HttpPost]
        public async Task<ActionResult<StorageMovementDTO>> CreateMovement([FromBody] CreateStorageMovementDTO dto)
        {
            var command = new CreateStorageMovementCommand(dto);
            var movement = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetMovements), new { itemId = movement.StorageItemId }, movement);
        }
    }
}
