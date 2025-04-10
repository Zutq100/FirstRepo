using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StorageApi.DTO;
using StorageApi.Properties.EFCore;

namespace StorageApi.Properties.Mediatr.Request
{
    public record GetInventoryReportQuery : IRequest<InventoryReportDTO>;

    public class GetInventoryReportQueryHandler : IRequestHandler<GetInventoryReportQuery, InventoryReportDTO>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetInventoryReportQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InventoryReportDTO> Handle(GetInventoryReportQuery request, CancellationToken cancellationToken)
        {
            var items = await _context.StorageItems.ToListAsync(cancellationToken);

            var lowStockItems = items
                .Where(i => i.MinimumStockLevel.HasValue && i.Quantity < i.MinimumStockLevel)
                .Select(i => new StockLevelDTO(
                    i.Id,
                    i.Name,
                    i.ArticleNumber,
                    i.Quantity,
                    i.MinimumStockLevel,
                    i.MaximumStockLevel));

            var overstockedItems = items
                .Where(i => i.MaximumStockLevel.HasValue && i.Quantity > i.MaximumStockLevel)
                .Select(i => new StockLevelDTO(
                    i.Id,
                    i.Name,
                    i.ArticleNumber,
                    i.Quantity,
                    i.MinimumStockLevel,
                    i.MaximumStockLevel));

            return new InventoryReportDTO(
                items.Count,
                items.Sum(i => i.Quantity),
                items.Sum(i => i.Price * i.Quantity),
                lowStockItems,
                overstockedItems);
        }
    }
}