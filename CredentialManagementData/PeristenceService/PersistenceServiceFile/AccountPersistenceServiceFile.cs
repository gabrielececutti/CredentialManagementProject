﻿using CredentialManagementData.FileWorking;
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

        public DefaultResponse<string> Write(Account account)
        {
            var response = new DefaultResponse<string>();
            var path = FilePathBuilder.GetFilePath(_basePath, account);
            var logger = $"{Heading}{Environment.NewLine}{CsvAccountConverter.Convert(account)}";
            try
            {
                File.WriteAllText(path, logger);
                response.Data = path;
            }catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
            }
            return response;
        }
    }
}
