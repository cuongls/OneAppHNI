using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;

namespace OneAppHNI.Log.Dtos
{
    [AutoMapFrom(typeof(LOGUPLOADFILE)), AutoMapTo(typeof(LOGUPLOADFILE))]
    public class CreateOrEditLOGUPLOADFILE
    {
        public int Id { get; set; }
        
         public string FILENAME { get; set; }
         public string FILEPATH { get; set; }
         public string DESCRIPTION { get; set; }
         public long? IDUSER { get; set; }
        public string LOAIFILE { get; set; }
        public IFormFile file { get; set; }
        public int? TenantId { get; set; }

    }
}
