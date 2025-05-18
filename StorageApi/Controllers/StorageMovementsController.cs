using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<StorageMovementDTO>> GetItem(int id)
        {
            var query = new GetStorageMovementQuery(id);
            var item = await _mediator.Send(query);

            return item is not null ? Ok(item) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<StorageMovementDTO>> CreateMovement([FromBody] CreateStorageMovementDTO dto)
        {
            var command = new CreateStorageMovementCommand(dto);
            var movement = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetMovements), new { itemId = movement.StorageItemId }, movement);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<StorageMovementDTO>> UpdateMovement(int id, [FromBody] UpdateStorageMovementDTO dto)
        {
            var command = new UpdateStorageMovementCommand(id, dto);
            var movement = await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StorageMovementDTO>> DeleteMovement(int id)
        {
            var command = new DeleteStorageMovementCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
