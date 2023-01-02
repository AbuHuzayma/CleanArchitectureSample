using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CASample.Application.Common.Mapping;
using CASample.Application.Common.Interfaces;
using CASample.Application.Common.Models;
using CASample.Application.Dto;
using Mapster;
using MapsterMapper;

namespace CASample.Application.Villages.Queries.GetVillagesWithPagination
{
    public class GetAllVillagesWithPaginationQuery : IRequestWrapper<PaginatedList<VillageDto>>
    {
        public int DistrictId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetAllVillagesWithPaginationQueryHandler : IRequestHandlerWrapper<GetAllVillagesWithPaginationQuery, PaginatedList<VillageDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllVillagesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<PaginatedList<VillageDto>>> Handle(GetAllVillagesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            PaginatedList<VillageDto> list = await _context.Villages
                .Where(x => x.DistrictId == request.DistrictId)
                .OrderBy(o => o.Name)
                .ProjectToType<VillageDto>(_mapper.Config)
                .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);

            return list.Items.Any() ? ServiceResult.Success(list) : ServiceResult.Failed<PaginatedList<VillageDto>>(ServiceError.NotFound);
        }
    }
}
