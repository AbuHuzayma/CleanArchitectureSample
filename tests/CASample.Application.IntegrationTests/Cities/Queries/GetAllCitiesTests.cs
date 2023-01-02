using System.Threading.Tasks;
using CASample.Application.Cities.Queries.GetCities;
using CASample.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static CASample.Application.IntegrationTests.Testing;

namespace CASample.Application.IntegrationTests.Cities.Queries
{
    public class GetAllCitiesTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllCities()
        {
            await RunAsDefaultUserAsync();
            
            await AddAsync(new City
            {
                Name = "Manisa",
            });

            var query = new GetAllCitiesQuery();

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Succeeded.Should().BeTrue();
            result.Data.Count.Should().BeGreaterThan(0);
        }
    }
}