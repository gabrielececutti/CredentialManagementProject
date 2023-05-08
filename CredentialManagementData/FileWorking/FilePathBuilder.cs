using CredentialMangementModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CredentialManagementData.FileWorking
{
    public static class FilePathBuilder
    {
        public static string GetFilePath(string _folderBasePath, Account account)
        {
            var fileName = $"{account.Number}-{account.Date.Year}-{account.Date.Month}-{account.Date.Day}";
            return Path.Combine(_folderBasePath, fileName);
        }
    }
}
