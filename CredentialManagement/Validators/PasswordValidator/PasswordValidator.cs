using CredentialMangementModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.PasswordValidator
{
    public abstract class PasswordValidator : IPasswordValidator
    {
        protected IPasswordValidator _successor;

        public abstract ValidationResponse IsValid(string password);

        public void SetSuccessor(IPasswordValidator passwordValidator)
        {
            _successor = passwordValidator;
        }
    }
}
