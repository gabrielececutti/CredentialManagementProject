using CredentialMangementModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidator
{
    public class SpecialChar : PasswordValidator
    {
        public override ValidationResponse IsValid(string password)
        {
            var response = new ValidationResponse();
            if (password.Any(c => !Char.IsLetterOrDigit(c)))
            {
                if (_successor != null) return _successor.IsValid(password);
                response.Valid = true;
                return response;
            };
            response.Error = "the password must contain at least one special character";
            return response;
        }
    }
}
