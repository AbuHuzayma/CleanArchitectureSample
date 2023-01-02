using System.Threading;
using System.Threading.Tasks;
using CASample.Application.Common.Models;
using CASample.Application.ExternalServices.OpenWeather.Request;
using CASample.Application.ExternalServices.OpenWeather.Response;

namespace CASample.Application.Common.Interfaces
{
    public interface IOpenWeatherService
    {
        Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request,
            CancellationToken cancellationToken);
    }
}