using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;


namespace OneAppHNI.Log.Dtos
{
	[AutoMapFrom(typeof(LOGSENDEMAIL))]
    public class LOGSENDEMAILDto : EntityDto<int>
    {
         public string EMAILSEND { get; set; }
 public string EMAILNHAN { get; set; }
 public string SUBJECT { get; set; }
 public string BODY { get; set; }
 public string FILEDINHKEM { get; set; }
 public DateTime NGAYGUI { get; set; }
 public long NGUOIGUI { get; set; }
        public string KETQUA { get; set; }
        public int TenantId { get; set; }

    }
}
