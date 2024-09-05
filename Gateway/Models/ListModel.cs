using Exportable.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Exportable.Attribute;
using System.Linq;
using System.Web;
using Exportable.Models;
using APIInvoice;
using it_report.Models;

namespace ApplicationChart.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "taikhoan")]

        public string taikhoan { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "matkhau")]
        public string matkhau { get; set; }
    }
    public partial class Tonkhohandung
    {
        public string kho { get; set; }
        public string mahh1 { get; set; }
        public string tenhh { get; set; }
        public string dvt { get; set; }
        public string malo { get; set; }
        public string handung { get; set; }
        public DateTime ngay_handung { get; set; }
        public decimal slton { get; set; }
        public decimal? hd_3_6 { get; set; }
        public decimal? hd_6_12 { get; set; }
        public decimal? hd_12_18 { get; set; }
        public decimal? hd_hon_18 { get; set; }
    }
    public partial class EntitiesKT
    {
        public KTContext data { get; set; }
        public string macn { get; set; }
    }
    public partial class EntitiesCN
    {
        public Entities data { get; set; }
        public string macn { get; set; }
    }
    public partial class EntitiesCH
    {
        public CHQ10Entities1 data { get; set; }
        public string macn { get; set; }
    }
    public partial class TBL_DANHMUCKHACHHANG_CHUNG
    {
        public string macn { get; set; }
        public string phanloaikhachhang { get; set; }
        public string makh { get; set; }
        public string donvi { get; set; }
        public string diachi { get; set; }
        public string tennguoigd { get; set; }
        public string masothue { get; set; }
        public string matdv { get; set; }
        public string tk { get; set; }
        public string matinh { get; set; }
        public string quanhuyen { get; set; }
        public string ghichu { get; set; }

        public string nhom { get; set; }

        public string TAIKHOAN { get; set; }
        public string NGANHANG { get; set; }
        public Nullable<int> ngayno { get; set; }
        public string phanloai { get; set; }
        public Nullable<double> hanmuc { get; set; }

        public string dt { get; set; }
        public string email { get; set; }
        public string tinhtrang { get; set; }
        public Nullable<System.DateTime> ngaygddautien { get; set; }
        public Nullable<System.DateTime> ngaygdgannhat { get; set; }
        public Nullable<System.DateTime> ngaysinh { get; set; }
        public string gioitinh { get; set; }
        public string cmnd { get; set; }
        public string GIAYTOPHAPLY { get; set; }
    }
    public partial class EntitiesMB
    {
        public KT_TBEntities1 data { get; set; }
        public string macn { get; set; }
    }
    public partial class ListModel
    {
        public int Nam { get; set; }
        public int Thang { get; set; }
        public string Mien { get; set; }
        public string Tendvbc { get; set; }
        public string Matinh { get; set; }
        public string MaHH { get; set; }
        public string TenHH { get; set; }
        public decimal Tien { get; set; }
        public string PhanLoai { get; set; }
        public string PhanLoaiKH { get; set; }
        public string MaKH { get; set; }
        public string DonVi { get; set; }
        public string MaPL { get; set; }
        public string NHOM { get; set; }
    }
    public partial class APICHITIETCONGNO
    {
        public string baocao { get; set; }
        public List<string> macn { get; set; }
        public string tungay { get; set; }
        public string denngay { get; set; }
        public int tuthang { get; set; }
        public int denthang { get; set; }
        public int nam { get; set; }
        public int loai { get; set; }
        public string makh { get; set; }
        public string tenkh { get; set; }
        public string mau { get; set; }
        public string ngayin { get; set; }

    }
    public partial class PDFBase64
    {
        public string Base64 { get; set; }
        public byte[] databyte { get; set; }
    }
    public partial class ModelCongTacAudit
    {
        public DateTime ngay { get; set; }
        public string matdv { get; set; }
        public string makh { get; set; }
        public string tenkh { get; set; }
        public int slthaydoi { get; set; }
    }
    public partial class THONGTINCUATOI
    {
        public string taikhoan { get; set; }
        public string hoten { get; set; }
        public string email { get; set; }
        public string sdt { get; set; }
    }
    public partial class TIENNOQUAHAN
    {
        public string makh { get; set; }
        public string sct { get; set; }
        public DateTime ngay { get; set; }
        public decimal tien { get; set; }
    }
    public partial class DATATIENNO
    {
        public List<TIENNOQUAHAN> tienquahan { get; set; }
        public List<TIENNO> tienno { get; set; }
    }
    public partial class DTA_DONDATHANGKD_IN
    {

        public string MADH { get; set; }
        public int STT { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public decimal SOLUONG { get; set; }
        public decimal GIABAN_VAT { get; set; }
        public string DATE { get; set; }
        public string MAKH { get; set; }
        public string HOPDONG { get; set; }
        public string DONVI { get; set; }
        public DateTime NgayDat { get; set; }
    }
    public partial class CONGTACTRINHDUOC_AUDIT
    {
        public string macn { get; set; }
        public string matdv { get; set; }
        public string ngay { get; set; }
        public string makh { get; set; }
        public string tenkh { get; set; }
        public Nullable<bool> checkin { get; set; }
        public Nullable<int> ketqua { get; set; }
        public string ghichu { get; set; }
        public Nullable<bool> khoa { get; set; }
        public string ngayedit { get; set; }
    }
    public partial class ListNhom
    {
        public string MANHOM { get; set; }
        public string TENNHOM { get; set; }

    }
    public partial class ListNhomSP
    {
        public string NHOM { get; set; }
        public string MaHH { get; set; }
        public string TenHH { get; set; }
    }
    public partial class databoloc
    {
        public List<ListNhomSP> SP { get; set; }
        public List<ListKhuVuc> KV { get; set; }
        public List<ListKhuyenMai> KM { get; set; }
        public List<ListTrinhDuocVien> TDV { get; set; }
        public List<ListQuan> Quan { get; set; }
        public List<LoaiHD> LOAIHD { get; set; }
        public List<ListHopDong> HD { get; set; }
        public List<ListNhom> NHOM { get; set; }
    }
    public partial class htmldataboloc
    {
        public string SP { get; set; }
        public string KV { get; set; }
        public string KM { get; set; }
        public string TDV { get; set; }
        public string Quan { get; set; }
        public string LOAIHD { get; set; }
        public string HD { get; set; }
        public string KH { get; set; }
    }
    public partial class ListQLHH
    {
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public string NHOM { get; set; }
        public string SDK { get; set; }
    }
    public partial class ListQLQD
    {
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public int? SL { get; set; }
        public int? HOP { get; set; }
        public int? DIEM { get; set; }
    }
    public partial class Ketquathecao
    {
        public string MAKH { get; set; }
        public string TENKH { get; set; }
        //public decimal DOANHSO { get; set; }
        public int soluongthe { get; set; }
        public string sothe { get; set; }
        public List<int> listsothe { get; set; }

    }
    public partial class ListKhachHang
    {
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string MATDV { get; set; }
        public string MATDV2 { get; set; }
        public double? HANMUC { get; set; }
        public string DIACHI { get; set; }
        public string DT { get; set; }
        public string macn { get; set; }
        public string MATINH { get; set; }
        public string phanloai { get; set; }
        public string phanloaikhachhang { get; set; }
        public string tennguoigd { get; set; }
        public string taikhoan { get; set; }
        public string nganhang { get; set; }
        public bool khngoai { get; set; }
        public string masothue { get; set; }
        public string email { get; set; }
        public string diachigiaohang { get; set; }
        public DateTime? NGAYSINH { get; set; }
    }
    public partial class CONGNOKHACHHANG
    {
        public double? MAKH { get; set; }
        public string DONVI { get; set; }
    }
    public partial class CHECKBBTT
    {
        public string LoaiBBTT { get; set; }
        public string makh { get; set; }

    }
    public partial class DATAHOPDONG
    {
        public string MACN { get; set; }
        public string MAKH { get; set; }
        public string MAHD { get; set; }
        public string noidung { get; set; }
        public Nullable<System.DateTime> NGAYBATDAU { get; set; }
        public Nullable<System.DateTime> NGAYKETTHUC { get; set; }

        public string donvi { get; set; }

        public string phuluc { get; set; }
        public string nguoidung { get; set; }
        public string sodk { get; set; }
        public string MAQD { get; set; }
        public string TENQD { get; set; }
        public Nullable<System.DateTime> NGAYQD { get; set; }
        public string LOAIHD { get; set; }

        public string GHICHU { get; set; }
        public string sp { get; set; }
        public string GIASP { get; set; }

        public string SL { get; set; }

    }
    public partial class DATABBTT
    {
        public int nam { get; set; }
        public string LoaiBBTT { get; set; }
        public string makh { get; set; }
        public string donvi { get; set; }
        public string matdv { get; set; }
        public string tennguoigd { get; set; }
        public double? ck { get; set; }
        public double? ckdatquy { get; set; }
        public double? ckdat { get; set; }
        public double? ckvuot { get; set; }
        public decimal? Tong { get; set; }
        public string Ghichu { get; set; }
    }
    public partial class DATAKYHANNO1
    {
        public string makh { get; set; }
        public string phanloai { get; set; }
        public string TENDVBC { get; set; }
        public double tien { get; set; }
        public double t1 { get; set; }
        public double t2 { get; set; }
        public double t3 { get; set; }
        public double t4 { get; set; }
        public double t5 { get; set; }
        public double t6 { get; set; }
        public double t7 { get; set; }
        public double t8 { get; set; }
        public double t9 { get; set; }
        public double t10 { get; set; }
        public double t11 { get; set; }
        public double t12 { get; set; }
        public double t13 { get; set; }
    }
    public partial class DATAKYHANNO2
    {
        public string mien { get; set; }
        public string phanloai { get; set; }
        public int thang { get; set; }
        public int nam { get; set; }
        public int thangtruoc { get; set; }
        public int namtruoc { get; set; }
        public DateTime ngay { get; set; }
        public string tendvbc { get; set; }
        public decimal dauky { get; set; }
        public decimal tienthu { get; set; }
        public decimal cuoiky { get; set; }
        public decimal tien { get; set; }
        public decimal t1 { get; set; }
        public decimal t2 { get; set; }
        public decimal t3 { get; set; }
        public decimal t4 { get; set; }
        public decimal t5 { get; set; }
        public decimal t6 { get; set; }
        public decimal t7 { get; set; }
        public decimal t8 { get; set; }
        public decimal t9 { get; set; }
        public decimal t10 { get; set; }
        public decimal t11 { get; set; }
        public decimal t12 { get; set; }
        public decimal t13 { get; set; }
    }
    public partial class DTA_TONKHO_CHITIET_HANDUNG
    {
        public string mahh { get; set; }
        public Nullable<decimal> slton { get; set; }
        public string handung { get; set; }
        public DateTime? ngayhandung { get; set; }
    }
    public partial class DTA_KEHOACHTHUNO
    {
        public List<DTA_THUNO> DATA { get; set; }
        public List<DTA_KEHOACHCONGNO> KH { get; set; }
    }
    public partial class DTA_THUNO
    {

        public DateTime? NGAYTINH { get; set; }
        public string MACH { get; set; }
        public string TENCH { get; set; }
        public string MAKH1 { get; set; }
        public string DONVI { get; set; }
        public string MATINH { get; set; }
        public string MATDV { get; set; }
        public string PHANLOAI { get; set; }
        public string PHANLOAIKHACHHANG { get; set; }
        public Nullable<double> OI_balance { get; set; }

        public Nullable<double> OI_Balance_Overdue { get; set; }
        public Nullable<double> QUAHAN_1_30 { get; set; }


        public Nullable<double> QUAHAN_31_60 { get; set; }
        public Nullable<double> QUAHAN_61_120 { get; set; }

        public Nullable<double> QUAHAN_121_360 { get; set; }


        public Nullable<double> QUAHAN_LON_360 { get; set; }
        public double PSCO { get; set; }
        public double PSNO { get; set; }
    }
    public partial class DTA_KYHANCONGNO_SQL
    {
        public System.DateTime NGAY { get; set; }
        public string MACH { get; set; }
        public string MAKH1 { get; set; }
        public string DONVI { get; set; }
        public string MATINH { get; set; }
        public string PHANLOAI { get; set; }
        public string PHANLOAIKHACHHANG { get; set; }
        public Nullable<double> OI_balance { get; set; }
        public Nullable<double> D_0_6 { get; set; }
        public Nullable<double> D_7_14 { get; set; }
        public Nullable<double> D_15_30 { get; set; }
        public Nullable<double> D_31_60 { get; set; }
        public Nullable<double> D_61_90 { get; set; }
        public Nullable<double> D_91_120 { get; set; }
        public Nullable<double> D_121_180 { get; set; }
        public Nullable<double> D_OVER_180 { get; set; }
        public Nullable<double> OI_Balance_Overdue { get; set; }
        public Nullable<double> QUAHAN_1_6 { get; set; }
        public Nullable<double> QUAHAN_7_14 { get; set; }
        public Nullable<double> QUAHAN_15_30 { get; set; }
        public Nullable<double> QUAHAN_31_60 { get; set; }
        public Nullable<double> QUAHAN_61_90 { get; set; }
        public Nullable<double> QUAHAN_91_120 { get; set; }
        public Nullable<double> QUAHAN_121_180 { get; set; }
        public Nullable<double> QUAHAN_181_360 { get; set; }
        public Nullable<double> QUAHAN_361_720 { get; set; }
        public Nullable<double> QUAHAN_LON_720 { get; set; }
        public Nullable<double> FORECAST_TUAN_1 { get; set; }
        public Nullable<double> FORECAST_TUAN_2 { get; set; }
        public Nullable<double> T1 { get; set; }
        public Nullable<double> T2 { get; set; }
        public Nullable<double> T3 { get; set; }
        public Nullable<double> T4 { get; set; }
        public Nullable<double> T5 { get; set; }
        public Nullable<double> T6 { get; set; }
        public Nullable<double> T7 { get; set; }
        public Nullable<double> T8 { get; set; }
        public Nullable<double> T9 { get; set; }
        public Nullable<double> T10 { get; set; }
        public Nullable<double> T11 { get; set; }
        public Nullable<double> T12 { get; set; }
    }
    public partial class DTA_KYHANCONGNO_FI_SQL
    {

        public string mach { get; set; }
        public string makh { get; set; }
        public string donvi { get; set; }
        public string matinh { get; set; }
        public string phanloai { get; set; }
        public string phanloaikhachhang { get; set; }
        public Nullable<decimal> tien { get; set; }
        public Nullable<decimal> etc_quahan { get; set; }
        public Nullable<decimal> thu_tuan_1 { get; set; }
        public Nullable<decimal> thu_quahan { get; set; }
        public Nullable<decimal> quahan_ps { get; set; }
        public Nullable<decimal> tien_sau { get; set; }
        public Nullable<decimal> etc_quahan_sau { get; set; }

    }
    public partial class DTA_KYHANCONGNO_FI_SQL2
    {

        public string mach { get; set; }
        public string makh { get; set; }
        public string noidung { get; set; }
        public string matinh { get; set; }
        public string phanloai { get; set; }
        public string phanloaikhachhang { get; set; }
        public Nullable<double> nodauky { get; set; }

    }
    public partial class TTNHANHTONKHO
    {
        public string MANHOM { get; set; }
        public string tendvbc { get; set; }
        public string TENNHOM { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public decimal SL_XUAT2 { get; set; }
        public decimal SL_NHAP2 { get; set; }
        //public decimal SL_NHAP { get; set; }
        //public decimal SL_TONCUOIKY { get; set; }
        public decimal SL_TONDAUKY2 { get; set; }
        public decimal SL_TONCUOIKY2 { get; set; }
        public string MALO { get; set; }
        public string HANDUNG { get; set; }
    }
    public partial class DATATONKHO
    {
        public int THANG { get; set; }
        public int NAM { get; set; }
        public string MANHOM { get; set; }
        public string TENNHOM { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public decimal SLTON { get; set; }
        public decimal? SLTONHETHAN { get; set; }
        public string MALO { get; set; }
        public string HANDUNG { get; set; }
        public string maquay { get; set; }
    }
    public partial class DATACHITIETHANGHOA
    {
        public string SOHD { get; set; }
        public string SOHD_NB { get; set; }
        public string DVT { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string KHANG { get; set; }
        public DateTime TUNGAY { get; set; }
        public DateTime DENNGAY { get; set; }
        public decimal SLMUA { get; set; }
        public decimal SLXBAN { get; set; }
        //public decimal SL_NHAP { get; set; }
        //public decimal SL_TONCUOIKY { get; set; }
        public decimal SLTONDKY { get; set; }
        public decimal TONGSLMUA { get; set; }
        public decimal TONGSLBAN { get; set; }
        public decimal TONCK { get; set; }
        public DateTime? NGAYLAPHD { get; set; }
        public string MALO { get; set; }
        public string HANDUNG { get; set; }
    }
    public partial class DATACHITIETHANGHOA1
    {
        public string SOHD { get; set; }
        public string DVT { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string KHANG { get; set; }
        public DateTime TUNGAY { get; set; }
        public DateTime DENNGAY { get; set; }
        public decimal SLMUA { get; set; }
        public decimal SLXBAN { get; set; }
        //public decimal SL_NHAP { get; set; }
        //public decimal SL_TONCUOIKY { get; set; }
        public decimal SLTONDKY { get; set; }
        public decimal TONGSLMUA { get; set; }
        public decimal TONGSLBAN { get; set; }
        public decimal TONCK { get; set; }
        public string NGAYLAPHD { get; set; }
        public string MALO { get; set; }
        public string HANDUNG { get; set; }
    }
    public partial class APIBSC
    {
        public string PHANLOAI { get; set; }
        public List<TBL_DANHMUCPHANLOAIKHACHHANG> MAPLKH { get; set; }
        public List<BAOCAOCTHT> CTHT { get; set; }

        public List<BSCCHINHANH> CHINHANH { get; set; }
        public List<TBL_DANHMUCLOAIBAOCAO> LOAIBC { get; set; }
        public List<TBL_DANHMUCNHOMSANPHAM> NHOMHANG { get; set; }
    }
    public partial class ListKhachHangFull
    {
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string DIACHI { get; set; }

        public string DT { get; set; }
        public DateTime? NGAYSINH { get; set; }
    }
    public partial class KhachHangFull
    {
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string DIACHI { get; set; }
        public string NGAYSINH { get; set; }
        public string DONHANGGANHAT { get; set; }
        public string TENNGUOILH { get; set; }
        public string DT { get; set; }
        public string MST { get; set; }
        public string xeploai { get; set; }
        public string matinh { get; set; }

    }
    public partial class LOCLAYDONHANG
    {
        public List<ListKhuVuc> khuvuc { get; set; }
        public List<ListTrinhDuocVien> matdv { get; set; }
        public List<ListKhachHang> makh { get; set; }
        public List<TBL_DANHMUCNGUOIDUNG> nguoigiaohang { get; set; }
    }
    public partial class datatracuukhachhang
    {
        public thongtinkhachhang thongtinkhachhang { get; set; }
        public thongtinbbtt thongtinbbtt { get; set; }
        public List<DATATRACUUKHACHHANG> listdata { get; set; }
    }
    public partial class thongtinkhachhang
    {
        public string makh { get; set; }
        public string donvi { get; set; }
        public string diachi { get; set; }
        public string dt { get; set; }
        public string tennguoigd { get; set; }
        public string matdv { get; set; }
        public string matinh { get; set; }
        public DateTime ngaygdgannhat { get; set; }

    }
    public partial class thongtinbbtt
    {
        public string LoaiBBTT { get; set; }
        public decimal Tong { get; set; }
        public decimal Doanhso { get; set; }
    }
    public partial class KhachHangBC11
    {
        public string MAKH { get; set; }

    }
    public partial class CHARTDATAGET
    {
        public string tungay1 { get; set; }
        public string denngay1 { get; set; }
        public int sltopkhuvuc { get; set; }
        public int sltopkhachhang { get; set; }
        public int sltophanghoa { get; set; }
        public List<string> nhomhang { get; set; }
        public string maphanloai { get; set; }
        public List<string> Checkboxlist1 { get; set; }
        public string Checkboxlist2 { get; set; }
        public List<string> Checkboxlist3 { get; set; }
        public List<string> Checkboxlist4 { get; set; }
        public List<string> Checkboxlist5 { get; set; }
    }
    public partial class BSCRECIEVE
    {
        public List<string> nhomhang { get; set; }

        public string tungay1 { get; set; }
        public string denngay1 { get; set; }
        public string maphanloai { get; set; }
        public List<string> Checkboxlist1 { get; set; }
        public string Checkboxlist2 { get; set; }
        public List<string> Checkboxlist3 { get; set; }
        public List<string> Checkboxlist4 { get; set; }
        public List<string> Checkboxlist5 { get; set; }
        public List<string> Checkboxlist6 { get; set; }
        public List<string> Checkboxlist8 { get; set; }
        public List<string> Checkboxlist9 { get; set; }
        public List<string> Checkboxlist10 { get; set; }
        public List<string> Checkboxlist11 { get; set; }
        public List<string> Checkboxlist12 { get; set; }
        public List<string> Checkboxlist13 { get; set; }
        public List<string> Checkboxlist14 { get; set; }
        public int loaibaocao { get; set; }
        public string tienck { get; set; }
        public int loctheo { get; set; }
        public string qui { get; set; }
        public int nam { get; set; }
        public int top { get; set; }
        public bool? spthauquocgia { get; set; }
        public bool? spkhongkedon { get; set; }
        public string lang { get; set; }
    }
    public partial class ListKhuyenMai
    {
        public string MAKM { get; set; }
        public string TENKM { get; set; }
        public string MAHH { get; set; }
        public List<string> PHAMVI { get; set; }
        public double? ck { get; set; }
        public DateTime? ngaybatdau { get; set; }
        public DateTime? ngayketthuc { get; set; }
        public bool? hieuluc { get; set; }
    }
    public partial class Sosanhtoado
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string makh { get; set; }
        public string ngay { get; set; }
    }
    public partial class ListOnline
    {
        public string taikhoan { get; set; }
        public string hovaten { get; set; }
    }
    public partial class ListTrinhDuocVien
    {
        public string MATDV { get; set; }
        public string TENTDV { get; set; }
    }
    public partial class ListMATDV
    {
        public string MATDV { get; set; }

    }
    public partial class ChitietCTBH
    {
        public TBL_DANHMUCKM dulieu { get; set; }
        public List<ListHangHoa> mahh { get; set; }
        public List<TBL_DANHSACHCHINHANH> macn { get; set; }
    }
    public partial class ChitietCTHT
    {
        public TBL_DANHMUCCHUONGTRINHHOTRO dulieu { get; set; }
        public List<ListHangHoa> mahh { get; set; }
        public List<TBL_DANHSACHCHINHANH> macn { get; set; }
    }
    public partial class ListKQHopdong
    {
        public string MACN { get; set; }
        public string MAHH { get; set; }
        public decimal SL { get; set; }
        public decimal TT { get; set; }
        public string tenhh { get; set; }
        public decimal tienps { get; set; }
        public decimal sldauky { get; set; }
        public decimal tiendauky { get; set; }
        public decimal tienhd { get; set; }
        public decimal tiendu { get; set; }
        public decimal sldu { get; set; }
        public decimal GIASP { get; set; }
        public string MAKH { get; set; }
        public string MAHD { get; set; }
        public DateTime TUNGAY { get; set; }
        public DateTime DENNGAY { get; set; }
        public string DONVI { get; set; }
        public string MATINH { get; set; }
        public string TENTINH { get; set; }
        public string TENDVBC { get; set; }
        public DateTime? ngaybatdau { get; set; }
        public DateTime? ngayketthuc { get; set; }
    }
    public partial class ListKQHopdong1
    {
        public string MAHH { get; set; }
        public decimal SL { get; set; }
        public decimal TT { get; set; }
        public string tenhh { get; set; }
        public decimal tienps { get; set; }
        public decimal sldauky { get; set; }
        public decimal tiendauky { get; set; }
        public decimal tienhd { get; set; }
        public decimal tiendu { get; set; }
        public decimal sldu { get; set; }
        public string MAKH { get; set; }
        public string MAHD { get; set; }
        public DateTime TUNGAY { get; set; }
        public DateTime DENNGAY { get; set; }
        public string DONVI { get; set; }
        public string MATINH { get; set; }
        public string TENTINH { get; set; }
        public string TENDVBC { get; set; }
        public string ngaybatdau { get; set; }
        public string ngayketthuc { get; set; }
    }
    public partial class ListQuan
    {
        public string maquan { get; set; }
        public string tenquan { get; set; }
    }
    public partial class Datachart
    {
        public string DataPoints { get; set; }
        public string DataPoints1 { get; set; }
        public string DataPoints3 { get; set; }
        public string DataPoints2 { get; set; }
        public string DataPoints5 { get; set; }
        public string DataPoints6 { get; set; }
        public string DataPoints7 { get; set; }
        public string DataPoints9 { get; set; }
        public string DataPoints88 { get; set; }
        public string DataPoints8 { get; set; }
        public string DataPoints811 { get; set; }
        public int Chart1Height { get; set; }
        public int Chart3Height { get; set; }
        public int Chart5Height { get; set; }
        public int Chart9Height { get; set; }
    }
    public partial class Datachartss
    {
        public string DataPoints { get; set; }
        public string DataPoints0 { get; set; }
        public string DataPoints00 { get; set; }
        public int Chart1Height { get; set; }
        public string DataPoints1 { get; set; }
        public string DataPoints10 { get; set; }
        public string DataPoints2 { get; set; }
        public string DataPoints22 { get; set; }
        public string DataPoints5 { get; set; }
        public int Chart5Height { get; set; }
        public string DataPoints50 { get; set; }
        public int Chart51Height { get; set; }
        public string DataPoints500 { get; set; }
        public string DataPoints6 { get; set; }
        public string DataPoints66 { get; set; }
        public string DataPoints7 { get; set; }
        public string DataPoints70 { get; set; }

    }
    public partial class BAOCAOTONGHOPCRM
    {
        public string taikhoan { get; set; }
        public string hovaten { get; set; }
        public string chinhanh { get; set; }
        public int? songaybaocao { get; set; }
        public int? solantham { get; set; }
        public int? sodonhang { get; set; }
        public decimal? doanhsootc { get; set; }
        public decimal? doanhsoetc { get; set; }
    }
    public partial class BAOCAOTONGHOPTUNGNGAYCRM
    {
        public string taikhoan { get; set; }
        public string hovaten { get; set; }
        public string chinhanh { get; set; }
        public List<BAOCAOTUNGNGAYTDV> chitietngay { get; set; }
    }
    public partial class BAOCAOTUNGNGAYTDV
    {
        public DateTime ngaythang { get; set; }
        public int ngay { get; set; }
        public int kehoach { get; set; }
        public int dabaocao { get; set; }
        public int donhang { get; set; }
        public int ghetham { get; set; }
        public int huy { get; set; }
    }
    public partial class LISTBAOCAOTONGHOPCRM
    {
        public DateTime tungay { get; set; }
        public DateTime denngay { get; set; }
        public int songaylamviec { get; set; }
        public List<BAOCAOTONGHOPCRM> data { get; set; }
    }
    public partial class LISTBAOCAOTONGHOPTUNGNGAYCRM
    {
        public DateTime tungay { get; set; }
        public DateTime denngay { get; set; }
        public int songaylamviec { get; set; }
        public List<BAOCAOTONGHOPTUNGNGAYCRM> data { get; set; }
    }
    public partial class LISTBAOCAOCHITIETNGAYCRM
    {
        public DateTime tungay { get; set; }
        public DateTime denngay { get; set; }
        public string taikhoan { get; set; }
        public string hovaten { get; set; }
        public string macn { get; set; }
        public string tencn { get; set; }
        public List<ListKhachHang> data { get; set; }
    }
    public partial class LastOnline
    {
        public string Username { get; set; }
        public DateTime LastDate { get; set; }
    }

    public partial class ModelChiNhanh
    {
        public List<ListModel> Data { get; set; }
    }
    public partial class ModelBCChiNhanh
    {
        public List<DULIEUBAOCAO> Data { get; set; }
    }
    //public partial class ModelBC0
    //{
    //    public List<DULIEUBAOCAO0> Data { get; set; }
    //}

    public partial class Export
    {
        public string macn { get; set; }
        public string phanloaikhachhang { get; set; }
        public string makh { get; set; }
        public string donvi { get; set; }
    }
    public partial class DoanhThuKH
    {
        public string Tendvbc { get; set; }
        public string DonVi { get; set; }
        public decimal TongTien { get; set; }
    }
    public partial class TopKhuVuc
    {
        public string Ten { get; set; }
        public decimal Nam { get; set; }
        public decimal Namtruoc { get; set; }
    }
    public partial class ModelReportChartView
    {
        public int submit { get; set; }
        public string Checkboxlist { get; set; }
        public string Checkboxlist1 { get; set; }
        public string Checkboxlist2 { get; set; }
        public string Checkboxlist3 { get; set; }
        public string Checkboxlist4 { get; set; }
        public int tuthang { get; set; }
        public int denthang { get; set; }
        public int nam { get; set; }
    }

    public partial class ModelReportView
    {
        public int btnin { get; set; }
        public string donvi { get; set; }
        public int checkbox1 { get; set; }
        public string tungay1 { get; set; }
        public string denngay1 { get; set; }
        public string Checkboxlist { get; set; }
        public string Checkboxlist1 { get; set; }
        public string Checkboxlist2 { get; set; }
        public string Checkboxlist3 { get; set; }
        public string Checkboxlist4 { get; set; }
        public string Checkboxlist5 { get; set; }
        public string Checkboxlist6 { get; set; }
        public string Checkboxlist8 { get; set; }
        public string Checkboxlist9 { get; set; }
        public string Checkboxlist10 { get; set; }
        public string Checkboxlist11 { get; set; }
        public string Checkboxlist12 { get; set; }
        public string Checkboxlist13 { get; set; }
        public string Checkboxlist14 { get; set; }
        public int loaibaocao { get; set; }
        public string tienck { get; set; }
        public int loctheo { get; set; }
        public string qui { get; set; }
        public int nam { get; set; }
        public int top { get; set; }
    }
    public partial class BAOCAOBSC5
    {

        public string makh { get; set; }
        public string tenkh { get; set; }
        public string diachi { get; set; }
        public string sohd { get; set; }
        public string ngaylaphd { get; set; }
        public string mahh { get; set; }
        public string tenhh { get; set; }
        public string dvt { get; set; }
        public decimal sl_mua { get; set; }
        public decimal sl_km { get; set; }
        public decimal dongia_mua { get; set; }
        public decimal tien_mua { get; set; }
        public decimal dongia_km { get; set; }
        public decimal tien_km { get; set; }
        public int thang { get; set; }
        public int nam { get; set; }
        public string makm { get; set; }
        public string tenkm { get; set; }
        public decimal tienck { get; set; }
    }

    public partial class Nam
    {
        public int CacNam { get; set; }
    }
    public partial class DoanhThuCN
    {
        public decimal TongTien { get; set; }
        public string Tendvbc { get; set; }
    }
    public partial class KeHoach
    {
        public decimal TongTien { get; set; }
        public string Mien { get; set; }
    }
    public class DoanhHangThang
    {
        public decimal TongTien { get; set; }
        public int thang { get; set; }
    }
    public class TopHangHoa
    {
        public decimal TongTien { get; set; }
        public string MaHH { get; set; }
        public string TenHH { get; set; }
    }
    public class DonVi
    {

        public string TenDV { get; set; }

    }
    public class ChiNhanhMien
    {
        public string macn { get; set; }
        public string ChiNhanh { get; set; }
        public string Mien { get; set; }
    }
    public class DATABAOCAO8
    {
        public string mahh { get; set; }
        public decimal soluong { get; set; }
        public string dvt { get; set; }
        public decimal dongia { get; set; }
        public decimal tien { get; set; }
        public string tenhh { get; set; }
        public string mapl { get; set; }
        public string NHOM { get; set; }
        public string SOHD { get; set; }
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string NGAYLAPHD { get; set; }
    }
    public class BAOCAO8
    {
        public string mahh { get; set; }
        public int soluong { get; set; }
        public string dvt { get; set; }
        //public double dongia { get; set; }
        public double tien { get; set; }
        public string tenhh { get; set; }
        public string mapl { get; set; }

        public string NHOM { get; set; }
    }
    public class BAOCAOHD8
    {
        public string SOHD { get; set; }
        public string MAKH { get; set; }
        public string TENNGUOIGD { get; set; }
        public double TIENVAT { get; set; }
        public double TIENCK { get; set; }
        public DateTime NGAYLAPHD { get; set; }
        public string DONVI { get; set; }
        public double TONGTIEN_CT_HOADON { get; set; }
        public string tendvbc { get; set; }
        public string MATDV { get; set; }
    }
    public class DATALAYDONHANG
    {
        public string SOHD { get; set; }
        public string SOHD_DT { get; set; }
        public string MAKH { get; set; }
        public DateTime NGAYLAPHD { get; set; }
        public string DONVI { get; set; }
        public string DIACHI { get; set; }
        public double TONGTIEN_CT_HOADON { get; set; }
        public string tendvbc { get; set; }
        public string MATDV { get; set; }
        public bool? check { get; set; }
    }
    public class BAOCAOTH
    {
        public double TIENCK { get; set; }
        public string thangdau { get; set; }
        public string nam { get; set; }
        public double TONGTIEN_CT_HOADON { get; set; }
        public string tendvbc { get; set; }
        public string chuky1 { get; set; }
    }
    public class ViewQLDHKD
    {
        public List<Khachhang> khachhang { get; set; }

        public string taikhoan { get; set; }
        public string hoten { get; set; }
        public string chinhanh { get; set; }
    }
    public class Khachhang
    {
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string matinh { get; set; }
    }
    public class BAOCAO9
    {
        public string PHANLOAI { get; set; }
        public string MACH { get; set; }
        public string TENCH { get; set; }
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string TENNGUOIGD { get; set; }

        public double TONGTIEN_CT_HOADON { get; set; }
        public double THANHTIEN { get; set; }
        public double TIENCK { get; set; }
        public string MATINH { get; set; }
        public string MATDV { get; set; }
        public double TIENVAT { get; set; }
    }
    public class BAOCAO48
    {
        public string MACN { get; set; }
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string MATDV { get; set; }
        public string MATINH { get; set; }

        public decimal TIEN { get; set; }
        public decimal TILECK { get; set; }
        public decimal TIENCK { get; set; }
        public decimal TILECKHT { get; set; }
        public decimal TIENCKHT { get; set; }
        public string QUATANG { get; set; }
        public Nullable<decimal> SLQUATANG { get; set; }
        public string QUATANGTHEM { get; set; }
        public Nullable<decimal> SLQUATANGTHEM { get; set; }
        public string QUATANGTHEM1 { get; set; }
        public Nullable<decimal> SLQUATANGTHEM1 { get; set; }
    }
    public class BAOCAO10
    {
        public string NAM { get; set; }
        public string mahh { get; set; }
        public int soluong { get; set; }
        public string dvt { get; set; }
        public double tien { get; set; }
        public string tenhh { get; set; }
        public decimal dongia { get; set; }
        public string mapl { get; set; }
        public string MAQUAY { get; set; }
        public string NHOM { get; set; }
        public int THANG { get; set; }
        public string tentinh { get; set; }

    }
    public class BAOCAO49
    {
        public string NGAY { get; set; }
        public string TENDVBC { get; set; }
        public string MATINH { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        //public string phanloai { get; set; }
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public decimal SOLUONG { get; set; }
        public decimal? HOP { get; set; }
        public decimal? SOLUONGTANG { get; set; }
        public decimal? HOPTANG { get; set; }
        public decimal TIEN { get; set; }
        public string MATDV { get; set; }
        public string SOHD { get; set; }
        public decimal? TILECK { get; set; }
        public decimal? TIENCK { get; set; }
    }
    public class BAOCAO39
    {
        public int NAM { get; set; }
        public int THANG { get; set; }

        public string MAKH { get; set; }
        public string TENKH { get; set; }
        public string DIACHI { get; set; }
        public string MATINH { get; set; }
        public string TENTINH { get; set; }
        public string PHANLOAI { get; set; }
        [DataType(DataType.Text)]
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DANGBAOCHE { get; set; }
        public string QUYCACH { get; set; }
        public decimal SOLUONG { get; set; }
        public decimal DOANHTHU { get; set; }

    }
    public class BAOCAOCHITIETKHUVUC
    {
        public string THANG { get; set; }

        public string mahh { get; set; }

        public double tien { get; set; }
        public string tenhh { get; set; }
        public string mapl { get; set; }
        public string TUTHANG { get; set; }
        public string MAQUAY { get; set; }
        public string NHOM { get; set; }
    }
    //public class BAOCAO11
    //{
    //    public string THANG { get; set; }
    //    public string mahh { get; set; }
    //    public int soluong { get; set; }
    //    public string dvt { get; set; }
    //    public double tien { get; set; }
    //    public string tenhh { get; set; }
    //    public string mapl { get; set; }
    //    public string TUTHANG { get; set; }
    //    public string MAQUAY { get; set; }
    //    public string NHOM { get; set; }
    //}

    public class DULIEUBAOCAO5
    {
        public string THANG { get; set; }

        public string mahh { get; set; }
        public decimal soluong { get; set; }
        public decimal dongia { get; set; }
        public decimal tien { get; set; }
        public string tenhh { get; set; }
        public string mapl { get; set; }
        public string TUTHANG { get; set; }
        public string MAQUAY { get; set; }
        public string NHOM { get; set; }
    }
    public class DULIEUBAOCAO41
    {
        public string NGAYLAPHD { get; set; }

        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string DIACHIKH { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public decimal TIEN { get; set; }
        public decimal SOLUONG { get; set; }
        public string TINH { get; set; }
        public string TENDVBC { get; set; }
        public string tungay { get; set; }
        public string denngay { get; set; }
        public string SOHD { get; set; }
        public string DIACHI_CN { get; set; }
    }
    public class DULIEUBAOCAO43
    {
        public DateTime NGAYLAPHD { get; set; }

        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string DIACHIKH { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public decimal TIEN { get; set; }
        public decimal SOLUONG { get; set; }
        public string TINH { get; set; }
        public string TENDVBC { get; set; }
        public string tungay { get; set; }
        public string denngay { get; set; }
        public string SOHD { get; set; }
        public string DIACHI_CN { get; set; }
    }

    public class DULIEUBAOCAO0
    {
        public string chuky1 { get; set; }
        public string TENDVBC { get; set; }
        public decimal TONGTIEN_CT_HOADON { get; set; }
        public decimal TIENCK { get; set; }
        public string MaPL { get; set; }
        public string thangdau { get; set; }
        public string nam { get; set; }
        public string Matinh { get; set; }
        public string Tentinh { get; set; }
    }
    public class DULIEUBAOCAO40
    {
        public string SOHD { get; set; }
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public decimal TONGTIEN { get; set; }
        public decimal THANHTIEN { get; set; }
        public decimal TIENCK { get; set; }

    }
    public class BCKEHOACHCHITIET
    {
        public string makh { get; set; }
        public int ngay { get; set; }
        public int loai { get; set; }
        public string ghichu { get; set; }
    }
    public class DULIEUSOSANH
    {
        public string MIEN { get; set; }
        public string TENDVBC { get; set; }
        public decimal TIEN { get; set; }
        public decimal TIEN_TRUOC { get; set; }
    }
    public class CHECKTONKHO
    {
        public string MAHH { get; set; }
        public decimal SL_TONCUOIKY_2 { get; set; }
    }
    public partial class TBL_UPDATE_PROGRAM1
    {
        public string tenphanmem { get; set; }
        public string dulieu { get; set; }

        public Nullable<System.DateTime> ngay { get; set; }
        public string phienban { get; set; }
        public int id { get; set; }
    }
    public class TBL_UPDATE_PROGRAM2
    {
        public string authtoken { get; set; }
        public string tenphanmem { get; set; }
        public string dulieu { get; set; }


        public string phienban { get; set; }

    }
    public partial class sp_IN_TONGHOP_CONGNO_IN_Result
    {
        public string MACN { get; set; }
        public string MAKH { get; set; }
        public string NOIDUNG { get; set; }
        public string PHANLOAI { get; set; }
        public double? NODAUKY { get; set; }
        public double? CODAUKY { get; set; }
        public double? PSNO { get; set; }
        public double? PSCO { get; set; }
        public double? COCUOIKY { get; set; }
        public double? NOCUOIKY { get; set; }
        public DateTime? TUNGAY { get; set; }
        public DateTime? DENNGAY { get; set; }
        public string tendvbc { get; set; }
        public string tinh { get; set; }
        public string chuky1 { get; set; }

        public string chuky3 { get; set; }

        public string chuky2b { get; set; }

        public string MATK { get; set; }
        public DateTime? ngayin { get; set; }
        public string matdv { get; set; }
        public string matinh { get; set; }
    }
    public partial class sp_IN_TONGHOP_CONGNO_IN_ResultTT423
    {
        public string MAKH { get; set; }
        public string NOIDUNG { get; set; }
        public decimal? NODAUKY { get; set; }
        public decimal? CODAUKY { get; set; }
        public decimal? PSNO { get; set; }
        public decimal? PSCO { get; set; }
        public decimal? COCUOIKY { get; set; }
        public decimal? NOCUOIKY { get; set; }
        public DateTime? TUNGAY { get; set; }
        public DateTime? DENNGAY { get; set; }
        public string tendvbc { get; set; }
        public string tinh { get; set; }
        public string chuky1 { get; set; }

        public string chuky3 { get; set; }

        public string chuky2b { get; set; }

        public string MATK { get; set; }
        public DateTime? ngayin { get; set; }
        public string matdv { get; set; }
        public string matinh { get; set; }
    }
    public partial class DULIEUBAOCAO3
    {
        public string MAKH { get; set; }
        public string NOIDUNG { get; set; }
        public double NODAUKY { get; set; }
        public double CODAUKY { get; set; }
        public double PSNO { get; set; }
        public double PSCO { get; set; }
        public double COCUOIKY { get; set; }
        public double NOCUOIKY { get; set; }
        public string TUNGAY { get; set; }
        public string DENNGAY { get; set; }
        public string tendvbc { get; set; }
        public string tinh { get; set; }
        public string chuky1 { get; set; }
        public string chuky3 { get; set; }
        public string chuky2b { get; set; }
        public string MATK { get; set; }
        public DateTime ngayin { get; set; }
        public string matdv { get; set; }
        public string matinh { get; set; }
    }
    public partial class sp_INTONGHOPCONGNOCHITIET_IN_Result
    {
        public string makh { get; set; }
        public string donvi { get; set; }
        public string sct { get; set; }
        public DateTime? ngay { get; set; }
        public string noidung { get; set; }
        public decimal? nodauky { get; set; }
        public decimal? codauky { get; set; }
        public decimal? psno { get; set; }
        public decimal? psco { get; set; }
        public decimal? nocuoiky { get; set; }
        public decimal? cocuoiky { get; set; }
        public string tk { get; set; }
        public string TENDVBC { get; set; }
        public string CHUKY1 { get; set; }
        public string CHUKY2B { get; set; }
        public string TUNGAY { get; set; }
        public string DENNGAY { get; set; }
        public DateTime NGAYIN { get; set; }
    }
    public partial class sp_INSOCTIET_CONGNO_Result
    {
        public string sohd { get; set; }
        public DateTime? ngaylaphd { get; set; }
        public decimal tienban { get; set; }
        public decimal tienthu { get; set; }
        public decimal tiendauky { get; set; }
        public decimal tientrahang { get; set; }
        public string TENKH { get; set; }
        public string tungay { get; set; }
        public string denngay { get; set; }
        public string tenkh1 { get; set; }
        public string makh1 { get; set; }
    }
    public partial class DULIEUBAOCAO1CH
    {
        public string sohd { get; set; }
        public string ngaylaphd { get; set; }
        public decimal tienban { get; set; }
        public decimal tienthu { get; set; }
        public decimal tiendauky { get; set; }
        public decimal tientrahang { get; set; }
        public string TENKH { get; set; }
        public string tungay { get; set; }
        public string denngay { get; set; }
        public string tenkh1 { get; set; }
        public string makh1 { get; set; }
    }
    public partial class DULIEUBAOCAO1
    {
        public string makh { get; set; }
        public string donvi { get; set; }
        public string sct { get; set; }
        public string ngay { get; set; }
        public string noidung { get; set; }
        public string tk { get; set; }
        public decimal nodauky { get; set; }
        public decimal codauky { get; set; }
        public decimal psno { get; set; }
        public decimal psco { get; set; }
        public decimal nocuoiky { get; set; }
        public decimal cocuoiky { get; set; }
        public string tendvbc { get; set; }
        public string chuky1 { get; set; }
        public string chuky2b { get; set; }
        public string TUNGAY { get; set; }
        public string DENNGAY { get; set; }

    }
    public partial class TIENNO
    {
        public string makh { get; set; }
        public string donvi { get; set; }
        public decimal tien { get; set; }
    }
    public partial class DULIEUBAOCAO2
    {
        public string makh { get; set; }
        public string donvi { get; set; }
        public string matdv { get; set; }
        public string matinh { get; set; }
        public string tentdv { get; set; }
        public string DIACHI { get; set; }
        public decimal tien { get; set; }
        public decimal t1 { get; set; }
        public decimal t2 { get; set; }
        public decimal t3 { get; set; }
        public decimal t4 { get; set; }
        public decimal t5 { get; set; }
        public decimal t6 { get; set; }
        public decimal t7 { get; set; }
        public decimal t8 { get; set; }
        public decimal t9 { get; set; }
        public decimal t10 { get; set; }
        public decimal t11 { get; set; }
        public decimal t12 { get; set; }
        public decimal t13 { get; set; }
    }
    public partial class DATA_DANHMUCKM_CHITIET
    {
        public string MACTKM { get; set; }
        public string TENCTKM { get; set; }
        public DateTime? ngaybatdau { get; set; }
        public DateTime? ngayketthuc { get; set; }
        public string MAHH { get; set; }
        public string MAHHCOUNT { get; set; }
        public string PHAMVI { get; set; }
        public string PHAMVICOUNT { get; set; }
        public Nullable<decimal> HANMUC { get; set; }

        public string GHICHU { get; set; }

        public double ckhd { get; set; }
        public string BBTT { get; set; }
        public Nullable<decimal> DSTU { get; set; }
        public Nullable<decimal> DSDEN { get; set; }
        public Nullable<double> ck { get; set; }
    }
    public partial class DATA_DANHMUCHT_CHITIET
    {
        public string MACTHT { get; set; }
        public string TENCTHT { get; set; }
        public DateTime? ngaybatdau { get; set; }
        public DateTime? ngayketthuc { get; set; }
        public string MAHH { get; set; }
        public string MAHHCOUNT { get; set; }
        public string PHAMVI { get; set; }
        public string PHAMVICOUNT { get; set; }
        public Nullable<decimal> HANMUC { get; set; }

        public string GHICHU { get; set; }

        public string MACTKM { get; set; }
        public string BBTT { get; set; }
        public Nullable<decimal> DSTU { get; set; }
        public Nullable<decimal> DSDEN { get; set; }
        public Nullable<double> ck { get; set; }
    }
    public partial class DULIEUBAOCAO17
    {
        public string SCT { get; set; }
        public string MAKH { get; set; }
        public string donvi { get; set; }
        public DateTime NGAY { get; set; }
        public double TIEN { get; set; }
        public double SONGAY { get; set; }
        public double t1 { get; set; }
        public double t2 { get; set; }
        public double t3 { get; set; }
        public double t4 { get; set; }
        public double t5 { get; set; }
        public double t6 { get; set; }
        public double t7 { get; set; }
        public double t8 { get; set; }
        public double t9 { get; set; }
        public double t10 { get; set; }
        public double t11 { get; set; }
        public double t12 { get; set; }
        public double t13 { get; set; }
    }
    public partial class DULIEUBAOCAO24
    {
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public decimal DS1 { get; set; }
        public decimal DS2 { get; set; }
        public decimal DS3 { get; set; }
        public decimal DS4 { get; set; }
        public decimal DS { get; set; }
        public decimal Q1 { get; set; }
        public decimal Q2 { get; set; }
        public decimal Q3 { get; set; }
        public decimal Q4 { get; set; }
        public decimal KH { get; set; }
        public decimal DOANHSOLONHONQUI { get; set; }
        public int NAM { get; set; }
        public string MAKM { get; set; }
        public double? ckqui { get; set; }
        public double? ckdat { get; set; }
        public string TENDVBC { get; set; }
    }
    public partial class DULIEUBAOCAO16
    {
        public string macn { get; set; }
        public string mien { get; set; }
        public decimal tien { get; set; }
        public decimal tien_hh { get; set; }
    }
    public partial class DULIEUBAOCAO24FINAL
    {
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public decimal DS1 { get; set; }
        public decimal DS2 { get; set; }
        public decimal DS3 { get; set; }
        public decimal DS4 { get; set; }
        public decimal DS { get; set; }
        public decimal Q1 { get; set; }
        public decimal Q2 { get; set; }
        public decimal Q3 { get; set; }
        public decimal Q4 { get; set; }
        public decimal KH { get; set; }
        public decimal DOANHSOLONHONQUI { get; set; }
        public int NAM { get; set; }
        public string MAKM { get; set; }
        public double ckqui { get; set; }
        public double ckdat { get; set; }
        public string TENDVBC { get; set; }
    }
    public partial class DULIEUBAOCAO26
    {
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public decimal DS1 { get; set; }
        public decimal DS2 { get; set; }
        public decimal DS3 { get; set; }

        public decimal DS { get; set; }
        public decimal T1 { get; set; }
        public decimal T2 { get; set; }
        public decimal T3 { get; set; }

        public decimal KH { get; set; }
        public decimal DOANHSOLONHONQUI { get; set; }
        public int NAM { get; set; }
        public string MAKM { get; set; }
        public double? ckqui { get; set; }
        public int THANG { get; set; }
        public string QUI { get; set; }
        public string TENDVBC { get; set; }
    }
    public partial class DULIEUBAOCAO26FINAL
    {
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public decimal DS1 { get; set; }
        public decimal DS2 { get; set; }
        public decimal DS3 { get; set; }

        public decimal DS { get; set; }
        public decimal T1 { get; set; }
        public decimal T2 { get; set; }
        public decimal T3 { get; set; }

        public decimal KH { get; set; }
        public decimal DOANHSOLONHONQUI { get; set; }
        public int NAM { get; set; }
        public string MAKM { get; set; }
        public double ckqui { get; set; }
        public int THANG { get; set; }
        public string QUI { get; set; }
        public string TENDVBC { get; set; }
    }
    public partial class DULIEUBAOCAO7
    {
        public string SCT { get; set; }
        public DateTime NGAY { get; set; }
        public string MAKH { get; set; }
        public int SONGAY { get; set; }
        public string donvi { get; set; }
        public decimal TIEN { get; set; }
        public decimal t1 { get; set; }
        public decimal t2 { get; set; }
        public decimal t3 { get; set; }
        public decimal t4 { get; set; }
        public decimal t5 { get; set; }
        public decimal t6 { get; set; }
        public decimal t7 { get; set; }
        public decimal t8 { get; set; }
        public decimal t9 { get; set; }
        public decimal t10 { get; set; }
        public decimal t11 { get; set; }
        public decimal t12 { get; set; }
        public decimal t13 { get; set; }
    }

    public partial class DULIEUBAOCAO7FINAL
    {
        public string SCT { get; set; }
        public string NGAY { get; set; }
        public string MAKH { get; set; }
        public int SONGAY { get; set; }
        public string donvi { get; set; }
        public decimal TIEN { get; set; }
        public decimal t1 { get; set; }
        public decimal t2 { get; set; }
        public decimal t3 { get; set; }
        public decimal t4 { get; set; }
        public decimal t5 { get; set; }
        public decimal t6 { get; set; }
        public decimal t7 { get; set; }
        public decimal t8 { get; set; }
        public decimal t9 { get; set; }
        public decimal t10 { get; set; }
        public decimal t11 { get; set; }
        public decimal t12 { get; set; }
        public decimal t13 { get; set; }
    }
    public class DULIEUBAOCAO13
    {
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public decimal TIEN { get; set; }
        public decimal SOLUONG { get; set; }
        public string MAQUAY { get; set; }

    }
    public class DULIEUBAOCAO15
    {
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public decimal TIEN { get; set; }
        public decimal SOLUONG { get; set; }
        public string MAQUAY { get; set; }

    }
    public class DULIEUBAOCAO25
    {
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string DIACHI { get; set; }
        public string MATINH { get; set; }
        public string PHANLOAI { get; set; }
        public string PHAMLOAIKHACHHANG { get; set; }
        public string TENDVBC { get; set; }
        public decimal T1 { get; set; }
        public decimal T2 { get; set; }
        public decimal T3 { get; set; }
        public decimal T4 { get; set; }
    }

    public class DULIEUBAOCAO53
    {
        public string MAKH { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public string DONVI { get; set; }
        public string DIACHI { get; set; }
        public string MATINH { get; set; }
        public string PHANLOAI { get; set; }
        public string PHAMLOAIKHACHHANG { get; set; }
        public string TENDVBC { get; set; }
        public decimal T1 { get; set; }
        public decimal T2 { get; set; }
        public decimal T3 { get; set; }
        public decimal T4 { get; set; }
    }

    public class DULIEUBAOCAO54
    {
        public string MAKH { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public string DONVI { get; set; }
        public string DIACHI { get; set; }
        public string MATINH { get; set; }
        public string PHANLOAI { get; set; }
        public string PHAMLOAIKHACHHANG { get; set; }
        public string TENDVBC { get; set; }
        public decimal T1 { get; set; }
        public decimal T2 { get; set; }
        public decimal T3 { get; set; }
        public decimal T4 { get; set; }
    }
    public class DULIEUBAOCAO55
    {
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string TENDVBC { get; set; }
        public decimal T1 { get; set; }
        public decimal T2 { get; set; }
        public decimal T3 { get; set; }
        public string QUI { get; set; }
    }
    public class DULIEUBAOCAO56
    {
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string TENDVBC { get; set; }
        public decimal T1 { get; set; }
        public decimal T2 { get; set; }
        public decimal T3 { get; set; }
        public string QUI { get; set; }
    }
    public class DULIEUBAOCAO27
    {
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string TENDVBC { get; set; }
        public decimal T1 { get; set; }
        public decimal T2 { get; set; }
        public decimal T3 { get; set; }
    }
    public class DULIEUBAOCAO35
    {
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public decimal DS1 { get; set; }
        public decimal T1 { get; set; }
        public decimal DOANHSOLONHONQUY { get; set; }
        public int NAM { get; set; }
        public string MAKM { get; set; }
        //public double ckqui { get { return ckqui; } set { ckqui = 0; } }
        public int THANG { get; set; }
        public int QUI { get; set; }
        public string TENDVBC { get; set; }
    }
    public class DULIEUBAOCAO28
    {
        public string TINH { get; set; }
        public string TENDVBC { get; set; }
        public string MAKH { get; set; }
        public string TENKH { get; set; }
        public decimal MUAHANG1 { get; set; }
        public decimal MUAHANG2 { get; set; }
        public decimal MUAHANG3 { get; set; }
        public decimal MUAHANG4 { get; set; }
        public decimal MUAHANG5 { get; set; }
        public decimal MUAHANG6 { get; set; }
        public decimal MUAHANG7 { get; set; }
        public decimal MUAHANG8 { get; set; }
        public decimal MUAHANG9 { get; set; }
        public decimal MUAHANG10 { get; set; }
        public decimal MUAHANG11 { get; set; }
        public decimal MUAHANG12 { get; set; }
        public decimal MUAHANG { get; set; }
    }
    public class DULIEUBAOCAO29
    {
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string TENDVBC { get; set; }
        public string NAM { get; set; }
        public string QUI { get; set; }
        public decimal T1 { get; set; }

    }
    public class DULIEUBAOCAO29_2022
    {
        public string mahh { get; set; }
        public decimal soluong { get; set; }
        public string dvt { get; set; }
        public string tenhh { get; set; }
        public decimal tien { get; set; }
        public string mapl { get; set; }
        public string MAQUAY { get; set; }
        public string NHOM { get; set; }

    }
    public class DULIEUBAOCAO23
    {
        public string TENDVBC { get; set; }
        public string TENTINH { get; set; }
        public string MATINH { get; set; }
        public int NAM { get; set; }
        public int THANG { get; set; }
        public decimal TIEN { get; set; }
    }
    public class DULIEUBAOCAOFINAL
    {
        public string TENDVBC { get; set; }
        public string TENTINH { get; set; }
        public string MATINH { get; set; }
        public decimal DSKHOAN { get; set; }

        public decimal DSTUDAUNAMNOW { get; set; }
        public decimal DSTUDAUNAMLAST { get; set; }
        public decimal DSTUDAUNAMTHANGTRUOCNOW { get; set; }
        public decimal DSTUDAUNAMTHANGTRUOCLAST { get; set; }
        public decimal DSTRONGTHANGNOW { get; set; }
        public decimal DSTRONGTHANGLAST { get; set; }
        public decimal TILETHANGTRUOC { get; set; }
        public decimal TILETHANG { get; set; }
        public decimal TILETRONGTHANG { get; set; }
        public decimal DSKHOANTHANGTRUOC { get; set; }
        public decimal DSKHOANTHANG { get; set; }
        public decimal DSKHOANTRONGTHANG { get; set; }
    }

    public class DULIEUBAOCAO
    {
        public DateTime NGAY { get; set; }
        public string MaPL { get; set; }
        public string MIEN { get; set; }
        public string TENDVBC { get; set; }
        public string MACN { get; set; }
        public string MATINH { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string phanloai { get; set; }
        public string phanloaikhachhang { get; set; }
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string DIACHI { get; set; }
        public decimal SOLUONG { get; set; }
        public decimal DONGIA { get; set; }
        public decimal DONGIA_VAT { get; set; }
        public string DVT { get; set; }
        public string NHOM { get; set; }
        public decimal TIEN { get; set; }
        public string MATDV { get; set; }
        public string TENTDV { get; set; }
        public decimal TIENCK { get; set; }
        //public decimal TYLECK { get; set; }
        public string MAKM { get; set; }
        public string SOHD { get; set; }
        public string SOHD_DT { get; set; }
        public double tienvat { get; set; }
        //public string DIACHI { get; set; }
        public int TICHDIEM { get; set; }
        public string MACTHT { get; set; }
        public int THANG { get; set; }
        public int NAM { get; set; }
        public string MANV { get; set; }
        public string SOLO { get; set; }
        public string HANDUNG { get; set; }
    }
    public partial class Themmatdv
    {

        public string idglobal_manager { get; set; }
        public string ten_manager { get; set; }
        public string idglobal_director { get; set; }
        public string ten_director { get; set; }
        public string idglobal_region { get; set; }
        public string ten_region { get; set; }

        public string macn { get; set; }

    }
    public class DULIEUBAOCAO45
    {
        public DateTime NGAY { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public decimal SOLUONG { get; set; }
        public decimal DONGIA { get; set; }
        public decimal TIEN { get; set; }
        public string SOHD { get; set; }

    }
    public class DULIEUBAOCAOLAY
    {
        public int THANG { get; set; }
        public int NAM { get; set; }
        public string TENDVBC { get; set; }
        public string MATINH { get; set; }
        public string QUANHUYEN { get; set; }
        public string MIEN { get; set; }
        public string PHANLOAI { get; set; }
        public string NHOM { get; set; }
        //public string phanloai { get; set; }
        public string MATDV { get; set; }
        public string TENTDV { get; set; }
        public string phanloaikhachhang { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public decimal SOLUONG { get; set; }
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string DIACHI { get; set; }
        public decimal DOANHTHUTHUAN { get; set; }
        public decimal DOANHTHU { get; set; }
        public double TIENVAT { get; set; }
        //public decimal TYLECK { get; set; }

    }
    public class DULIEUBAOCAOPOWERBI
    {
        public int THANG { get; set; }
        public int NAM { get; set; }
        public string MACN { get; set; }
        public string MATINH { get; set; }
        public string MIEN { get; set; }
        public string PHANLOAI { get; set; }
        public string NHOM { get; set; }
        //public string phanloai { get; set; }
        public string MATDV { get; set; }
        public string TENTDV { get; set; }
        public string phanloaikhachhang { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public decimal SOLUONG { get; set; }
        public decimal DOANHTHUTHUAN { get; set; }
        public decimal DOANHTHU { get; set; }
        //public decimal TYLECK { get; set; }

    }


    public class DATATRACUUKHACHHANG
    {
        public DateTime NGAY { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }

        public decimal SOLUONG { get; set; }
        public string DVT { get; set; }
        public decimal TIEN { get; set; }
        public List<string> MAKM { get; set; }
    }
    public class ListKhuVuc
    {
        public string matinh { get; set; }
        public string tentinh { get; set; }
    }
    public class ListBOLOC
    {
        public List<TBL_DANHMUCTINH> TINH { get; set; }
        public List<ListNhomSP> SP { get; set; }
        public List<LoaiHD> HD { get; set; }
        public List<ListKhuyenMai> KM { get; set; }
    }
    public class LoaiHD
    {
        public string loaihd { get; set; }

    }
    public partial class ListTonKho
    {
        public string MANHOM { get; set; }
        public string TENNHOM { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public decimal SL_TONDAUKY2 { get; set; }
        public decimal SL_XUAT2 { get; set; }
        public decimal SL_NHAP2 { get; set; }
        public decimal SL_TONCUOIKY2 { get; set; }
        public string TENDVBC { get; set; }
        public string MACH { get; set; }
        public string MIEN { get; set; }
        public string THANG { get; set; }
    }
    public partial class ModelListTonKho
    {
        public List<ListTonKho> Data { get; set; }
    }
    public partial class GETSOHD
    {
        public int MADH { get; set; }
        public string DATENOW { get; set; }
    }
    public partial class ListDMThau
    {
        public string MAHD { get; set; }
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string MACN { get; set; }

    }
    public partial class ListHopDong
    {
        public string MAHD { get; set; }
        public string MAKH { get; set; }
        public string DONVI { get; set; }
    }
    public partial class Dulieuthau
    {
        public List<ListDMThau> DANHMUC { get; set; }
        public List<ListKhuVuc> KHUVUC { get; set; }
        public List<ListNhomSP> SANPHAM { get; set; }
        public List<ListQuyetDinh> QUYETDINH { get; set; }
        public List<string> LOAIHD { get; set; }
    }
    public partial class Dulieutimkiem
    {
        public List<ListKhachHang> KHACHHANG { get; set; }
        public List<ListKhuVuc> KHUVUC { get; set; }
        public List<ListQuan> QUANHUYEN { get; set; }
        public List<ListNhomSP> SANPHAM { get; set; }
        public List<ListTrinhDuocVien> TDV { get; set; }
        public List<string> NHOM { get; set; }
        public List<ListKhuyenMai> CTKM { get; set; }
        public List<ListChuongTrinhHT> CTHT { get; set; }
        public List<string> PHANLOAI { get; set; }
        public List<ListKho> KHO { get; set; }

    }
    public partial class Dulieukyhan
    {
        public List<ListKhachHang> KHACHHANG { get; set; }
        public List<ListKhuVuc> KHUVUC { get; set; }

        public List<ListTrinhDuocVien> TDV { get; set; }
        public List<string> NHOM { get; set; }

        public List<string> PHANLOAI { get; set; }
        public List<string> matk { get; set; }

    }
    public partial class Dulieucongno
    {
        public string SCT { get; set; }
        public DateTime? NGAY { get; set; }
        public string NOIDUNG { get; set; }
        public string NODAUKY { get; set; }
        public string CODAUKY { get; set; }
        public string PSNO { get; set; }
        public string PSCO { get; set; }
        public string COCUOIKY { get; set; }
        public string NOCUOIKY { get; set; }
        public string TPSNO { get; set; }
        public string TPSCO { get; set; }
        public string TON { get; set; }
    }
    public partial class DulieucongnoTT423
    {
        public string SCT { get; set; }
        public DateTime? NGAY { get; set; }
        public string NOIDUNG { get; set; }
        public decimal? NODAUKY { get; set; }
        public decimal? CODAUKY { get; set; }
        public decimal? PSNO { get; set; }
        public decimal? PSCO { get; set; }
        public decimal? COCUOIKY { get; set; }
        public decimal? NOCUOIKY { get; set; }
        public string TPSNO { get; set; }
        public string TPSCO { get; set; }
        public string TON { get; set; }
    }
    public partial class DulieucongnoRP
    {
        public string SCT { get; set; }
        public string NGAY { get; set; }
        public string NOIDUNG { get; set; }
        public string TK { get; set; }
        public decimal NODAUKY { get; set; }
        public decimal CODAUKY { get; set; }
        public decimal PSNO { get; set; }
        public decimal PSCO { get; set; }
        public decimal COCUOIKY { get; set; }
        public decimal NOCUOIKY { get; set; }
        public string MAKH { get; set; }
        public string TENKH { get; set; }
        public string txttien { get; set; }
        public int TUTHANG { get; set; }
        public int DENTHANG { get; set; }
        public int NAM { get; set; }
        public DateTime TUNGAY { get; set; }
        public DateTime NGAYIN { get; set; }
        public DateTime DENNGAY { get; set; }
        public string tencn { get; set; }
        public string tinh { get; set; }
        public string DIACHIKH { get; set; }
        public string dt { get; set; }
        public string nganhang { get; set; }
        public string taikhoan { get; set; }
        public string diachi { get; set; }
        //public string TPSNO { get; set; }
        //public string TPSCO { get; set; }
        //public string TON { get; set; }
        public string tendvbc { get; set; }
    }
    public partial class apiketqua
    {
        public List<string> macn { get; set; }
        public string tungay { get; set; }
        public string denngay { get; set; }
        public string loaiphieu { get; set; }
        public string sohd { get; set; }
        public string solo { get; set; }
        public string handung { get; set; }
        public List<string> makh { get; set; }
        public List<string> khuvuc { get; set; }
        public List<string> mahh { get; set; }
        public string manhom { get; set; }
        public List<string> matdv { get; set; }
        public List<string> mactkm { get; set; }
        public List<string> mactht { get; set; }
        public string taikhoan { get; set; }
        public List<string> phanloai { get; set; }
        public string kho { get; set; }
    }
    public partial class Dulieucongnodoichieu
    {
        public string SCT { get; set; }
        public DateTime? NGAY { get; set; }
        public string NOIDUNG { get; set; }

        public decimal NODAUKY { get; set; }
        public decimal CODAUKY { get; set; }
        public decimal PSNO { get; set; }
        public decimal PSCO { get; set; }
        public decimal COCUOIKY { get; set; }
        public decimal NOCUOIKY { get; set; }
        public string MAKH { get; set; }
        public string TENKH { get; set; }
        public string txttien { get; set; }
        public int TUTHANG { get; set; }
        public int DENTHANG { get; set; }
        public int NAM { get; set; }
        public DateTime TUNGAY { get; set; }
        public DateTime NGAYIN { get; set; }
        public DateTime DENNGAY { get; set; }
        public string tencn { get; set; }
        public string tinh { get; set; }
        public string DIACHIKH { get; set; }
        public string dt { get; set; }
        public string nganhang { get; set; }
        public string taikhoan { get; set; }
        public string diachi { get; set; }
        //public string TPSNO { get; set; }
        //public string TPSCO { get; set; }
        //public string TON { get; set; }
        public string tendvbc { get; set; }
    }

    public partial class DulieucongnodoichieuRP
    {
        public string SCT { get; set; }
        public string NGAY { get; set; }
        public string NOIDUNG { get; set; }
        public decimal NODAUKY { get; set; }
        public decimal CODAUKY { get; set; }
        public decimal PSNO { get; set; }
        public decimal PSCO { get; set; }
        public decimal COCUOIKY { get; set; }
        public decimal NOCUOIKY { get; set; }
        public string MAKH { get; set; }
        public string TENKH { get; set; }
        public string txttien { get; set; }


        public DateTime TUNGAY { get; set; }
        public DateTime NGAYIN { get; set; }
        public DateTime DENNGAY { get; set; }
        public string tencn { get; set; }
        public string tinh { get; set; }
        public string DIACHIKH { get; set; }
        public string dt { get; set; }
        public string nganhang { get; set; }
        public string taikhoan { get; set; }
        public string diachi { get; set; }
        //public string TPSNO { get; set; }
        //public string TPSCO { get; set; }
        //public string TON { get; set; }
        public string tendvbc { get; set; }
    }
    public partial class KetquatimkiemX
    {
        public string FKEY { get; set; }
        public string SOHD { get; set; }
        public string SOCTKH { get; set; }
        public string THEO { get; set; }
        public string MAPL { get; set; }
        public string MAKH { get; set; }
        public string DIACHI { get; set; }
        public string DONVI { get; set; }
        public string DVT { get; set; }
        public DateTime NGAYLAPHD { get; set; }
        public DateTime NGAYCTKH { get; set; }
        public string NHAPTAIKHO { get; set; }
        public string MATT { get; set; }
        public int? THUESUAT { get; set; }
        public string TENNGUOIGD { get; set; }
        public string MASOTHUE { get; set; }
        public string MATDV { get; set; }
        public string MATINH { get; set; }
        public string MACH { get; set; }
        public string MAKM { get; set; }
        public DateTime? NGAYGIAOHANG { get; set; }
        public bool KT { get; set; }
        public int? STT { get; set; }
        public string TENHH { get; set; }
        public string MAHH { get; set; }
        public double TYLECK { get; set; }
        public decimal SOLUONG { get; set; }
        public decimal DONGIA { get; set; }
        public decimal THANHTIEN { get; set; }
        public string MALO { get; set; }
        public string HANDUNG { get; set; }
        public string KIHIEU { get; set; }
        public string HOPDONG { get; set; }
    }
    public partial class Ketquadieuchuyen
    {
        public string sohd { get; set; }
        public DateTime ngaylaphd { get; set; }
        public string noidi { get; set; }
        public string noiden { get; set; }
        public int stt { get; set; }
        public string mahh { get; set; }
        public string tenhh { get; set; }
        public string dvt { get; set; }
        public string malo { get; set; }
        public string handung { get; set; }
        public double soluong { get; set; }
        public double dongia { get; set; }
        public double thanhtien { get; set; }
        public string nguoivanchuyen { get; set; }

    }
    public partial class KetquatimkiemN
    {

    }
    public partial class ListDonHang
    {
        public string MADH { get; set; }
        public string DONVI { get; set; }
        public string NGAYDAT { get; set; }
        public bool DUYETDH { get; set; }
        public string MAKH { get; set; }
    }
    public partial class ListQuyetDinh
    {
        public string MAQD { get; set; }
        public string TENQD { get; set; }
    }
    public partial class ListKho
    {
        public string macn { get; set; }
        public int STT { get; set; }
        public string noinhan { get; set; }
        public string diachi { get; set; }
        public int? THUESUAT_NB { get; set; }
    }
    public partial class TBL_DANHMUCTDV1
    {
        public string macn { get; set; }
        public string MaTDV { get; set; }
        public string TenTDV { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        public Nullable<bool> nghiviec { get; set; }
        public Nullable<System.DateTime> Ngaynghiviec { get; set; }
        public string idlocal { get; set; }
        public string idglobal { get; set; }
        public string idglobal_supervisor { get; set; }
        public string idglobal_manager { get; set; }
        public string idglobal_director { get; set; }
        public string idglobal_region { get; set; }
    }
    public partial class CHITIET331AP
    {
        public string makhc { get; set; }
        public DateTime ngaytt { get; set; }
        public decimal tien { get; set; }

    }
    public partial class TONGHOPCONGNOAP
    {
        public string makh { get; set; }
        public double nodauky { get; set; }
        public double codauky { get; set; }
        public double psno { get; set; }
        public double psco { get; set; }
        public double nocuoiky { get; set; }
        public double cocuoiky { get; set; }
        public string noidung { get; set; }
        public string diachi_kh { get; set; }

    }
    public partial class TBL_DANHMUCTAIKHOANKETOAN
    {
        public string macn { get; set; }
        public string matk { get; set; }
        public string tkcaptren { get; set; }
        public string tentk { get; set; }
        public int? bactk { get; set; }
        public int? dunoco { get; set; }
        public bool? thamchieu { get; set; }
        public bool? tkcongno { get; set; }
        public bool? batbuoc { get; set; }
        public bool? sudung { get; set; }
        public bool? ngoaite { get; set; }
    }
    public partial class ListChuongTrinhKM
    {
        public string MACTKM { get; set; }
        public string TENCTKM { get; set; }
        public string MAHH { get; set; }
        public int? TICHDIEM { get; set; }
        public decimal? HANMUC { get; set; }
        public double? ck { get; set; }
        public int? BBTT { get; set; }

        public DateTime ngaybatdau { get; set; }

        public DateTime? ngayketthuc { get; set; }

    }
    public partial class NGUOIDUNG
    {
        public string TAIKHOAN { get; set; }
        public string HOVATEN { get; set; }
    }
    public partial class ListHopdongKD
    {
        public string MAHOPDONG { get; set; }
        public string TENHOPDONG { get; set; }
        public int? ck { get; set; }
        public DateTime ngaybatdau { get; set; }
        public DateTime ngayketthuc { get; set; }
    }
    public partial class QLKHKD
    {
        public List<ListHopdongKD> hopdong { get; set; }
        public IEnumerable<TBL_DANHMUCPHANQUYENKD> nguoidung { get; set; }
    }
    public partial class QLKHSC
    {
        public List<ListHopdongKD> hopdong { get; set; }
        public IEnumerable<TBL_DANHMUCPHANQUYENSC> nguoidung { get; set; }
    }
    public partial class ListChuongTrinhHT
    {
        public string MACTHT { get; set; }
        public string TENCTHT { get; set; }
        public string MAHH { get; set; }
        public int? TICHDIEM { get; set; }
        public decimal? HANMUC { get; set; }
        public string MACTKM { get; set; }
    }
    public partial class BAOCAOCTHT
    {
        public string MACTHT { get; set; }
        public string TENCTHT { get; set; }
        public DateTime? NGAYBATDAU { get; set; }
        public DateTime? NGAYKETTHUC { get; set; }
    }
    public partial class DOANHSOTHANGNAM
    {
        public decimal? doanhsothang { get; set; }
        public decimal? doanhsonam { get; set; }
    }
    public partial class BAOCAODATA
    {
        public List<BAOCAOCTHT> CTHT { get; set; }
        public List<TBL_DANHMUCLOAIBAOCAO> LOAIBC { get; set; }

    }
    public partial class BSCNGUOIDUNG
    {
        public string phanloai { get; set; }
        public bool? EXCEL { get; set; }
        public bool? WORD { get; set; }
        public bool? PDF { get; set; }
        public bool? READ_ONLY { get; set; }
    }
    public partial class BSCCHINHANH
    {
        public double? UUTIEN { get; set; }
        public string MACN { get; set; }
        public string TENCN { get; set; }
        public string MIEN { get; set; }

    }
    public partial class Quanlyhanghoa
    {
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string HOATCHAT { get; set; }
        public string DVT2 { get; set; }
        public decimal GIABAN2 { get; set; }
        public string DVT3 { get; set; }
        public decimal GIABAN3 { get; set; }

    }
    public partial class QuanlyCTBH
    {
        public List<TBL_DANHSACHCHINHANH> CHINHANH { get; set; }
        public List<ListHangHoa> HANGHOA { get; set; }
        public List<TBL_DANHMUCKM> KHUYENMAI { get; set; }
    }
    public partial class ListHangHoaWS
    {
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public string DVT1 { get; set; }
        public string DVT2 { get; set; }
        public string QUICACH { get; set; }
        public string DANGBAOCHE { get; set; }
        public string NHOM { get; set; }
        public int? SL1 { get; set; }
        public int? SL2 { get; set; }
        public int? SL3 { get; set; }
        public int? kiemsoat { get; set; }
        public string SDK { get; set; }
        public int? phanphoi { get; set; }
        public string ghichu { get; set; }
    }
    public partial class ListHTTT
    {
        public string MATT { get; set; }
        public string TENTT { get; set; }

    }
    public partial class THONGTINNO
    {
        public decimal COCUOIKY { get; set; }
        public decimal NOCUOIKY { get; set; }

    }
    public partial class THONGTINKYHANNO
    {
        public string makh { get; set; }
        public string sct { get; set; }
        public DateTime ngay { get; set; }
        public decimal tien { get; set; }

    }
    public partial class ListHangHoa
    {
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public string DVT1 { get; set; }
        public string DVT2 { get; set; }
        public string GIABAN { get; set; }
        public string QUICACH { get; set; }
        public string DANGBAOCHE { get; set; }
        public string NHOM { get; set; }
        public int? SL1 { get; set; }
        public int? SL2 { get; set; }
        public int? SL3 { get; set; }
        public int? kiemsoat { get; set; }
        public string SDK { get; set; }
        public int? phanphoi { get; set; }
        public string ghichu { get; set; }
    }
    public partial class TBL_GIABAN
    {
        public string MAHH { get; set; }
        public string GIABAN { get; set; }

    }
    public partial class APILOGINLOG
    {
        public string taikhoan { get; set; }
        public string IP { get; set; }
        public string pcname { get; set; }

    }
    public partial class TONGHOPCTBHDATA
    {
        public string MAKM { get; set; }
        public string TENKM { get; set; }
        public string MACTHT { get; set; }
        public string TENCTHT { get; set; }
        public string MATINH { get; set; }
        public string TENTINH { get; set; }
        public string NGAYBATDAU { get; set; }
        public string NGAYKETTHUC { get; set; }
        public decimal DOANHSO { get; set; }


    }
    public partial class ListData
    {
        public List<DTA_DONDATHANG> ListDDH { get; set; }
        public List<ListHangHoa> ListHH { get; set; }
        public List<string> ListTDV { get; set; }
        public List<ListKhachHang> ListKH { get; set; }
        public List<ListChuongTrinhKM> ListCTKM { get; set; }
        public List<ListChuongTrinhHT> ListCTHT { get; set; }
    }
    //public partial class ListDataHoaDonWS
    //{
    //    public List<ListHangHoa> ListHH { get; set; }
    //    public List<DTA_DONDATHANG_WS> ListDDH { get; set; }
    //    //public List<ListTrinhDuocVien> ListTDV { get; set; }
    //    public List<ListKhachHang> ListKH { get; set; }
    //}
    //public partial class ListDataKD
    //{
    //    public List<DTA_DONDATHANG_KD> ListDDH { get; set; }
    //    public List<ListHangHoa> ListHH { get; set; }
    //    //public List<ListTrinhDuocVien> ListTDV { get; set; }
    //    public List<ListKhachHang> ListKH { get; set; }
    //    public List<ListHopdongKD> ListHopdong { get; set; }
    //}
    //public partial class ListDataWS
    //{
    //    public List<DTA_DONDATHANG_WS> ListDDH { get; set; }
    //    public List<ListHangHoa> ListHH { get; set; }
    //    //public List<ListTrinhDuocVien> ListTDV { get; set; }
    //    public List<ListKhachHang> ListKH { get; set; }
    //    public List<TBL_DANHMUCHOPDONG_WS> ListHopdong { get; set; }
    //}
    public partial class DTA_DONDATHANG_KD_QUYDOI
    {
        public string MADH { get; set; }
        public System.DateTime NgayDat { get; set; }
        public Nullable<int> STT { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public string DONVI { get; set; }
        public string MACH { get; set; }
        public string MAKH { get; set; }
        public string MALO { get; set; }
        public string HANDUNG { get; set; }
        public Nullable<decimal> SOLUONG { get; set; }
        public Nullable<decimal> THUNG { get; set; }
        public Nullable<decimal> HOP { get; set; }
        public Nullable<decimal> GIABAN_VAT { get; set; }
        public Nullable<int> VAT { get; set; }
        public Nullable<bool> DUYETDH { get; set; }
        public string HOPDONG { get; set; }
        public string DIACHIGIAOHANG { get; set; }
        public string SOHD { get; set; }
        public Nullable<System.DateTime> NGAYLAPHD { get; set; }
        public string GHICHU { get; set; }
        public Nullable<double> ck { get; set; }
        public string USERTAO { get; set; }
        public Nullable<System.DateTime> NGAYTHUCHIEN { get; set; }
        public string DATE { get; set; }
    }
    public partial class DANHMUCKHUYENMAI
    {
        public string MACTKM { get; set; }
        public string TENCTKM { get; set; }
        public DateTime ngaybatdau { get; set; }
        public DateTime ngayketthuc { get; set; }

        public List<string> PHAMVI { get; set; }
        public Nullable<decimal> HANMUC { get; set; }
        public Nullable<int> TICHDIEM { get; set; }

        public bool FILEDATA { get; set; }
    }
    public partial class CTBH
    {
        public List<DANHMUCKHUYENMAI> ctkm { get; set; }
        public List<DANHMUCKHUYENMAI> ctht { get; set; }
    }
    public partial class JsonMessage
    {
        public string status { get; set; }
        public string message { get; set; }
        public Byte[] data { get; set; }
    }
    public partial class DONDATHANG
    {
        public string NGAYGIAO { get; set; }
        public string NGAY { get; set; }
        public int STT { get; set; }
        public string MADH { get; set; }
        public string MACH { get; set; }
        public string DONVI { get; set; }
        public string KHACHHANG { get; set; }
        public string MACTKM { get; set; }
        public string TENCTKM { get; set; }
        public string MACTHT { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string MATDV { get; set; }
        public string DVT { get; set; }
        public decimal? SOLUONG { get; set; }
        public int? SOLUONG2 { get; set; }
        public int? SOLUONG3 { get; set; }
        public decimal? GIABAN_VAT { get; set; }
        public int VAT { get; set; }
        public double? ck { get; set; }
        public string GHICHU { get; set; }

    }
    public partial class DONDATHANG_KD
    {
        public string NGAY { get; set; }
        public int STT { get; set; }
        public int MADH { get; set; }
        public string MACH { get; set; }
        public string DONVI { get; set; }
        public string KHACHHANG { get; set; }
        public string HOPDONG { get; set; }
        public int? ck { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }

        public string DVT { get; set; }
        public decimal? SOLUONG { get; set; }
        public decimal? GIABAN_VAT { get; set; }
        public int VAT { get; set; }
        public string GHICHU { get; set; }
        public string DATE { get; set; }
        public string MALO { get; set; }
        public string HANDUNG { get; set; }
    }
    public partial class DATA_WS

    {
        public List<DATA_CHITIET_HOADON_WS> chitiet { get; set; }
        public DATA_HOADON_WS hoadon { get; set; }
    }
    public partial class DATA_CHITIET_HOADON_WS
    {

        public int STT { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public decimal SOLUONG { get; set; }
        public int THUNG { get; set; }
        public int HOP { get; set; }
        public string DVT { get; set; }

        public string MALO { get; set; }
        public string HANDUNG { get; set; }
    }
    public partial class DATA_HOADON_WS
    {
        public string MADH { get; set; }
        public string NGAY { get; set; }
        public string KYHIEU { get; set; }
        public int TINHCHATHOADON { get; set; }
        public string PHANLOAI { get; set; }
        public string MAKH { get; set; }
        public string DONVI { get; set; }
        public string MATINH { get; set; }
        public string TENNGUOIGD { get; set; }
        public string TAIKHOAN { get; set; }
        public string NGANHANG { get; set; }
        public string DIACHI { get; set; }
        public string MASOTHUE { get; set; }
        public string EMAILKH { get; set; }
        public string DIACHIGIAOHANG { get; set; }
        public string MAHD { get; set; }
        public string PHANLOAIHH { get; set; }
        public string KHO { get; set; }
        public int PPTT { get; set; }
        public string HTTT { get; set; }

    }
    public partial class DONDATHANG_WS
    {
        public string NGAY { get; set; }
        public int STT { get; set; }
        public int MADH { get; set; }
        public string MACH { get; set; }
        public string DONVI { get; set; }
        public string KHACHHANG { get; set; }
        public string HOPDONG { get; set; }
        public string DIACHIGIAOHANG { get; set; }
        public string MAHH { get; set; }
        public string TENHH { get; set; }

        public string DVT { get; set; }
        public decimal? SOLUONG { get; set; }


        public string GHICHU { get; set; }

        public string MALO { get; set; }
        public string HANDUNG { get; set; }
    }

    public partial class ListCN
    {
        public Entities DATACN { get; set; }
        public string MACN { get; set; }

    }
    public partial class Sodonhang
    {
        public string SODH { get; set; }
        public string SOHD { get; set; }
        public bool? DUYET { get; set; }

    }
    public partial class modelqldh
    {
        public string tungay { get; set; }
        public string denngay { get; set; }
        public string matdv { get; set; }
        public string macn { get; set; }

    }
    public partial class Listmahh
    {
        public string MAHH { get; set; }
        public Nullable<int> SOLUONG { get; set; }

    }
    public partial class Quanlyhopdongthau
    {
        public string MACN { get; set; }
        public string MAKH { get; set; }
        public string MAHD { get; set; }
        public string noidung { get; set; }
        public Nullable<System.DateTime> NGAYBATDAU { get; set; }
        public Nullable<System.DateTime> NGAYKETTHUC { get; set; }
        public string giatri { get; set; }
        public string donvi { get; set; }
        public Nullable<double> ck { get; set; }
        public string phuluc { get; set; }
        public string nguoidung { get; set; }
        public string MAQD { get; set; }
        public string TENQD { get; set; }
        public Nullable<System.DateTime> NGAYQD { get; set; }
        public string LOAIHD { get; set; }
        public Nullable<bool> KT { get; set; }
        public string GHICHU { get; set; }
        public List<Listmahh> Listmahh { get; set; }

    }
    public partial class PHIEUXUATKHO
    {
        public TBL_DANHMUCTAIKHOAN thongtin { get; set; }
        public Invoice Invoice { get; set; }
        public string DIACHIGIAOHANG { get; set; }
    }
    public partial class BANGSOLOHANDUNG
    {
        public string MAHH { get; set; }
        public string TENHH { get; set; }
        public string DVT { get; set; }
        public string MALO { get; set; }
        public string HANDUNG { get; set; }
        public string KHO { get; set; }
        public string soluong { get; set; }
    }
    public partial class ImportHopDongWS
    {
        public string MAHD { get; set; }
        public string MAKH { get; set; }
        public string TENKH { get; set; }
        public string NOIDUNG { get; set; }
        public DateTime NGAYBATDAU { get; set; }
        public DateTime NGAYKETTHUC { get; set; }
        public string DIACHIGIAOHANG { get; set; }
        public string MAHH { get; set; }

        public string SDK { get; set; }
        public decimal GIASP { get; set; }
        public int SLQUI { get; set; }
        public int SLNAM { get; set; }
        public string GHICHU { get; set; }

    }

}