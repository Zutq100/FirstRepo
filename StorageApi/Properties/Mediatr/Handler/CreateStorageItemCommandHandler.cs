using AutoMapper;
using MediatR;
using StorageApi.DTO;
using StorageApi.Models;
using StorageApi.Properties.EFCore;

namespace StorageApi.Properties.Mediatr.Handler
{
    public record CreateStorageItemCommand(CreateStorageItemDTO Dto) : IRequest<StorageItemDTO>;

    public class CreateStorageItemCommandHandler : IRequestHandler<CreateStorageItemCommand, StorageItemDTO>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateStorageItemCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StorageItemDTO> Handle(CreateStorageItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<StorageItem>(request.Dto);

            _context.StorageItems.Add(item);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<StorageItemDTO>(item);
        }
    }
}
