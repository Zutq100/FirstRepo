using MediatR;
using Microsoft.AspNetCore.Mvc;
using StorageApi.DTO;
using StorageApi.Properties.Mediatr.Handler;
using StorageApi.Properties.Mediatr.Request;

namespace StorageApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StorageItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StorageItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorageItemDTO>>> GetItems(
            [FromQuery] string? search,
            [FromQuery] string? category)
        {
            var query = new GetStorageItemsQuery(search, category);
            var items = await _mediator.Send(query);
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StorageItemDTO>> GetItem(int id)
        {
            var query = new GetStorageItemQuery(id);
            var item = await _mediator.Send(query);

            return item is not null ? Ok(item) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<StorageItemDTO>> CreateItem([FromBody] CreateStorageItemDTO dto)
        {
            var command = new CreateStorageItemCommand(dto);
            var item = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StorageItemDTO>> UpdateItem(int id, [FromBody] UpdateStorageItemDTO dto)
        {
            var command = new UpdateStorageItemCommand(id, dto);
            var item = await _mediator.Send(command);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var command = new DeleteStorageItemCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
