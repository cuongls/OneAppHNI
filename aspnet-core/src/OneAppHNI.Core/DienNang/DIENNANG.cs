using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OneAppHNI.DienNang
{
    [Table("DIENNANG", Schema = "ONEAPPHNIDB")]
    public class DIENNANG : FullAuditedEntity<long>, IMayHaveTenant
    {
        
        [StringLength(200)]
        public virtual string MACSHT { get; set; }
        [StringLength(200)]
        public virtual string TTVT { get; set; }
        [StringLength(200)]
        public virtual string DOIVT { get; set; }
        [StringLength(200)]
        public virtual string MUCDICHSD { get; set; }
        [StringLength(200)]
        public virtual string TENTRAM { get; set; }
        [StringLength(200)]
        public virtual string LOAIHINHTH { get; set; }
        public virtual double SODIEN { get; set; }
        public virtual double TIENDIEN { get; set; }
        public virtual double CPVANHANH { get; set; }
        public virtual double CPTHUEHATANG { get; set; }
        public virtual double CPLAODONG { get; set; }
        public virtual double CPSUACHUA { get; set; }
        public virtual double CPKHAC { get; set; }
        [StringLength(200)]
        public virtual string MAHOADON { get; set; }
        [StringLength(200)]
        public virtual string CHUNGCSHT { get; set; }
        [StringLength(1000)]
        public virtual string GHICHU { get; set; }
        [StringLength(200)]
        public virtual string TRANGTHAI { get; set; }
        [StringLength(200)]
        public virtual string NETXXACNHAN { get; set; }
        public virtual int NGAYBAOCAO { get; set; }
        public virtual int THANGBAOCAO { get; set; }
        public virtual int NAMBAOCAO { get; set; }
        public int? TenantId { get; set; }
    }
}
