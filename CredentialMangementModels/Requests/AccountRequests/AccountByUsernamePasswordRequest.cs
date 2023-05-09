using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialMangementModels.Requests.AccountRequests
{
    public class AccountByUsernamePasswordRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
