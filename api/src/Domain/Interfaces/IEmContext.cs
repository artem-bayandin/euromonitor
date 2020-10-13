using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    // TODO: remove EF ref
    public interface IEmContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Subscription> Subscriptions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
