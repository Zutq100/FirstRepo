using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StorageApi.DTO;
using StorageApi.Properties.EFCore;

namespace StorageApi.Properties.Mediatr.Request
{
    public record GetStorageMovementQuery(int Id) : IRequest<StorageMovementDTO?>;
    public class GetStorageMovementQueryHandler : IRequestHandler<GetStorageMovementQuery, StorageMovementDTO?>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetStorageMovementQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StorageMovementDTO?> Handle(GetStorageMovementQuery request, CancellationToken cancellationToken)
        {
            var item = await _context.StorageItems
                .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);

            return item == null ? null : _mapper.Map<StorageMovementDTO>(item);
        }
    }
}
