using MediatR;
using Microsoft.EntityFrameworkCore;
using StorageApi.Properties.EFCore;

namespace StorageApi.Properties.Mediatr.Handler
{
        public record DeleteStorageMovementCommand(int Id) : IRequest;

        public class DeleteStorageMovementCommandHandler : IRequestHandler<DeleteStorageMovementCommand>
        {
            private readonly AppDbContext _context;

            public DeleteStorageMovementCommandHandler(AppDbContext context)
            {
                _context = context;
            }

            public async Task Handle(DeleteStorageMovementCommand request, CancellationToken cancellationToken)
            {
                var item = await _context.StorageMovements
                    .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);

                if (item != null)
                {
                    _context.StorageMovements.Remove(item);
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }
        }
}
