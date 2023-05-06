using CredentialMangementModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialManagementData.FileWorking
{
    public static class CsvAccountConverter
    {
        public static string Convert (Account account)
        {
            return $"{account.Number};{account.Username};{account.Password};{account.Date.Year}-{account.Date.Month}-{account.Date.Day}";
        }
    }
}
