using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;


namespace OneAppHNI.DienNang.Dtos
{
    public class CanhBaoDto : EntityDto<int>
    {
        public string MACSHT { get; set; }
        public string TTVT { get; set; }
        public string DOIVT { get; set; }
         public string MUCDICHSD { get; set; }
         public string TENTRAM { get; set; }
         public string LOAIHINHTH { get; set; }
         public string MUCCANHBAO { get; set; }
         public double SODIEN { get; set; }
         public double SODIENTHANGTRUOC { get; set; }
         public double SODIENCUNGKYNAMTRUOC { get; set; }
         public string GHICHU { get; set; }
    }
}
