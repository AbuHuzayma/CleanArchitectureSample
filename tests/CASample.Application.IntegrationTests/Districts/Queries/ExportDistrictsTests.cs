using System;
using System.Threading.Tasks;
using CASample.Application.Cities.Commands.Create;
using CASample.Application.Common.Exceptions;
using CASample.Application.Common.Security;
using CASample.Application.Districts.Commands.Create;
using CASample.Application.Districts.Queries;
using FluentAssertions;
using NUnit.Framework;

namespace CASample.Application.IntegrationTests.Districts.Queries
{
    using static Testing;

    public class ExportDistrictsTests : TestBase
    {
        [Test]
        public void ShouldDenyAnonymousUser()
        {
            var query = new ExportDistrictsQuery();

            query.GetType().Should().BeDecoratedWith<AuthorizeAttribute>();

            FluentActions.Invoking(() =>
                SendAsync(query)).Should().ThrowAsync<UnauthorizedAccessException>();
        }

        [Test]
        public async Task ShouldDenyNonAdministrator()
        {
            await RunAsDefaultUserAsync();

            var query = new ExportDistrictsQuery();

            await FluentActions.Invoking(() =>
                SendAsync(query)).Should().ThrowAsync<ForbiddenAccessException>();
        }

        [Test]
        public async Task ShouldAllowAdministrator()
        {
            await RunAsAdministratorAsync();

            var city = await SendAsync(new CreateCityCommand("Çanakkale"));

            var result = await SendAsync(new CreateDistrictCommand
            {
                Name = "Çan",
                CityId = city.Data.Id
            });

            var query = new ExportDistrictsQuery
            {
                CityId = result.Data.Id
            };

            await FluentActions.Invoking(() => SendAsync(query))
                .Should().NotThrowAsync();
        }
    }
}
