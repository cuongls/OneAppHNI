using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using OneAppHNI.VoTuyen.Dtos;

namespace OneAppHNI.VoTuyen
{
    public interface ITRAMLOAITRUAppService : IApplicationService
    {
        Task<PagedResultDto<TRAMLOAITRUDto>> Getall(GetTRAMLOAITRUs input);
        Task<TRAMLOAITRUDto> Get(GetTRAMLOAITRU input);
        void Create(CreateOrEditTRAMLOAITRU input);
        void Update(CreateOrEditTRAMLOAITRU input);
        void Delete(long id);
    }
}
