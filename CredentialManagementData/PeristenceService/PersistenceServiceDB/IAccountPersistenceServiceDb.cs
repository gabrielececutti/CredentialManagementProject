using CredentialMangementModels.Entities;
using CredentialMangementModels.Requests.AccountRequests;
using CredentialMangementModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialMangamentServices.PeristenceService
{
    public interface IAccountPersistenceServiceDb
    {
        public DefaultResponse<Account> GetAccountById(AccountByIdRequest id);
        public DefaultResponse<bool> Insert(Account account);
    }
}
