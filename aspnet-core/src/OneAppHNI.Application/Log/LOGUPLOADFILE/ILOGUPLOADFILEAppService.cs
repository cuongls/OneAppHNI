using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using OneAppHNI.Log.Dtos;
using Microsoft.AspNetCore.Http;

namespace OneAppHNI.Log
{
    public interface ILOGUPLOADFILEAppService : IApplicationService
    {
        Task<PagedResultDto<LOGUPLOADFILEDto>> Getall(GetLOGUPLOADFILEs input);
        Task<LOGUPLOADFILEDto> Get(GetLOGUPLOADFILE input);
        void Create(CreateOrEditLOGUPLOADFILE input);
        void Update(CreateOrEditLOGUPLOADFILE input);
        void Delete(long id);
    }
}
