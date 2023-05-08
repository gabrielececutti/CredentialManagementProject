using CredentialManagementData.PeristenceService;
using CredentialMangamentServices.PeristenceService;
using CredentialMangementModels.Entities;
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

        public DefaultResponse<string> PrintAccount(int number, string password)
        {
            var response = new DefaultResponse<string>();
            var dbResponse = _accountPersistenceServiceDb.GetAccountById(new AccountByIdRequest { Id = number });
            if (dbResponse.Data!= null) 
            {
                var printerResponse = _accountPeristenceServiceFile.Write(dbResponse.Data);
                if (printerResponse.Data != null) response.Data = printerResponse.Data;
                else response.Errors = printerResponse.Errors;
            }else 
            {
                response.Errors = dbResponse.Errors;
            }
            return response;
        }

        public DefaultResponse<bool> PrintCopyAccount(string fileName)
        {
            DefaultResponse<bool> response = new DefaultResponse<bool>();
            var copyFile = $"{fileName}.copy";
            try
            {   
                File.Copy(fileName, copyFile);
                response.Data = true;
            }
            catch (Exception ex) 
            {
                response.Errors.Add(ex.Message);
            }
            return response;
        }
    }
}
