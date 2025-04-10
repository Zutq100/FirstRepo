using MediatR;
using Microsoft.EntityFrameworkCore;
using StorageApi.Properties.EFCore;

namespace StorageApi.Properties.Mediatr.Handler
{
    public record DeleteStorageItemCommand(int Id) : IRequest;

    public class DeleteStorageItemCommandHandler : IRequestHandler<DeleteStorageItemCommand>
    {
        private readonly AppDbContext _context;

        public DeleteStorageItemCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteStorageItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.StorageItems
                .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);

            if (item != null)
            {
                _context.StorageItems.Remove(item);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
