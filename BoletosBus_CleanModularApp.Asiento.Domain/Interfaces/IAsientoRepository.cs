using BoletosBus_CleanModularApp.Common.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModularApp.Asiento.Domain.Interfaces
{
    public interface IAsientoRepository : IBaseRepository<Domain.Entities.Asiento, int>
    {
    }
}
