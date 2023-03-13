using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;

namespace OneAppHNI.Log.Dtos
{
    [AutoMapFrom(typeof(LOGUPLOADFILE))]
    public class LOGUPLOADFILEDto : EntityDto<int>
    {
         public string FILENAME { get; set; }
         public string FILEPATH { get; set; }
         public string DESCRIPTION { get; set; }
         public long? IDUSER { get; set; }
        public string LOAIFILE { get; set; }
        public DateTime CreationTime { get; set; }
        public int? TenantId { get; set; }

    }
}
