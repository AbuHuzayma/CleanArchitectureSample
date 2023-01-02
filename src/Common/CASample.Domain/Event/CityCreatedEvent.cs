using CASample.Domain.Common;
using CASample.Domain.Entities;

namespace CASample.Domain.Event
{
    public class CityCreatedEvent : DomainEvent
    {
        public CityCreatedEvent(City city)
        {
            City = city;
        }

        public City City { get; }
    }
}
