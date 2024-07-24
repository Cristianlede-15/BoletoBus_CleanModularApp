using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModularApp.Cliente.Application.Exceptions
{
    public class ClienteDbExceptions : ArgumentNullException
    {
        public ClienteDbExceptions(string message) : base(message)
        {
        }
    }
}
