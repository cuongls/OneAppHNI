using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using OneAppHNI.Log.Dtos;
using System.Collections.Generic;

namespace OneAppHNI.Log
{
    public interface ILOGSENDEMAILAppService : IApplicationService
    {
        Task<PagedResultDto<LOGSENDEMAILDto>> Getall(GetLOGSENDEMAILs input);
        Task<LOGSENDEMAILDto> Get(GetLOGSENDEMAIL input);
        void Create(CreateOrEditLOGSENDEMAIL input);
        void Update(CreateOrEditLOGSENDEMAIL input);
        void Delete(long id);
        void SendEmailVNPT(string yourEmail, string passWord, List<string> lsToEmail, string subjectEmail, string bodyEmail, List<string> lsFilePath);
    }
}
