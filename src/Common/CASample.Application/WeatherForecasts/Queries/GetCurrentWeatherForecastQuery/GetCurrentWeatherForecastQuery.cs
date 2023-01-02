using System.Threading;
using System.Threading.Tasks;
using CASample.Application.Common.Interfaces;
using CASample.Application.Common.Models;
using CASample.Application.Dto;
using CASample.Application.ExternalServices.OpenWeather.Request;
using MapsterMapper;

namespace CASample.Application.WeatherForecasts.Queries.GetCurrentWeatherForecastQuery
{
    public class GetCurrentWeatherForecastQuery : IRequestWrapper<CurrentWeatherForecastDto>
    {
        public string Q { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public int Id { get; set; }
    }

    public class GetCurrentWeatherForecastQueryHandler : IRequestHandlerWrapper<GetCurrentWeatherForecastQuery, CurrentWeatherForecastDto>
    {
        private readonly IOpenWeatherService _openWeatherService;
        private readonly IMapper _mapper;

        public GetCurrentWeatherForecastQueryHandler(IOpenWeatherService openWeatherService, IMapper mapper)
        {
            _openWeatherService = openWeatherService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CurrentWeatherForecastDto>> Handle(GetCurrentWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var openWeatherRequest = _mapper.Map<OpenWeatherRequest>(request);

            var result = await _openWeatherService.GetCurrentWeatherForecast(openWeatherRequest, cancellationToken);

            return result.Succeeded
                ? ServiceResult.Success(_mapper.Map<CurrentWeatherForecastDto>(result.Data))
                : ServiceResult.Failed<CurrentWeatherForecastDto>(ServiceError.ServiceProvider);
        }
    }
}