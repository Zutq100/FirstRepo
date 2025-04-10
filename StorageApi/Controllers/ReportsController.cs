using MediatR;
using Microsoft.AspNetCore.Mvc;
using StorageApi.DTO;
using StorageApi.Properties.Mediatr.Request;

namespace StorageApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("inventory")]
        public async Task<ActionResult<InventoryReportDTO>> GetInventoryReport()
        {
            var query = new GetInventoryReportQuery();
            var report = await _mediator.Send(query);

            return Ok(report);
        }
    }
}
