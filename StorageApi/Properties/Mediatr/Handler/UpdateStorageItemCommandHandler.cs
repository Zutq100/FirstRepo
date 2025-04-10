using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StorageApi.DTO;
using StorageApi.Properties.EFCore;

namespace StorageApi.Properties.Mediatr.Handler
{
    public record UpdateStorageItemCommand(int Id, UpdateStorageItemDTO Dto) : IRequest<StorageItemDTO>;

    public class UpdateStorageItemCommandHandler : IRequestHandler<UpdateStorageItemCommand, StorageItemDTO>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateStorageItemCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StorageItemDTO> Handle(UpdateStorageItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.StorageItems
                .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);

            if (item == null)
            {
                throw new KeyNotFoundException($"Item with ID {request.Id} not found.");
            }

            _mapper.Map(request.Dto, item);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<StorageItemDTO>(item);
        }
    }
}
