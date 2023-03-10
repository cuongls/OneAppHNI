using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace OneAppHNI.DienNang.Dtos
{
    [AutoMapFrom(typeof(DIENNANG)), AutoMapTo(typeof(DIENNANG))]
    public class CreateOrEditDIENNANG
    {
        public long Id { get; set; }
        
         public string MACSHT { get; set; }
         public string TTVT { get; set; }
         public string DOIVT { get; set; }
         public string MUCDICHSD { get; set; }
         public string TENTRAM { get; set; }
         public string LOAIHINHTH { get; set; }
         public double SODIEN { get; set; }
         public double TIENDIEN { get; set; }
         public double CPVANHANH { get; set; }
         public double CPTHUEHATANG { get; set; }
         public double CPLAODONG { get; set; }
         public double CPSUACHUA { get; set; }
         public double CPKHAC { get; set; }
         public string MAHOADON { get; set; }
         public string CHUNGCSHT { get; set; }
         public string GHICHU { get; set; }
         public string TRANGTHAI { get; set; }
         public string NETXXACNHAN { get; set; }
        public int NGAYBAOCAO { get; set; }
        public int THANGBAOCAO { get; set; }
        public int NAMBAOCAO { get; set; }
        public int? TenantId { get; set; }
    }
}
