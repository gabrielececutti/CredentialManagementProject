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
        public List<string>? Errors { get; set; } = new List<string>();
    }
}
