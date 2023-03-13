using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace OneAppHNI.Log.Dtos
{
    [AutoMapFrom(typeof(LOGSENDEMAIL)), AutoMapTo(typeof(LOGSENDEMAIL))]
    public class CreateOrEditLOGSENDEMAIL
    {
        public int Id { get; set; }
        
         public string EMAILSEND { get; set; }
 public string EMAILNHAN { get; set; }
 public string SUBJECT { get; set; }
 public string BODY { get; set; }
 public string FILEDINHKEM { get; set; }
 public DateTime NGAYGUI { get; set; }
 public long? NGUOIGUI { get; set; }
        public string KETQUA { get; set; }
        public int? TenantId { get; set; }

    }
}
