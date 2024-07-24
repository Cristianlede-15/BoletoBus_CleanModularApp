using Microsoft.EntityFrameworkCore;

namespace BoletosBus_CleanModularApp.Bus.Persistence.Context
{
    public class BusContext : DbContext
    {
        #region"Constructor"
        public BusContext(DbContextOptions<BusContext> options) : base(options)
        {
        }
        #endregion

        #region"Bus DbSet"
        public DbSet<Domain.Entities.Bus> Bus { get; set; }
        #endregion
    }
}
