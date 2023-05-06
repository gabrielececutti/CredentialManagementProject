using CredentialManagementData.FileWorking;
using CredentialMangementModels.Entities;
using CredentialMangementModels.Response;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialManagementData.PeristenceService
{
    public class AccountPersistenceServiceFile : IAccountPersistenceServiceFile
    {
        private readonly string _basePath;
        private const string Heading = $"number;username;password;date";

        public AccountPersistenceServiceFile(string basePath) 
        {
            _basePath = basePath;
        }

        public DefaultResponse<bool> Write(Account account)
        {
            var response = new DefaultResponse<bool>();
            var filePathBuilder = new FilePathBuilder(_basePath, account);
            var path = filePathBuilder.GetFilePath();
            var writer = new StreamWriter(path);
            try
            {
                var logger = $"{Heading}{Environment.NewLine}{CsvAccountConverter.Convert(account)}";
                writer.WriteLine(logger);
                writer.Dispose();
                response.Data = true;
            }catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
            }
            return response;
        }
    }
}
