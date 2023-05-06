﻿using CredentialMangementModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidator
{
    public class Digit : PasswordValidator
    {
        public override ValidationResponse IsValid(string password)
        {
            var response = new ValidationResponse();
            if (password.Any ( c => Char.IsDigit(c)))
            {
                if (_successor != null) return _successor.IsValid(password);
                response.Valid = true;
                return response;
            }
            response.Error = "the password must contain at least two digits";
            return response;
        }
    }
}
