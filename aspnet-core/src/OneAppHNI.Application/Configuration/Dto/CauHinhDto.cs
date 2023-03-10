using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneAppHNI.Configuration.Dto
{
    public class CauHinhDto
    {
        [MaxLength(100)]
        public string AcountEmailSend { get; set; }
        [MaxLength(100)]
        public string PassWordEmailSend { get; set; }
        [MaxLength(1000)]
        public string EmailNhanCanhBaoDienNang { get; set; }
        [MaxLength(100)]
        public string UrlXuatPhieuDHTT { get; set; }
    }
}
