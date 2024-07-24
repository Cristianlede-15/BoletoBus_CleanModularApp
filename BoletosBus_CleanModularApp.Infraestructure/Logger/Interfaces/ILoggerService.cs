﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModularApp.Infraestructure.Logger.Interfaces
{
    public interface ILoggerService
    {
        void LogInformation(string message);
        void LogError(string message);
    }
}