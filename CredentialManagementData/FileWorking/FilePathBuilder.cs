using CredentialMangementModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CredentialManagementData.FileWorking
{
    public class FilePathBuilder
    {
        private readonly string _folderBasePath;
        private readonly Account _account;

        public FilePathBuilder(string folderBasePath, Account account)
        {
            _folderBasePath = folderBasePath;
            _account= account;
        }

        public string GetFilePath()
        {
            var fileName = $"{_account.Number}-{_account.Date.Year}-{_account.Date.Month}-{_account.Date.Day}";
            return Path.Combine(_folderBasePath, fileName);
        }
    }
}
