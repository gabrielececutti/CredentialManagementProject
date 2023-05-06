using CredentialManagementData.Repository;
using CredentialMangementModels.Entities;
using CredentialMangementModels.Requests.AccountRequests;
using CredentialMangementModels.Response;

namespace CredentialMangamentServices.PeristenceService
{
    public class AccountPersistenceServiceDb : IAccountPersistenceServiceDb
    {
        private readonly IAccountRepository _accountReposistory;

        public AccountPersistenceServiceDb(IAccountRepository accountReposistory)
        {
            _accountReposistory = accountReposistory;
        }

        public DefaultResponse<Account> GetAccountById(AccountByIdRequest id)
        {
            return _accountReposistory.GetAccountById(id);
        }

        public DefaultResponse<bool> Insert(Account account)
        {
            return _accountReposistory.Insert(account);
        }
    }
}
