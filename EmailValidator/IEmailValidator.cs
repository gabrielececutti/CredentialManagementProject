﻿using CredentialMangementModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailValidator
{
    public interface IEmailValidator
    {
        public ValidationResponse IsValid (string email);
    }
}
