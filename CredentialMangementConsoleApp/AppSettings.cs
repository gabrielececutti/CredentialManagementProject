using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialMangementConsoleApp
{
    public class AppSettings
    {
        public List<string>? exclude { get; set; }
        public ConnectionStrings? ConnectionStrings { get; set; }
        public DownloadFolderPaths? DownloadFolderPaths { get; set; }
        public string? EmailPattern { get; set; }
    }
    public class ConnectionStrings
    {
        public string? MyConnectionString { get; set; }
    }

    public class DownloadFolderPaths
    {
        public string? MyPath { get; set; }
    }
}
