using BoletosBus_CleanModularApp.Common.Data.Repository;

namespace BoletosBus_CleanModularApp.Bus.Domain.Interfaces
{
    public interface IBusRepository : IBaseRepository<Bus.Domain.Entities.Bus, int>
    {
    }
}
