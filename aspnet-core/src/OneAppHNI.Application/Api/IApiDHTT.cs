using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneAppHNI.Api
{
    public interface IApiDHTT : IApplicationService
    {
        string CallApi(string url, string method, string authen, string jsonContent);
    }
}
