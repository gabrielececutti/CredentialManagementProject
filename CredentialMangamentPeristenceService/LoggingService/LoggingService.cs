using CredentialMangamentServices.PeristenceService;
using CredentialMangementModels.Entities;
using CredentialMangementModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators.EmailValidator;
using Validators.PasswordValidator;

namespace CredentialMangamentServices.LoggerService
{
    public class LoggingService : ILoggingService
    {
        private readonly IAccountPersistenceServiceDb _accountPersistenceServiceDb;
        private readonly IPasswordValidator _passwordValidator;
        private readonly IEmailValidator _emailValidator;

        public LoggingService(IAccountPersistenceServiceDb accountPersistenceServiceDb, IPasswordValidator passwordValidator, IEmailValidator emailValidator)
        {
            _accountPersistenceServiceDb = accountPersistenceServiceDb;
            _passwordValidator = passwordValidator;
            _emailValidator = emailValidator;
        }

        public DefaultResponse<int> LogNewAccount(Account account)
        {
            var logResponse = new DefaultResponse<int>();

            var accountValidation = ExecuteValidation(account);
            if (accountValidation.Data) 
            {
               var dbResponse = _accountPersistenceServiceDb.Insert(account);
               if (dbResponse.Data) logResponse.Data = account.Number;
               else logResponse.Errors = dbResponse.Errors;
            }else
            {
                logResponse.Errors = accountValidation.Errors;
            }
            return logResponse;
        }

        private DefaultResponse<bool> ExecuteValidation (Account account)
        {
            var response = new DefaultResponse<bool>();
            var emailValidation = _emailValidator.IsValid(account.Username);
            var passwordValidation = _passwordValidator.IsValid(account.Password);
            if (emailValidation.Valid && passwordValidation.Valid)
            {
                response.Data = true;
            }else
            {
                response.Errors.Add(emailValidation.Error);
                response.Errors.Add(passwordValidation.Error);
            }
            return response;
        }
    }
}
