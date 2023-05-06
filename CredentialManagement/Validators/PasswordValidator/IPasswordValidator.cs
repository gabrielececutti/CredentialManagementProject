using CredentialMangementModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.PasswordValidator
{
    public interface IPasswordValidator
    {
        public ValidationResponse IsValid (string password);
        public void SetSuccessor (IPasswordValidator passwordValidator);
    }
}
