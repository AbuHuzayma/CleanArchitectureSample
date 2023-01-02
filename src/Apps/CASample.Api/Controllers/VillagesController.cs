using System.Threading;
using System.Threading.Tasks;
using CASample.Application.Common.Models;
using CASample.Application.Dto;
using CASample.Application.Villages.Queries.GetVillagesWithPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CASample.Api.Controllers
{
    /// <summary>
    /// Villages
    /// </summary>
    [Authorize]
    public class VillagesController : BaseApiController
    {
        /// <summary>
        /// Get all villages with pagination
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<PaginatedList<VillageDto>>>> GetAllVillagesWithPagination(GetAllVillagesWithPaginationQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }
    }
}
