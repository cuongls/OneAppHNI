using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;


namespace OneAppHNI.Log.Dtos
{
	[AutoMapFrom(typeof(LOGCALLAPI))]
    public class LOGCALLAPIDto : EntityDto<int>
    {
         public string URL { get; set; }
 public string METHOD { get; set; }
 public string DATA { get; set; }
 public string KETQUA { get; set; }
 public DateTime THOIGIAN { get; set; }
 public long? IDUSER { get; set; }
 public int? TenantId { get; set; }

    }
}
