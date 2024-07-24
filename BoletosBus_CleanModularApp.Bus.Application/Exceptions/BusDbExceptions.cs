using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModularApp.Bus.Application.Exceptions
{
    public class BusDbExceptions : ArgumentNullException
    {
        public BusDbExceptions(string message) : base(message)
        {
        }
    }
}
