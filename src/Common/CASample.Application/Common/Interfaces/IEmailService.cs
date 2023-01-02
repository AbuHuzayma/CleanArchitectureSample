using System.Threading.Tasks;
using CASample.Application.Common.Models;

namespace CASample.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
