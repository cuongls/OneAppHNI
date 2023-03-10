﻿using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;


namespace OneAppHNI.VoTuyen.Dtos
{
	[AutoMapFrom(typeof(TRAMLOAITRU))]
    public class TRAMLOAITRUDto : EntityDto<int>
    {
         public string QUANHUYEN { get; set; }
 public double? LATITUDE { get; set; }
 public double? LONGITUDE { get; set; }
 public string LOAITRAM { get; set; }
 public string SITENAME { get; set; }
 public string CELLNAME { get; set; }
 public string CELLNAMEALIAS { get; set; }
 public string TRANGTHAI { get; set; }
 public DateTime? THOIGIAN { get; set; }
 public string GHICHU { get; set; }
        public bool ISACTIVE { get; set; }
        public int? TenantId { get; set; }

    }
}
