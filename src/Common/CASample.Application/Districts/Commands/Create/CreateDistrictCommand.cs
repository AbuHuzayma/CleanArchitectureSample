using System.Threading;
using System.Threading.Tasks;
using CASample.Application.Common.Interfaces;
using CASample.Application.Common.Models;
using CASample.Application.Dto;
using CASample.Domain.Entities;
using MapsterMapper;

namespace CASample.Application.Districts.Commands.Create
{
    public class CreateDistrictCommand : IRequestWrapper<DistrictDto>
    {
        public string Name { get; set; }

        public int CityId { get; set; }
    }

    public class CreateDistrictCommandHandler : IRequestHandlerWrapper<CreateDistrictCommand, DistrictDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateDistrictCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<DistrictDto>> Handle(CreateDistrictCommand request, CancellationToken cancellationToken)
        {
            var entity = new District
            {
                Name = request.Name,
                CityId = request.CityId
            };

            await _context.Districts.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<DistrictDto>(entity));
        }
    }
}
