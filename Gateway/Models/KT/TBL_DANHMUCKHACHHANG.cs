using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace it_report.Models
{
    [Table("TBL_DANHMUCKHACHHANG")]
    public class TBL_DANHMUCKHACHHANG
    {
        public string macn { get; set; }
        public string phanloaikhachhang { get; set; }
        [Key]
        public string makh { get; set; }
        public string donvi { get; set; }
        public string diachi { get; set; }
        public string tennguoigd { get; set; }
        public string masothue { get; set; }
        public string matdv { get; set; }
        public string matinh { get; set; }
        public string quanhuyen { get; set; }
        public string ghichu { get; set; }
        public string tk { get; set; }
        public string nhom { get; set; }
        public string SP { get; set; }
        public string GIASP { get; set; }
        public string PHI { get; set; }
        public string CP { get; set; }
        public string TAIKHOAN { get; set; }
        public string NGANHANG { get; set; }
        public Nullable<int> ngayno { get; set; }
        public string phanloai { get; set; }
        public Nullable<double> hanmuc { get; set; }
        public string chitiet { get; set; }
        public string xeploai { get; set; }
        public string dt { get; set; }
        public string fax { get; set; }
        public string tinhtrang { get; set; }
        public Nullable<System.DateTime> ngaygddautien { get; set; }
        public Nullable<System.DateTime> ngaygdgannhat { get; set; }
        public Nullable<double> solangd { get; set; }
        public string MACHUNG { get; set; }
        public Nullable<System.DateTime> ngaysinh { get; set; }
        public string gioitinh { get; set; }
        public string cmnd { get; set; }
        public string email { get; set; }
        public string giaytophaply { get; set; }
        public Nullable<bool> hd_thau { get; set; }
        public Nullable<bool> hd_phanphoi { get; set; }
        public Nullable<bool> hd_kinhte { get; set; }
        public Nullable<System.DateTime> ngayhethan { get; set; }
        public string giaydkkd { get; set; }
        public Nullable<int> stt { get; set; }


    }
}
