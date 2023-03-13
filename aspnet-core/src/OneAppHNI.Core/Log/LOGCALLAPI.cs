using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace OneAppHNI.Log
{
    [Table("LOGCALLAPI", Schema = "ONEAPPHNIDB")]
    public class LOGCALLAPI : FullAuditedEntity<long>, IMayHaveTenant
    {
        [StringLength(200)]
        public virtual string URL { get; set; }
        [StringLength(200)]
        public virtual string METHOD { get; set; }
        public virtual string DATA { get; set; }
        public virtual string KETQUA { get; set; }
        public virtual DateTime THOIGIAN { get; set; }
        public virtual long? IDUSER { get; set; }
        public int? TenantId { get; set; }

    }
}
