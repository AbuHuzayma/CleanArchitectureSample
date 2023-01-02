using System.Threading.Tasks;
using CASample.Domain.Common;

namespace CASample.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
