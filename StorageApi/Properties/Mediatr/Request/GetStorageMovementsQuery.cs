using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StorageApi.DTO;
using StorageApi.Properties.EFCore;

namespace StorageApi.Properties.Mediatr.Request
{
    public record GetStorageMovementsQuery(int ItemId) : IRequest<IEnumerable<StorageMovementDTO>>;

    public class GetStorageMovementsQueryHandler : IRequestHandler<GetStorageMovementsQuery, IEnumerable<StorageMovementDTO>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetStorageMovementsQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StorageMovementDTO>> Handle(GetStorageMovementsQuery request, CancellationToken cancellationToken)
        {
            var movements = await _context.StorageMovements
                .Include(m => m.StorageItem)
                .Where(m => m.StorageItemId == request.ItemId)
                .OrderByDescending(m => m.MovementDate)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<StorageMovementDTO>>(movements);
        }
    }
}
