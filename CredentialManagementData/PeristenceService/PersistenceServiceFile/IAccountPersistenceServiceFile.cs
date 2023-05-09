using CredentialMangementModels.Entities;
using CredentialMangementModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialManagementData.PeristenceService
{
    public interface IAccountPersistenceServiceFile
    {
        public string Write(Account account);
    }
}
