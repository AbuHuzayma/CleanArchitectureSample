using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CASample.Application.Cities.Commands.Create;
using CASample.Application.Cities.Commands.Delete;
using CASample.Application.Cities.Commands.Update;
using CASample.Application.Cities.Queries.GetCities;
using CASample.Application.Cities.Queries.GetCityById;
using CASample.Application.Common.Models;
using CASample.Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CASample.Api.Controllers
{
    /// <summary>
    /// Cities
    /// </summary>
    [Authorize]
    public class CitiesController : BaseApiController
    {
        /// <summary>
        /// Get all cities
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<CityDto>>>> GetAllCities(CancellationToken cancellationToken)
        {
            //Cancellation token example.
            return Ok(await Mediator.Send(new GetAllCitiesQuery(), cancellationToken));
        }

        /// <summary>
        /// Get city by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<CityDto>>> GetCityById(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCityByIdQuery { CityId = id }, cancellationToken));
        }

        /// <summary>
        /// Create city
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<CityDto>>> Create(CreateCityCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Update city
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ServiceResult<CityDto>>> Update(UpdateCityCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Delete city by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<CityDto>>> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteCityCommand { Id = id }, cancellationToken));
        }
    }
}