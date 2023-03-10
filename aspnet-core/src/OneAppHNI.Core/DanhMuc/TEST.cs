using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OneAppHNI.DanhMuc
{
    [Table("TEST", Schema = "ONEAPPHNIDB")]
    public class TEST : FullAuditedEntity<long>, IMayHaveTenant
    {
        [StringLength(100)]
        public virtual string CODE { get; set; }
        [StringLength(200)]
        public virtual string NAME { get; set; }
        [StringLength(1000)]
        public virtual string DESCRIPTION { get; set; }
        public int? TenantId { get; set; }
    }
}
