using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OneAppHNI.VoTuyen
{
    public class DANHMUCCELL : FullAuditedEntity<long>, IMayHaveTenant
    {
        [StringLength(100)]
        public virtual string MANODE { get; set; }
        [StringLength(200)]
        public virtual string MATRAM { get; set; }
        [StringLength(200)]
        public virtual string MACELL { get; set; }
        [StringLength(200)]
        public virtual string DONVIQUANLY { get; set; }
        [StringLength(200)]
        public virtual string THIETBI { get; set; }
        [StringLength(200)]
        public virtual string MACCSHT { get; set; }
        [StringLength(200)]
        public virtual string TINH { get; set; }
        [StringLength(200)]
        public virtual string QUANHUYEN { get; set; }
        public virtual double LATITUDE { get; set; }
        public virtual double LONGITUDE { get; set; }
        public int? TenantId { get; set; }

    }
}
