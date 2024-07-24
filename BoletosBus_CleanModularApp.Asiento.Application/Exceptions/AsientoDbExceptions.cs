using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModularApp.Asiento.Application.Exceptions
{
    public class AsientoDbExceptions : ArgumentNullException
    {
        public AsientoDbExceptions(string message) : base(message)
        {
        }
    }
}
