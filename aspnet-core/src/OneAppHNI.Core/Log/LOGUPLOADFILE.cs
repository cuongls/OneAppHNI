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
    [Table("LOGUPLOADFILE", Schema = "ONEAPPHNIDB")]
    public class LOGUPLOADFILE : FullAuditedEntity<long>, IMayHaveTenant
    {
        [StringLength(200)]
        public virtual string FILENAME { get; set; }
        [StringLength(200)]
        public virtual string FILEPATH { get; set; }
        [StringLength(1000)]
        public virtual string DESCRIPTION { get; set; }
        [StringLength(200)]
        public virtual string LOAIFILE { get; set; }
        public virtual long? IDUSER { get; set; }
        public int? TenantId { get; set; }
    }
}
