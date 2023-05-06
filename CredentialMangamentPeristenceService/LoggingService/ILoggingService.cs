using CredentialMangementModels.Entities;
using CredentialMangementModels.Response;

namespace CredentialMangamentServices.LoggerService
{
    public interface ILoggingService
    {
        public DefaultResponse<int> LogNewAccount(Account account);
    }
}
