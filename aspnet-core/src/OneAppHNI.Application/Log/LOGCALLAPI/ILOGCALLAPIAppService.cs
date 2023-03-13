using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using OneAppHNI.Log.Dtos;

namespace OneAppHNI.Log
{
    public interface ILOGCALLAPIAppService : IApplicationService
    {
        Task<PagedResultDto<LOGCALLAPIDto>> Getall(GetLOGCALLAPIs input);
        Task<LOGCALLAPIDto> Get(GetLOGCALLAPI input);
        void Create(CreateOrEditLOGCALLAPI input);
        void Update(CreateOrEditLOGCALLAPI input);
        void Delete(long id);
    }
}
