using CredentialManagementData.PeristenceService;
using CredentialMangamentServices.PeristenceService;
using CredentialMangementModels.Entities;
using CredentialMangementModels.Requests;
using CredentialMangementModels.Requests.AccountRequests;
using CredentialMangementModels.Response;

namespace CredentialMangamentServices.PrinterService
{
    public class PrinterService : IPrinterService
    {
        private readonly IAccountPersistenceServiceFile _accountPeristenceServiceFile;
        private readonly IAccountPersistenceServiceDb _accountPersistenceServiceDb;

        public PrinterService(IAccountPersistenceServiceFile accountPeristenceServiceFile, IAccountPersistenceServiceDb accountPersistenceServiceDb)
        {
            _accountPeristenceServiceFile = accountPeristenceServiceFile;
            _accountPersistenceServiceDb = accountPersistenceServiceDb;
        }

        public DefaultResponse<string> PrintAccount(AccountByUsernamePasswordRequest userInput)
        {
            var response = new DefaultResponse<string>();
            var dbResponse = _accountPersistenceServiceDb.GetAccountByUsernameAndPassword(userInput);
            if (dbResponse.Data!= null) 
            {
                var printerResponse = _accountPeristenceServiceFile.Write(dbResponse.Data);
                if (!string.IsNullOrEmpty(printerResponse)) response.Data = printerResponse;
                else response.Error = "unable to print the file";
            }
            else 
            {
                response.Error = "the account dose not exist";
            }
            return response;
        }

        public bool PrintCopyAccount(string fileName)
        {
            var copyFile = $"{fileName}.copy";
            try
            {   
                File.Copy(fileName, copyFile);
            }
            catch (Exception) 
            {
                return false;
            }
            return true;
        }
    }
}
