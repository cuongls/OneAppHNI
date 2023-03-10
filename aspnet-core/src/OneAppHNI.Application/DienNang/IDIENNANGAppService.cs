using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using OneAppHNI.DienNang.Dtos;
using System.Collections.Generic;

namespace OneAppHNI.DienNang
{
    public interface IDIENNANGAppService : IApplicationService
    {
        Task<PagedResultDto<DIENNANGDto>> Getall(GetDIENNANGs input);
        Task<DIENNANGDto> Get(GetDIENNANG input);
        void Create(CreateOrEditDIENNANG input);
        void Update(CreateOrEditDIENNANG input);
        void Delete(long id);
        List<CanhBaoDto> SendEmail(int thang, int nam, int muccanhbaothuong, int muccanhbaokhan);
    }
}
