using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
