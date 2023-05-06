using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialManagementData
{
    public class DatabaseOption
    {
        public string ConnectionString { get; set; }
        public DatabaseOption(string connectionString) => ConnectionString = connectionString;
    }
}
