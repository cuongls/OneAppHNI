using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OneAppHNI.VoTuyen
{
    [Table("BADCELL", Schema = "ONEAPPHNIDB")]
    public class BADCELL : FullAuditedEntity<long>, IMayHaveTenant
    {
        [StringLength(50)]
        public virtual string MATINH { get; set; }
        [StringLength(100)]
        public virtual string DONVI { get; set; }
        [StringLength(100)]
        public virtual string QUANHUYEN { get; set; }
        [StringLength(100)]
        public virtual string TENTRAM { get; set; }
        [StringLength(100)]
        public virtual string TENCELL { get; set; }
        public virtual long CELLID { get; set; }
        [StringLength(50)]
        public virtual string LOAICELL { get; set; }
        public virtual double? QOSDIEM { get; set; }
        public virtual double? QOSTYLE { get; set; }
        public virtual double? SQICHUANHOA1 { get; set; }
        public virtual double? SQICHUANHOA2 { get; set; }
        public virtual double? SQICHUANHOA3 { get; set; }
        public virtual double? SQICHUANHOA4 { get; set; }
        public virtual double? SQICHUANHOA5 { get; set; }
        public virtual double? SQIDIEM1 { get; set; }
        public virtual double? SQIDIEM2 { get; set; }
        public virtual double? SQIDIEM3 { get; set; }
        public virtual double? SQIDIEM4 { get; set; }
        public virtual double? SQIDIEM5 { get; set; }
        public virtual double? KPIDAURASQI1 { get; set; }
        public virtual double? KPIDAURASQI2 { get; set; }
        public virtual double? KPIDAURASQI3 { get; set; }
        public virtual double? KPIDAURASQI4 { get; set; }
        public virtual double? KPIDAURASQI5 { get; set; }
        public virtual double? KPIDAUVAOSQI1 { get; set; }
        public virtual double? KPIDAUVAOSQI2 { get; set; }
        public virtual double? KPIDAUVAOSQI3 { get; set; }
        public virtual double? KPIDAUVAOSQI4 { get; set; }
        public virtual double? KPIDAUVAOSQI5 { get; set; }
        public virtual double? KPIDAUVAOOUTDOR { get; set; }
        public virtual double? TRAFFIC { get; set; }
        public virtual int TUANBAOCAO { get; set; }
        public virtual int NAMBAOCAO { get; set; }
        public virtual int TRANGTHAI { get; set; } = 0;
        public int? TenantId { get; set; }
    }
}
