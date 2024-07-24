using BoletosBus_CleanModularApp.Common.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModularApp.Bus.Domain.Interfaces
{
    public interface IBusRepository : IBaseRepository<Bus.Domain.Entities.Bus, int>
    {
    }
}
