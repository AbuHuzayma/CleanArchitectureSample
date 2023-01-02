using System.Threading;
using System.Threading.Tasks;
using CASample.Application.Common.Interfaces;
using CASample.Application.Common.Models;
using CASample.Application.Dto;
using CASample.Domain.Entities;
using CASample.Domain.Event;
using MapsterMapper;

namespace CASample.Application.ApplicationUser.Commands.Create
{
    public class CreateUserCommand : ApplicationUserDto, IRequestWrapper<string>
    {
        public string password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandlerWrapper<CreateUserCommand, string>
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IIdentityService identityService, IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _identityService.CreateUserAsync(request.UserName, request.password);
            if (!user.Result.Succeeded)
                return ServiceResult.Failed<string>(user.Result.Errors[0],ServiceError.ForbiddenError);

            return ServiceResult.Success(user.UserId);
        }
    }
}
