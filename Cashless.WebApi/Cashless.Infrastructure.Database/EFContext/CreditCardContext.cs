using Cashless.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Cashless.Infrastructure.Database.EFContext
{
    public class CreditCardContext : DbContext
    {
        public CreditCardContext(DbContextOptions<CreditCardContext> options)
            : base(options)
        {
        }

        public DbSet<CreditCard> Cards { get; set; }
    }
}
