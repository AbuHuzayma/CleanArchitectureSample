using System.Threading;
using System.Threading.Tasks;
using CASample.Application.ApplicationUser.Commands.Create;
using CASample.Application.ApplicationUser.Queries.GetToken;
using CASample.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace CASample.Api.Controllers
{
    /// <summary>
    /// Login
    /// </summary>
    public class LoginController : BaseApiController
    {
        /// <summary>
        /// Login and get JWT token email: test@test.com password: Matech_1850
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<LoginResponse>>> Login(GetTokenQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }
        /// <summary>
        /// CreateUser
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult<ServiceResult<string>>> Create(CreateUserCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
    }
}
