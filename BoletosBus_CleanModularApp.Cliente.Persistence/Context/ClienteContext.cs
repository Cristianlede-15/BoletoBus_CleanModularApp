
using Microsoft.EntityFrameworkCore;

namespace BoletosBus_CleanModularApp.Cliente.Persistence.Context
{
    public class ClienteContext : DbContext
    {
        #region "Constructor"
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        {

        }
        #endregion

        #region "Db Set"
        public DbSet<Domain.Entities.Cliente> Cliente { get; set; }
        #endregion
    }
}
