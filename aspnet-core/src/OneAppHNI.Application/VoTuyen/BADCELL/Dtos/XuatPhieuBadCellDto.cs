using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneAppHNI.VoTuyen.Dtos
{
    public class XuatPhieuBadCellDto
    {
        public string loaitin { get; set; }
        public string tieude { get; set; }
        public string noidung { get; set; }
        public string nguoinhan { get; set; }
        public DateTime ngaygui { get; set; }
        public string userxuatphieu { get; set; }
        public string nguoigui { get; set; }
        public string diachitram { get; set; }
        public string tenquanly { get; set; }
        public string vitriphieu { get; set; }
        public string nhapthoihanxuly { get; set; }
        
    }
    public class ThongTinPhieu
    {
        public int magui { get; set; }
        public string LoaiTin { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string NoiDungUpdate { get; set; }
        public string NoiDungtraphieu { get; set; }
        public string NguoiNhan { get; set; }
        public DateTime NgayGui { get; set; }
        public string UserXuatPhieu { get; set; }
        public string NguoiGui { get; set; }
        public string PhoiHop { get; set; }
        public string ChuTri { get; set; }
        public string TapTin { get; set; }
        public bool TrangThaiXuLy { get; set; }
        public string DsSendSMS { get; set; }
        public bool CotCao { get; set; }
        public DateTime TimeUpdate { get; set; }
        public string UserUpdate { get; set; }
        public string UserKhoaPhieu { get; set; }
        public DateTime TimeKhoaPhieu { get; set; }
        public string UserKhoaTraPhieu { get; set; }
        public DateTime TimeTraPhieu { get; set; }
        public string DiaChiTram { get; set; }
        public string TenQuanLy { get; set; }
        public string ViTriPhieu { get; set; }
        public string NhapThoiHanXL { get; set; }
    }
}
