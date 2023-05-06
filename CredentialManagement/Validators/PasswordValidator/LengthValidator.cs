using CredentialMangementModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.PasswordValidator
{
    public class LengthValidator : PasswordValidator
    {
        public override ValidationResponse IsValid(string password)
        {
            var response = new ValidationResponse();
            if (password.Length >= 7)
            {
                if (_successor != null) return _successor.IsValid(password);
                response.Valid = true;
                return response;
            }
            response.Error = "the password must be at least seven characters long";
            return response;
        }
    }
}
