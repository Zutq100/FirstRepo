using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StorageApi.DTO;
using StorageApi.Properties.EFCore;

namespace StorageApi.Properties.Mediatr.Request
{
    public record GetStorageItemQuery(int Id) : IRequest<StorageItemDTO?>;

    public class GetStorageItemQueryHandler : IRequestHandler<GetStorageItemQuery, StorageItemDTO?>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetStorageItemQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StorageItemDTO?> Handle(GetStorageItemQuery request, CancellationToken cancellationToken)
        {
            var item = await _context.StorageItems
                .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);

            return item == null ? null : _mapper.Map<StorageItemDTO>(item);
        }
    }
}
