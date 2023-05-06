using CredentialMangementModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmailValidator
{
    public class WithUsername : EmailValidatorDecorator
    {
        private const string Pattern = @"^[a-zA-Z0-9._%+-]+@";
        protected IEmailValidator _validator;
        protected string _email;

        public WithUsername(IEmailValidator validator, string email)
        {
            _validator = validator;
            _email = email;
        }

        public override ValidationResponse IsValid()
        {
            var response = new ValidationResponse();
            if (IsThisValid().Valid && _validator.IsValid().Valid) response.Valid = true;
            else response.Error = $"{IsThisValid().Error}, {_validator.IsValid().Error}";
            return response;
        }

        private ValidationResponse IsThisValid()
        {
            var response = new ValidationResponse();
            Regex regex = new Regex(Pattern);
            bool isMatch = regex.IsMatch(_email);
            if (isMatch) response.Valid = true;
            else response.Error = "the email must contain an username";
            return response;
        }
    }
}
