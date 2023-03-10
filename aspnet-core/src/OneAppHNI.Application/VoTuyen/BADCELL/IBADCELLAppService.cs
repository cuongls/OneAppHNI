using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using OneAppHNI.VoTuyen.Dtos;

namespace OneAppHNI.VoTuyen
{
    public interface IBADCELLAppService : IApplicationService
    {
        Task<PagedResultDto<BADCELLDto>> Getall(GetBADCELLs input);
        Task<BADCELLDto> Get(GetBADCELL input);
        void Create(CreateOrEditBADCELL input);
        void Update(CreateOrEditBADCELL input);
        void Delete(long id);
    }
}
