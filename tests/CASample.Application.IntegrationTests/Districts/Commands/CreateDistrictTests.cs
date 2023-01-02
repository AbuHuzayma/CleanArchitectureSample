using System;
using System.Threading.Tasks;
using CASample.Application.Cities.Commands.Create;
using CASample.Application.Common.Exceptions;
using CASample.Application.Districts.Commands.Create;
using CASample.Domain.Entities;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using static CASample.Application.IntegrationTests.Testing;

namespace CASample.Application.IntegrationTests.Districts.Commands
{
    public class CreateDistrictTests
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateDistrictCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();

        }

        [Test]
        public async Task ShouldCreateDistrict()
        {
            var rand = new Random();
            var city = await SendAsync(new CreateCityCommand($"Bursa.{rand.Next()}"));

            var userId = await RunAsDefaultUserAsync();

            var command = new CreateDistrictCommand
            {
                Name = "Karacabey",
                CityId = city.Data.Id
            };

            var result = await SendAsync(command);

            var list = await FindAsync<District>(result.Data.Id);

            list.Should().NotBeNull();
            list.Name.Should().Be(command.Name);
            list.Creator.Should().Be(userId);
            list.CreateDate.Should().BeCloseTo(DateTime.Now, 10.Seconds());
        }
    }
}
