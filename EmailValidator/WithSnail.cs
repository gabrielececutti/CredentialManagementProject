using CredentialMangementModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailValidator
{
    public class WithSnail : EmailValidatorDecorator
    {
        protected string _email;

        public WithSnail(string email)
        {
            _email = email;
        }

        //public override ValidationResponse IsValid()
        //{
        //    var response = new ValidationResponse();
        //    if (IsThisValid().Valid && _validator.IsValid().Valid) response.Valid = true;
        //    else response.Error = $"{IsThisValid().Error}{Environment.NewLine}{_validator.IsValid().Error}";
        //    return response;
        //}

        public override ValidationResponse IsValid()
        {
            var response = new ValidationResponse();
            if (_email.Contains('@')) response.Valid = true;
            else response.Error = "the email must contain @";
            return response;
        }
    }
}
