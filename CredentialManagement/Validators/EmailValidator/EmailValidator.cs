using CredentialMangementModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validators.EmailValidator
{
    public class EmailValidator : IEmailValidator
    {
        private readonly string _pattern;

        public EmailValidator (string pattern)
        {
            _pattern = pattern;
        }

        public ValidationResponse IsValid(string email)
        {
            var response = new ValidationResponse();
            var regex = new Regex(_pattern);
            if (regex.IsMatch(email)) response.Valid = true;
            else response.Error = "email not valid";
            return response;
        }
    }
}
