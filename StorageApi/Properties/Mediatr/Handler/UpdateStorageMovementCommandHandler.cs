using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StorageApi.DTO;
using StorageApi.Properties.EFCore;

namespace StorageApi.Properties.Mediatr.Handler
{
    public record UpdateStorageMovementCommand(int Id, UpdateStorageMovementDTO Dto) : IRequest<StorageMovementDTO>;

    public class UpdateStorageMovementCommandHandler : IRequestHandler<UpdateStorageMovementCommand, StorageMovementDTO>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateStorageMovementCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StorageMovementDTO> Handle(UpdateStorageMovementCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.StorageMovements
                .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);

            if (item == null)
            {
                throw new KeyNotFoundException($"Item with ID {request.Id} not found.");
            }

            item.Type = request.Dto.Type;
            item.Quantity = (int)request.Dto.Quantity;
            item.Comment = request.Dto.Comment;
            item.Source = request.Dto.Source;
            item.Destination = request.Dto.Destination;
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<StorageMovementDTO>(item);
        }
    }
}
