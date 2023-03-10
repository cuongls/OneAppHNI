using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.IO;
using System.Net;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using OneAppHNI.Log;
using OneAppHNI.VoTuyen;
using OneAppHNI.Log.Dtos;
using Newtonsoft.Json;

namespace OneAppHNI.Api
{
    public class ApiDHTT : ApplicationService, IApiDHTT
    {
        private readonly IRepository<LOGCALLAPI, long> _initLogCellAPI;
        public ApiDHTT(IRepository<LOGCALLAPI, long> initLogCellAPI)
        {
            _initLogCellAPI = initLogCellAPI;
        }
        public string CallApi(string url, string method, string authen, string jsonContent)
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(url);
            //client.DefaultRequestHeaders.Add("x-api-key", "8BqTENj2LPs3u28M");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string description = string.Empty;
            string ketqua = string.Empty;
            try
            {
                if (method == "POST")
                {
                    System.Net.Http.HttpContent content = new StringContent(jsonContent, UTF8Encoding.UTF8, "application/json");
                    HttpResponseMessage messge = client.PostAsync(url, content).Result;
                    if (messge.IsSuccessStatusCode)
                    {
                        string result = messge.Content.ReadAsStringAsync().Result;
                        description = result;
                        ketqua = result;
                    }
                }
                if (method == "GET")
                {
                    HttpResponseMessage messge = client.GetAsync(url + jsonContent).Result;
                    if (messge.IsSuccessStatusCode)
                    {
                        string result = messge.Content.ReadAsStringAsync().Result;
                        description = result;
                        ketqua = "Call Success";
                    }
                }
            }catch(Exception ex)
            {
                ketqua = ex.Message;
            }
            LOGCALLAPI log = new LOGCALLAPI();
            log.URL = url;
            log.METHOD = method;
            log.DATA = jsonContent;
            log.TenantId = AbpSession.TenantId;
            log.IDUSER = AbpSession.UserId;
            log.THOIGIAN = DateTime.Now;
            log.KETQUA = ketqua;
            _initLogCellAPI.Insert(log);

            return description;
        }
    }
}
