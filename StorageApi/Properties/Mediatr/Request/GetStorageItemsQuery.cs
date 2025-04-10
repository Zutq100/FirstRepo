using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StorageApi.DTO;
using StorageApi.Properties.EFCore;

namespace StorageApi.Properties.Mediatr.Request
{
    public record GetStorageItemsQuery(string? SearchTerm, string? Category) : IRequest<IEnumerable<StorageItemDTO>>;

    public class GetStorageItemsQueryHandler : IRequestHandler<GetStorageItemsQuery, IEnumerable<StorageItemDTO>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetStorageItemsQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StorageItemDTO>> Handle(GetStorageItemsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.StorageItems.AsQueryable();

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(i =>
                    i.Name.Contains(request.SearchTerm) ||
                    i.ArticleNumber.Contains(request.SearchTerm) ||
                    i.Description != null && i.Description.Contains(request.SearchTerm));
            }

            if (!string.IsNullOrEmpty(request.Category))
            {
                query = query.Where(i => i.Category == request.Category);
            }

            var items = await query.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<StorageItemDTO>>(items);
        }
    }
}
