using System.Threading;
using System.Threading.Tasks;
using CASample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CASample.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<City> Cities { get; set; }

        DbSet<District> Districts { get; set; }

        DbSet<Village> Villages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
