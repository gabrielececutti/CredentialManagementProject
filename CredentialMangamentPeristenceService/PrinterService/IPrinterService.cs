﻿using CredentialMangementModels.Entities;
using CredentialMangementModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialMangamentServices.PrinterService
{
    public interface IPrinterService
    {
        public DefaultResponse<string> PrintAccount(int numbers, string password);
        public DefaultResponse<bool> PrintCopyAccount(string fileName);
    }
}
