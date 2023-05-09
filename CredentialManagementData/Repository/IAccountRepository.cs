using CredentialMangementModels.Entities;
using CredentialMangementModels.Requests.AccountRequests;
using CredentialMangementModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialManagementData.Repository
{
    public interface IAccountRepository
    {
        public DefaultResponse<Account> GetAccountById(AccountByIdRequest id);
        public DefaultResponse<Account> GetAccountByUsernameAndPassword(AccountByUsernamePasswordRequest accountByUsernamePasswordRequest);
        public DefaultResponse<bool> Insert(Account account);
    }
}
