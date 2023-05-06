using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialMangementModels.Response
{
    public class ValidationResponse
    {
        public bool Valid { get; set; }
        public string Error { get; set; } = string.Empty;
    }
}
