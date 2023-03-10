using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OneAppHNI.DanhMuc;

namespace DigitalMap.DanhMuc.Dtos
{
    [AutoMapFrom(typeof(TEST))]
    public class TESTDto : EntityDto<int>
    {
         public string CODE { get; set; }
         public string NAME { get; set; }
         public string DESCRIPTION { get; set; }
         public int TenantId { get; set; }

    }
}
