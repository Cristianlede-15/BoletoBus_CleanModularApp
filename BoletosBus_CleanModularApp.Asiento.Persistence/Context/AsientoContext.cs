using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModularApp.Asiento.Persistence.Context
{
    public class AsientoContext : DbContext
    {
        #region "Constructor"
        public AsientoContext(DbContextOptions<AsientoContext> options) : base(options)
        {
        }
        #endregion

        #region"DbSet"
        public DbSet<Domain.Entities.Asiento> Asiento { get; set; }
        #endregion
    }
}
