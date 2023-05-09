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

            var emailValidation = _emailValidator.IsValid(account.Username);
            if (!emailValidation.Valid)
            {
                logResponse.Error = emailValidation.Error;
                return logResponse;
            }

            var passwordValidation = _passwordValidator.IsValid(account.Password);
            if (!passwordValidation.Valid)
            {
                logResponse.Error = passwordValidation.Error;
                return logResponse;
            }

            var dbResponse = _accountPersistenceServiceDb.Insert(account);
            if (!dbResponse.Data)
            {
                logResponse.Error = dbResponse.Error;
            }
            logResponse.Data = account.Number;
            return logResponse;
        }
    }
}
