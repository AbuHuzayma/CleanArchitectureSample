using System.Threading;
using System.Threading.Tasks;
using CASample.Application.Common.Interfaces;
using CASample.Application.Common.Mapping;
using CASample.Application.Common.Models;
using CASample.Application.ExternalServices.OpenWeather.Request;
using CASample.Application.ExternalServices.OpenWeather.Response;
using CASample.Domain.Enums;

namespace CASample.Infrastructure.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly IHttpClientHandler _httpClient;

        private string ClientApi { get; } = "open-weather-api";

        public OpenWeatherService(IHttpClientHandler httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request, CancellationToken cancellationToken)
        {
            return await _httpClient.GenericRequest<OpenWeatherRequest, OpenWeatherResponse>(ClientApi, string.Concat("weather?", StringExtensions
                .ParseObjectToQueryString(request, true)), cancellationToken, MethodType.Get, request);
        }
    }
}