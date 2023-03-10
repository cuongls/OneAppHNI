using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using OneAppHNI.DanhMuc;

namespace DigitalMap.DanhMuc.Dtos
{
    [AutoMapFrom(typeof(TEST)), AutoMapTo(typeof(TEST))]
    public class CreateOrEditTEST
    {
        public int Id { get; set; }
        
         public string CODE { get; set; }
         public string NAME { get; set; }
         public string DESCRIPTION { get; set; }
         public int? TenantId { get; set; }

    }
}
