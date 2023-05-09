using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialMangementModels.Response
{
    public class DefaultResponse<T>
    {
        public T? Data { get; set; }
        public string? Error { get; set; }
    }
}
