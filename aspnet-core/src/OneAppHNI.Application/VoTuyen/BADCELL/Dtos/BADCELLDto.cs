using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;


namespace OneAppHNI.VoTuyen.Dtos
{
	[AutoMapFrom(typeof(BADCELL))]
    public class BADCELLDto : EntityDto<int>
    {
         public string MATINH { get; set; }
 public string DONVI { get; set; }
 public string QUANHUYEN { get; set; }
 public string TENTRAM { get; set; }
 public string TENCELL { get; set; }
 public long CELLID { get; set; }
 public string LOAICELL { get; set; }
 public double QOSDIEM { get; set; }
 public double QOSTYLE { get; set; }
 public double SQICHUANHOA1 { get; set; }
 public double SQICHUANHOA2 { get; set; }
 public double SQICHUANHOA3 { get; set; }
 public double SQICHUANHOA4 { get; set; }
 public double SQICHUANHOA5 { get; set; }
 public double SQIDIEM1 { get; set; }
 public double SQIDIEM2 { get; set; }
 public double SQIDIEM3 { get; set; }
 public double SQIDIEM4 { get; set; }
 public double SQIDIEM5 { get; set; }
 public double KPIDAURASQI1 { get; set; }
 public double KPIDAURASQI2 { get; set; }
 public double KPIDAURASQI3 { get; set; }
 public double KPIDAURASQI4 { get; set; }
 public double KPIDAURASQI5 { get; set; }
 public double KPIDAUVAOSQI1 { get; set; }
 public double KPIDAUVAOSQI2 { get; set; }
 public double KPIDAUVAOSQI3 { get; set; }
 public double KPIDAUVAOSQI4 { get; set; }
 public double KPIDAUVAOSQI5 { get; set; }
 public double KPIDAUVAOOUTDOR { get; set; }
 public double TRAFFIC { get; set; }
 public int TUANBAOCAO { get; set; }
 public int NAMBAOCAO { get; set; }
        public int TRANGTHAI { get; set; }
        public int? TenantId { get; set; }

    }
}
