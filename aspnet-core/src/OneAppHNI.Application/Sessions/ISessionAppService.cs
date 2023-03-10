using System.Threading.Tasks;
using Abp.Application.Services;
using OneAppHNI.Sessions.Dto;

namespace OneAppHNI.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
