using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CASample.Application.Common.Interfaces;
using CASample.Application.Common.Models;
using CASample.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CASample.Application.Cities.EventHandler
{
    public class CityActivatedEventHandler : INotificationHandler<DomainEventNotification<CityActivatedEvent>>
    {
        private readonly ILogger<CityActivatedEventHandler> _logger;
        private readonly IEmailService _emailService;

        public CityActivatedEventHandler(ILogger<CityActivatedEventHandler> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public async Task Handle(DomainEventNotification<CityActivatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("CASample CASample.Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            if (domainEvent.City != null)
            {
                await _emailService.SendAsync(new EmailRequest
                {
                    Subject = domainEvent.City.Name + " is activated.",
                    Body = "City is activated successfully.",
                    FromDisplayName = "Clean Architecture",
                    FromMail = "test@test.com",
                    ToMail = new List<string> { "to@test.com" }
                });
            }
        }
    }
}
