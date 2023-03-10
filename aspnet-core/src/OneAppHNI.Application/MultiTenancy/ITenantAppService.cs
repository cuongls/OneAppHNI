using Abp.Application.Services;
using OneAppHNI.MultiTenancy.Dto;

namespace OneAppHNI.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

