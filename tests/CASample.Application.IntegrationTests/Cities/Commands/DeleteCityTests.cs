using System.Threading.Tasks;
using CASample.Application.Cities.Commands.Create;
using CASample.Application.Cities.Commands.Delete;
using CASample.Application.Common.Exceptions;
using CASample.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static CASample.Application.IntegrationTests.Testing;

namespace CASample.Application.IntegrationTests.Cities.Commands
{
    public class DeleteCityTests : TestBase
    {
        [Test]
        public void ShouldRequireValidCityId()
        {
            var command = new DeleteCityCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteCity()
        {
            await RunAsDefaultUserAsync();

            var city = await SendAsync(new CreateCityCommand("Kayseri"));

            await SendAsync(new DeleteCityCommand
            {
                Id = city.Data.Id
            });

            var list = await FindAsync<City>(city.Data.Id);

            list.Should().BeNull();
        }
    }
}
