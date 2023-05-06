using CredentialManagementData.PeristenceService;
using CredentialMangamentServices.PeristenceService;
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

        public DefaultResponse<bool> PrintAccount(int number, string password)
        {
            var response = new DefaultResponse<bool>();
            var dbResponse = _accountPersistenceServiceDb.GetAccountById(new AccountByIdRequest { Id = number });
            if (dbResponse.Data!= null) 
            {
                var printerResponse = _accountPeristenceServiceFile.Write(dbResponse.Data);
                if (printerResponse.Data) response.Data = true;
                else response.Errors = printerResponse.Errors;
            }else 
            {
                response.Errors = dbResponse.Errors;
            }
            return response;
        }
    }
}
