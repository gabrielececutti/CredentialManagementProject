using CredentialMangementModels.Entities;
using CredentialMangementModels.Requests;
using CredentialMangementModels.Requests.AccountRequests;
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
        public DefaultResponse<string> PrintAccount(AccountByUsernamePasswordRequest userInput);
        public bool PrintCopyAccount(string fileName);
    }
}
