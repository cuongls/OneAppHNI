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
    [Table("TRAMLOAITRU", Schema = "ONEAPPHNIDB")]
    public class TRAMLOAITRU : FullAuditedEntity<long>, IMayHaveTenant
    {
        [StringLength(100)]
        public virtual string QUANHUYEN { get; set; }
        public virtual double? LATITUDE { get; set; }
        public virtual double? LONGITUDE { get; set; }
        [StringLength(100)]
        public virtual string LOAITRAM { get; set; }
        [StringLength(100)]
        public virtual string SITENAME { get; set; }
        [StringLength(100)]
        public virtual string CELLNAME { get; set; }
        [StringLength(1000)]
        public virtual string CELLNAMEALIAS { get; set; }
        [StringLength(100)]
        public virtual string TRANGTHAI { get; set; }
        public virtual DateTime? THOIGIAN { get; set; }
        [StringLength(2000)]
        public virtual string GHICHU { get; set; }
        public virtual bool ISACTIVE { get; set; }
        public int? TenantId { get; set; }
    }
}
