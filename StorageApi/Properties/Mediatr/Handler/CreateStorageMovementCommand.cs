using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StorageApi.DTO;
using StorageApi.Models;
using StorageApi.Properties.EFCore;

namespace StorageApi.Properties.Mediatr.Handler
{
    public record CreateStorageMovementCommand(CreateStorageMovementDTO Dto) : IRequest<StorageMovementDTO>;

    public class CreateStorageMovementCommandHandler : IRequestHandler<CreateStorageMovementCommand, StorageMovementDTO>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateStorageMovementCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StorageMovementDTO> Handle(CreateStorageMovementCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.StorageItems
                .FirstOrDefaultAsync(i => i.Id == request.Dto.StorageItemId, cancellationToken);

            if (item == null)
            {
                throw new KeyNotFoundException($"Item with ID {request.Dto.StorageItemId} not found.");
            }

            // Update item quantity based on movement type
            switch (request.Dto.Type)
            {
                case MovementType.Receipt:
                    item.Quantity += request.Dto.Quantity;
                    break;
                case MovementType.Consumption:
                    item.Quantity -= request.Dto.Quantity;
                    if (item.Quantity < 0) item.Quantity = 0;
                    break;
                case MovementType.Adjustment:
                    item.Quantity = request.Dto.Quantity;
                    break;
            }

            var movement = _mapper.Map<StorageMovement>(request.Dto);
            _context.StorageMovements.Add(movement);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<StorageMovementDTO>(movement);
        }
    }
}
