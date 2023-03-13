using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OneAppHNI.Log
{
    [Table("LOGSENDEMAIL", Schema = "ONEAPPHNIDB")]
    public class LOGSENDEMAIL : FullAuditedEntity<long>, IMayHaveTenant
    {
        [StringLength(200)]
        public virtual string EMAILSEND { get; set; }
        [StringLength(2000)]
        public virtual string EMAILNHAN { get; set; }
        [StringLength(1000)]
        public virtual string SUBJECT { get; set; }
        public virtual string BODY { get; set; }
        public virtual string BODYEMAIL { get; set; }
        [StringLength(1000)]
        public virtual string FILEDINHKEM { get; set; }
        public virtual DateTime NGAYGUI { get; set; }
        public virtual long? NGUOIGUI { get; set; }
        [StringLength(1000)]
        public virtual string KETQUA { get; set; }
        public int? TenantId { get; set; }
    }
}
