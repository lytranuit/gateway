using ApplicationChart.Models;
using ApplicationChart.Report;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ApplicationChart.Controllers
{
    [Authorize]
    public class APIBSCController : ApiController
    {
        Entities SC = new Entities("KT_SCEntities");
        Entities HaNoi = new Entities("KT_HNEntities");
        Entities ThaiBinh = new Entities("KT_TBEntities");
        Entities ThaiNguyen = new Entities("KT_TNGEntities");

        Entities PhuTho = new Entities("KT_PTEntities");

        Entities TT423 = new Entities("TT423Entities");
        Entities TayNinh = new Entities("KT_TNEntities");
        Entities BinhDinh = new Entities("KT_BDEntities");
        Entities CanTho = new Entities("KT_CTEntities");
        Entities DongNai = new Entities("KT_DNEntities");
        Entities BinhDuong = new Entities("KT_BDGEntities");
        Entities DaNang = new Entities("KT_DNAEntities");
        Entities HoChiMinh = new Entities("KT_HCMEntities");
        Entities NgheAn = new Entities("KT_NAEntities");
        Entities NgheAn2 = new Entities("KT_NA_2Entities");
        Entities QuangTri = new Entities("KT_QTEntities");
        Entities QuangNgai = new Entities("KT_QNEntities");
        Entities PhuYen = new Entities("KTEntities");
        Entities AnGiang = new Entities("KT_AGEntities");
        Entities CaMau = new Entities("KT_CMEntities");
        Entities GiaLai = new Entities("KT_GLEntities");
        Entities Hue = new Entities("KT_HUEEntities");
        Entities HaiPhong = new Entities("KT_HPEntities");
        Entities LamDong = new Entities("KT_LDEntities");
        Entities NhaTrang = new Entities("KT_NTEntities");
        Entities TienGiang = new Entities("KT_TGEntities");
        Entities VinhLong = new Entities("KT_VLEntities");
        Entities Daknong = new Entities("KT_DNONGEntities");
        Entities ThanhHoa = new Entities("KT_THOEntities");
        Entities BinhThuan = new Entities("KT_BTEntities");
        CHQ10Entities1 PTTT = new CHQ10Entities1("PTTTEntities");
        CHQ10Entities1 CHQ10 = new CHQ10Entities1("CHQ10Entities");
        CHQ10Entities1 CHPPSP = new CHQ10Entities1("CHPPSPEntities");
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();
        KT_THEntities1 DATATH1 = new KT_THEntities1("KT_THEntities1");
        KT_THEntities1 DATATH2 = new KT_THEntities1("KT_THEntities2");
        List<EntitiesCN> queryCN = new List<EntitiesCN> {
            new EntitiesCN {data = new Entities("TT423Entities") , macn = "TT423"},
            new EntitiesCN {data = new Entities("KT_TNEntities") , macn = "TN"},
            new EntitiesCN {data = new Entities("KT_BDEntities") , macn = "BD"},
            new EntitiesCN {data = new Entities("KT_CTEntities") , macn = "CT"},
            new EntitiesCN {data = new Entities("KT_DNEntities") , macn = "DN"},
            new EntitiesCN {data = new Entities("KT_BDGEntities") , macn = "BDG"},
            new EntitiesCN {data = new Entities("KT_DNAEntities") , macn = "DNA"},
            new EntitiesCN {data = new Entities("KT_HCMEntities") , macn = "HCM"},
            new EntitiesCN {data = new Entities("KT_NAEntities") , macn = "NA"},
            new EntitiesCN {data = new Entities("KT_NA_2Entities") , macn = "NA2"},
            new EntitiesCN {data = new Entities("KT_QTEntities") , macn = "QT"},
            new EntitiesCN {data = new Entities("KT_QNEntities") , macn = "QN"},
            new EntitiesCN {data = new Entities("KTEntities") , macn = "PY"},
            new EntitiesCN {data = new Entities("KT_AGEntities") , macn = "AG"},
            new EntitiesCN {data = new Entities("KT_CMEntities") , macn = "CM"},
            new EntitiesCN {data = new Entities("KT_GLEntities") , macn = "GL"},
            new EntitiesCN {data = new Entities("KT_HUEEntities") , macn = "HUE"},
                 new EntitiesCN {data = new Entities("KT_HPEntities") , macn = "HP"},
            new EntitiesCN {data = new Entities("KT_LDEntities") , macn = "LD"},
            new EntitiesCN {data = new Entities("KT_NTEntities") , macn = "NT"},
            new EntitiesCN {data = new Entities("KT_TGEntities") , macn = "TG"},
            new EntitiesCN {data = new Entities("KT_VLEntities") , macn = "VL"},
            new EntitiesCN {data = new Entities("KT_DNONGEntities") , macn = "DNONG"},
                   new EntitiesCN {data = new Entities("KT_PTEntities") , macn = "PT"},
            new EntitiesCN {data = new Entities("KT_HNEntities") , macn = "HN"},
            new EntitiesCN {data = new Entities("KT_TNGEntities") , macn = "TNG"},
            new EntitiesCN {data = new Entities("KT_TBEntities") , macn = "TB"},
             new EntitiesCN {data = new Entities("KT_THOEntities") , macn = "THO"},
              new EntitiesCN {data = new Entities("KT_BTEntities") , macn = "BT"},
                 new EntitiesCN {data = new Entities("KT_PYPHARM_HCMEntities") , macn = "DPY_HCM"},
        };
        List<EntitiesCH> queryCH = new List<EntitiesCH> {
            new EntitiesCH {data = new CHQ10Entities1("PTTTEntities") , macn = "PTTT"},
            new EntitiesCH {data = new CHQ10Entities1("CHQ10Entities") , macn = "CHQ10"},
            new EntitiesCH {data = new CHQ10Entities1("CHPPSPEntities") , macn = "CHPPSP"},

        };

        public IHttpActionResult Get()
        {
            var data = new APIBSC();
            var tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name);
            data.PHANLOAI = tv.phanloai;
            data.CTHT = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.Select(cl => new BAOCAOCTHT { MACTHT = cl.MACTHT, TENCTHT = cl.TENCTHT }).ToList();
            List<string> listcn = tv.macn.Split(',').ToList();
            data.CHINHANH = db2.TBL_DANHSACHCHINHANH.Where(n => listcn.Contains(n.macn) && n.check == true).Select(cl => new BSCCHINHANH { MACN = cl.macn, MIEN = cl.Mien, TENCN = cl.Tencn, UUTIEN = cl.stt }).ToList();
            data.MAPLKH = db2.TBL_DANHMUCPHANLOAIKHACHHANG.OrderBy(n => n.phanloaikhachhang).ToList();
            data.LOAIBC = db2.TBL_DANHMUCLOAIBAOCAO.ToList();
            if (tv.manhom != null)
            {
                var listnhom = tv.manhom.Split(',').ToList();
                data.NHOMHANG = DATATH1.TBL_DANHMUCNHOMSANPHAM.Where(n => n.STT != 4 && n.STT != 0 && listnhom.Contains(n.MANHOM)).ToList();
            }
            else
            {
                data.NHOMHANG = DATATH1.TBL_DANHMUCNHOMSANPHAM.Where(n => n.STT != 4 && n.STT != 0).ToList();
            }
          
            return Json(data);
        }
        public IHttpActionResult Getchinhanh()
        {
            var tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name);
            List<string> listcn = tv.macn.Split(',').ToList();
            var donvi = db2.TBL_DANHSACHCHINHANH.Where(n => listcn.Contains(n.macn) && n.check == true).Select(cl => new BSCCHINHANH { MACN = cl.macn, MIEN = cl.Mien, TENCN = cl.Tencn, UUTIEN = cl.stt }).ToList();
            return Json(donvi);
        }
        public IHttpActionResult Getdoanhsocongno(int loai)
        {
            var tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name);
            var nhomhang = new List<string>();
            if(tv.manhom != null)
            {
                nhomhang = tv.manhom.Split(',').ToList();
            }
            else
            {
                nhomhang = null;
            }
            var sanpham = new List<string>();
            if(tv.mahh != "ALL")
            {
                sanpham = tv.mahh.Split(',').ToList();
            }
            else
            {
                sanpham = null;
            }
            try
            {
                var maphanloai = new List<string>() { "BAN", "XK" };
                if (loai == 1)
                {
                    var datathang = DATABAOCAO0(maphanloai, tv.macn.Split(',').ToList(), GetFirstDay(DateTime.Today.Month, DateTime.Today.Year), GetLastDay(DateTime.Today.Month, DateTime.Today.Year), "ALL", nhomhang, sanpham, null, null, null, null, null, tv);
                    return Json(new DOANHSOTHANGNAM() { doanhsothang = datathang.Sum(n => n.TONGTIEN_CT_HOADON), doanhsonam = 0 });
                }
                else if (loai == 2)
                {
                    var datanam = DATABAOCAO0(maphanloai, tv.macn.Split(',').ToList(), GetFirstDay(1, DateTime.Today.Year), GetLastDay(12, DateTime.Today.Year), "ALL", nhomhang, sanpham, null, null, null, null, null, tv);
                    return Json(new DOANHSOTHANGNAM() { doanhsothang = 0, doanhsonam = datanam.Sum(n => n.TONGTIEN_CT_HOADON) });
                }
                else
                {
                    var datathang = DATABAOCAO0(maphanloai, tv.macn.Split(',').ToList(), GetFirstDay(DateTime.Today.Month, DateTime.Today.Year), GetLastDay(DateTime.Today.Month, DateTime.Today.Year), "ALL", nhomhang, sanpham, null, null, null, null, null, tv);
                    var datanam = DATABAOCAO0(maphanloai, tv.macn.Split(',').ToList(), GetFirstDay(1, DateTime.Today.Year), GetLastDay(12, DateTime.Today.Year), "ALL", nhomhang, sanpham, null, null, null, null, null, tv);
                    return Json(new DOANHSOTHANGNAM() { doanhsothang = datathang.Sum(n => n.TONGTIEN_CT_HOADON), doanhsonam = datanam.Sum(n => n.TONGTIEN_CT_HOADON) });
                }
            }
            catch (Exception)
            {
                return Json(new DOANHSOTHANGNAM() { doanhsothang = 0, doanhsonam = 0 });
            }

        }
        [HttpPost]
        public IHttpActionResult GetTimKiem(string macn)
        {
            var Info = GetInfo();
            var data = new Dulieutimkiem();
            data.SANPHAM = DATAGETSP(macn, Info);
            data.TDV = DATAGETTDV(macn, Info);
            data.KHUVUC = DATAGETKHUVUC(new List<string> { macn }, Info);
            data.KHACHHANG = DATAGETKHACHHANG(macn, Info);
            data.CTKM = DATAGETCTKM(macn);
            data.CTHT = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.Select(cl => new ListChuongTrinhHT { MACTHT = cl.MACTHT, TENCTHT = cl.TENCTHT }).ToList();
            data.PHANLOAI = DATAGETPHANLOAI(new List<string> { macn });
            data.KHO = DATAGETKHO(new List<string> { macn });
            return Json(data);
        }
        [HttpPost]
        public IHttpActionResult GetKetqua(apiketqua dataa)
        {
            var Info = GetInfo();
            if (Info.mahh != "ALL")
            {
                dataa.mahh = (dataa.mahh != null && Info.mahh.Split(',').Intersect(dataa.mahh).ToList().Count() > 0) ? Info.mahh.Split(',').Intersect(dataa.mahh).ToList() : Info.mahh.Split(',').ToList();
            }
            if (Info.matinh != "ALL")
            {
                dataa.khuvuc = (dataa.khuvuc != null && Info.matinh.Split(',').Intersect(dataa.khuvuc).ToList().Count() > 0) ? Info.matinh.Split(',').Intersect(dataa.khuvuc).ToList() : Info.matinh.Split(',').ToList();
            }
            if (Info.matdv != "ALL")
            {
                dataa.matdv = (dataa.matdv != null && Info.matdv.Split(',').Intersect(dataa.matdv).ToList().Count() > 0) ? Info.matdv.Split(',').Intersect(dataa.matdv).ToList() : Info.matdv.Split(',').ToList();
            }
            //if(Info.maquan != "ALL")
            //{
            //    Checkboxlist11 = (Checkboxlist11 != null && Info.maquan.Split(',').Intersect(Checkboxlist11).ToList().Count() > 0) ? Info.maquan.Split(',').Intersect(Checkboxlist11).ToList() : Info.maquan.Split(',').ToList();
            //}
            DateTime tungay1 = DateTime.ParseExact(dataa.tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime denngay1 = DateTime.ParseExact(dataa.denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var data = DATATIMKIEM(dataa.macn, tungay1, denngay1, dataa.loaiphieu, dataa.sohd, dataa.solo, dataa.handung, dataa.makh, dataa.khuvuc, dataa.mahh, dataa.manhom, dataa.matdv, dataa.mactkm, dataa.mactht, dataa.taikhoan, dataa.phanloai, dataa.kho);
            return Json(data);
        }
        private List<KetquatimkiemX> DATATIMKIEM(List<string> macn, DateTime tungay1, DateTime denngay1, string loaiphieu, string sohd, string solo, string handung, List<string> makh, List<string> khuvuc, List<string> mahh, string manhom, List<string> matdv, List<string> mactkm, List<string> mactht, string taikhoan, List<string> phanloai, string kho)
        {
            var data = new List<KetquatimkiemX>();
            var strcn = "DECLARE @DANHSACHHANGHOA TABLE (SOHD VARCHAR(20),MAPL VARCHAR(10),SOCTKH VARCHAR(100),THEO NVARCHAR(200),MAKH VARCHAR(50), DIACHI NVARCHAR(500),DONVI NVARCHAR(500),NGAYLAPHD SMALLDATETIME,NGAYCTKH SMALLDATETIME,NHAPTAIKHO NVARCHAR(200), MATT VARCHAR(80),THUESUAT INT,TENNGUOIGD NVARCHAR(500),MASOTHUE VARCHAR(20),MATDV VARCHAR(20),MATINH VARCHAR(20),MACH NVARCHAR(200),MAKM VARCHAR(20),NGAYGIAOHANG SMALLDATETIME,TENTDV NVARCHAR(100),DOWN VARCHAR(20),GHICHU NVARCHAR(200),KT BIT,STT INT,MAHH VARCHAR(20),TENHH NVARCHAR(400),TYLECK float,DVT NVARCHAR(60),SOLUONG money,DONGIA money,THANHTIEN money,MALO VARCHAR(20),HANDUNG VARCHAR(20),KIHIEU VARCHAR(20),HOPDONG VARCHAR(20),KTKM BIT)  INSERT INTO @DANHSACHHANGHOA SELECT HOADON.SOHD,HOADON.MAPL," + ((loaiphieu == "N") ? "HOADON.SOCTKH,HOADON.THEO" : "'',''") + ",HOADON.MAKH,HOADON.DIACHI,HOADON.DONVI,HOADON.NGAYLAPHD," + ((loaiphieu == "N") ? "HOADON.NGAYCTKH,HOADON.NHAPTAIKHO" : "HOADON.NGAYLAPHD,HOADON.NOIXUAT") + ",HOADON.MATT,HOADON.THUESUAT,HOADON.TENNGUOIGD,HOADON.MATHUE," + ((loaiphieu == "N") ? "'','',TBL_DANHMUCCUAHANG.MACH,'',HOADON.NGAYLAPHD,'',''" : "HOADON.MATDV,HOADON.MATINH,TBL_DANHMUCCUAHANG.MACH,CT_HOADON.MAKM,HOADON.NGAYGIAOHANG,'',CT_HOADON.DOWN") + ",CT_HOADON.GHICHU,CT_HOADON.KT,CT_HOADON.STT,CT_HOADON.MAHH,CT_HOADON.TENHH,CT_HOADON.TYLECK,CT_HOADON.DVT,CT_HOADON.SOLUONG,CT_HOADON.DONGIA,round(CT_HOADON.DONGIA*CT_HOADON.SOLUONG,0), CT_HOADON.MALO, CT_HOADON.HANDUNG, HoaDon.KIHIEU," + ((loaiphieu == "N") ? "'',0" : "HoaDon.HOPDONG, CT_HOADON.KTKM") + " FROM " + ((loaiphieu == "N") ? "dta_HOADON_NHAP HOADON,dta_CT_HOADON_NHAP CT_HOADON" : "dta_HOADON_XUAT HOADON,dta_CT_HOADON_XUAT CT_HOADON") + ",TBL_DANHMUCCUAHANG  WHERE HoaDon.SoHD = CT_HOADON.SOHD And HoaDon.NgayLapHD = CT_HOADON.NGAYLAPHD And CT_HOADON.KT = 1 And " + ((loaiphieu == "N") ? "HOADON.NGUOIDUNG=CT_HOADON.NGUOIDUNG" : "HoaDon.MACH = CT_HOADON.MACh") + " AND HOADON.NGAYLAPHD between '" + tungay1.ToString("yyyy-MM-dd") + "' and '" + denngay1.ToString("yyyy-MM-dd") + "'";
            if (solo != null)
            {
                strcn = strcn + "AND CT_HOADON.MALO = '" + solo + "'";
            }
            if (handung != null)
            {
                strcn = strcn + "AND CT_HOADON.HANDUNG = '" + handung + "'";
            }
            if (sohd != null)
            {
                strcn = strcn + "AND HOADON.SOHD = '" + sohd + "'";
            }
            if (makh.Count != 0)
            {
                strcn = strcn + string.Format(" AND HOADON.MAKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            }
            if (matdv.Count != 0)
            {
                strcn = strcn + string.Format(" AND HOADON.MATDV IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            if (khuvuc.Count != 0)
            {
                strcn = strcn + string.Format(" AND HOADON.MATINH IN ({0})", string.Join(",", khuvuc.Select(p => "'" + p + "'")));
            }
            if (mactkm.Count != 0)
            {
                strcn = strcn + string.Format(" AND CT_HOADON.MAKM IN ({0})", string.Join(",", mactkm.Select(p => "'" + p + "'")));
            }
            if (mactht.Count != 0)
            {
                strcn = strcn + string.Format(" AND CT_HOADON.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
            }
            if (phanloai.Count != 0)
            {
                strcn = strcn + string.Format(" AND hoadon.mapl IN ({0})", "'" + phanloai + "'");
            }
            if (mahh.Count != 0)
            {
                strcn = strcn + string.Format(" AND ct_hoadon.MAHH IN ({0})", string.Join(",", mahh.Select(p => "'" + p + "'")));
            }
            if (macn.Contains("QT"))
            {

            }
            else if (manhom != null)
            {
                if (manhom == "1")
                {
                    strcn = strcn + " AND SUBSTRING(ct_hoadon.MAHH,1,2) IN ('50','51','60','61','62','63','64','70')";
                }
                else
                {
                    strcn = strcn + " AND SUBSTRING(ct_hoadon.MAHH,1,2) NOT IN ('50','51','60','61','62','63','64','70')";
                }
            }
            if (kho != null)
            {
                strcn = strcn + "AND HOADON.NOIXUAT = N'" + kho + "'";
            }
            strcn = strcn + " select * from @DANHSACHHANGHOA where 1=1 ORDER BY NGAYLAPHD,SOHD,STT";
            foreach (var ChiNhanhId in macn)
            {
                if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    if (ChiNhanhId == "TT423")
                    {
                        data.AddRange(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<KetquatimkiemX>(strcn.Replace("HOADON.NOIXUAT", "HOADON.NHAPKHO")).ToList());
                    }
                    else if (ChiNhanhId == "PY")
                    {
                        data.AddRange(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<KetquatimkiemX>(strcn.Replace("HOADON.NOIXUAT", "HOADON.NHAPTAIKHO")).ToList());
                    }
                    else
                    {
                        data.AddRange(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<KetquatimkiemX>(strcn).ToList());
                    }
                }
                else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data.AddRange(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<KetquatimkiemX>(strcn).ToList());
                }

            }
            return data;
        }
        private List<ListKho> DATAGETKHO(List<string> macn)
        {
            var data = new List<ListKho>();
            var str = "EXEC sp_THAMSO";
            foreach (var ChiNhanhId in macn)
            {
                if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data.AddRange(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<ListKho>(str).ToList());
                }
                else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data.AddRange(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<ListKho>(str).ToList());
                }

            }
            return data;
        }

        private List<string> DATAGETPHANLOAI(List<string> macn)
        {
            var data = new List<string>();
            var str = "SELECT MAPL FROM TBL_DANHMUCPHANLOAIHD ";
            foreach (var ChiNhanhId in macn)
            {
                if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data.AddRange(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<string>(str).ToList());
                }
                else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data.AddRange(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<string>(str).ToList());
                }
            }
            return data;
        }
        public IHttpActionResult Chart([FromBody] CHARTDATAGET get)
        {
            DateTime tungay = DateTime.ParseExact(get.tungay1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime denngay = DateTime.ParseExact(get.denngay1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var data = new Datachart();
            if (get.Checkboxlist4 == null)
            {
                if (get.nhomhang.Contains("ALL"))
                {
                    get.Checkboxlist4 = null;
                }
                else
                {
                    get.Checkboxlist4 = string.Join(",", get.nhomhang).Split(',').ToList();
                }
            }
            //PL KHACH HANG
            var listcheckbox1 = String.Join(",", get.Checkboxlist1.ToArray()).Split(',').Distinct().ToList();
            get.Checkboxlist1 = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name).macn.Split(',').Intersect(listcheckbox1).ToList();
            JsonSerializerSettings jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

            var pickthang = DATAALL(get.Checkboxlist1, tungay.ToString("yyyy-MM-dd"), denngay.ToString("yyyy-MM-dd"), get.Checkboxlist4).ToList();
            //MAPL
            //LỌC OTC/ETC
            if (get.Checkboxlist2 != "null")
            {
                pickthang = pickthang.Where(n => get.Checkboxlist2.Contains(n.PhanLoai)).Distinct().ToList();
            }
            if (get.Checkboxlist3.Contains("null") == false)
            {
                pickthang = pickthang.Where(n => get.Checkboxlist3.Contains(n.PhanLoaiKH)).Distinct().ToList();
            }
            if (get.Checkboxlist5 != null)
            {
                pickthang = pickthang.Where(n => get.Checkboxlist5.Contains(n.MaHH)).Distinct().ToList();
            }
            //
            if (get.maphanloai != "null")
            {
                var flag = 0;
                if (get.maphanloai == "BAN,XK")
                {
                    flag = 1;
                }
                if (flag == 0)
                {
                    var dulieu = pickthang.Where(n => n.MaPL == get.maphanloai).ToList();
                    var xyz = db2.DANHMUCPHANLOAIHDs.SingleOrDefault(n => n.MAPK == get.maphanloai);
                    var dulieu1 = pickthang.Where(n => n.MaPL == xyz.TKHN).ToList();
                    pickthang = dulieu.Concat(dulieu1).Distinct().ToList();
                }
            }
            if (!pickthang.Any())
            {
                return Json(data);
            }
            //CHART1
            var doanhthuchinhanh = pickthang.GroupBy(n => n.Tendvbc).Select(cl => new DoanhThuCN { Tendvbc = cl.First().Tendvbc, TongTien = cl.Sum(c => c.Tien) }).OrderBy(n => n.TongTien);
            decimal TONG = doanhthuchinhanh.Sum(n => n.TongTien);
            var sodem2 = doanhthuchinhanh.Count();
            List<DataPoint> dataPoints = new List<DataPoint>();
            foreach (var i in doanhthuchinhanh)
            {
                dataPoints.Add(new DataPoint((double)i.TongTien / 1000000000, sodem2 + " . " + i.Tendvbc, Math.Round((double)i.TongTien / 1000000000, 2).ToString() + " (" + Math.Round((double)(i.TongTien * 100 / TONG), 2).ToString() + "%)"));
                sodem2--;
            }
            dataPoints.Add(new DataPoint((double)TONG / 1000000000, "TỔNG DOANH THU", Math.Round((double)TONG / 1000000000, 2).ToString() + " (100%)"));
            data.Chart1Height = 150 + dataPoints.Count() * 30;
            data.DataPoints = JsonConvert.SerializeObject(dataPoints, jsonSetting);
            //
            //CHART2
            var doanhthuhangthang = pickthang.GroupBy(n => n.Thang).Select(cl => new DoanhHangThang { thang = cl.First().Thang, TongTien = cl.Sum(c => c.Tien) }).OrderBy(n => n.thang).ToList();
            List<DataPoint> dataPoints1 = new List<DataPoint>();
            foreach (var x in doanhthuhangthang)
            {
                dataPoints1.Add(new DataPoint(x.thang, (double)x.TongTien / 1000000000, Math.Round((double)x.TongTien / 1000000000, 2).ToString() + " (" + Math.Round((double)(x.TongTien * 100 / TONG), 2).ToString() + "%)"));
            }
            data.DataPoints1 = JsonConvert.SerializeObject(dataPoints1, jsonSetting);
            //
            //CHART3
            List<DataPoint> dataPoints2 = new List<DataPoint>();
            var doanhthuvungmien = pickthang.GroupBy(n => n.Mien).Select(cl => new DoanhThuCN { Tendvbc = cl.First().Mien, TongTien = cl.Sum(c => c.Tien) }).OrderByDescending(n => n.TongTien);
            foreach (var i in doanhthuvungmien)
            {
                dataPoints2.Add(new DataPoint((double)i.TongTien / 1000000000, i.Tendvbc));
            }
            data.DataPoints2 = JsonConvert.SerializeObject(dataPoints2, jsonSetting);
            //
            //CHART4
            var tophanghoa = pickthang.GroupBy(n => n.MaHH).Select(cl => new TopHangHoa { MaHH = cl.First().MaHH, TenHH = cl.First().TenHH, TongTien = cl.Sum(c => c.Tien) }).OrderByDescending(n => n.TongTien).Take(get.sltophanghoa);
            List<DataPoint> dataPoints3 = new List<DataPoint>();
            decimal TONG1 = tophanghoa.Sum(n => n.TongTien);
            var sodem1 = 1;
            foreach (var i in tophanghoa)
            {
                dataPoints3.Add(new DataPoint((double)i.TongTien / 1000000000, sodem1 + " . " + i.MaHH + "-" + i.TenHH, Math.Round((double)i.TongTien / 1000000000, 2).ToString() + " (" + Math.Round((double)(i.TongTien * 100 / TONG), 2).ToString() + "%)"));
                sodem1++;
            }
            dataPoints3.Add(new DataPoint((double)TONG1 / 1000000000, "TỔNG TIỀN TOP " + get.sltophanghoa, Math.Round((double)TONG1 / 1000000000, 2).ToString() + " (" + Math.Round((double)(TONG1 * 100 / TONG), 2).ToString() + "%)"));
            dataPoints3.Add(new DataPoint((double)TONG / 1000000000, "TỔNG DOANH THU", Math.Round((double)TONG / 1000000000, 2).ToString() + " (100%)"));
            dataPoints3 = dataPoints3.OrderBy(n => n.Y).ToList();
            if (tophanghoa.Count() > 15)
            {
                data.Chart3Height = tophanghoa.Count() * 30;
            }
            data.DataPoints3 = JsonConvert.SerializeObject(dataPoints3, jsonSetting);
            //
            //CHART5
            // var topkhuvuc1 = pickthang.GroupBy(n => n.Matinh).Select(cl => new DoanhThuCN { Tendvbc = cl.First().Matinh, TongTien = cl.Sum(c => c.Tien) }).OrderByDescending(n => n.TongTien);
            var topkhuvuc = pickthang.GroupBy(n => n.Matinh).Select(cl => new DoanhThuCN { Tendvbc = cl.First().Matinh, TongTien = cl.Sum(c => c.Tien) }).OrderByDescending(n => n.TongTien).Take(get.sltopkhuvuc);
            List<DataPoint> dataPoints5 = new List<DataPoint>();
            decimal TONG3 = topkhuvuc.Sum(n => n.TongTien);
            var sodem = 1;
            foreach (var i in topkhuvuc)
            {
                var khuvuc = db2.KhuVucs.FirstOrDefault(n => n.MaKhuVuc == i.Tendvbc);
                if (khuvuc != null)
                {
                    dataPoints5.Add(new DataPoint((double)i.TongTien / 1000000000, sodem + " . " + khuvuc.TenKhuVuc, Math.Round((double)i.TongTien / 1000000000, 2).ToString() + " (" + Math.Round((double)(i.TongTien * 100 / TONG), 2).ToString() + "%)"));
                    sodem++;
                }
            }
            dataPoints5.Add(new DataPoint((double)TONG3 / 1000000000, "TỔNG TIỀN TOP " + get.sltopkhuvuc, Math.Round((double)TONG3 / 1000000000, 2).ToString() + " (" + Math.Round((double)(TONG3 * 100 / TONG), 2).ToString() + "%)"));
            dataPoints5.Add(new DataPoint((double)TONG / 1000000000, "TỔNG DOANH THU", Math.Round((double)TONG / 1000000000, 2).ToString() + " (100%)"));
            dataPoints5 = dataPoints5.OrderBy(n => n.Y).ToList();
            if (topkhuvuc.Count() > 15)
            {
                data.Chart5Height = topkhuvuc.Count() * 30;
            }
            data.DataPoints5 = JsonConvert.SerializeObject(dataPoints5, jsonSetting);
            //
            //CHART6
            var tileotcetc = pickthang.GroupBy(n => n.PhanLoai).Select(cl => new DoanhThuCN { Tendvbc = cl.First().PhanLoai, TongTien = cl.Sum(c => c.Tien) }).OrderByDescending(n => n.TongTien).Take(2);
            List<DataPoint> dataPoints6 = new List<DataPoint>();
            foreach (var i in tileotcetc)
            {
                dataPoints6.Add(new DataPoint((double)i.TongTien / 1000000000, i.Tendvbc));
            }
            data.DataPoints6 = JsonConvert.SerializeObject(dataPoints6, jsonSetting);
            //
            //CHART7
            var tilephanloaikh = pickthang.GroupBy(n => n.PhanLoaiKH).Select(cl => new DoanhThuCN { Tendvbc = cl.First().PhanLoaiKH, TongTien = cl.Sum(c => c.Tien) }).OrderByDescending(n => n.TongTien);
            List<DataPoint> dataPoints7 = new List<DataPoint>();
            foreach (var i in tilephanloaikh)
            {
                dataPoints7.Add(new DataPoint((double)i.TongTien / 1000000000, i.Tendvbc));
            }
            data.DataPoints7 = JsonConvert.SerializeObject(dataPoints7, jsonSetting);
            //
            //CHART8
            //List<DataPoint> dataPoints8 = new List<DataPoint>();
            //List<DataPoint> dataPoints81 = new List<DataPoint>();
            //List<DataPoint> dataPoints811 = new List<DataPoint>();

            //var kehoach = db2.TBL_DANHMUCKEHOACH.Where(n => n.nam == nam).ToList();
            //List<TBL_DANHMUCKEHOACH> kehoach1 = new List<TBL_DANHMUCKEHOACH>();

            //    kehoach1 = kehoach.Where(n => Checkboxlist1.Contains(n.macn)).ToList();

            //var abc = kehoach1.GroupBy(n => n.TBL_DANHSACHCHINHANH.Mien).Select(cl => new KeHoach { Mien = cl.First().TBL_DANHSACHCHINHANH.Mien, TongTien = (decimal)cl.Sum(c => c.ETC + c.OTC) });
            //decimal doanhthutong = 0;
            //foreach (var i in abc.OrderBy(n => n.Mien))
            //{
            //    doanhthutong = doanhthutong + i.TongTien;
            //    dataPoints811.Add(new DataPoint((double)i.TongTien / 1000000000, i.Mien));
            //}
            //dataPoints811.Add(new DataPoint((double)doanhthutong / 1000000000, "TỔNG"));
            //foreach (var i in doanhthuvungmien)
            //{
            //    dataPoints8.Add(new DataPoint((double)i.TongTien / 1000000000, i.Tendvbc));
            //    var phantram = dataPoints811.SingleOrDefault(n => n.Label == i.Tendvbc);
            //    dataPoints81.Add(new DataPoint((double)i.TongTien / 1000000000 / (double)phantram.Y * 100, i.Tendvbc));
            //}
            //dataPoints8.Add(new DataPoint((double)TONG / 1000000000, "TỔNG"));
            //dataPoints81.Add(new DataPoint((double)TONG / (double)doanhthutong * 100, "TỔNG"));
            //List<DataPoint> dataPoints88 = new List<DataPoint>();
            //foreach (var i in dataPoints81)
            //{
            //    if (dataPoints8.SingleOrDefault(n => n.Label == i.Label) != null)
            //    {
            //        dataPoints88.Add(new DataPoint((double)dataPoints8.SingleOrDefault(n => n.Label == i.Label).Y, i.Label, Math.Round((double)dataPoints8.SingleOrDefault(n => n.Label == i.Label).Y, 2) + " " + Math.Round((double)i.Y, 2).ToString() + "%"));
            //    }
            //}
            //data.DataPoints88 = JsonConvert.SerializeObject(dataPoints88.OrderBy(n => n.Label), jsonSetting);
            //data.DataPoints8 = JsonConvert.SerializeObject(dataPoints8.OrderBy(n => n.Label), jsonSetting);
            //data.DataPoints811 = JsonConvert.SerializeObject(dataPoints811.OrderBy(n => n.Label), jsonSetting);
            //
            //CHART9
            var topkhachhang = pickthang.GroupBy(n => n.MaKH).Select(cl => new TopHangHoa { MaHH = cl.First().MaKH, TenHH = cl.First().DonVi, TongTien = cl.Sum(c => c.Tien) }).OrderByDescending(n => n.TongTien).Take(get.sltopkhachhang);
            List<DataPoint> dataPoints9 = new List<DataPoint>();
            decimal TONG2 = topkhachhang.Sum(n => n.TongTien);
            var sodem3 = 1;
            foreach (var i in topkhachhang)
            {
                dataPoints9.Add(new DataPoint((double)i.TongTien / 1000000000, sodem3 + " . " + i.TenHH, Math.Round((double)i.TongTien / 1000000000, 2).ToString() + " (" + Math.Round((double)(i.TongTien * 100 / TONG), 2).ToString() + "%)"));
                sodem3++;
            }
            dataPoints9.Add(new DataPoint((double)TONG2 / 1000000000, "TỔNG TIỀN TOP " + get.sltopkhachhang, Math.Round((double)TONG2 / 1000000000, 2).ToString() + " (" + Math.Round((double)(TONG2 * 100 / TONG), 2).ToString() + "%)"));
            dataPoints9.Add(new DataPoint((double)TONG / 1000000000, "TỔNG DOANH THU", Math.Round((double)TONG / 1000000000, 2).ToString() + " (100%)"));
            data.DataPoints9 = JsonConvert.SerializeObject(dataPoints9.OrderBy(n => n.Y), jsonSetting);
            if (topkhachhang.Count() > 15)
            {
                data.Chart9Height = topkhachhang.Count() * 30;
            }
            return Json(data);
        }
        public List<ListModel> DATAALL(List<string> soso, string tuthang, string denthang, List<string> Checkboxlist4)
        {
            var strcn = "Select HOADON.MaPL,year(HOADON.ngaylaphd) AS NAM ,month(HOADON.ngaylaphd) AS THANG,TBL_MIEN.mien,TBL_DANHMUCTIEUDEBAOCAO.tendvbc,TBL_DANHMUCKHACHHANG.matinh,CT.mahh,CT.tenhh ,sum(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)- round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CAST(TYLECK AS MONEY)/100,0) ) AS TIEN , TBL_DANHMUCKHACHHANG.phanloai, TBL_DANHMUCKHACHHANG.phanloaikhachhang AS PHANLOAIKH, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI from TBL_MIEN , TBL_DANHMUCTIEUDEBAOCAO, DTA_HOADON_XUAT HOADON   LEFT JOIN   TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh , DTA_CT_HOADON_XUAT CT   LEFT JOIN   TBL_DANHMUCHANGHOA ON CT.mahh=TBL_DANHMUCHANGHOA.mahh where  HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1 AND HOADON.ngaylaphd BETWEEN '" + tuthang + "' AND '" + denthang + "' AND HOADON.MaPL IN ('BAN','XK') ";
            var strch = "Select HOADON.MaPL, year(HOADON.ngaylaphd) AS NAM, month(HOADON.ngaylaphd) AS THANG, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, CT.tenhh, sum(ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0) - round(ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0) * CAST(TYLECK AS MONEY) / 100, 0))   AS TIEN, TBL_DANHMUCKHACHHANG.phanloai, TBL_DANHMUCKHACHHANG.phanloaikhachhang AS PHANLOAIKH, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI from TBL_MIEN, tieude TBL_DANHMUCTIEUDEBAOCAO, CT_HOADON_XUAT CT  LEFT JOIN  DM_HANGHOA ON CT.mahh= DM_HANGHOA.mahh, HOADON_XUAT  HOADON   LEFT JOIN  DM_KHACHHANG_PTTT  TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh where  HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1 AND HOADON.ngaylaphd BETWEEN '" + tuthang + "' AND '" + denthang + "' AND HOADON.MaPL IN ('BAN','XK') ";
            //var strmb = "DECLARE @HANGHOA TABLE (MAPL char(3),THANG INT,NAM INT, NHOM Nvarchar(120) ,MAHH varchar(20),TENHH Nvarchar(120) ,DOANHTHU MONEY ,TENDVBC NVARCHAR(100) ,MIEN NVARCHAR(100) ,MATINH1 VARCHAR(20) ,MAKH1 VARCHAR(20), DONVI NVARCHAR(300) ,PHANLOAI VARCHAR(50) ,PHANLOAIKH VARCHAR(50),MACH VARCHAR(20) ) insert into @HANGHOA SELECT substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) AS MAPL, MONTH(dtaChungTu.ngaychungtu), YEAR(dtaChungTu.ngaychungtu), substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) as NHOM, replace(dclChiTietHangHoa.MaCap, ' ', '') AS MAHH, replace(dclChiTietHangHoa.TENCAP, ' ', '')  AS TENHH, SUM(ISNULL(CAST(TIENBAN   AS MONEY), 0) - ISNULL(CAST(TIENCHIETKHAU   AS MONEY), 0))  AS DOANHTHU, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_MIEN.MIEN, '', cast(dtaChungTu.KHACHHANGID as varchar), '', '', '', TBL_DANHMUCCUAHANG.MACH FROM dtasoluong, dtaDinhKhoan, dtaChungTu, dclChiTietHangHoa, dclDanhSachDonViTinh, tbl_danhmuctieudebaocao, tbl_mien, TBL_DANHMUCCUAHANG where  dtasoluong.dinhkhoanid = dtaDinhKhoan.CapDKID And dtaDinhKhoan.chungtuid = dtaChungTu.chungtuid and dtaDinhKhoan.IDTaiKhoanCo = dclChiTietHangHoa.TaiKhoanID and dclDanhSachDonViTinh.DonViTinhID = dclChiTietHangHoa.DonViTinhID  And dtaChungTu.KHACHHANGID  IN(select dclChiTietKhachHang.TaiKhoanID from dclChiTietKhachHang) AND substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) = '632' AND dtaChungTu.ngaychungtu BETWEEN '" + tuthang + "' AND '" + denthang + "' ";
            var strmbnew = "select substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) as NHOM,substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) AS MAPL,YEAR(dtaChungTu.ngaychungtu) AS NAM, MONTH(dtaChungTu.ngaychungtu) AS THANG,TBL_MIEN.MIEN,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC ,TBL_MIEN.MIEN,KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh AS MATINH ,replace(dclChiTietHangHoa.MaCap, ' ', '') AS MAHH ,replace(dclChiTietHangHoa.TENCAP, ' ', '')  AS TENHH ,SUM(ISNULL(CAST(TIENBAN   AS MONEY), 0) - ISNULL(CAST(TIENCHIETKHAU   AS MONEY), 0)) AS TIEN , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai AS PHANLOAI, KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang AS PHANLOAIKH, cast(dtaChungTu.KHACHHANGID as varchar) AS MAKH,KT_TH.DBO.TBL_DANHMUCKHACHHANG.donvi AS DONVI from dtasoluong, dtaDinhKhoan, dclChiTietHangHoa, dclDanhSachDonViTinh, tbl_danhmuctieudebaocao, tbl_mien, KT_TH.DBO.TBL_DANHMUCKHACHHANG right join TBL_DANHMUCCUAHANG on KT_TH.DBO.TBL_DANHMUCKHACHHANG.MaCH = TBL_DANHMUCCUAHANG.MACH right join dtaChungTu on KT_TH.DBO.TBL_DANHMUCKHACHHANG.makh = cast(dtaChungTu.KHACHHANGID as varchar) where dtasoluong.dinhkhoanid = dtaDinhKhoan.CapDKID And dtaDinhKhoan.chungtuid = dtaChungTu.chungtuid and dtaDinhKhoan.IDTaiKhoanCo = dclChiTietHangHoa.TaiKhoanID and dclDanhSachDonViTinh.DonViTinhID = dclChiTietHangHoa.DonViTinhID  And dtaChungTu.KHACHHANGID IN(select dclChiTietKhachHang.TaiKhoanID from dclChiTietKhachHang) AND substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) = '632' AND dtaChungTu.ngaychungtu BETWEEN '" + tuthang + "' AND '" + denthang + "' ";
            if (Checkboxlist4 != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.nhom in ({0})", string.Join(",", Checkboxlist4.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DM_HANGHOA.nhom in ({0})", string.Join(",", Checkboxlist4.Select(p => "'" + p + "'")));
                //strmb = strmb + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap,' ',''),1,2) in ({0})", string.Join(",", Checkboxlist4.Select(p => "'" + p + "'")));
                strmbnew = strmbnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap,' ',''),1,2) in ({0})", string.Join(",", Checkboxlist4.Select(p => "'" + p + "'")));
            }
            strcn = strcn + " GROUP BY TBL_DANHMUCHANGHOA.nhom ,HOADON.MaPL, HOADON.ngaylaphd, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, CT.tenhh, TBL_DANHMUCKHACHHANG.phanloai, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI ";
            strch = strch + " GROUP BY DM_HANGHOA.nhom ,HOADON.MaPL, HOADON.ngaylaphd , TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, CT.tenhh, TBL_DANHMUCKHACHHANG.phanloai, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI";
            //strmb = strmb + " group by dtaDinhKhoan.TaiKhoanNo ,dtaChungTu.ngaychungtu ,dclChiTietHangHoa.MaCap,dclChiTietHangHoa.TENCAP ,tbl_danhmuctieudebaocao.tendvbc ,tbl_mien.mien ,dtaChungTu.khachhangid,TBL_DANHMUCCUAHANG.MACH update @hanghoa   set matinh1=(SELECT matinh FROM KT_TH.DBO.TBL_DANHMUCKHACHHANG    WHERE MACH=(SELECT MACH FROM TBL_DANHMUCCUAHANG) AND MAKH=MAKH1 ) ,phanloai=(SELECT phanloai FROM KT_TH.DBO.TBL_DANHMUCKHACHHANG    WHERE MACH=(SELECT MACH FROM TBL_DANHMUCCUAHANG) AND MAKH=MAKH1 )  ,phanloaikh =(SELECT phanloaikhachhang FROM KT_TH.DBO.TBL_DANHMUCKHACHHANG    WHERE MACH=(SELECT MACH FROM TBL_DANHMUCCUAHANG) AND MAKH=MAKH1 ) ,DONVI=(SELECT DONVI FROM KT_TH.DBO.TBL_DANHMUCKHACHHANG    WHERE MACH=(SELECT MACH FROM TBL_DANHMUCCUAHANG) AND MAKH=MAKH1 )  select  NHOM,MAPL,NAM, THANG,MIEN,TENDVBC ,MATINH1 AS MATINH ,MAHH ,TENHH ,SUM(DOANHTHU) AS TIEN , PHANLOAI, PHANLOAIKH, MAKH1 AS MAKH,DONVI from @HANGHOA GROUP BY  NHOM,MAPL,NAM, THANG,MIEN,TENDVBC ,MATINH1  ,MAHH ,TENHH ,PHANLOAI ,PHANLOAIKH ,MAKH1 ,DONVI";
            strmbnew = strmbnew + "GROUP BY dtaDinhKhoan.TaiKhoanNo ,dtaChungTu.ngaychungtu ,dclChiTietHangHoa.MaCap,dclChiTietHangHoa.TENCAP ,tbl_danhmuctieudebaocao.tendvbc ,tbl_mien.mien ,dtaChungTu.khachhangid,TBL_DANHMUCCUAHANG.MACH,KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh,KT_TH.DBO.TBL_DANHMUCKHACHHANG.donvi,KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai,KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang";
            var DATAX = new List<ListModel>();
            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(DULIEU(queryCN.SingleOrDefault(n => n.macn == x).data, strcn));
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(DULIEUCUAHANG(queryCH.SingleOrDefault(n => n.macn == x).data, strch));
                }

            }
            return DATAX;
        }
        public List<ListModel> DULIEU(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<ListModel>(str).ToList();
            return All;
        }
        public List<ListModel> DULIEUCUAHANG(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<ListModel>(str).ToList();
            return All;
        }
        private List<ListKhuyenMai> DATAGETCTKM(string ChiNhanhId)
        {
            List<ListKhuyenMai> data = new List<ListKhuyenMai>();
            if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
            {
                if (ChiNhanhId == "TT423")
                {
                    data = queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<ListKhuyenMai>("SELECT MaCTKM AS MAKM, TenCTKM AS TENKM FROM TBL_DANHMUCKHUYENMAI WHERE MaCTKM IS NOT NULL").ToList();
                }

                else
                {
                    data = DULIEUKHUYENMAI(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data).ToList();
                }
            }
            else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
            {
                data = DULIEUCUAHANGKHUYENMAI(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data).ToList();
            }

            var ctkmchung = DATATH1.TBL_DANHMUCKM.Select(n => new ListKhuyenMai { MAKM = n.MACTKM, TENKM = n.TENCTKM }).ToList();
            return data.Where(n => !ctkmchung.Select(c => c.MAKM).Contains(n.MAKM)).Concat(ctkmchung).Distinct().Where(n => n.MAKM != "").OrderBy(n => n.MAKM).ToList();
        }
        private List<ListKhachHang> DATAGETKHACHHANG(string ChiNhanhId, TBL_DANHMUCNGUOIDUNG Info)
        {
            var listpl = Info.phanloai.Split(',').ToList();
            string strcn = "SELECT makh AS MAKH, donvi AS DONVI FROM TBL_DANHMUCKHACHHANG";
            string strch = "SELECT MaKH AS MAKH, DonVi AS DONVI FROM DM_KHACHHANG_PTTT";
            string strmb = "select KT_TH.DBO.TBL_DANHMUCKHACHHANG.makh as MAKH,KT_TH.DBO.TBL_DANHMUCKHACHHANG.donvi as DONVI from KT_TH.DBO.TBL_DANHMUCKHACHHANG where KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = (SELECT MACH FROM TBL_DANHMUCCUAHANG)";
            strcn = strcn + string.Format(" WHERE phanloai IN ({0})", string.Join(",", listpl.Select(p => "'" + p + "'")));
            strch = strch + string.Format(" WHERE PHANLOAI IN ({0})", string.Join(",", listpl.Select(p => "'" + p + "'")));
            strmb = strmb + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", string.Join(",", listpl.Select(p => "'" + p + "'")));
            if (Info.matinh != "ALL")
            {
                var listmt = Info.matinh.Split(',').ToList();
                strcn = strcn + string.Format(" AND matinh IN ({0})", string.Join(",", listmt.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND MaTinh IN ({0})", string.Join(",", listmt.Select(p => "'" + p + "'")));
                strmb = strmb + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", listmt.Select(p => "'" + p + "'")));
            }
            if (Info.matdv != "ALL")
            {
                var listtdv = Info.matdv.Split(',').ToList();
                strcn = strcn + string.Format(" AND matdv IN ({0})", string.Join(",", listtdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND MaTDV IN ({0})", string.Join(",", listtdv.Select(p => "'" + p + "'")));
            }
            if (Info.maquan != "ALL")
            {
                var listquan = Info.maquan.Split(',').ToList();
                strcn = strcn + string.Format(" AND quanhuyen IN ({0})", string.Join(",", listquan.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND quanhuyen IN ({0})", string.Join(",", listquan.Select(p => "'" + p + "'")));
            }
            List<ListKhachHang> data = new List<ListKhachHang>();
            if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
            {

                data = DULIEUKHACHHANG(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data, strcn).ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
            {
                data = DULIEUCUAHANGKHACHHANG(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data, strch).ToList();
            }

            return data;
        }

        private List<ListTrinhDuocVien> DATAGETTDV(string ChiNhanhId, TBL_DANHMUCNGUOIDUNG info)
        {
            List<ListTrinhDuocVien> data = new List<ListTrinhDuocVien>();
            if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
            {
                data = DULIEUTRINHDUOCVIEN(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data).ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
            {
                data = DULIEUCUAHANGTRINHDUOCVIEN(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data).ToList();
            }

            var Info = GetInfo();
            if (Info.matdv != "ALL")
            {
                var taphop = Info.matdv.Split(',').ToList();
                data = data.Where(n => taphop.Contains(n.MATDV)).ToList();
            }
            return data;
        }
        private List<ListNhomSP> DATAGETSP(string ChiNhanhId, TBL_DANHMUCNGUOIDUNG Info)
        {
            List<ListNhomSP> data = new List<ListNhomSP>();
            if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
            {

                data = DULIEUNHOMSP(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data).ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
            {
                data = DULIEUCUAHANGNHOMSP(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data).ToList();
            }


            if (Info.mahh != "ALL")
            {
                var taphop = Info.mahh.Split(',').ToList();
                data = data.Where(n => taphop.Contains(n.MaHH)).ToList();
            }
            return data.OrderBy(n => n.MaHH).ToList();
        }
        private List<ListKhuVuc> DATAGETKHUVUC(List<string> macn, TBL_DANHMUCNGUOIDUNG Info)
        {
            List<ListKhuVuc> data = new List<ListKhuVuc>();
            foreach (var ChiNhanhId in macn)
            {
                if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data.AddRange(DULIEUKHUVUC(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data).ToList());
                }
                else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data.AddRange(DULIEUCUAHANGKHUVUC(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data).ToList());
                }
            }
            if (Info.matinh != "ALL")
            {
                var taphop = Info.matinh.Split(',').ToList();
                data = data.Distinct().Where(n => taphop.Contains(n.matinh)).ToList();
            }
            return data;
        }

        [Authorize(Roles = "TRACUU")]
        private List<Dulieucongno> DATACONGNO(List<string> macn, string strcn)
        {
            var data = new List<Dulieucongno>();
            foreach (var ChiNhanhId in macn)
            {
                if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    //if (ChiNhanhId == "TT423")
                    //{
                    //    data.AddRange(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<DulieucongnoTT423>(strcn.Replace("sp_INSOCTIET_MAKH_THANG", "sp_INSOCTIET_MAKH_IN_THANG").Replace("sp_INSOCTIET_MAKH ", "sp_INSOCTIET_MAKH_IN ")).ToList().Select(cl => new Dulieucongno { COCUOIKY = string.Format("{0:#,##0}", cl.COCUOIKY), CODAUKY = string.Format("{0:#,##0}", cl.CODAUKY), NOCUOIKY = string.Format("{0:#,##0}", cl.NOCUOIKY), NODAUKY = string.Format("{0:#,##0}", cl.NODAUKY), PSCO = (cl.NOIDUNG == "") ? string.Format("{0:#,##0}", cl.CODAUKY) : string.Format("{0:#,##0}", cl.PSCO), PSNO = (cl.NOIDUNG == "") ? string.Format("{0:#,##0}", cl.NODAUKY) : string.Format("{0:#,##0}", cl.PSNO), NGAY = cl.NGAY, NOIDUNG = (cl.NOIDUNG == "") ? "Đầu kỳ" : cl.NOIDUNG, SCT = cl.SCT, TON = cl.TON, TPSCO = cl.TPSCO, TPSNO = cl.TPSNO }));
                    //}
                    //else
                    //{
                    data.AddRange(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<Dulieucongno>(strcn).ToList());

                    //}
                }
                else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data.AddRange(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<Dulieucongno>(strcn).ToList());
                }
            }
            return data;
        }

        [Authorize(Roles = "TRACUU")]
        private List<Dulieucongnodoichieu> DATACONGNORP(List<string> macn, string strcn)
        {
            var data = new List<Dulieucongnodoichieu>();
            foreach (var ChiNhanhId in macn)
            {
                if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    if (ChiNhanhId == "TT423")
                    {
                        data.AddRange(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<Dulieucongnodoichieu>(strcn).ToList().Select(cl => { cl.NOIDUNG = (cl.NOIDUNG == "") ? "Đầu kỳ" : cl.NOIDUNG; cl.PSNO = (cl.NOIDUNG == "") ? cl.NODAUKY : cl.PSNO; cl.PSCO = (cl.NOIDUNG == "") ? cl.CODAUKY : cl.PSCO; return cl; }));
                    }
                    else
                    {
                        data.AddRange(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<Dulieucongnodoichieu>(strcn).ToList());
                    }
                }
            }
            return data;
        }

        [Authorize(Roles = "TRACUU")]
        [HttpPost]
        public HttpResponseMessage Chitietcongno([FromBody]APICHITIETCONGNO x)
        {
            DateTime tungay1 = DateTime.ParseExact(x.tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime ngayin1 = DateTime.ParseExact(x.ngayin, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime denngay1 = DateTime.ParseExact(x.denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var chinhanh = x.macn.FirstOrDefault();
            var tendvbc = db2.TBL_DANHSACHCHINHANH.SingleOrDefault(n => n.macn == chinhanh).Tencn;
            if (x.baocao == "1")
            {
                //if (x.loai == 1)
                //{
                //    var data = DATACONGNO(x.macn, "EXEC sp_INSOCTIET_MAKH_THANG @TUTHANG=" + x.tuthang + ", @DENTHANG=" + x.denthang + ", @NAM=" + x.nam + ", @MAKH='" + x.makh + "', @TENKH='" + x.tenkh + "'").Select(z => new DulieucongnoRP { NGAY = (z.NGAY != null) ? ((DateTime)z.NGAY).ToString("dd/MM/yyyy") : "", tendvbc = tendvbc, NOIDUNG = z.NOIDUNG, NODAUKY = (z.NODAUKY == null) ? 0 : Convert.ToDecimal(z.NODAUKY.Replace(",", "")), NOCUOIKY = (z.NOCUOIKY == null) ? 0 : Convert.ToDecimal(z.NOCUOIKY.Replace(",", "")), COCUOIKY = (z.COCUOIKY == null) ? 0 : Convert.ToDecimal(z.COCUOIKY.Replace(",", "")), CODAUKY = (z.CODAUKY == null) ? 0 : Convert.ToDecimal(z.CODAUKY.Replace(",", "")), PSNO = (z.PSNO == null) ? 0 : Convert.ToDecimal(z.PSNO.Replace(",", "")), PSCO = (z.PSCO == null) ? 0 : Convert.ToDecimal(z.PSCO.Replace(",", "")), SCT = z.SCT, TUTHANG = x.tuthang, DENTHANG = x.denthang, NAM = x.nam, MAKH = x.makh, TENKH = x.tenkh });
                //    if (x.mau == "C")
                //    {
                //        CR_TONGHOP_CONGNO_1_MAKH_THANG rpt = new CR_TONGHOP_CONGNO_1_MAKH_THANG();
                //        rpt.Load();
                //        rpt.SetDataSource(data);
                //        var s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                //        return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });

                //    }
                //    else
                //    {
                //        CR_TONGHOP_CONGNO_1_MAKH_THANG_VAT rpt = new CR_TONGHOP_CONGNO_1_MAKH_THANG_VAT();
                //        rpt.Load();
                //        rpt.SetDataSource(data);
                //        var s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                //        return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });
                //    }
                //}
                //else
                //{
                //    var data = DATACONGNO(x.macn, "EXEC sp_INSOCTIET_MAKH @TUNGAY='" + tungay1.ToString("MM/dd/yyyy") + "', @DENNGAY='" + denngay1.ToString("MM/dd/yyyy") + "', @MAKH='" + x.makh + "', @TENKH='" + x.tenkh + "'").Select(z => new DulieucongnoRP { NGAY = (z.NGAY != null) ? ((DateTime)z.NGAY).ToString("dd/MM/yyyy") : "", tendvbc = tendvbc, NOIDUNG = z.NOIDUNG, NODAUKY = (z.NODAUKY == null) ? 0 : Convert.ToDecimal(z.NODAUKY.Replace(",", "")), NOCUOIKY = (z.NOCUOIKY == null) ? 0 : Convert.ToDecimal(z.NOCUOIKY.Replace(",", "")), COCUOIKY = (z.COCUOIKY == null) ? 0 : Convert.ToDecimal(z.COCUOIKY.Replace(",", "")), CODAUKY = (z.CODAUKY == null) ? 0 : Convert.ToDecimal(z.CODAUKY.Replace(",", "")), PSNO = (z.PSNO == null) ? 0 : Convert.ToDecimal(z.PSNO.Replace(",", "")), PSCO = (z.PSCO == null) ? 0 : Convert.ToDecimal(z.PSCO.Replace(",", "")), SCT = z.SCT, TUNGAY = tungay1, DENNGAY = denngay1, MAKH = x.makh, TENKH = x.tenkh });
                //    if (x.mau == "C")
                //    {
                //        CR_TONGHOP_CONGNO_1_MAKH rpt = new CR_TONGHOP_CONGNO_1_MAKH();
                //        rpt.Load();
                //        rpt.SetDataSource(data);
                //        var s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                //        return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });
                //    }
                //    else
                //    {
                //        CR_TONGHOP_CONGNO_1_MAKH_VAT rpt = new CR_TONGHOP_CONGNO_1_MAKH_VAT();
                //        rpt.Load();
                //        rpt.SetDataSource(data);
                //        var s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                //        return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });
                //    }
                //}
            }
            else if (x.baocao == "2")
            {
                if (x.loai == 1)
                {
                    var str = "";
                    if (x.macn.FirstOrDefault() == "TT423")
                    {
                        str = "EXEC sp_INSOCTIET_DOICHIEU_MAKH_THANG @TUTHANG='" + x.tuthang + "', @DENTHANG=" + x.denthang + ", @NAM=" + x.nam + ", @NGAYIN='" + ngayin1.ToString("MM/dd/yyyy") + "', @MAKH='" + x.makh + "', @TENKH=N'" + x.tenkh + "'";
                    }
                    else
                    {
                        str = "EXEC sp_INSOCTIET_DOICHIEU_MAKH @TUNGAY='" + GetFirstDay(x.tuthang, x.nam).ToString("MM/dd/yyyy") + "', @DENNGAY='" + GetLastDay(x.denthang, x.nam).ToString("MM/dd/yyyy") + "', @NGAYIN='" + ngayin1.ToString("MM/dd/yyyy") + "', @MAKH='" + x.makh + "', @TENKH=N'" + x.tenkh + "'";
                    }
                    var data = DATACONGNORP(x.macn, str).Select(n => new DulieucongnodoichieuRP { NGAY = ((n.NGAY != null) ? ((DateTime)n.NGAY).ToString("dd/MM/yyyy") : ""), COCUOIKY = n.COCUOIKY, nganhang = n.nganhang, CODAUKY = n.CODAUKY, DENNGAY = n.DENNGAY, TUNGAY = n.TUNGAY, diachi = n.diachi, DIACHIKH = n.DIACHIKH, dt = n.dt, MAKH = n.MAKH, NGAYIN = n.NGAYIN, NOCUOIKY = n.NOCUOIKY, NODAUKY = n.NODAUKY, NOIDUNG = n.NOIDUNG, PSCO = n.PSCO, PSNO = n.PSNO, SCT = n.SCT, taikhoan = n.taikhoan, tencn = n.tencn, tendvbc = n.tendvbc, TENKH = n.TENKH, tinh = n.tinh });
                    CR_TONGHOP_CONGNO_DOICHIEU_MAKH rpt = new CR_TONGHOP_CONGNO_DOICHIEU_MAKH();
                    rpt.Load();
                    rpt.SetDataSource(data.Select(z => { z.txttien = docso(Convert.ToInt32(z.NOCUOIKY).ToString()); return z; }));

                    var s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });

                }
                else
                {
                    var str = "";
                    if (x.macn.FirstOrDefault() == "TT423")
                    {
                        str = "EXEC sp_INSOCTIET_DOICHIEU_MAKH_THANG @TUTHANG='" + tungay1.Month + "', @DENTHANG=" + denngay1.Month + ", @NAM=" + denngay1.Year + ", @NGAYIN='" + ngayin1.ToString("MM/dd/yyyy") + "', @MAKH='" + x.makh + "', @TENKH=N'" + x.tenkh + "'";
                    }
                    else
                    {
                        str = "EXEC sp_INSOCTIET_DOICHIEU_MAKH @TUNGAY='" + tungay1.ToString("MM/dd/yyyy") + "', @DENNGAY='" + denngay1.ToString("MM/dd/yyyy") + "', @NGAYIN='" + ngayin1.ToString("MM/dd/yyyy") + "', @MAKH='" + x.makh + "', @TENKH=N'" + x.tenkh + "'";
                    }
                    var data = DATACONGNORP(x.macn, str).Select(n => new DulieucongnodoichieuRP { NGAY = ((n.NGAY != null) ? ((DateTime)n.NGAY).ToString("dd/MM/yyyy") : ""), COCUOIKY = n.COCUOIKY, nganhang = n.nganhang, CODAUKY = n.CODAUKY, DENNGAY = n.DENNGAY, TUNGAY = n.TUNGAY, diachi = n.diachi, DIACHIKH = n.DIACHIKH, dt = n.dt, MAKH = n.MAKH, NGAYIN = n.NGAYIN, NOCUOIKY = n.NOCUOIKY, NODAUKY = n.NODAUKY, NOIDUNG = n.NOIDUNG, PSCO = n.PSCO, PSNO = n.PSNO, SCT = n.SCT, taikhoan = n.taikhoan, tencn = n.tencn, tendvbc = n.tendvbc, TENKH = n.TENKH, tinh = n.tinh }); ;
                    CR_TONGHOP_CONGNO_DOICHIEU_MAKH rpt = new CR_TONGHOP_CONGNO_DOICHIEU_MAKH();
                    rpt.Load();
                    rpt.SetDataSource(data.Select(z => { z.txttien = docso(Convert.ToInt32(z.NOCUOIKY).ToString()); return z; }));

                    var s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });

                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, new PDFBase64 { Base64 = null });

        }
        public DateTime GetLastDay(int month, int year)
        {
            var lastDayOfMonth = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
            return lastDayOfMonth;
        }
        public DateTime GetFirstDay(int month, int year)
        {
            var firstDayOfMonth = new DateTime(year, month, 1);
            return firstDayOfMonth;
        }
        public string DOCHANGDONVI(string str_hangdonvi)
        {
            string[] str_donvi = new[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] str_chuc = new[] { "không", "mười", "hai mươi", "ba mươi", "bốn mươi", "năm mươi", "sáu mươi", "bảy mươi", "tám mươi", "chín mươi" };
            string[] str_tram = new[] { "không", "một trăm", "hai trăm", "ba trăm", "bốn trăm", "năm trăm", "sáu trăm", "bảy trăm", "tám trăm", "chín trăm" };
            int i = 0;
            string STR_CHUOI_SO_DV = "";
            int chieudai = str_hangdonvi.Length;
            string str_tien_donvi;
            if (chieudai >= 3)
                str_tien_donvi = str_hangdonvi.Substring(chieudai - 3);
            else
                str_tien_donvi = str_hangdonvi;
            i = 0;
            try
            {
                while (i <= str_tien_donvi.Length - 1)
                {
                    int int_so = System.Convert.ToInt32(str_tien_donvi[i].ToString());
                    if (str_tien_donvi.Length == 3)
                    {
                        if (i == 2)
                        {
                            switch (int_so)
                            {
                                case 0:
                                    {
                                        break;
                                    }
                                case 1:
                                    {
                                        int_so = System.Convert.ToInt32(str_tien_donvi[i - 1].ToString());
                                        if (int_so != 1 & int_so != 0)
                                            STR_CHUOI_SO_DV = STR_CHUOI_SO_DV + " mốt";
                                        else
                                            STR_CHUOI_SO_DV = STR_CHUOI_SO_DV + " một";
                                        break;
                                    }
                                case 5:
                                    {
                                        int_so = System.Convert.ToInt32(str_tien_donvi[i - 1].ToString());
                                        if (int_so != 0)
                                            STR_CHUOI_SO_DV = STR_CHUOI_SO_DV + " lăm";
                                        else
                                            STR_CHUOI_SO_DV = STR_CHUOI_SO_DV + " năm";
                                        break;
                                    }
                                default:
                                    {
                                        STR_CHUOI_SO_DV = STR_CHUOI_SO_DV + "  " + str_donvi[int_so];
                                        break;
                                    }
                            }
                        }
                        if (i == 1)
                        {
                            switch (int_so)
                            {
                                case 0:
                                    {
                                        int_so = System.Convert.ToInt32(str_tien_donvi[i + 1].ToString());
                                        if (int_so != 0)
                                            STR_CHUOI_SO_DV = STR_CHUOI_SO_DV + "  " + "lẻ";
                                        break;
                                    }

                                default:
                                    {
                                        STR_CHUOI_SO_DV = STR_CHUOI_SO_DV + "  " + str_chuc[int_so];
                                        break;
                                    }
                            }
                        }
                        if (i == 0)
                        {
                            switch (int_so)
                            {
                                case 0:
                                    {
                                        break;
                                    }

                                default:
                                    {
                                        STR_CHUOI_SO_DV = STR_CHUOI_SO_DV + "  " + str_tram[int_so];
                                        break;
                                    }
                            }
                        }
                    }
                    else if (str_tien_donvi.Length == 2)
                    {
                        if (i == 1)
                        {
                            switch (int_so)
                            {
                                case 0:
                                    {
                                        break;
                                    }

                                case 1:
                                    {
                                        int_so = System.Convert.ToInt32(str_tien_donvi[i - 1].ToString());
                                        if (int_so != 1)
                                            STR_CHUOI_SO_DV = STR_CHUOI_SO_DV + " mốt";
                                        else
                                            STR_CHUOI_SO_DV = STR_CHUOI_SO_DV + " một";
                                        break;
                                    }

                                case 5:
                                    {
                                        STR_CHUOI_SO_DV = STR_CHUOI_SO_DV + " lăm";
                                        break;
                                    }

                                default:
                                    {
                                        STR_CHUOI_SO_DV = STR_CHUOI_SO_DV + "  " + str_donvi[int_so];
                                        break;
                                    }
                            }
                        }
                        if (i == 0)
                        {
                            switch (int_so)
                            {
                                case 0:
                                    {
                                        int_so = System.Convert.ToInt32(str_tien_donvi[i + 1].ToString());
                                        if (int_so != 0)
                                            STR_CHUOI_SO_DV = STR_CHUOI_SO_DV + "  " + "lẻ";
                                        break;
                                    }

                                case 5:
                                    {
                                        STR_CHUOI_SO_DV = STR_CHUOI_SO_DV + "  " + str_chuc[int_so];
                                        break;
                                    }

                                default:
                                    {
                                        STR_CHUOI_SO_DV = STR_CHUOI_SO_DV + "  " + str_chuc[int_so];
                                        break;
                                    }
                            }
                        }
                    }
                    else if (str_tien_donvi.Length == 1)
                    {
                        if (i == 0)
                        {
                            switch (int_so)
                            {
                                case 0:
                                    {
                                        break;
                                    }

                                default:
                                    {
                                        STR_CHUOI_SO_DV = STR_CHUOI_SO_DV + "  " + str_donvi[int_so];
                                        break;
                                    }
                            }
                        }
                    }
                    i = i + 1;
                }
            }
            catch (Exception ex)
            {
            }
            return STR_CHUOI_SO_DV;
        }
        public string docso(string str_tong_tien)
        {
            string str_tien_ngan = "";
            string str_tien_don_vi = "";
            string str_tien_trieu = "";
            string str_tien_ty = "";
            string str_tien_ngan_ty = "";
            string str_tien_trieu_ty = "";
            string str_tien_hang_ngan = "";
            int chieudaichuoitien = str_tong_tien.Length;
            str_tien_don_vi = DOCHANGDONVI(str_tong_tien) + " đồng chẵn";
            if (chieudaichuoitien - 3 > 0)
            {
                str_tien_ngan = str_tong_tien.Remove(chieudaichuoitien - 3, 3);
                if (str_tien_ngan.Length - 3 >= 0)
                    str_tien_ngan = str_tien_ngan.Substring(str_tien_ngan.Length - 3);
                else
                    str_tien_ngan = str_tong_tien.Remove(chieudaichuoitien - 3, 3);

                if (str_tien_ngan == "000")
                    str_tien_hang_ngan = "";
                else
                    str_tien_hang_ngan = DOCHANGDONVI(str_tien_ngan) + " ngàn ";
            }
            if (chieudaichuoitien - 6 > 0)
            {
                str_tien_ngan = str_tong_tien.Remove(chieudaichuoitien - 6, 6);
                if (str_tien_ngan.Length - 3 >= 0)
                    str_tien_ngan = str_tien_ngan.Substring(str_tien_ngan.Length - 3);
                else
                    str_tien_ngan = str_tong_tien.Remove(chieudaichuoitien - 6, 6);
                if (str_tien_ngan == "000")
                    str_tien_trieu = "";
                else
                    str_tien_trieu = DOCHANGDONVI(str_tien_ngan) + " triệu ";
            }
            if (chieudaichuoitien - 9 > 0)
            {
                str_tien_ngan = str_tong_tien.Remove(chieudaichuoitien - 9, 9);
                // str_tien_ngan = str_tien_ngan.Substring(str_tien_ngan.Length - 3)
                if (str_tien_ngan == "000")
                    str_tien_ty = "";
                else
                    str_tien_ty = DOCHANGDONVI(str_tien_ngan) + " tỷ ";
            }

            if (chieudaichuoitien - 12 > 0)
            {
                str_tien_ngan = str_tong_tien.Remove(chieudaichuoitien - 12, 12);
                // str_tien_ngan = str_tien_ngan.Substring(str_tien_ngan.Length - 3)
                if (str_tien_ngan.Length - 3 > 0)
                    str_tien_ngan_ty = str_tien_ngan.Substring(str_tien_ngan.Length - 3);
                else
                    str_tien_ngan_ty = str_tong_tien.Remove(chieudaichuoitien - 12, 6);
                if (str_tien_ngan_ty == "000")
                    str_tien_ngan_ty = "";
                else
                    str_tien_ngan_ty = DOCHANGDONVI(str_tien_ngan) + " ngàn";
            }

            if (chieudaichuoitien - 15 > 0)
            {
                str_tien_ngan = str_tong_tien.Remove(chieudaichuoitien - 15, 15);
                if (str_tien_ngan.Length - 3 >= 0)
                    str_tien_trieu_ty = str_tien_ngan.Substring(str_tien_ngan.Length - 3);
                else
                    str_tien_trieu_ty = str_tong_tien.Remove(chieudaichuoitien - 15, 6);
                if (str_tien_ngan == "000")
                    str_tien_trieu_ty = "";
                else
                    str_tien_trieu_ty = DOCHANGDONVI(str_tien_ngan) + " triệu";
            }
            string str_tien = "";
            str_tien = str_tien_trieu_ty + str_tien_ngan_ty + str_tien_ty + str_tien_trieu + str_tien_hang_ngan + str_tien_don_vi;
            return str_tien;
        }
        [HttpPost]
        public IHttpActionResult GetKhachHang(string macn)
        {
            var Info = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name);
            var listpl = Info.phanloai.Split(',').ToList();
            string strcn = "SELECT makh AS MAKH, donvi AS DONVI FROM TBL_DANHMUCKHACHHANG";
            string strch = "SELECT MaKH AS MAKH, DonVi AS DONVI FROM DM_KHACHHANG_PTTT";
            string strmb = "select KT_TH.DBO.TBL_DANHMUCKHACHHANG.makh as MAKH,KT_TH.DBO.TBL_DANHMUCKHACHHANG.donvi as DONVI from KT_TH.DBO.TBL_DANHMUCKHACHHANG where KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = (SELECT MACH FROM TBL_DANHMUCCUAHANG)";
            strcn = strcn + string.Format(" WHERE phanloai IN ({0})", string.Join(",", listpl.Select(p => "'" + p + "'")));
            strch = strch + string.Format(" WHERE PHANLOAI IN ({0})", string.Join(",", listpl.Select(p => "'" + p + "'")));
            strmb = strmb + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", string.Join(",", listpl.Select(p => "'" + p + "'")));
            if (Info.matinh != "ALL")
            {
                var listmt = Info.matinh.Split(',').ToList();
                strcn = strcn + string.Format(" AND matinh IN ({0})", string.Join(",", listmt.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND MaTinh IN ({0})", string.Join(",", listmt.Select(p => "'" + p + "'")));
                strmb = strmb + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", listmt.Select(p => "'" + p + "'")));
            }
            if (Info.matdv != "ALL")
            {
                var listtdv = Info.matdv.Split(',').ToList();
                strcn = strcn + string.Format(" AND matdv IN ({0})", string.Join(",", listtdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND MaTDV IN ({0})", string.Join(",", listtdv.Select(p => "'" + p + "'")));
            }
            if (Info.maquan != "ALL")
            {
                var listquan = Info.maquan.Split(',').ToList();
                strcn = strcn + string.Format(" AND quanhuyen IN ({0})", string.Join(",", listquan.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND quanhuyen IN ({0})", string.Join(",", listquan.Select(p => "'" + p + "'")));
            }
            List<ListKhachHang> data = new List<ListKhachHang>();
            if (queryCN.SingleOrDefault(n => n.macn == macn) != null)
            {

                data = DULIEUKHACHHANG(queryCN.SingleOrDefault(n => n.macn == macn).data, strcn).ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == macn) != null)
            {
                data = DULIEUCUAHANGKHACHHANG(queryCH.SingleOrDefault(n => n.macn == macn).data, strch).ToList();
            }


            return Json(data.OrderBy(n => n.MAKH));
        }
        [HttpPost]
        public IHttpActionResult GetBoLoc(string macn)
        {
            var Info = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name);
            var data = new databoloc();
            if (macn == "QN")
            {
                data.KV = DULIEUKHUVUC(QuangNgai).ToList();
                data.SP = DULIEUNHOMSP(QuangNgai).ToList();
                data.LOAIHD = DULIEULOAIHD(QuangNgai).ToList();
                data.KM = DULIEUKHUYENMAI(QuangNgai).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(QuangNgai).ToList();
                data.Quan = DULIEUQUAN(QuangNgai).ToList();
            }
            else if (macn == "TN")
            {
                data.KV = DULIEUKHUVUC(TayNinh).ToList();
                data.SP = DULIEUNHOMSP(TayNinh).ToList();
                data.LOAIHD = DULIEULOAIHD(TayNinh).ToList();
                data.KM = DULIEUKHUYENMAI(TayNinh).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(TayNinh).ToList();
                data.Quan = DULIEUQUAN(TayNinh).ToList();
            }

            else if (macn == "CHQ10")
            {
                data.KV = DULIEUCUAHANGKHUVUC(CHQ10).ToList();
                data.SP = DULIEUCUAHANGNHOMSP(CHQ10).ToList();
                data.LOAIHD = DULIEUCUAHANGLOAIHD(CHQ10).ToList();
                data.KM = DULIEUCUAHANGKHUYENMAI(CHQ10).ToList();
                data.TDV = DULIEUCUAHANGTRINHDUOCVIEN(CHQ10).ToList();
                data.Quan = DULIEUCUAHANGQUAN(CHQ10).ToList();
            }
            else if (macn == "CHPPSP")
            {
                data.KV = DULIEUCUAHANGKHUVUC(CHPPSP).ToList();
                data.SP = DULIEUCUAHANGNHOMSP(CHPPSP).ToList();
                data.LOAIHD = DULIEUCUAHANGLOAIHD(CHPPSP).ToList();
                data.KM = DULIEUCUAHANGKHUYENMAI(CHPPSP).ToList();
                data.TDV = DULIEUCUAHANGTRINHDUOCVIEN(CHPPSP).ToList();
                data.Quan = DULIEUCUAHANGQUAN(CHPPSP).ToList();
            }
            else if (macn == "TT423")
            {
                data.KV = DULIEUKHUVUC(TT423).ToList();
                data.SP = DULIEUNHOMSP(TT423).ToList();
                data.LOAIHD = DULIEULOAIHD(TT423).ToList();
                data.KM = TT423.Database.SqlQuery<ListKhuyenMai>("SELECT MaCTKM AS MAKM, TenCTKM AS TENKM FROM TBL_DANHMUCKHUYENMAI WHERE MaCTKM IS NOT NULL").ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(TT423).ToList();
            }
            else if (macn == "BD")
            {
                data.KV = DULIEUKHUVUC(BinhDinh).ToList();
                data.SP = DULIEUNHOMSP(BinhDinh).ToList();
                data.LOAIHD = DULIEULOAIHD(BinhDinh).ToList();
                data.KM = DULIEUKHUYENMAI(BinhDinh).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(BinhDinh).ToList();
            }
            else if (macn == "CT")
            {
                data.KV = DULIEUKHUVUC(CanTho).ToList();
                data.SP = DULIEUNHOMSP(CanTho).ToList();
                data.LOAIHD = DULIEULOAIHD(CanTho).ToList();
                data.KM = DULIEUKHUYENMAI(CanTho).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(CanTho).ToList();
                data.Quan = DULIEUQUAN(CanTho).ToList();
            }
            else if (macn == "DN")
            {
                data.KV = DULIEUKHUVUC(DongNai).ToList();
                data.SP = DULIEUNHOMSP(DongNai).ToList();
                data.LOAIHD = DULIEULOAIHD(DongNai).ToList();
                data.KM = DULIEUKHUYENMAI(DongNai).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(DongNai).ToList();
                data.Quan = DULIEUQUAN(DongNai).ToList();
            }
            else if (macn == "BDG")
            {
                data.KV = DULIEUKHUVUC(BinhDuong).ToList();
                data.SP = DULIEUNHOMSP(BinhDuong).ToList();
                data.LOAIHD = DULIEULOAIHD(BinhDuong).ToList();
                data.KM = DULIEUKHUYENMAI(BinhDuong).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(BinhDuong).ToList();
                data.Quan = DULIEUQUAN(BinhDuong).ToList();
            }
            else if (macn == "DNA")
            {
                data.KV = DULIEUKHUVUC(DaNang).ToList();
                data.SP = DULIEUNHOMSP(DaNang).ToList();
                data.LOAIHD = DULIEULOAIHD(DaNang).ToList();
                data.KM = DULIEUKHUYENMAI(DaNang).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(DaNang).ToList();
            }
            else if (macn == "HCM")
            {
                data.KV = DULIEUKHUVUC(HoChiMinh).ToList();
                data.SP = DULIEUNHOMSP(HoChiMinh).ToList();
                data.LOAIHD = DULIEULOAIHD(HoChiMinh).ToList();
                data.KM = DULIEUKHUYENMAI(HoChiMinh).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(HoChiMinh).ToList();
                data.Quan = DULIEUQUAN(HoChiMinh).ToList();
            }
            else if (macn == "NA")
            {
                data.KV = DULIEUKHUVUC(NgheAn).ToList();
                data.SP = DULIEUNHOMSP(NgheAn).ToList();
                data.LOAIHD = DULIEULOAIHD(NgheAn).ToList();
                data.KM = DULIEUKHUYENMAI(NgheAn).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(NgheAn).ToList();
            }
            else if (macn == "HN")
            {
                data.KV = DULIEUKHUVUC(HaNoi).ToList();
                data.SP = DULIEUNHOMSP(HaNoi).ToList();
                data.LOAIHD = DULIEULOAIHD(HaNoi).ToList();
                data.KM = DULIEUKHUYENMAI(HaNoi).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(HaNoi).ToList();
            }
            else if (macn == "TB")
            {
                data.KV = DULIEUKHUVUC(ThaiBinh).ToList();
                data.SP = DULIEUNHOMSP(ThaiBinh).ToList();
                data.LOAIHD = DULIEULOAIHD(ThaiBinh).ToList();
                data.KM = DULIEUKHUYENMAI(ThaiBinh).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(ThaiBinh).ToList();
            }
            else if (macn == "PT")
            {
                data.KV = DULIEUKHUVUC(PhuTho).ToList();
                data.SP = DULIEUNHOMSP(PhuTho).ToList();
                data.LOAIHD = DULIEULOAIHD(PhuTho).ToList();
                data.KM = DULIEUKHUYENMAI(PhuTho).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(PhuTho).ToList();
            }
            else if (macn == "TNG")
            {
                data.KV = DULIEUKHUVUC(ThaiNguyen).ToList();
                data.SP = DULIEUNHOMSP(ThaiNguyen).ToList();
                data.LOAIHD = DULIEULOAIHD(ThaiNguyen).ToList();
                data.KM = DULIEUKHUYENMAI(ThaiNguyen).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(ThaiNguyen).ToList();
            }
            else if (macn == "BT")
            {
                data.KV = DULIEUKHUVUC(BinhThuan).ToList();
                data.SP = DULIEUNHOMSP(BinhThuan).ToList();
                data.LOAIHD = DULIEULOAIHD(BinhThuan).ToList();
                data.KM = DULIEUKHUYENMAI(BinhThuan).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(BinhThuan).ToList();
            }
            else if (macn == "THO")
            {
                data.KV = DULIEUKHUVUC(ThanhHoa).ToList();
                data.SP = DULIEUNHOMSP(ThanhHoa).ToList();
                data.LOAIHD = DULIEULOAIHD(ThanhHoa).ToList();
                data.KM = DULIEUKHUYENMAI(ThanhHoa).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(ThanhHoa).ToList();
            }
            else if (macn == "NA2")
            {
                data.KV = DULIEUKHUVUC(NgheAn2).ToList();
                data.SP = DULIEUNHOMSP(NgheAn2).ToList();
                data.LOAIHD = DULIEULOAIHD(NgheAn2).ToList();
                data.KM = DULIEUKHUYENMAI(NgheAn2).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(NgheAn2).ToList();
            }

            else if (macn == "PY")
            {
                data.KV = DULIEUKHUVUC(PhuYen).ToList();
                data.SP = DULIEUNHOMSP(PhuYen).ToList();
                data.LOAIHD = DULIEULOAIHD(PhuYen).ToList();
                data.KM = DULIEUKHUYENMAI(PhuYen).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(PhuYen).ToList();
            }
            else if (macn == "AG")
            {
                data.KV = DULIEUKHUVUC(AnGiang).ToList();
                data.SP = DULIEUNHOMSP(AnGiang).ToList();
                data.LOAIHD = DULIEULOAIHD(AnGiang).ToList();
                data.KM = DULIEUKHUYENMAI(AnGiang).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(AnGiang).ToList();
                data.Quan = DULIEUQUAN(AnGiang).ToList();
            }
            else if (macn == "CM")
            {
                data.KV = DULIEUKHUVUC(CaMau).ToList();
                data.SP = DULIEUNHOMSP(CaMau).ToList();
                data.LOAIHD = DULIEULOAIHD(CaMau).ToList();
                data.KM = DULIEUKHUYENMAI(CaMau).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(CaMau).ToList();
                data.Quan = DULIEUQUAN(CaMau).ToList();
            }
            else if (macn == "GL")
            {
                data.KV = DULIEUKHUVUC(GiaLai).ToList();
                data.SP = DULIEUNHOMSP(GiaLai).ToList();
                data.LOAIHD = DULIEULOAIHD(GiaLai).ToList();
                data.KM = DULIEUKHUYENMAI(GiaLai).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(GiaLai).ToList();
            }
            else if (macn == "HUE")
            {
                data.KV = DULIEUKHUVUC(Hue).ToList();
                data.SP = DULIEUNHOMSP(Hue).ToList();
                data.LOAIHD = DULIEULOAIHD(Hue).ToList();
                data.KM = DULIEUKHUYENMAI(Hue).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(Hue).ToList();
            }
            else if (macn == "HP")
            {
                data.KV = DULIEUKHUVUC(HaiPhong).ToList();
                data.SP = DULIEUNHOMSP(HaiPhong).ToList();
                data.LOAIHD = DULIEULOAIHD(HaiPhong).ToList();
                data.KM = DULIEUKHUYENMAI(HaiPhong).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(HaiPhong).ToList();
            }
            else if (macn == "LD")
            {
                data.KV = DULIEUKHUVUC(LamDong).ToList();
                data.SP = DULIEUNHOMSP(LamDong).ToList();
                data.LOAIHD = DULIEULOAIHD(LamDong).ToList();
                data.KM = DULIEUKHUYENMAI(LamDong).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(LamDong).ToList();
                data.Quan = DULIEUQUAN(LamDong).ToList();
            }
            else if (macn == "NT")
            {
                data.KV = DULIEUKHUVUC(NhaTrang).ToList();
                data.SP = DULIEUNHOMSP(NhaTrang).ToList();
                data.LOAIHD = DULIEULOAIHD(NhaTrang).ToList();
                data.KM = DULIEUKHUYENMAI(NhaTrang).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(NhaTrang).ToList();
                data.Quan = DULIEUQUAN(NhaTrang).ToList();
            }
            else if (macn == "TG")
            {
                data.KV = DULIEUKHUVUC(TienGiang).ToList();
                data.SP = DULIEUNHOMSP(TienGiang).ToList();
                data.LOAIHD = DULIEULOAIHD(TienGiang).ToList();
                data.KM = DULIEUKHUYENMAI(TienGiang).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(TienGiang).ToList();
                data.Quan = DULIEUQUAN(TienGiang).ToList();
            }
            else if (macn == "VL")
            {
                data.KV = DULIEUKHUVUC(VinhLong).ToList();
                data.SP = DULIEUNHOMSP(VinhLong).ToList();
                data.LOAIHD = DULIEULOAIHD(VinhLong).ToList();
                data.KM = DULIEUKHUYENMAI(VinhLong).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(VinhLong).ToList();
                data.Quan = DULIEUQUAN(VinhLong).ToList();
            }
            else if (macn == "DNONG")
            {
                data.KV = DULIEUKHUVUC(Daknong).ToList();
                data.SP = DULIEUNHOMSP(Daknong).ToList();

                data.KM = DULIEUKHUYENMAI(Daknong).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(Daknong).ToList();
                data.Quan = DULIEUQUAN(Daknong).ToList();
            }
            else if (macn == "PTTT")
            {
                data.KV = DULIEUCUAHANGKHUVUC(PTTT).ToList();
                data.SP = DULIEUCUAHANGNHOMSP(PTTT).ToList();
                data.LOAIHD = DULIEUCUAHANGLOAIHD(PTTT).ToList();
                data.KM = DULIEUCUAHANGKHUYENMAI(PTTT).GroupBy(n => n.MAKM).Select(cl => new ListKhuyenMai { MAKM = cl.Key, TENKM = cl.FirstOrDefault().TENKM }).ToList();
                data.TDV = DULIEUCUAHANGTRINHDUOCVIEN(PTTT).ToList();
                data.Quan = DULIEUCUAHANGQUAN(PTTT).ToList();
            }
            else if (macn == "QT")
            {
                data.KV = DULIEUKHUVUC(QuangTri).ToList();
                data.SP = DULIEUNHOMSP(QuangTri).ToList();
                data.LOAIHD = DULIEULOAIHD(QuangTri).ToList();
                data.KM = DULIEUKHUYENMAI(QuangTri).ToList();
                data.TDV = DULIEUTRINHDUOCVIEN(QuangTri).ToList();
                data.Quan = DULIEUQUAN(QuangTri).ToList();
            }
            data.HD = GetHopDong(macn);
            var ctkmchung = DATATH1.TBL_DANHMUCKM.Select(n => new { n.MACTKM, n.TENCTKM, n.PHAMVI }).ToList().Where(n => n.PHAMVI.Split(',').Contains(macn)).Select(n => new ListKhuyenMai { MAKM = n.MACTKM, TENKM = n.TENCTKM }).ToList();
            data.KM = data.KM.Where(n => !ctkmchung.Select(c => c.MAKM).Contains(n.MAKM)).Concat(ctkmchung).Distinct().Where(n => n.MAKM != "").OrderBy(n => n.MAKM).ToList();
            data.NHOM = getnhomcn(macn);
            if (Info.mahh != "ALL")
            {
                var taphopsp = Info.mahh.Split(',').ToList();
                data.SP = data.SP.Where(n => taphopsp.Contains(n.MaHH)).ToList();
            }
            if (Info.matinh != "ALL")
            {
                var taphopkv = Info.matinh.Split(',').ToList();
                data.KV = data.KV.Where(n => taphopkv.Contains(n.matinh)).ToList();
            }
            if (Info.maquan != "ALL")
            {
                var taphop = Info.maquan.Split(',').ToList();
                data.Quan = data.Quan.Where(n => taphop.Contains(n.maquan)).ToList();
            }
            return Json(data);
        }
        [HttpPost]
        public IHttpActionResult GetBoLocTH()
        {
            var Info = GetInfo();
            var datakv = DATATH1.TBL_DANHMUCTINH.ToList();
            if (Info.matinh != "ALL")
            {
                var taphop = Info.matinh.Split(',').ToList();
                datakv = datakv.Where(n => taphop.Contains(n.matinh)).ToList();
            }
            List<ListNhomSP> datasp = new List<ListNhomSP>();
            datasp = DULIEUNHOMSP(SC).ToList();
            if (Info.mahh != "ALL")
            {
                var taphop = Info.mahh.Split(',').ToList();
                datasp = datasp.Where(n => taphop.Contains(n.MaHH)).ToList();
            }
            datasp = datasp.GroupBy(n => n.MaHH).Select(cl => new ListNhomSP { MaHH = cl.First().MaHH, TenHH = cl.First().TenHH }).ToList();
            List<LoaiHD> dataloaihd = new List<LoaiHD>();
            dataloaihd = DULIEULOAIHD(SC).ToList();
            var data = new ListBOLOC() { TINH = datakv, HD = dataloaihd, SP = datasp };
            return Json(data);
        }
        [HttpPost]
        public IHttpActionResult GetKhuyenMai(string macn)
        {
            var Info = GetInfo();
            var listmacnquyen = Info.macn.Split(',').ToList();
            var listmacn = macn.Split(',').ToList();
            var result = (from chon in listmacn
                          join quyen in listmacnquyen on chon equals quyen
                          select new
                          {
                              quyen
                          }).Select(cl => cl.quyen).ToList();
            List<ListKhuyenMai> data = new List<ListKhuyenMai>();
            foreach (var ChiNhanh in result)
            {
                if (queryCN.SingleOrDefault(n => n.macn == ChiNhanh) != null)
                {
                    if (ChiNhanh == "TT423")
                    {
                        data = queryCN.SingleOrDefault(n => n.macn == ChiNhanh).data.Database.SqlQuery<ListKhuyenMai>("SELECT MaCTKM AS MAKM, TenCTKM AS TENKM FROM TBL_DANHMUCKHUYENMAI WHERE MaCTKM IS NOT NULL").ToList();
                    }

                    else
                    {
                        data = DULIEUKHUYENMAI(queryCN.SingleOrDefault(n => n.macn == ChiNhanh).data).ToList();
                    }
                }
                else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanh) != null)
                {
                    data = DULIEUCUAHANGKHUYENMAI(queryCH.SingleOrDefault(n => n.macn == ChiNhanh).data).ToList();
                }
            }
            if (result.Count > 1)
            {
                var ctkmchung = DATATH1.TBL_DANHMUCKM.Select(n => new ListKhuyenMai { MAKM = n.MACTKM, TENKM = n.TENCTKM }).ToList();
                return Json(data.GroupBy(n => n.MAKM).Select(cl => new ListKhuyenMai { MAKM = cl.Key, TENKM = cl.First().TENKM }).Where(n => !ctkmchung.Select(c => c.MAKM).Contains(n.MAKM)).Concat(ctkmchung).Distinct().Where(n => n.MAKM != "").OrderBy(n => n.MAKM));
            }
            else
            {
                var ctkmchung = DATATH1.TBL_DANHMUCKM.ToList().Where(n => n.PHAMVI.Split(',').Contains(macn)).Select(n => new ListKhuyenMai { MAKM = n.MACTKM, TENKM = n.TENCTKM }).ToList();
                return Json(data.Where(n => !ctkmchung.Select(c => c.MAKM).Contains(n.MAKM)).Concat(ctkmchung).Distinct().Where(n => n.MAKM != "").OrderBy(n => n.MAKM));
            }
        }

        [HttpPost]
        public HttpResponseMessage xembaocao([FromBody]BSCRECIEVE x)
        {
            //try
            //{
            var phanquyen = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name);

            DateTime gioihan = DateTime.ParseExact("01/01/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime tungay = DateTime.ParseExact(x.tungay1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var loaitru = new List<string>() { "PY.MEN", "PY.DIEN", "HCM.LACVY", "HCM.PHUONGLINH" };
            if (tungay < gioihan && !loaitru.Contains(User.Identity.Name.ToUpper()))
            {
                x.tungay1 = "01/01/2023";
                tungay = gioihan;
            }
            DateTime denngay = DateTime.ParseExact(x.denngay1, "dd/MM/yyyy", CultureInfo.InvariantCulture);

          
            //if (x.nhomhang == "1")
            //{
            //    x.Checkboxlist4 = new List<string> { "50", "51", "60", "61", "62", "63", "70" };
            //}
            //else if (x.nhomhang == "2")
            //{
            //    x.Checkboxlist4 = null;
            //}
            //else if (x.nhomhang == "64.PME")
            //{
            //    x.Checkboxlist4 = new List<string> { "64.PME" };
            //}
            //else if (x.nhomhang == "64.STA")
            //{
            //    x.Checkboxlist4 = new List<string> { "64.STA" };
            //}
            //else if (x.nhomhang == "64")
            //{
            //    x.Checkboxlist4 = new List<string> { "64.STA", "64.PME", "64" };
            //}
         
            if (x.Checkboxlist4 == null)
            {
                if (x.nhomhang.Contains("ALL"))
                {
                    if (phanquyen.manhom != null)
                    {
                        x.Checkboxlist4 = string.Join(",", phanquyen.manhom).Split(',').ToList();
                    }
                    else
                    {
                        x.Checkboxlist4 = null;
                    }
                }
                else
                {
                    x.Checkboxlist4 = string.Join(",", x.nhomhang).Split(',').ToList();
                }
            }
            if (phanquyen.manhom != null)
            {
                x.Checkboxlist4 = (x.Checkboxlist4 != null && phanquyen.manhom.Split(',').Intersect(x.Checkboxlist4).ToList().Count() > 0) ? phanquyen.manhom.Split(',').Intersect(x.Checkboxlist4).ToList() : phanquyen.manhom.Split(',').ToList();
            }
            //if (x.Checkboxlist1.Contains("QT"))
            //{
            //x.Checkboxlist4 = null;
            //}
            var listcheckbox1 = String.Join(",", x.Checkboxlist1.ToArray()).Split(',').Distinct().ToList();
            x.Checkboxlist1 = phanquyen.macn.Split(',').Intersect(listcheckbox1).ToList();
            if (phanquyen.phanloai != "ETC,OTC")
            {
                x.Checkboxlist2 = phanquyen.phanloai;
            }
            if (phanquyen.mahh != "ALL")
            {
                x.Checkboxlist5 = (x.Checkboxlist5 != null && phanquyen.mahh.Split(',').Intersect(x.Checkboxlist5).ToList().Count() > 0) ? phanquyen.mahh.Split(',').Intersect(x.Checkboxlist5).ToList() : phanquyen.mahh.Split(',').ToList();
            }
            if (phanquyen.matinh != "ALL")
            {
                x.Checkboxlist6 = (x.Checkboxlist6 != null && phanquyen.matinh.Split(',').Intersect(x.Checkboxlist6).ToList().Count() > 0) ? phanquyen.matinh.Split(',').Intersect(x.Checkboxlist6).ToList() : phanquyen.matinh.Split(',').ToList();
            }
            if (phanquyen.matdv != "ALL")
            {
                x.Checkboxlist10 = (x.Checkboxlist10 != null && phanquyen.matdv.Split(',').Intersect(x.Checkboxlist10).ToList().Count() > 0) ? phanquyen.matdv.Split(',').Intersect(x.Checkboxlist10).ToList() : phanquyen.matdv.Split(',').ToList();
            }
            if (phanquyen.maquan != "ALL")
            {
                x.Checkboxlist11 = (x.Checkboxlist11 != null && phanquyen.maquan.Split(',').Intersect(x.Checkboxlist11).ToList().Count() > 0) ? phanquyen.maquan.Split(',').Intersect(x.Checkboxlist11).ToList() : phanquyen.maquan.Split(',').ToList();
            }
            if (x.spthauquocgia == true)
            {
                x.Checkboxlist5 = PhuYen.Database.SqlQuery<string>("select MAHH from TBL_DANHMUCHANGHOA where thauqg = 1").ToList();
            }
            if (x.spkhongkedon == true)
            {
                x.Checkboxlist5 = PhuYen.Database.SqlQuery<string>("select MAHH from TBL_DANHMUCHANGHOA where kedon = 1").ToList();
            }
            //if ((x.Checkboxlist9 != null || x.Checkboxlist14 != null) && x.Checkboxlist5 == null)
            //{
            //    try
            //    {
            //        if (x.Checkboxlist14 != null)
            //        {
            //            var mahhctht = String.Join(",", DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.Where(n => x.Checkboxlist14.Contains(n.MACTHT)).Select(cl => cl.MAHH).ToArray());
            //            x.Checkboxlist5 = (mahhctht != "") ? mahhctht.Split(',').Distinct().ToList() : null;
            //        }
            //        else
            //        {
            //            var mahhkm = String.Join(",", DATATH1.TBL_DANHMUCKM.Where(n => x.Checkboxlist9.Contains(n.MACTKM)).Select(cl => cl.MAHH).ToArray());
            //            x.Checkboxlist5 = (mahhkm != "") ? mahhkm.Split(',').Distinct().ToList() : null;
            //        }
            //    }
            //    catch (Exception)
            //    {

            //    }
            //}

            List<string> listcn = phanquyen.macn.Split(',').ToList();
            var cacdonvi = db2.TBL_DANHSACHCHINHANH.Where(n => listcn.Contains(n.macn)).ToList();
            if (x.loaibaocao == 1)
            {
                BAOCAODOANHSOBANTHEO_KH_TONGHOP_MIEN rpt = new BAOCAODOANHSOBANTHEO_KH_TONGHOP_MIEN();
                var data0 = DATABAOCAO0(x.maphanloai.Split(',').ToList(),x.Checkboxlist1, tungay, denngay, x.Checkboxlist2, x.Checkboxlist3, x.Checkboxlist4, x.Checkboxlist5, x.Checkboxlist6, x.Checkboxlist12, x.Checkboxlist9, x.Checkboxlist14, phanquyen);
             
                data0 = data0.GroupBy(n => new { n.chuky1, n.TENDVBC }).Select(cl => new DULIEUBAOCAO0 { chuky1 = cl.First().chuky1, TENDVBC = cl.First().TENDVBC, TIENCK = cl.Sum(c => c.TIENCK), TONGTIEN_CT_HOADON = cl.Sum(c => c.TONGTIEN_CT_HOADON), thangdau = x.tungay1, nam = x.denngay1 }).ToList();
                if (!data0.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }

                string LOC = ((x.lang == "vi") ? "Mã phân loại : " : " Classification code : ") + x.maphanloai + ". " + ((x.Checkboxlist4 != null) ? (((x.lang == "vi") ? "Nhóm hàng : " : "Product groups : ") + string.Join(",", x.Checkboxlist4.ToArray())) : "");
                if (x.Checkboxlist2 != "ALL")
                {
                    LOC = LOC + ((x.lang == "vi") ? ". Phân loại khách hàng : " : ". Customer type") + x.Checkboxlist2;
                }
                if (x.Checkboxlist3 != null)
                {
                    LOC = LOC + ((x.lang == "vi") ? ". Phân loại chi tiết khách hàng : " : ". Customer detail type : ") + string.Join(",", x.Checkboxlist3.ToArray());
                }
                if (x.Checkboxlist6 != null)
                {
                    LOC = LOC + ((x.lang == "vi") ? ". Khu vực : " : ". Area") + string.Join(",", x.Checkboxlist6.ToArray());
                }
                rpt.Load();
                rpt.SetDataSource(data0.OrderBy(n => n.TENDVBC));
                rpt.SetParameterValue("LOC", LOC);
                rpt.SetParameterValue("LANG", x.lang);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });

            }

            else if (x.loaibaocao == 2)
            {
                if (x.Checkboxlist1.Contains("CHQ10") || x.Checkboxlist1.Contains("PTTT") || x.Checkboxlist1.Contains("CHPPSP"))
                {
                    var data1 = DATABAOCAO1CH(x.Checkboxlist1, tungay, denngay, x.Checkboxlist8, x.Checkboxlist6, x.Checkboxlist10, x.Checkboxlist11);
                    if (!data1.Any())
                    {
                        var myMess = new
                        {
                            Message = "Không tìm thấy dữ liệu !",
                        };
                        return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                    }
                    var dataa = new List<DULIEUBAOCAO1CH>();
                    foreach (var i in data1)
                    {
                        dataa.Add(new DULIEUBAOCAO1CH { denngay = x.denngay1, makh1 = i.makh1, sohd = i.sohd, TENKH = i.TENKH, tenkh1 = i.tenkh1, tienban = i.tienban, tiendauky = i.tiendauky, tienthu = i.tienthu, tientrahang = i.tientrahang, tungay = x.tungay1, ngaylaphd = (i.ngaylaphd == null) ? "" : ((DateTime)i.ngaylaphd).ToString("dd/MM/yyyy") });
                    }
                    if (!dataa.Any())
                    {
                        var myMess = new
                        {
                            Message = "Không tìm thấy dữ liệu !",
                        };
                        return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                    }
                    CR_CHITIET_CONGNO_CUAHANG rpt = new CR_CHITIET_CONGNO_CUAHANG();
                    rpt.Load();
                    rpt.SetDataSource(dataa);
                    Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    rpt.Close();
                    rpt.Dispose();
                    GC.Collect();
                    return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                }
                else
                {
                    var data0 = DATABAOCAO1(x.Checkboxlist1, tungay, denngay, x.Checkboxlist8, x.Checkboxlist6, x.Checkboxlist10, x.Checkboxlist11);
                    if (!data0.Any())
                    {
                        var myMess = new
                        {
                            Message = "Không tìm thấy dữ liệu !",
                        };
                        return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                    }
                    List<DULIEUBAOCAO1> data3 = new List<DULIEUBAOCAO1>();
                    foreach (var i in data0.GroupBy(n => new { n.sct, n.ngay }).Select(cl => new sp_INTONGHOPCONGNOCHITIET_IN_Result { sct = cl.Key.sct, CHUKY1 = cl.FirstOrDefault().CHUKY1, CHUKY2B = cl.FirstOrDefault().CHUKY2B, psno = cl.Sum(n => n.psno), psco = cl.Sum(n => n.psco), cocuoiky = cl.FirstOrDefault().cocuoiky, codauky = cl.FirstOrDefault().codauky, DENNGAY = cl.FirstOrDefault().DENNGAY, donvi = cl.FirstOrDefault().donvi, makh = cl.FirstOrDefault().makh, ngay = cl.Key.ngay, NGAYIN = cl.FirstOrDefault().NGAYIN, nocuoiky = cl.FirstOrDefault().nocuoiky, nodauky = cl.FirstOrDefault().nodauky, noidung = cl.FirstOrDefault().noidung, TENDVBC = cl.FirstOrDefault().TENDVBC, TUNGAY = cl.FirstOrDefault().TUNGAY }).OrderBy(n => n.ngay))
                    {
                        if (i.CHUKY1 == null)
                        {
                            i.CHUKY1 = "";
                        }
                        if (i.CHUKY2B == null)
                        {
                            i.CHUKY2B = "";
                        }
                        if (i.cocuoiky == null)
                        {
                            i.cocuoiky = 0;
                        }
                        if (i.codauky == null)
                        {
                            i.codauky = 0;
                        }
                        if (i.donvi == null)
                        {
                            i.donvi = "";
                        }
                        if (i.makh == null)
                        {
                            i.makh = "";
                        }
                        if (i.nocuoiky == null)
                        {
                            i.nocuoiky = 0;
                        }
                        if (i.nodauky == null)
                        {
                            i.nodauky = 0;
                        }
                        if (i.psco == null)
                        {
                            i.psco = 0;
                        }
                        if (i.psno == null)
                        {
                            i.psno = 0;
                        }
                        data3.Add(new DULIEUBAOCAO1 { chuky1 = i.CHUKY1, chuky2b = i.CHUKY2B, cocuoiky = (decimal)i.cocuoiky, codauky = (decimal)i.codauky, DENNGAY = Convert.ToDateTime(i.DENNGAY).ToString("dd/MM/yyyy"), donvi = i.donvi, makh = i.makh, ngay = (i.ngay == null) ? "" : ((DateTime)i.ngay).ToString("dd/MM/yyyy"), nocuoiky = (decimal)i.nocuoiky, nodauky = (decimal)i.nodauky, noidung = i.noidung, psco = (decimal)i.psco, psno = (decimal)i.psno, sct = i.sct, tendvbc = i.TENDVBC, tk = "", TUNGAY = Convert.ToDateTime(i.TUNGAY).ToString("dd/MM/yyyy") });
                    }
                    CR_TONGHOP_131_CHITIET rpt = new CR_TONGHOP_131_CHITIET();
                    rpt.Load();
                    rpt.SetDataSource(data3);
                    rpt.SetParameterValue("tungay", x.tungay1);
                    rpt.SetParameterValue("denngay", x.denngay1);
                    Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    rpt.Close();
                    rpt.Dispose();
                    GC.Collect();
                    return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                }
            }
            else if (x.loaibaocao == 3)
            {
                CR_kt2_kyhan_th rpt = new CR_kt2_kyhan_th();
                var data0 = DATABAOCAO2(x.Checkboxlist1, tungay, denngay, x.Checkboxlist8, x.Checkboxlist10, x.Checkboxlist2, x.Checkboxlist6);
                if (!data0.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                rpt.Load();
                rpt.SetDataSource(data0);
                string kybaocao = " Tháng :" + denngay.Month + " Năm: " + denngay.Year;
                string diengiai = "";
                if (x.Checkboxlist8 != null)
                {
                    diengiai = "TK: 131 - " + String.Join(",", x.Checkboxlist8.ToArray());
                }
                else
                {
                    diengiai = "TK: 131 - MATDV: " + String.Join(",", x.Checkboxlist10.ToArray());
                }
                rpt.SetParameterValue("kybaocao", kybaocao);
                rpt.SetParameterValue("strDiengiai1", diengiai);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
            if (x.loaibaocao == 8 && (x.maphanloai.Split(',').ToList().Contains("TH") || x.maphanloai.Split(',').ToList().Contains("NTH")))
            {
                BAOCAO_TONGHOP_CT_XUAT_KHUVUC rpt = new BAOCAO_TONGHOP_CT_XUAT_KHUVUC();
                var data0 = DATABAOCAO8(x.Checkboxlist1, tungay, denngay, x.Checkboxlist2, x.Checkboxlist3, x.Checkboxlist4, x.Checkboxlist5, x.Checkboxlist11, x.Checkboxlist6, x.Checkboxlist8, x.Checkboxlist10, x.Checkboxlist12, x.maphanloai.Split(',').ToList(), x.Checkboxlist9, x.Checkboxlist14, x.tienck);
                if (!data0.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                rpt.Load();
                rpt.SetDataSource(data0);
                rpt.SetParameterValue("tungay", x.tungay1);
                rpt.SetParameterValue("denngay", x.denngay1);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });

            }
            if (x.loaibaocao == 12 && (x.maphanloai.Split(',').ToList().Contains("TH") || x.maphanloai.Split(',').ToList().Contains("NTH")))
            {
                BAOCAO_TONGHOP_CT_XUAT_MAKH_MAHH_SOHD rpt = new BAOCAO_TONGHOP_CT_XUAT_MAKH_MAHH_SOHD();
                var data0 = DATABAOCAO12(x.Checkboxlist1, tungay, denngay, x.Checkboxlist2, x.Checkboxlist3, x.Checkboxlist4, x.Checkboxlist5, x.Checkboxlist11, x.Checkboxlist6, x.Checkboxlist8, x.Checkboxlist10, x.Checkboxlist12, x.maphanloai.Split(',').ToList(), x.Checkboxlist9, x.Checkboxlist14, x.tienck);
                if (!data0.Any())
                {

                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                rpt.Load();
                rpt.SetDataSource(data0.OrderBy(n => n.mapl));
                rpt.SetParameterValue("tungay", x.tungay1);
                rpt.SetParameterValue("denngay", x.denngay1);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
            else if (x.loaibaocao == 4)
            {
                CR_TONGHOP_CONGNO rpt = new CR_TONGHOP_CONGNO();
                var data0 = DATABAOCAO3(x.Checkboxlist1, tungay, denngay, x.Checkboxlist2, x.Checkboxlist3, x.Checkboxlist6, x.Checkboxlist10, x.Checkboxlist11);
                if (!data0.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                var data4 = data0.Select(i => new DULIEUBAOCAO3 { chuky1 = i.chuky1, chuky2b = i.chuky2b, chuky3 = i.chuky3, COCUOIKY = (i.COCUOIKY == null) ? 0 : (double)i.COCUOIKY, CODAUKY = (i.CODAUKY == null) ? 0 : (double)i.CODAUKY, DENNGAY = ((DateTime)i.DENNGAY).ToString("dd/MM/yyyy"), TUNGAY = ((DateTime)i.TUNGAY).ToString("dd/MM/yyyy"), MAKH = i.MAKH, matdv = i.matdv, matinh = i.matinh, MATK = i.MATK, ngayin = ((DateTime)i.ngayin), NOCUOIKY = (i.NOCUOIKY == null) ? 0 : (double)i.NOCUOIKY, NODAUKY = (i.NODAUKY == null) ? 0 : (double)i.NODAUKY, NOIDUNG = i.NOIDUNG, PSCO = (i.PSCO == null) ? 0 : (double)i.PSCO, PSNO = (i.PSNO == null) ? 0 : (double)i.PSNO, tendvbc = i.tendvbc, tinh = i.tinh });
                rpt.Load();
                rpt.SetDataSource(data4);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
            else if (x.loaibaocao == 23)
            {
                BAOCAO23NEW rpt = new BAOCAO23NEW();
              
                var list = db2.TBL_DSKHOAN.Where(n => n.nam == denngay.Year).ToList();
                var datanow = DATABAOCAO23(x.maphanloai.Split(',').ToList(), x.Checkboxlist1, new DateTime(denngay.Year, 1, 1), denngay, x.Checkboxlist2, x.Checkboxlist3, x.Checkboxlist4, x.Checkboxlist5, x.Checkboxlist11, x.Checkboxlist6, x.Checkboxlist10, x.Checkboxlist12, x.Checkboxlist8, x.Checkboxlist9, x.Checkboxlist13, x.Checkboxlist14).ToList();
                var datalate = DATABAOCAO23(x.maphanloai.Split(',').ToList(), x.Checkboxlist1, new DateTime(denngay.Year - 1, 1, 1), denngay.AddYears(-1), x.Checkboxlist2, x.Checkboxlist3, x.Checkboxlist4, x.Checkboxlist5, x.Checkboxlist11, x.Checkboxlist6, x.Checkboxlist10, x.Checkboxlist12, x.Checkboxlist8, x.Checkboxlist9, x.Checkboxlist13, x.Checkboxlist14).ToList();
                var tentinh = DATATH1.TBL_DANHMUCTINH.ToList();
                datanow.AddRange(datalate);
                var data0 = datanow.GroupBy(n => n.MATINH).Select(n => new DULIEUBAOCAOFINAL { MATINH = n.Key, TENDVBC = (list.SingleOrDefault(cl => cl.matinh == n.Key) != null) ? list.SingleOrDefault(cl => cl.matinh == n.Key).tencn : "ORTHER", DSKHOAN = (list.SingleOrDefault(cl => cl.matinh == n.Key) != null) ? (decimal)list.SingleOrDefault(cl => cl.matinh == n.Key).doanhso : 0, DSTUDAUNAMNOW = n.Where(z => z.NAM == denngay.Year).Sum(z => z.TIEN), DSTUDAUNAMLAST = n.Where(z => z.NAM == (denngay.Year - 1)).Sum(z => z.TIEN), DSTUDAUNAMTHANGTRUOCNOW = n.Where(z => z.NAM == denngay.Year && z.THANG < denngay.Month).Sum(z => z.TIEN), DSTUDAUNAMTHANGTRUOCLAST = n.Where(z => z.NAM == (denngay.Year - 1) && z.THANG < denngay.Month).Sum(z => z.TIEN), DSTRONGTHANGNOW = n.Where(z => z.NAM == denngay.Year && z.THANG == denngay.Month).Sum(z => z.TIEN), DSTRONGTHANGLAST = n.Where(z => z.NAM == (denngay.Year - 1) && z.THANG == denngay.Month).Sum(z => z.TIEN), TENTINH = (tentinh.SingleOrDefault(cl => cl.matinh == n.Key) != null) ? tentinh.SingleOrDefault(cl => cl.matinh == n.Key).tentinh : "ORTHER", DSKHOANTHANGTRUOC = (list.SingleOrDefault(cl => cl.matinh == n.Key) != null) ? (decimal)list.SingleOrDefault(cl => cl.matinh == n.Key).doanhso / 12 * (denngay.Month - 1) : 0, DSKHOANTHANG = (list.SingleOrDefault(cl => cl.matinh == n.Key) != null) ? (decimal)list.SingleOrDefault(cl => cl.matinh == n.Key).doanhso / 12 * (denngay.Month) : 0, DSKHOANTRONGTHANG = (list.SingleOrDefault(cl => cl.matinh == n.Key) != null) ? (decimal)list.SingleOrDefault(cl => cl.matinh == n.Key).doanhso / 12 : 0, TILETHANGTRUOC = (list.SingleOrDefault(cl => cl.matinh == n.Key) != null) ? (n.Where(z => z.NAM == denngay.Year && z.THANG < denngay.Month).Sum(z => z.TIEN)) / ((decimal)list.SingleOrDefault(z => z.matinh == n.Key).doanhso / 12 * (denngay.Month - 1)) * 100 : 0, TILETHANG = (list.SingleOrDefault(cl => cl.matinh == n.Key) != null) ? (n.Where(z => z.NAM == denngay.Year).Sum(z => z.TIEN)) / ((decimal)list.SingleOrDefault(z => z.matinh == n.Key).doanhso / 12 * (denngay.Month)) * 100 : 0, TILETRONGTHANG = (list.SingleOrDefault(cl => cl.matinh == n.Key) != null) ? (n.Where(z => z.NAM == denngay.Year && z.THANG == denngay.Month).Sum(z => z.TIEN)) / ((decimal)list.SingleOrDefault(z => z.matinh == n.Key).doanhso / 12) * 100 : 0 });
                if (!data0.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                return Request.CreateResponse(HttpStatusCode.OK, data0);
                //rpt.Load();
                //rpt.SetDataSource(data0);
                //rpt.SetParameterValue("denngay", denngay);
                //Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);
                //rpt.Close();
                //rpt.Dispose();
                //GC.Collect();
                //var result = Request.CreateResponse(HttpStatusCode.OK);

                //result.Content = new StreamContent(s);
                //result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                //{
                //    FileName = "BAOCAOKHOAN.xls"
                //};
                //return result;
            }
            else if (x.loaibaocao == 7)
            {
                CR_kt2_kyhan_ct_chiphi rpt = new CR_kt2_kyhan_ct_chiphi();
                var data0 = DATABAOCAO7(x.Checkboxlist1, denngay, x.Checkboxlist8, x.Checkboxlist10);
                if (!data0.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                var data1 = data0.OrderBy(n => n.NGAY).ThenBy(n => n.SCT).Select(i => new DULIEUBAOCAO7FINAL { donvi = i.donvi, MAKH = i.MAKH, NGAY = i.NGAY.ToString("dd/MM/yyyy"), SCT = i.SCT, SONGAY = i.SONGAY, t1 = i.t1, t10 = i.t10, t11 = i.t11, t12 = i.t12, t13 = i.t13, t2 = i.t2, t3 = i.t3, t4 = i.t4, t5 = i.t5, t6 = i.t6, t7 = i.t7, t8 = i.t8, t9 = i.t9, TIEN = i.TIEN });
                rpt.Load();
                rpt.SetDataSource(data1);
                string kybaocao = "Ngày : " + denngay.Day + " Tháng : " + denngay.Month + " Năm : " + denngay.Year;
                string diengiai;
                if (x.Checkboxlist10 != null && x.Checkboxlist8 == null)
                {
                    diengiai = "Trình dược viên : " + String.Join(",", x.Checkboxlist10.ToArray());
                }
                else
                {
                    diengiai = "Mã khách hàng : " + String.Join(",", x.Checkboxlist8.ToArray());
                }
                rpt.SetParameterValue("kybaocao", kybaocao);
                rpt.SetParameterValue("strDiengiai1", diengiai);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });

            }
            else if (x.loaibaocao == 16)
            {
                BAOCAODOANHSOBANTHEO_KH_TONGHOP_MIEN_DASHBOARD_TH_MIEN_CN rpt = new BAOCAODOANHSOBANTHEO_KH_TONGHOP_MIEN_DASHBOARD_TH_MIEN_CN();
                var data0 = DATABAOCAO16(x.Checkboxlist1, x.Checkboxlist2, x.Checkboxlist3, x.maphanloai.Split(',').ToList(), tungay, denngay, x.Checkboxlist5, x.Checkboxlist6, x.Checkboxlist10, x.Checkboxlist11, phanquyen);
                if (!data0.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                rpt.Load();
                rpt.SetDataSource(data0.OrderByDescending(n => n.tien));
                rpt.SetParameterValue("tungay", x.tungay1);
                rpt.SetParameterValue("denngay", x.denngay1);
                //var noidung = "Đơn vị: " + String.Join(", ", x.Checkboxlist1.ToArray()) + "\nMã PL: " + String.Join(", ", x.maphanloai.Split(',').ToList().ToArray()) + "\nPhân loại khách hàng: " + String.Join(", ", x.Checkboxlist2.ToArray()) + ((x.Checkboxlist4 != null) ? ("\nNhóm sản phẩm: " + String.Join(", ", x.Checkboxlist4.ToArray())) : "") + ((x.Checkboxlist5 != null) ? ("\nSản phẩm: " + String.Join(", ", x.Checkboxlist5.ToArray())) : "") + ((x.Checkboxlist10 != null) ? ("\nMã TDV: " + String.Join(", ", x.Checkboxlist10.ToArray())) : "") + ((x.Checkboxlist6 != null) ? ("\nMã tỉnh: " + String.Join(", ", x.Checkboxlist6.ToArray())) : "" + ((x.Checkboxlist11 != null) ? ("\nQuận/Huyện: " + String.Join(", ", x.Checkboxlist11.ToArray())) : ""));
                rpt.SetParameterValue("LOC", "");
                rpt.SetParameterValue("LANG", x.lang);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });

            }
            else if (x.loaibaocao == 24)
            {
                BAOCAO_TONGHOP_CT_XUAT_MAKH_BIENBANTHOATHUAN rpt = new BAOCAO_TONGHOP_CT_XUAT_MAKH_BIENBANTHOATHUAN();
                var data0 = DATABAOCAO24(x.Checkboxlist1, tungay.Year, x.Checkboxlist8, x.Checkboxlist9, x.Checkboxlist14, x.Checkboxlist6, x.Checkboxlist10, x.Checkboxlist11, phanquyen);
                if (!data0.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                var data1 = data0.Select(n => new DULIEUBAOCAO24FINAL { ckdat = (n.ckdat != null) ? (double)n.ckdat : 0, ckqui = (n.ckqui != null) ? (double)n.ckqui : 0, DOANHSOLONHONQUI = n.DOANHSOLONHONQUI, DONVI = n.DONVI, DS1 = n.DS1, DS2 = n.DS2, DS3 = n.DS3, DS4 = n.DS4, KH = n.KH, MAKH = n.MAKH, MAKM = n.MAKM, NAM = n.NAM, Q1 = n.Q1, Q2 = n.Q2, Q3 = n.Q3, Q4 = n.Q4, TENDVBC = n.TENDVBC }).ToList();

                rpt.Load();
                rpt.SetDataSource(data1);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
            else if (x.loaibaocao == 26)
            {
                BAOCAO_TONGHOP_CT_XUAT_MAKH_BIENBANTHOATHUAN_QUI rpt = new BAOCAO_TONGHOP_CT_XUAT_MAKH_BIENBANTHOATHUAN_QUI();
                var data0 = DATABAOCAO26(x.Checkboxlist1, x.nam, x.Checkboxlist8, x.Checkboxlist9, x.Checkboxlist14, x.Checkboxlist6, x.Checkboxlist10, x.Checkboxlist11, x.qui, phanquyen);
                if (!data0.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                var data1 = data0.Select(n => new DULIEUBAOCAO26FINAL { ckqui = (n.ckqui != null) ? (double)n.ckqui : 0, DOANHSOLONHONQUI = n.DOANHSOLONHONQUI, DONVI = n.DONVI, DS1 = n.DS1, DS2 = n.DS2, DS3 = n.DS3, KH = n.KH, MAKH = n.MAKH, MAKM = n.MAKM, NAM = n.NAM, TENDVBC = n.TENDVBC, DS = n.DS, T1 = n.T1, T2 = n.T2, T3 = n.T3, THANG = n.THANG, QUI = n.QUI }).ToList();
                rpt.Load();
                rpt.SetDataSource(data1);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
            else if (x.loaibaocao == 17)
            {
                CR_kt2_kyhan_ct rpt = new CR_kt2_kyhan_ct();
                var data0 = new List<DULIEUBAOCAO17>();
                var str = "EXEC sp_kyhan_inct '" + 131 + "'," + denngay.Month + "," + denngay.Year + ",'','" + String.Join(",", x.Checkboxlist8.ToArray()) + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "'";
                data0 = DATABAOCAO17(x.Checkboxlist1, str);
                if (!data0.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                rpt.Load();
                rpt.SetDataSource(data0);
                string kybaocao = " Tháng :" + denngay.Month + " Năm: " + denngay.Year;
                string diengiai = "";
                if (data0.Count() != 0)
                {
                    diengiai = data0.First().donvi + "(" + data0.First().MAKH + ".131)";
                }

                rpt.SetParameterValue("kybaocao", kybaocao);
                rpt.SetParameterValue("strDiengiai1", diengiai);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
            else if (x.loaibaocao == 13)
            {
                BAOCAO_TONGHOP_CT_XUAT_TDV rpt = new BAOCAO_TONGHOP_CT_XUAT_TDV();
                var data0 = DATABAOCAO13(x.Checkboxlist1, tungay, denngay, x.Checkboxlist2, x.Checkboxlist3, x.Checkboxlist4, x.Checkboxlist5, x.Checkboxlist11, x.Checkboxlist6, x.Checkboxlist8, x.Checkboxlist10, x.Checkboxlist12, x.maphanloai.Split(',').ToList(), x.Checkboxlist9, x.Checkboxlist13, x.Checkboxlist14, x.tienck);
                if (!data0.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                rpt.Load();
                rpt.SetDataSource(data0);
                rpt.SetParameterValue("tungay", x.tungay1);
                rpt.SetParameterValue("denngay", x.denngay1);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
            else if (x.loaibaocao == 15)
            {
                BAOCAO_TONGHOP_CT_XUAT_KHUYENMAI rpt = new BAOCAO_TONGHOP_CT_XUAT_KHUYENMAI();
                var data0 = DATABAOCAO15(x.Checkboxlist1, tungay, denngay, x.Checkboxlist2, x.Checkboxlist3, x.Checkboxlist4, x.Checkboxlist5, x.Checkboxlist11, x.Checkboxlist6, x.Checkboxlist8, x.Checkboxlist10, x.Checkboxlist12, x.maphanloai.Split(',').ToList(), x.Checkboxlist9, x.Checkboxlist14, x.tienck);
                if (!data0.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                rpt.Load();
                rpt.SetDataSource(data0);
                rpt.SetParameterValue("tungay", x.tungay1);
                rpt.SetParameterValue("denngay", x.denngay1);
                string loc = "";
                if (x.Checkboxlist8 != null)
                {
                    var kh = GetTenKhachHang(x.Checkboxlist1, x.Checkboxlist8).Select(cl => (cl.MAKH + " - " + cl.DONVI)).ToList();
                    loc = "<b>Khách hàng</b> : " + String.Join(", ", kh.ToArray());
                }
                rpt.SetParameterValue("LOC", loc);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
            else if (x.loaibaocao == 27)
            {
                BAOCAO_TONGHOP__KHACHHANG_THUONGXUYEN rpt = new BAOCAO_TONGHOP__KHACHHANG_THUONGXUYEN();
                var data0 = DATABAOCAO27(x.Checkboxlist1, x.Checkboxlist2, x.Checkboxlist3, x.Checkboxlist4, x.Checkboxlist5, x.Checkboxlist11, x.Checkboxlist6, x.Checkboxlist8, x.Checkboxlist10, x.Checkboxlist12, x.maphanloai.Split(',').ToList(), x.Checkboxlist9, x.Checkboxlist14, x.qui, x.nam);
                if (!data0.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                rpt.Load();
                rpt.SetDataSource(data0);
                rpt.SetParameterValue("qui", x.qui);
                rpt.SetParameterValue("nam", x.nam);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
            else if (x.loaibaocao == 25)
            {
                BAOCAO_TONGHOP__KHACHHANG_THUONGXUYEN_QUI rpt = new BAOCAO_TONGHOP__KHACHHANG_THUONGXUYEN_QUI();
                var data0 = DATABAOCAO25(x.Checkboxlist1, x.Checkboxlist2, x.Checkboxlist3, x.Checkboxlist4, x.Checkboxlist5, x.Checkboxlist11, x.Checkboxlist6, x.Checkboxlist8, x.Checkboxlist10, x.Checkboxlist12, x.maphanloai.Split(',').ToList(), x.Checkboxlist9, x.Checkboxlist14, x.nam);
                if (!data0.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                rpt.Load();
                rpt.SetDataSource(data0);
                rpt.SetParameterValue("NAM", x.nam);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
            else if (x.loaibaocao == 33)
            {
                var datakm = DATABAOCAOKM(x.maphanloai.Split(',').ToList(), x.Checkboxlist1, tungay, denngay, x.Checkboxlist2, x.Checkboxlist3, x.Checkboxlist4, x.Checkboxlist5, x.Checkboxlist11, x.Checkboxlist6, x.Checkboxlist10, x.Checkboxlist12, x.Checkboxlist8, x.Checkboxlist9, x.Checkboxlist13, x.Checkboxlist14).Where(n => n.SOLUONG != 0).ToList();

                var data1 = new List<TONGHOPCTBHDATA>();
                if (x.Checkboxlist9 != null && x.Checkboxlist14 == null)
                {
                    TONGHOPCTBH rpt = new TONGHOPCTBH();
                    data1 = datakm.GroupBy(n => new { n.MATINH, n.MAKM }).Select(cl => new TONGHOPCTBHDATA { MATINH = cl.Key.MATINH, MAKM = cl.Key.MAKM, DOANHSO = cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) }).ToList();
                    foreach (var i in data1)
                    {
                        var tv = DATATH1.TBL_DANHMUCKM.SingleOrDefault(n => n.MACTKM == i.MAKM);
                        if (tv != null)
                        {
                            i.NGAYBATDAU = ((DateTime)tv.ngaybatdau).ToString("dd/MM/yyyy");
                            i.NGAYKETTHUC = ((DateTime)tv.ngayketthuc).ToString("dd/MM/yyyy");
                            i.TENKM = tv.TENCTKM;
                        }
                        else
                        {
                            var abc = GetDataKM(x.Checkboxlist1.FirstOrDefault(), i.MAKM);
                            if (abc != null)
                            {
                                i.TENKM = abc.TENKM;
                                i.NGAYBATDAU = (abc.ngaybatdau != null) ? ((DateTime)abc.ngaybatdau).ToString("dd/MM/yyyy") : "N/A";
                                i.NGAYKETTHUC = (abc.ngayketthuc != null) ? ((DateTime)abc.ngayketthuc).ToString("dd/MM/yyyy") : "N/A";
                            }
                            else
                            {
                                i.TENKM = "N/A";
                                i.NGAYBATDAU = "N/A";
                                i.NGAYKETTHUC = "N/A";
                            }
                        }
                        if (i.MACTHT != "" && i.MACTHT != null)
                        {
                            var tv1 = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.SingleOrDefault(n => n.MACTHT == i.MACTHT);
                            if (tv1 != null)
                            {
                                i.NGAYBATDAU = ((DateTime)tv1.ngaybatdau).ToString("dd/MM/yyyy");
                                i.NGAYKETTHUC = ((DateTime)tv1.ngayketthuc).ToString("dd/MM/yyyy");
                                i.TENCTHT = tv1.TENCTHT;
                            }
                            else
                            {
                                i.TENCTHT = "N/A";
                            }
                        }
                        var z = DATATH1.TBL_DANHMUCTINH.SingleOrDefault(n => n.matinh == i.MATINH);
                        if (z != null)
                        {
                            i.TENTINH = z.tentinh;
                        }
                    }
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    rpt.SetParameterValue("tungay", x.tungay1);
                    rpt.SetParameterValue("denngay", x.denngay1);
                    rpt.SetParameterValue("loc", "Mã CN : " + string.Join(",", x.Checkboxlist1.ToArray()));

                    Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    rpt.Close();
                    rpt.Dispose();
                    GC.Collect();
                    return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                }
                else if (x.Checkboxlist9 == null && x.Checkboxlist14 != null)
                {
                    TONGHOPCTBHHT rpt = new TONGHOPCTBHHT();
                    data1 = datakm.GroupBy(n => new { n.MATINH, n.MACTHT }).Select(cl => new TONGHOPCTBHDATA { MATINH = cl.Key.MATINH, MACTHT = cl.Key.MACTHT, DOANHSO = cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) }).ToList();
                    foreach (var i in data1)
                    {
                        var tv = DATATH1.TBL_DANHMUCKM.SingleOrDefault(n => n.MACTKM == i.MAKM);
                        if (tv != null)
                        {
                            i.NGAYBATDAU = ((DateTime)tv.ngaybatdau).ToString("dd/MM/yyyy");
                            i.NGAYKETTHUC = ((DateTime)tv.ngayketthuc).ToString("dd/MM/yyyy");
                            i.TENKM = tv.TENCTKM;
                        }
                        else
                        {
                            var abc = GetDataKM(x.Checkboxlist1.FirstOrDefault(), i.MAKM);
                            if (abc != null)
                            {
                                i.TENKM = abc.TENKM;
                                i.NGAYBATDAU = (abc.ngaybatdau != null) ? ((DateTime)abc.ngaybatdau).ToString("dd/MM/yyyy") : "N/A";
                                i.NGAYKETTHUC = (abc.ngayketthuc != null) ? ((DateTime)abc.ngayketthuc).ToString("dd/MM/yyyy") : "N/A";
                            }
                            else
                            {
                                i.TENKM = "N/A";
                                i.NGAYBATDAU = "N/A";
                                i.NGAYKETTHUC = "N/A";
                            }
                        }
                        if (i.MACTHT != "" && i.MACTHT != null)
                        {
                            var tv1 = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.SingleOrDefault(n => n.MACTHT == i.MACTHT);
                            if (tv1 != null)
                            {
                                i.NGAYBATDAU = ((DateTime)tv1.ngaybatdau).ToString("dd/MM/yyyy");
                                i.NGAYKETTHUC = ((DateTime)tv1.ngayketthuc).ToString("dd/MM/yyyy");
                                i.TENCTHT = tv1.TENCTHT;
                            }
                            else
                            {
                                i.TENCTHT = "N/A";
                            }
                        }
                        var z = DATATH1.TBL_DANHMUCTINH.SingleOrDefault(n => n.matinh == i.MATINH);
                        if (z != null)
                        {
                            i.TENTINH = z.tentinh;
                        }
                    }
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    rpt.SetParameterValue("tungay", x.tungay1);
                    rpt.SetParameterValue("denngay", x.denngay1);
                    rpt.SetParameterValue("loc", "Mã CN : " + string.Join(",", x.Checkboxlist1.ToArray()));
                    Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    rpt.Close();
                    rpt.Dispose();
                    GC.Collect();
                    return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                }
                else
                {
                    CHITIETCTBH rpt = new CHITIETCTBH();
                    data1 = new List<TONGHOPCTBHDATA>();
                    data1 = datakm.GroupBy(n => new { n.MATINH, n.MAKM, n.MACTHT }).Select(cl => new TONGHOPCTBHDATA { MATINH = cl.Key.MATINH, MACTHT = cl.Key.MACTHT, MAKM = cl.Key.MAKM, DOANHSO = cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) }).ToList();
                    foreach (var i in data1)
                    {
                        var tv = DATATH1.TBL_DANHMUCKM.SingleOrDefault(n => n.MACTKM == i.MAKM);
                        if (tv != null)
                        {
                            i.NGAYBATDAU = ((DateTime)tv.ngaybatdau).ToString("dd/MM/yyyy");
                            i.NGAYKETTHUC = ((DateTime)tv.ngayketthuc).ToString("dd/MM/yyyy");
                            i.TENKM = tv.TENCTKM;
                        }
                        else
                        {
                            var abc = GetDataKM(x.Checkboxlist1.FirstOrDefault(), i.MAKM);
                            if (abc != null)
                            {
                                i.TENKM = abc.TENKM;
                                i.NGAYBATDAU = (abc.ngaybatdau != null) ? ((DateTime)abc.ngaybatdau).ToString("dd/MM/yyyy") : "N/A";
                                i.NGAYKETTHUC = (abc.ngayketthuc != null) ? ((DateTime)abc.ngayketthuc).ToString("dd/MM/yyyy") : "N/A";
                            }
                            else
                            {
                                i.TENKM = "N/A";
                                i.NGAYBATDAU = "N/A";
                                i.NGAYKETTHUC = "N/A";
                            }
                        }
                        if (i.MACTHT != "" && i.MACTHT != null)
                        {
                            var tv1 = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.SingleOrDefault(n => n.MACTHT == i.MACTHT);
                            if (tv1 != null)
                            {
                                i.NGAYBATDAU = ((DateTime)tv1.ngaybatdau).ToString("dd/MM/yyyy");
                                i.NGAYKETTHUC = ((DateTime)tv1.ngayketthuc).ToString("dd/MM/yyyy");
                                i.TENCTHT = tv1.TENCTHT;
                            }
                            else
                            {
                                i.TENCTHT = "N/A";
                            }
                        }
                        var z = DATATH1.TBL_DANHMUCTINH.SingleOrDefault(n => n.matinh == i.MATINH);
                        if (z != null)
                        {
                            i.TENTINH = z.tentinh;
                        }
                        if (i.MACTHT == null || i.MACTHT == "")
                        {
                            i.MACTHT = "N/A";
                            i.TENCTHT = "N/A";
                        }
                    }
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    rpt.SetParameterValue("tungay", x.tungay1);
                    rpt.SetParameterValue("denngay", x.denngay1);
                    rpt.SetParameterValue("loc", "Mã CN : " + string.Join(",", x.Checkboxlist1.ToArray()));
                    Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    rpt.Close();
                    rpt.Dispose();
                    GC.Collect();
                    return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                }
            }
            else if (x.loaibaocao == 34)
            {
                var datakm = DATABAOCAOKM(x.maphanloai.Split(',').ToList(), x.Checkboxlist1, tungay, denngay, x.Checkboxlist2, x.Checkboxlist3, x.Checkboxlist4, x.Checkboxlist5, x.Checkboxlist11, x.Checkboxlist6, x.Checkboxlist10, x.Checkboxlist12, x.Checkboxlist8, x.Checkboxlist9, x.Checkboxlist13, x.Checkboxlist14).Where(n => n.SOLUONG != 0).ToList();

                CHITIETCTBH rpt = new CHITIETCTBH();
                var data1 = new List<TONGHOPCTBHDATA>();
                data1 = datakm.GroupBy(n => new { n.MATINH, n.MAKM, n.MACTHT }).Select(cl => new TONGHOPCTBHDATA { MATINH = cl.Key.MATINH, MACTHT = cl.Key.MACTHT, MAKM = cl.Key.MAKM, DOANHSO = cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) }).ToList();
                foreach (var i in data1)
                {
                    var tv = DATATH1.TBL_DANHMUCKM.SingleOrDefault(n => n.MACTKM == i.MAKM);
                    if (tv != null)
                    {
                        i.NGAYBATDAU = ((DateTime)tv.ngaybatdau).ToString("dd/MM/yyyy");
                        i.NGAYKETTHUC = ((DateTime)tv.ngayketthuc).ToString("dd/MM/yyyy");
                        i.TENKM = tv.TENCTKM;
                    }
                    else
                    {
                        var abc = GetDataKM(x.Checkboxlist1.FirstOrDefault(), i.MAKM);
                        if (abc != null)
                        {
                            i.TENKM = abc.TENKM;
                            i.NGAYBATDAU = (abc.ngaybatdau != null) ? ((DateTime)abc.ngaybatdau).ToString("dd/MM/yyyy") : "N/A";
                            i.NGAYKETTHUC = (abc.ngayketthuc != null) ? ((DateTime)abc.ngayketthuc).ToString("dd/MM/yyyy") : "N/A";
                        }
                        else
                        {
                            i.TENKM = "N/A";
                            i.NGAYBATDAU = "N/A";
                            i.NGAYKETTHUC = "N/A";
                        }
                    }
                    if (i.MACTHT != "" && i.MACTHT != null)
                    {
                        var tv1 = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.SingleOrDefault(n => n.MACTHT == i.MACTHT);
                        if (tv1 != null)
                        {
                            i.NGAYBATDAU = ((DateTime)tv1.ngaybatdau).ToString("dd/MM/yyyy");
                            i.NGAYKETTHUC = ((DateTime)tv1.ngayketthuc).ToString("dd/MM/yyyy");
                            i.TENCTHT = tv1.TENCTHT;
                        }
                        else
                        {
                            i.TENCTHT = "N/A";
                        }
                    }
                    var z = DATATH1.TBL_DANHMUCTINH.SingleOrDefault(n => n.matinh == i.MATINH);
                    if (z != null)
                    {
                        i.TENTINH = z.tentinh;
                    }
                    if (i.MACTHT == null || i.MACTHT == "")
                    {
                        i.MACTHT = "N/A";
                        i.TENCTHT = "N/A";
                    }
                }
                rpt.Load();
                rpt.SetDataSource(data1);
                rpt.SetParameterValue("tungay", x.tungay1);
                rpt.SetParameterValue("denngay", x.denngay1);
                rpt.SetParameterValue("loc", "Mã CN : " + string.Join(",", x.Checkboxlist1.ToArray()));
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
            else if (x.loaibaocao == 18)
            {
                var datakm = DATABAOCAOKM(x.maphanloai.Split(',').ToList(), x.Checkboxlist1, tungay, denngay, x.Checkboxlist2, x.Checkboxlist3, x.Checkboxlist4, x.Checkboxlist5, x.Checkboxlist11, x.Checkboxlist6, x.Checkboxlist10, x.Checkboxlist12, x.Checkboxlist8, x.Checkboxlist9, x.Checkboxlist13, x.Checkboxlist14).Where(n => n.SOLUONG != 0).ToList();
              
                BAOCAO_TONGHOP_CT_XUAT_KHUYENMAI_KHACHHANG rpt = new BAOCAO_TONGHOP_CT_XUAT_KHUYENMAI_KHACHHANG();
                var data0 = new List<DULIEUBAOCAO15>();
                data0 = datakm.GroupBy(n => new { n.MAKH, n.MAKM }).Select(n => new DULIEUBAOCAO15 { TIEN = n.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)), MAHH = n.Key.MAKH, TENHH = n.FirstOrDefault().DONVI, MAQUAY = n.Key.MAKM }).ToList();
                rpt.Load();
                rpt.SetDataSource(data0);
                rpt.SetParameterValue("tungay", x.tungay1);
                rpt.SetParameterValue("denngay", x.denngay1);
                string loc = "";
                if (x.Checkboxlist8 != null)
                {
                    var kh = GetTenKhachHang(x.Checkboxlist1, x.Checkboxlist8).Select(cl => (cl.MAKH + " - " + cl.DONVI)).ToList();
                    loc = "<b>Khách hàng</b> : " + String.Join(", ", kh.ToArray());
                }
                rpt.SetParameterValue("LOC", loc);

                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
            else if (x.loaibaocao == 28)
            {
                CR_CANDOI_CONGNO_TATCA_1 rpt = new CR_CANDOI_CONGNO_TATCA_1();
                var data0 = DATABAOCAO28(x.Checkboxlist1, x.nam, x.Checkboxlist2, x.Checkboxlist3, x.Checkboxlist4, x.Checkboxlist5, x.Checkboxlist11, x.Checkboxlist6, x.Checkboxlist8, x.Checkboxlist10, x.Checkboxlist12, x.maphanloai.Split(',').ToList(), x.Checkboxlist9, x.Checkboxlist14);
                if (!data0.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                rpt.Load();
                rpt.SetDataSource(data0);
                rpt.SetParameterValue("SONAM", x.nam);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
            //else if (x.loaibaocao == 29)
            //{
            //    BAOCAO_TONGHOP__KHACHHANG_VIP rpt = new BAOCAO_TONGHOP__KHACHHANG_VIP();
            //    var data0 = DATABAOCAO29(x.Checkboxlist1, x.Checkboxlist2, x.Checkboxlist3, x.Checkboxlist4, x.Checkboxlist5, x.Checkboxlist11, x.Checkboxlist6, x.Checkboxlist8, x.Checkboxlist10, x.Checkboxlist12, x.maphanloai.Split(',').ToList(), x.Checkboxlist9, x.Checkboxlist14, x.qui, x.nam);
            //    if (!data0.Any())
            //    {
            //        var myMess = new
            //        {
            //            Message = "Không tìm thấy dữ liệu !",
            //        };
            //        return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
            //    }
            //    rpt.Load();
            //    rpt.SetDataSource(data0);
            //    rpt.SetParameterValue("qui", x.qui);
            //    rpt.SetParameterValue("nam", x.nam);
            //    Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            //    rpt.Close();
            //    rpt.Dispose();
            //    GC.Collect();
            //    return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            //}
            else if (x.loaibaocao == 29)
            {
                BAOCAO_TONGHOP_CT_XUAT_KHUVUC_MAKH_TOP_2022 rpt = new BAOCAO_TONGHOP_CT_XUAT_KHUVUC_MAKH_TOP_2022();
                var data0 = DATABAOCAO29_2022(x.Checkboxlist1, x.Checkboxlist2, x.Checkboxlist3, x.Checkboxlist4, x.Checkboxlist5, x.Checkboxlist11, x.Checkboxlist6, x.Checkboxlist8, x.Checkboxlist10, x.Checkboxlist12, x.maphanloai.Split(',').ToList(), x.Checkboxlist9, x.Checkboxlist14, tungay, denngay, x.top);
                if (!data0.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                rpt.Load();
                rpt.SetDataSource(data0);
                rpt.SetParameterValue("tungay", x.tungay1);
                rpt.SetParameterValue("denngay", x.denngay1);
                rpt.SetParameterValue("top", x.top);
                rpt.SetParameterValue("LANG", x.lang);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
            var data = DATABAOCAO(x.maphanloai.Split(',').ToList(), x.Checkboxlist1, tungay, denngay, x.Checkboxlist2, x.Checkboxlist3, x.Checkboxlist4, x.Checkboxlist5, x.Checkboxlist11, x.Checkboxlist6, x.Checkboxlist10, x.Checkboxlist12, x.Checkboxlist8, x.Checkboxlist9, x.Checkboxlist13, x.Checkboxlist14).Where(n => n.SOLUONG != 0).ToList();
            if (!data.Any())
            {
                var myMess = new
                {
                    Message = "Không tìm thấy dữ liệu !",
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
            }
            if (x.loctheo == 0 && x.loaibaocao != 12)
            {
                BAOCAODOANHSOBANTHEO_KH rpt = new BAOCAODOANHSOBANTHEO_KH();
                var data1 = data.GroupBy(n => new { n.SOHD, n.TENDVBC }).Select(cl => new BAOCAOHD8 { TIENCK = (double)cl.Sum(z => z.TIENCK), TIENVAT = (double)cl.Sum(z => z.tienvat), MATDV = cl.First().MATDV, SOHD = cl.Key.SOHD, DONVI = cl.First().DONVI, MAKH = cl.First().MAKH, NGAYLAPHD = cl.First().NGAY, tendvbc = cl.Key.TENDVBC, TONGTIEN_CT_HOADON = (double)cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) }).OrderBy(n => n.MAKH).ThenBy(n => n.SOHD).ToList();
                if (!data1.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                rpt.Load();
                rpt.SetDataSource(data1);
                rpt.SetParameterValue("tungay", x.tungay1);
                rpt.SetParameterValue("denngay", x.denngay1);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }

            if (x.loaibaocao == 8)
            {

                BAOCAO_TONGHOP_CT_XUAT_KHUVUC rpt = new BAOCAO_TONGHOP_CT_XUAT_KHUVUC();
                if (x.loctheo == 1)
                {
                    var data1 = new List<BAOCAO8>();
                    if (x.tienck == "1")
                    {
                        data1 = data.OrderByDescending(n => n.DONGIA).GroupBy(n => n.MAHH).Select(cl => new BAOCAO8 { dvt = cl.First().DVT.ToUpper(), mahh = cl.Key, NHOM = cl.First().NHOM, soluong = (int)cl.Sum(cx => cx.SOLUONG), tenhh = cl.First().TENHH, tien = (double)(cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) - cl.Sum(z => z.TIENCK)) }).ToList();
                    }
                    else
                    {
                        data1 = data.OrderByDescending(n => n.DONGIA).GroupBy(n => n.MAHH).Select(cl => new BAOCAO8 { dvt = cl.First().DVT.ToUpper(), mahh = cl.Key, NHOM = cl.First().NHOM, soluong = (int)cl.Sum(cx => cx.SOLUONG), tenhh = cl.First().TENHH, tien = (double)cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) }).ToList();
                    }

                    rpt.Load();
                    rpt.SetDataSource(data1.OrderBy(n => n.mahh));
                    rpt.SetParameterValue("tungay", x.tungay1);
                    rpt.SetParameterValue("denngay", x.denngay1);
                    var loc = "";
                    if (x.Checkboxlist9 != null)
                    {
                        loc = loc + "CTKM : " + string.Join(",", x.Checkboxlist9.ToArray()) + ".";
                    }
                    if (x.Checkboxlist14 != null)
                    {
                        loc = loc + "\nCTHT : " + string.Join(",", x.Checkboxlist14.ToArray()) + ".";
                    }
                    rpt.SetParameterValue("LOC", loc);
                    rpt.SetParameterValue("LANG", x.lang);
                    Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    rpt.Close();
                    rpt.Dispose();
                    GC.Collect();
                    return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                }
            }
            if (x.loaibaocao == 14)
            {
                BAOCAO_TONGHOP_CT_XUAT_KHUVUC_MAHH_TOP rpt = new BAOCAO_TONGHOP_CT_XUAT_KHUVUC_MAHH_TOP();
                if (x.loctheo == 1)
                {
                    var data1 = new List<BAOCAO8>();
                    if (x.tienck == "1")
                    {
                        data1 = data.OrderByDescending(n => n.DONGIA).GroupBy(n => n.MAHH).Select(cl => new BAOCAO8 { dvt = cl.First().DVT.ToUpper(), mahh = cl.Key, soluong = (int)cl.Sum(cx => cx.SOLUONG), tenhh = cl.First().TENHH, tien = (double)(cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) - cl.Sum(z => z.TIENCK)) }).ToList();
                    }
                    else
                    {
                        data1 = data.OrderByDescending(n => n.DONGIA).GroupBy(n => n.MAHH).Select(cl => new BAOCAO8 { dvt = cl.First().DVT.ToUpper(), mahh = cl.Key, soluong = (int)cl.Sum(cx => cx.SOLUONG), tenhh = cl.First().TENHH, tien = (double)cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) }).ToList();
                    }
                    rpt.Load();
                    rpt.SetDataSource(data1.OrderBy(n => n.mahh));
                    rpt.SetParameterValue("tungay", x.tungay1);
                    rpt.SetParameterValue("denngay", x.denngay1);
                    rpt.SetParameterValue("top", x.top);
                    var loc = "";
                    if (x.Checkboxlist9 != null)
                    {
                        loc = loc + "CTKM : " + string.Join(",", x.Checkboxlist9.ToArray()) + ".";
                    }
                    if (x.Checkboxlist14 != null)
                    {
                        loc = loc + "\nCTHT : " + string.Join(",", x.Checkboxlist14.ToArray()) + ".";
                    }
                    rpt.SetParameterValue("LOC", loc);
                    rpt.SetParameterValue("LANG", x.lang);
                    Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    rpt.Close();
                    rpt.Dispose();
                    GC.Collect();
                    return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                }
            }
        
            else if (x.loaibaocao == 9)
            {
                BAOCAOTONGTOP_KHACHHANG_CHIETKHAU rpt = new BAOCAOTONGTOP_KHACHHANG_CHIETKHAU();
                var data2 = new List<BAOCAO9>();
                data2 = data.OrderByDescending(n => n.DONGIA).GroupBy(n => n.MAKH).Select(cl => new BAOCAO9 { MATDV = cl.First().MATDV, DONVI = cl.First().DONVI, MAKH = cl.First().MAKH, MATINH = cl.First().MATINH, TONGTIEN_CT_HOADON = (double)(cl.Sum(cx => Math.Round(cx.SOLUONG * cx.DONGIA, 0, MidpointRounding.AwayFromZero))), THANHTIEN = (double)(cl.Sum(cx => Math.Round(cx.SOLUONG * cx.DONGIA, 0, MidpointRounding.AwayFromZero)) - cl.Sum(cx => cx.TIENCK)), TIENCK = (double)cl.Sum(cx => cx.TIENCK) }).ToList();
                rpt.Load();
                rpt.SetDataSource(data2.OrderBy(n => n.MAKH));
                rpt.SetParameterValue("tungay", x.tungay1);
                rpt.SetParameterValue("denngay", x.denngay1);
                var loc = "";
                if (x.Checkboxlist9 != null)
                {
                    loc = loc + "CTKM : " + string.Join(",", x.Checkboxlist9.ToArray()) + ".";
                }
                if (x.Checkboxlist14 != null)
                {
                    loc = loc + "\nCTHT : " + string.Join(",", x.Checkboxlist14.ToArray()) + ".";
                }
                rpt.SetParameterValue("LOC", loc);
                rpt.SetParameterValue("LANG", x.lang);
               

                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
            else if (x.loaibaocao == 30)
            {
                BAOCAOTONGTOP_KHACHHANG_DIEMTICHLUY rpt = new BAOCAOTONGTOP_KHACHHANG_DIEMTICHLUY();
                string mactkm = "";
                if (x.Checkboxlist9 != null && x.Checkboxlist14 == null)
                {
                    mactkm = x.Checkboxlist9.FirstOrDefault();
                }
                else if (x.Checkboxlist9 == null && x.Checkboxlist14 != null)
                {
                    mactkm = x.Checkboxlist14.FirstOrDefault();
                }
                else if (x.Checkboxlist9 != null && x.Checkboxlist14 != null)
                {
                    mactkm = x.Checkboxlist14.FirstOrDefault();
                }
                if (x.tienck == "1")
                {
                    data = data.OrderByDescending(n => n.DONGIA).GroupBy(n => new { n.MAKH, n.MAHH }).Select(cl => new DULIEUBAOCAO { MATDV = cl.First().MATDV, DONVI = cl.First().DONVI, MAKH = cl.Key.MAKH, MATINH = cl.First().MATINH, TIEN = cl.Sum(cx => Math.Round(cx.SOLUONG * cx.DONGIA, 0, MidpointRounding.AwayFromZero)) - cl.Sum(cx => cx.TIENCK), SOLUONG = cl.Sum(n => n.SOLUONG), MAHH = cl.Key.MAHH }).ToList();
                }
                else
                {
                    data = data.OrderByDescending(n => n.DONGIA).GroupBy(n => new { n.MAKH, n.MAHH }).Select(cl => new DULIEUBAOCAO { MATDV = cl.First().MATDV, DONVI = cl.First().DONVI, MAKH = cl.Key.MAKH, MATINH = cl.First().MATINH, TIEN = cl.Sum(cx => Math.Round(cx.SOLUONG * cx.DONGIA, 0, MidpointRounding.AwayFromZero)), SOLUONG = cl.Sum(n => n.SOLUONG), MAHH = cl.Key.MAHH }).ToList();
                }
                foreach (var i in data)
                {
                    try
                    {
                        var diem = DATATH1.TBL_DANHMUCHANGHOATICHDIEM.SingleOrDefault(n => n.MACT == mactkm && n.MAHH == i.MAHH);
                        i.TICHDIEM = (int)((Convert.ToInt32(i.SOLUONG) / diem.SOLUONG) * diem.DIEM);
                    }
                    catch (Exception)
                    {
                        var tv = DATATH1.TBL_DANHMUCHANGHOATICHDIEM.Where(n => n.MACT == mactkm && n.MAHH == i.MAHH).ToList();
                        if (tv.Any())
                        {
                            if ((Convert.ToInt32(i.SOLUONG) % tv.LastOrDefault().SOLUONG) % tv.FirstOrDefault().SOLUONG == 0)
                            {
                                var diem = (Convert.ToInt32(i.SOLUONG) / tv.LastOrDefault().SOLUONG) * tv.LastOrDefault().DIEM + (Convert.ToInt32(i.SOLUONG) % tv.LastOrDefault().SOLUONG) / tv.FirstOrDefault().SOLUONG * tv.FirstOrDefault().DIEM;
                                i.TICHDIEM = (int)diem;
                            }
                            else if (Convert.ToInt32(i.SOLUONG) % tv.FirstOrDefault().SOLUONG == 0)
                            {
                                var diem = Convert.ToInt32(i.SOLUONG) / tv.FirstOrDefault().HOP * tv.FirstOrDefault().DIEM;
                                i.TICHDIEM = (int)diem;
                            }
                            else
                            {
                                var diem = (Convert.ToInt32(i.SOLUONG) / tv.LastOrDefault().SOLUONG) * tv.LastOrDefault().DIEM + (Convert.ToInt32(i.SOLUONG) % tv.LastOrDefault().SOLUONG) / tv.FirstOrDefault().SOLUONG * tv.FirstOrDefault().DIEM;
                                i.TICHDIEM = (int)diem;
                            }
                        }
                        else
                        {
                            i.TICHDIEM = 0;
                        }
                    }
                }
                var data2 = data.OrderByDescending(n => n.DONGIA).GroupBy(n => n.MAKH).Select(cl => new BAOCAO9 { MATDV = cl.First().MATDV, DONVI = cl.First().DONVI, MAKH = cl.Key, MATINH = cl.First().MATINH, TONGTIEN_CT_HOADON = (double)cl.Sum(cx => cx.TIEN), TIENVAT = cl.Sum(cx => cx.TICHDIEM) }).ToList();
                rpt.Load();
                rpt.SetDataSource(data2.OrderBy(n => n.MAKH));
                rpt.SetParameterValue("tungay", x.tungay1);
                rpt.SetParameterValue("denngay", x.denngay1);
                rpt.SetParameterValue("LOC", "Chương trình tích điểm : " + mactkm);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
            else if (x.loaibaocao == 10)
            {
                BAOCAO_TONGHOP_CT_XUAT_MAKH_MAHH rpt = new BAOCAO_TONGHOP_CT_XUAT_MAKH_MAHH();
                if (x.loctheo == 1)
                {
                    var data1 = new List<BAOCAO10>();
                    if (x.tienck == "1")
                    {
                        data1 = data.GroupBy(n => new { n.MAKH, n.MAHH }).Select(cl => new BAOCAO10 { MAQUAY = cl.First().DONVI, dvt = cl.First().DVT.ToUpper(), mahh = cl.Key.MAHH, mapl = cl.Key.MAKH, NHOM = cl.First().MATINH, soluong = (Int32)cl.Sum(cx => cx.SOLUONG), tenhh = cl.First().TENHH, tien = (double)(cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) - cl.Sum(z => z.TIENCK)) }).ToList();
                    }
                    else
                    {
                        data1 = data.GroupBy(n => new { n.MAKH, n.MAHH }).Select(cl => new BAOCAO10 { MAQUAY = cl.First().DONVI, dvt = cl.First().DVT.ToUpper(), mahh = cl.Key.MAHH, mapl = cl.Key.MAKH, NHOM = cl.First().MATINH, soluong = (Int32)cl.Sum(cx => cx.SOLUONG), tenhh = cl.First().TENHH, tien = (double)cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) }).ToList();
                    }
                    rpt.Load();
                    rpt.SetDataSource(data1.OrderBy(n => n.mapl));
                    rpt.SetParameterValue("tungay", x.tungay1);
                    rpt.SetParameterValue("denngay", x.denngay1);
                    Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    rpt.Close();
                    rpt.Dispose();
                    GC.Collect();
                    return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                }
            }
            else if (x.loaibaocao == 31)
            {
                string mactkm = "";
                if (x.Checkboxlist9 != null && x.Checkboxlist14 == null)
                {
                    mactkm = x.Checkboxlist9.FirstOrDefault();
                }
                else if (x.Checkboxlist9 == null && x.Checkboxlist14 != null)
                {
                    mactkm = x.Checkboxlist14.FirstOrDefault();
                }
                else if (x.Checkboxlist9 != null && x.Checkboxlist14 != null)
                {
                    mactkm = x.Checkboxlist14.FirstOrDefault();
                }
                BAOCAO_TONGHOP_CT_XUAT_MAKH_MAHH_DIEMTICHLUY rpt = new BAOCAO_TONGHOP_CT_XUAT_MAKH_MAHH_DIEMTICHLUY();
                if (x.loctheo == 1)
                {
                    if (x.tienck == "1")
                    {
                        data = data.GroupBy(n => new { n.MAKH, n.MAHH }).Select(cl => new DULIEUBAOCAO { DONVI = cl.First().DONVI, DVT = cl.First().DVT.ToUpper(), MAHH = cl.Key.MAHH, MAKH = cl.Key.MAKH, MATINH = cl.First().MATINH, SOLUONG = cl.Sum(cx => cx.SOLUONG), TENHH = cl.First().TENHH, TIEN = cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) - cl.Sum(z => z.TIENCK) }).ToList();
                    }
                    else
                    {
                        data = data.GroupBy(n => new { n.MAKH, n.MAHH }).Select(cl => new DULIEUBAOCAO { DONVI = cl.First().DONVI, DVT = cl.First().DVT.ToUpper(), MAHH = cl.Key.MAHH, MAKH = cl.Key.MAKH, MATINH = cl.First().MATINH, SOLUONG = cl.Sum(cx => cx.SOLUONG), TENHH = cl.First().TENHH, TIEN = cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) }).ToList();
                    }
                    var data1 = new List<BAOCAO10>();
                    foreach (var i in data)
                    {
                        try
                        {
                            var diem = DATATH1.TBL_DANHMUCHANGHOATICHDIEM.SingleOrDefault(n => n.MACT == mactkm && n.MAHH == i.MAHH);
                            i.TICHDIEM = (int)((Convert.ToInt32(i.SOLUONG) / diem.SOLUONG) * diem.DIEM);
                        }
                        catch (Exception)
                        {
                            var tv = DATATH1.TBL_DANHMUCHANGHOATICHDIEM.Where(n => n.MACT == mactkm && n.MAHH == i.MAHH).ToList();
                            if (tv.Any())
                            {
                                if ((Convert.ToInt32(i.SOLUONG) % tv.LastOrDefault().SOLUONG) % tv.FirstOrDefault().SOLUONG == 0)
                                {
                                    var diem = (Convert.ToInt32(i.SOLUONG) / tv.LastOrDefault().SOLUONG) * tv.LastOrDefault().DIEM + (Convert.ToInt32(i.SOLUONG) % tv.LastOrDefault().SOLUONG) / tv.FirstOrDefault().SOLUONG * tv.FirstOrDefault().DIEM;
                                    i.TICHDIEM = (int)diem;
                                }
                                else if (Convert.ToInt32(i.SOLUONG) % tv.FirstOrDefault().SOLUONG == 0)
                                {
                                    var diem = Convert.ToInt32(i.SOLUONG) / tv.FirstOrDefault().HOP * tv.FirstOrDefault().DIEM;
                                    i.TICHDIEM = (int)diem;
                                }
                                else
                                {
                                    var diem = (Convert.ToInt32(i.SOLUONG) / tv.LastOrDefault().SOLUONG) * tv.LastOrDefault().DIEM + (Convert.ToInt32(i.SOLUONG) % tv.LastOrDefault().SOLUONG) / tv.FirstOrDefault().SOLUONG * tv.FirstOrDefault().DIEM;
                                    i.TICHDIEM = (int)diem;
                                }
                            }
                            else
                            {
                                i.TICHDIEM = 0;
                            }
                        }
                        data1.Add(new BAOCAO10 { MAQUAY = i.DONVI, dvt = i.DVT, mahh = i.MAHH, mapl = i.MAKH, NHOM = i.MATINH, soluong = (Int32)i.SOLUONG, tenhh = i.TENHH, tien = (double)(i.TIEN - i.TIENCK), THANG = i.TICHDIEM });

                    }
                    rpt.Load();
                    rpt.SetDataSource(data1.OrderBy(n => n.mapl));
                    rpt.SetParameterValue("tungay", x.tungay1);
                    rpt.SetParameterValue("denngay", x.denngay1);
                    rpt.SetParameterValue("LOC", "Chương trình tích điểm : " + mactkm);
                    Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    rpt.Close();
                    rpt.Dispose();
                    GC.Collect();
                    return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                }
            }
            else if (x.loaibaocao == 5)
            {
                BAOCAO_TONGHOP_CT_XUAT_KHUVUC_MIEN_CHITIET_TINH_MOI rpt = new BAOCAO_TONGHOP_CT_XUAT_KHUVUC_MIEN_CHITIET_TINH_MOI();
                var data0 = new List<DULIEUBAOCAO5>();
                data0 = data.GroupBy(n => new { n.MATINH, n.TENDVBC }).Select(n => new DULIEUBAOCAO5() { dongia = n.Sum(cl => cl.TIENCK), tien = (n.Sum(cl => Math.Round(cl.SOLUONG * cl.DONGIA, 0, MidpointRounding.AwayFromZero)) - n.Sum(cl => cl.TIENCK)), soluong = n.Sum(cl => Math.Round(cl.SOLUONG * cl.DONGIA, 0, MidpointRounding.AwayFromZero)), MAQUAY = n.Key.MATINH, tenhh = n.Key.TENDVBC, mahh = n.First().MIEN, TUTHANG = x.tungay1, THANG = x.denngay1 }).ToList();
                foreach (var i in data0)
                {
                    if (DATATH1.TBL_DANHMUCTINH.SingleOrDefault(n => n.matinh == i.MAQUAY) != null)
                    {
                        i.NHOM = DATATH1.TBL_DANHMUCTINH.SingleOrDefault(n => n.matinh == i.MAQUAY).tentinh;
                    }
                }
                //data0 = data0.GroupBy(n => new { n.chuky1, n.TENDVBC }).Select(cl => new DULIEUBAOCAO0 { chuky1 = cl.First().chuky1, TENDVBC = cl.First().TENDVBC, TIENCK = cl.Sum(c => c.TIENCK), TONGTIEN_CT_HOADON = cl.Sum(c => c.TONGTIEN_CT_HOADON), thangdau = dataview.tungay1, nam = dataview.denngay1 }).ToList();
                if (!data0.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                string LOC = ((x.lang == "vi") ? "Mã phân loại : " : " Classification code : ") + x.maphanloai + ". " + ((x.Checkboxlist4 != null) ? (((x.lang == "vi") ? "Nhóm hàng : " : "Product groups : ") + string.Join(",", x.Checkboxlist4.ToArray())) : "");
                if (x.Checkboxlist2 != "ALL")
                {
                    LOC = LOC + ((x.lang == "vi") ? ". Phân loại khách hàng : " : ". Customer type") + x.Checkboxlist2;
                }
                if (x.Checkboxlist3 != null)
                {
                    LOC = LOC + ((x.lang == "vi") ? ". Phân loại chi tiết khách hàng : " : ". Customer detail type : ") + string.Join(",", x.Checkboxlist3.ToArray());
                }
                if (x.Checkboxlist6 != null)
                {
                    LOC = LOC + ((x.lang == "vi") ? ". Khu vực : " : ". Area") + string.Join(",", x.Checkboxlist6.ToArray());
                }
                rpt.Load();
                rpt.SetDataSource(data0);
                rpt.SetParameterValue("LOC", LOC);
                rpt.SetParameterValue("LANG", x.lang);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });

            }
            else if (x.loaibaocao == 11)
            {
                BAOCAO_TONGHOP_CT_XUAT_KHUVUC_MAHH rpt = new BAOCAO_TONGHOP_CT_XUAT_KHUVUC_MAHH();
                if (x.loctheo == 1)
                {
                    if (x.tienck == "1")
                    {
                        data = data.GroupBy(n => new { n.MAHH, n.MATINH }).Select(cl => new DULIEUBAOCAO { MATINH = cl.Key.MATINH, TENDVBC = cl.First().TENDVBC, MIEN = cl.First().MIEN, MAHH = cl.Key.MAHH, SOLUONG = cl.Sum(cx => cx.SOLUONG), TENHH = cl.First().TENHH, TIEN = cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) - cl.Sum(z => z.TIENCK) }).ToList();
                    }
                    else
                    {
                        data = data.GroupBy(n => new { n.MAHH, n.MATINH }).Select(cl => new DULIEUBAOCAO { MATINH = cl.Key.MATINH, TENDVBC = cl.First().TENDVBC, MIEN = cl.First().MIEN, MAHH = cl.Key.MAHH, SOLUONG = cl.Sum(cx => cx.SOLUONG), TENHH = cl.First().TENHH, TIEN = cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) }).ToList();
                    }
                    var data1 = new List<BAOCAO10>();

                    foreach (var i in data)
                    {
                        try
                        {
                            data1.Add(new BAOCAO10 { MAQUAY = db2.KhuVucs.SingleOrDefault(n => n.MaKhuVuc == i.MATINH).TenKhuVuc, dvt = i.MIEN, mahh = i.MAHH, mapl = i.MATINH, NHOM = "", soluong = (Int32)i.SOLUONG, tenhh = i.TENHH, tien = (double)(i.TIEN) });
                        }
                        catch (Exception)
                        {
                            data1.Add(new BAOCAO10 { MAQUAY = "", dvt = i.MIEN, mahh = i.MAHH, mapl = i.MATINH, NHOM = "", soluong = (Int32)i.SOLUONG, tenhh = i.TENHH, tien = (double)(i.TIEN) });
                        }
                    }

                    rpt.Load();
                    rpt.SetDataSource(data1.OrderBy(n => n.mapl));
                    rpt.SetParameterValue("tungay", x.tungay1);
                    rpt.SetParameterValue("denngay", x.denngay1);
                    Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    rpt.Close();
                    rpt.Dispose();
                    GC.Collect();
                    return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                }
            }
            else if (x.loaibaocao == 12)
            {
                BAOCAO_TONGHOP_CT_XUAT_MAKH_MAHH_SOHD rpt = new BAOCAO_TONGHOP_CT_XUAT_MAKH_MAHH_SOHD();
                var data1 = new List<BAOCAO10>();
                if (x.tienck == "1")
                {
                    data1 = data.GroupBy(n => new { n.SOHD, n.MAHH }).Select(cl => new BAOCAO10 { NHOM = cl.Key.SOHD, MAQUAY = cl.First().DONVI, dvt = cl.First().DVT.ToUpper(), mahh = cl.Key.MAHH, mapl = cl.First().MAKH, NAM = cl.First().NGAY.ToString("dd/MM/yyyy"), soluong = (Int32)cl.Sum(cx => cx.SOLUONG), tenhh = cl.First().TENHH, tien = (double)(cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) - cl.Sum(z => z.TIENCK)) }).ToList();
                }
                else
                {
                    data1 = data.GroupBy(n => new { n.SOHD, n.MAHH }).Select(cl => new BAOCAO10 { NHOM = cl.Key.SOHD, MAQUAY = cl.First().DONVI, dvt = cl.First().DVT.ToUpper(), mahh = cl.Key.MAHH, mapl = cl.First().MAKH, NAM = cl.First().NGAY.ToString("dd/MM/yyyy"), soluong = (Int32)cl.Sum(cx => cx.SOLUONG), tenhh = cl.First().TENHH, tien = (double)cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) }).ToList();
                }
                rpt.Load();
                rpt.SetDataSource(data1);
                rpt.SetParameterValue("tungay", x.tungay1);
                rpt.SetParameterValue("denngay", x.denngay1);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
         
            else if (x.loaibaocao == 32)
            {
                BAOCAO_TONGHOP_CT_XUAT_MAKH_MAHH_SOHD_DIEMTICHLUY rpt = new BAOCAO_TONGHOP_CT_XUAT_MAKH_MAHH_SOHD_DIEMTICHLUY();
                string mactkm = "";
                if (x.Checkboxlist9 != null && x.Checkboxlist14 == null)
                {
                    mactkm = x.Checkboxlist9.FirstOrDefault();
                }
                else if (x.Checkboxlist9 == null && x.Checkboxlist14 != null)
                {
                    mactkm = x.Checkboxlist14.FirstOrDefault();
                }
                else if (x.Checkboxlist9 != null && x.Checkboxlist14 != null)
                {
                    mactkm = x.Checkboxlist14.FirstOrDefault();
                }
                if (x.tienck == "1")
                {
                    data = data.GroupBy(n => new { n.SOHD, n.MAHH }).Select(cl => new DULIEUBAOCAO { SOHD = cl.First().SOHD, DONVI = cl.First().DONVI, DVT = cl.First().DVT.ToUpper(), MAHH = cl.First().MAHH, MAKH = cl.First().MAKH, NGAY = cl.First().NGAY, SOLUONG = cl.Sum(cx => cx.SOLUONG), TENHH = cl.First().TENHH, TIEN = cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) - cl.Sum(z => z.TIENCK) }).ToList();
                }
                else
                {
                    data = data.GroupBy(n => new { n.SOHD, n.MAHH }).Select(cl => new DULIEUBAOCAO { SOHD = cl.First().SOHD, DONVI = cl.First().DONVI, DVT = cl.First().DVT.ToUpper(), MAHH = cl.First().MAHH, MAKH = cl.First().MAKH, NGAY = cl.First().NGAY, SOLUONG = cl.Sum(cx => cx.SOLUONG), TENHH = cl.First().TENHH, TIEN = cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) }).ToList();
                }
                var data1 = new List<BAOCAO10>();
                foreach (var i in data.OrderBy(n => n.MAKH).ThenBy(n => n.NGAY))
                {
                    try
                    {
                        var diem = DATATH1.TBL_DANHMUCHANGHOATICHDIEM.SingleOrDefault(n => n.MACT == mactkm && n.MAHH == i.MAHH);
                        i.TICHDIEM = (int)((Convert.ToInt32(i.SOLUONG) / diem.SOLUONG) * diem.DIEM);
                    }
                    catch (Exception)
                    {
                        var tv = DATATH1.TBL_DANHMUCHANGHOATICHDIEM.Where(n => n.MACT == mactkm && n.MAHH == i.MAHH).ToList();
                        if (tv.Any())
                        {
                            if ((Convert.ToInt32(i.SOLUONG) % tv.LastOrDefault().SOLUONG) % tv.FirstOrDefault().SOLUONG == 0)
                            {
                                var diem = (Convert.ToInt32(i.SOLUONG) / tv.LastOrDefault().SOLUONG) * tv.LastOrDefault().DIEM + (Convert.ToInt32(i.SOLUONG) % tv.LastOrDefault().SOLUONG) / tv.FirstOrDefault().SOLUONG * tv.FirstOrDefault().DIEM;
                                i.TICHDIEM = (int)diem;
                            }
                            else if (Convert.ToInt32(i.SOLUONG) % tv.FirstOrDefault().SOLUONG == 0)
                            {
                                var diem = Convert.ToInt32(i.SOLUONG) / tv.FirstOrDefault().HOP * tv.FirstOrDefault().DIEM;
                                i.TICHDIEM = (int)diem;
                            }
                            else
                            {
                                var diem = (Convert.ToInt32(i.SOLUONG) / tv.LastOrDefault().SOLUONG) * tv.LastOrDefault().DIEM + (Convert.ToInt32(i.SOLUONG) % tv.LastOrDefault().SOLUONG) / tv.FirstOrDefault().SOLUONG * tv.FirstOrDefault().DIEM;
                                i.TICHDIEM = (int)diem;
                            }
                        }
                        else
                        {
                            i.TICHDIEM = 0;
                        }
                    }
                    data1.Add(new BAOCAO10 { MAQUAY = i.DONVI, NAM = i.NGAY.ToString("dd/MM/yyyy"), dvt = i.DVT, mahh = i.MAHH, mapl = i.MAKH, NHOM = i.SOHD, soluong = (Int32)i.SOLUONG, tenhh = i.TENHH, tien = (double)(i.TIEN - i.TIENCK), THANG = i.TICHDIEM });
                }
                if (!data1.Any())
                {
                    var myMess = new
                    {
                        Message = "Không tìm thấy dữ liệu !",
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
                }
                rpt.Load();
                rpt.SetDataSource(data1);
                rpt.SetParameterValue("tungay", x.tungay1);
                rpt.SetParameterValue("denngay", x.denngay1);
                rpt.SetParameterValue("LOC", "Chương trình tích điểm : " + mactkm);
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
                return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
            }
            else if (x.loaibaocao == 40)
            {
                BAOCAODOANHSOBANTHEO_KH_TONGHOP_MIEN_MANV rpt = new BAOCAODOANHSOBANTHEO_KH_TONGHOP_MIEN_MANV();
                if (x.loctheo == 1)
                {
                    var data1 = new List<DULIEUBAOCAO40>();

                    data1 = data.GroupBy(n => new { n.MATDV }).Select(cl => new DULIEUBAOCAO40 { SOHD = cl.First().MANV, MAKH = cl.Key.MATDV, DONVI = cl.First().TENTDV, TONGTIEN = cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)), THANHTIEN = (cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) - cl.Sum(z => z.TIENCK)), TIENCK = (decimal)(500000.0 * Math.Floor(((double)(cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) - cl.Sum(z => z.TIENCK)) / 3000000.0))) }).ToList();

                    rpt.Load();
                    rpt.SetDataSource(data1);
                    rpt.SetParameterValue("tungay", x.tungay1);
                    rpt.SetParameterValue("denngay", x.denngay1);
                    var noidung = "Đơn vị: " + String.Join(", ", x.Checkboxlist1.ToArray()) + ((x.Checkboxlist9 != null) ? (", Mã CTKM: " + String.Join(", ", x.Checkboxlist9.ToArray())) : "") + ((x.Checkboxlist14 != null) ? (", Mã CTKM: " + String.Join(", ", x.Checkboxlist14.ToArray())) : "");
                    rpt.SetParameterValue("LOC", noidung);
                    rpt.SetParameterValue("LANG", x.lang);
                    Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    rpt.Close();
                    rpt.Dispose();
                    GC.Collect();
                    return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                }
            }
            else if (x.loaibaocao == 6)
            {
                BAOCAO_TONGHOP_CT_XUAT_TDV_CHITIET rpt = new BAOCAO_TONGHOP_CT_XUAT_TDV_CHITIET();
                if (x.loctheo == 1)
                {
                    var data1 = new List<BAOCAO10>();
                    if (x.tienck == "1")
                    {
                        data1 = data.GroupBy(n => new { n.MATDV, n.MATINH }).Select(cl => new BAOCAO10 { tenhh = cl.First().TENTDV, MAQUAY = cl.Key.MATDV, mapl = cl.Key.MATINH, soluong = (Int32)cl.Sum(cx => cx.SOLUONG), mahh = cl.First().TENDVBC, tien = (double)(cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) - cl.Sum(z => z.TIENCK)) }).ToList();
                    }
                    else
                    {
                        data1 = data.GroupBy(n => new { n.MATDV, n.MATINH }).Select(cl => new BAOCAO10 { tenhh = cl.First().TENTDV, MAQUAY = cl.Key.MATDV, mapl = cl.Key.MATINH, soluong = (Int32)cl.Sum(cx => cx.SOLUONG), mahh = cl.First().TENDVBC, tien = (double)cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) }).ToList();
                    }
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    rpt.SetParameterValue("tungay", x.tungay1);
                    rpt.SetParameterValue("denngay", x.denngay1);
                    var noidung = "Đơn vị: " + String.Join(", ", x.Checkboxlist1.ToArray()) + ((x.Checkboxlist9 != null) ? (", Mã CTKM: " + String.Join(", ", x.Checkboxlist9.ToArray())) : "");
                    rpt.SetParameterValue("LOC", noidung);
                    rpt.SetParameterValue("LANG", x.lang);
                    Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    rpt.Close();
                    rpt.Dispose();
                    GC.Collect();
                    return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                }
            }
          
            else if (x.loaibaocao == 22)
            {
                BAOCAO_TONGHOP_CT_XUAT_MAHH_MAKH rpt = new BAOCAO_TONGHOP_CT_XUAT_MAHH_MAKH();
                if (x.loctheo == 1)
                {
                    var data1 = new List<BAOCAO10>();
                    if (x.tienck == "1")
                    {
                        data1 = data.GroupBy(n => new { n.MAKH, n.MAHH }).Select(cl => new BAOCAO10 { MAQUAY = cl.First().DONVI, dvt = cl.First().DVT.ToUpper(), mahh = cl.Key.MAHH, mapl = cl.Key.MAKH, soluong = (Int32)cl.Sum(cx => cx.SOLUONG), tenhh = cl.First().TENHH, tien = (double)(cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) - cl.Sum(z => z.TIENCK)) }).ToList();
                    }
                    else
                    {
                        data1 = data.GroupBy(n => new { n.MAKH, n.MAHH }).Select(cl => new BAOCAO10 { MAQUAY = cl.First().DONVI, dvt = cl.First().DVT.ToUpper(), mahh = cl.Key.MAHH, mapl = cl.Key.MAKH, soluong = (Int32)cl.Sum(cx => cx.SOLUONG), tenhh = cl.First().TENHH, tien = (double)cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)) }).ToList();
                    }
                    rpt.Load();
                    rpt.SetDataSource(data1.OrderBy(n => n.mapl));
                    rpt.SetParameterValue("tungay", x.tungay1);
                    rpt.SetParameterValue("denngay", x.denngay1);
                    Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    rpt.Close();
                    rpt.Dispose();
                    GC.Collect();
                    return Request.CreateResponse(HttpStatusCode.OK, new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                }
            }
            var myMess1 = new
            {
                Message = "Không thể kết nối với dữ liệu. Vui lòng kiểm tra lại Internet !!",
            };
            return Request.CreateResponse(HttpStatusCode.BadRequest, myMess1);

        }
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        public List<ListNhom> getnhomcn(string macn)
        {
            List<ListNhom> data = new List<ListNhom>();
            if (queryCN.SingleOrDefault(n => n.macn == macn) != null)
            {
                data.AddRange(DULIEUNHOM(queryCN.SingleOrDefault(n => n.macn == macn).data));
            }
            else if (queryCH.SingleOrDefault(n => n.macn == macn) != null)
            {
                data.AddRange(DULIEUCUAHANGNHOM(queryCH.SingleOrDefault(n => n.macn == macn).data));
            }

            return data.OrderBy(n => n.MANHOM).ToList();
        }
        public List<ListNhomSP> DULIEUNHOMSP(Entities data)
        {

            try
            {
                var All = data.Database.SqlQuery<ListNhomSP>("SELECT MAHH,TENHH,nhom AS NHOM FROM TBL_DANHMUCHANGHOA WHERE MAHH IS NOT NULL AND nhom IN ('50', '51', '60', '61', '62', '63','64','64.PME','64.STA', '70','99','40','50.STA','51.STA','60.STA','62.STA')").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListNhomSP>();
            }
        }
        public List<ListNhom> DULIEUNHOM(Entities data)
        {

            try
            {
                var All = data.Database.SqlQuery<ListNhom>("SELECT MANHOM,TENNHOM FROM TBL_DANHMUCNHOMHANG").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListNhom>();
            }
        }
        public List<ListNhom> DULIEUCUAHANGNHOM(CHQ10Entities1 data)
        {

            try
            {
                var All = data.Database.SqlQuery<ListNhom>("select MANHOM,TENNHOM from NHOMHANG").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListNhom>();
            }
        }
        public List<ListNhomSP> DULIEUMIENBACNHOMSP(KT_TBEntities1 data)
        {

            try
            {
                var All = data.Database.SqlQuery<ListNhomSP>("SELECT  REPLACE(dclChiTietHangHoa.MACAP,' ','')  AS MAHH, (select dbo.TCVN2Unicode(dclChiTietHangHoa.TENCAP)) AS TENHH, SUBSTRING(REPLACE(dclChiTietHangHoa.MACAP, ' ', ''), 1, 2)  AS NHOM FROM dclChiTietHangHoa WHERE REPLACE(dclChiTietHangHoa.MACAP,' ','') IS NOT NULL AND SUBSTRING(REPLACE(dclChiTietHangHoa.MACAP, ' ', ''), 1, 2) IN ('50', '51', '60', '61', '62', '63','64','64.PME','64.STA', '70','99','40','50.STA','51.STA','60.STA','62.STA')").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListNhomSP>();
            }
        }
        public List<ListHopDong> GetHopDong(string macn)
        {
            List<ListHopDong> data = new List<ListHopDong>();

            //GETKHACHHANG
            var Info = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name);
            var listpl = Info.phanloai.Split(',').ToList();
            string strcn = "SELECT makh AS MAKH, donvi AS DONVI FROM TBL_DANHMUCKHACHHANG";
            string strch = "SELECT MaKH AS MAKH, DonVi AS DONVI FROM DM_KHACHHANG_PTTT";
            string strmb = "select KT_TH.DBO.TBL_DANHMUCKHACHHANG.makh as MAKH,KT_TH.DBO.TBL_DANHMUCKHACHHANG.donvi as DONVI from KT_TH.DBO.TBL_DANHMUCKHACHHANG where KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = (SELECT MACH FROM TBL_DANHMUCCUAHANG)";
            strcn = strcn + string.Format(" WHERE phanloai IN ({0})", string.Join(",", listpl.Select(p => "'" + p + "'")));
            strch = strch + string.Format(" WHERE PHANLOAI IN ({0})", string.Join(",", listpl.Select(p => "'" + p + "'")));
            strmb = strmb + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", string.Join(",", listpl.Select(p => "'" + p + "'")));
            if (Info.matinh != "ALL")
            {
                var listmt = Info.matinh.Split(',').ToList();
                strcn = strcn + string.Format(" AND matinh IN ({0})", string.Join(",", listmt.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND MaTinh IN ({0})", string.Join(",", listmt.Select(p => "'" + p + "'")));
                strmb = strmb + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", listmt.Select(p => "'" + p + "'")));
            }
            if (Info.matdv != "ALL")
            {
                var listtdv = Info.matdv.Split(',').ToList();
                strcn = strcn + string.Format(" AND matdv IN ({0})", string.Join(",", listtdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND MaTDV IN ({0})", string.Join(",", listtdv.Select(p => "'" + p + "'")));
            }
            if (Info.maquan != "ALL")
            {
                var listquan = Info.maquan.Split(',').ToList();
                strcn = strcn + string.Format(" AND quanhuyen IN ({0})", string.Join(",", listquan.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND quanhuyen IN ({0})", string.Join(",", listquan.Select(p => "'" + p + "'")));
            }
            List<ListKhachHang> data1 = new List<ListKhachHang>();
            if (queryCN.SingleOrDefault(n => n.macn == macn) != null)
            {
                data = DULIEUHOPDONG(queryCN.SingleOrDefault(n => n.macn == macn).data).ToList();
                data1 = DULIEUKHACHHANG(queryCN.SingleOrDefault(n => n.macn == macn).data, strcn).ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == macn) != null)
            {
                data = DULIEUHOPDONGCH(queryCH.SingleOrDefault(n => n.macn == macn).data).ToList();
                data1 = DULIEUCUAHANGKHACHHANG(queryCH.SingleOrDefault(n => n.macn == macn).data, strch).ToList();
            }

            if (Info.matdv != "ALL")
            {
                var taphop = Info.matdv.Split(',').ToList();
                data1 = data1.Where(n => taphop.Contains(n.MATDV)).ToList();
                data = data.Where(n => data1.Select(cl => cl.MAKH).Contains(n.MAKH)).ToList();
            }
            return data.OrderBy(n => n.MAHD).ToList();
        }
        public List<ListNhom> DULIEUMIENBACNHOM(KT_TBEntities1 data)
        {

            try
            {
                var All = PhuYen.Database.SqlQuery<ListNhom>("select  MANHOM,TENNHOM from TBL_DANHMUCNHOMHANG").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListNhom>();
            }
        }
        public List<ListQuan> DULIEUQUAN(Entities data)
        {
            try
            {
                var All = data.Database.SqlQuery<ListQuan>("SELECT maquan,tenquan FROM TBL_DANHMUCQUAN WHERE maquan IS NOT NULL").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListQuan>();
            }
        }
        public List<ListQuan> DULIEUCUAHANGQUAN(CHQ10Entities1 data)
        {
            var All = data.Database.SqlQuery<ListQuan>("SELECT maquan,tenquan FROM TBL_DANHMUCQUAN WHERE maquan IS NOT NULL").ToList();
            return All;
        }


        public List<ListNhomSP> DULIEUCUAHANGNHOMSP(CHQ10Entities1 data)
        {
            try
            {
                var All = data.Database.SqlQuery<ListNhomSP>("SELECT MAHH,TENHH,nhom AS NHOM FROM DM_HANGHOA WHERE MAHH IS NOT NULL AND nhom IN ('50', '51', '60', '61', '62', '63','64','64.PME','64.STA', '70','99','40','50.STA','51.STA','60.STA','62.STA')").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListNhomSP>();
            }
        }
        //LOAD DỮ LIỆU NHÓM SẢN PHẨM
        //LOAD DỮ LIỆU KHU VỰC
        public List<ListKhuVuc> DULIEUKHUVUC(Entities data)
        {
            try
            {
                var All = data.Database.SqlQuery<ListKhuVuc>("SELECT MaTinh, TenTinh FROM TBL_DANHMUCDONVI WHERE MaTinh IS NOT NULL").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListKhuVuc>();
            }
        }
        public List<LoaiHD> DULIEULOAIHD(Entities data)
        {
            try
            {
                var All = data.Database.SqlQuery<LoaiHD>("select DISTINCT loaihd from TBL_DANHMUCHOPDONG where isnull(loaihd,'')<>'' ").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<LoaiHD>();
            }
        }
        public List<LoaiHD> DULIEUCUAHANGLOAIHD(CHQ10Entities1 data)
        {
            try
            {
                var All = data.Database.SqlQuery<LoaiHD>("select DISTINCT loaihd from TBL_DANHMUCHOPDONG where isnull(loaihd,'')<>'' ").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<LoaiHD>();
            }

        }
        public List<ListKhuVuc> DULIEUCUAHANGKHUVUC(CHQ10Entities1 data)
        {
            try
            {
                var All = data.Database.SqlQuery<ListKhuVuc>("SELECT MaTinh, TenTinh FROM DS_TINH WHERE MaTinh IS NOT NULL").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListKhuVuc>();
            }

        }
        public List<ListKhuVuc> DULIEUMIENBACKHUVUC(KT_TBEntities1 data)
        {
            try
            {
                var All = data.Database.SqlQuery<ListKhuVuc>("select distinct KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh AS MATINH , KT_TH.DBO.TBL_DANHMUCTINH.tentinh AS TENTINH from KT_TH.DBO.TBL_DANHMUCKHACHHANG left join KT_TH.DBO.TBL_DANHMUCTINH on KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh = KT_TH.DBO.TBL_DANHMUCTINH.matinh where KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = (SELECT MACH FROM TBL_DANHMUCCUAHANG ) and KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh IS NOT NULL and KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh != ''").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListKhuVuc>();
            }

        }
        //LOAD DỮ LIỆU KHU VỰC
        //LOAD DỮ LIỆU KHUYẾN MÃI
        public List<ListKhuyenMai> DULIEUKHUYENMAI(Entities data)
        {

            try
            {
                var All = data.Database.SqlQuery<ListKhuyenMai>("SELECT MaCTKM AS MAKM, TenCTKM AS TENKM FROM TBL_DANHMUCKM WHERE MaCTKM IS NOT NULL").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListKhuyenMai>();
            }
        }
        public List<ListKhuyenMai> DULIEUCUAHANGKHUYENMAI(CHQ10Entities1 data)
        {

            try
            {
                var All = data.Database.SqlQuery<ListKhuyenMai>("SELECT distinct MACTKM AS MAKM, TENCTKM AS TENKM FROM TBL_DANHMUCKHUYENMAI WHERE MACTKM IS NOT NULL AND MACTKM != ''").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListKhuyenMai>();
            }
        }
        public List<ListKhuyenMai> DULIEUMIENBACKHUYENMAI(Entities data)
        {

            try
            {
                var All = data.Database.SqlQuery<ListKhuyenMai>("SELECT MaCTKM AS MAKM, TenCTKM AS TENKM FROM TBL_DANHMUCKHUYENMAI WHERE MaCTKM IS NOT NULL").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListKhuyenMai>();
            }
        }
        //LOAD DỮ LIỆU KHUYẾN MÃI
        //LOAD DỮ LIỆU TRÌNH DUYỆT VIÊN

        public List<ListTrinhDuocVien> DULIEUTRINHDUOCVIEN(Entities data)
        {

            try
            {
                var All = data.Database.SqlQuery<ListTrinhDuocVien>("SELECT MaTDV AS MATDV, TenTDV AS TENTDV FROM TBL_DANHMUCTDV WHERE MaTDV IS NOT NULL").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListTrinhDuocVien>();
            }
        }
        public List<ListHopDong> DULIEUHOPDONG(Entities data)
        {
            try
            {
                var All = data.Database.SqlQuery<ListHopDong>("SELECT MAHD, MAKH, donvi AS DONVI FROM TBL_DANHMUCHOPDONG").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListHopDong>();
            }

        }
        public List<ListHopDong> DULIEUHOPDONGCH(CHQ10Entities1 data)
        {
            try
            {
                var All = data.Database.SqlQuery<ListHopDong>("SELECT MAHD, MAKH, donvi AS DONVI FROM TBL_DANHMUCHOPDONG").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListHopDong>();
            }

        }
        public List<ListTrinhDuocVien> DULIEUCUAHANGTRINHDUOCVIEN(CHQ10Entities1 data)
        {
            try
            {
                var All = data.Database.SqlQuery<ListTrinhDuocVien>("SELECT MaTDV AS MATDV, TenTDV AS TENTDV FROM DS_TDV_PTTT WHERE MaTDV IS NOT NULL").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListTrinhDuocVien>();
            }

        }
        public List<ListTrinhDuocVien> DULIEUMIENBACTRINHDUOCVIEN(CHQ10Entities1 data)
        {
            try
            {
                var All = data.Database.SqlQuery<ListTrinhDuocVien>("SELECT MaTDV AS MATDV, TenTDV AS TENTDV FROM DS_TDV_PTTT").ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListTrinhDuocVien>();
            }

        }
        public List<ListKhachHang> DULIEUKHACHHANG(Entities data, string str)
        {
            try
            {
                data.Database.CommandTimeout = 320;
                var All = data.Database.SqlQuery<ListKhachHang>(str).ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListKhachHang>();
            }

        }
        public List<ListKhachHang> DULIEUCUAHANGKHACHHANG(CHQ10Entities1 data, string str)
        {
            try
            {
                data.Database.CommandTimeout = 320;
                var All = data.Database.SqlQuery<ListKhachHang>(str).ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListKhachHang>();
            }


        }
        public List<ListKhachHang> DULIEUMIENBACKHACHHANG(KT_TBEntities1 data, string str)
        {
            try
            {
                data.Database.CommandTimeout = 320;
                var All = data.Database.SqlQuery<ListKhachHang>(str).ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListKhachHang>();
            }
        }
        public List<Khachhang> GetTenKhachHang(List<string> macn, List<string> makh)
        {
            string strcn = "SELECT makh AS MAKH, donvi AS DONVI FROM TBL_DANHMUCKHACHHANG";
            string strch = "SELECT MaKH AS MAKH, DonVi AS DONVI FROM DM_KHACHHANG_PTTT";

            if (makh != null)
            {
                strcn = strcn + string.Format(" WHERE makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" WHERE MaKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            }
            List<Khachhang> DATAX = new List<Khachhang>();
            foreach (var x in macn)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<Khachhang>(strcn).ToList());
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<Khachhang>(strch).ToList());
                }
            }
            return DATAX;
        }
        public List<sp_INSOCTIET_CONGNO_Result> DATABAOCAO1CH(List<string> soso, DateTime tungay, DateTime denngay, List<string> khachhang, List<string> khuvuc, List<string> tdv, List<string> quanhuyen)
        {
            string select = "";
            string select1 = "";
            if (khachhang != null)
            {
                //var MAKH = String.Join(",", khachhang.ToArray());
                select = string.Format("({0})", string.Join(",", khachhang.Select(p => "'" + p + "'")));
                select1 = "(SELECT VAL FROM FUN_CATCHUOI('" + String.Join(",", khachhang.ToArray()) + "'))";
            }
            else if (tdv != null)
            {
                select = string.Format(" (SELECT MaKH from DM_KHACHHANG_PTTT where MaTDV IN ({0})) ", string.Join(",", tdv.Select(p => "'" + p + "'")));
                select1 = string.Format(" (SELECT MaKH from DM_KHACHHANG_PTTT where MaTDV IN ({0})) ", string.Join(",", tdv.Select(p => "'" + p + "'")));
            }
            else if (tdv == null && quanhuyen != null)
            {
                select = string.Format(" (SELECT MaKH from DM_KHACHHANG_PTTT where quanhuyen IN ({0})) ", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
                select1 = string.Format(" (SELECT MaKH from DM_KHACHHANG_PTTT where quanhuyen IN ({0})) ", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
            }
            else if (tdv == null && quanhuyen == null && khuvuc != null)
            {
                select = string.Format(" (SELECT MaKH from DM_KHACHHANG_PTTT where MaTinh IN ({0})) ", string.Join(",", khuvuc.Select(p => "'" + p + "'")));
                select1 = string.Format(" (SELECT MaKH from DM_KHACHHANG_PTTT where MaTinh IN ({0})) ", string.Join(",", khuvuc.Select(p => "'" + p + "'")));
            }

            //CUAHANG
            string strch = "";
            strch = " DECLARE @retFindReportsBAN TABLE(";
            strch = strch + " sohd varchar(20),";
            strch = strch + " ngaylaphd varchar(20),";
            strch = strch + " tienban money default 0,";
            strch = strch + " MAKH VARCHAR(255),";
            strch = strch + " TENKH NVARCHAR(255) )";

            // PHÁT SINH BAN ĐẦU

            strch = strch + " insert into @retFindReportsBAN(makh) ";
            strch = strch + select1;

            strch = strch + " INSERT INTO  @retFindReportsBAN";
            strch = strch + " SELECT distinct hoadon.sohd,hoadon.ngaylaphd";
            strch = strch + " ,ROUND(sum( ROUND((ROUND(CAST(CT_HOADON.SOLUONG AS MONEY)*CAST(CT_HOADON.DONGIA AS MONEY),0)-ROUND(ROUND(CAST(CT_HOADON.SOLUONG AS MONEY)*CAST(CT_HOADON.DONGIA AS MONEY),0)*TYLECK/100,0)),0))*THUESUAT/100,0)+SUM(ROUND(CAST(CT_HOADON.SOLUONG AS MONEY)*CAST(CT_HOADON.DONGIA AS MONEY),0)-ROUND(ROUND(CAST(CT_HOADON.SOLUONG AS MONEY)*CAST(CT_HOADON.DONGIA AS MONEY),0)*TYLECK/100,0))";
            strch = strch + " ,HOADON.MAKH";
            strch = strch + " ,DM_KHACHHANG.DONVI";
            strch = strch + " FROM HOADON_XUAT HOADON,ct_hoadon_XUAT CT_HOADON";
            strch = strch + " ,DM_KHACHHANG_PTTT DM_KHACHHANG";
            strch = strch + " where  HOADON.MAPL='BAN' ";
            strch = strch + " AND  HOADON.MAKH=DM_KHACHHANG.MAKH";
            strch = strch + " and hoadon.sohd=ct_hoadon.sohd";
            strch = strch + " and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD";
            strch = strch + " and ct_hoadon.kt=1";
            strch = strch + " AND HOADON.NGAYLAPHD BETWEEN'" + tungay.ToString("MM/dd/yyyy") + "' AND '" + denngay.ToString("MM/dd/yyyy") + "'";
            strch = strch + " and hoadon.makh IN " + select;
            strch = strch + " AND HOADON.MACH=CT_HOADON.MACH";
            strch = strch + " group by hoadon.sohd,hoadon.ngaylaphd,HOADON.MAKH,DM_KHACHHANG.DONVI,HOADON.THUESUAT";

            // TRẢ TIỀN
            strch = strch + " DECLARE @retFindReportsTRAHANG TABLE(";
            strch = strch + " sohd varchar(20),";
            strch = strch + " ngaylaphd varchar(20),";
            strch = strch + " tientrahang money default 0,";
            strch = strch + " MAKH VARCHAR(255),";
            strch = strch + " TENKH NVARCHAR(255) )";

            strch = strch + " DECLARE @retFindReportsTHU TABLE(";
            strch = strch + " sohd varchar(20),";
            strch = strch + " ngaylaphd varchar(20),";
            strch = strch + " tienthu money default 0,";
            strch = strch + " MAKH VARCHAR(255),";
            strch = strch + " TENKH NVARCHAR(255) )";

            strch = strch + " INSERT INTO  @retFindReportsTHU";
            strch = strch + " select CN.sct, CN.ngaylaphd, CN.tien,CN.MAKH,CN.NOIDUNG";
            strch = strch + " from congno_khachhang_tratien  CN";
            strch = strch + " where CN.makh  IN " + select;
            strch = strch + " and CN.ngaylaphd between '" + tungay.ToString("MM/dd/yyyy") + "' AND '" + denngay.ToString("MM/dd/yyyy") + "'";
            strch = strch + " AND CN.KT IS NULL";

            strch = strch + " DECLARE @retFindReports TABLE(";
            strch = strch + " sohd varchar(20),";
            strch = strch + " ngaylaphd smalldatetime,";
            strch = strch + " tienban money default 0,";
            strch = strch + " tienthu money default 0,";
            strch = strch + " tiendauky money default 0,";
            strch = strch + " tientrahang money default 0,";
            strch = strch + " MAKH1 VARCHAR(255),";
            strch = strch + " TENKH NVARCHAR(255),TENKH1 NVARCHAR(255) )";
            strch = strch + " INSERT INTO  @retFindReports";
            strch = strch + " SELECT sohd,ngaylaphd,tienban,0,0,0,MAKH,TENKH,''";
            strch = strch + " FROM  @retFindReportsBAN";
            strch = strch + " INSERT INTO  @retFindReports";
            strch = strch + " SELECT sohd,ngaylaphd,0,tienthu,0,0,MAKH,TENKH,''";
            strch = strch + " FROM  @retFindReportsTHU";
            strch = strch + " INSERT INTO  @retFindReports";
            strch = strch + " SELECT sohd,ngaylaphd,0,0,0,TIENTRAHANG,MAKH,TENKH,''";
            strch = strch + " FROM  @retFindReportsTRAHANG";
            // TIỀN ĐẦU KỲ
            strch = strch + " DECLARE contro5 CURSOR";
            strch = strch + " FOR SELECT makh,tien";
            strch = strch + " FROM congno_dauky_2";
            strch = strch + " WHERE makh  IN " + select;
            strch = strch + " and thang=month('" + tungay.ToString("MM/dd/yyyy") + "' )";
            strch = strch + " and nam=year('" + denngay.ToString("MM/dd/yyyy") + "' )";
            strch = strch + " OPEN contro5";
            strch = strch + " DECLARE @makh1 varchar(20),@tien money";
            strch = strch + " FETCH NEXT FROM contro5";
            strch = strch + " INTO @makh1,@tien";
            strch = strch + " WHILE @@FETCH_STATUS=0";
            strch = strch + " BEGIN ";
            strch = strch + " update @retFindReports";
            strch = strch + " SET  tiendauky=@tien where makh1=@makh1";
            strch = strch + " FETCH NEXT FROM contro5";
            strch = strch + " INTO @makh1,@tien";
            strch = strch + " END";
            strch = strch + " CLOSE contro5";
            strch = strch + " DEALLOCATE contro5";
            strch = strch + " UPDATE  @retFindReports SET TENKH1 =(SELECT DONVI FROM DM_KHACHHANG_PTTT WHERE MAKH=MAKH1)";
            strch = strch + " select sohd,ngaylaphd,tienban,tienthu,tiendauky,tientrahang,TENKH1,TENKH,MAKH1 , '" + tungay.ToString("MM/dd/yyyy") + "' as tungay, '" + denngay.ToString("MM/dd/yyyy") + "' as denngay";
            strch = strch + " ,makh1 as makh";
            strch = strch + ",TIEUDE.TENDVBC ";
            strch = strch + ",TIEUDE.TINH ";
            strch = strch + ",TIEUDE.TENCN ";
            strch = strch + ",TIEUDE.NGANHANG ";
            strch = strch + ",sohd as sct,ngaylaphd as ngay,tenkh as noidung ";
            strch = strch + ",tienban as psno,tienthu as psco ";
            strch = strch + " from  @retFindReports,TIEUDE";
            strch = strch + " order by ngaylaphd";
            var DATAX = new List<sp_INSOCTIET_CONGNO_Result>();
            foreach (var x in soso)
            {
                if (x == "CHQ10")
                {
                    DATAX.AddRange(BAOCAOCUAHANG1(CHQ10, strch));
                }
                else if (x == "CHPPSP")
                {
                    DATAX.AddRange(BAOCAOCUAHANG1(CHPPSP, strch));
                }
                else if (x == "PTTT")
                {
                    DATAX.AddRange(BAOCAOCUAHANG1(PTTT, strch));
                }
            }
            return DATAX;
        }
        public List<DULIEUBAOCAO2> DATABAOCAO2(List<string> soso, DateTime tungay, DateTime denngay, List<string> khachhang, List<string> matdv, string maphanloai, List<string> makhuvuc)
        {
            string strcn = "";
            string strch = "";
            if (khachhang != null)
            {
                var MAKH = String.Join(",", khachhang.ToArray());
                strcn = " exec sp_kyhan_inct_capnhap '131'," + denngay.Month + "," + denngay.Year + ",'','" + MAKH + "','" + denngay.ToString("MM/dd/yyyy") + "' ";
                strch = " exec sp_kyhan_inct_capnhap '131'," + denngay.Month + "," + denngay.Year + ",'','" + MAKH + "','" + denngay.ToString("MM/dd/yyyy") + "' ";
            }
            else
            {
                var str = "SELECT makh from TBL_DANHMUCKHACHHANG where makh is not null";
                var str1 = "SELECT makh from DM_KHACHHANG_PTTT where makh is not null";
                if (matdv != null)
                {
                    str = str + string.Format(" and matdv IN ({0}) ", string.Join(",", matdv.Select(p => "'" + p + "'")));
                    str1 = str1 + string.Format(" and matdv IN ({0}) ", string.Join(",", matdv.Select(p => "'" + p + "'")));
                }
                if (makhuvuc != null)
                {
                    str = str + string.Format(" and matinh IN ({0}) ", string.Join(",", makhuvuc.Select(p => "'" + p + "'")));
                    str1 = str1 + string.Format(" and matinh IN ({0}) ", string.Join(",", makhuvuc.Select(p => "'" + p + "'")));

                }
                if (maphanloai != "ALL")
                {
                    str = str + string.Format(" and phanloai IN ('{0}') ", maphanloai);
                    str1 = str1 + string.Format(" and phanloai IN ('{0}') ", maphanloai);
                }

                strcn = " DECLARE @TBL_IN TABLE( TK VARCHAR(20) ,SCT VARCHAR(20) ,NGAY SMALLDATETIME ,MAKH VARCHAR(20) ,TIEN FLOAT DEFAULT NULL ,KT BIT ,SOID VARCHAR(40) ,MACH VARCHAR(20) ,THANG INT ,NAM INT ,MAKH1 VARCHAR(20)) DECLARE @TBL_IN_01 TABLE ( MAKH VARCHAR(20) ,TENKH NVARCHAR(700) ,DAUNAM_NO FLOAT DEFAULT NULL ,DAUNAM_CO FLOAT DEFAULT NULL ,PSNO FLOAT DEFAULT NULL ,PSCO FLOAT DEFAULT NULL ,CKNO FLOAT DEFAULT NULL ,CKCO FLOAT DEFAULT NULL ,MAKH1 VARCHAR(20) ) DECLARE @TBL_TAM_KYHAN TABLE ( MAKH VARCHAR(20) ,DAUNAM_NO FLOAT DEFAULT NULL ,DAUNAM_CO FLOAT DEFAULT NULL ,PSNO FLOAT DEFAULT NULL ,PSCO FLOAT DEFAULT NULL ,CKNO FLOAT DEFAULT NULL ,CKCO FLOAT DEFAULT NULL ,MAKH1 VARCHAR(20) ) insert into @TBL_IN(mach,tk,sct,ngay,makh,tien) select '',tk,sct,ngay,makh,tien FROM dta_kyhancongno where THANG in(select THANG_NAM from fun_KTTHANG(1," + denngay.Month + "," + denngay.Year + " )) AND NAM in(select THANG_NAM from fun_KTTHANG(2," + denngay.Month + "," + denngay.Year + ")) and tk='131' and makh IN (" + str + ") insert into @TBL_IN(mach,ngay,sct,makh,tk,tien) select '',ngay,sct,makhn,tkn,isnull(sum(tien),0) FROM dta_dinhkhoan where month(ngay)=" + denngay.Month + " and year(ngay)=" + denngay.Year + " and tkn='131' and makhN IN (" + str + ") group by ngay,sct,makhn,tkn insert into @TBL_IN(mach,ngay,sct,makh,tk,tien) select '',ngay,sct,makhC,tkC,isnull(sum(ABS(tien)),0) FROM dta_dinhkhoan where month(ngay)=" + denngay.Month + " and year(ngay)=" + denngay.Year + " and tkC='131' AND tien <0 and makhc IN (" + str + ") group by ngay,sct,makhC,tkC update @TBL_IN set kt=0, SOID=ltrim(rtrim(mach))+ltrim(rtrim(makh))+convert(varchar(10),ngay,112)+isnull(ltrim(rtrim(sct)),''), makh1=makh insert into @TBL_IN_01(makh,daunam_no) select matk,isnull(duno,0) FROM dta_daukytaikhoan WHERE tkcaptren='131' and nam=" + denngay.Year + " and thamchieu=1 and matk IN (" + str + ") insert into @TBL_IN_01(makh,daunam_co) select matk,isnull(duco,0) FROM dta_daukytaikhoan WHERE tkcaptren='131' and nam=" + denngay.Year + " and thamchieu=1 and matk IN (" + str + ") insert into @TBL_IN_01(makh,psno) select makhn,isnull(sum(tien),0) FROM dta_dinhkhoan where tkn='131' and month(ngay)>=1 and month(ngay)<=" + denngay.Month + " and year(ngay)=" + denngay.Year + " and makhn IN (" + str + ") group by makhn insert into @TBL_IN_01(makh,psco) select makhc,isnull(sum(tien),0) FROM dta_dinhkhoan where tkc='131' and month(ngay)>=1 and month(ngay)<=" + denngay.Month + " and year(ngay)=" + denngay.Year + " and makhc IN (" + str + ") group by makhc insert into @TBL_TAM_KYHAN(makh,daunam_no,daunam_co,psno,psco) select makh,sum(daunam_no),sum(daunam_co),sum(psno),sum(psco)from @TBL_IN_01 group by makh update @TBL_TAM_KYHAN set makh1=makh update @TBL_TAM_KYHAN set ckno=isnull(daunam_no,0)-isnull(daunam_co,0)+isnull(psno,0)-isnull(psco,0) delete @TBL_TAM_KYHAN where ckno<=0 Declare @makh1 varchar(20) Declare @TienCK float set @TienCK=0 Declare curIC cursor FOR select makh1,ckno from @TBL_TAM_KYHAN OPEN curIC FETCH NEXT FROM curIC INTO @makh1,@TienCK WHILE @@FETCH_STATUS=0 BEGIN Declare @autoID varchar(30) Declare @tien float Declare curFIFO cursor FOR select soID,tien from @TBL_IN where makh1=@makh1 order by ngay desc OPEN curFIFO FETCH NEXT FROM curFIFO INTO @autoID,@Tien WHILE (@@FETCH_STATUS=0) AND (@TienCK!=0) BEGIN IF @TienCK>=@Tien BEGIN SET @TienCK=@TienCK-@tien UPDATE @TBL_IN SET KT=1 WHERE soID= @autoID END ELSE BEGIN UPDATE @TBL_IN SET KT=1,tien=@TienCK WHERE soID= @autoID SET @TienCK=0 END FETCH NEXT FROM curFIFO INTO @autoID,@Tien END CLOSE curFIFO DEALLOCATE curFIFO FETCH NEXT FROM curIC INTO @makh1,@TienCK END CLOSE curIC DEALLOCATE curIC delete from @TBL_IN where kt=0 update @TBL_IN set tk='131',thang=" + denngay.Month + ", nam=" + denngay.Year + " declare @dta_kyhancongno table ( tk varchar(20), makh varchar(20), sct varchar(20), ngay smalldatetime , tien money ) insert into @dta_kyhancongno(tk,makh,sct,ngay,tien ) select tk,makh,sct,ngay,tien from @TBL_IN WHERE MAKH <>'' AND MAKH IS NOT NULL order by makh DECLARE @TBL_IN_10 TABLE ( TK VARCHAR(10) ,MACH NVARCHAR(200) ,SCT VARCHAR(20) ,NGAY SMALLDATETIME ,MAKH1 VARCHAR(20) ,TIEN FLOAT DEFAULT NULL ,SONGAY FLOAT DEFAULT NULL ,ngayin SMALLDATETIME ,t1 FLOAT DEFAULT NULL ,t2 FLOAT DEFAULT NULL ,t3 FLOAT DEFAULT NULL ,t4 FLOAT DEFAULT NULL ,t5 FLOAT DEFAULT NULL ,t6 FLOAT DEFAULT NULL ,t7 FLOAT DEFAULT NULL ,t8 FLOAT DEFAULT NULL ,t9 FLOAT DEFAULT NULL ,t10 FLOAT DEFAULT NULL ,t11 FLOAT DEFAULT NULL ,t12 FLOAT DEFAULT NULL ,t13 FLOAT DEFAULT NULL ,donvi nvarchar(200) ,diachi1 nvarchar(200) ) Declare @m_mmddyy SMALLDATETIME set @m_mmddyy='" + denngay.ToString("MM/dd/yyyy") + "' DECLARE @DONVI NVARCHAR(300) DECLARE @DIACHI NVARCHAR(300) insert into @TBL_IN_10(sct,ngay,makh1,tien,mach) select sct,ngay,makh,tien ,'' FROM @dta_kyhancongno where TIEN >0 update @TBL_IN_10 set ngayin='" + denngay.ToString("MM/dd/yyyy") + "' update @TBL_IN_10 set songay=DATEDIFF ( dd , ngay , ngayin ) update @TBL_IN_10 set t1=tien where songay<=30 update @TBL_IN_10 set t2=tien where songay>30 and songay<=60 update @TBL_IN_10 set t3=tien where songay>60 and songay<=90 update @TBL_IN_10 set t4=tien where songay>90 and songay<=120 update @TBL_IN_10 set t5=tien where songay>120 and songay<=150 update @TBL_IN_10 set t6=tien where songay>150 and songay<=180 update @TBL_IN_10 set t7=tien where songay>180 and songay<=210 update @TBL_IN_10 set t8=tien where songay>210 and songay<=240 update @TBL_IN_10 set t9=tien where songay>240 and songay<=270 update @TBL_IN_10 set t10=tien where songay>270 and songay<=300 update @TBL_IN_10 set t11=tien where songay>300 and songay<=330 update @TBL_IN_10 set t12=tien where songay>330 and songay<=360 update @TBL_IN_10 set t13=tien where songay>360 declare @thongtin table ( makh varchar(20) ,donvi nvarchar(200) ,tien money ,t1 money ,t2 money ,t3 money ,t4 money ,t5 money ,t6 money ,t7 money ,t8 money ,t9 money ,t10 money ,t11 money ,t12 money ,t13 money ) update @TBL_IN_10 set donvi=(select donvi from tbl_danhmuckhachhang where makh=makh1)  insert into @thongtin SELECT makh1,donvi ,sum(tien),sum(isnull(t1,0)),sum(isnull(t2,0)),sum(isnull(t3,0)) ,sum(isnull(t4,0)),sum(isnull(t5,0)),sum(isnull(t6,0)) ,sum(isnull(t7,0)),sum(isnull(t8,0)),sum(isnull(t9,0)),sum(isnull(t10,0)) ,sum(isnull(t11,0)),sum(isnull(t12,0)),sum(isnull(t13,0)) FROM @TBL_IN_10, TBL_DANHMUCTIEUDEBAOCAO group by makh1,donvi,DIACHI1 ,TBL_DANHMUCTIEUDEBAOCAO.TENCN ,TBL_DANHMUCTIEUDEBAOCAO.TAIKHOAN ,TBL_DANHMUCTIEUDEBAOCAO.NGANHANG ,TBL_DANHMUCTIEUDEBAOCAO.tendvbc select * from @thongtin ";
                strch = " DECLARE @TBL_IN TABLE( TK VARCHAR(20) ,SCT VARCHAR(20) ,NGAY SMALLDATETIME ,MAKH VARCHAR(20) ,TIEN FLOAT DEFAULT NULL ,KT BIT ,SOID VARCHAR(40) ,MACH VARCHAR(10) ,THANG INT ,NAM INT ,MAKH1 VARCHAR(20)) DECLARE @TBL_IN_02 TABLE ( TK VARCHAR(20) ,SCT VARCHAR(20) ,NGAY SMALLDATETIME ,MAKH VARCHAR(20) ,TIEN FLOAT DEFAULT NULL ,KT BIT ,SOID VARCHAR(40) ,MACH VARCHAR(10) ,THANG INT ,NAM INT ,MAKH1 VARCHAR(20) ,ts int ) DECLARE @TBL_IN_01 TABLE ( MAKH VARCHAR(20) ,TENKH NVARCHAR(200) ,DAUNAM_NO FLOAT DEFAULT NULL ,DAUNAM_CO FLOAT DEFAULT NULL ,PSNO FLOAT DEFAULT NULL ,PSCO FLOAT DEFAULT NULL ,CKNO FLOAT DEFAULT NULL ,CKCO FLOAT DEFAULT NULL ,MAKH1 VARCHAR(20) ) DECLARE @TBL_IN_01_01 TABLE ( sct varchar(20) ,ngay smalldatetime ,tien money ,ts int , MAKH VARCHAR(20) ,TENKH NVARCHAR(200) ,DAUNAM_NO FLOAT DEFAULT NULL ,DAUNAM_CO FLOAT DEFAULT NULL ,PSNO FLOAT DEFAULT NULL ,PSCO FLOAT DEFAULT NULL ,CKNO FLOAT DEFAULT NULL ,CKCO FLOAT DEFAULT NULL ,MAKH1 VARCHAR(20) ) DECLARE @TBL_TAM_KYHAN TABLE ( MAKH VARCHAR(20) ,DAUNAM_NO FLOAT DEFAULT NULL ,DAUNAM_CO FLOAT DEFAULT NULL ,PSNO FLOAT DEFAULT NULL ,PSCO FLOAT DEFAULT NULL ,CKNO FLOAT DEFAULT NULL ,CKCO FLOAT DEFAULT NULL ,MAKH1 VARCHAR(20) ) insert into @TBL_IN(mach,tk,sct,ngay,makh,tien) select '',tk,sct,ngay,makh,tien FROM dta_kyhancongno where THANG in(select THANG_NAM from fun_KTTHANG(1," + denngay.Month + "," + denngay.Year + " )) AND NAM in(select THANG_NAM from fun_KTTHANG(2," + denngay.Month + "," + denngay.Year + " )) and makh IN (" + str1 + ") insert into @TBL_IN_02(mach,ngay,sct,makh,tk,tien,ts) SELECT '',hoadon.ngaylaphd,hoadon.sohd,HOADON.MAKH ,'' ,SUM(ROUND(CAST(CT_HOADON.SOLUONG AS MONEY)*CAST(CT_HOADON.DONGIA AS MONEY),0))-SUM(ROUND(ROUND(CAST(CT_HOADON.SOLUONG AS MONEY)*CAST(CT_HOADON.DONGIA AS MONEY),0)*CT_HOADON.TYLECK/100,0)) ,hoadon.THUESUAT FROM HOADON_XUAT HOADON,ct_hoadon_XUAT CT_HOADON where HOADON.MAPL='BAN' AND hoadon.sohd=ct_hoadon.sohd and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND month(HOADON.NGAYLAPHD) =" + denngay.Month + " AND year(HOADON.NGAYLAPHD) =" + denngay.Year + " and hoadon.mach=ct_hoadon.mach and hoadon.makh IN (" + str1 + ") group by hoadon.sohd,hoadon.ngaylaphd,HOADON.MAKH ,HOADON.tennguoigd ,HOADON.THUESUAT insert into @TBL_IN (mach,ngay,sct,makh,tk,tien ) select mach,ngay,sct,makh,tk,tien + round(tien *ts/100,0) from @TBL_IN_02 insert into @TBL_IN(mach,ngay,sct,makh,tk,tien) select '',NGAYLAPHD,SOHD,MAKH,'', sum(ABS(CN.tien) ) from congno_khachhang_tratien CN where month(CN.ngaylaphd) =" + denngay.Month + " AND year(CN.NGAYLAPHD) =" + denngay.Year + " AND TIEN<0 AND KT IS NULL and makh IN (" + str1 + ") group by NGAYLAPHD,SOHD,MAKH update @TBL_IN set kt=0, SOID=ltrim(rtrim(mach))+ltrim(rtrim(makh))+convert(varchar(10),ngay,112)+isnull(ltrim(rtrim(sct)),''), makh1=makh insert into @TBL_IN_01(makh,daunam_no) select MAKH,isnull(TIEN,0) FROM CONGNO_DAUKY_2 WHERE THANG=" + denngay.Month + " AND nam=" + denngay.Year + " AND TIEN >0 and makh IN (" + str1 + ") insert into @TBL_IN_01(makh,daunam_co) select maKH,isnull(ABS(TIEN),0) FROM CONGNO_DAUKY_2 WHERE THANG=" + denngay.Month + " AND nam=" + denngay.Year + " AND TIEN <0 and makh IN (" + str1 + ") insert into @TBL_IN_01_01(sct,ngay,makh,tien,ts ) select HOADON.sohd,HOADON.ngaylaphd ,HOADON.MAKH ,SUM(ROUND(CAST(CT_HOADON.SOLUONG AS MONEY)*CAST(CT_HOADON.DONGIA AS MONEY),0))-SUM(ROUND(ROUND(CAST(CT_HOADON.SOLUONG AS MONEY)*CAST(CT_HOADON.DONGIA AS MONEY),0)*CT_HOADON.TYLECK/100,0)) ,hoadon.THUESUAT FROM HOADON_XUAT HOADON,ct_hoadon_XUAT CT_HOADON where HOADON.MAPL='BAN' AND hoadon.sohd=ct_hoadon.sohd and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND month(HOADON.NGAYLAPHD) =" + denngay.Month + " AND year(HOADON.NGAYLAPHD) =" + denngay.Year + " and hoadon.mach=ct_hoadon.mach and hoadon.makh IN (" + str1 + ") group by HOADON.sohd,HOADON.ngaylaphd ,HOADON.MAKH,hoadon.THUESUAT insert into @TBL_IN_01(makh,psno) select makh,sum(tien + round(tien *ts/100,0)) from @TBL_IN_01_01 group by makh insert into @TBL_IN_01(makh,psno) SELECT MAKH,SUM(ABS(TIEN)) from congno_khachhang_tratien CN where month(CN.ngaylaphd) =" + denngay.Month + " AND year(CN.NGAYLAPHD) =" + denngay.Year + " AND TIEN<0 AND KT IS NULL and makh IN (" + str1 + ") GROUP BY MAKH insert into @TBL_IN_01(makh,psco) SELECT MAKH,SUM(ABS(TIEN)) from congno_khachhang_tratien CN where month(CN.ngaylaphd) =" + denngay.Month + " AND year(CN.NGAYLAPHD) =" + denngay.Year + " AND TIEN>0 AND KT IS NULL and makh IN (" + str1 + ") GROUP BY MAKH insert into @TBL_TAM_KYHAN(makh,daunam_no,daunam_co,psno,psco) select makh,sum(daunam_no),sum(daunam_co),sum(psno),sum(psco)from @TBL_IN_01 group by makh update @TBL_TAM_KYHAN set makh1=makh update @TBL_TAM_KYHAN set ckno=isnull(daunam_no,0)-isnull(daunam_co,0)+isnull(psno,0)-isnull(psco,0) delete @TBL_TAM_KYHAN where ckno<=0 Declare @makh1 varchar(20) Declare @TienCK float set @TienCK=0 Declare curIC cursor FOR select makh1,ckno from @TBL_TAM_KYHAN OPEN curIC FETCH NEXT FROM curIC INTO @makh1,@TienCK WHILE @@FETCH_STATUS=0 BEGIN Declare @autoID varchar(30) Declare @tien float Declare curFIFO cursor FOR select soID,tien from @TBL_IN where makh1=@makh1 order by ngay desc OPEN curFIFO FETCH NEXT FROM curFIFO INTO @autoID,@Tien WHILE (@@FETCH_STATUS=0) AND (@TienCK!=0) BEGIN IF @TienCK>=@Tien BEGIN SET @TienCK=@TienCK-@tien UPDATE @TBL_IN SET KT=1 WHERE soID= @autoID END ELSE BEGIN UPDATE @TBL_IN SET KT=1,tien=@TienCK WHERE soID= @autoID SET @TienCK=0 END FETCH NEXT FROM curFIFO INTO @autoID,@Tien END CLOSE curFIFO DEALLOCATE curFIFO FETCH NEXT FROM curIC INTO @makh1,@TienCK END CLOSE curIC DEALLOCATE curIC delete from @TBL_IN where kt=0 declare @dta_kyhancongno table ( tk varchar(20), makh varchar(20), sct varchar(20), ngay smalldatetime , tien money ) insert into @dta_kyhancongno(tk,makh,sct,ngay,tien ) select tk,makh,sct,ngay,tien from @TBL_IN WHERE MAKH <>'' AND MAKH IS NOT NULL order by makh DECLARE @TBL_IN_10 TABLE ( TK VARCHAR(10) ,MACH NVARCHAR(200) ,SCT VARCHAR(20) ,NGAY SMALLDATETIME ,MAKH1 VARCHAR(20) ,TIEN FLOAT DEFAULT NULL ,SONGAY FLOAT DEFAULT NULL ,ngayin SMALLDATETIME ,t1 FLOAT DEFAULT NULL ,t2 FLOAT DEFAULT NULL ,t3 FLOAT DEFAULT NULL ,t4 FLOAT DEFAULT NULL ,t5 FLOAT DEFAULT NULL ,t6 FLOAT DEFAULT NULL ,t7 FLOAT DEFAULT NULL ,t8 FLOAT DEFAULT NULL ,t9 FLOAT DEFAULT NULL ,t10 FLOAT DEFAULT NULL ,t11 FLOAT DEFAULT NULL ,t12 FLOAT DEFAULT NULL ,t13 FLOAT DEFAULT NULL ,donvi nvarchar(200) ,diachi1 nvarchar(200) ) Declare @m_mmddyy SMALLDATETIME set @m_mmddyy='" + denngay.ToString("MM/dd/yyyy") + "' DECLARE @DONVI NVARCHAR(300) DECLARE @DIACHI NVARCHAR(300) insert into @TBL_IN_10(sct,ngay,makh1,tien,donvi,diachi1,mach) select sct,ngay,makh,tien ,@DONVI,@DIACHI ,'' FROM @dta_kyhancongno where TIEN >0 update @TBL_IN_10 set ngayin='" + denngay.ToString("MM/dd/yyyy") + "' update @TBL_IN_10 set songay=DATEDIFF ( dd , ngay , ngayin ) update @TBL_IN_10 set t1=tien where songay<=30 update @TBL_IN_10 set t2=tien where songay>30 and songay<=60 update @TBL_IN_10 set t3=tien where songay>60 and songay<=90 update @TBL_IN_10 set t4=tien where songay>90 and songay<=120 update @TBL_IN_10 set t5=tien where songay>120 and songay<=150 update @TBL_IN_10 set t6=tien where songay>150 and songay<=180 update @TBL_IN_10 set t7=tien where songay>180 and songay<=210 update @TBL_IN_10 set t8=tien where songay>210 and songay<=240 update @TBL_IN_10 set t9=tien where songay>240 and songay<=270 update @TBL_IN_10 set t10=tien where songay>270 and songay<=300 update @TBL_IN_10 set t11=tien where songay>300 and songay<=330 update @TBL_IN_10 set t12=tien where songay>330 and songay<=360 update @TBL_IN_10 set t13=tien where songay>360 declare @thongtin table ( makh varchar(20) ,donvi nvarchar(200) ,tien money ,t1 money ,t2 money ,t3 money ,t4 money ,t5 money ,t6 money ,t7 money ,t8 money ,t9 money ,t10 money ,t11 money ,t12 money ,t13 money ,diachikh nvarchar(200) ,chon int ,matinh varchar(20) ,ngayin smalldatetime ,tendvbc nvarchar(100) ,matdv1 varchar(20) ,tentdv nvarchar(200) ,TENCN NVARCHAR(200) ,TAIKHOAN VARCHAR(20) ,NGANHANG NVARCHAR(100) ) update @TBL_IN_10 set donvi=(select donvi from dm_khachhang_pttt where makh=makh1) , diachi1=(select donvi from dm_khachhang_pttt where makh=makh1) insert into @thongtin SELECT makh1,donvi ,sum(tien),sum(isnull(t1,0)),sum(isnull(t2,0)),sum(isnull(t3,0)) ,sum(isnull(t4,0)),sum(isnull(t5,0)),sum(isnull(t6,0)) ,sum(isnull(t7,0)),sum(isnull(t8,0)),sum(isnull(t9,0)),sum(isnull(t10,0)) ,sum(isnull(t11,0)),sum(isnull(t12,0)),sum(isnull(t13,0)) , DIACHI1,1 ,'' ,'" + denngay.ToString("MM/dd/yyyy") + "' as NGAYIN ,TBL_DANHMUCTIEUDEBAOCAO.tendvbc ,'','' ,TBL_DANHMUCTIEUDEBAOCAO.TENCN ,'' , TBL_DANHMUCTIEUDEBAOCAO.NGANHANG FROM @TBL_IN_10, tieude TBL_DANHMUCTIEUDEBAOCAO group by makh1,donvi,DIACHI1 ,TBL_DANHMUCTIEUDEBAOCAO.TENCN ,TBL_DANHMUCTIEUDEBAOCAO.NGANHANG ,TBL_DANHMUCTIEUDEBAOCAO.tendvbc select * from @thongtin SELECT * FROM @TBL_IN select '',tk,sct,ngay,makh,tien FROM dta_kyhancongno where THANG in(select THANG_NAM from fun_KTTHANG(1," + denngay.Month + "," + denngay.Year + " )) AND NAM in(select THANG_NAM from fun_KTTHANG(2," + denngay.Month + "," + denngay.Year + " )) and makh IN (" + str1 + ") ";
            }
            var DATAX = new List<DULIEUBAOCAO2>();
            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(BAOCAOCHINHANH2(queryCN.SingleOrDefault(n => n.macn == x).data, strcn));
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(BAOCAOCUAHANG2(queryCH.SingleOrDefault(n => n.macn == x).data, strch));
                }
            }
            return DATAX;
        }
        public List<DULIEUBAOCAO16> DATABAOCAO16(List<string> soso, string phanloai, List<string> phanloaikhachhang, List<string> maphanloai, DateTime tungay, DateTime denngay, List<string> sanpham, List<string> matinh, List<string> matdv, List<string> maquan, TBL_DANHMUCNGUOIDUNG Info)
        {
            var nhomhang = new List<string> { "50", "51", "60", "61", "62", "63", "70" };
            var DATAX = new List<DULIEUBAOCAO16>();
            //String CN
            string strmb = "DECLARE @khachhang TABLE( makh1 VARCHAR(20), phanloai VARCHAR(30), mien NVARCHAR(200), mach NVARCHAR(200)) DECLARE @MACN VARCHAR(20) SET @MACN =(SELECT mach FROM tbl_danhmuccuahang) INSERT INTO @khachhang SELECT dclchitietkhachhang.taikhoanid, '', tbl_mien.mien, tbl_danhmuctieudebaocao.tendvbc FROM dclchitietkhachhang, tbl_danhmuctieudebaocao, tbl_mien UPDATE @khachhang SET phanloai = (SELECT phanloai FROM kt_th.dbo.tbl_danhmuckhachhang WHERE mach = @MACN AND makh = makh1) DECLARE @HANGHOA TABLE ( macn NVARCHAR(200), mien NVARCHAR(100), tien MONEY, tien_hh MONEY)";

            //String CH
            string strcn = "DECLARE @HANGHOA TABLE( macn NVARCHAR(200), mien NVARCHAR(100), tien MONEY, tien_hh MONEY) INSERT INTO @hanghoa (macn, mien, tien, tien_hh) SELECT tbl_danhmuctieudebaocao.tendvbc, tbl_mien.mien, 0, 0 from tbl_danhmuctieudebaocao,tbl_mien, tbl_danhmuccuahang UPDATE @HANGHOA SET tien = (SELECT Sum(Round(Cast(ct_hoadon.dongia AS MONEY) * Cast( ct_hoadon.soluong AS MONEY), 0) ) - Sum(Round(( Round(Cast(ct_hoadon.soluong AS MONEY) * Cast( ct_hoadon.dongia AS MONEY) , 0) * Cast( ct_hoadon.tyleck AS MONEY) / 100 ), 0)) from DTA_CT_HOADON_XUAT ct_hoadon,DTA_HOADON_XUAT HOADON  LEFT JOIN  TBL_DANHMUCKHACHHANG ON HOADON.makh=TBL_DANHMUCKHACHHANG.makh ,TBL_MIEN,TBL_DANHMUCTIEUDEBAOCAO WHERE HOADON.sohd = ct_hoadon.sohd AND HOADON.ngaylaphd = ct_hoadon.ngaylaphd AND HOADON.mach = ct_hoadon.mach AND ct_hoadon.kt = 1 ";
            //String MB

            if (phanloai != "ALL")
            {
                strmb = strmb + string.Format(" delete @khachhang WHERE phanloai NOT IN ({0})", "'" + phanloai + "'");
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }

            if (phanloaikhachhang != null)
            {
                strmb = strmb + string.Format(" delete @khachhang WHERE phanloaikhachhang NOT IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            }
            strmb = strmb + " INSERT INTO @hanghoa (macn, mien, tien, tien_hh) SELECT tbl_danhmuctieudebaocao.tendvbc, tbl_mien.mien, 0, 0 FROM tbl_danhmuctieudebaocao, tbl_mien UPDATE @HANGHOA SET tien = (SELECT Sum(Isnull(Cast(tienban AS MONEY), 0) - Isnull(Cast(tienchietkhau AS MONEY), 0)) AS tien FROM dtasoluong, dtadinhkhoan, dtachungtu, dclchitiethanghoa, dcldanhsachdonvitinh, tbl_danhmuctieudebaocao WHERE dtasoluong.dinhkhoanid = dtadinhkhoan.capdkid AND dtadinhkhoan.chungtuid = dtachungtu.chungtuid ";
            if (nhomhang != null)
            {
                strmb = strmb + string.Format(" AND Substring(Replace(dclchitiethanghoa.macap, ' ', ''), 1, 2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strcn = strcn + string.Format(" AND Substring(ct_hoadon.mahh, 1, 2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (matinh != null)
            {
                strmb = strmb + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
            }
            if (matdv != null)
            {
                strcn = strcn + string.Format(" AND HOADON.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            if (maquan != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", maquan.Select(p => "'" + p + "'")));
            }
            if (sanpham != null)
            {
                strmb = strmb + string.Format(" AND Replace(dclchitiethanghoa.macap, ' ', '') IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strcn = strcn + string.Format(" AND ct_hoadon.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
            }

            if (maphanloai != null)
            {
                string strmaplmb = string.Format("Select TKHN from TBL_DANHMUCPHANLOAIHD where MAPL IN ({0})", string.Join(",", maphanloai.Select(p => "'" + p + "'")));
                var maplmb = DATATH1.Database.SqlQuery<string>(strmaplmb).ToList();
                strmb = strmb + string.Format(" AND Substring(dtadinhkhoan.taikhoanno, 1, 3) IN ({0})", string.Join(",", maplmb.Select(p => "'" + p + "'")));
                strcn = strcn + string.Format(" AND HOADON.mapl IN ({0})", string.Join(",", maphanloai.Select(p => "'" + p + "'")));
            }
            strmb = strmb + " AND dtadinhkhoan.idtaikhoanco = dclchitiethanghoa.taikhoanid AND dcldanhsachdonvitinh.donvitinhid = dclchitiethanghoa.donvitinhid AND Cast(dtachungtu.khachhangid AS VARCHAR) IN(SELECT makh1 FROM @khachhang) AND Substring(dtadinhkhoan.taikhoanco, 1, 3)IN (SELECT val FROM Fun_catchuoi('155')) AND dtachungtu.ngaychungtu BETWEEN '" + tungay.ToString("MM/dd/yyyy") + "' AND '" + denngay.ToString("MM/dd/yyyy") + "') UPDATE @HANGHOA SET tien_hh =(SELECT Sum(Isnull(Cast(tienban AS MONEY), 0) - Isnull( Cast(tienchietkhau AS MONEY), 0)) AS tien FROM dtasoluong, dtadinhkhoan, dtachungtu, dclchitiethanghoa, dcldanhsachdonvitinh, tbl_danhmuctieudebaocao WHERE dtasoluong.dinhkhoanid = dtadinhkhoan.capdkid AND dtadinhkhoan.chungtuid = dtachungtu.chungtuid ";
            strcn = strcn + " and HOADON.ngaylaphd between '" + tungay.ToString("MM/dd/yyyy") + "'  and '" + denngay.ToString("MM/dd/yyyy") + "')  UPDATE @HANGHOA SET tien_hh=  ( SELECT sum(round(cast(ct_hoadon.dongia as money)*cast(ct_hoadon.soluong as money),0))- SUM(ROUND(( ROUND( cast(ct_hoadon.soluong as money) *cast(ct_hoadon.dongia as money),0)*cast(ct_hoadon.tyleck as money)/100),0))       from DTA_CT_HOADON_XUAT ct_hoadon,DTA_HOADON_XUAT HOADON  LEFT JOIN  TBL_DANHMUCKHACHHANG ON HOADON.makh=TBL_DANHMUCKHACHHANG.makh ,TBL_MIEN,TBL_DANHMUCTIEUDEBAOCAO   where    HOADON.SOHD=ct_hoadon.SOHD AND HOADON.NGAYLAPHD=ct_hoadon.NGAYLAPHD AND HOADON.MACH=ct_hoadon.MACH AND ct_hoadon.KT=1 ";
            //
            if (phanloai != "ALL")
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloaikhachhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            }
            if (nhomhang != null)
            {
                strmb = strmb + string.Format(" AND Substring(Replace(dclchitiethanghoa.macap, ' ', ''), 1, 2) NOT IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strcn = strcn + string.Format(" AND Substring(ct_hoadon.mahh, 1, 2) NOT IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (matinh != null)
            {
                strmb = strmb + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
            }
            if (matdv != null)
            {
                strcn = strcn + string.Format(" AND HOADON.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            if (maquan != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", maquan.Select(p => "'" + p + "'")));
            }
            if (sanpham != null)
            {
                strmb = strmb + string.Format(" AND Replace(dclchitiethanghoa.macap, ' ', '') IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strcn = strcn + string.Format(" AND ct_hoadon.mahh NOT IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
            }
            if (maphanloai != null)
            {
                string strmaplmb = string.Format("Select TKHN from TBL_DANHMUCPHANLOAIHD where MAPL IN ({0})", string.Join(",", maphanloai.Select(p => "'" + p + "'")));
                var maplmb = DATATH1.Database.SqlQuery<string>(strmaplmb).ToList();
                strmb = strmb + string.Format(" AND Substring(dtadinhkhoan.taikhoanno, 1, 3) IN ({0})", string.Join(",", maplmb.Select(p => "'" + p + "'")));
                strcn = strcn + string.Format(" AND HOADON.mapl IN ({0})", string.Join(",", maphanloai.Select(p => "'" + p + "'")));
            }
            strmb = strmb + " AND dtadinhkhoan.idtaikhoanco = dclchitiethanghoa.taikhoanid AND dcldanhsachdonvitinh.donvitinhid = dclchitiethanghoa.donvitinhid AND Cast(dtachungtu.khachhangid AS VARCHAR) IN(SELECT makh1 FROM @khachhang) AND Substring(dtadinhkhoan.taikhoanco, 1, 3)IN (SELECT val FROM Fun_catchuoi('155')) AND dtachungtu.ngaychungtu BETWEEN '" + tungay.ToString("MM/dd/yyyy") + "' AND '" + denngay.ToString("MM/dd/yyyy") + "') UPDATE @HANGHOA SET tien = 0 WHERE tien IS NULL UPDATE @HANGHOA SET tien_hh = 0 WHERE tien_hh IS NULL SELECT * FROM @HANGHOA";
            strcn = strcn + " and HOADON.ngaylaphd between '" + tungay.ToString("MM/dd/yyyy") + "'  and '" + denngay.ToString("MM/dd/yyyy") + "')";
            //String MB
            strcn = strcn + " UPDATE @HANGHOA SET tien = 0 WHERE tien IS NULL UPDATE @HANGHOA SET tien_hh = 0 WHERE tien_hh IS NULL SELECT * FROM @HANGHOA";
            var strch = strcn.Replace("from DTA_CT_HOADON_XUAT ct_hoadon,DTA_HOADON_XUAT HOADON  LEFT JOIN  TBL_DANHMUCKHACHHANG ON HOADON.makh=TBL_DANHMUCKHACHHANG.makh ,TBL_MIEN,TBL_DANHMUCTIEUDEBAOCAO", "from  CT_HOADON_XUAT ct_hoadon, HOADON_XUAT HOADON  LEFT JOIN  DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON HOADON.makh=TBL_DANHMUCKHACHHANG.makh ,TBL_MIEN,TIEUDE  TBL_DANHMUCTIEUDEBAOCAO").Replace("from tbl_danhmuctieudebaocao,tbl_mien", "from TIEUDE tbl_danhmuctieudebaocao,tbl_mien");
            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(BAOCAOCHINHANH16(queryCN.SingleOrDefault(n => n.macn == x).data, strcn));

                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(BAOCAOCUAHANG16(queryCH.SingleOrDefault(n => n.macn == x).data, strch));

                }

            }
            return DATAX;
        }
        public List<DULIEUBAOCAO24> DATABAOCAO24(List<string> soso, int nam, List<string> khachhang, List<string> ctkm, List<string> mactht, List<string> matinh, List<string> matdv, List<string> maquan, TBL_DANHMUCNGUOIDUNG Info)
        {
            string CTKM = String.Join(",", ctkm.ToArray());
            string strcn = null;
            if (khachhang != null)
            {
                strcn = "declare @m table( makh1 varchar(20), donvi nvarchar(300), TIEN1 MONEY , TIEN2 MONEY , TIEN3 MONEY , TIEN4 MONEY , TIENNAM MONEY , Q1 MONEY , Q2 MONEY , Q3 MONEY , Q4 MONEY , QNAM MONEY , ckqui float, ckdat float) INSERT INTO @M SELECT MAKH,DONVI,0,0,0,0,0 ,Q1,Q2,Q3,Q4,ISNULL(Q1,0) + ISNULL(Q2,0)+ ISNULL(Q3,0)+ ISNULL(Q4,0) ,0,0 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=" + nam + "  " + ((khachhang != null) ? string.Format(" AND MAKH IN({0})", string.Join(",", khachhang.Select(p => "'" + p + "'"))) : "") + " AND ISNULL(KT,0)=0 UPDATE @M SET TIEN1 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE HOADON.NGAYLAPHD BETWEEN '" + nam + "-01-01' AND '" + nam + "-03-31' AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,TIEN2 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE HOADON.NGAYLAPHD BETWEEN '" + nam + "-04-01' AND '" + nam + "-06-30' AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,TIEN3 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE HOADON.NGAYLAPHD BETWEEN '" + nam + "-07-01' AND '" + nam + "-09-30' AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,TIEN4 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE HOADON.NGAYLAPHD BETWEEN '" + nam + "-10-01' AND '" + nam + "-12-31' AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,ckqui= (SELECT ckqui FROM KT_TH.dbo.TBL_DOANHSOBBTT WHERE NAM=2018 AND DOANHSO= QNAM ) , ckdat= (SELECT ckdat FROM KT_TH.dbo.TBL_DOANHSOBBTT WHERE NAM=2018 AND DOANHSO= QNAM ) SELECT MAKH1 AS MAKH,DONVI ,ISNULL(TIEN1,0) AS DS1 ,ISNULL(TIEN2,0) AS DS2 ,ISNULL(TIEN3,0) AS DS3 ,ISNULL(TIEN4,0) AS DS4 ,ISNULL(TIEN1,0) + ISNULL(TIEN2,0) + ISNULL(TIEN3,0) +ISNULL(TIEN4,0) AS DS ,ISNULL(Q1,0) AS Q1 ,ISNULL(Q2,0) AS Q2 ,ISNULL(Q3,0) AS Q3 ,ISNULL(Q4,0) AS Q4 ,ISNULL(QNAM,0) AS KH ,(SELECT DOANHSOLONHON FROM KT_TH.dbo.TBL_DOANHSOBBTT WHERE DOANHSO =0 )/4 AS DOANHSOLONHONQUI ," + nam + " as NAM ,'" + CTKM + "' as MAKM ,ckqui ,ckdat ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC FROM @M,TBL_DANHMUCTIEUDEBAOCAO WHERE ISNULL(TIEN1,0)+ISNULL(TIEN2,0)+ISNULL(TIEN3,0)+ISNULL(TIEN4,0) +ISNULL(Q1,0)+ISNULL(Q2,0)+ ISNULL(Q3,0)+ ISNULL(Q4,0) <> 0";
            }
            else
            {
                if (Info.matinh == "ALL" && Info.maquan == "ALL" && Info.matdv == "ALL" && matinh == null && matdv == null && maquan == null)
                {
                    strcn = "declare @m table( makh1 varchar(20), donvi nvarchar(300), TIEN1 MONEY , TIEN2 MONEY , TIEN3 MONEY , TIEN4 MONEY , TIENNAM MONEY , Q1 MONEY , Q2 MONEY , Q3 MONEY , Q4 MONEY , QNAM MONEY , ckqui float, ckdat float) INSERT INTO @M SELECT MAKH,DONVI,0,0,0,0,0 ,Q1,Q2,Q3,Q4,ISNULL(Q1,0) + ISNULL(Q2,0)+ ISNULL(Q3,0)+ ISNULL(Q4,0) ,0,0 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=" + nam + "  AND ISNULL(KT,0)=0 UPDATE @M SET TIEN1 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE HOADON.NGAYLAPHD BETWEEN '" + nam + "-01-01' AND '" + nam + "-03-31' AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,TIEN2 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE HOADON.NGAYLAPHD BETWEEN '" + nam + "-04-01' AND '" + nam + "-06-30' AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,TIEN3 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE HOADON.NGAYLAPHD BETWEEN '" + nam + "-07-01' AND '" + nam + "-09-30' AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,TIEN4 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE HOADON.NGAYLAPHD BETWEEN '" + nam + "-10-01' AND '" + nam + "-12-31' AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,ckqui= (SELECT ckqui FROM KT_TH.dbo.TBL_DOANHSOBBTT WHERE NAM=2018 AND DOANHSO= QNAM ) , ckdat= (SELECT ckdat FROM KT_TH.dbo.TBL_DOANHSOBBTT WHERE NAM=2018 AND DOANHSO= QNAM ) SELECT MAKH1 AS MAKH,DONVI ,ISNULL(TIEN1,0) AS DS1 ,ISNULL(TIEN2,0) AS DS2 ,ISNULL(TIEN3,0) AS DS3 ,ISNULL(TIEN4,0) AS DS4 ,ISNULL(TIEN1,0) + ISNULL(TIEN2,0) + ISNULL(TIEN3,0) +ISNULL(TIEN4,0) AS DS ,ISNULL(Q1,0) AS Q1 ,ISNULL(Q2,0) AS Q2 ,ISNULL(Q3,0) AS Q3 ,ISNULL(Q4,0) AS Q4 ,ISNULL(QNAM,0) AS KH ,(SELECT DOANHSOLONHON FROM KT_TH.dbo.TBL_DOANHSOBBTT WHERE DOANHSO =0 )/4 AS DOANHSOLONHONQUI ," + nam + " as NAM ,'" + CTKM + "' as MAKM ,ckqui ,ckdat ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC FROM @M,TBL_DANHMUCTIEUDEBAOCAO WHERE ISNULL(TIEN1,0)+ISNULL(TIEN2,0)+ISNULL(TIEN3,0)+ISNULL(TIEN4,0) +ISNULL(Q1,0)+ISNULL(Q2,0)+ ISNULL(Q3,0)+ ISNULL(Q4,0) <> 0";
                }
                else
                {
                    var listmakh = new List<string>();
                    foreach (var i in soso)
                    {
                        listmakh.AddRange(GetMAKH(i, Info, matinh, matdv, maquan));
                    }
                    //strcn = "EXEC TONGHOP_BBTT_MAKH_2 '" + CTKM + "'," + nam + ",'" + MAKH + "'";
                    strcn = "declare @m table( makh1 varchar(20), donvi nvarchar(300), TIEN1 MONEY , TIEN2 MONEY , TIEN3 MONEY , TIEN4 MONEY , TIENNAM MONEY , Q1 MONEY , Q2 MONEY , Q3 MONEY , Q4 MONEY , QNAM MONEY , ckqui float, ckdat float) INSERT INTO @M SELECT MAKH,DONVI,0,0,0,0,0 ,Q1,Q2,Q3,Q4,ISNULL(Q1,0) + ISNULL(Q2,0)+ ISNULL(Q3,0)+ ISNULL(Q4,0) ,0,0 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=" + nam + " " + string.Format(" AND MAKH IN({0})", string.Join(",", listmakh.Select(p => "'" + p + "'"))) + " AND ISNULL(KT,0)=0 UPDATE @M SET TIEN1 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE HOADON.NGAYLAPHD BETWEEN '" + nam + "-01-01' AND '" + nam + "-03-31' AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,TIEN2 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE HOADON.NGAYLAPHD BETWEEN '" + nam + "-04-01' AND '" + nam + "-06-30' AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,TIEN3 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE HOADON.NGAYLAPHD BETWEEN '" + nam + "-07-01' AND '" + nam + "-09-30' AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,TIEN4 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE HOADON.NGAYLAPHD BETWEEN '" + nam + "-10-01' AND '" + nam + "-12-31' AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,ckqui= (SELECT ckqui FROM KT_TH.dbo.TBL_DOANHSOBBTT WHERE NAM=2018 AND DOANHSO= QNAM ) , ckdat= (SELECT ckdat FROM KT_TH.dbo.TBL_DOANHSOBBTT WHERE NAM=2018 AND DOANHSO= QNAM ) SELECT MAKH1 AS MAKH,DONVI ,ISNULL(TIEN1,0) AS DS1 ,ISNULL(TIEN2,0) AS DS2 ,ISNULL(TIEN3,0) AS DS3 ,ISNULL(TIEN4,0) AS DS4 ,ISNULL(TIEN1,0) + ISNULL(TIEN2,0) + ISNULL(TIEN3,0) +ISNULL(TIEN4,0) AS DS ,ISNULL(Q1,0) AS Q1 ,ISNULL(Q2,0) AS Q2 ,ISNULL(Q3,0) AS Q3 ,ISNULL(Q4,0) AS Q4 ,ISNULL(QNAM,0) AS KH ,(SELECT DOANHSOLONHON FROM KT_TH.dbo.TBL_DOANHSOBBTT WHERE DOANHSO =0 )/4 AS DOANHSOLONHONQUI ," + nam + " as NAM ,'" + CTKM + "' as MAKM ,ckqui ,ckdat ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC FROM @M,TBL_DANHMUCTIEUDEBAOCAO WHERE ISNULL(TIEN1,0)+ISNULL(TIEN2,0)+ISNULL(TIEN3,0)+ISNULL(TIEN4,0) +ISNULL(Q1,0)+ISNULL(Q2,0)+ ISNULL(Q3,0)+ ISNULL(Q4,0) <> 0";
                }
            }
            var DATAX = new List<DULIEUBAOCAO24>();
            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    if (x == "TT423")
                    {
                        DATAX.AddRange(BAOCAOCHINHANH24(queryCN.SingleOrDefault(n => n.macn == x).data, strcn.Replace("AND ISNULL(ck,0) + ISNULL(CKVUOT,0) + ISNULL(ckdat,0) > 0", "and Isnull(q1, 0) + Isnull(q2, 0) + Isnull(q3, 0) + Isnull(q4, 0) > 0")));
                    }
                    else if (x == "GL")
                    {
                        DATAX.AddRange(BAOCAOCHINHANH24(queryCN.SingleOrDefault(n => n.macn == x).data, strcn.Replace("AND ISNULL(KT,0)=0", " ")));
                    }
                    else
                    {
                        DATAX.AddRange(BAOCAOCHINHANH24(queryCN.SingleOrDefault(n => n.macn == x).data, strcn));
                    }
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {

                    DATAX.AddRange(BAOCAOCUAHANG24(queryCH.SingleOrDefault(n => n.macn == x).data, strcn.Replace("dta_", "").Replace("TBL_DANHMUCTIEUDEBAOCAO WHERE", "TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE")));

                }
            }

            return DATAX;
        }
    
        public List<DULIEUBAOCAO0> DATABAOCAO0(List<string> mapl,List<string> soso, DateTime tungay, DateTime denngay, string phanloai, List<string> phanloaikhachhang, List<string> nhomhang, List<string> sanpham, List<string> khuvuc, List<string> hopdong, List<string> makm, List<string> mactht, TBL_DANHMUCNGUOIDUNG Info)
        {
            //var Info = GetInfo();
            //String CN
            string strcn = "seleCT HOADON.MaPL,  sum(  ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)) as TONGTIEN_CT_HOADON   ,  sum( round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*cast(TYLECK as money) /100,0)) as TIENCK ,TBL_MIEN.MIEN as chuky1 ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC from TBL_MIEN, TBL_DANHMUCTIEUDEBAOCAO, DTA_CT_HOADON_XUAT CT LEFT JOIN   TBL_DANHMUCHANGHOA ON CT.mahh = TBL_DANHMUCHANGHOA.mahh, DTA_HOADON_XUAT HOADON   LEFT JOIN   TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MaPL IN ('BAN','XK') AND HOADON.MACH = CT.MACH AND CT.KT = 1";
            string strch = "seleCT HOADON.MaPL,  sum(  ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)) as TONGTIEN_CT_HOADON   ,  sum( round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*cast(TYLECK as money) /100,0)) as TIENCK ,TBL_MIEN.MIEN as chuky1 ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC from TBL_MIEN,tieude TBL_DANHMUCTIEUDEBAOCAO, CT_HOADON_XUAT CT  LEFT JOIN  DM_HANGHOA ON CT.mahh = DM_HANGHOA.mahh, HOADON_XUAT  HOADON LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.MaPL IN ('BAN','XK') AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1 ";
            string strnew = "select SUM(ISNULL(CAST(TIENCHIETKHAU   AS MONEY ),0)) AS TIENCK,substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) AS MaPL,SUM(ISNULL(CAST(TIENBAN   AS MONEY), 0)) AS TONGTIEN_CT_HOADON,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_MIEN.MIEN AS chuky1 from dtasoluong, dtaDinhKhoan, dclChiTietHangHoa, dclChiTietKhachHang, dclDanhSachDonViTinh, tbl_danhmuctieudebaocao, tbl_mien, KT_TH.DBO.TBL_DANHMUCKHACHHANG right join TBL_DANHMUCCUAHANG on KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = TBL_DANHMUCCUAHANG.MaCH right join dtaChungTu ON KT_TH.DBO.TBL_DANHMUCKHACHHANG.makh = CAST(dtaChungTu.KhachHangID as varchar) where dtasoluong.dinhkhoanid = dtaDinhKhoan.CapDKID And dclChiTietKhachHang.TaiKhoanID = dtaChungTu.KHACHHANGID And dtaDinhKhoan.chungtuid = dtaChungTu.chungtuid and dtaDinhKhoan.IDTaiKhoanCo = dclChiTietHangHoa.TaiKhoanID and dclDanhSachDonViTinh.DonViTinhID = dclChiTietHangHoa.DonViTinhID  AND substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) = '632' AND dtaChungTu.ngaychungtu between '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "'";
            if (mapl != null)
            {
                strcn = strcn + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloai != "ALL")
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloaikhachhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            }
            if (nhomhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DM_HANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (hopdong != null)
            {
                List<string> kh = new List<string>();
                List<string> hd = new List<string>();
                foreach (var i in hopdong)
                {
                    var k = i.Split('~').ToList();
                    hd.Add(k.First());
                    kh.Add(k.Last());
                }
                strcn = strcn + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MAKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MaKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (sanpham != null)
            {
                strcn = strcn + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND replace(dclChiTietHangHoa.MaCap, ' ', '') IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
            }
            if (Info.matinh != "ALL" && khuvuc == null)
            {
                var matinh = Info.matinh.Split(',').ToList();
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND cast(dtaChungTu.KHACHHANGID as varchar) IN (select makh from KT_TH.DBO.TBL_DANHMUCKHACHHANG where MACH=@MACN AND matinh IN ({0}))", string.Join(",", matinh.Select(p => "'" + p + "'")));
            }
            else if (khuvuc != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", khuvuc.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", khuvuc.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND cast(dtaChungTu.KHACHHANGID as varchar) IN (select makh from KT_TH.DBO.TBL_DANHMUCKHACHHANG where MACH=@MACN AND matinh IN ({0}))", string.Join(",", khuvuc.Select(p => "'" + p + "'")));
            }
            if (Info.maquan != "ALL")
            {
                var maquan = Info.maquan.Split(',').ToList();
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", maquan.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", maquan.Select(p => "'" + p + "'")));

            }
            if (makm != null)
            {
                strcn = strcn + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
            }
            if (mactht != null)
            {

                strcn = strcn + string.Format(" AND CT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));

            }
            if (Info.matdv != "ALL")
            {
                var matdv = Info.matdv.Split(',').ToList();
                strcn = strcn + string.Format(" AND HOADON.MaTDV IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND   TBL_DANHMUCKHACHHANG.MATDV IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            strcn = strcn + " GROUP BY  TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc , HOADON.MaPL";
            strch = strch + " GROUP BY HOADON.MaPL, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc";
            strnew = strnew + " group by substring(dtaDinhKhoan.TaiKhoanNo, 1, 3),tbl_danhmuctieudebaocao.tendvbc, tbl_mien.mien";
            var DATAX = new List<DULIEUBAOCAO0>();

            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(BAOCAOCHINHANH0(queryCN.SingleOrDefault(n => n.macn == x).data, strcn));

                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(BAOCAOCUAHANG0(queryCH.SingleOrDefault(n => n.macn == x).data, strch));

                }

            }
            return DATAX;
        }
        // CÁC HÀM
        public List<DULIEUBAOCAO> BAOCAOCHINHANH(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO>(str).ToList();
            return All;
        }
        // Chưa sửa
        public List<DULIEUBAOCAO0> BAOCAOCHINHANH0(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO0>(str).ToList();
            return All;
        }
        public List<sp_INTONGHOPCONGNOCHITIET_IN_Result> BAOCAOCHINHANH1(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<sp_INTONGHOPCONGNOCHITIET_IN_Result>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO2> BAOCAOCHINHANH2(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO2>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO7> BAOCAOCHINHANH7(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO7>(str).ToList();
            return All;
        }

        public List<DULIEUBAOCAO24> BAOCAOCHINHANH24(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO24>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO26> BAOCAOCUAHANG26(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO26>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO24> BAOCAOCUAHANG24(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO24>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO16> BAOCAOCHINHANH16(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO16>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO16> BAOCAOCUAHANG16(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO16>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO16> BAOCAOMIENBAC16(KT_TBEntities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO16>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO26> BAOCAOCHINHANH26(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO26>(str).ToList();
            return All;
        }
        public List<sp_INSOCTIET_CONGNO_Result> BAOCAOCUAHANG1(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<sp_INSOCTIET_CONGNO_Result>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO5> DATABAOCAO5(List<string> soso, DateTime tungay, DateTime denngay, string phanloai, List<string> phanloaikhachhang, List<string> nhomhang, List<string> sanpham, List<string> khuvuc, List<string> hopdong, TBL_DANHMUCNGUOIDUNG Info)
        {
            string strch = "  SELECT TBL_DANHMUCDONVI.tentinh AS NHOM ,SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0)) -  sum(ROUND(round(cast(DTA_CT_HOADON_XUAT.soluong as money)*cast(DTA_CT_HOADON_XUAT.dongia as money),0)*cast(DTA_CT_HOADON_XUAT.tyleck as money) /100,0)) AS TIEN ,SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0)) AS SOLUONG ,SUM(ROUND(round(cast(DTA_CT_HOADON_XUAT.soluong as money)*cast(DTA_CT_HOADON_XUAT.dongia as money),0)*cast(DTA_CT_HOADON_XUAT.tyleck as money) /100,0))  AS DONGIA  ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC AS TENHH,'" + tungay.ToString("dd/MM/yyyy") + "' as tuthang,'" + denngay.ToString("dd/MM/yyyy") + "' as thang, TBL_DANHMUCKHACHHANG.MATINH AS MAQUAY,TBL_MIEN.MIEN AS MAHH  FROM TBL_MIEN,CT_HOADON_XUAT DTA_CT_HOADON_XUAT LEFT JOIN  DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH ,HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, DM_KHACHHANG_PTTT A LEFT JOIN DS_TINH TBL_DANHMUCDONVI ON A .maTINH=TBL_DANHMUCDONVI .maTINH,TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD  AND A.MAKH=TBL_DANHMUCKHACHHANG.MAKH AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  and DTA_CT_HOADON_XUAT.kt=1 AND DTA_HOADON_XUAT.NGAYLAPHD between '" + tungay.ToString("MM/dd/yyyy") + "'  and '" + denngay.ToString("MM/dd/yyyy") + "' ";
            var strcn = "  SELECT TBL_DANHMUCDONVI.tentinh AS NHOM,SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0))  -  sum(ROUND(round(cast(DTA_CT_HOADON_XUAT.soluong as money)*cast(DTA_CT_HOADON_XUAT.dongia as money),0)*cast(DTA_CT_HOADON_XUAT.tyleck as money) /100,0))  AS TIEN ,SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0)) AS SOLUONG ,SUM(ROUND(round(cast(DTA_CT_HOADON_XUAT.soluong as money)*cast(DTA_CT_HOADON_XUAT.dongia as money),0)*cast(DTA_CT_HOADON_XUAT.tyleck as money) /100,0))  AS DONGIA  ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC AS TENHH,'" + tungay.ToString("dd/MM/yyyy") + "' as tuthang,'" + denngay.ToString("dd/MM/yyyy") + "' as thang, TBL_DANHMUCKHACHHANG.MATINH AS MAQUAY,TBL_MIEN.MIEN AS MAHH FROM   TBL_MIEN, DTA_CT_HOADON_XUAT LEFT JOIN  TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH ,DTA_HOADON_XUAT LEFT JOIN  TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh,  TBL_DANHMUCKHACHHANG AS A  LEFT JOIN  TBL_DANHMUCDONVI ON A.maTINH=TBL_DANHMUCDONVI .maTINH ,TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD  AND A.MAKH=TBL_DANHMUCKHACHHANG.MAKH AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  and DTA_CT_HOADON_XUAT.kt=1  AND DTA_HOADON_XUAT.NGAYLAPHD between '" + tungay.ToString("MM/dd/yyyy") + "'  and '" + denngay.ToString("MM/dd/yyyy") + "' ";

            string strnew = "SELECT SUM(ISNULL(CAST(dtasoluong.SOLUONG AS MONEY), 0)) AS soluong, SUM(CAST(dtasoluong.GiaBan AS MONEY)*CAST(dtasoluong.SOLUONG AS MONEY))/SUM(CAST(dtasoluong.SOLUONG AS MONEY)) AS dongia, SUM(ISNULL(CAST(TIENBAN AS MONEY), 0)) AS TIEN, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC as tenhh, TBL_MIEN.MIEN as mahh, KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh AS MAQUAY FROM dtasoluong, dtaDinhKhoan, dclChiTietHangHoa, dclChiTietKhachHang, dclDanhSachDonViTinh, tbl_danhmuctieudebaocao, tbl_mien, KT_TH.DBO.TBL_DANHMUCKHACHHANG RIGHT JOIN TBL_DANHMUCCUAHANG ON KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = TBL_DANHMUCCUAHANG.MaCH RIGHT JOIN dtaChungTu ON KT_TH.DBO.TBL_DANHMUCKHACHHANG.makh = CAST(dtaChungTu.KhachHangID AS varchar) WHERE dtasoluong.dinhkhoanid = dtaDinhKhoan.CapDKID AND dclChiTietKhachHang.TaiKhoanID = dtaChungTu.KHACHHANGID AND dtaDinhKhoan.chungtuid = dtaChungTu.chungtuid AND dtaDinhKhoan.IDTaiKhoanCo = dclChiTietHangHoa.TaiKhoanID AND dclDanhSachDonViTinh.DonViTinhID = dclChiTietHangHoa.DonViTinhID AND dtaChungTu.KHACHHANGID IN(SELECT dclChiTietKhachHang.TaiKhoanID FROM dclChiTietKhachHang) AND substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) = '632' AND dtaChungTu.ngaychungtu BETWEEN '" + tungay.ToString("MM/dd/yyyy") + "' AND '" + denngay.ToString("MM/dd/yyyy") + "' ";
            if (phanloai != "ALL")
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloaikhachhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            }
            if (nhomhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCHANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (hopdong != null)
            {
                List<string> kh = new List<string>();
                List<string> hd = new List<string>();
                foreach (var i in hopdong)
                {
                    var k = i.Split('~').ToList();
                    hd.Add(k.First());
                    kh.Add(k.Last());
                }
                strcn = strcn + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MAKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MaKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (sanpham != null)
            {
                strcn = strcn + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND replace(dclChiTietHangHoa.MaCap, ' ', '') IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
            }
            if (Info.matinh != "ALL" && khuvuc == null)
            {
                var matinh = Info.matinh.Split(',').ToList();
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND cast(dtaChungTu.KHACHHANGID as varchar) IN (select makh from KT_TH.DBO.TBL_DANHMUCKHACHHANG where MACH=@MACN AND matinh IN ({0}))", string.Join(",", matinh.Select(p => "'" + p + "'")));
            }
            else if (khuvuc != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", khuvuc.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", khuvuc.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND cast(dtaChungTu.KHACHHANGID as varchar) IN (select makh from KT_TH.DBO.TBL_DANHMUCKHACHHANG where MACH=@MACN AND matinh IN ({0}))", string.Join(",", khuvuc.Select(p => "'" + p + "'")));
            }
            if (Info.maquan != "ALL")
            {
                var maquan = Info.maquan.Split(',').ToList();
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", maquan.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", maquan.Select(p => "'" + p + "'")));

            }
            if (Info.matdv != "ALL")
            {
                var matdv = Info.matdv.Split(',').ToList();
                strcn = strcn + string.Format(" AND HOADON.MaTDV IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND   TBL_DANHMUCKHACHHANG.MATDV IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            strcn = strcn + " GROUP BY  TBL_MIEN.MIEN, TBL_DANHMUCKHACHHANG.MATINH,TBL_DANHMUCDONVI.tentinh,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC HAVING SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0)) <>0  ";
            strch = strch + " GROUP BY  TBL_MIEN.MIEN, TBL_DANHMUCKHACHHANG.MATINH,TBL_DANHMUCDONVI.tentinh,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC HAVING SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0)) <>0  ";
            strnew = strnew + " GROUP BY tbl_danhmuctieudebaocao.tendvbc, tbl_mien.mien, TBL_DANHMUCCUAHANG.MACH, KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh ";
            var DATAX = new List<DULIEUBAOCAO5>();

            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(BAOCAOCHINHANH5(queryCN.SingleOrDefault(n => n.macn == x).data, strcn));

                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(BAOCAOCUAHANG5(queryCH.SingleOrDefault(n => n.macn == x).data, strch));

                }

            }
            return DATAX;
        }
        public List<DULIEUBAOCAO5> BAOCAOCHINHANH5(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO5>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO5> BAOCAOCUAHANG5(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO5>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO5> BAOCAOMIENBAC5(KT_TBEntities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO5>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO2> BAOCAOCUAHANG2(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO2>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO7> BAOCAOCUAHANG7(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO7>(str).ToList();
            return All;
        }
        public List<sp_IN_TONGHOP_CONGNO_IN_Result> BAOCAOCHINHANH3(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<sp_IN_TONGHOP_CONGNO_IN_Result>(str).ToList();
            return All;
        }
        public List<sp_IN_TONGHOP_CONGNO_IN_Result> BAOCAOCUAHANG3(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<sp_IN_TONGHOP_CONGNO_IN_Result>(str).ToList();
            return All;
        }
        public List<sp_IN_TONGHOP_CONGNO_IN_Result> BAOCAOCUAHANG3TT423(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<sp_IN_TONGHOP_CONGNO_IN_ResultTT423>(str).ToList();
            return All.Select(n => new sp_IN_TONGHOP_CONGNO_IN_Result { COCUOIKY = (double?)n.COCUOIKY, CODAUKY = (double?)n.CODAUKY, DENNGAY = n.DENNGAY, MAKH = n.MAKH, matdv = n.matdv, matinh = n.matinh, chuky1 = n.chuky1, chuky2b = n.chuky2b, chuky3 = n.chuky3, MATK = n.MATK, ngayin = n.ngayin, NOCUOIKY = (double?)n.NOCUOIKY, NODAUKY = (double?)n.NODAUKY, NOIDUNG = n.NOIDUNG, PSCO = (double?)n.PSCO, PSNO = (double?)n.PSNO, tendvbc = n.tendvbc, tinh = n.tinh, TUNGAY = n.TUNGAY }).ToList();
        }
        public List<DULIEUBAOCAO0> BAOCAOCUAHANG0(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO0>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO0> BAOCAOMIENBAC0(KT_TBEntities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO0>(str).ToList();
            return All;
        }
        // Chưa sửa
        public List<DULIEUBAOCAO> BAOCAOCUAHANG(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO> BAOCAOMIENBAC(KT_TBEntities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO>(str).ToList();
            return All;
        }
        public List<string> GetMAKH(string ChiNhanhId, TBL_DANHMUCNGUOIDUNG Info, List<string> matinh, List<string> matdv, List<string> maquan)
        {
            var listpl = Info.phanloai.Split(',').ToList();
            string strcn = "SELECT makh AS MAKH, donvi AS DONVI FROM TBL_DANHMUCKHACHHANG";
            string strch = "SELECT MaKH AS MAKH, DonVi AS DONVI FROM DM_KHACHHANG_PTTT";
            string strmb = "select KT_TH.DBO.TBL_DANHMUCKHACHHANG.makh as MAKH,KT_TH.DBO.TBL_DANHMUCKHACHHANG.donvi as DONVI from KT_TH.DBO.TBL_DANHMUCKHACHHANG where KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = (SELECT MACH FROM TBL_DANHMUCCUAHANG)";
            strcn = strcn + string.Format(" WHERE phanloai IN ({0})", string.Join(",", listpl.Select(p => "'" + p + "'")));
            strch = strch + string.Format(" WHERE PHANLOAI IN ({0})", string.Join(",", listpl.Select(p => "'" + p + "'")));
            strmb = strmb + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", string.Join(",", listpl.Select(p => "'" + p + "'")));
            if (matinh != null)
            {
                strcn = strcn + string.Format(" AND matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND MaTinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strmb = strmb + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
            }
            else if (Info.matinh != "ALL")
            {
                var listmt = Info.matinh.Split(',').ToList();
                strcn = strcn + string.Format(" AND matinh IN ({0})", string.Join(",", listmt.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND MaTinh IN ({0})", string.Join(",", listmt.Select(p => "'" + p + "'")));
                strmb = strmb + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", listmt.Select(p => "'" + p + "'")));
            }
            if (matdv != null)
            {
                strcn = strcn + string.Format(" AND matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND MaTDV IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            else if (Info.matdv != "ALL")
            {
                var listtdv = Info.matdv.Split(',').ToList();
                strcn = strcn + string.Format(" AND matdv IN ({0})", string.Join(",", listtdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND MaTDV IN ({0})", string.Join(",", listtdv.Select(p => "'" + p + "'")));
            }
            if (maquan != null)
            {
                strcn = strcn + string.Format(" AND quanhuyen IN ({0})", string.Join(",", maquan.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND quanhuyen IN ({0})", string.Join(",", maquan.Select(p => "'" + p + "'")));
            }
            else if (Info.maquan != "ALL")
            {
                var listquan = Info.maquan.Split(',').ToList();
                strcn = strcn + string.Format(" AND quanhuyen IN ({0})", string.Join(",", listquan.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND quanhuyen IN ({0})", string.Join(",", listquan.Select(p => "'" + p + "'")));
            }
            List<ListKhachHang> data = new List<ListKhachHang>();
            if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
            {
                data = DULIEUKHACHHANG(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data, strcn).ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
            {
                data = DULIEUCUAHANGKHACHHANG(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data, strch).ToList();
            }

            return data.OrderBy(n => n.MAKH).Select(n => n.MAKH).ToList();
        }
        public TBL_DANHMUCNGUOIDUNG GetInfo()
        {
            TBL_DANHMUCNGUOIDUNG abc = new TBL_DANHMUCNGUOIDUNG();
            abc = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name.ToString());
            return abc;
        }
        [HttpPost]
        public List<ListKhachHang> GetKhachHangBC11(List<string> soso, List<string> trinhduocvien)
        {
            var Info = GetInfo();
            string strcn = string.Format("SELECT makh AS MAKH FROM TBL_DANHMUCKHACHHANG where matdv IN ({0})", string.Join(",", trinhduocvien.Select(p => "'" + p + "'")));
            string strch = string.Format("SELECT MaKH AS MAKH FROM DM_KHACHHANG_PTTT where MaTDV IN ({0})", string.Join(",", trinhduocvien.Select(p => "'" + p + "'")));
            if (Info.matinh != "ALL")
            {
                var listmt = Info.matinh.Split(',').ToList();
                strcn = strcn + string.Format(" AND matinh IN ({0})", string.Join(",", listmt.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND MaTinh IN ({0})", string.Join(",", listmt.Select(p => "'" + p + "'")));
            }
            if (Info.phanloai != "ETC,OTC")
            {
                var listpl = Info.phanloai.Split(',').ToList();
                strcn = strcn + string.Format(" AND phanloai IN ({0})", string.Join(",", listpl.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND PHANLOAI IN ({0})", string.Join(",", listpl.Select(p => "'" + p + "'")));
            }
            List<ListKhachHang> data = new List<ListKhachHang>();
            foreach (var ChiNhanhId in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data = DULIEUKHACHHANG(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data, strcn).ToList();
                }
                else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data = DULIEUCUAHANGKHACHHANG(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data, strch).ToList();
                }
            }
            return data.OrderBy(n => n.MAKH).ToList();
        }
        public List<sp_INTONGHOPCONGNOCHITIET_IN_Result> DATABAOCAO1(List<string> soso, DateTime tungay, DateTime denngay, List<string> khachhang, List<string> khuvuc, List<string> tdv, List<string> quanhuyen)
        {
            string select = "";
            string select1 = "";
            if (khachhang != null)
            {
                //var MAKH = String.Join(",", khachhang.ToArray());
                select = string.Format("({0})", string.Join(",", khachhang.Select(p => "'" + p + "'")));
                select1 = "(SELECT VAL FROM FUN_CATCHUOI('" + String.Join(",", khachhang.ToArray()) + "'))";
                //select1 = " (SELECT VAL FROM FUN_CATCHUOI('" + MAKH + "')) ";
            }
            else if (tdv != null)
            {
                select = string.Format(" (SELECT makh from TBL_DANHMUCKHACHHANG where matdv IN ({0})) ", string.Join(",", tdv.Select(p => "'" + p + "'")));
                select1 = string.Format(" (SELECT makh from TBL_DANHMUCKHACHHANG where matdv IN ({0})) ", string.Join(",", tdv.Select(p => "'" + p + "'")));
            }
            else if (tdv == null && quanhuyen != null)
            {
                select = string.Format(" (SELECT makh from TBL_DANHMUCKHACHHANG where quanhuyen IN ({0})) ", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
                select1 = string.Format(" (SELECT makh from TBL_DANHMUCKHACHHANG where quanhuyen IN ({0})) ", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
            }
            else if (tdv == null && quanhuyen == null && khuvuc != null)
            {
                select = string.Format(" (SELECT makh from TBL_DANHMUCKHACHHANG where matinh IN ({0})) ", string.Join(",", khuvuc.Select(p => "'" + p + "'")));
                select1 = string.Format(" (SELECT makh from TBL_DANHMUCKHACHHANG where matinh IN ({0})) ", string.Join(",", khuvuc.Select(p => "'" + p + "'")));
            }
            //TT423
            //TT423
            string strcn = "";
            strcn = strcn + "DECLARE @retFindReports TABLE ";
            strcn = strcn + "( makh varchar(20) ";
            strcn = strcn + ",NODAUNAM MONEY ";
            strcn = strcn + ",CODAUNAM MONEY ";
            strcn = strcn + ",PSNODAUNAM MONEY ";
            strcn = strcn + ",PSCODAUNAM MONEY ";
            strcn = strcn + ",NODAUKY MONEY ";
            strcn = strcn + ",CODAUKY MONEY ";
            strcn = strcn + ",PSNO MONEY ";
            strcn = strcn + ",PSCO MONEY ";
            strcn = strcn + ",NOCUOIKY MONEY ";
            strcn = strcn + ",COCUOIKY MONEY) ";

            //ĐẦU NĂM
            strcn = strcn + "INSERT INTO  @retFindReports(MAKH,NODAUNAM,CODAUNAM) ";
            strcn = strcn + "SELECT MATK,SUM(DUNO),SUM(DUCO) ";
            strcn = strcn + "FROM DTA_DAUKYTAIKHOAN ";
            strcn = strcn + "WHERE NAM ='" + tungay.Year + "'";
            strcn = strcn + "AND MATK IN " + select;
            strcn = strcn + "GROUP BY MATK ";

            //PS NO DAU NAM
            strcn = strcn + "INSERT INTO  @retFindReports(MAKH,PSNODAUNAM,PSCODAUNAM) ";
            strcn = strcn + "SELECT  THU.MAKHN,SUM(CAST(THU.TIEN AS MONEY)),0 ";
            strcn = strcn + "FROM DTA_DINHKHOAN  THU ";
            strcn = strcn + "WHERE   NGAY BETWEEN CAST( '01/01/" + tungay.Year + "' AS SMALLDATETIME)  ";
            strcn = strcn + "and dbo.funNgaycuoiThang ('" + tungay.ToString("MM/dd/yyyy") + "') ";
            strcn = strcn + "AND THU.MAKHN IN " + select;
            strcn = strcn + "AND THU.KT=1 ";
            strcn = strcn + "GROUP BY THU.MAKHN ";

            // PS CO DAU NAM

            strcn = strcn + "INSERT INTO @retFindReports(MAKH,PSNODAUNAM,PSCODAUNAM) ";
            strcn = strcn + "SELECT    MAKHC,0,SUM(CAST(TIEN AS MONEY)) ";
            strcn = strcn + "FROM DTA_DINHKHOAN  THU ";
            strcn = strcn + "WHERE   NGAY BETWEEN CAST( '01/01/" + tungay.Year + "' AS SMALLDATETIME) ";
            strcn = strcn + "and dbo.funNgaycuoiThang ('" + tungay.ToString("MM/dd/yyyy") + "') ";
            strcn = strcn + "AND THU.MAKHC IN " + select;
            strcn = strcn + "AND THU.KT=1 ";
            strcn = strcn + "GROUP BY THU.MAKHC ";

            // PHAT SINH 
            strcn = strcn + "INSERT INTO  @retFindReports (MAKH,PSNO,PSCO) ";
            strcn = strcn + " SELECT    MAKHC,0,sum(CAST(TIEN AS MONEY)) ";
            strcn = strcn + " FROM DTA_DINHKHOAN";
            strcn = strcn + " WHERE   NGAY BETWEEN  '" + tungay.ToString("MM/dd/yyyy") + "' AND '" + denngay.ToString("MM/dd/yyyy") + "'";
            strcn = strcn + " AND MAKHC IN " + select;
            strcn = strcn + " AND KT=1";
            strcn = strcn + " group by MAKHC";

            strcn = strcn + " INSERT INTO  @retFindReports (MAKH,PSNO,PSCO)";
            strcn = strcn + " SELECT   MAKHN,SUM(CAST(TIEN AS MONEY)),0";
            strcn = strcn + " FROM DTA_DINHKHOAN";
            strcn = strcn + " WHERE NGAY BETWEEN '" + tungay.ToString("MM/dd/yyyy") + "' AND '" + denngay.ToString("MM/dd/yyyy") + "'";
            strcn = strcn + " AND MAKHN IN " + select;
            strcn = strcn + " AND KT=1";
            strcn = strcn + " group by MAKHN";

            //KHAI BÁO TỔNG HỢP

            strcn = strcn + " DECLARE @TBL_IN_CONGNOTH TABLE( ";
            strcn = strcn + " MAKH VARCHAR(20)";
            strcn = strcn + " ,DAUNAM_NO FLOAT DEFAULT  NULL ,TENKH NVARCHAR(200)";
            strcn = strcn + " ,DAUNAM_CO FLOAT";
            strcn = strcn + " ,PSNO_0 FLOAT";
            strcn = strcn + " ,PSCO_0 FLOAT";
            strcn = strcn + " ,DKNO FLOAT";
            strcn = strcn + " ,DKCO FLOAT";
            strcn = strcn + " ,PSNO FLOAT";
            strcn = strcn + " ,PSCO FLOAT";
            strcn = strcn + " ,CKNO FLOAT";
            strcn = strcn + " ,CKCO FLOAT)";

            strcn = strcn + " insert into @TBL_IN_CONGNOTH(makh,daunam_no,daunam_co,psno_0,psco_0,dkno,dkco,psno,psco)";
            strcn = strcn + " select makh";
            strcn = strcn + " ,sum(ISNULL(NODAUNAM,0)),sum(ISNULL(CODAUNAM,0))";
            strcn = strcn + " ,sum(ISNULL(PSNODAUNAM,0)),sum(ISNULL(PSCODAUNAM,0))";
            strcn = strcn + " ,sum(ISNULL(NODAUKY,0)),sum(ISNULL(CODAUKY,0))";
            strcn = strcn + " ,sum(ISNULL(PSNO,0)),sum(ISNULL(PSCO,0))";
            strcn = strcn + " from @retFindReports";
            strcn = strcn + " group by makh";

            strcn = strcn + " update @TBL_IN_CONGNOTH";
            strcn = strcn + " set dkno= daunam_no - daunam_co + psno_0 - psco_0 ";

            strcn = strcn + " update @TBL_IN_CONGNOTH";
            strcn = strcn + " set ckno= dkno +  psno - psco";

            strcn = strcn + " update @TBL_IN_CONGNOTH";
            strcn = strcn + " set dkco=-dkno,dkno=0";
            strcn = strcn + " where dkno<0";

            strcn = strcn + " update @TBL_IN_CONGNOTH";
            strcn = strcn + " set ckco=-ckno,ckno=0";
            strcn = strcn + " where ckno<0";

            strcn = strcn + " delete @TBL_IN_CONGNOTH";
            strcn = strcn + " where (isnull(dkno,0) + isnull(dkco,0) +isnull(psno,0) +isnull(psco,0) +isnull(Ckno,0)  + isnull(Ckco,0) )=0";

            strcn = strcn + " DECLARE @thongtin TABLE(";
            strcn = strcn + " MAKH1 varchar(20),";
            strcn = strcn + " ID INT,";
            strcn = strcn + " SCT VARCHAR(20)";
            strcn = strcn + " ,NGAY SMALLDATETIME";
            strcn = strcn + " ,NOIDUNG NVARCHAR(200)";
            strcn = strcn + " ,TK VARCHAR(10)";
            strcn = strcn + " ,NODAUKY MONEY DEFAULT 0";
            strcn = strcn + " ,CODAUKY MONEY  DEFAULT 0";
            strcn = strcn + " ,PSNO MONEY   DEFAULT 0";
            strcn = strcn + " ,PSCO MONEY    DEFAULT 0";
            strcn = strcn + " ,NOCUOIKY MONEY";
            strcn = strcn + " ,COCUOIKY MONEY";
            strcn = strcn + " ,TNODAUKY MONEY";
            strcn = strcn + " ,TCODAUKY MONEY";
            strcn = strcn + " ,TPSNO MONEY";
            strcn = strcn + " ,TPSCO MONEY";
            strcn = strcn + " ,TNOCUOIKY MONEY";
            strcn = strcn + " ,TCOCUOIKY MONEY";
            strcn = strcn + " ,sct_vat varchar(10)";
            strcn = strcn + " ,ngay_vat smalldatetime ";
            strcn = strcn + " ,DONVI NVARCHAR(250)) ";

            strcn = strcn + " INSERT INTO  @thongtin ";
            strcn = strcn + " SELECT MAKHC, ID,SCT,NGAY,ND,TKN,";
            strcn = strcn + " 0,0,";
            strcn = strcn + " 0,CAST(TIEN AS MONEY)";
            strcn = strcn + " ,0,0";
            strcn = strcn + " ,0,0,0,0,0,0";
            strcn = strcn + " ,sct_vat,ngay_vat,''";
            strcn = strcn + " FROM DTA_DINHKHOAN ";
            strcn = strcn + " WHERE   NGAY BETWEEN  '" + tungay.ToString("MM/dd/yyyy") + "' AND '" + denngay.ToString("MM/dd/yyyy") + "'";
            strcn = strcn + " AND MAKHC IN " + select;
            strcn = strcn + " AND KT=1";
            strcn = strcn + " AND CAST(TIEN AS MONEY) <>0";

            strcn = strcn + " insert into @thongtin(makh1) ";
            strcn = strcn + select1;

            strcn = strcn + " INSERT INTO  @thongtin ";
            strcn = strcn + " SELECT  MAKHN,ID, SCT,NGAY,ND,TKC,0,0,CAST(TIEN AS MONEY),0 ";
            strcn = strcn + " ,0,0";
            strcn = strcn + " ,0,0,0,0,0,0";
            strcn = strcn + " ,sct_vat,ngay_vat,''";
            strcn = strcn + " FROM DTA_DINHKHOAN";
            strcn = strcn + " WHERE   NGAY BETWEEN  '" + tungay.ToString("MM/dd/yyyy") + "' AND '" + denngay.ToString("MM/dd/yyyy") + "'";
            strcn = strcn + " AND MAKHN IN " + select;
            strcn = strcn + " AND KT=1";

            strcn = strcn + "  UPDATE @thongtin";
            strcn = strcn + "  SET NODAUKY=(SELECT DKNO FROM @TBL_IN_CONGNOTH WHERE MAKH=MAKH1),";
            strcn = strcn + " CODAUKY=(SELECT DKCO FROM @TBL_IN_CONGNOTH WHERE MAKH=MAKH1),";
            strcn = strcn + " NOCUOIKY=(SELECT CKNO FROM @TBL_IN_CONGNOTH WHERE MAKH=MAKH1),";
            strcn = strcn + " COCUOIKY=(SELECT CKCO FROM @TBL_IN_CONGNOTH WHERE MAKH=MAKH1),";
            strcn = strcn + " DONVI=(SELECT DONVI FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1)";

            strcn = strcn + " SELECT SCT,DONVI,NGAY,NOIDUNG,TK,NODAUKY,CODAUKY,PSCO,PSNO,NOCUOIKY,COCUOIKY,chuky1,chuky2b,makh1 as makh ";
            strcn = strcn + " , '" + tungay.ToString("MM/dd/yyyy") + "' as TUNGAY, '" + denngay.ToString("MM/dd/yyyy") + "' as DENNGAY";

            strcn = strcn + ",TIEUDE.TENDVBC ";
            strcn = strcn + ",TIEUDE.TINH ";
            strcn = strcn + ",TIEUDE.TENCN ";
            strcn = strcn + ",TIEUDE.NGANHANG ";
            strcn = strcn + ",TIEUDE.TAIKHOAN ";

            strcn = strcn + " FROM @thongtin,TBL_DANHMUCTIEUDEBAOCAO TIEUDE order by id,ngay,sct";

            var DATAX = new List<sp_INTONGHOPCONGNOCHITIET_IN_Result>();
            foreach (var x in soso)
            {
                if (x == "TT423")
                {
                    string tt423 = "";
                    tt423 = tt423 + " declare @tuthang int,@denthang int,@nam int";
                    tt423 = tt423 + " declare @TUNGAY SMALLDATETIME,@DENNGAY SMALLDATETIME";
                    tt423 = tt423 + " set @tuthang =" + tungay.Month;
                    tt423 = tt423 + " set @denthang=" + denngay.Month;
                    tt423 = tt423 + " set @nam=" + denngay.Year;
                    tt423 = tt423 + " set @tungay ='" + tungay.ToString("MM/dd/yyyy") + "'";
                    tt423 = tt423 + " set @DENNGAY ='" + denngay.ToString("MM/dd/yyyy") + "'";
                    tt423 = tt423 + " DECLARE @TBL_IN_0 TABLE(";
                    tt423 = tt423 + " MAKH VARCHAR(20)";
                    tt423 = tt423 + " ,TENKH NVARCHAR(200)";
                    tt423 = tt423 + " ,DAUNAM_NO FLOAT";
                    tt423 = tt423 + " ,DAUNAM_CO FLOAT";
                    tt423 = tt423 + " ,PSNO_0 FLOAT";
                    tt423 = tt423 + " ,PSCO_0 FLOAT";
                    tt423 = tt423 + " ,DKNO FLOAT";
                    tt423 = tt423 + " ,DKCO FLOAT";
                    tt423 = tt423 + " ,PSNO FLOAT";
                    tt423 = tt423 + " ,PSCO FLOAT";
                    tt423 = tt423 + " ,CKNO FLOAT";
                    tt423 = tt423 + " ,CKCO FLOAT";
                    tt423 = tt423 + " ,MAKH1 VARCHAR(20) )";
                    // DẦU KỲ NƠ
                    tt423 = tt423 + " insert into @TBL_IN_0(makh,daunam_no)";
                    tt423 = tt423 + " select dta_daukytaikhoan.MAKH,isnull(TIEN,0) ";
                    tt423 = tt423 + " FROM congno_dauky_2 dta_daukytaikhoan ,TBL_DANHMUCKHACHHANG ";
                    tt423 = tt423 + " WHERE dta_daukytaikhoan. nam=@NAM -1";
                    tt423 = tt423 + " AND dta_daukytaikhoan.MAKH=TBL_DANHMUCKHACHHANG.MAKH";
                    tt423 = tt423 + " AND TIEN>0";
                    tt423 = tt423 + " AND dta_daukytaikhoan.makh IN " + select;
                    tt423 = tt423 + " insert into @TBL_IN_0(makh,daunam_co)";
                    tt423 = tt423 + " select dta_daukytaikhoan.MAKH ,ABS(isnull(TIEN,0))";
                    tt423 = tt423 + " FROM congno_dauky_2 dta_daukytaikhoan ,TBL_DANHMUCKHACHHANG";
                    tt423 = tt423 + " WHERE dta_daukytaikhoan. nam=@NAM -1";
                    tt423 = tt423 + " AND dta_daukytaikhoan.MAKH=TBL_DANHMUCKHACHHANG.MAKH";
                    tt423 = tt423 + "  AND TIEN <0  ";
                    tt423 = tt423 + " AND dta_daukytaikhoan.makh IN " + select;
                    // phát sinh nợ trước kỳ
                    tt423 = tt423 + " insert into @TBL_IN_0(makh,psno_0)";
                    tt423 = tt423 + " select HOADON.makh,sum(round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0))";
                    tt423 = tt423 + " from DTA_CT_HOADON_XUAT CT,DTA_HOADON_XUAT HOADON,TBL_DANHMUCKHACHHANG dm_khachhang";
                    tt423 = tt423 + " where  HOADON.NGAYLAPHD BETWEEN CAST( '01/01/'+CAST(YEAR(@TUNGAY) AS VARCHAR) AS SMALLDATETIME) ";
                    tt423 = tt423 + " and dbo.funNgaycuoiThang (@tungay)";
                    tt423 = tt423 + " AND HOADON.SOHD=CT.SOHD";
                    tt423 = tt423 + " AND HOADON.NGAYLAPHD=CT.NGAYLAPHD";
                    tt423 = tt423 + " AND HOADON.MACH=CT.MACH";
                    tt423 = tt423 + " AND CT.KT=1";
                    tt423 = tt423 + " AND HOADON.MAKH=DM_KHACHHANG.MAKH";
                    tt423 = tt423 + " AND HOADON.CTGS='BAN_DL'";
                    tt423 = tt423 + " AND HOADON.MAPL='BAN'";
                    tt423 = tt423 + " AND HOADON.makh IN " + select;
                    tt423 = tt423 + " GROUP BY  HOADON.makh";
                    tt423 = tt423 + " insert into @TBL_IN_0(makh,psno_0)";
                    tt423 = tt423 + " select HOADON.makh,sum(round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0) - round((round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0)*ct.tyleck*0.01),0))";
                    tt423 = tt423 + " from DTA_CT_HOADON_XUAT CT,DTA_HOADON_XUAT HOADON,TBL_DANHMUCKHACHHANG dm_khachhang";
                    tt423 = tt423 + " where  HOADON.NGAYLAPHD BETWEEN CAST( '01/01/'+CAST(YEAR(@TUNGAY) AS VARCHAR) AS SMALLDATETIME) ";
                    tt423 = tt423 + " and dbo.funNgaycuoiThang (@tungay)";
                    tt423 = tt423 + " AND HOADON.SOHD=CT.SOHD";
                    tt423 = tt423 + " AND HOADON.NGAYLAPHD=CT.NGAYLAPHD";
                    tt423 = tt423 + " AND HOADON.MACH=CT.MACH";
                    tt423 = tt423 + " AND CT.KT=1";
                    tt423 = tt423 + " AND HOADON.MAKH=DM_KHACHHANG.MAKH";
                    tt423 = tt423 + " AND HOADON.CTGS='BAN_KHAC'";
                    tt423 = tt423 + " AND HOADON.MAPL='BAN'";
                    tt423 = tt423 + " AND HOADON.makh IN " + select;
                    tt423 = tt423 + " GROUP BY  HOADON.makh";
                    //trả tiền trước kỳ
                    tt423 = tt423 + " insert into @TBL_IN_0(makh,psco_0)";
                    tt423 = tt423 + " select congno.makh,sum(congno.tien)";
                    tt423 = tt423 + " from CONGNO_KHACHHANG_TRATIEN congno,TBL_DANHMUCKHACHHANG dm_khachhang";
                    tt423 = tt423 + " where NGAY BETWEEN CAST( '01/01/'+CAST(YEAR(@TUNGAY) AS VARCHAR) AS SMALLDATETIME) ";
                    tt423 = tt423 + " and dbo.funNgaycuoiThang (@tungay)";
                    tt423 = tt423 + " and congno.makh=dm_khachhang.makh";
                    tt423 = tt423 + " AND congno.KT IS NULL ";
                    tt423 = tt423 + " AND congno.makh IN " + select;
                    tt423 = tt423 + " group by  congno.makh ";
                    //phát sinh nợ trong kỳ
                    tt423 = tt423 + " insert into @TBL_IN_0(makh,psno)";
                    tt423 = tt423 + " select HOADON.makh,sum(round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0))";
                    tt423 = tt423 + " from DTA_CT_HOADON_XUAT CT,DTA_HOADON_XUAT HOADON,TBL_DANHMUCKHACHHANG dm_khachhang";
                    tt423 = tt423 + " where  HOADON.NGAYLAPHD   BETWEEN  @TUNGAY AND @DENNGAY";
                    tt423 = tt423 + " AND HOADON.SOHD=CT.SOHD";
                    tt423 = tt423 + " AND HOADON.NGAYLAPHD=CT.NGAYLAPHD";
                    tt423 = tt423 + " AND HOADON.MACH=CT.MACH";
                    tt423 = tt423 + " AND CT.KT=1";
                    tt423 = tt423 + " AND HOADON.MAKH=DM_KHACHHANG.MAKH";
                    tt423 = tt423 + " AND HOADON.CTGS='BAN_DL'";
                    tt423 = tt423 + " AND HOADON.MAPL='BAN'";
                    tt423 = tt423 + " AND HOADON.makh IN " + select;
                    tt423 = tt423 + " GROUP BY  HOADON.makh";
                    tt423 = tt423 + " insert into @TBL_IN_0(makh,psno)";
                    tt423 = tt423 + " select HOADON.makh,sum(round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0) - round((round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0)*ct.tyleck*0.01),0))";
                    tt423 = tt423 + " from DTA_CT_HOADON_XUAT CT,DTA_HOADON_XUAT HOADON,TBL_DANHMUCKHACHHANG dm_khachhang";
                    tt423 = tt423 + " where  HOADON.NGAYLAPHD   BETWEEN  @TUNGAY AND @DENNGAY";
                    tt423 = tt423 + " AND HOADON.SOHD=CT.SOHD";
                    tt423 = tt423 + " AND HOADON.NGAYLAPHD=CT.NGAYLAPHD";
                    tt423 = tt423 + " AND HOADON.MACH=CT.MACH";
                    tt423 = tt423 + " AND CT.KT=1";
                    tt423 = tt423 + " AND HOADON.MAKH=DM_KHACHHANG.MAKH";
                    tt423 = tt423 + " AND HOADON.CTGS='BAN_KHAC'";
                    tt423 = tt423 + " AND HOADON.MAPL='BAN'";
                    tt423 = tt423 + " AND HOADON.makh IN " + select;
                    tt423 = tt423 + " GROUP BY  HOADON.makh";
                    tt423 = tt423 + " insert into @TBL_IN_0(makh,psno)";
                    tt423 = tt423 + " select congno.makh,sum(congno.tien)";
                    tt423 = tt423 + " from CONGNO_KHACHHANG_TRATIEN congno,TBL_DANHMUCKHACHHANG dm_khachhang";
                    tt423 = tt423 + " where NGAY BETWEEN  @TUNGAY AND @DENNGAY";
                    tt423 = tt423 + " and congno.makh=dm_khachhang.makh";
                    tt423 = tt423 + " AND congno.KT IS NULL ";
                    tt423 = tt423 + " and tien<0";
                    tt423 = tt423 + " AND congno.makh IN " + select;
                    tt423 = tt423 + " group by  congno.makh ";
                    // trả tiền trong kỳ
                    tt423 = tt423 + " insert into @TBL_IN_0(makh,psco)";
                    tt423 = tt423 + " select congno.makh,sum(congno.tien)";
                    tt423 = tt423 + " from CONGNO_KHACHHANG_TRATIEN congno,TBL_DANHMUCKHACHHANG dm_khachhang";
                    tt423 = tt423 + " where NGAY BETWEEN  @TUNGAY AND @DENNGAY";
                    tt423 = tt423 + " and congno.makh=dm_khachhang.makh";
                    tt423 = tt423 + " AND congno.KT IS NULL ";
                    tt423 = tt423 + " and tien > 0";
                    tt423 = tt423 + " AND congno.makh IN " + select;
                    tt423 = tt423 + " group by  congno.makh ";
                    tt423 = tt423 + " DECLARE @TBL_IN_CONGNOTH TABLE( ";
                    tt423 = tt423 + " MAKH VARCHAR(20)";
                    tt423 = tt423 + " ,DAUNAM_NO MONEY";
                    tt423 = tt423 + " ,TENKH NVARCHAR(200) ";
                    tt423 = tt423 + " ,DAUNAM_CO MONEY";
                    tt423 = tt423 + " ,PSNO_0 MONEY ";
                    tt423 = tt423 + " ,PSCO_0 MONEY ";
                    tt423 = tt423 + " ,DKNO MONEY";
                    tt423 = tt423 + " ,DKCO MONEY";
                    tt423 = tt423 + " ,PSNO MONEY";
                    tt423 = tt423 + " ,PSCO MONEY";
                    tt423 = tt423 + " ,CKNO MONEY ";
                    tt423 = tt423 + " ,CKCO MONEY";
                    tt423 = tt423 + " ) ";
                    tt423 = tt423 + " insert into @TBL_IN_CONGNOTH(makh,daunam_no,daunam_co,psno_0,psco_0,dkno,dkco,psno,psco,ckno,ckco)";
                    tt423 = tt423 + " select makh,sum(ISNULL(daunam_no,0)),sum(ISNULL(daunam_co,0)),sum(ISNULL(psno_0,0))";
                    tt423 = tt423 + " ,sum(ISNULL(psco_0,0)),sum(ISNULL(dkno,0)),sum(ISNULL(dkco,0)),sum(ISNULL(psno,0)),sum(ISNULL(psco,0))";
                    tt423 = tt423 + " ,sum(ISNULL(ckno,0)),sum(ISNULL(ckco,0))";
                    tt423 = tt423 + " from @TBL_IN_0";
                    tt423 = tt423 + " group by makh";
                    tt423 = tt423 + " update @TBL_IN_CONGNOTH";
                    tt423 = tt423 + " set dkno= daunam_no - daunam_co + psno_0 - psco_0 ";
                    tt423 = tt423 + " update @TBL_IN_CONGNOTH";
                    tt423 = tt423 + " set ckno= dkno +  psno - psco ";
                    tt423 = tt423 + " update @TBL_IN_CONGNOTH";
                    tt423 = tt423 + " set dkco=-dkno,dkno=0";
                    tt423 = tt423 + " where dkno<0";
                    tt423 = tt423 + " update @TBL_IN_CONGNOTH";
                    tt423 = tt423 + " set ckco=-ckno,ckno=0";
                    tt423 = tt423 + " where ckno<0";
                    tt423 = tt423 + " delete @TBL_IN_CONGNOTH ";
                    tt423 = tt423 + " where (isnull(dkno,0) + isnull(dkco,0) +isnull(psno,0) +isnull(psco,0) +isnull(Ckno,0)  + isnull(Ckco,0) )=0";
                    tt423 = tt423 + " DECLARE @thongtin TABLE(";
                    tt423 = tt423 + " MAKH1 varchar(20),";
                    tt423 = tt423 + " ID INT,";
                    tt423 = tt423 + " SCT VARCHAR(20)";
                    tt423 = tt423 + " ,NGAY SMALLDATETIME";
                    tt423 = tt423 + " ,NOIDUNG NVARCHAR(200)";
                    tt423 = tt423 + " ,TK VARCHAR(10)";
                    tt423 = tt423 + " ,NODAUKY MONEY DEFAULT 0";
                    tt423 = tt423 + " ,CODAUKY MONEY  DEFAULT 0";
                    tt423 = tt423 + " ,PSNO MONEY   DEFAULT 0";
                    tt423 = tt423 + " ,PSCO MONEY    DEFAULT 0";
                    tt423 = tt423 + " ,NOCUOIKY MONEY";
                    tt423 = tt423 + " ,COCUOIKY MONEY";
                    tt423 = tt423 + " ,TNODAUKY MONEY";
                    tt423 = tt423 + " ,TCODAUKY MONEY";
                    tt423 = tt423 + " ,TPSNO MONEY";
                    tt423 = tt423 + " ,TPSCO MONEY";
                    tt423 = tt423 + " ,TNOCUOIKY MONEY";
                    tt423 = tt423 + " ,TCOCUOIKY MONEY";
                    tt423 = tt423 + " ,sct_vat varchar(10)";
                    tt423 = tt423 + " ,ngay_vat smalldatetime ";
                    tt423 = tt423 + " ,DONVI NVARCHAR(250)) ";

                    //phát sinh nợ
                    tt423 = tt423 + " INSERT INTO  @thongtin(MAKH1,SCT,NGAY,NOIDUNG,PSNO) ";
                    tt423 = tt423 + " select HOADON.makh,HOADON.SOHD,HOADON.NGAYLAPHD,HOADON.DONVI,sum(round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0))";
                    tt423 = tt423 + " from DTA_CT_HOADON_XUAT CT,DTA_HOADON_XUAT HOADON,TBL_DANHMUCKHACHHANG dm_khachhang";
                    tt423 = tt423 + " where  HOADON.NGAYLAPHD   BETWEEN  @TUNGAY AND @DENNGAY";
                    tt423 = tt423 + " AND HOADON.SOHD=CT.SOHD";
                    tt423 = tt423 + " AND HOADON.NGAYLAPHD=CT.NGAYLAPHD";
                    tt423 = tt423 + " AND HOADON.MACH=CT.MACH";
                    tt423 = tt423 + " AND CT.KT=1";
                    tt423 = tt423 + " AND HOADON.MAKH=DM_KHACHHANG.MAKH";
                    tt423 = tt423 + " AND HOADON.CTGS='BAN_DL'";
                    tt423 = tt423 + " AND HOADON.MAPL='BAN'";
                    tt423 = tt423 + " AND HOADON.makh IN " + select;
                    tt423 = tt423 + " GROUP BY HOADON.makh,HOADON.SOHD,HOADON.NGAYLAPHD,HOADON.DONVI";
                    tt423 = tt423 + " INSERT INTO  @thongtin(MAKH1,SCT,NGAY,NOIDUNG,PSNO) ";
                    tt423 = tt423 + " select HOADON.makh,HOADON.SOHD,HOADON.NGAYLAPHD,HOADON.DONVI,sum(round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0) - round((round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0)*ct.tyleck*0.01),0))";
                    tt423 = tt423 + " from DTA_CT_HOADON_XUAT CT,DTA_HOADON_XUAT HOADON,TBL_DANHMUCKHACHHANG dm_khachhang";
                    tt423 = tt423 + " where  HOADON.NGAYLAPHD   BETWEEN  @TUNGAY AND @DENNGAY";
                    tt423 = tt423 + " AND HOADON.SOHD=CT.SOHD";
                    tt423 = tt423 + " AND HOADON.NGAYLAPHD=CT.NGAYLAPHD";
                    tt423 = tt423 + " AND HOADON.MACH=CT.MACH";
                    tt423 = tt423 + " AND CT.KT=1";
                    tt423 = tt423 + " AND HOADON.MAKH=DM_KHACHHANG.MAKH";
                    tt423 = tt423 + " AND HOADON.CTGS='BAN_KHAC'";
                    tt423 = tt423 + " AND HOADON.MAPL='BAN'";
                    tt423 = tt423 + " AND HOADON.makh IN " + select;
                    tt423 = tt423 + " GROUP BY HOADON.makh,HOADON.SOHD,HOADON.NGAYLAPHD,HOADON.DONVI";
                    tt423 = tt423 + " insert into @thongtin(MAKH1,SCT,NGAY,NOIDUNG,PSNO)";
                    tt423 = tt423 + " select congno.makh,congno.sct,congno.NGAY,congno.noidung,sum(congno.tien)";
                    tt423 = tt423 + " from CONGNO_KHACHHANG_TRATIEN congno,TBL_DANHMUCKHACHHANG dm_khachhang";
                    tt423 = tt423 + " where NGAY BETWEEN  @TUNGAY AND @DENNGAY";
                    tt423 = tt423 + " and congno.makh=dm_khachhang.makh";
                    tt423 = tt423 + " AND congno.KT IS NULL ";
                    tt423 = tt423 + " and tien<0";
                    tt423 = tt423 + " AND congno.makh IN " + select;
                    tt423 = tt423 + " group by  congno.makh,congno.sct,congno.NGAY,congno.noidung";
                    tt423 = tt423 + " insert into @thongtin(MAKH1,SCT,NGAY,NOIDUNG,PSCO)";
                    tt423 = tt423 + " select congno.makh,congno.sct,congno.NGAY,congno.noidung,sum(congno.tien)";
                    tt423 = tt423 + " from CONGNO_KHACHHANG_TRATIEN congno,TBL_DANHMUCKHACHHANG dm_khachhang";
                    tt423 = tt423 + " where NGAY BETWEEN  @TUNGAY AND @DENNGAY";
                    tt423 = tt423 + " and congno.makh=dm_khachhang.makh";
                    tt423 = tt423 + " AND congno.KT IS NULL ";
                    tt423 = tt423 + " and tien > 0";
                    tt423 = tt423 + " AND congno.makh IN " + select;
                    tt423 = tt423 + " group by  congno.makh,congno.sct,congno.NGAY,congno.noidung";
                    tt423 = tt423 + " INSERT INTO @thongtin(makh1) " + "(SELECT VAL FROM FUN_CATCHUOI('" + String.Join(",", khachhang.ToArray()) + "'))";
                    tt423 = tt423 + "  UPDATE @thongtin";
                    tt423 = tt423 + "  SET NODAUKY=(SELECT DKNO FROM @TBL_IN_CONGNOTH WHERE MAKH=MAKH1),";
                    tt423 = tt423 + " CODAUKY=(SELECT DKCO FROM @TBL_IN_CONGNOTH WHERE MAKH=MAKH1),";
                    tt423 = tt423 + " NOCUOIKY=(SELECT CKNO FROM @TBL_IN_CONGNOTH WHERE MAKH=MAKH1),";
                    tt423 = tt423 + " COCUOIKY=(SELECT CKCO FROM @TBL_IN_CONGNOTH WHERE MAKH=MAKH1),";
                    tt423 = tt423 + " DONVI=(SELECT DONVI FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1)";
                    tt423 = tt423 + " SELECT *,makh1 as makh ";
                    tt423 = tt423 + " , '" + tungay.ToString("MM/dd/yyyy") + "' as TUNGAY, '" + denngay.ToString("MM/dd/yyyy") + "' as DENNGAY";
                    tt423 = tt423 + ",TIEUDE.TENDVBC ";
                    tt423 = tt423 + ",TIEUDE.TINH ";
                    tt423 = tt423 + ",TIEUDE.TENCN ";
                    tt423 = tt423 + ",TIEUDE.NGANHANG ";
                    tt423 = tt423 + ",TIEUDE.TAIKHOAN ";
                    tt423 = tt423 + " FROM @thongtin,TBL_DANHMUCTIEUDEBAOCAO TIEUDE order by  ngay,sct";
                    DATAX.AddRange(BAOCAOCHINHANH1(TT423, tt423));
                }
                else if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(BAOCAOCHINHANH1(queryCN.SingleOrDefault(n => n.macn == x).data, strcn));
                }
            }
            return DATAX;
        }
        public ListKhuyenMai GetDataKM(string ChiNhanh, string MAKM)
        {
            var str = "SELECT MaCTKM AS MAKM, TenCTKM AS TENKM, ngaybatdau, ngayketthuc  FROM TBL_DANHMUCKM WHERE MaCTKM = '" + MAKM + "'";
            var strch = "SELECT MACTKM AS MAKM, TENCTKM AS TENKM FROM TBL_DANHMUCKHUYENMAI WHERE MACTKM = '" + MAKM + "'";
            ListKhuyenMai data = new ListKhuyenMai();
            if (queryCN.SingleOrDefault(n => n.macn == ChiNhanh) != null)
            {
                if (ChiNhanh == "TT423")
                {
                    data = queryCN.SingleOrDefault(n => n.macn == ChiNhanh).data.Database.SqlQuery<ListKhuyenMai>("SELECT MaCTKM AS MAKM, TenCTKM AS TENKM , TRY_CONVERT(datetime, TBL_DANHMUCKHUYENMAI.ngaybd, 103) AS ngaybatdau,TRY_CONVERT(datetime, TBL_DANHMUCKHUYENMAI.ngaykt, 103) as ngayketthuc  FROM TBL_DANHMUCKHUYENMAI WHERE MaCTKM = '" + MAKM + "'").FirstOrDefault();
                }
                else
                {
                    data = queryCN.SingleOrDefault(n => n.macn == ChiNhanh).data.Database.SqlQuery<ListKhuyenMai>(str).FirstOrDefault();
                }

            }
            else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanh) != null)
            {
                data = queryCH.SingleOrDefault(n => n.macn == ChiNhanh).data.Database.SqlQuery<ListKhuyenMai>(strch).FirstOrDefault();
            }
            return data;
        }
        public List<DULIEUBAOCAO13> DATABAOCAO13(List<string> soso, DateTime tungay, DateTime denngay, string phanloai, List<string> phanloaikhachhang, List<string> nhomhang, List<string> sanpham, List<string> quanhuyen, List<string> matinh, List<string> makh, List<string> matdv, List<string> hopdong, List<string> mapl, List<string> makm, List<string> loaihd, List<string> mactht, string tienck)
        {
            var DATAX = new List<DULIEUBAOCAO13>();
            //String CN
            string strcn = "SELECT DTA_CT_HOADON_XUAT.MAHH,TBL_DANHMUCHANGHOA.TENHH,TBL_DANHMUCHANGHOA.DVT,SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0))" + ((tienck == "1") ? "- SUM(CAST(ROUND(round(DTA_CT_HOADON_XUAT.DONGIA*DTA_CT_HOADON_XUAT.SOLUONG,0)*DTA_CT_HOADON_XUAT.TYLECK/100 ,0) AS MONEY))" : "") + " AS TIEN  ,SUM(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)) AS SOLUONG ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, DTA_HOADON_XUAT.MATDV AS MAQUAY FROM  DTA_CT_HOADON_XUAT   LEFT JOIN   TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH , DTA_HOADON_XUAT LEFT JOIN  TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh ,TBL_DANHMUCTIEUDEBAOCAO " + ((loaihd != null) ? " ,DTA_HOADON_XUAT DTA_HOADON_XUAT_1  LEFT JOIN TBL_DANHMUCHOPDONG ON DTA_HOADON_XUAT_1.HOPDONG=TBL_DANHMUCHOPDONG.mahd AND DTA_HOADON_XUAT_1.MAKH=TBL_DANHMUCHOPDONG.MAKH" : " ") + " WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  and DTA_CT_HOADON_XUAT.kt=1  AND DTA_HOADON_XUAT.NGAYLAPHD between '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' ";
            //String CH
            string strch = "SELECT DTA_CT_HOADON_XUAT.MAHH,TBL_DANHMUCHANGHOA.TENHH,TBL_DANHMUCHANGHOA.DVT,SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0))" + ((tienck == "1") ? "-SUM(CAST(ROUND(round(DTA_CT_HOADON_XUAT.DONGIA*DTA_CT_HOADON_XUAT.SOLUONG,0)*DTA_CT_HOADON_XUAT.TYLECK/100 ,0) AS MONEY))" : "") + " AS TIEN  ,SUM(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)) AS SOLUONG ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.MATDV AS MAQUAY FROM CT_HOADON_XUAT DTA_CT_HOADON_XUAT   LEFT JOIN  DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH,HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh ,TIEUDE TBL_DANHMUCTIEUDEBAOCAO " + ((loaihd != null) ? " ,DTA_HOADON_XUAT DTA_HOADON_XUAT_1  LEFT JOIN TBL_DANHMUCHOPDONG ON DTA_HOADON_XUAT_1.HOPDONG=TBL_DANHMUCHOPDONG.mahd AND DTA_HOADON_XUAT_1.MAKH=TBL_DANHMUCHOPDONG.MAKH" : " ") + " WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  and DTA_CT_HOADON_XUAT.kt=1  AND DTA_HOADON_XUAT.NGAYLAPHD between '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' ";
            //String MB
            if (phanloai != "ALL")
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloaikhachhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            }
            if (loaihd != null)
            {
                strcn = strcn + " AND DTA_HOADON_XUAT.SOHD=DTA_HOADON_XUAT_1.SOHD And DTA_HOADON_XUAT.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And DTA_HOADON_XUAT.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
                strch = strch + " AND DTA_HOADON_XUAT.SOHD=DTA_HOADON_XUAT_1.SOHD And DTA_HOADON_XUAT.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And DTA_HOADON_XUAT.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
            }
            if (hopdong != null)
            {
                List<string> kh = new List<string>();
                List<string> hd = new List<string>();
                foreach (var i in hopdong)
                {
                    var k = i.Split('~').ToList();
                    hd.Add(k.First());
                    kh.Add(k.Last());
                }
                strcn = strcn + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MAKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MaKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
            }
            if (nhomhang != null)
            {
                strcn = strcn + string.Format(" AND Substring(dta_ct_hoadon_xuat.mahh, 1, 2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND Substring(dta_ct_hoadon_xuat.mahh, 1, 2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (sanpham != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.MAHH IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCHANGHOA.MAHH IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
            }
            if (quanhuyen != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
            }
            if (matinh != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
            }
            if (makh != null)
            {
                strcn = strcn + string.Format(" AND DTA_HOADON_XUAT.MAKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_HOADON_XUAT.MAKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            }
            if (matdv != null)
            {
                strcn = strcn + string.Format(" AND dta_hoadon_xuat.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            if (mapl != null)
            {
                strcn = strcn + string.Format(" AND DTA_HOADON_XUAT.MAPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_HOADON_XUAT.MAPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
            }
            if (makm != null)
            {
                strcn = strcn + string.Format(" AND DTA_CT_HOADON_XUAT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_CT_HOADON_XUAT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
            }
            if (mactht != null)
            {
                strcn = strcn + string.Format(" AND DTA_CT_HOADON_XUAT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_CT_HOADON_XUAT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
            }
            strcn = strcn + " GROUP BY TBL_DANHMUCKHACHHANG.MATINH,TBL_DANHMUCHANGHOA.NHOM, DTA_CT_HOADON_XUAT.MAHH,TBL_DANHMUCHANGHOA.TENHH,TBL_DANHMUCHANGHOA.DVT,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC , DTA_HOADON_XUAT.MATDV   HAVING SUM(DTA_CT_HOADON_XUAT.SOLUONG) <>0";
            strch = strch + " GROUP BY TBL_DANHMUCKHACHHANG.MATDV ,TBL_DANHMUCKHACHHANG.MATINH,TBL_DANHMUCHANGHOA.NHOM, DTA_CT_HOADON_XUAT.MAHH,TBL_DANHMUCHANGHOA.TENHH,TBL_DANHMUCHANGHOA.DVT,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC HAVING SUM(DTA_CT_HOADON_XUAT.SOLUONG) <>0";
            foreach (var x in soso)
            {
                //
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DULIEUBAOCAO13>(strcn).ToList());
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DULIEUBAOCAO13>(strch).ToList());
                }
            }
            return DATAX;
        }
        public List<DULIEUBAOCAO15> DATABAOCAO15(List<string> soso, DateTime tungay, DateTime denngay, string phanloai, List<string> phanloaikhachhang, List<string> nhomhang, List<string> sanpham, List<string> quanhuyen, List<string> matinh, List<string> makh, List<string> matdv, List<string> hopdong, List<string> mapl, List<string> makm, List<string> mactht, string tienck)
        {

            var DATAX = new List<DULIEUBAOCAO15>();
            //String CN
            string strcn = "SELECT DTA_CT_HOADON_XUAT.MAHH,TBL_DANHMUCHANGHOA.TENHH,TBL_DANHMUCHANGHOA.DVT,SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0))" + ((tienck == "1") ? "-SUM(ROUND(round(DTA_CT_HOADON_XUAT.DONGIA*DTA_CT_HOADON_XUAT.SOLUONG,0)*DTA_CT_HOADON_XUAT.TYLECK/100 ,0))" : " ") + " AS TIEN  ,CAST(SUM(DTA_CT_HOADON_XUAT.SOLUONG) AS MONEY) AS SOLUONG , DTA_CT_HOADON_XUAT.MAKM AS MAQUAY FROM  DTA_CT_HOADON_XUAT   LEFT JOIN   TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH,  DTA_HOADON_XUAT LEFT JOIN  TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh ,TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  and DTA_CT_HOADON_XUAT.kt=1  AND DTA_HOADON_XUAT.NGAYLAPHD between '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' ";
            //String CH
            string strch = "SELECT DTA_CT_HOADON_XUAT.MAHH,TBL_DANHMUCHANGHOA.TENHH,TBL_DANHMUCHANGHOA.DVT,SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0))" + ((tienck == "1") ? "-SUM(ROUND(round(DTA_CT_HOADON_XUAT.DONGIA*DTA_CT_HOADON_XUAT.SOLUONG,0)*DTA_CT_HOADON_XUAT.TYLECK/100 ,0))" : " ") + " AS TIEN  ,CAST(SUM(DTA_CT_HOADON_XUAT.SOLUONG) AS MONEY) AS SOLUONG, DTA_CT_HOADON_XUAT.MAKM AS MAQUAY FROM CT_HOADON_XUAT DTA_CT_HOADON_XUAT LEFT JOIN  DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH,HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh ,TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  and DTA_CT_HOADON_XUAT.kt=1  AND DTA_HOADON_XUAT.NGAYLAPHD between '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' ";
            //String MB

            if (phanloai != "ALL")
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloaikhachhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            }
            if (hopdong != null)
            {
                List<string> kh = new List<string>();
                List<string> hd = new List<string>();
                foreach (var i in hopdong)
                {
                    var k = i.Split('~').ToList();
                    hd.Add(k.First());
                    kh.Add(k.Last());
                }
                strcn = strcn + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MAKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MaKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
            }
            if (nhomhang != null)
            {
                strcn = strcn + string.Format(" AND Substring(dta_ct_hoadon_xuat.mahh, 1, 2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND Substring(dta_ct_hoadon_xuat.mahh, 1, 2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));

            }
            if (sanpham != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.MAHH IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCHANGHOA.MAHH IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));

            }
            if (quanhuyen != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
            }
            if (matinh != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));

            }
            if (makh != null)
            {
                strcn = strcn + string.Format(" AND DTA_HOADON_XUAT.MAKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_HOADON_XUAT.MAKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            }
            if (matdv != null)
            {
                strcn = strcn + string.Format(" AND dta_hoadon_xuat.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            if (mapl != null)
            {
                strcn = strcn + string.Format(" AND DTA_HOADON_XUAT.MAPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_HOADON_XUAT.MAPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
            }
            if (makm != null)
            {
                strcn = strcn + string.Format(" AND DTA_CT_HOADON_XUAT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_CT_HOADON_XUAT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
            }
            if (mactht != null)
            {
                strcn = strcn + string.Format(" AND DTA_CT_HOADON_XUAT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_CT_HOADON_XUAT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
            }
            strcn = strcn + " GROUP BY  DTA_CT_HOADON_XUAT.MAKM , TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCHANGHOA.NHOM, DTA_CT_HOADON_XUAT.MAHH, TBL_DANHMUCHANGHOA.TENHH, TBL_DANHMUCHANGHOA.DVT, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC HAVING SUM(DTA_CT_HOADON_XUAT.SOLUONG) <>0";
            strch = strch + " GROUP BY  DTA_CT_HOADON_XUAT.MAKM ,TBL_DANHMUCKHACHHANG.MATINH,TBL_DANHMUCHANGHOA.NHOM, DTA_CT_HOADON_XUAT.MAHH,TBL_DANHMUCHANGHOA.TENHH,TBL_DANHMUCHANGHOA.DVT,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC HAVING SUM(DTA_CT_HOADON_XUAT.SOLUONG) <>0";
            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DULIEUBAOCAO15>(strcn).ToList());
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DULIEUBAOCAO15>(strch).ToList());
                }
            }
            return DATAX;
        }
        public List<DATABAOCAO8> DATABAOCAO8(List<string> soso, DateTime tungay, DateTime denngay, string phanloai, List<string> phanloaikhachhang, List<string> nhomhang, List<string> sanpham, List<string> quanhuyen, List<string> matinh, List<string> makh, List<string> matdv, List<string> hopdong, List<string> mapl, List<string> makm, List<string> mactht, string tienck)
        {

            var DATAX = new List<DATABAOCAO8>();
            //String CN
            string strcn = "SELECT TBL_DANHMUCHANGHOA.NHOM,DTA_CT_HOADON_XUAT.MAHH,TBL_DANHMUCHANGHOA.TENHH,TBL_DANHMUCHANGHOA.DVT,SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0)) AS TIEN  ,CAST(SUM(DTA_CT_HOADON_XUAT.SOLUONG) AS MONEY) AS SOLUONG ,CAST(ROUND(SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0))/SUM(DTA_CT_HOADON_XUAT.SOLUONG), 0) AS MONEY) AS DONGIA   ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC,'" + tungay.ToString("dd/MM/yyyy") + "' as tuthang,'" + denngay.ToString("dd/MM/yyyy") + "' as thang FROM  DTA_CT_HOADON_NHAP  DTA_CT_HOADON_XUAT  LEFT JOIN   TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH ,DTA_HOADON_NHAP  DTA_HOADON_XUAT LEFT JOIN  TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh ,TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.NGUOIDUNG=DTA_CT_HOADON_XUAT.NGUOIDUNG and DTA_CT_HOADON_XUAT.kt=1  AND DTA_HOADON_XUAT.NGAYLAPHD between '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' ";
            //String CH
            string strch = "SELECT DTA_CT_HOADON_XUAT.MAHH,TBL_DANHMUCHANGHOA.TENHH,TBL_DANHMUCHANGHOA.DVT,SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0))" + ((tienck == "1") ? "-SUM(CAST(ROUND(round(DTA_CT_HOADON_XUAT.DONGIA*DTA_CT_HOADON_XUAT.SOLUONG,0)*DTA_CT_HOADON_XUAT.TYLECK/100 ,0) AS MONEY))" : "") + " AS TIEN  ,SUM(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)) AS SOLUONG ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.MATDV AS MAQUAY FROM CT_HOADON_XUAT DTA_CT_HOADON_XUAT   LEFT JOIN  DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH,HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh ,TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  and DTA_CT_HOADON_XUAT.kt=1  AND DTA_HOADON_XUAT.NGAYLAPHD between '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' ";
            //String MB

            if (phanloai != "ALL")
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloaikhachhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            }
            if (hopdong != null)
            {
                List<string> kh = new List<string>();
                List<string> hd = new List<string>();
                foreach (var i in hopdong)
                {
                    var k = i.Split('~').ToList();
                    hd.Add(k.First());
                    kh.Add(k.Last());
                }
                strcn = strcn + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MAKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MaKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
            }
            if (nhomhang != null)
            {
                strcn = strcn + string.Format(" AND Substring(dta_ct_hoadon_xuat.mahh, 1, 2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND Substring(dta_ct_hoadon_xuat.mahh, 1, 2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));

            }
            if (sanpham != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.MAHH IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCHANGHOA.MAHH IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));

            }
            if (quanhuyen != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
            }
            if (matinh != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
            }
            if (makh != null)
            {
                strcn = strcn + string.Format(" AND DTA_HOADON_XUAT.MAKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_HOADON_XUAT.MAKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            }
            if (matdv != null)
            {
                strcn = strcn + string.Format(" AND dta_hoadon_xuat.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            if (mapl != null)
            {
                strcn = strcn + string.Format(" AND DTA_HOADON_XUAT.MAPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_HOADON_XUAT.MAPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
            }
            if (makm != null)
            {
                strcn = strcn + string.Format(" AND DTA_CT_HOADON_XUAT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_CT_HOADON_XUAT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
            }
            if (mactht != null)
            {
                strcn = strcn + string.Format(" AND DTA_CT_HOADON_XUAT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_CT_HOADON_XUAT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
            }
            strcn = strcn + " GROUP BY  TBL_DANHMUCHANGHOA.NHOM, DTA_CT_HOADON_XUAT.MAHH,TBL_DANHMUCHANGHOA.TENHH,TBL_DANHMUCHANGHOA.DVT,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC HAVING SUM(DTA_CT_HOADON_XUAT.SOLUONG) <>0  ORDER by DTA_CT_HOADON_XUAT.MAHH";
            strch = strch + " GROUP BY TBL_DANHMUCKHACHHANG.MATDV ,TBL_DANHMUCKHACHHANG.MATINH,TBL_DANHMUCHANGHOA.NHOM, DTA_CT_HOADON_XUAT.MAHH,TBL_DANHMUCHANGHOA.TENHH,TBL_DANHMUCHANGHOA.DVT,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC HAVING SUM(DTA_CT_HOADON_XUAT.SOLUONG) <>0";
            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DATABAOCAO8>(strcn).ToList());
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DATABAOCAO8>(strch).ToList());
                }
            }
            return DATAX;
        }
        public List<BAOCAO10> DATABAOCAO12(List<string> soso, DateTime tungay, DateTime denngay, string phanloai, List<string> phanloaikhachhang, List<string> nhomhang, List<string> sanpham, List<string> quanhuyen, List<string> matinh, List<string> makh, List<string> matdv, List<string> hopdong, List<string> mapl, List<string> makm, List<string> mactht, string tienck)
        {
            var DATAX = new List<DATABAOCAO8>();
            //String CN
            string strcn = "SELECT DTA_HOADON_XUAT.SOHD,DTA_HOADON_XUAT.MAKH,DTA_HOADON_XUAT.DONVI,convert(varchar, DTA_HOADON_XUAT.NGAYLAPHD, 103) AS NGAYLAPHD,TBL_DANHMUCHANGHOA.NHOM,DTA_CT_HOADON_XUAT.MAHH,TBL_DANHMUCHANGHOA.TENHH,TBL_DANHMUCHANGHOA.DVT,SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0)) AS TIEN  ,CAST(SUM(DTA_CT_HOADON_XUAT.SOLUONG) AS MONEY) AS SOLUONG ,CAST(ROUND(SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0))/SUM(DTA_CT_HOADON_XUAT.SOLUONG), 0) AS MONEY) AS DONGIA   ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC,'" + tungay.ToString("dd/MM/yyyy") + "' as tuthang,'" + denngay.ToString("dd/MM/yyyy") + "' as thang FROM  DTA_CT_HOADON_NHAP  DTA_CT_HOADON_XUAT  LEFT JOIN   TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH ,DTA_HOADON_NHAP  DTA_HOADON_XUAT LEFT JOIN  TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh ,TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.NGUOIDUNG=DTA_CT_HOADON_XUAT.NGUOIDUNG and DTA_CT_HOADON_XUAT.kt=1  AND DTA_HOADON_XUAT.NGAYLAPHD between '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' ";
            //String CH
            string strch = "SELECT DTA_HOADON_XUAT.SOHD,DTA_HOADON_XUAT.MAKH,DTA_HOADON_XUAT.DONVI,convert(varchar, DTA_HOADON_XUAT.NGAYLAPHD, 103) AS NGAYLAPHD,DTA_CT_HOADON_XUAT.MAHH,TBL_DANHMUCHANGHOA.TENHH,TBL_DANHMUCHANGHOA.DVT,SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0))" + ((tienck == "1") ? "-SUM(CAST(ROUND(round(DTA_CT_HOADON_XUAT.DONGIA*DTA_CT_HOADON_XUAT.SOLUONG,0)*DTA_CT_HOADON_XUAT.TYLECK/100 ,0) AS MONEY))" : "") + " AS TIEN  ,SUM(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)) AS SOLUONG ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.MATDV AS MAQUAY FROM CT_HOADON_XUAT DTA_CT_HOADON_XUAT   LEFT JOIN  DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH,HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh ,TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  and DTA_CT_HOADON_XUAT.kt=1  AND DTA_HOADON_XUAT.NGAYLAPHD between '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' ";
            //String MB

            if (phanloai != "ALL")
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloaikhachhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            }
            if (hopdong != null)
            {
                List<string> kh = new List<string>();
                List<string> hd = new List<string>();
                foreach (var i in hopdong)
                {
                    var k = i.Split('~').ToList();
                    hd.Add(k.First());
                    kh.Add(k.Last());
                }
                strcn = strcn + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MAKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MaKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
            }
            if (nhomhang != null)
            {
                strcn = strcn + string.Format(" AND Substring(dta_ct_hoadon_xuat.mahh, 1, 2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND Substring(dta_ct_hoadon_xuat.mahh, 1, 2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (sanpham != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.MAHH IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCHANGHOA.MAHH IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
            }
            if (quanhuyen != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
            }
            if (matinh != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
            }
            if (makh != null)
            {
                strcn = strcn + string.Format(" AND DTA_HOADON_XUAT.MAKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_HOADON_XUAT.MAKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            }
            if (matdv != null)
            {
                strcn = strcn + string.Format(" AND dta_hoadon_xuat.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            if (mapl != null)
            {
                strcn = strcn + string.Format(" AND DTA_HOADON_XUAT.MAPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_HOADON_XUAT.MAPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
            }
            if (makm != null)
            {
                strcn = strcn + string.Format(" AND DTA_CT_HOADON_XUAT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_CT_HOADON_XUAT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
            }
            if (mactht != null)
            {
                strcn = strcn + string.Format(" AND DTA_CT_HOADON_XUAT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_CT_HOADON_XUAT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
            }
            strcn = strcn + " GROUP BY  DTA_HOADON_XUAT.SOHD,DTA_HOADON_XUAT.MAKH,DTA_HOADON_XUAT.DONVI,DTA_HOADON_XUAT.NGAYLAPHD,TBL_DANHMUCHANGHOA.NHOM, DTA_CT_HOADON_XUAT.MAHH,TBL_DANHMUCHANGHOA.TENHH,TBL_DANHMUCHANGHOA.DVT,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC HAVING SUM(DTA_CT_HOADON_XUAT.SOLUONG) <>0  ORDER by DTA_CT_HOADON_XUAT.MAHH";
            strch = strch + " GROUP BY DTA_HOADON_XUAT.SOHD,DTA_HOADON_XUAT.MAKH,DTA_HOADON_XUAT.DONVI,DTA_HOADON_XUAT.NGAYLAPHD,TBL_DANHMUCKHACHHANG.MATDV ,TBL_DANHMUCKHACHHANG.MATINH,TBL_DANHMUCHANGHOA.NHOM, DTA_CT_HOADON_XUAT.MAHH,TBL_DANHMUCHANGHOA.TENHH,TBL_DANHMUCHANGHOA.DVT,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC HAVING SUM(DTA_CT_HOADON_XUAT.SOLUONG) <>0";
            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DATABAOCAO8>(strcn).ToList());
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DATABAOCAO8>(strch).ToList());
                }
            }
            return DATAX.Select(n => new BAOCAO10 { mapl = n.MAKH, MAQUAY = n.DONVI, soluong = (int)n.soluong, tien = (double)n.tien, mahh = n.mahh, tenhh = n.tenhh, dvt = n.dvt, NAM = n.NGAYLAPHD, NHOM = n.SOHD }).ToList();
        }
        public List<DULIEUBAOCAO28> DATABAOCAO28(List<string> soso, int nam, string phanloai, List<string> phanloaikhachhang, List<string> nhomhang, List<string> sanpham, List<string> quanhuyen, List<string> matinh, List<string> makh, List<string> matdv, List<string> hopdong, List<string> mapl, List<string> makm, List<string> mactht)
        {

            var DATAX = new List<DULIEUBAOCAO28>();
            //String CN
            string strcn = "SELECT TBL_DANHMUCCUAHANG.MACH as TENDVBC,DTA_HOADON_XUAT.MAKH,TBL_DANHMUCKHACHHANG.DONVI AS TENKH,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 1 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG1 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 2 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG2 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 3 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG3 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 4 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG4 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 5 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG5 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 6 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG6 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 7 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG7 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 8 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG8 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 9 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG9 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 10 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG10 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 11 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG11 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 12 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG12 ,SUM( ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ) AS MUAHANG  FROM TBL_MIEN,TBL_DANHMUCCUAHANG,DTA_HOADON_XUAT LEFT JOIN  TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh,DTA_CT_HOADON_XUAT LEFT JOIN  TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH  WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NgayLapHD=DTA_CT_HOADON_XUAT.NgayLapHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.KT=1 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD) =" + nam;
            //String CH
            string strch = "SELECT TBL_DANHMUCCUAHANG.MACH as TENDVBC,DTA_HOADON_XUAT.MAKH,TBL_DANHMUCKHACHHANG.DONVI AS TENKH,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 1 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG1 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 2 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG2 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 3 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG3 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 4 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG4 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 5 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG5 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 6 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG6 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 7 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG7 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 8 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG8 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 9 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG9 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 10 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG10 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 11 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG11 ,SUM(CASE MONTH(DTA_HOADON_XUAT.NgayLapHD) WHEN 12 THEN ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ELSE 0 END) AS MUAHANG12 ,SUM( ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG*DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0) ) AS MUAHANG  FROM TBL_MIEN,TBL_DANHMUCCUAHANG,HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, CT_HOADON_XUAT DTA_CT_HOADON_XUAT LEFT JOIN  DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH  WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NgayLapHD=DTA_CT_HOADON_XUAT.NgayLapHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.KT=1 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD) =" + nam;
            //String MB

            if (phanloai != "ALL")
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloaikhachhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            }
            //if (hopdong != null)
            //{
            //    List<string> kh = new List<string>();
            //    List<string> hd = new List<string>();
            //    foreach (var i in hopdong)
            //    {
            //        var k = i.Split('~').ToList();
            //        hd.Add(k.First());
            //        kh.Add(k.Last());
            //    }
            //    strcn = strcn + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MAKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
            //    strch = strch + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MaKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
            //    //strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            //}
            if (nhomhang != null)
            {
                strcn = strcn + string.Format(" AND Substring(dta_ct_hoadon_xuat.mahh, 1, 2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND SUBSTRING(DTA_CT_HOADON_XUAT.MAHH,1,2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (sanpham != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.MAHH IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCHANGHOA.MAHH IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND replace(dclChiTietHangHoa.MaCap, ' ', '') IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
            }
            if (quanhuyen != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
            }
            if (matinh != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
            }
            if (makh != null)
            {
                strcn = strcn + string.Format(" AND DTA_HOADON_XUAT.MAKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_HOADON_XUAT.MAKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            }
            if (matdv != null)
            {
                strcn = strcn + string.Format(" AND dta_hoadon_xuat.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.MATDV IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            if (mapl != null)
            {
                strcn = strcn + string.Format(" AND DTA_HOADON_XUAT.MAPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_HOADON_XUAT.MAPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
            }
            if (makm != null)
            {
                strcn = strcn + string.Format(" AND DTA_CT_HOADON_XUAT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_CT_HOADON_XUAT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
            }
            if (mactht != null)
            {
                strcn = strcn + string.Format(" AND DTA_CT_HOADON_XUAT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_CT_HOADON_XUAT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
            }
            //DTA_CT_HOADON_XUAT.MAKM
            //String MB
            strcn = strcn + " group by  TBL_MIEN.MIEN,TBL_DANHMUCCUAHANG.MACH,DTA_HOADON_XUAT.MAKH,TBL_DANHMUCKHACHHANG.DONVI order by DTA_HOADON_XUAT.MAKH";
            strch = strch + " group by  TBL_MIEN.MIEN,TBL_DANHMUCCUAHANG.MACH,DTA_HOADON_XUAT.MAKH,TBL_DANHMUCKHACHHANG.DONVI order by DTA_HOADON_XUAT.MAKH";
            //strnew = strnew + "group by  dclChiTietKhachHang.TENCAP, dclChiTietKhachHang.TaiKhoanID,dtaChungTu.SoHoaDon,dtasoluong.TienBan, dclDanhSachDonViTinh.TenDonViTinh, dtasoluong.SOLUONG, dtasoluong.GIAban, dtaDinhKhoan.TaiKhoanNo, dtaChungTu.ngaychungtu, dclChiTietHangHoa.MaCap, dclChiTietHangHoa.TENCAP, tbl_danhmuctieudebaocao.tendvbc, tbl_mien.mien, dtaChungTu.khachhangid, TBL_DANHMUCCUAHANG.MACH ,KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang";

            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DULIEUBAOCAO28>(strcn).ToList());
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DULIEUBAOCAO28>(strch).ToList());
                }
            }
            return DATAX;
        }
        public List<DULIEUBAOCAO17> BAOCAOCHINHANH17(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO17>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO17> BAOCAOCUAHANG17(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO17>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO17> DATABAOCAO17(List<string> soso, string strcn)
        {

            var DATAX = new List<DULIEUBAOCAO17>();
            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(BAOCAOCHINHANH17(queryCN.SingleOrDefault(n => n.macn == x).data, strcn));
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(BAOCAOCUAHANG17(queryCH.SingleOrDefault(n => n.macn == x).data, strcn));
                }
            }
            //foreach (var x in soso)
            //{
            //    if (x == "QN")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(QuangNgai, strcn));
            //    }
            //    else if (x == "TN")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(TayNinh, strcn));
            //    }
            //    else if (x == "CHQ10")
            //    {
            //        DATAX.AddRange(BAOCAOCUAHANG17(CHQ10, strcn));
            //    }
            //    else if (x == "CHPPSP")
            //    {
            //        DATAX.AddRange(BAOCAOCUAHANG17(CHPPSP, strcn));
            //    }
            //    else if (x == "TT423")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(TT423, strcn));
            //    }
            //    else if (x == "BD")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(BinhDinh, strcn));
            //    }
            //    else if (x == "CT")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(CanTho, strcn));
            //    }
            //    else if (x == "DN")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(DongNai, strcn));
            //    }
            //    else if (x == "BDG")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(BinhDuong, strcn));
            //    }
            //    else if (x == "DNA")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(DaNang, strcn));
            //    }
            //    else if (x == "HCM")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(HoChiMinh, strcn));
            //    }
            //    else if (x == "NA")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(NgheAn, strcn));
            //    }
            //    else if (x == "BT")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(BinhThuan, strcn));
            //    }

            //    else if (x == "THO")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(ThanhHoa, strcn));
            //    }
            //    else if (x == "PY")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(PhuYen, strcn));
            //    }
            //    else if (x == "AG")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(AnGiang, strcn));
            //    }
            //    else if (x == "CM")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(CaMau, strcn));
            //    }
            //    else if (x == "GL")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(GiaLai, strcn));
            //    }
            //    else if (x == "HUE")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(Hue, strcn));
            //    }
            //    else if (x == "HP")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(HaiPhong, strcn));
            //    }
            //    else if (x == "LD")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(LamDong, strcn));
            //    }
            //    else if (x == "NT")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(NhaTrang, strcn));
            //    }
            //    else if (x == "TG")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(TienGiang, strcn));
            //    }
            //    else if (x == "VL")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(VinhLong, strcn));
            //    }
            //    else if (x == "DNONG")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(Daknong, strcn));
            //    }
            //    else if (x == "PTTT")
            //    {
            //        DATAX.AddRange(BAOCAOCUAHANG17(PTTT, strcn));
            //    }
            //    else if (x == "QT")
            //    {
            //        DATAX.AddRange(BAOCAOCHINHANH17(QuangTri, strcn));
            //    }
            //}
            return DATAX;
        }
        public List<DULIEUBAOCAO29> DATABAOCAO29(List<string> soso, string phanloai, List<string> phanloaikhachhang, List<string> nhomhang, List<string> sanpham, List<string> quanhuyen, List<string> matinh, List<string> makh, List<string> matdv, List<string> hopdong, List<string> mapl, List<string> makm, List<string> mactht, string qui, int nam)
        {

            var khoan = new Dictionary<int, int>();
            if (qui == "Quí 1")
            {
                khoan.Add(1, 3);
            }
            else if (qui == "Quí 2")
            {
                khoan.Add(1, 6);
            }
            else if (qui == "Quí 3")
            {
                khoan.Add(1, 9);
            }
            else if (qui == "Quí 4")
            {
                khoan.Add(1, 12);
            }
            var DATAX = new List<DULIEUBAOCAO29>();
            //String CN
            string strcn = "DECLARE @KHACHHANG TABLE ( MAKH VARCHAR(20),DONVI NVARCHAR(300),T1 MONEY ,T2 MONEY ,T3 MONEY,TENDVBC NVARCHAR(100) ,DIACHI NVARCHAR(300),MATINH VARCHAR(20),PHANLOAI VARCHAR(20),PHANLOAIKHACHHANG VARCHAR(20) )   INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0))   ,0,0,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG  FROM  DTA_CT_HOADON_XUAT  LEFT JOIN   TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH , DTA_HOADON_XUAT LEFT JOIN  TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh,TBL_DANHMUCTIEUDEBAOCAO  WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  and DTA_CT_HOADON_XUAT.kt=1  AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD) BETWEEN " + khoan.First().Key + " AND " + khoan.First().Value + " AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam;
            //String CH
            string strch = "DECLARE @KHACHHANG TABLE ( MAKH VARCHAR(20),DONVI NVARCHAR(300),T1 MONEY ,T2 MONEY ,T3 MONEY,TENDVBC NVARCHAR(100) ,DIACHI NVARCHAR(300),MATINH VARCHAR(20),PHANLOAI VARCHAR(20),PHANLOAIKHACHHANG VARCHAR(20) )   INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0))  ,0,0,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM  CT_HOADON_XUAT DTA_CT_HOADON_XUAT  LEFT JOIN  DM_HANGHOA  TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH , HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh,TIEUDE TBL_DANHMUCTIEUDEBAOCAO  WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  and DTA_CT_HOADON_XUAT.kt=1  AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD) BETWEEN " + khoan.First().Key + " AND " + khoan.First().Value + "   AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam;
            //String MB

            if (phanloai != "ALL")
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloaikhachhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            }
            //if (hopdong != null)
            //{
            //    List<string> kh = new List<string>();
            //    List<string> hd = new List<string>();
            //    foreach (var i in hopdong)
            //    {
            //        var k = i.Split('~').ToList();
            //        hd.Add(k.First());
            //        kh.Add(k.Last());
            //    }
            //    strcn = strcn + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MAKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
            //    strch = strch + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MaKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
            //    //strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            //}
            if (nhomhang != null)
            {
                strcn = strcn + string.Format(" AND Substring(dta_ct_hoadon_xuat.mahh, 1, 2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND SUBSTRING(DTA_CT_HOADON_XUAT.MAHH,1,2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (sanpham != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.MAHH IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCHANGHOA.MAHH IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND replace(dclChiTietHangHoa.MaCap, ' ', '') IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
            }
            if (quanhuyen != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
            }
            if (matinh != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
            }
            if (makh != null)
            {
                strcn = strcn + string.Format(" AND DTA_HOADON_XUAT.MAKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_HOADON_XUAT.MAKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            }
            if (matdv != null)
            {
                strcn = strcn + string.Format(" AND dta_hoadon_xuat.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.MATDV IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            if (mapl != null)
            {
                strcn = strcn + string.Format(" AND DTA_HOADON_XUAT.MAPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_HOADON_XUAT.MAPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
            }
            if (makm != null)
            {
                strcn = strcn + string.Format(" AND DTA_CT_HOADON_XUAT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_CT_HOADON_XUAT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
            }
            if (mactht != null)
            {
                strcn = strcn + string.Format(" AND DTA_CT_HOADON_XUAT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_CT_HOADON_XUAT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
            }
            //DTA_CT_HOADON_XUAT.MAKM
            //String MB
            strcn = strcn + " GROUP BY DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi,TBL_DANHMUCTIEUDEBAOCAO.tendvbc,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG  Select MAKH,DONVI, SUM(ISNULL(T1,0)) As T1 , TENDVBC FROM @KHACHHANG   GROUP BY  MAKH,DONVI,TENDVBC HAVING SUM(ISNULL(T1,0))  <>0 ORDER BY SUM(ISNULL(T1,0)) DESC";
            strch = strch + " GROUP BY DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi,TBL_DANHMUCTIEUDEBAOCAO.tendvbc ,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG SELECT MAKH,DONVI, SUM(ISNULL(T1,0)) AS T1   ,TENDVBC FROM @KHACHHANG   GROUP BY  MAKH,DONVI,TENDVBC HAVING SUM(ISNULL(T1,0))  <>0      ORDER BY   SUM(ISNULL(T1,0)) DESC";
            //strnew = strnew + "group by  dclChiTietKhachHang.TENCAP, dclChiTietKhachHang.TaiKhoanID,dtaChungTu.SoHoaDon,dtasoluong.TienBan, dclDanhSachDonViTinh.TenDonViTinh, dtasoluong.SOLUONG, dtasoluong.GIAban, dtaDinhKhoan.TaiKhoanNo, dtaChungTu.ngaychungtu, dclChiTietHangHoa.MaCap, dclChiTietHangHoa.TENCAP, tbl_danhmuctieudebaocao.tendvbc, tbl_mien.mien, dtaChungTu.khachhangid, TBL_DANHMUCCUAHANG.MACH ,KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang";
            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DULIEUBAOCAO29>(strcn).ToList());
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DULIEUBAOCAO29>(strch).ToList());
                }
            }
            return DATAX;
        }
        public List<DULIEUBAOCAO27> DATABAOCAO27(List<string> soso, string phanloai, List<string> phanloaikhachhang, List<string> nhomhang, List<string> sanpham, List<string> quanhuyen, List<string> matinh, List<string> makh, List<string> matdv, List<string> hopdong, List<string> mapl, List<string> makm, List<string> mactht, string qui, int nam)
        {

            var DATAX = new List<DULIEUBAOCAO27>();
            string strcn = "";
            string strch = "";

            var strloccn = " ";
            if (phanloai != "ALL")
            {
                strloccn = strloccn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");

            }
            if (mapl != null)
            {
                strloccn = strloccn + string.Format(" AND DTA_HOADON_XUAT.MAPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));

            }
            if (phanloaikhachhang != null)
            {
                strloccn = strloccn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));

            }
            if (nhomhang != null)
            {
                strloccn = strloccn + string.Format(" AND Substring(dta_ct_hoadon_xuat.mahh, 1, 2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));

            }
            if (sanpham != null)
            {
                strloccn = strloccn + string.Format(" AND TBL_DANHMUCHANGHOA.MAHH IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));

            }
            if (quanhuyen != null)
            {
                strloccn = strloccn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));

            }
            if (matinh != null)
            {
                strloccn = strloccn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));

            }
            if (makh != null)
            {
                strloccn = strloccn + string.Format(" AND DTA_HOADON_XUAT.MAKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));

            }
            if (matdv != null)
            {
                strloccn = strloccn + string.Format(" AND dta_hoadon_xuat.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));

            }

            if (makm != null)
            {
                strloccn = strloccn + string.Format(" AND DTA_CT_HOADON_XUAT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));

            }
            if (mactht != null)
            {
                strloccn = strloccn + string.Format(" AND DTA_CT_HOADON_XUAT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));

            }
            if (qui == "Quí 1")
            {
                strcn = "DECLARE @KHACHHANG TABLE(MAKH VARCHAR(20), DONVI NVARCHAR(300), T1 MONEY, T2 MONEY, T3 MONEY, TENDVBC NVARCHAR(100), DIACHI NVARCHAR(300), MATINH VARCHAR(20), PHANLOAI VARCHAR(20), PHANLOAIKHACHHANG VARCHAR(20)) INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)) , 0, 0, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM DTA_CT_HOADON_XUAT LEFT JOIN TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, DTA_HOADON_XUAT LEFT JOIN TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=1 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)=" + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, 0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)), 0, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM DTA_CT_HOADON_XUAT LEFT JOIN TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, DTA_HOADON_XUAT LEFT JOIN TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=2 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + "GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi , 0, 0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)) , TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM DTA_CT_HOADON_XUAT LEFT JOIN TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, DTA_HOADON_XUAT LEFT JOIN TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=3 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG SELECT MAKH, DONVI, SUM(ISNULL(T1, 0)) AS T1, SUM(ISNULL(T2, 0)) AS T2, SUM(ISNULL(T3, 0)) AS T3, TENDVBC FROM @KHACHHANG GROUP BY MAKH, DONVI, TENDVBC HAVING SUM(ISNULL(T1, 0)) <>0 AND SUM(ISNULL(T2, 0)) <> 0 AND SUM(ISNULL(T3, 0)) <> 0 ORDER BY SUM(ISNULL(T1, 0)) + SUM(ISNULL(T2, 0)) + SUM(ISNULL(T3, 0))";
                strch = "DECLARE @KHACHHANG TABLE(MAKH VARCHAR(20), DONVI NVARCHAR(300), T1 MONEY, T2 MONEY, T3 MONEY, TENDVBC NVARCHAR(100), DIACHI NVARCHAR(300), MATINH VARCHAR(20), PHANLOAI VARCHAR(20), PHANLOAIKHACHHANG VARCHAR(20)) INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)), 0, 0, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM CT_HOADON_XUAT DTA_CT_HOADON_XUAT LEFT JOIN DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1   AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=1 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD) =" + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, 0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)), 0, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM CT_HOADON_XUAT DTA_CT_HOADON_XUAT LEFT JOIN DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=2 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi , 0, 0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)), TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM CT_HOADON_XUAT DTA_CT_HOADON_XUAT LEFT JOIN DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=3 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG SELECT MAKH, DONVI, SUM(ISNULL(T1, 0)) AS T1, SUM(ISNULL(T2, 0)) AS T2, SUM(ISNULL(T3, 0)) AS T3, TENDVBC FROM @KHACHHANG GROUP BY MAKH, DONVI, TENDVBC HAVING SUM(ISNULL(T1, 0)) <>0 AND SUM(ISNULL(T2, 0)) <> 0 AND SUM(ISNULL(T3, 0)) <> 0 ORDER BY SUM(ISNULL(T1, 0)) + SUM(ISNULL(T2, 0)) + SUM(ISNULL(T3, 0))";
            }
            else if (qui == "Quí 2")
            {
                strcn = "DECLARE @KHACHHANG TABLE(MAKH VARCHAR(20), DONVI NVARCHAR(300), T1 MONEY, T2 MONEY, T3 MONEY, TENDVBC NVARCHAR(100), DIACHI NVARCHAR(300), MATINH VARCHAR(20), PHANLOAI VARCHAR(20), PHANLOAIKHACHHANG VARCHAR(20)) INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)) , 0, 0, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM DTA_CT_HOADON_XUAT LEFT JOIN TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, DTA_HOADON_XUAT LEFT JOIN TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=4 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)=" + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, 0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)), 0, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM DTA_CT_HOADON_XUAT LEFT JOIN TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, DTA_HOADON_XUAT LEFT JOIN TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=5 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + "GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi , 0, 0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)) , TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM DTA_CT_HOADON_XUAT LEFT JOIN TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, DTA_HOADON_XUAT LEFT JOIN TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=6 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG SELECT MAKH, DONVI, SUM(ISNULL(T1, 0)) AS T1, SUM(ISNULL(T2, 0)) AS T2, SUM(ISNULL(T3, 0)) AS T3, TENDVBC FROM @KHACHHANG GROUP BY MAKH, DONVI, TENDVBC HAVING SUM(ISNULL(T1, 0)) <>0 AND SUM(ISNULL(T2, 0)) <> 0 AND SUM(ISNULL(T3, 0)) <> 0 ORDER BY SUM(ISNULL(T1, 0)) + SUM(ISNULL(T2, 0)) + SUM(ISNULL(T3, 0))";
                strch = "DECLARE @KHACHHANG TABLE(MAKH VARCHAR(20), DONVI NVARCHAR(300), T1 MONEY, T2 MONEY, T3 MONEY, TENDVBC NVARCHAR(100), DIACHI NVARCHAR(300), MATINH VARCHAR(20), PHANLOAI VARCHAR(20), PHANLOAIKHACHHANG VARCHAR(20)) INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)), 0, 0, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM CT_HOADON_XUAT DTA_CT_HOADON_XUAT LEFT JOIN DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1   AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=4 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD) =" + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, 0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)), 0, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM CT_HOADON_XUAT DTA_CT_HOADON_XUAT LEFT JOIN DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=5 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi , 0, 0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)), TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM CT_HOADON_XUAT DTA_CT_HOADON_XUAT LEFT JOIN DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=6 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG SELECT MAKH, DONVI, SUM(ISNULL(T1, 0)) AS T1, SUM(ISNULL(T2, 0)) AS T2, SUM(ISNULL(T3, 0)) AS T3, TENDVBC FROM @KHACHHANG GROUP BY MAKH, DONVI, TENDVBC HAVING SUM(ISNULL(T1, 0)) <>0 AND SUM(ISNULL(T2, 0)) <> 0 AND SUM(ISNULL(T3, 0)) <> 0 ORDER BY SUM(ISNULL(T1, 0)) + SUM(ISNULL(T2, 0)) + SUM(ISNULL(T3, 0))";
            }
            else if (qui == "Quí 3")
            {
                strcn = "DECLARE @KHACHHANG TABLE(MAKH VARCHAR(20), DONVI NVARCHAR(300), T1 MONEY, T2 MONEY, T3 MONEY, TENDVBC NVARCHAR(100), DIACHI NVARCHAR(300), MATINH VARCHAR(20), PHANLOAI VARCHAR(20), PHANLOAIKHACHHANG VARCHAR(20)) INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)) , 0, 0, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM DTA_CT_HOADON_XUAT LEFT JOIN TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, DTA_HOADON_XUAT LEFT JOIN TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=7 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)=" + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, 0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)), 0, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM DTA_CT_HOADON_XUAT LEFT JOIN TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, DTA_HOADON_XUAT LEFT JOIN TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=8 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + "GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi , 0, 0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)) , TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM DTA_CT_HOADON_XUAT LEFT JOIN TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, DTA_HOADON_XUAT LEFT JOIN TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=9 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG SELECT MAKH, DONVI, SUM(ISNULL(T1, 0)) AS T1, SUM(ISNULL(T2, 0)) AS T2, SUM(ISNULL(T3, 0)) AS T3, TENDVBC FROM @KHACHHANG GROUP BY MAKH, DONVI, TENDVBC HAVING SUM(ISNULL(T1, 0)) <>0 AND SUM(ISNULL(T2, 0)) <> 0 AND SUM(ISNULL(T3, 0)) <> 0 ORDER BY SUM(ISNULL(T1, 0)) + SUM(ISNULL(T2, 0)) + SUM(ISNULL(T3, 0))";
                strch = "DECLARE @KHACHHANG TABLE(MAKH VARCHAR(20), DONVI NVARCHAR(300), T1 MONEY, T2 MONEY, T3 MONEY, TENDVBC NVARCHAR(100), DIACHI NVARCHAR(300), MATINH VARCHAR(20), PHANLOAI VARCHAR(20), PHANLOAIKHACHHANG VARCHAR(20)) INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)), 0, 0, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM CT_HOADON_XUAT DTA_CT_HOADON_XUAT LEFT JOIN DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1   AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=7 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD) =" + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, 0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)), 0, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM CT_HOADON_XUAT DTA_CT_HOADON_XUAT LEFT JOIN DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=8 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi , 0, 0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)), TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM CT_HOADON_XUAT DTA_CT_HOADON_XUAT LEFT JOIN DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=9 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG SELECT MAKH, DONVI, SUM(ISNULL(T1, 0)) AS T1, SUM(ISNULL(T2, 0)) AS T2, SUM(ISNULL(T3, 0)) AS T3, TENDVBC FROM @KHACHHANG GROUP BY MAKH, DONVI, TENDVBC HAVING SUM(ISNULL(T1, 0)) <>0 AND SUM(ISNULL(T2, 0)) <> 0 AND SUM(ISNULL(T3, 0)) <> 0 ORDER BY SUM(ISNULL(T1, 0)) + SUM(ISNULL(T2, 0)) + SUM(ISNULL(T3, 0))";
            }
            else if (qui == "Quí 4")
            {
                strcn = "DECLARE @KHACHHANG TABLE(MAKH VARCHAR(20), DONVI NVARCHAR(300), T1 MONEY, T2 MONEY, T3 MONEY, TENDVBC NVARCHAR(100), DIACHI NVARCHAR(300), MATINH VARCHAR(20), PHANLOAI VARCHAR(20), PHANLOAIKHACHHANG VARCHAR(20)) INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)) , 0, 0, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM DTA_CT_HOADON_XUAT LEFT JOIN TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, DTA_HOADON_XUAT LEFT JOIN TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=10 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)=" + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, 0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)), 0, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM DTA_CT_HOADON_XUAT LEFT JOIN TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, DTA_HOADON_XUAT LEFT JOIN TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=11 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + "GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi , 0, 0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)) , TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM DTA_CT_HOADON_XUAT LEFT JOIN TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, DTA_HOADON_XUAT LEFT JOIN TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=12 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG SELECT MAKH, DONVI, SUM(ISNULL(T1, 0)) AS T1, SUM(ISNULL(T2, 0)) AS T2, SUM(ISNULL(T3, 0)) AS T3, TENDVBC FROM @KHACHHANG GROUP BY MAKH, DONVI, TENDVBC HAVING SUM(ISNULL(T1, 0)) <>0 AND SUM(ISNULL(T2, 0)) <> 0 AND SUM(ISNULL(T3, 0)) <> 0 ORDER BY SUM(ISNULL(T1, 0)) + SUM(ISNULL(T2, 0)) + SUM(ISNULL(T3, 0))";
                strch = "DECLARE @KHACHHANG TABLE(MAKH VARCHAR(20), DONVI NVARCHAR(300), T1 MONEY, T2 MONEY, T3 MONEY, TENDVBC NVARCHAR(100), DIACHI NVARCHAR(300), MATINH VARCHAR(20), PHANLOAI VARCHAR(20), PHANLOAIKHACHHANG VARCHAR(20)) INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)), 0, 0, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM CT_HOADON_XUAT DTA_CT_HOADON_XUAT LEFT JOIN DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1   AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=10 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD) =" + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, 0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)), 0, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM CT_HOADON_XUAT DTA_CT_HOADON_XUAT LEFT JOIN DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=11 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG INSERT INTO @KHACHHANG SELECT DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi , 0, 0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY), 0)), TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM CT_HOADON_XUAT DTA_CT_HOADON_XUAT LEFT JOIN DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH, HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh, TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH AND DTA_CT_HOADON_XUAT.kt=1 AND MONTH(DTA_HOADON_XUAT.NGAYLAPHD)=12 AND YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + " GROUP BY DTA_HOADON_XUAT.makh, TBL_DANHMUCKHACHHANG.donvi, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG SELECT MAKH, DONVI, SUM(ISNULL(T1, 0)) AS T1, SUM(ISNULL(T2, 0)) AS T2, SUM(ISNULL(T3, 0)) AS T3, TENDVBC FROM @KHACHHANG GROUP BY MAKH, DONVI, TENDVBC HAVING SUM(ISNULL(T1, 0)) <>0 AND SUM(ISNULL(T2, 0)) <> 0 AND SUM(ISNULL(T3, 0)) <> 0 ORDER BY SUM(ISNULL(T1, 0)) + SUM(ISNULL(T2, 0)) + SUM(ISNULL(T3, 0))";
            }
            else
            {

            }

            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DULIEUBAOCAO27>(strcn).ToList());
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DULIEUBAOCAO27>(strch).ToList());
                }
            }
            return DATAX;
        }
        public List<DULIEUBAOCAO25> DATABAOCAO25(List<string> soso, string phanloai, List<string> phanloaikhachhang, List<string> nhomhang, List<string> sanpham, List<string> quanhuyen, List<string> matinh, List<string> makh, List<string> matdv, List<string> hopdong, List<string> mapl, List<string> makm, List<string> mactht, int nam)
        {

            var DATAX = new List<DULIEUBAOCAO25>();
            string strcn = "";
            string strch = "";
            //string strnew = "";
            var strloccn = " ";
            if (phanloai != "ALL")
            {
                strloccn = strloccn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (mapl != null)
            {
                strloccn = strloccn + string.Format(" AND DTA_HOADON_XUAT.MAPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
            }
            if (phanloaikhachhang != null)
            {
                strloccn = strloccn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            }
            if (nhomhang != null)
            {
                strloccn = strloccn + string.Format(" AND Substring(dta_ct_hoadon_xuat.mahh, 1, 2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (sanpham != null)
            {
                strloccn = strloccn + string.Format(" AND TBL_DANHMUCHANGHOA.MAHH IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
            }
            if (quanhuyen != null)
            {
                strloccn = strloccn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
            }
            if (matinh != null)
            {
                strloccn = strloccn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
            }
            if (makh != null)
            {
                strloccn = strloccn + string.Format(" AND DTA_HOADON_XUAT.MAKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            }
            if (matdv != null)
            {
                strloccn = strloccn + string.Format(" AND dta_hoadon_xuat.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            if (makm != null)
            {
                strloccn = strloccn + string.Format(" AND DTA_CT_HOADON_XUAT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
            }
            if (mactht != null)
            {
                strloccn = strloccn + string.Format(" AND DTA_CT_HOADON_XUAT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
            }
            strcn = strcn + " DECLARE @KHACHHANG TABLE ( MAKH VARCHAR(20),DONVI NVARCHAR(300),T1 MONEY ,T2 MONEY ,T3 MONEY,T4 MONEY,TENDVBC NVARCHAR(100) ,DIACHI NVARCHAR(300),MATINH VARCHAR(20),PHANLOAI VARCHAR(20),PHANLOAIKHACHHANG VARCHAR(20) )   INSERT INTO @KHACHHANG Select  DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG As MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA As MONEY),0)),0 ,0,0,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM  DTA_CT_HOADON_XUAT  LEFT JOIN   TBL_DANHMUCHANGHOA On DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH , DTA_HOADON_XUAT LEFT JOIN  TBL_DANHMUCKHACHHANG On DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh,TBL_DANHMUCTIEUDEBAOCAO  WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD And DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD And DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  And DTA_CT_HOADON_XUAT.kt=1  And MONTH(DTA_HOADON_XUAT.NGAYLAPHD) between 1 And 3  And YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + "  GROUP BY DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi,TBL_DANHMUCTIEUDEBAOCAO.tendvbc,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG   INSERT INTO @KHACHHANG  Select DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi,0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG As MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA As MONEY),0)),0,0,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM  DTA_CT_HOADON_XUAT  LEFT JOIN   TBL_DANHMUCHANGHOA On DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH , DTA_HOADON_XUAT LEFT JOIN  TBL_DANHMUCKHACHHANG On DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh,TBL_DANHMUCTIEUDEBAOCAO  WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD And DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD And DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  And DTA_CT_HOADON_XUAT.kt=1  And MONTH(DTA_HOADON_XUAT.NGAYLAPHD) between 4 And 6  And YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + "  GROUP BY DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi,TBL_DANHMUCTIEUDEBAOCAO.tendvbc,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG   INSERT INTO @KHACHHANG  Select DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi  ,0,0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG As MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA As MONEY),0)) ,0,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM  DTA_CT_HOADON_XUAT  LEFT JOIN   TBL_DANHMUCHANGHOA On DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH , DTA_HOADON_XUAT LEFT JOIN  TBL_DANHMUCKHACHHANG On DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh,TBL_DANHMUCTIEUDEBAOCAO  WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD And DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD And DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  And DTA_CT_HOADON_XUAT.kt=1  And MONTH(DTA_HOADON_XUAT.NGAYLAPHD) between 7 And 9  And YEAR(DTA_HOADON_XUAT.NGAYLAPHD)=" + nam + strloccn + "  GROUP BY DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi,TBL_DANHMUCTIEUDEBAOCAO.tendvbc,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG   INSERT INTO @KHACHHANG  Select DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi ,0 ,0,0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG As MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA As MONEY),0)),TBL_DANHMUCTIEUDEBAOCAO.TENDVBC,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM  DTA_CT_HOADON_XUAT  LEFT JOIN   TBL_DANHMUCHANGHOA On DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH , DTA_HOADON_XUAT LEFT JOIN  TBL_DANHMUCKHACHHANG On DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh,TBL_DANHMUCTIEUDEBAOCAO  WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD And DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD And DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  And DTA_CT_HOADON_XUAT.kt=1  And MONTH(DTA_HOADON_XUAT.NGAYLAPHD) between 10 And 12  And YEAR(DTA_HOADON_XUAT.NGAYLAPHD)=" + nam + strloccn + "  GROUP BY DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi,TBL_DANHMUCTIEUDEBAOCAO.tendvbc,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG  SELECT MAKH,DONVI,DIACHI,MATINH,PHANLOAI,PHANLOAIKHACHHANG, SUM(ISNULL(T1,0)) AS T1 , SUM(ISNULL(T2,0)) AS T2 , SUM(ISNULL(T3,0)) AS T3, SUM(ISNULL(T4,0)) AS T4 ,TENDVBC FROM @KHACHHANG   GROUP BY  MAKH,DONVI,DIACHI,MATINH,PHANLOAI,PHANLOAIKHACHHANG,TENDVBC HAVING SUM(ISNULL(T1,0))  +  SUM(ISNULL(T2,0))  +  SUM(ISNULL(T3,0))+  SUM(ISNULL(T4,0)) <> 0      ORDER BY   SUM(ISNULL(T1,0)) + SUM(ISNULL(T2,0)) + SUM(ISNULL(T3,0)) + SUM(ISNULL(T4,0))";
            strch = strch + " DECLARE @KHACHHANG TABLE ( MAKH VARCHAR(20),DONVI NVARCHAR(300),T1 MONEY ,T2 MONEY ,T3 MONEY,T4 MONEY ,TENDVBC NVARCHAR(100) ,DIACHI NVARCHAR(300),MATINH VARCHAR(20),PHANLOAI VARCHAR(20),PHANLOAIKHACHHANG VARCHAR(20) )   INSERT INTO @KHACHHANG SELECT  DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0)),0 ,0,0,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM  CT_HOADON_XUAT DTA_CT_HOADON_XUAT  LEFT JOIN  DM_HANGHOA  TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH , HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh,TIEUDE TBL_DANHMUCTIEUDEBAOCAO  WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD And DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD And DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  And DTA_CT_HOADON_XUAT.kt=1  And MONTH(DTA_HOADON_XUAT.NGAYLAPHD) between 1 And 3  And YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + "  GROUP BY DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi,TBL_DANHMUCTIEUDEBAOCAO.tendvbc ,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG  INSERT INTO @KHACHHANG  SELECT DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi,0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0)),0,0,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM  CT_HOADON_XUAT DTA_CT_HOADON_XUAT  LEFT JOIN  DM_HANGHOA  TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH , HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh,TIEUDE TBL_DANHMUCTIEUDEBAOCAO  WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD And DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD And DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  And DTA_CT_HOADON_XUAT.kt=1  And MONTH(DTA_HOADON_XUAT.NGAYLAPHD) between 4 And 6  And YEAR(DTA_HOADON_XUAT.NGAYLAPHD)=" + nam + strloccn + "  GROUP BY DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi,TBL_DANHMUCTIEUDEBAOCAO.tendvbc ,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG  INSERT INTO @KHACHHANG  SELECT DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi  ,0,0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0)),0,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM  CT_HOADON_XUAT DTA_CT_HOADON_XUAT  LEFT JOIN  DM_HANGHOA  TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH , HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh,TIEUDE TBL_DANHMUCTIEUDEBAOCAO  WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD And DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD And DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  And DTA_CT_HOADON_XUAT.kt=1  And MONTH(DTA_HOADON_XUAT.NGAYLAPHD) between 7 And 9  And YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + "  GROUP BY DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi,TBL_DANHMUCTIEUDEBAOCAO.tendvbc ,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG  INSERT INTO @KHACHHANG  SELECT DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi ,0 ,0,0, SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0)),TBL_DANHMUCTIEUDEBAOCAO.TENDVBC,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG FROM  CT_HOADON_XUAT DTA_CT_HOADON_XUAT  LEFT JOIN  DM_HANGHOA  TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH , HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh,TIEUDE TBL_DANHMUCTIEUDEBAOCAO  WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD And DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD And DTA_HOADON_XUAT.MACH=DTA_CT_HOADON_XUAT.MACH  And DTA_CT_HOADON_XUAT.kt=1  And MONTH(DTA_HOADON_XUAT.NGAYLAPHD) between 10 And 12  And YEAR(DTA_HOADON_XUAT.NGAYLAPHD)= " + nam + strloccn + "  GROUP BY DTA_HOADON_XUAT.makh,TBL_DANHMUCKHACHHANG.donvi,TBL_DANHMUCTIEUDEBAOCAO.tendvbc ,TBL_DANHMUCKHACHHANG.diachi, TBL_DANHMUCKHACHHANG.MATINH ,TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.PHANLOAIKHACHHANG SELECT MAKH,DONVI,DIACHI,MATINH,PHANLOAI,PHANLOAIKHACHHANG, SUM(ISNULL(T1,0)) AS T1 , SUM(ISNULL(T2,0)) AS T2 , SUM(ISNULL(T3,0)) AS T3, SUM(ISNULL(T4,0)) AS T4 ,TENDVBC FROM @KHACHHANG   GROUP BY  MAKH,DONVI,DIACHI,MATINH,PHANLOAI,PHANLOAIKHACHHANG,TENDVBC HAVING SUM(ISNULL(T1,0))  +  SUM(ISNULL(T2,0))  +  SUM(ISNULL(T3,0))+  SUM(ISNULL(T4,0)) <> 0     ORDER BY   SUM(ISNULL(T1,0)) + SUM(ISNULL(T2,0)) + SUM(ISNULL(T3,0))+  SUM(ISNULL(T4,0))";
            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DULIEUBAOCAO25>(strcn).ToList());
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DULIEUBAOCAO25>(strch).ToList());
                }
            }
            return DATAX;
        }
        //public List<DULIEUBAOCAO> DATABAOCAO(List<string> mapl, List<string> soso, DateTime tungay, DateTime denngay, string phanloai, List<string> phanloaikhachhang, List<string> nhomhang, List<string> sanpham, List<string> quanhuyen, List<string> matinh, List<string> matdv, List<string> hopdong, List<string> makh, List<string> makm, List<string> loaihd, List<string> mactht)
        //{
        //    var DATAX = new List<DULIEUBAOCAO>();
        //    //String CN
        //    string strcn = "seleCT SUM((ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)  -  ROUND(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CT.TYLECK/100,0) ) *HOADON.THUESUAT/100) AS tienvat,HOADON.SOHD_DT as SoHD,SUM(round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CAST(TYLECK AS MONEY)/100,0)) AS TIENCK,HOADON.MaTDV AS MATDV ,TBL_DANHMUCTDV.TenTDV AS TENTDV,HOADON.ngaylaphd AS NGAY, HOADON.MaPL,TBL_MIEN.mien AS MIEN,TBL_DANHMUCTIEUDEBAOCAO.tendvbc AS TENDVBC,TBL_DANHMUCKHACHHANG.matinh AS MATINH,CT.MAKM AS MAKM,CT.MACTHT AS MACTHT,CT.mahh AS MAHH,CT.tenhh AS TENHH, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, SUM(CAST(CT.SOLUONG AS MONEY)) AS SOLUONG, CAST(CT.DonGia AS MONEY) AS DONGIA, CT.DVT, TBL_DANHMUCHANGHOA.nhom AS NHOM, ROUND(CAST(CT.SOLUONG AS MONEY) * (CAST(CT.DONGIA AS MONEY)), 0) AS TIEN from TBL_MIEN, TBL_DANHMUCTIEUDEBAOCAO, DTA_CT_HOADON_XUAT CT LEFT JOIN   TBL_DANHMUCHANGHOA ON CT.mahh = TBL_DANHMUCHANGHOA.mahh, DTA_HOADON_XUAT HOADON   LEFT JOIN   TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh LEFT JOIN TBL_DANHMUCTDV on HOADON.matdv = TBL_DANHMUCTDV.MaTDV " + ((loaihd != null) ? " ,DTA_HOADON_XUAT DTA_HOADON_XUAT_1  LEFT JOIN TBL_DANHMUCHOPDONG ON DTA_HOADON_XUAT_1.HOPDONG=TBL_DANHMUCHOPDONG.mahd AND DTA_HOADON_XUAT_1.MAKH=TBL_DANHMUCHOPDONG.MAKH" : " ") + " where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1";
        //    //String CH
        //    string strch = "Select SUM((ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)  -  ROUND(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CT.TYLECK/100,0) ) *HOADON.THUESUAT/100) AS tienvat,HOADON.SOHD_DT as SoHD,SUM(round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CAST(TYLECK AS MONEY)/100,0)) AS TIENCK,TBL_DANHMUCKHACHHANG.MATDV AS MATDV,DS_TDV_PTTT.TenTDV AS TENTDV,HOADON.ngaylaphd AS NGAY, HOADON.MaPL, TBL_MIEN.mien AS MIEN, TBL_DANHMUCTIEUDEBAOCAO.tendvbc AS TENDVBC, TBL_DANHMUCKHACHHANG.matinh AS MATINH,CT.MAKM AS MAKM , CT.mahh AS MAHH, CT.tenhh AS TENHH, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, SUM(CAST(CT.SOLUONG AS MONEY)) AS SOLUONG, CAST(CT.DonGia AS MONEY) AS DONGIA , CT.DVT ,DM_HANGHOA.nhom AS NHOM , ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0) AS TIEN from TBL_MIEN,tieude TBL_DANHMUCTIEUDEBAOCAO, CT_HOADON_XUAT CT  LEFT JOIN  DM_HANGHOA ON CT.mahh = DM_HANGHOA.mahh, DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG right join HOADON_XUAT  HOADON on TBL_DANHMUCKHACHHANG.makh = HOADON.makh left join DS_TDV_PTTT on TBL_DANHMUCKHACHHANG.MaTDV = DS_TDV_PTTT.MaTDV " + ((loaihd != null) ? " ,DTA_HOADON_XUAT DTA_HOADON_XUAT_1  LEFT JOIN TBL_DANHMUCHOPDONG ON DTA_HOADON_XUAT_1.HOPDONG=TBL_DANHMUCHOPDONG.mahd AND DTA_HOADON_XUAT_1.MAKH=TBL_DANHMUCHOPDONG.MAKH" : " ") + " where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1 ";
        //    //String MB
        //    string strnew = "select SUM(ISNULL(CAST(TIENCHIETKHAU   AS MONEY ),0)) as TIENCK,CAST(sum((ISNULL(CAST(TIENBAN   AS MONEY ),0) -   ISNULL(CAST(TIENCHIETKHAU   AS MONEY ),0)  )*dtasoluong.tylethue/100 ) as FLOAT) as TIENVAT, (select dbo.TCVN2Unicode(dclDanhSachDonViTinh.TenDonViTinh)) as DVT , SUM(ISNULL(CAST(dtasoluong.SOLUONG AS MONEY),0)) as SOLUONG ,SUM(CAST(TIENBAN   AS MONEY))/SUM(CAST(dtasoluong.SOLUONG AS MONEY)) as DONGIA,substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) AS MAPL , dtaChungTu.ngaychungtu as NGAY, substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) as NHOM ,replace(dclChiTietHangHoa.MaCap, ' ', '') AS MAHH, replace(dclChiTietHangHoa.TENCAP, ' ', '')  AS TENHH, ISNULL(CAST(TIENBAN   AS MONEY), 0)  AS TIEN, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_MIEN.MIEN, KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh as MATINH,dtaChungTu.SoHoaDon as SOHD , cast(dtaChungTu.KHACHHANGID as varchar) as MAKH, (select dbo.TCVN2Unicode(dclChiTietKhachHang.TENCAP)) as DONVI, KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang FROM dtasoluong, dtaDinhKhoan, dclChiTietHangHoa, dclChiTietKhachHang, dclDanhSachDonViTinh, tbl_danhmuctieudebaocao, tbl_mien , KT_TH.DBO.TBL_DANHMUCKHACHHANG right join TBL_DANHMUCCUAHANG on KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = TBL_DANHMUCCUAHANG.MaCH right join dtaChungTu ON KT_TH.DBO.TBL_DANHMUCKHACHHANG.makh = CAST(dtaChungTu.KhachHangID as varchar) where dtasoluong.dinhkhoanid = dtaDinhKhoan.CapDKID And dclChiTietKhachHang.TaiKhoanID = dtaChungTu.KHACHHANGID And dtaDinhKhoan.chungtuid = dtaChungTu.chungtuid and dtaDinhKhoan.IDTaiKhoanCo = dclChiTietHangHoa.TaiKhoanID and dclDanhSachDonViTinh.DonViTinhID = dclChiTietHangHoa.DonViTinhID and dtasoluong.SOLUONG != 0  And dtaChungTu.KHACHHANGID IN(select dclChiTietKhachHang.TaiKhoanID from dclChiTietKhachHang) AND substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) = '632' AND dtaChungTu.ngaychungtu between  '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "'";
        //    if (mapl != null)
        //    {
        //        strcn = strcn + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
        //        strch = strch + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
        //        //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
        //    }
        //    if (phanloai != "ALL")
        //    {
        //        strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
        //        strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
        //        strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
        //    }
        //    if (phanloaikhachhang != null)
        //    {
        //        strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
        //        strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
        //        strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
        //    }
        //    if (loaihd != null)
        //    {
        //        strcn = strcn + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
        //        strch = strch + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
        //        strnew = strnew + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
        //    }
        //    if (hopdong != null)
        //    {
        //        List<string> kh = new List<string>();
        //        List<string> hd = new List<string>();
        //        foreach (var i in hopdong)
        //        {
        //            var k = i.Split('~').ToList();
        //            hd.Add(k.First());
        //            kh.Add(k.Last());
        //        }
        //        strcn = strcn + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MAKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
        //        strch = strch + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MaKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
        //        //strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
        //    }
        //    if (nhomhang != null)
        //    {
        //        strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
        //        strch = strch + string.Format(" AND DM_HANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
        //        strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
        //    }
        //    if (sanpham != null)
        //    {
        //        strcn = strcn + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
        //        strch = strch + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
        //        strnew = strnew + string.Format(" AND replace(dclChiTietHangHoa.MaCap, ' ', '') IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
        //    }
        //    if (quanhuyen != null)
        //    {
        //        strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
        //        strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
        //    }
        //    if (matinh != null)
        //    {
        //        strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
        //        strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
        //        strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
        //    }
        //    if (matdv != null)
        //    {
        //        strcn = strcn + string.Format(" AND HOADON.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
        //        strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
        //    }
        //    if (makh != null)
        //    {
        //        strcn = strcn + string.Format(" AND HOADON.makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
        //        strch = strch + string.Format(" AND HOADON.makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
        //    }
        //    if (makm != null)
        //    {
        //        strcn = strcn + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
        //        strch = strch + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
        //    }
        //    if (mactht != null)
        //    {

        //        strcn = strcn + string.Format(" AND CT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
        //        strch = strch + string.Format(" AND CT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));

        //    }
        //    //String MB
        //    strcn = strcn + " GROUP BY TBL_DANHMUCTDV.TenTDV,HOADON.SOHD_DT,CT.MAKM,CT.MACTHT,HOADON.MATDV,HOADON.ngaylaphd, HOADON.MaPL, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, CT.tenhh, TBL_DANHMUCKHACHHANG.phanloai, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, CAST(CT.SOLUONG AS MONEY), CT.DonGia, CT.DVT, TBL_DANHMUCHANGHOA.nhom, ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)";
        //    strch = strch + " GROUP BY DS_TDV_PTTT.TenTDV,HOADON.SOHD_DT,CT.MAKM ,TBL_DANHMUCKHACHHANG.MATDV,DM_HANGHOA.nhom, HOADON.MaPL, HOADON.ngaylaphd, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, CT.tenhh, TBL_DANHMUCKHACHHANG.phanloai, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, CAST(CT.SOLUONG AS MONEY), CT.DonGia, CT.DVT, ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)";
        //    strnew = strnew + "group by  dclChiTietKhachHang.TENCAP, dclChiTietKhachHang.TaiKhoanID,dtaChungTu.SoHoaDon,dtasoluong.TienBan, dclDanhSachDonViTinh.TenDonViTinh, dtasoluong.SOLUONG, dtasoluong.GIAban, dtaDinhKhoan.TaiKhoanNo, dtaChungTu.ngaychungtu, dclChiTietHangHoa.MaCap, dclChiTietHangHoa.TENCAP, tbl_danhmuctieudebaocao.tendvbc, tbl_mien.mien, dtaChungTu.khachhangid, TBL_DANHMUCCUAHANG.MACH ,KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang";
        //    foreach (var x in soso)
        //    {

        //        if (x == "QN")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(QuangNgai, strcn));
        //        }
        //        else if (x == "TN")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(TayNinh, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
        //        }
        //        //else if (x == "TB2")
        //        //{
        //        //    DATAX.AddRange(BAOCAOMIENBAC(ThaiBinh2, strnew));
        //        //}
        //        ////else if (x == "HN_2")
        //        ////{
        //        ////    DATAX.AddRange(BAOCAOCHINHANH(HaNoi, strcn));
        //        ////}
        //        //else if (x == "HN2")
        //        //{
        //        //    DATAX.AddRange(BAOCAOMIENBAC(HaNoi2, strnew));
        //        //    //DATAX.AddRange(BAOCAOMIENBAC(ThaiNguyen, strnew.Replace("KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = TBL_DANHMUCCUAHANG.MaCH", "KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH IN ('HN','TB','PT')")));
        //        //}
        //        //else if (x == "TNG2")
        //        //{
        //        //    DATAX.AddRange(BAOCAOMIENBAC(ThaiNguyen2, strnew));
        //        //    //DATAX.AddRange(BAOCAOMIENBAC(ThaiNguyen, strnew.Replace("KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = TBL_DANHMUCCUAHANG.MaCH", "KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH IN ('HN','TB','PT')")));
        //        //}
        //        else if (x == "CHQ10")
        //        {
        //            DATAX.AddRange(BAOCAOCUAHANG(CHQ10, strch));
        //        }
        //        else if (x == "CHPPSP")
        //        {
        //            DATAX.AddRange(BAOCAOCUAHANG(CHPPSP, strch.Replace("SOHD_DT", "SoHD")));
        //        }
        //        else if (x == "TT423")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(TT423, strcn));
        //        }
        //        else if (x == "BD")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(BinhDinh, strcn));
        //        }
        //        else if (x == "CT")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(CanTho, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
        //        }
        //        else if (x == "DN")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(DongNai, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
        //        }
        //        else if (x == "BDG")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(BinhDuong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
        //        }
        //        else if (x == "DNA")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(DaNang, strcn.Replace("SOHD_DT", "SoHD")));
        //        }
        //        else if (x == "HCM")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(HoChiMinh, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
        //        }
        //        else if (x == "NA")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(NgheAn, strcn));
        //        }
        //        else if (x == "HN")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(HaNoi, strcn));
        //        }
        //        else if (x == "TB")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(ThaiBinh, strcn));
        //        }
        //        else if (x == "PT")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(PhuTho, strcn));
        //        }
        //        else if (x == "TNG")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(ThaiNguyen, strcn));
        //        }
        //        else if (x == "BT")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(BinhThuan, strcn));
        //        }

        //        else if (x == "THO")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(ThanhHoa, strcn));
        //        }
        //        //else if (x == "PT2")
        //        //{
        //        //    DATAX.AddRange(BAOCAOMIENBAC(PhuTho2, strnew));
        //        //}
        //        else if (x == "PY")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(PhuYen, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
        //        }
        //        else if (x == "AG")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(AnGiang, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
        //        }
        //        else if (x == "CM")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(CaMau, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
        //        }
        //        else if (x == "GL")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(GiaLai, strcn));
        //        }
        //        else if (x == "HUE")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(Hue, strcn));
        //        }
        //        else if (x == "HP")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(HaiPhong, strcn));
        //        }
        //        else if (x == "LD")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(LamDong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
        //        }
        //        else if (x == "NT")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(NhaTrang, strcn));
        //        }
        //        else if (x == "TG")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(TienGiang, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
        //        }
        //        else if (x == "VL")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(VinhLong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
        //        }
        //        else if (x == "DNONG")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(Daknong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "").Replace(", TBL_DANHMUCKHACHHANG.phanloaikhachhang", "")));
        //        }
        //        else if (x == "PTTT")
        //        {
        //            DATAX.AddRange(BAOCAOCUAHANG(PTTT, strch));
        //        }
        //        else if (x == "QT")
        //        {
        //            DATAX.AddRange(BAOCAOCHINHANH(QuangTri, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
        //        }
        //    }
        //    return DATAX;
        //}
        public List<DULIEUBAOCAO> DATABAOCAOKM(List<string> mapl, List<string> soso, DateTime tungay, DateTime denngay, string phanloai, List<string> phanloaikhachhang, List<string> nhomhang, List<string> sanpham, List<string> quanhuyen, List<string> matinh, List<string> matdv, List<string> hopdong, List<string> makh, List<string> makm, List<string> loaihd, List<string> mactht)
        {
            var DATAX = new List<DULIEUBAOCAO>();
            //String CN
            string strcn = "seleCT SUM((ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)  -  ROUND(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CT.TYLECK/100,0) ) *HOADON.THUESUAT/100) AS tienvat,HOADON.SOHD_DT as SoHD,SUM(round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CAST(TYLECK AS MONEY)/100,0)) AS TIENCK,HOADON.MaTDV AS MATDV ,TBL_DANHMUCTDV.TenTDV AS TENTDV,HOADON.ngaylaphd AS NGAY, HOADON.MaPL,TBL_MIEN.mien AS MIEN,TBL_DANHMUCTIEUDEBAOCAO.tendvbc AS TENDVBC,TBL_DANHMUCKHACHHANG.matinh AS MATINH,CT.MAKM AS MAKM,CT.MACTHT AS MACTHT,CT.mahh AS MAHH,CT.tenhh AS TENHH, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, SUM(CAST(CT.SOLUONG AS MONEY)) AS SOLUONG, CAST(CT.DonGia AS MONEY) AS DONGIA, CT.DVT, TBL_DANHMUCHANGHOA.nhom AS NHOM, ROUND(CAST(CT.SOLUONG AS MONEY) * (CAST(CT.DONGIA AS MONEY)), 0) AS TIEN from TBL_MIEN, TBL_DANHMUCTIEUDEBAOCAO, DTA_CT_HOADON_XUAT CT LEFT JOIN   TBL_DANHMUCHANGHOA ON CT.mahh = TBL_DANHMUCHANGHOA.mahh, DTA_HOADON_XUAT HOADON   LEFT JOIN   TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh LEFT JOIN TBL_DANHMUCTDV on HOADON.matdv = TBL_DANHMUCTDV.MaTDV " + ((loaihd != null) ? " ,DTA_HOADON_XUAT DTA_HOADON_XUAT_1  LEFT JOIN TBL_DANHMUCHOPDONG ON DTA_HOADON_XUAT_1.HOPDONG=TBL_DANHMUCHOPDONG.mahd AND DTA_HOADON_XUAT_1.MAKH=TBL_DANHMUCHOPDONG.MAKH" : " ") + " where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1";
            //String CH
            string strch = "Select SUM((ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)  -  ROUND(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CT.TYLECK/100,0) ) *HOADON.THUESUAT/100) AS tienvat,HOADON.SOHD_DT as SoHD,SUM(round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CAST(TYLECK AS MONEY)/100,0)) AS TIENCK,TBL_DANHMUCKHACHHANG.MaTDV AS MATDV,DS_TDV_PTTT.TenTDV AS TENTDV,HOADON.ngaylaphd AS NGAY, HOADON.MaPL, TBL_MIEN.mien AS MIEN, TBL_DANHMUCTIEUDEBAOCAO.tendvbc AS TENDVBC, TBL_DANHMUCKHACHHANG.matinh AS MATINH,CT.MAKM AS MAKM , CT.mahh AS MAHH, CT.tenhh AS TENHH, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, SUM(CAST(CT.SOLUONG AS MONEY)) AS SOLUONG, CAST(CT.DonGia AS MONEY) AS DONGIA , CT.DVT ,DM_HANGHOA.nhom AS NHOM , ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0) AS TIEN from TBL_MIEN,tieude TBL_DANHMUCTIEUDEBAOCAO, CT_HOADON_XUAT CT  LEFT JOIN  DM_HANGHOA ON CT.mahh = DM_HANGHOA.mahh, DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG right join HOADON_XUAT  HOADON on TBL_DANHMUCKHACHHANG.makh = HOADON.makh left join DS_TDV_PTTT on HOADON.MaTDV = DS_TDV_PTTT.MaTDV " + ((loaihd != null) ? " ,DTA_HOADON_XUAT DTA_HOADON_XUAT_1  LEFT JOIN TBL_DANHMUCHOPDONG ON DTA_HOADON_XUAT_1.HOPDONG=TBL_DANHMUCHOPDONG.mahd AND DTA_HOADON_XUAT_1.MAKH=TBL_DANHMUCHOPDONG.MAKH" : " ") + " where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1 ";
            //String MB
            string strnew = "select SUM(ISNULL(CAST(TIENCHIETKHAU   AS MONEY ),0)) as TIENCK,CAST(sum((ISNULL(CAST(TIENBAN   AS MONEY ),0) -   ISNULL(CAST(TIENCHIETKHAU   AS MONEY ),0)  )*dtasoluong.tylethue/100 ) as FLOAT) as TIENVAT, (select dbo.TCVN2Unicode(dclDanhSachDonViTinh.TenDonViTinh)) as DVT , SUM(ISNULL(CAST(dtasoluong.SOLUONG AS MONEY),0)) as SOLUONG ,SUM(CAST(TIENBAN   AS MONEY))/SUM(CAST(dtasoluong.SOLUONG AS MONEY)) as DONGIA,substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) AS MAPL , dtaChungTu.ngaychungtu as NGAY, substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) as NHOM ,replace(dclChiTietHangHoa.MaCap, ' ', '') AS MAHH, replace(dclChiTietHangHoa.TENCAP, ' ', '')  AS TENHH, ISNULL(CAST(TIENBAN   AS MONEY), 0)  AS TIEN, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_MIEN.MIEN, KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh as MATINH,dtaChungTu.SoHoaDon as SOHD , cast(dtaChungTu.KHACHHANGID as varchar) as MAKH, (select dbo.TCVN2Unicode(dclChiTietKhachHang.TENCAP)) as DONVI, KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang FROM dtasoluong, dtaDinhKhoan, dclChiTietHangHoa, dclChiTietKhachHang, dclDanhSachDonViTinh, tbl_danhmuctieudebaocao, tbl_mien , KT_TH.DBO.TBL_DANHMUCKHACHHANG right join TBL_DANHMUCCUAHANG on KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = TBL_DANHMUCCUAHANG.MaCH right join dtaChungTu ON KT_TH.DBO.TBL_DANHMUCKHACHHANG.makh = CAST(dtaChungTu.KhachHangID as varchar) where dtasoluong.dinhkhoanid = dtaDinhKhoan.CapDKID And dclChiTietKhachHang.TaiKhoanID = dtaChungTu.KHACHHANGID And dtaDinhKhoan.chungtuid = dtaChungTu.chungtuid and dtaDinhKhoan.IDTaiKhoanCo = dclChiTietHangHoa.TaiKhoanID and dclDanhSachDonViTinh.DonViTinhID = dclChiTietHangHoa.DonViTinhID and dtasoluong.SOLUONG != 0  And dtaChungTu.KHACHHANGID IN(select dclChiTietKhachHang.TaiKhoanID from dclChiTietKhachHang) AND substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) = '632' AND dtaChungTu.ngaychungtu between  '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "'";
            if (mapl != null)
            {
                strcn = strcn + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloai != "ALL")
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloaikhachhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            }
            if (loaihd != null)
            {
                strcn = strcn + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
                strch = strch + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
                strnew = strnew + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
            }
            if (hopdong != null)
            {
                List<string> kh = new List<string>();
                List<string> hd = new List<string>();
                foreach (var i in hopdong)
                {
                    var k = i.Split('~').ToList();
                    hd.Add(k.First());
                    kh.Add(k.Last());
                }
                strcn = strcn + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MAKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MaKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (nhomhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DM_HANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (sanpham != null)
            {
                strcn = strcn + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND replace(dclChiTietHangHoa.MaCap, ' ', '') IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
            }
            if (quanhuyen != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
            }
            if (matinh != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
            }
            if (matdv != null)
            {
                strcn = strcn + string.Format(" AND HOADON.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.MaTDV IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            if (makh != null)
            {
                strcn = strcn + string.Format(" AND HOADON.makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            }
            if (makm != null)
            {
                strcn = strcn + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
            }
            if (mactht != null)
            {

                strcn = strcn + string.Format(" AND CT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));

            }
            //String MB
            strcn = strcn + " GROUP BY TBL_DANHMUCTDV.TenTDV,HOADON.SOHD_DT,CT.MAKM,CT.MACTHT,HOADON.MATDV,HOADON.ngaylaphd, HOADON.MaPL, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, CT.tenhh, TBL_DANHMUCKHACHHANG.phanloai, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, CAST(CT.SOLUONG AS MONEY), CT.DonGia, CT.DVT, TBL_DANHMUCHANGHOA.nhom, ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)";
            strch = strch + " GROUP BY DS_TDV_PTTT.TenTDV,HOADON.SOHD_DT,CT.MAKM ,TBL_DANHMUCKHACHHANG.MaTDV,DM_HANGHOA.nhom, HOADON.MaPL, HOADON.ngaylaphd, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, CT.tenhh, TBL_DANHMUCKHACHHANG.phanloai, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, CAST(CT.SOLUONG AS MONEY), CT.DonGia, CT.DVT, ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)";
            strnew = strnew + "group by dclChiTietKhachHang.TENCAP, dclChiTietKhachHang.TaiKhoanID,dtaChungTu.SoHoaDon,dtasoluong.TienBan, dclDanhSachDonViTinh.TenDonViTinh, dtasoluong.SOLUONG, dtasoluong.GIAban, dtaDinhKhoan.TaiKhoanNo, dtaChungTu.ngaychungtu, dclChiTietHangHoa.MaCap, dclChiTietHangHoa.TENCAP, tbl_danhmuctieudebaocao.tendvbc, tbl_mien.mien, dtaChungTu.khachhangid, TBL_DANHMUCCUAHANG.MACH ,KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang";
            foreach (var x in soso)
            {
                if (x == "QN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(QuangNgai, strcn));
                }
                else if (x == "TN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(TayNinh, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                //else if (x == "TB2")
                //{
                //    DATAX.AddRange(BAOCAOMIENBAC(ThaiBinh2, strnew));
                //}
                ////else if (x == "HN_2")
                ////{
                ////    DATAX.AddRange(BAOCAOCHINHANH(HaNoi, strcn));
                ////}
                //else if (x == "HN2")
                //{
                //    DATAX.AddRange(BAOCAOMIENBAC(HaNoi2, strnew));
                //    //DATAX.AddRange(BAOCAOMIENBAC(ThaiNguyen, strnew.Replace("KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = TBL_DANHMUCCUAHANG.MaCH", "KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH IN ('HN','TB','PT')")));
                //}
                //else if (x == "TNG2")
                //{
                //    DATAX.AddRange(BAOCAOMIENBAC(ThaiNguyen2, strnew));
                //    //DATAX.AddRange(BAOCAOMIENBAC(ThaiNguyen, strnew.Replace("KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = TBL_DANHMUCCUAHANG.MaCH", "KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH IN ('HN','TB','PT')")));
                //}
                else if (x == "CHQ10")
                {
                    DATAX.AddRange(BAOCAOCUAHANG(CHQ10, strch));
                }
                else if (x == "CHPPSP")
                {
                    DATAX.AddRange(BAOCAOCUAHANG(CHPPSP, strch.Replace("SOHD_DT", "SoHD")));
                }
                else if (x == "TT423")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(TT423, strcn));
                }
                else if (x == "BD")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(BinhDinh, strcn));
                }
                else if (x == "CT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(CanTho, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(DongNai, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "BDG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(BinhDuong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DNA")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(DaNang, strcn));
                }
                else if (x == "HCM")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(HoChiMinh, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "NA")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(NgheAn, strcn));
                }
                else if (x == "HN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(HaNoi, strcn));
                }
                else if (x == "TB")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(ThaiBinh, strcn));
                }
                else if (x == "PT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(PhuTho, strcn));
                }
                else if (x == "TNG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(ThaiNguyen, strcn));
                }
                else if (x == "BT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(BinhThuan, strcn));
                }

                else if (x == "THO")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(ThanhHoa, strcn));
                }
                //else if (x == "PT2")
                //{
                //    DATAX.AddRange(BAOCAOMIENBAC(PhuTho2, strnew));
                //}
                else if (x == "PY")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(PhuYen, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "AG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(AnGiang, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "CM")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(CaMau, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "GL")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(GiaLai, strcn));
                }
                else if (x == "HUE")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(Hue, strcn));
                }
                else if (x == "HP")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(HaiPhong, strcn));
                }
                else if (x == "LD")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(LamDong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "NT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(NhaTrang, strcn));
                }
                else if (x == "TG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(TienGiang, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "VL")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(VinhLong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DNONG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(Daknong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "").Replace(", TBL_DANHMUCKHACHHANG.phanloaikhachhang", "")));
                }
                else if (x == "PTTT")
                {
                    DATAX.AddRange(BAOCAOCUAHANG(PTTT, strch.Replace("DS_TDV_PTTT.TenTDV", "DS_TDV_PTTT.MANV,DS_TDV_PTTT.TenTDV")));
                }
                else if (x == "QT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(QuangTri, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
            }
            return DATAX;
        }

        public List<DULIEUBAOCAO> DATABAOCAO(List<string> mapl, List<string> soso, DateTime tungay, DateTime denngay, string phanloai, List<string> phanloaikhachhang, List<string> nhomhang, List<string> sanpham, List<string> quanhuyen, List<string> matinh, List<string> matdv, List<string> hopdong, List<string> makh, List<string> makm, List<string> loaihd, List<string> mactht)
        {
            var DATAX = new List<DULIEUBAOCAO>();
            //String CN
            string strcn = "seleCT SUM((ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)  -  ROUND(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CT.TYLECK/100,0) ) *HOADON.THUESUAT/100) AS tienvat,HOADON.SOHD_DT as SoHD,SUM(round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CAST(TYLECK AS MONEY)/100,0)) AS TIENCK,HOADON.MaTDV AS MATDV ,TBL_DANHMUCTDV.TenTDV AS TENTDV,HOADON.ngaylaphd AS NGAY, HOADON.MaPL,TBL_MIEN.mien AS MIEN,TBL_DANHMUCTIEUDEBAOCAO.tendvbc AS TENDVBC,TBL_DANHMUCKHACHHANG.matinh AS MATINH,CT.MAKM AS MAKM,CT.MACTHT AS MACTHT,CT.mahh AS MAHH,TBL_DANHMUCHANGHOA.TENHH AS TENHH, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, SUM(CAST(CT.SOLUONG AS MONEY)) AS SOLUONG, CAST(CT.DonGia AS MONEY) AS DONGIA, CT.DVT, TBL_DANHMUCHANGHOA.nhom AS NHOM, ROUND(CAST(CT.SOLUONG AS MONEY) * (CAST(CT.DONGIA AS MONEY)), 0) AS TIEN from TBL_MIEN, TBL_DANHMUCTIEUDEBAOCAO, DTA_CT_HOADON_XUAT CT LEFT JOIN   TBL_DANHMUCHANGHOA ON CT.mahh = TBL_DANHMUCHANGHOA.mahh, DTA_HOADON_XUAT HOADON   LEFT JOIN   TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh LEFT JOIN TBL_DANHMUCTDV on HOADON.matdv = TBL_DANHMUCTDV.MaTDV " + ((loaihd != null) ? " ,DTA_HOADON_XUAT DTA_HOADON_XUAT_1  LEFT JOIN TBL_DANHMUCHOPDONG ON DTA_HOADON_XUAT_1.HOPDONG=TBL_DANHMUCHOPDONG.mahd AND DTA_HOADON_XUAT_1.MAKH=TBL_DANHMUCHOPDONG.MAKH" : " ") + " where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1";
            //String CH
            string strch = "Select SUM((ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)  -  ROUND(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CT.TYLECK/100,0) ) *HOADON.THUESUAT/100) AS tienvat,HOADON.SOHD_DT as SoHD,SUM(round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CAST(TYLECK AS MONEY)/100,0)) AS TIENCK,HOADON.MaTDV AS MATDV,DS_TDV_PTTT.TenTDV AS TENTDV,HOADON.ngaylaphd AS NGAY, HOADON.MaPL, TBL_MIEN.mien AS MIEN, TBL_DANHMUCTIEUDEBAOCAO.tendvbc AS TENDVBC, TBL_DANHMUCKHACHHANG.matinh AS MATINH,CT.MAKM AS MAKM , CT.mahh AS MAHH, DM_HANGHOA.TENHH AS TENHH, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, SUM(CAST(CT.SOLUONG AS MONEY)) AS SOLUONG, CAST(CT.DonGia AS MONEY) AS DONGIA , CT.DVT ,DM_HANGHOA.nhom AS NHOM , ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0) AS TIEN from TBL_MIEN,tieude TBL_DANHMUCTIEUDEBAOCAO, CT_HOADON_XUAT CT  LEFT JOIN  DM_HANGHOA ON CT.mahh = DM_HANGHOA.mahh, DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG right join HOADON_XUAT  HOADON on TBL_DANHMUCKHACHHANG.makh = HOADON.makh left join DS_TDV_PTTT on HOADON.MaTDV = DS_TDV_PTTT.MaTDV " + ((loaihd != null) ? " ,HOADON_XUAT DTA_HOADON_XUAT_1  LEFT JOIN TBL_DANHMUCHOPDONG ON DTA_HOADON_XUAT_1.HOPDONG=TBL_DANHMUCHOPDONG.mahd AND DTA_HOADON_XUAT_1.MAKH=TBL_DANHMUCHOPDONG.MAKH" : " ") + " where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1 ";
            //String MB
            string strnew = "select SUM(ISNULL(CAST(TIENCHIETKHAU   AS MONEY ),0)) as TIENCK,CAST(sum((ISNULL(CAST(TIENBAN   AS MONEY ),0) -   ISNULL(CAST(TIENCHIETKHAU   AS MONEY ),0)  )*dtasoluong.tylethue/100 ) as FLOAT) as TIENVAT, (select dbo.TCVN2Unicode(dclDanhSachDonViTinh.TenDonViTinh)) as DVT , SUM(ISNULL(CAST(dtasoluong.SOLUONG AS MONEY),0)) as SOLUONG ,SUM(CAST(TIENBAN   AS MONEY))/SUM(CAST(dtasoluong.SOLUONG AS MONEY)) as DONGIA,substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) AS MAPL , dtaChungTu.ngaychungtu as NGAY, substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) as NHOM ,replace(dclChiTietHangHoa.MaCap, ' ', '') AS MAHH, replace(dclChiTietHangHoa.TENCAP, ' ', '')  AS TENHH, ISNULL(CAST(TIENBAN   AS MONEY), 0)  AS TIEN, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_MIEN.MIEN, KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh as MATINH,dtaChungTu.SoHoaDon as SOHD , cast(dtaChungTu.KHACHHANGID as varchar) as MAKH, (select dbo.TCVN2Unicode(dclChiTietKhachHang.TENCAP)) as DONVI, KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang FROM dtasoluong, dtaDinhKhoan, dclChiTietHangHoa, dclChiTietKhachHang, dclDanhSachDonViTinh, tbl_danhmuctieudebaocao, tbl_mien , KT_TH.DBO.TBL_DANHMUCKHACHHANG right join TBL_DANHMUCCUAHANG on KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = TBL_DANHMUCCUAHANG.MaCH right join dtaChungTu ON KT_TH.DBO.TBL_DANHMUCKHACHHANG.makh = CAST(dtaChungTu.KhachHangID as varchar) where dtasoluong.dinhkhoanid = dtaDinhKhoan.CapDKID And dclChiTietKhachHang.TaiKhoanID = dtaChungTu.KHACHHANGID And dtaDinhKhoan.chungtuid = dtaChungTu.chungtuid and dtaDinhKhoan.IDTaiKhoanCo = dclChiTietHangHoa.TaiKhoanID and dclDanhSachDonViTinh.DonViTinhID = dclChiTietHangHoa.DonViTinhID and dtasoluong.SOLUONG != 0  And dtaChungTu.KHACHHANGID IN(select dclChiTietKhachHang.TaiKhoanID from dclChiTietKhachHang) AND substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) = '632' AND dtaChungTu.ngaychungtu between  '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "'";
            if (mapl != null)
            {
                strcn = strcn + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloai != "ALL")
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloaikhachhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            }
            if (loaihd != null)
            {
                strcn = strcn + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
                strch = strch + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
                strnew = strnew + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
            }
            if (hopdong != null)
            {
                List<string> kh = new List<string>();
                List<string> hd = new List<string>();
                foreach (var i in hopdong)
                {
                    var k = i.Split('~').ToList();
                    hd.Add(k.First());
                    kh.Add(k.Last());
                }
                strcn = strcn + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MAKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MaKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (nhomhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DM_HANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (sanpham != null)
            {
                strcn = strcn + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND replace(dclChiTietHangHoa.MaCap, ' ', '') IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
            }
            if (quanhuyen != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
            }
            if (matinh != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
            }
            if (matdv != null)
            {
                strcn = strcn + string.Format(" AND HOADON.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.MaTDV IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            if (makh != null)
            {
                strcn = strcn + string.Format(" AND HOADON.makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            }
            if (makm != null)
            {
                strcn = strcn + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
            }
            if (mactht != null)
            {

                strcn = strcn + string.Format(" AND CT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));

            }
            //String MB
            strcn = strcn + " GROUP BY TBL_DANHMUCTDV.TenTDV,HOADON.SOHD_DT,CT.MAKM,CT.MACTHT,HOADON.MATDV,HOADON.ngaylaphd, HOADON.MaPL, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, TBL_DANHMUCHANGHOA.TENHH, TBL_DANHMUCKHACHHANG.phanloai, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, CAST(CT.SOLUONG AS MONEY), CT.DonGia, CT.DVT, TBL_DANHMUCHANGHOA.nhom, ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)";
            strch = strch + " GROUP BY DS_TDV_PTTT.TenTDV,HOADON.SOHD_DT,CT.MAKM ,HOADON.MaTDV,DM_HANGHOA.nhom, HOADON.MaPL, HOADON.ngaylaphd, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, DM_HANGHOA.TENHH, TBL_DANHMUCKHACHHANG.phanloai, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, CAST(CT.SOLUONG AS MONEY), CT.DonGia, CT.DVT, ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)";
            strnew = strnew + "group by dclChiTietKhachHang.TENCAP, dclChiTietKhachHang.TaiKhoanID,dtaChungTu.SoHoaDon,dtasoluong.TienBan, dclDanhSachDonViTinh.TenDonViTinh, dtasoluong.SOLUONG, dtasoluong.GIAban, dtaDinhKhoan.TaiKhoanNo, dtaChungTu.ngaychungtu, dclChiTietHangHoa.MaCap, dclChiTietHangHoa.TENCAP, tbl_danhmuctieudebaocao.tendvbc, tbl_mien.mien, dtaChungTu.khachhangid, TBL_DANHMUCCUAHANG.MACH ,KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang";
            foreach (var x in soso)
            {
                if (x == "QN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(QuangNgai, strcn));
                }
                else if (x == "TN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(TayNinh, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                //else if (x == "TB2")
                //{
                //    DATAX.AddRange(BAOCAOMIENBAC(ThaiBinh2, strnew));
                //}
                ////else if (x == "HN_2")
                ////{
                ////    DATAX.AddRange(BAOCAOCHINHANH(HaNoi, strcn));
                ////}
                //else if (x == "HN2")
                //{
                //    DATAX.AddRange(BAOCAOMIENBAC(HaNoi2, strnew));
                //    //DATAX.AddRange(BAOCAOMIENBAC(ThaiNguyen, strnew.Replace("KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = TBL_DANHMUCCUAHANG.MaCH", "KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH IN ('HN','TB','PT')")));
                //}
                //else if (x == "TNG2")
                //{
                //    DATAX.AddRange(BAOCAOMIENBAC(ThaiNguyen2, strnew));
                //    //DATAX.AddRange(BAOCAOMIENBAC(ThaiNguyen, strnew.Replace("KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = TBL_DANHMUCCUAHANG.MaCH", "KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH IN ('HN','TB','PT')")));
                //}
                else if (x == "CHQ10")
                {
                    DATAX.AddRange(BAOCAOCUAHANG(CHQ10, strch));
                }
                else if (x == "CHPPSP")
                {
                    DATAX.AddRange(BAOCAOCUAHANG(CHPPSP, strch.Replace("SOHD_DT", "SoHD")));
                }
                else if (x == "TT423")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(TT423, strcn));
                }
                else if (x == "BD")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(BinhDinh, strcn));
                }
                else if (x == "CT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(CanTho, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(DongNai, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "BDG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(BinhDuong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DNA")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(DaNang, strcn));
                }
                else if (x == "HCM")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(HoChiMinh, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "NA")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(NgheAn, strcn));
                }
                else if (x == "HN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(HaNoi, strcn));
                }
                else if (x == "TB")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(ThaiBinh, strcn));
                }
                else if (x == "PT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(PhuTho, strcn));
                }
                else if (x == "TNG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(ThaiNguyen, strcn));
                }
                else if (x == "BT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(BinhThuan, strcn));
                }

                else if (x == "THO")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(ThanhHoa, strcn));
                }
                //else if (x == "PT2")
                //{
                //    DATAX.AddRange(BAOCAOMIENBAC(PhuTho2, strnew));
                //}
                else if (x == "PY")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(PhuYen, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "AG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(AnGiang, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "CM")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(CaMau, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "GL")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(GiaLai, strcn));
                }
                else if (x == "HUE")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(Hue, strcn));
                }
                else if (x == "HP")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(HaiPhong, strcn));
                }
                else if (x == "LD")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(LamDong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "NT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(NhaTrang, strcn));
                }
                else if (x == "TG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(TienGiang, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "VL")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(VinhLong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DNONG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(Daknong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "").Replace(", TBL_DANHMUCKHACHHANG.phanloaikhachhang", "")));
                }
                else if (x == "PTTT")
                {
                    DATAX.AddRange(BAOCAOCUAHANG(PTTT, strch.Replace("DS_TDV_PTTT.TenTDV", "DS_TDV_PTTT.MANV,DS_TDV_PTTT.TenTDV")));
                }
                else if (x == "QT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(QuangTri, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
            }
            return DATAX;
        }
        public List<DULIEUBAOCAO> DATABAOCAO19(List<string> mapl, List<string> soso, DateTime tungay, DateTime denngay, string phanloai, List<string> phanloaikhachhang, List<string> nhomhang, List<string> sanpham, List<string> quanhuyen, List<string> matinh, List<string> matdv, List<string> hopdong, List<string> makh, List<string> makm, List<string> loaihd, List<string> mactht)
        {
            var DATAX = new List<DULIEUBAOCAO>();
            //String CN
            string strcn = "seleCT SUM((ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)  -  ROUND(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CT.TYLECK/100,0) ) *HOADON.THUESUAT/100) AS tienvat,HOADON.SOHD_DT as SoHD,SUM(round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CAST(TYLECK AS MONEY)/100,0)) AS TIENCK,HOADON.MaTDV AS MATDV ,TBL_DANHMUCKHACHHANG.diachi AS TENTDV,HOADON.ngaylaphd AS NGAY, HOADON.MaPL,TBL_MIEN.mien AS MIEN,TBL_DANHMUCTIEUDEBAOCAO.tendvbc AS TENDVBC,TBL_DANHMUCKHACHHANG.matinh AS MATINH,CT.MAKM AS MAKM,CT.MACTHT AS MACTHT,CT.mahh AS MAHH,CT.tenhh AS TENHH, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, SUM(CAST(CT.SOLUONG AS MONEY)) AS SOLUONG, CAST(CT.DonGia AS MONEY) AS DONGIA, CT.DVT, TBL_DANHMUCHANGHOA.nhom AS NHOM, ROUND(CAST(CT.SOLUONG AS MONEY) * (CAST(CT.DONGIA AS MONEY)), 0) AS TIEN from TBL_MIEN, TBL_DANHMUCTIEUDEBAOCAO, DTA_CT_HOADON_XUAT CT LEFT JOIN   TBL_DANHMUCHANGHOA ON CT.mahh = TBL_DANHMUCHANGHOA.mahh, DTA_HOADON_XUAT HOADON   LEFT JOIN   TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh LEFT JOIN TBL_DANHMUCTDV on HOADON.matdv = TBL_DANHMUCTDV.MaTDV " + ((loaihd != null) ? " ,DTA_HOADON_XUAT DTA_HOADON_XUAT_1  LEFT JOIN TBL_DANHMUCHOPDONG ON DTA_HOADON_XUAT_1.HOPDONG=TBL_DANHMUCHOPDONG.mahd AND DTA_HOADON_XUAT_1.MAKH=TBL_DANHMUCHOPDONG.MAKH" : " ") + " where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1";
            //String CH
            string strch = "Select SUM((ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)  -  ROUND(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CT.TYLECK/100,0) ) *HOADON.THUESUAT/100) AS tienvat,HOADON.SOHD_DT as SoHD ,SUM(round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CAST(TYLECK AS MONEY)/100,0)) AS TIENCK,TBL_DANHMUCKHACHHANG.MATDV AS MATDV,TBL_DANHMUCKHACHHANG.diachi AS TENTDV,HOADON.ngaylaphd AS NGAY, HOADON.MaPL, TBL_MIEN.mien AS MIEN, TBL_DANHMUCTIEUDEBAOCAO.tendvbc AS TENDVBC, TBL_DANHMUCKHACHHANG.matinh AS MATINH,CT.MAKM AS MAKM , CT.mahh AS MAHH, CT.tenhh AS TENHH, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, SUM(CAST(CT.SOLUONG AS MONEY)) AS SOLUONG, CAST(CT.DonGia AS MONEY) AS DONGIA , CT.DVT ,DM_HANGHOA.nhom AS NHOM , ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0) AS TIEN from TBL_MIEN,tieude TBL_DANHMUCTIEUDEBAOCAO, CT_HOADON_XUAT CT  LEFT JOIN  DM_HANGHOA ON CT.mahh = DM_HANGHOA.mahh, DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG right join HOADON_XUAT  HOADON on TBL_DANHMUCKHACHHANG.makh = HOADON.makh left join DS_TDV_PTTT on TBL_DANHMUCKHACHHANG.MaTDV = DS_TDV_PTTT.MaTDV " + ((loaihd != null) ? " ,DTA_HOADON_XUAT DTA_HOADON_XUAT_1  LEFT JOIN TBL_DANHMUCHOPDONG ON DTA_HOADON_XUAT_1.HOPDONG=TBL_DANHMUCHOPDONG.mahd AND DTA_HOADON_XUAT_1.MAKH=TBL_DANHMUCHOPDONG.MAKH" : " ") + " where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1 ";
            //String MB

            if (mapl != null)
            {
                strcn = strcn + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloai != "ALL")
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloaikhachhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            }
            if (loaihd != null)
            {
                strcn = strcn + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
                strch = strch + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
                //strnew = strnew + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
            }
            if (hopdong != null)
            {
                List<string> kh = new List<string>();
                List<string> hd = new List<string>();
                foreach (var i in hopdong)
                {
                    var k = i.Split('~').ToList();
                    hd.Add(k.First());
                    kh.Add(k.Last());
                }
                strcn = strcn + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MAKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MaKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (nhomhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DM_HANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (sanpham != null)
            {
                strcn = strcn + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND replace(dclChiTietHangHoa.MaCap, ' ', '') IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
            }
            if (quanhuyen != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
            }
            if (matinh != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                // strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
            }
            if (matdv != null)
            {
                strcn = strcn + string.Format(" AND HOADON.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            if (makh != null)
            {
                strcn = strcn + string.Format(" AND HOADON.makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            }
            if (makm != null)
            {
                strcn = strcn + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
            }
            if (mactht != null)
            {

                strcn = strcn + string.Format(" AND CT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));

            }
            //String MB
            strcn = strcn + " GROUP BY TBL_DANHMUCKHACHHANG.diachi,HOADON.SOHD_DT,CT.MAKM,CT.MACTHT,HOADON.MATDV,HOADON.ngaylaphd, HOADON.MaPL, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, CT.tenhh, TBL_DANHMUCKHACHHANG.phanloai, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, CAST(CT.SOLUONG AS MONEY), CT.DonGia, CT.DVT, TBL_DANHMUCHANGHOA.nhom, ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)";
            strch = strch + " GROUP BY TBL_DANHMUCKHACHHANG.diachi,HOADON.SOHD_DT,CT.MAKM ,TBL_DANHMUCKHACHHANG.MATDV,DM_HANGHOA.nhom, HOADON.MaPL, HOADON.ngaylaphd, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, CT.tenhh, TBL_DANHMUCKHACHHANG.phanloai, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, CAST(CT.SOLUONG AS MONEY), CT.DonGia, CT.DVT, ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)";
            // strnew = strnew + "group by  dclChiTietKhachHang.TENCAP, dclChiTietKhachHang.TaiKhoanID,dtaChungTu.SoHoaDon,dtasoluong.TienBan, dclDanhSachDonViTinh.TenDonViTinh, dtasoluong.SOLUONG, dtasoluong.GIAban, dtaDinhKhoan.TaiKhoanNo, dtaChungTu.ngaychungtu, dclChiTietHangHoa.MaCap, dclChiTietHangHoa.TENCAP, tbl_danhmuctieudebaocao.tendvbc, tbl_mien.mien, dtaChungTu.khachhangid, TBL_DANHMUCCUAHANG.MACH ,KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang";
            foreach (var x in soso)
            {
                if (x == "QN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(QuangNgai, strcn));
                }
                else if (x == "TN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(TayNinh, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "CHQ10")
                {
                    DATAX.AddRange(BAOCAOCUAHANG(CHQ10, strch));
                }
                else if (x == "CHPPSP")
                {
                    DATAX.AddRange(BAOCAOCUAHANG(CHPPSP, strch.Replace("SOHD_DT", "SoHD")));
                }
                else if (x == "TT423")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(TT423, strcn));
                }
                else if (x == "BD")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(BinhDinh, strcn));
                }
                else if (x == "CT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(CanTho, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(DongNai, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "BDG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(BinhDuong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DNA")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(DaNang, strcn.Replace("SOHD_DT", "SoHD")));
                }
                else if (x == "HCM")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(HoChiMinh, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "NA")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(NgheAn, strcn));
                }
                else if (x == "HN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(HaNoi, strcn));
                }
                else if (x == "TB")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(ThaiBinh, strcn));
                }
                else if (x == "PT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(PhuTho, strcn));
                }
                else if (x == "TNG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(ThaiNguyen, strcn));
                }
                else if (x == "BT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(BinhThuan, strcn));
                }

                else if (x == "THO")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(ThanhHoa, strcn));
                }

                else if (x == "PY")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(PhuYen, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "AG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(AnGiang, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "CM")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(CaMau, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "GL")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(GiaLai, strcn));
                }
                else if (x == "HUE")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(Hue, strcn));
                }
                else if (x == "HP")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(HaiPhong, strcn));
                }
                else if (x == "LD")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(LamDong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "NT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(NhaTrang, strcn));
                }
                else if (x == "TG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(TienGiang, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "VL")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(VinhLong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DNONG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(Daknong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "").Replace(", TBL_DANHMUCKHACHHANG.phanloaikhachhang", "")));
                }
                else if (x == "PTTT")
                {
                    DATAX.AddRange(BAOCAOCUAHANG(PTTT, strch));
                }
                else if (x == "QT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(QuangTri, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
            }
            return DATAX;
        }
        public List<DULIEUBAOCAO> DATABAOCAO36(List<string> mapl, List<string> soso, DateTime tungay, DateTime denngay, string phanloai, List<string> phanloaikhachhang, List<string> nhomhang, List<string> sanpham, List<string> quanhuyen, List<string> matinh, List<string> matdv, List<string> hopdong, List<string> makh, List<string> makm, List<string> loaihd, List<string> mactht)
        {
            var DATAX = new List<DULIEUBAOCAO>();
            //String CN
            string strcn = "seleCT SUM((ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)  -  ROUND(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CT.TYLECK/100,0) ) *HOADON.THUESUAT/100) AS tienvat,HOADON.SOHD_DT as SoHD,SUM(round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CAST(TYLECK AS MONEY)/100,0)) AS TIENCK,HOADON.MaTDV AS MATDV ,TBL_DANHMUCTDV.TenTDV AS TENTDV,HOADON.ngaylaphd AS NGAY, HOADON.MaPL,TBL_MIEN.mien AS MIEN,TBL_DANHMUCTIEUDEBAOCAO.tendvbc AS TENDVBC,TBL_DANHMUCKHACHHANG.matinh AS MATINH,CT.MAKM AS MAKM,CT.MACTHT AS MACTHT,CT.mahh AS MAHH,CT.tenhh AS TENHH, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, SUM(CAST(CT.SOLUONG AS MONEY)) AS SOLUONG, CAST(CT.DonGia AS MONEY) AS DONGIA, CAST(CT.DONGIA_VAT AS MONEY) AS DONGIA_VAT, CT.DVT, TBL_DANHMUCHANGHOA.nhom AS NHOM, ROUND(CAST(CT.SOLUONG AS MONEY) * (CAST(CT.DONGIA AS MONEY)), 0) AS TIEN from TBL_MIEN, TBL_DANHMUCTIEUDEBAOCAO, DTA_CT_HOADON_XUAT CT LEFT JOIN   TBL_DANHMUCHANGHOA ON CT.mahh = TBL_DANHMUCHANGHOA.mahh, DTA_HOADON_XUAT HOADON   LEFT JOIN   TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh LEFT JOIN TBL_DANHMUCTDV on HOADON.matdv = TBL_DANHMUCTDV.MaTDV " + ((loaihd != null) ? " ,DTA_HOADON_XUAT DTA_HOADON_XUAT_1  LEFT JOIN TBL_DANHMUCHOPDONG ON DTA_HOADON_XUAT_1.HOPDONG=TBL_DANHMUCHOPDONG.mahd AND DTA_HOADON_XUAT_1.MAKH=TBL_DANHMUCHOPDONG.MAKH" : " ") + " where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1";
            //String CH
            string strch = "Select SUM((ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)  -  ROUND(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CT.TYLECK/100,0) ) *HOADON.THUESUAT/100) AS tienvat,HOADON.SOHD_DT as SoHD ,SUM(round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CAST(TYLECK AS MONEY)/100,0)) AS TIENCK,TBL_DANHMUCKHACHHANG.MATDV AS MATDV,DS_TDV_PTTT.TenTDV AS TENTDV,HOADON.ngaylaphd AS NGAY, HOADON.MaPL, TBL_MIEN.mien AS MIEN, TBL_DANHMUCTIEUDEBAOCAO.tendvbc AS TENDVBC, TBL_DANHMUCKHACHHANG.matinh AS MATINH,CT.MAKM AS MAKM , CT.mahh AS MAHH, CT.tenhh AS TENHH, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, SUM(CAST(CT.SOLUONG AS MONEY)) AS SOLUONG, CAST(CT.DonGia AS MONEY) AS DONGIA , CAST(CT.DONGIA_VAT AS MONEY) AS DONGIA_VAT, CT.DVT ,DM_HANGHOA.nhom AS NHOM , ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0) AS TIEN from TBL_MIEN,tieude TBL_DANHMUCTIEUDEBAOCAO, CT_HOADON_XUAT CT  LEFT JOIN  DM_HANGHOA ON CT.mahh = DM_HANGHOA.mahh, DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG right join HOADON_XUAT  HOADON on TBL_DANHMUCKHACHHANG.makh = HOADON.makh left join DS_TDV_PTTT on TBL_DANHMUCKHACHHANG.MaTDV = DS_TDV_PTTT.MaTDV " + ((loaihd != null) ? " ,DTA_HOADON_XUAT DTA_HOADON_XUAT_1  LEFT JOIN TBL_DANHMUCHOPDONG ON DTA_HOADON_XUAT_1.HOPDONG=TBL_DANHMUCHOPDONG.mahd AND DTA_HOADON_XUAT_1.MAKH=TBL_DANHMUCHOPDONG.MAKH" : " ") + " where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1 ";
            //String MB
            string strnew = "select SUM(ISNULL(CAST(TIENCHIETKHAU   AS MONEY ),0)) as TIENCK,CAST(sum((ISNULL(CAST(TIENBAN   AS MONEY ),0) -   ISNULL(CAST(TIENCHIETKHAU   AS MONEY ),0)  )*dtasoluong.tylethue/100 ) as FLOAT) as TIENVAT, (select dbo.TCVN2Unicode(dclDanhSachDonViTinh.TenDonViTinh)) as DVT , SUM(ISNULL(CAST(dtasoluong.SOLUONG AS MONEY),0)) as SOLUONG ,SUM(CAST(TIENBAN   AS MONEY))/SUM(CAST(dtasoluong.SOLUONG AS MONEY)) as DONGIA,substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) AS MAPL , dtaChungTu.ngaychungtu as NGAY, substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) as NHOM ,replace(dclChiTietHangHoa.MaCap, ' ', '') AS MAHH, replace(dclChiTietHangHoa.TENCAP, ' ', '')  AS TENHH, ISNULL(CAST(TIENBAN   AS MONEY), 0)  AS TIEN, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_MIEN.MIEN, KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh as MATINH,dtaChungTu.SoHoaDon as SOHD , cast(dtaChungTu.KHACHHANGID as varchar) as MAKH, (select dbo.TCVN2Unicode(dclChiTietKhachHang.TENCAP)) as DONVI, KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang FROM dtasoluong, dtaDinhKhoan, dclChiTietHangHoa, dclChiTietKhachHang, dclDanhSachDonViTinh, tbl_danhmuctieudebaocao, tbl_mien , KT_TH.DBO.TBL_DANHMUCKHACHHANG right join TBL_DANHMUCCUAHANG on KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = TBL_DANHMUCCUAHANG.MaCH right join dtaChungTu ON KT_TH.DBO.TBL_DANHMUCKHACHHANG.makh = CAST(dtaChungTu.KhachHangID as varchar) where dtasoluong.dinhkhoanid = dtaDinhKhoan.CapDKID And dclChiTietKhachHang.TaiKhoanID = dtaChungTu.KHACHHANGID And dtaDinhKhoan.chungtuid = dtaChungTu.chungtuid and dtaDinhKhoan.IDTaiKhoanCo = dclChiTietHangHoa.TaiKhoanID and dclDanhSachDonViTinh.DonViTinhID = dclChiTietHangHoa.DonViTinhID and dtasoluong.SOLUONG != 0  And dtaChungTu.KHACHHANGID IN(select dclChiTietKhachHang.TaiKhoanID from dclChiTietKhachHang) AND substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) = '632' AND dtaChungTu.ngaychungtu between  '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "'";
            if (mapl != null)
            {
                strcn = strcn + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloai != "ALL")
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloaikhachhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            }
            if (loaihd != null)
            {
                strcn = strcn + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
                strch = strch + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
                strnew = strnew + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
            }
            if (hopdong != null)
            {
                List<string> kh = new List<string>();
                List<string> hd = new List<string>();
                foreach (var i in hopdong)
                {
                    var k = i.Split('~').ToList();
                    hd.Add(k.First());
                    kh.Add(k.Last());
                }
                strcn = strcn + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MAKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MaKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (nhomhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DM_HANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (sanpham != null)
            {
                strcn = strcn + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND replace(dclChiTietHangHoa.MaCap, ' ', '') IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
            }
            if (quanhuyen != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
            }
            if (matinh != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
            }
            if (matdv != null)
            {
                strcn = strcn + string.Format(" AND HOADON.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            if (makh != null)
            {
                strcn = strcn + string.Format(" AND HOADON.makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            }
            if (makm != null)
            {
                strcn = strcn + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
            }
            if (mactht != null)
            {

                strcn = strcn + string.Format(" AND CT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));

            }
            //String MB
            strcn = strcn + " GROUP BY TBL_DANHMUCTDV.TenTDV,HOADON.SOHD_DT,CT.MAKM,CT.MACTHT,HOADON.MATDV,HOADON.ngaylaphd, HOADON.MaPL, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, CT.tenhh, TBL_DANHMUCKHACHHANG.phanloai, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, CAST(CT.SOLUONG AS MONEY), CT.DonGia,CT.DONGIA_VAT, CT.DVT, TBL_DANHMUCHANGHOA.nhom, ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)";
            strch = strch + " GROUP BY DS_TDV_PTTT.TenTDV,HOADON.SOHD_DT,CT.MAKM ,TBL_DANHMUCKHACHHANG.MATDV,DM_HANGHOA.nhom, HOADON.MaPL, HOADON.ngaylaphd, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, CT.tenhh, TBL_DANHMUCKHACHHANG.phanloai, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, CAST(CT.SOLUONG AS MONEY), CT.DonGia,CT.DONGIA_VAT, CT.DVT, ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)";
            strnew = strnew + "group by  dclChiTietKhachHang.TENCAP, dclChiTietKhachHang.TaiKhoanID,dtaChungTu.SoHoaDon,dtasoluong.TienBan, dclDanhSachDonViTinh.TenDonViTinh, dtasoluong.SOLUONG, dtasoluong.GIAban, dtaDinhKhoan.TaiKhoanNo, dtaChungTu.ngaychungtu, dclChiTietHangHoa.MaCap, dclChiTietHangHoa.TENCAP, tbl_danhmuctieudebaocao.tendvbc, tbl_mien.mien, dtaChungTu.khachhangid, TBL_DANHMUCCUAHANG.MACH ,KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang";
            foreach (var x in soso)
            {

                if (x == "QN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(QuangNgai, strcn));
                }
                else if (x == "TN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(TayNinh, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                //else if (x == "TB2")
                //{
                //    DATAX.AddRange(BAOCAOMIENBAC(ThaiBinh2, strnew));
                //}
                ////else if (x == "HN_2")
                ////{
                ////    DATAX.AddRange(BAOCAOCHINHANH(HaNoi, strcn));
                ////}
                //else if (x == "HN2")
                //{
                //    DATAX.AddRange(BAOCAOMIENBAC(HaNoi2, strnew));
                //    //DATAX.AddRange(BAOCAOMIENBAC(ThaiNguyen, strnew.Replace("KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = TBL_DANHMUCCUAHANG.MaCH", "KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH IN ('HN','TB','PT')")));
                //}
                //else if (x == "TNG2")
                //{
                //    DATAX.AddRange(BAOCAOMIENBAC(ThaiNguyen2, strnew));
                //    //DATAX.AddRange(BAOCAOMIENBAC(ThaiNguyen, strnew.Replace("KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = TBL_DANHMUCCUAHANG.MaCH", "KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH IN ('HN','TB','PT')")));
                //}
                else if (x == "CHQ10")
                {
                    DATAX.AddRange(BAOCAOCUAHANG(CHQ10, strch));
                }
                else if (x == "CHPPSP")
                {
                    DATAX.AddRange(BAOCAOCUAHANG(CHPPSP, strch.Replace("SOHD_DT", "SoHD")));
                }
                else if (x == "TT423")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(TT423, strcn));
                }

                else if (x == "BD")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(BinhDinh, strcn));
                }
                else if (x == "CT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(CanTho, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(DongNai, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "BDG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(BinhDuong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DNA")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(DaNang, strcn.Replace("SOHD_DT", "SoHD")));
                }
                else if (x == "HCM")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(HoChiMinh, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "NA")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(NgheAn, strcn));
                }
                else if (x == "HN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(HaNoi, strcn));
                }
                else if (x == "TB")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(ThaiBinh, strcn));
                }
                else if (x == "PT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(PhuTho, strcn));
                }
                else if (x == "TNG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(ThaiNguyen, strcn));
                }
                else if (x == "BT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(BinhThuan, strcn));
                }
                else if (x == "THO")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(ThanhHoa, strcn));
                }
                //else if (x == "PT2")
                //{
                //    DATAX.AddRange(BAOCAOMIENBAC(PhuTho2, strnew));
                //}
                else if (x == "PY")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(PhuYen, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "AG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(AnGiang, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "CM")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(CaMau, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "GL")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(GiaLai, strcn));
                }
                else if (x == "HUE")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(Hue, strcn));
                }
                else if (x == "HP")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(HaiPhong, strcn));
                }
                else if (x == "LD")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(LamDong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "NT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(NhaTrang, strcn));
                }
                else if (x == "TG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(TienGiang, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "VL")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(VinhLong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DNONG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(Daknong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "").Replace(", TBL_DANHMUCKHACHHANG.phanloaikhachhang", "")));
                }
                else if (x == "PTTT")
                {
                    DATAX.AddRange(BAOCAOCUAHANG(PTTT, strch));
                }
                else if (x == "QT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH(QuangTri, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
            }
            return DATAX;
        }
        public List<DULIEUBAOCAO23> DATABAOCAO23(List<string> mapl, List<string> soso, DateTime tungay, DateTime denngay, string phanloai, List<string> phanloaikhachhang, List<string> nhomhang, List<string> sanpham, List<string> quanhuyen, List<string> matinh, List<string> matdv, List<string> hopdong, List<string> makh, List<string> makm, List<string> loaihd, List<string> mactht)
        {

            var DATAX = new List<DULIEUBAOCAO23>();
            //String CN
            string strcn = "SELECT  MONTH(HOADON.NGAYLAPHD) as THANG,TBL_DANHMUCKHACHHANG.matinh AS MATINH, SUM(ROUND(CAST(CT.SOLUONG AS MONEY) * (CAST(CT.DONGIA AS MONEY)), 0)) AS TIEN , CAST('" + denngay.Year + "'  AS INT) AS NAM from TBL_MIEN, TBL_DANHMUCTIEUDEBAOCAO, DTA_CT_HOADON_XUAT CT LEFT JOIN   TBL_DANHMUCHANGHOA ON CT.mahh = TBL_DANHMUCHANGHOA.mahh, DTA_HOADON_XUAT HOADON   LEFT JOIN   TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh LEFT JOIN TBL_DANHMUCTDV on HOADON.matdv = TBL_DANHMUCTDV.MaTDV " + ((loaihd != null) ? " ,DTA_HOADON_XUAT DTA_HOADON_XUAT_1  LEFT JOIN TBL_DANHMUCHOPDONG ON DTA_HOADON_XUAT_1.HOPDONG=TBL_DANHMUCHOPDONG.mahd AND DTA_HOADON_XUAT_1.MAKH=TBL_DANHMUCHOPDONG.MAKH" : " ") + " where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1";
            //String CH
            string strch = "Select  MONTH(HOADON.NGAYLAPHD) as THANG,TBL_DANHMUCKHACHHANG.matinh AS MATINH, SUM(ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)) AS TIEN , CAST('" + denngay.Year + "' AS INT) AS NAM from TBL_MIEN,tieude TBL_DANHMUCTIEUDEBAOCAO, CT_HOADON_XUAT CT  LEFT JOIN  DM_HANGHOA ON CT.mahh = DM_HANGHOA.mahh, DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG right join HOADON_XUAT  HOADON on TBL_DANHMUCKHACHHANG.makh = HOADON.makh left join DS_TDV_PTTT on TBL_DANHMUCKHACHHANG.MaTDV = DS_TDV_PTTT.MaTDV " + ((loaihd != null) ? " ,DTA_HOADON_XUAT DTA_HOADON_XUAT_1  LEFT JOIN TBL_DANHMUCHOPDONG ON DTA_HOADON_XUAT_1.HOPDONG=TBL_DANHMUCHOPDONG.mahd AND DTA_HOADON_XUAT_1.MAKH=TBL_DANHMUCHOPDONG.MAKH" : " ") + " where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1 ";

            if (mapl != null)
            {
                strcn = strcn + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloai != "ALL")
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");

            }
            if (phanloaikhachhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));

            }
            if (loaihd != null)
            {
                strcn = strcn + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
                strch = strch + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));

            }
            if (hopdong != null)
            {
                List<string> kh = new List<string>();
                List<string> hd = new List<string>();
                foreach (var i in hopdong)
                {
                    var k = i.Split('~').ToList();
                    hd.Add(k.First());
                    kh.Add(k.Last());
                }
                strcn = strcn + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MAKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MaKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (nhomhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DM_HANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));

            }
            if (sanpham != null)
            {
                strcn = strcn + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));

            }
            if (quanhuyen != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
            }
            if (matinh != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));

            }
            if (matdv != null)
            {
                strcn = strcn + string.Format(" AND HOADON.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            if (makh != null)
            {
                strcn = strcn + string.Format(" AND HOADON.makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND HOADON.makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            }
            if (makm != null)
            {
                strcn = strcn + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
            }
            if (mactht != null)
            {

                strcn = strcn + string.Format(" AND CT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND CT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));

            }
            //String MB
            strcn = strcn + " GROUP BY TBL_DANHMUCKHACHHANG.matinh,MONTH(HOADON.NGAYLAPHD) ORDER BY MATINH ASC, THANG ASC";
            strch = strch + " GROUP BY TBL_DANHMUCKHACHHANG.matinh,MONTH(HOADON.NGAYLAPHD) ORDER BY MATINH ASC, THANG ASC";

            foreach (var x in soso)
            {

                if (x == "QN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(QuangNgai, strcn));
                }
                else if (x == "TN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(TayNinh, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "CHQ10")
                {
                    DATAX.AddRange(BAOCAOCUAHANG23(CHQ10, strch));
                }
                else if (x == "CHPPSP")
                {
                    DATAX.AddRange(BAOCAOCUAHANG23(CHPPSP, strch.Replace("SOHD_DT", "SoHD")));
                }
                else if (x == "TT423")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(TT423, strcn));
                }

                else if (x == "BD")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(BinhDinh, strcn));
                }
                else if (x == "CT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(CanTho, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(DongNai, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "BDG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(BinhDuong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DNA")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(DaNang, strcn));
                }
                else if (x == "HCM")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(HoChiMinh, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "NA")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(NgheAn, strcn));
                }
                else if (x == "HN")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(HaNoi, strcn));
                }
                else if (x == "TB")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(ThaiBinh, strcn));
                }
                else if (x == "PT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(PhuTho, strcn));
                }
                else if (x == "TNG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(ThaiNguyen, strcn));
                }
                else if (x == "BT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(BinhThuan, strcn));
                }

                else if (x == "THO")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(ThanhHoa, strcn));
                }
                //else if (x == "PT2")
                //{
                //    DATAX.AddRange(BAOCAOMIENBAC(PhuTho2, strnew));
                //}
                else if (x == "PY")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(PhuYen, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "AG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(AnGiang, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "CM")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(CaMau, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "GL")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(GiaLai, strcn));
                }
                else if (x == "HUE")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(Hue, strcn));
                }
                else if (x == "HP")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(HaiPhong, strcn));
                }
                else if (x == "LD")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(LamDong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "NT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(NhaTrang, strcn));
                }
                else if (x == "TG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(TienGiang, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "VL")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(VinhLong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DNONG")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(Daknong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "").Replace(", TBL_DANHMUCKHACHHANG.phanloaikhachhang", "")));
                }
                else if (x == "PTTT")
                {
                    DATAX.AddRange(BAOCAOCUAHANG23(PTTT, strch));
                }
                else if (x == "QT")
                {
                    DATAX.AddRange(BAOCAOCHINHANH23(QuangTri, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
            }
            return DATAX;
        }
        public List<DULIEUBAOCAO23> BAOCAOCUAHANG23(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO23>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO23> BAOCAOCHINHANH23(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO23>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO26> DATABAOCAO26(List<string> soso, int nam, List<string> khachhang, List<string> ctkm, List<string> mactht, List<string> matinh, List<string> matdv, List<string> maquan, string qui, TBL_DANHMUCNGUOIDUNG Info)
        {
            string CTKM = String.Join(",", ctkm.ToArray());

            string strcn = null;
            if (khachhang != null)
            {

                strcn = " declare @m table( makh1 varchar(20), donvi nvarchar(300), TIEN1 MONEY , TIEN2 MONEY , TIEN3 MONEY , T1 MONEY , T2 MONEY , T3 MONEY , ckqui float) DECLARE @NAM INT SET @NAM = " + nam + " DECLARE @QUI NVARCHAR(100) SET @QUI = '" + qui + "' DECLARE @TUTHANG INT IF @QUI='Quí 1' begin set @TUTHANG=1 end IF @QUI='Quí 2' begin set @TUTHANG=4 end IF @QUI='Quí 3' begin set @TUTHANG=7 end IF @QUI='Quí 4' begin set @TUTHANG=10 end INSERT INTO @M SELECT MAKH,DONVI, 0,0,0, 0,0,0, 0 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM AND ISNULL(ck,0) + ISNULL(CKVUOT,0) + ISNULL(ckdat,0) > 0 " + ((khachhang != null) ? string.Format(" AND MAKH IN({0})", string.Join(",", khachhang.Select(p => "'" + p + "'"))) : "") + " AND ISNULL(KT,0)=0 UPDATE @M SET TIEN1 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE MONTH(HOADON.NGAYLAPHD ) = @TUTHANG AND YEAR(HOADON.NGAYLAPHD ) =@NAM AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,TIEN2 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE MONTH(HOADON.NGAYLAPHD ) = @TUTHANG+1 AND YEAR(HOADON.NGAYLAPHD ) =@NAM AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,TIEN3 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE MONTH(HOADON.NGAYLAPHD ) = @TUTHANG+2 AND YEAR(HOADON.NGAYLAPHD ) =@NAM AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) IF @QUI='Quí 1' begin UPDATE @M SET T1 = ( SELECT Q1/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) , T2 = ( SELECT Q1/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) , T3 = ( SELECT Q1/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) end IF @QUI='Quí 2' begin UPDATE @M SET T1 =( SELECT Q2/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1) , T2 = ( SELECT Q2/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) , T3 = ( SELECT Q2/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) end IF @QUI='Quí 3' begin UPDATE @M SET T1 =( SELECT Q3/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1) , T2 = ( SELECT Q3/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) , T3 = ( SELECT Q3/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) end IF @QUI='Quí 4' begin UPDATE @M SET T1 =( SELECT Q4/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1) , T2 = ( SELECT Q4/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) , T3 = ( SELECT Q4/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) end UPDATE @M SET ckqui= (SELECT ckqui FROM KT_TH.dbo.TBL_DOANHSOBBTT WHERE NAM=@NAM AND DOANHSO= (ISNULL(T1,0) +ISNULL(T2,0) + ISNULL(T3,0))*4 ) SELECT MAKH1 AS MAKH,DONVI ,ISNULL(TIEN1,0) AS DS1 ,ISNULL(TIEN2,0) AS DS2 ,ISNULL(TIEN3,0) AS DS3 ,ISNULL(TIEN1,0) + ISNULL(TIEN2,0) +ISNULL(TIEN3,0) as DS ,ISNULL(T1,0) AS T1 ,ISNULL(T2,0) AS T2 ,ISNULL(T3,0) AS T3 ,ISNULL(T1,0) +ISNULL(T2,0) + ISNULL(T3,0) as KH ,(SELECT DOANHSOLONHON FROM KT_TH.dbo.TBL_DOANHSOBBTT WHERE DOANHSO =0 )/4 AS DOANHSOLONHONQUI ,@nam as NAM ," + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + " as MAKM ,ckqui, @TUTHANG AS THANG, @QUI AS QUI ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC FROM @M,TBL_DANHMUCTIEUDEBAOCAO WHERE ISNULL(TIEN1,0)+ISNULL(TIEN2,0)+ISNULL(TIEN3,0) +ISNULL(T1,0) +ISNULL(T2,0) + ISNULL(T3,0) <> 0";
            }
            else
            {

                if (Info.matinh == "ALL" && Info.maquan == "ALL" && Info.matdv == "ALL")
                {
                    strcn = "declare @m table( makh1 varchar(20), donvi nvarchar(300), TIEN1 MONEY , TIEN2 MONEY , TIEN3 MONEY , T1 MONEY , T2 MONEY , T3 MONEY , ckqui float) DECLARE @NAM INT SET @NAM = " + nam + " DECLARE @QUI NVARCHAR(100) SET @QUI = '" + qui + "' DECLARE @TUTHANG INT IF @QUI='Quí 1' begin set @TUTHANG=1 end IF @QUI='Quí 2' begin set @TUTHANG=4 end IF @QUI='Quí 3' begin set @TUTHANG=7 end IF @QUI='Quí 4' begin set @TUTHANG=10 end INSERT INTO @M SELECT MAKH,DONVI, 0,0,0, 0,0,0, 0 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM AND ISNULL(ck,0) + ISNULL(CKVUOT,0) + ISNULL(ckdat,0) > 0 AND ISNULL(KT,0)=0 UPDATE @M SET TIEN1 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE MONTH(HOADON.NGAYLAPHD ) = @TUTHANG AND YEAR(HOADON.NGAYLAPHD ) =@NAM AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,TIEN2 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE MONTH(HOADON.NGAYLAPHD ) = @TUTHANG+1 AND YEAR(HOADON.NGAYLAPHD ) =@NAM AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,TIEN3 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE MONTH(HOADON.NGAYLAPHD ) = @TUTHANG+2 AND YEAR(HOADON.NGAYLAPHD ) =@NAM AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) IF @QUI='Quí 1' begin UPDATE @M SET T1 = ( SELECT Q1/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) , T2 = ( SELECT Q1/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) , T3 = ( SELECT Q1/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) end IF @QUI='Quí 2' begin UPDATE @M SET T1 =( SELECT Q2/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1) , T2 = ( SELECT Q2/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) , T3 = ( SELECT Q2/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) end IF @QUI='Quí 3' begin UPDATE @M SET T1 =( SELECT Q3/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1) , T2 = ( SELECT Q3/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) , T3 = ( SELECT Q3/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) end IF @QUI='Quí 4' begin UPDATE @M SET T1 =( SELECT Q4/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1) , T2 = ( SELECT Q4/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) , T3 = ( SELECT Q4/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) end UPDATE @M SET ckqui= (SELECT ckqui FROM KT_TH.dbo.TBL_DOANHSOBBTT WHERE NAM=@NAM AND DOANHSO= (ISNULL(T1,0) +ISNULL(T2,0) + ISNULL(T3,0))*4 ) SELECT MAKH1 AS MAKH,DONVI ,ISNULL(TIEN1,0) AS DS1 ,ISNULL(TIEN2,0) AS DS2 ,ISNULL(TIEN3,0) AS DS3 ,ISNULL(TIEN1,0) + ISNULL(TIEN2,0) +ISNULL(TIEN3,0) as DS ,ISNULL(T1,0) AS T1 ,ISNULL(T2,0) AS T2 ,ISNULL(T3,0) AS T3 ,ISNULL(T1,0) +ISNULL(T2,0) + ISNULL(T3,0) as KH ,(SELECT DOANHSOLONHON FROM KT_TH.dbo.TBL_DOANHSOBBTT WHERE DOANHSO =0 )/4 AS DOANHSOLONHONQUI ,@nam as NAM ," + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + " as MAKM ,ckqui, @TUTHANG AS THANG, @QUI AS QUI ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC FROM @M,TBL_DANHMUCTIEUDEBAOCAO WHERE ISNULL(TIEN1,0)+ISNULL(TIEN2,0)+ISNULL(TIEN3,0) +ISNULL(T1,0) +ISNULL(T2,0) + ISNULL(T3,0) <> 0";
                }
                else
                {
                    var listmakh = new List<string>();
                    foreach (var i in soso)
                    {
                        listmakh.AddRange(GetMAKH(i, Info, matinh, matdv, maquan));
                    }
                    strcn = " declare @m table( makh1 varchar(20), donvi nvarchar(300), TIEN1 MONEY , TIEN2 MONEY , TIEN3 MONEY , T1 MONEY , T2 MONEY , T3 MONEY , ckqui float) DECLARE @NAM INT SET @NAM = " + nam + " DECLARE @QUI NVARCHAR(100) SET @QUI = '" + qui + "' DECLARE @TUTHANG INT IF @QUI='Quí 1' begin set @TUTHANG=1 end IF @QUI='Quí 2' begin set @TUTHANG=4 end IF @QUI='Quí 3' begin set @TUTHANG=7 end IF @QUI='Quí 4' begin set @TUTHANG=10 end INSERT INTO @M SELECT MAKH,DONVI, 0,0,0, 0,0,0, 0 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM AND ISNULL(ck,0) + ISNULL(CKVUOT,0) + ISNULL(ckdat,0) > 0 " + string.Format(" AND MAKH IN({0})", string.Join(",", listmakh.Select(p => "'" + p + "'"))) + " AND ISNULL(KT,0)=0 UPDATE @M SET TIEN1 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE MONTH(HOADON.NGAYLAPHD ) = @TUTHANG AND YEAR(HOADON.NGAYLAPHD ) =@NAM AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,TIEN2 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE MONTH(HOADON.NGAYLAPHD ) = @TUTHANG+1 AND YEAR(HOADON.NGAYLAPHD ) =@NAM AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) ,TIEN3 = ( SELECT sum(round(cast(ct_hoadon.soluong as money)*cast(ct_hoadon.dongia as money),0)) FROM dta_HOADON_xuat HOADON,dta_ct_hoadon_xuat ct_hoadon WHERE MONTH(HOADON.NGAYLAPHD ) = @TUTHANG+2 AND YEAR(HOADON.NGAYLAPHD ) =@NAM AND CT_HOADON.MAKM IN (" + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + ") and hoadon.sohd=ct_hoadon.sohd AND HOADON.MAPL ='BAN' and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1 AND CT_HOADON.TYLECK <>100 AND HOADON.MACH=CT_HOADON.MACH AND HOADON.MAKH=MAKH1 ) IF @QUI='Quí 1' begin UPDATE @M SET T1 = ( SELECT Q1/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) , T2 = ( SELECT Q1/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) , T3 = ( SELECT Q1/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) end IF @QUI='Quí 2' begin UPDATE @M SET T1 =( SELECT Q2/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1) , T2 = ( SELECT Q2/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) , T3 = ( SELECT Q2/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) end IF @QUI='Quí 3' begin UPDATE @M SET T1 =( SELECT Q3/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1) , T2 = ( SELECT Q3/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) , T3 = ( SELECT Q3/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) end IF @QUI='Quí 4' begin UPDATE @M SET T1 =( SELECT Q4/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1) , T2 = ( SELECT Q4/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) , T3 = ( SELECT Q4/3 FROM TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE NAM=@NAM and MAKH=MAKH1 ) end UPDATE @M SET ckqui= (SELECT ckqui FROM KT_TH.dbo.TBL_DOANHSOBBTT WHERE NAM=@NAM AND DOANHSO= (ISNULL(T1,0) +ISNULL(T2,0) + ISNULL(T3,0))*4 ) SELECT MAKH1 AS MAKH,DONVI ,ISNULL(TIEN1,0) AS DS1 ,ISNULL(TIEN2,0) AS DS2 ,ISNULL(TIEN3,0) AS DS3 ,ISNULL(TIEN1,0) + ISNULL(TIEN2,0) +ISNULL(TIEN3,0) as DS ,ISNULL(T1,0) AS T1 ,ISNULL(T2,0) AS T2 ,ISNULL(T3,0) AS T3 ,ISNULL(T1,0) +ISNULL(T2,0) + ISNULL(T3,0) as KH ,(SELECT DOANHSOLONHON FROM KT_TH.dbo.TBL_DOANHSOBBTT WHERE DOANHSO =0 )/4 AS DOANHSOLONHONQUI ,@nam as NAM ," + string.Format("{0}", string.Join(",", ctkm.Select(p => "'" + p + "'"))) + " as MAKM ,ckqui, @TUTHANG AS THANG, @QUI AS QUI ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC FROM @M,TBL_DANHMUCTIEUDEBAOCAO WHERE ISNULL(TIEN1,0)+ISNULL(TIEN2,0)+ISNULL(TIEN3,0) +ISNULL(T1,0) +ISNULL(T2,0) + ISNULL(T3,0) <> 0";
                }
            }
            var DATAX = new List<DULIEUBAOCAO26>();
            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    if (x == "TT423")
                    {
                        DATAX.AddRange(BAOCAOCHINHANH26(queryCN.SingleOrDefault(n => n.macn == x).data, strcn.Replace("AND ISNULL(ck,0) + ISNULL(CKVUOT,0) + ISNULL(ckdat,0) > 0", "and Isnull(q1, 0) + Isnull(q2, 0) + Isnull(q3, 0) + Isnull(q4, 0) > 0")));
                    }
                    else if (x == "GL")
                    {
                        DATAX.AddRange(BAOCAOCHINHANH26(queryCN.SingleOrDefault(n => n.macn == x).data, strcn.Replace("AND ISNULL(ck,0) + ISNULL(CKVUOT,0) + ISNULL(ckdat,0) > 0 AND ISNULL(KT,0)=0", " ")));
                    }
                    else
                    {
                        DATAX.AddRange(BAOCAOCHINHANH26(queryCN.SingleOrDefault(n => n.macn == x).data, strcn));
                    }

                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {

                    DATAX.AddRange(BAOCAOCUAHANG26(queryCH.SingleOrDefault(n => n.macn == x).data, strcn.Replace("dta_", "").Replace("TBL_DANHMUCTIEUDEBAOCAO WHERE", "TIEUDE TBL_DANHMUCTIEUDEBAOCAO WHERE")));

                }
            }
            return DATAX;
        }
        public List<DULIEUBAOCAO7> DATABAOCAO7(List<string> soso, DateTime denngay, List<string> khachhang, List<string> trinhduocvien)
        {
            string MAKH;
            if (trinhduocvien != null && khachhang == null)
            {
                MAKH = String.Join(",", GetKhachHangBC11(soso, trinhduocvien).Select(cl => cl.MAKH).ToArray());
            }
            else
            {
                MAKH = String.Join(",", khachhang.ToArray());
            }
            string strcn = "";
            strcn = " exec sp_kyhan_inct_CHITIET '131'," + denngay.Month + "," + denngay.Year + ",'','" + MAKH + "','" + denngay.ToString("MM/dd/yyyy") + "' ";
            var DATAX = new List<DULIEUBAOCAO7>();
            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    if (x == "DNA")
                    {
                        string strdn = "DECLARE @m_tk varchar(10) set @m_tk = '131' DECLARE @m_thang int set @m_thang = " + denngay.Month + " DECLARE @m_nam int set @m_nam = " + denngay.Year + " DECLARE @m_mach varchar(10) set @m_mach = '' DECLARE @m_makh varchar(8000) set @m_makh = '" + MAKH + "' DECLARE @m_ngayin smalldatetime set @m_ngayin = '" + denngay.ToString("MM/dd/yyyy") + "' DECLARE @masoID char(4) DECLARE @TBL_IN TABLE( TK VARCHAR(10) ,SCT VARCHAR(20) ,NGAY SMALLDATETIME ,MAKH VARCHAR(20) ,TIEN FLOAT DEFAULT NULL ,KT BIT ,SOID VARCHAR(40) ,MACH VARCHAR(20) ,THANG INT ,NAM INT ,MAKH1 VARCHAR(20)) DECLARE @TBL_IN_01 TABLE ( MAKH VARCHAR(20) ,TENKH NVARCHAR(700) ,DAUNAM_NO FLOAT DEFAULT NULL ,DAUNAM_CO FLOAT DEFAULT NULL ,PSNO FLOAT DEFAULT NULL ,PSCO FLOAT DEFAULT NULL ,CKNO FLOAT DEFAULT NULL ,CKCO FLOAT DEFAULT NULL ,MAKH1 VARCHAR(20) ) DECLARE @TBL_TAM_KYHAN TABLE ( MAKH VARCHAR(20) ,DAUNAM_NO FLOAT DEFAULT NULL ,DAUNAM_CO FLOAT DEFAULT NULL ,PSNO FLOAT DEFAULT NULL ,PSCO FLOAT DEFAULT NULL ,CKNO FLOAT DEFAULT NULL ,CKCO FLOAT DEFAULT NULL ,MAKH1 VARCHAR(20) ) insert into @TBL_IN(mach,tk,sct,ngay,makh,tien) select '',tk,sct,ngay,makh,tien FROM dta_kyhancongno where THANG in(select THANG_NAM from fun_KTTHANG(1,@m_thang,@m_nam )) AND NAM in(select THANG_NAM from fun_KTTHANG(2,@m_thang,@m_nam)) and tk=@m_tk and makh IN (SELECT VAL FROM FUN_CATCHUOI(@m_makh)) insert into @TBL_IN(mach,ngay,sct,makh,tk,tien) select '',ngay,sct,makhn,tkn,isnull(sum(tien),0) FROM dta_dinhkhoan where month(ngay)=@m_thang and year(ngay)=@m_nam and tkn=@m_tk and makhN IN (SELECT VAL FROM FUN_CATCHUOI(@m_makh)) group by ngay,sct,makhn,tkn insert into @TBL_IN(mach,ngay,sct,makh,tk,tien) select '',ngay,sct,makhC,tkC,isnull(sum(ABS(tien)),0) FROM dta_dinhkhoan where month(ngay)=@m_thang and year(ngay)=@m_nam and tkC=@m_tk AND tien <0 and makhc IN (SELECT VAL FROM FUN_CATCHUOI(@m_makh)) group by ngay,sct,makhC,tkC update @TBL_IN set kt=0, SOID=ltrim(rtrim(mach))+ltrim(rtrim(makh))+convert(varchar(10),ngay,112)+isnull(ltrim(rtrim(sct)),''), makh1=makh insert into @TBL_IN_01(makh,daunam_no) select matk,isnull(duno,0) FROM dta_daukytaikhoan WHERE tkcaptren=@m_tk and nam=@m_nam and thamchieu=1 and matk IN (SELECT VAL FROM FUN_CATCHUOI(@m_makh)) insert into @TBL_IN_01(makh,daunam_co) select matk,isnull(duco,0) FROM dta_daukytaikhoan WHERE tkcaptren=@m_tk and nam=@m_nam and thamchieu=1 and matk=@m_makh insert into @TBL_IN_01(makh,psno) select makhn,isnull(sum(tien),0) FROM dta_dinhkhoan where tkn=@m_tk and month(ngay)>=1 and month(ngay)<=@m_thang and year(ngay)=@m_nam and makhn IN (SELECT VAL FROM FUN_CATCHUOI(@m_makh)) group by makhn insert into @TBL_IN_01(makh,psco) select makhc,isnull(sum(tien),0) FROM dta_dinhkhoan where tkc=@m_tk and month(ngay)>=1 and month(ngay)<=@m_thang and year(ngay)=@m_nam and makhc IN (SELECT VAL FROM FUN_CATCHUOI(@m_makh)) group by makhc insert into @TBL_TAM_KYHAN(makh,daunam_no,daunam_co,psno,psco) select makh,sum(daunam_no),sum(daunam_co),sum(psno),sum(psco)from @TBL_IN_01 group by makh update @TBL_TAM_KYHAN set makh1=makh update @TBL_TAM_KYHAN set ckno=isnull(daunam_no,0)-isnull(daunam_co,0)+isnull(psno,0)-isnull(psco,0) delete @TBL_TAM_KYHAN where ckno<=0 Declare @makh1 varchar(20) Declare @TienCK float set @TienCK=0 Declare curIC cursor FOR select makh1,ckno from @TBL_TAM_KYHAN OPEN curIC FETCH NEXT FROM curIC INTO @makh1,@TienCK WHILE @@FETCH_STATUS=0 BEGIN Declare @autoID varchar(30) Declare @tien float Declare curFIFO cursor FOR select soID,tien from @TBL_IN where makh1=@makh1 order by ngay desc OPEN curFIFO FETCH NEXT FROM curFIFO INTO @autoID,@Tien WHILE (@@FETCH_STATUS=0) AND (@TienCK!=0) BEGIN IF @TienCK>=@Tien BEGIN SET @TienCK=@TienCK-@tien UPDATE @TBL_IN SET KT=1 WHERE soID= @autoID END ELSE BEGIN UPDATE @TBL_IN SET KT=1,tien=@TienCK WHERE soID= @autoID SET @TienCK=0 END FETCH NEXT FROM curFIFO INTO @autoID,@Tien END CLOSE curFIFO DEALLOCATE curFIFO FETCH NEXT FROM curIC INTO @makh1,@TienCK END CLOSE curIC DEALLOCATE curIC delete from @TBL_IN where kt=0 update @TBL_IN set tk=@m_tk,thang=@m_thang, nam=@m_nam declare @dta_kyhancongno table ( tk varchar(20), makh varchar(20), sct varchar(20), ngay smalldatetime , tien money ) insert into @dta_kyhancongno(tk,makh,sct,ngay,tien ) select tk,makh,sct,ngay,tien from @TBL_IN WHERE MAKH <>'' AND MAKH IS NOT NULL order by makh DECLARE @TBL_IN_10 TABLE ( TK VARCHAR(10) ,MACH NVARCHAR(200) ,SCT VARCHAR(20) ,NGAY SMALLDATETIME ,MAKH1 VARCHAR(20) ,TIEN FLOAT DEFAULT NULL ,SONGAY FLOAT DEFAULT NULL ,ngayin SMALLDATETIME ,t1 FLOAT DEFAULT NULL ,t2 FLOAT DEFAULT NULL ,t3 FLOAT DEFAULT NULL ,t4 FLOAT DEFAULT NULL ,t5 FLOAT DEFAULT NULL ,t6 FLOAT DEFAULT NULL ,t7 FLOAT DEFAULT NULL ,t8 FLOAT DEFAULT NULL ,t9 FLOAT DEFAULT NULL ,t10 FLOAT DEFAULT NULL ,t11 FLOAT DEFAULT NULL ,t12 FLOAT DEFAULT NULL ,t13 FLOAT DEFAULT NULL ,donvi nvarchar(200) ,diachi1 nvarchar(200) ) Declare @m_mmddyy SMALLDATETIME set @m_mmddyy=@m_ngayin DECLARE @DONVI NVARCHAR(300) DECLARE @DIACHI NVARCHAR(300) insert into @TBL_IN_10(sct,ngay,makh1,tien,mach) select sct,ngay,makh,tien ,@m_mach FROM @dta_kyhancongno where TIEN >0 update @TBL_IN_10 set ngayin=@m_ngayin update @TBL_IN_10 set songay=DATEDIFF ( dd , ngay , ngayin ) update @TBL_IN_10 set t1=tien where songay<=30 update @TBL_IN_10 set t2=tien where songay>30 and songay<=60 update @TBL_IN_10 set t3=tien where songay>60 and songay<=90 update @TBL_IN_10 set t4=tien where songay>90 and songay<=120 update @TBL_IN_10 set t5=tien where songay>120 and songay<=150 update @TBL_IN_10 set t6=tien where songay>150 and songay<=180 update @TBL_IN_10 set t7=tien where songay>180 and songay<=210 update @TBL_IN_10 set t8=tien where songay>210 and songay<=240 update @TBL_IN_10 set t9=tien where songay>240 and songay<=270 update @TBL_IN_10 set t10=tien where songay>270 and songay<=300 update @TBL_IN_10 set t11=tien where songay>300 and songay<=330 update @TBL_IN_10 set t12=tien where songay>330 and songay<=360 update @TBL_IN_10 set t13=tien where songay>360 declare @thongtin table ( SCT VARCHAR(20), NGAY SMALLDATETIME, MAKH varchar(20), TIEN MONEY, SONGAY INT, ngayin smalldatetime ,t1 money ,t2 money ,t3 money ,t4 money ,t5 money ,t6 money ,t7 money ,t8 money ,t9 money ,t10 money ,t11 money ,t12 money ,t13 money ,donvi nvarchar(200)) update @TBL_IN_10 set donvi=(select donvi from tbl_danhmuckhachhang where makh=makh1) , diachi1=(select diachi from tbl_danhmuckhachhang where makh=makh1) insert into @thongtin SELECT SCT,NGAY,makh1 ,sum(tien) ,songay ,@m_ngayin ,sum(isnull(t1,0)),sum(isnull(t2,0)),sum(isnull(t3,0)) ,sum(isnull(t4,0)),sum(isnull(t5,0)),sum(isnull(t6,0)) ,sum(isnull(t7,0)),sum(isnull(t8,0)),sum(isnull(t9,0)),sum(isnull(t10,0)) ,sum(isnull(t11,0)),sum(isnull(t12,0)),sum(isnull(t13,0)) ,donvi FROM @TBL_IN_10 group by SCT,NGAY,makh1,donvi,songay select * from @thongtin ";
                        DATAX.AddRange(BAOCAOCHINHANH7(queryCN.SingleOrDefault(n => n.macn == x).data, strdn));
                    }
                    else
                    {
                        DATAX.AddRange(BAOCAOCHINHANH7(queryCN.SingleOrDefault(n => n.macn == x).data, strcn));
                    }
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(BAOCAOCUAHANG7(queryCH.SingleOrDefault(n => n.macn == x).data, strcn));
                }
            }
            return DATAX;
        }
        public List<sp_IN_TONGHOP_CONGNO_IN_Result> DATABAOCAO3(List<string> soso, DateTime tungay, DateTime denngay, string phanloai, List<string> phanloaikhachhang, List<string> khuvuc, List<string> trinhduocvien, List<string> quanhuyen)
        {
            string tk = "131";
            string strcn = "";
            strcn = (strcn + " DECLARE @TBL_IN_0 TABLE( ");
            strcn = (strcn + " MAKH VARCHAR(20)   ");
            strcn = (strcn + " ,DAUNAM_NO FLOAT DEFAULT  NULL ,TENKH NVARCHAR(300) ");
            strcn = (strcn + "  ,DAUNAM_CO FLOAT DEFAULT  NULL ");
            strcn = (strcn + "  ,PSNO_0 FLOAT DEFAULT  NULL ");
            strcn = (strcn + "  ,PSCO_0 FLOAT DEFAULT  NULL ");
            strcn = (strcn + "  ,DKNO FLOAT DEFAULT  NULL ");
            strcn = (strcn + "  ,DKCO FLOAT DEFAULT  NULL ");
            strcn = (strcn + " ,PSNO FLOAT DEFAULT  NULL  ");
            strcn = (strcn + "   ,PSCO FLOAT DEFAULT  NULL");
            strcn = (strcn + "  ,CKNO FLOAT DEFAULT  NULL ");
            strcn = (strcn + "   ,CKCO FLOAT DEFAULT  NULL");
            strcn = (strcn + "   ,MAKH1 VARCHAR(20) )");
            strcn = (strcn + "   insert into @TBL_IN_0(makh,daunam_no,daunam_co)");
            strcn = (strcn + "  select dta_daukytaikhoan.matk,isnull(dta_daukytaikhoan.duno,0),isnull(duco,0) ");
            strcn = (strcn + "  FROM dta_daukytaikhoan ,TBL_DANHMUCKHACHHANG ");
            strcn = (strcn + "  WHERE ");
            strcn = ((strcn + "  dta_daukytaikhoan. nam=") + tungay.Year);
            // nam
            strcn = (strcn + "  AND dta_daukytaikhoan.MATK=TBL_DANHMUCKHACHHANG.MAKH ");
            strcn = ((strcn + "  AND TBL_DANHMUCKHACHHANG.TK=\'") + (tk + "\' "));
            strcn = (strcn + "  insert into @TBL_IN_0(makh,psno_0)  ");
            strcn = (strcn + "  select makhn,isnull(sum(tien),0)  ");
            strcn = (strcn + "  FROM dta_dinhkhoan ");
            strcn = ((strcn + "  where  NGAY BETWEEN CAST( \'01/01/\'+CAST(YEAR(\'") + (tungay.ToString("MM/dd/yyyy") + "\') AS VARCHAR) AS SMALLDATETIME)  "));
            strcn = ((strcn + "  and   dbo.funNgaycuoiThang (\'") + (tungay.ToString("MM/dd/yyyy") + "\')"));
            strcn = (strcn + "  and kt=1 and makhn<>\'\'  ");
            strcn = (strcn + "  group by makhn ");
            strcn = (strcn + "  insert into @TBL_IN_0(makh,psco_0) ");
            strcn = (strcn + "  select makhc,isnull(sum(tien),0)  ");
            strcn = (strcn + "  FROM dta_dinhkhoan ");
            strcn = ((strcn + "  where  NGAY BETWEEN CAST( \'01/01/\'+CAST(YEAR(\'") + (tungay.ToString("MM/dd/yyyy") + "\') AS VARCHAR) AS SMALLDATETIME)  "));
            strcn = ((strcn + "  and   dbo.funNgaycuoiThang (\'") + (tungay.ToString("MM/dd/yyyy") + "\')"));
            strcn = (strcn + "  and kt=1 and   makhc<>\'\'  ");
            strcn = (strcn + "   group by makhc ");
            strcn = (strcn + "  insert into @TBL_IN_0(makh,psno) ");
            strcn = (strcn + "  select makhn,isnull(sum(tien),0)  ");
            strcn = (strcn + " FROM dta_dinhkhoan");
            strcn = ((strcn + " where NGAY BETWEEN  \'") + (tungay.ToString("MM/dd/yyyy") + ("\'  AND \'" + (denngay.ToString("MM/dd/yyyy") + "\' "))));
            strcn = (strcn + "  and makhn<>\'\' ");
            strcn = (strcn + "  and kt=1 group by makhn ");
            strcn = (strcn + "  insert into @TBL_IN_0(makh,psco) ");
            strcn = (strcn + "   select makhc,isnull(sum(tien),0) ");
            strcn = (strcn + " FROM dta_dinhkhoan ");
            strcn = ((strcn + " where NGAY BETWEEN  \'") + (tungay.ToString("MM/dd/yyyy") + ("\'  AND \'" + (denngay.ToString("MM/dd/yyyy") + "\' "))));
            strcn = (strcn + "  and makhc<>\'\' ");
            strcn = (strcn + "  and kt=1 group by makhc  ");
            strcn = (strcn + " DECLARE @TBL_IN_CONGNOTH TABLE( ");
            strcn = (strcn + " MAKH VARCHAR(20)   ");
            strcn = (strcn + " ,DAUNAM_NO FLOAT DEFAULT  NULL ,TENKH NVARCHAR(200) ");
            strcn = (strcn + "  ,DAUNAM_CO FLOAT DEFAULT  NULL ");
            strcn = (strcn + "  ,PSNO_0 FLOAT DEFAULT  NULL ");
            strcn = (strcn + "  ,PSCO_0 FLOAT DEFAULT  NULL ");
            strcn = (strcn + "  ,DKNO FLOAT DEFAULT  NULL ");
            strcn = (strcn + "  ,DKCO FLOAT DEFAULT  NULL ");
            strcn = (strcn + " ,PSNO FLOAT DEFAULT  NULL  ");
            strcn = (strcn + "   ,PSCO FLOAT DEFAULT  NULL");
            strcn = (strcn + "  ,CKNO FLOAT DEFAULT  NULL ");
            strcn = (strcn + "   ,CKCO FLOAT DEFAULT  NULL");
            strcn = (strcn + "   ,DONVI NVARCHAR(300)");
            strcn = (strcn + "   ,DIACHI NVARCHAR(300)");
            strcn = (strcn + "  ,PHANLOAI VARCHAR(20)");
            strcn = (strcn + ",PHANLOAIKHACHHANG VARCHAR(20)");
            strcn = (strcn + " ,MATINH1 VARCHAR(20)");
            strcn = (strcn + " ,TENTINH NVARCHAR(100)");
            strcn = (strcn + ",MATDV1 VARCHAR(20) ");
            strcn = (strcn + ",TENTDV NVARCHAR(100) ");
            strcn = (strcn + ",TENDVBC NVARCHAR(200) ");
            strcn = (strcn + ",MACH VARCHAR(20),MIEN NVARCHAR(50)  ) ");
            strcn = (strcn + "   insert into @TBL_IN_CONGNOTH(makh,daunam_no,daunam_co,psno_0,psco_0,dkno,dkco,psno,psco,ckno,ckco)" +
            "");
            strcn = (strcn + "   select makh,sum(isnull(daunam_no,0)),sum(isnull(daunam_co,0)),sum(isnull(psno_0,0))");
            strcn = (strcn + "  ,sum(isnull(psco_0,0)),sum(isnull(dkno,0)),sum(isnull(dkco,0)),sum(isnull(psno,0)),sum(isnull(psco," +
            "0)) ");
            strcn = (strcn + "  ,sum(isnull(ckno,0)),sum(isnull(ckco,0)) ");
            strcn = (strcn + "  from @TBL_IN_0 ");
            strcn = (strcn + "  group by makh ");
            strcn = (strcn + "  update @TBL_IN_CONGNOTH ");
            strcn = (strcn + "   set dkno= daunam_no - daunam_co + psno_0 - psco_0 ");
            strcn = (strcn + "  update @TBL_IN_CONGNOTH ");
            strcn = (strcn + "  set ckno= dkno +  psno - psco  ");
            strcn = (strcn + "  update @TBL_IN_CONGNOTH ");
            strcn = (strcn + "   set dkco=-dkno,dkno=0");
            strcn = (strcn + "  where dkno<0 ");
            strcn = (strcn + "  update @TBL_IN_CONGNOTH ");
            strcn = (strcn + "  set ckco=-ckno,ckno=0 ");
            strcn = (strcn + "  where ckno<0 ");
            strcn = (strcn + " delete @TBL_IN_CONGNOTH");
            strcn = (strcn + "   where (isnull(dkno,0) + isnull(dkco,0) +isnull(psno,0) +isnull(psco,0) +isnull(Ckno,0)  + isnull(C" +
            "kco,0) )=0 ");
            strcn = (strcn + "  SELECT TBL_IN_CONGNOTH.makh ");
            strcn = (strcn + "  ,TBL_IN_CONGNOTH.dkno as nodauky ");
            strcn = (strcn + "  ,TBL_IN_CONGNOTH.dkco  as codauky ");
            strcn = (strcn + "  ,TBL_IN_CONGNOTH.psno as psno ");
            strcn = (strcn + "   ,TBL_IN_CONGNOTH.psco as psco");
            strcn = (strcn + "  ,TBL_IN_CONGNOTH.ckno as nocuoiky ");
            strcn = (strcn + "  ,TBL_IN_CONGNOTH.ckco as cocuoiky ");
            strcn = (strcn + "  ,TBL_DANHMUCKHACHHANG.donvi as noidung ");
            strcn = (strcn + "  ,TBL_DANHMUCTIEUDEBAOCAO.tendvbc , TBL_DANHMUCTIEUDEBAOCAO.tinh , TBL_DANHMUCTIEUDEBAOCAO.chuky1, TBL_DANHMUCTIEUDEBAOCAO.chuky3 , TBL_DANHMUCTIEUDEBAOCAO.chuky2b ");
            strcn = ((strcn + "   ,cast(\'") + (tungay.ToString("MM/dd/yyyy") + "\' as smalldatetime)   AS TUNGAY "));
            strcn = ((strcn + "   ,cast(\'") + (denngay.ToString("MM/dd/yyyy") + "\' as smalldatetime) AS DENNGAY "));
            strcn = ((strcn + "   ,\'") + (tk + "\' as MATK"));
            strcn = ((strcn + "   ,cast(\'") + (DateTime.Now.ToString("MM/dd/yyyy") + "\' as smalldatetime)  AS ngayin "));
            strcn = (strcn + "  , TBL_DANHMUCKHACHHANG.PHANLOAI ");
            strcn = (strcn + "  , TBL_DANHMUCKHACHHANG.matdv ");
            strcn = (strcn + "   , TBL_DANHMUCKHACHHANG.matinh");
            strcn = (strcn + "  FROM @TBL_IN_CONGNOTH TBL_IN_CONGNOTH ,TBL_DANHMUCKHACHHANG,TBL_DANHMUCTIEUDEBAOCAO ");
            strcn = (strcn + "  where TBL_IN_CONGNOTH.makh=TBL_DANHMUCKHACHHANG.makh ");
            strcn = ((strcn + "   and TBL_DANHMUCKHACHHANG.tk=\'") + (tk + "\' "));
            //TT423
            string tt423 = "";
            //NEW
            tt423 = tt423 + " declare @tuthang int,@denthang int,@nam int";
            tt423 = tt423 + " declare @TUNGAY SMALLDATETIME,@DENNGAY SMALLDATETIME";
            tt423 = tt423 + " set @tuthang =" + tungay.Month;
            tt423 = tt423 + " set @denthang=" + denngay.Month;
            tt423 = tt423 + " set @nam=" + denngay.Year;
            tt423 = tt423 + " set @tungay ='" + tungay.ToString("MM/dd/yyyy") + "'";
            tt423 = tt423 + " set @DENNGAY ='" + denngay.ToString("MM/dd/yyyy") + "'";

            tt423 = tt423 + " DECLARE @TBL_IN_0 TABLE(";
            tt423 = tt423 + " MAKH VARCHAR(20)";
            tt423 = tt423 + " ,TENKH NVARCHAR(200)";
            tt423 = tt423 + " ,DAUNAM_NO FLOAT";
            tt423 = tt423 + " ,DAUNAM_CO FLOAT";
            tt423 = tt423 + " ,PSNO_0 FLOAT";
            tt423 = tt423 + " ,PSCO_0 FLOAT";
            tt423 = tt423 + " ,DKNO FLOAT";
            tt423 = tt423 + " ,DKCO FLOAT";
            tt423 = tt423 + " ,PSNO FLOAT";
            tt423 = tt423 + " ,PSCO FLOAT";
            tt423 = tt423 + " ,CKNO FLOAT";
            tt423 = tt423 + " ,CKCO FLOAT";
            tt423 = tt423 + " ,MAKH1 VARCHAR(20) )";

            // DẦU KỲ NƠ
            tt423 = tt423 + " insert into @TBL_IN_0(makh,daunam_no)";
            tt423 = tt423 + " select dta_daukytaikhoan.MAKH,isnull(TIEN,0) ";
            tt423 = tt423 + " FROM congno_dauky_2 dta_daukytaikhoan ,TBL_DANHMUCKHACHHANG ";
            tt423 = tt423 + " WHERE dta_daukytaikhoan. nam=@NAM -1";
            tt423 = tt423 + " AND dta_daukytaikhoan.MAKH=TBL_DANHMUCKHACHHANG.MAKH";
            tt423 = tt423 + " AND TIEN>0";

            tt423 = tt423 + " insert into @TBL_IN_0(makh,daunam_co)";
            tt423 = tt423 + " select dta_daukytaikhoan.MAKH ,ABS(isnull(TIEN,0))";
            tt423 = tt423 + " FROM congno_dauky_2 dta_daukytaikhoan ,TBL_DANHMUCKHACHHANG";
            tt423 = tt423 + " WHERE dta_daukytaikhoan. nam=@NAM -1";
            tt423 = tt423 + " AND dta_daukytaikhoan.MAKH=TBL_DANHMUCKHACHHANG.MAKH";
            tt423 = tt423 + "  AND TIEN <0  ";

            // phát sinh nợ trước kỳ
            tt423 = tt423 + " insert into @TBL_IN_0(makh,psno_0)";
            tt423 = tt423 + " select HOADON.makh,sum(round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0))";
            tt423 = tt423 + " from DTA_CT_HOADON_XUAT CT,DTA_HOADON_XUAT HOADON,TBL_DANHMUCKHACHHANG dm_khachhang";
            tt423 = tt423 + " where  HOADON.NGAYLAPHD BETWEEN CAST( '01/01/'+CAST(YEAR(@TUNGAY) AS VARCHAR) AS SMALLDATETIME) ";
            tt423 = tt423 + " and dbo.funNgaycuoiThang (@tungay)";
            tt423 = tt423 + " AND HOADON.SOHD=CT.SOHD";
            tt423 = tt423 + " AND HOADON.NGAYLAPHD=CT.NGAYLAPHD";
            tt423 = tt423 + " AND HOADON.MACH=CT.MACH";
            tt423 = tt423 + " AND CT.KT=1";
            tt423 = tt423 + " AND HOADON.MAKH=DM_KHACHHANG.MAKH";
            tt423 = tt423 + " AND HOADON.CTGS='BAN_DL'";
            tt423 = tt423 + " AND HOADON.MAPL='BAN'";
            tt423 = tt423 + " GROUP BY  HOADON.makh";

            tt423 = tt423 + " insert into @TBL_IN_0(makh,psno_0)";
            tt423 = tt423 + " select HOADON.makh,sum(round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0) - round((round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0)*ct.tyleck*0.01),0))";
            tt423 = tt423 + " from DTA_CT_HOADON_XUAT CT,DTA_HOADON_XUAT HOADON,TBL_DANHMUCKHACHHANG dm_khachhang";
            tt423 = tt423 + " where  HOADON.NGAYLAPHD BETWEEN CAST( '01/01/'+CAST(YEAR(@TUNGAY) AS VARCHAR) AS SMALLDATETIME) ";
            tt423 = tt423 + " and dbo.funNgaycuoiThang (@tungay)";
            tt423 = tt423 + " AND HOADON.SOHD=CT.SOHD";
            tt423 = tt423 + " AND HOADON.NGAYLAPHD=CT.NGAYLAPHD";
            tt423 = tt423 + " AND HOADON.MACH=CT.MACH";
            tt423 = tt423 + " AND CT.KT=1";
            tt423 = tt423 + " AND HOADON.MAKH=DM_KHACHHANG.MAKH";
            tt423 = tt423 + " AND HOADON.CTGS='BAN_KHAC'";
            tt423 = tt423 + " AND HOADON.MAPL='BAN'";
            tt423 = tt423 + " GROUP BY  HOADON.makh";
            //trả tiền trước kỳ
            tt423 = tt423 + " insert into @TBL_IN_0(makh,psco_0)";
            tt423 = tt423 + " select congno.makh,sum(congno.tien)";
            tt423 = tt423 + " from CONGNO_KHACHHANG_TRATIEN congno,TBL_DANHMUCKHACHHANG dm_khachhang";
            tt423 = tt423 + " where NGAY BETWEEN CAST( '01/01/'+CAST(YEAR(@TUNGAY) AS VARCHAR) AS SMALLDATETIME) ";
            tt423 = tt423 + " and dbo.funNgaycuoiThang (@tungay)";
            tt423 = tt423 + " and congno.makh=dm_khachhang.makh";
            tt423 = tt423 + " AND congno.KT IS NULL ";
            tt423 = tt423 + " group by  congno.makh ";

            // phát sinh nợ trong kỳ
            tt423 = tt423 + " insert into @TBL_IN_0(makh,psno)";
            tt423 = tt423 + " select HOADON.makh,sum(round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0))";
            tt423 = tt423 + " from DTA_CT_HOADON_XUAT CT,DTA_HOADON_XUAT HOADON,TBL_DANHMUCKHACHHANG dm_khachhang";
            tt423 = tt423 + " where  HOADON.NGAYLAPHD   BETWEEN  @TUNGAY AND @DENNGAY";
            tt423 = tt423 + " AND HOADON.SOHD=CT.SOHD";
            tt423 = tt423 + " AND HOADON.NGAYLAPHD=CT.NGAYLAPHD";
            tt423 = tt423 + " AND HOADON.MACH=CT.MACH";
            tt423 = tt423 + " AND CT.KT=1";
            tt423 = tt423 + " AND HOADON.MAKH=DM_KHACHHANG.MAKH";
            tt423 = tt423 + " AND HOADON.CTGS='BAN_DL'";
            tt423 = tt423 + " AND HOADON.MAPL='BAN'";
            tt423 = tt423 + " GROUP BY  HOADON.makh";

            tt423 = tt423 + " insert into @TBL_IN_0(makh,psno)";
            tt423 = tt423 + " select HOADON.makh,sum(round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0) - round((round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0)*ct.tyleck*0.01),0))";
            tt423 = tt423 + " from DTA_CT_HOADON_XUAT CT,DTA_HOADON_XUAT HOADON,TBL_DANHMUCKHACHHANG dm_khachhang";
            tt423 = tt423 + " where  HOADON.NGAYLAPHD   BETWEEN  @TUNGAY AND @DENNGAY";
            tt423 = tt423 + " AND HOADON.SOHD=CT.SOHD";
            tt423 = tt423 + " AND HOADON.NGAYLAPHD=CT.NGAYLAPHD";
            tt423 = tt423 + " AND HOADON.MACH=CT.MACH";
            tt423 = tt423 + " AND CT.KT=1";
            tt423 = tt423 + " AND HOADON.MAKH=DM_KHACHHANG.MAKH";
            tt423 = tt423 + " AND HOADON.CTGS='BAN_KHAC'";
            tt423 = tt423 + " AND HOADON.MAPL='BAN'";
            tt423 = tt423 + " GROUP BY  HOADON.makh";

            tt423 = tt423 + " insert into @TBL_IN_0(makh,psno)";
            tt423 = tt423 + " select congno.makh,sum(congno.tien)";
            tt423 = tt423 + " from CONGNO_KHACHHANG_TRATIEN congno,TBL_DANHMUCKHACHHANG dm_khachhang";
            tt423 = tt423 + " where NGAY BETWEEN  @TUNGAY AND @DENNGAY";
            tt423 = tt423 + " and congno.makh=dm_khachhang.makh";
            tt423 = tt423 + " AND congno.KT IS NULL ";
            tt423 = tt423 + " and tien<0";
            tt423 = tt423 + " group by  congno.makh ";

            // trả tiền trong kỳ
            tt423 = tt423 + " insert into @TBL_IN_0(makh,psco)";
            tt423 = tt423 + " select congno.makh,sum(congno.tien)";
            tt423 = tt423 + " from CONGNO_KHACHHANG_TRATIEN congno,TBL_DANHMUCKHACHHANG dm_khachhang";
            tt423 = tt423 + " where NGAY BETWEEN  @TUNGAY AND @DENNGAY";
            tt423 = tt423 + " and congno.makh=dm_khachhang.makh";
            tt423 = tt423 + " AND congno.KT IS NULL ";
            tt423 = tt423 + " and tien > 0";
            tt423 = tt423 + " group by  congno.makh ";

            tt423 = tt423 + " DECLARE @TBL_IN_CONGNOTH TABLE( ";
            tt423 = tt423 + " MAKH VARCHAR(20)";
            tt423 = tt423 + " ,DAUNAM_NO MONEY";
            tt423 = tt423 + " ,TENKH NVARCHAR(200) ";
            tt423 = tt423 + " ,DAUNAM_CO MONEY";
            tt423 = tt423 + " ,PSNO_0 MONEY ";
            tt423 = tt423 + " ,PSCO_0 MONEY ";
            tt423 = tt423 + " ,DKNO MONEY";
            tt423 = tt423 + " ,DKCO MONEY";
            tt423 = tt423 + " ,PSNO MONEY";
            tt423 = tt423 + " ,PSCO MONEY";
            tt423 = tt423 + " ,CKNO MONEY ";
            tt423 = tt423 + " ,CKCO MONEY";
            tt423 = tt423 + " ) ";

            tt423 = tt423 + " insert into @TBL_IN_CONGNOTH(makh,daunam_no,daunam_co,psno_0,psco_0,dkno,dkco,psno,psco,ckno,ckco)";
            tt423 = tt423 + " select makh,sum(ISNULL(daunam_no,0)),sum(ISNULL(daunam_co,0)),sum(ISNULL(psno_0,0))";
            tt423 = tt423 + " ,sum(ISNULL(psco_0,0)),sum(ISNULL(dkno,0)),sum(ISNULL(dkco,0)),sum(ISNULL(psno,0)),sum(ISNULL(psco,0))";
            tt423 = tt423 + " ,sum(ISNULL(ckno,0)),sum(ISNULL(ckco,0))";
            tt423 = tt423 + " from @TBL_IN_0";
            tt423 = tt423 + " group by makh";

            tt423 = tt423 + " update @TBL_IN_CONGNOTH";
            tt423 = tt423 + " set dkno= daunam_no - daunam_co + psno_0 - psco_0 ";

            tt423 = tt423 + " update @TBL_IN_CONGNOTH";
            tt423 = tt423 + " set ckno= dkno +  psno - psco ";

            tt423 = tt423 + " update @TBL_IN_CONGNOTH";
            tt423 = tt423 + " set dkco=-dkno,dkno=0";
            tt423 = tt423 + " where dkno<0";

            tt423 = tt423 + " update @TBL_IN_CONGNOTH";
            tt423 = tt423 + " set ckco=-ckno,ckno=0";
            tt423 = tt423 + " where ckno<0";

            tt423 = tt423 + " delete @TBL_IN_CONGNOTH ";
            tt423 = tt423 + " where (isnull(dkno,0) + isnull(dkco,0) +isnull(psno,0) +isnull(psco,0) +isnull(Ckno,0)  + isnull(Ckco,0) )=0";

            tt423 = tt423 + "  Select TBL_IN_CONGNOTH.makh ";
            tt423 = tt423 + "  ,TBL_IN_CONGNOTH.dkno As nodauky ";
            tt423 = tt423 + "  ,TBL_IN_CONGNOTH.dkco  As codauky ";
            tt423 = tt423 + "  ,TBL_IN_CONGNOTH.psno As psno ";
            tt423 = tt423 + "   ,TBL_IN_CONGNOTH.psco As psco";
            tt423 = tt423 + "  ,TBL_IN_CONGNOTH.ckno As nocuoiky ";
            tt423 = tt423 + "  ,TBL_IN_CONGNOTH.ckco As cocuoiky ";
            tt423 = tt423 + "  ,TBL_DANHMUCKHACHHANG.donvi As noidung ";

            tt423 = tt423 + "  ,TBL_DANHMUCTIEUDEBAOCAO.tendvbc,TBL_DANHMUCTIEUDEBAOCAO.tinh, ";
            tt423 = tt423 + "  '' AS chuky1, ";
            tt423 = tt423 + "  '' AS chuky3,'' AS chuky2b ";
            tt423 = tt423 + "   ,cast('" + tungay.ToString("MM/dd/yyyy") + "' as smalldatetime)   AS TUNGAY ";
            tt423 = tt423 + "   ,cast('" + denngay.ToString("MM/dd/yyyy") + "' as smalldatetime) AS DENNGAY ";
            tt423 = tt423 + "   ,cast('" + DateTime.Now.ToString("MM/dd/yyyy") + "' as smalldatetime)  AS ngayin ";
            tt423 = tt423 + "   ," + denngay.Year + " as nam";
            tt423 = tt423 + "  , TBL_DANHMUCKHACHHANG.PHANLOAI ";
            tt423 = tt423 + "  , TBL_DANHMUCKHACHHANG.matdv ";
            tt423 = tt423 + "   , TBL_DANHMUCKHACHHANG.matinh";
            tt423 = tt423 + "  FROM @TBL_IN_CONGNOTH TBL_IN_CONGNOTH ,TBL_DANHMUCKHACHHANG TBL_DANHMUCKHACHHANG,TBL_DANHMUCTIEUDEBAOCAO";
            tt423 = tt423 + "  where TBL_IN_CONGNOTH.makh=TBL_DANHMUCKHACHHANG.makh ";
            //
            //CUAHANG
            string strch = "";
            strch = strch + " DECLARE @TBL_IN TABLE ( ";
            strch = strch + "   makh1 VARCHAR(20)   ";
            strch = strch + " ,DONVI NVARCHAR(200) ";
            strch = strch + "  ,DK_NO float";
            strch = strch + " ,DK_CO float ";

            strch = strch + "  ,PS_NO float ";
            strch = strch + " ,PS_CO float ";
            strch = strch + " ,CK_NO float ";
            strch = strch + " ,CK_CO float )   ";

            strch = strch + " DECLARE @TABLE TABLE ( ";
            strch = strch + "   makh VARCHAR(20)   ";
            strch = strch + " ,nodauky float ";
            strch = strch + "  ,codauky float";
            strch = strch + ",psno float ";

            strch = strch + " ,psco float ";
            strch = strch + ",nocuoiky float ";
            strch = strch + ",cocuoiky float ";
            strch = strch + "  ,noidung NVARCHAR(200) )   ";
            strch = strch + "    INSERT INTO  @TBL_IN";
            strch = strch + " seleCT congno.makh,'',sum(congno.tien),0,0,0,0,0 ";
            strch = strch + "  from congno_dauky_2 congno   ";
            strch = strch + "  where congno.thang=" + tungay.Month;
            strch = strch + "  and congno.nam=" + tungay.Year;
            strch = strch + " AND TIEN >0 ";
            strch = strch + "  group by congno.makh ";

            strch = strch + "    INSERT INTO  @TBL_IN";
            strch = strch + " seleCT congno.makh,'',0,sum(ABS(congno.tien)),0,0,0,0 ";
            strch = strch + "  from congno_dauky_2 congno   ";
            strch = strch + "  where congno.thang=" + tungay.Month;
            strch = strch + "  and congno.nam=" + tungay.Year;
            strch = strch + " AND TIEN < 0 ";
            strch = strch + "  group by congno.makh ";
            // Phat sinh nợ
            strch = strch + "  insert into  @TBL_IN ";
            strch = strch + "  SELECT HOADON.MAKH,'',0,0,ROUND(sum( ROUND((ROUND(CAST(CT_HOADON.SOLUONG AS MONEY)*CAST(CT_HOADON.DONGIA AS MONEY),0)-ROUND(ROUND(CAST(CT_HOADON.SOLUONG AS MONEY)*CAST(CT_HOADON.DONGIA AS MONEY),0)*TYLECK/100,0)),0))*THUESUAT/100,0)+SUM(ROUND(CAST(CT_HOADON.SOLUONG AS MONEY)*CAST(CT_HOADON.DONGIA AS MONEY),0)-ROUND(ROUND(CAST(CT_HOADON.SOLUONG AS MONEY)*CAST(CT_HOADON.DONGIA AS MONEY),0)*TYLECK/100,0)),0,0,0  ";
            strch = strch + "  FROM HOADON_XUAT HOADON,ct_hoadon_XUAT CT_HOADON  ";
            strch = strch + "  where  HOADON.MAPL='BAN'  AND hoadon.sohd=ct_hoadon.sohd and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1  ";
            strch = strch + "  and   month(HOADON.NGAYLAPHD) BETWEEN   " + tungay.Month + " and " + denngay.Month + " and year(HOADON.NGAYLAPHD)=" + denngay.Year;
            strch = strch + "  and hoadon.mach=ct_hoadon.mach ";
            strch = strch + "  group by  HOADON.MAKH,HOADON.THUESUAT,hoadon.sohd,hoadon.ngaylaphd ";

            // phat sinh có
            strch = strch + " insert into @TBL_IN ";
            strch = strch + "  select MAKH,'',0,0,0, sum( CN.tien) ,0,0 ";
            strch = strch + " from congno_khachhang_tratien  CN ";
            strch = strch + " where  month(CN.ngaylaphd)  BETWEEN  " + tungay.Month + " and " + denngay.Month + " and year(CN.ngaylaphd)=" + denngay.Year;
            strch = strch + " AND KT IS NULL  GROUP BY MAKH  ";
            strch = strch + "  update @TBL_IN ";
            strch = strch + " set DONVI=(SELECT DONVI FROM DM_KHACHHANG_PTTT WHERE MAKH=MAKH1) ";
            strch = strch + " INSERT INTO @TABLE  ";
            strch = strch + " SELECT MAKH1,SUM(ISNULL(DK_NO,0)),SUM(ISNULL(DK_CO,0)) ";
            strch = strch + " ,SUM(ISNULL(PS_NO,0)),SUM(ISNULL(PS_CO,0))";
            strch = strch + " ,SUM(ISNULL(CK_NO,0)),SUM(ISNULL(CK_CO,0))";
            strch = strch + " ,DONVI";
            strch = strch + " FROM  @TBL_IN";
            strch = strch + " group by  MAKH1,DONVI ";
            strch = strch + " update @TABLE ";
            strch = strch + " set noCUOIKY=   ISNULL( noDAUKY,0) + ISNULL( psno,0) - ISNULL(  psco,0) - ISNULL( CODAUKY,0)";
            strch = strch + " update  @TABLE  ";
            strch = strch + " set  coCUOIKY=- NoCUOIKY,NoCUOIKY=0";
            strch = strch + " where NoCUOIKY<0";
            strch = strch + "  delete @TABLE";
            strch = strch + " where  ABS(nodauky)+ABS(codauky)+ABS( psno)  +ABS(psco)+ABS(nocuoiky) +ABS(cocuoiky) =0";

            // khai báo table mới
            strch = strch + " DECLARE @TBL_IN_CONGNOTH TABLE( ";
            strch = strch + " MAKH VARCHAR(20)   ";
            strch = strch + " ,DAUNAM_NO FLOAT DEFAULT  NULL ,TENKH NVARCHAR(200) ";
            strch = strch + "  ,DAUNAM_CO FLOAT DEFAULT  NULL ";
            strch = strch + "  ,PSNO_0 FLOAT DEFAULT  NULL ";

            strch = strch + "  ,PSCO_0 FLOAT DEFAULT  NULL ";
            strch = strch + "  ,DKNO FLOAT DEFAULT  NULL ";
            strch = strch + "  ,DKCO FLOAT DEFAULT  NULL ";
            strch = strch + " ,PSNO FLOAT DEFAULT  NULL  ";
            strch = strch + "   ,PSCO FLOAT DEFAULT  NULL";
            strch = strch + "  ,CKNO FLOAT DEFAULT  NULL ";
            strch = strch + "   ,CKCO FLOAT DEFAULT  NULL";
            strch = strch + "   ,DONVI NVARCHAR(300)";
            strch = strch + "   ,DIACHI NVARCHAR(300)";
            strch = strch + "  ,PHANLOAI VARCHAR(20)";
            strch = strch + ",PHANLOAIKHACHHANG VARCHAR(20)";
            strch = strch + " ,MATINH1 VARCHAR(20)";
            strch = strch + " ,TENTINH NVARCHAR(100)";
            strch = strch + ",MATDV1 VARCHAR(20) ";
            strch = strch + ",TENTDV NVARCHAR(100) ";
            strch = strch + ",TENDVBC NVARCHAR(200) ";
            strch = strch + ",MACH VARCHAR(20),MIEN NVARCHAR(50)  ) ";

            strch = strch + " INSERT INTO @TBL_IN_CONGNOTH( MAKH,TENKH,CKNO,CKCO,PSNO,PSCO,DKNO,DKCO)";
            strch = strch + " SELECT MAKH,NOIDUNG,nocuoiky,cocuoiky,PSNO,PSCO,NODAUKY,CODAUKY";
            strch = strch + " FROM @TABLE ";
            strch = strch + "  SELECT TBL_IN_CONGNOTH.makh ";
            strch = strch + "  ,TBL_IN_CONGNOTH.dkno as nodauky ";
            strch = strch + "  ,TBL_IN_CONGNOTH.dkco  as codauky ";
            strch = strch + "  ,TBL_IN_CONGNOTH.psno as psno ";
            strch = strch + "   ,TBL_IN_CONGNOTH.psco as psco";
            strch = strch + "  ,TBL_IN_CONGNOTH.ckno as nocuoiky ";
            strch = strch + "  ,TBL_IN_CONGNOTH.ckco as cocuoiky ";
            strch = strch + "  ,TBL_DANHMUCKHACHHANG.donvi as noidung ";
            strch = strch + "  ,TIEUDE.tendvbc,TIEUDE.tinh, ";
            strch = strch + "  '' AS chuky1, ";
            strch = strch + "  '' AS chuky3,'' AS NGANHANG,'' AS chuky2b  ";
            strch = strch + "   ,cast('" + tungay.ToString("MM/dd/yyyy") + "' as smalldatetime)   AS TUNGAY ";
            strch = strch + "   ,cast('" + denngay.ToString("MM/dd/yyyy") + "' as smalldatetime) AS DENNGAY ";

            strch = strch + "   ,cast('" + DateTime.Now.ToString("MM/dd/yyyy") + "' as smalldatetime)  AS ngayin ";

            strch = strch + "  , TBL_DANHMUCKHACHHANG.PHANLOAI ";
            strch = strch + "  , TBL_DANHMUCKHACHHANG.matdv ";
            strch = strch + "   , TBL_DANHMUCKHACHHANG.matinh";
            strch = strch + "  FROM  @TBL_IN_CONGNOTH TBL_IN_CONGNOTH ,dm_khachhang_pttt TBL_DANHMUCKHACHHANG,TIEUDE ";
            strch = strch + "  where TBL_IN_CONGNOTH.makh=TBL_DANHMUCKHACHHANG.makh ";

            //
            if (khuvuc != null)
            {
                strcn = (strcn + (" AND TBL_DANHMUCKHACHHANG.MATINH IN (select val from  fun_CATCHUOI(\'"
                            + (String.Join(",", khuvuc.ToArray()).Trim() + "\'))")));
                tt423 = (tt423 + (" AND TBL_DANHMUCKHACHHANG.MATINH IN (select val from  fun_CATCHUOI(\'"
                            + (String.Join(",", khuvuc.ToArray()).Trim() + "\'))")));
            }

            if (phanloai != "ALL")
            {
                strcn = (strcn + (" AND TBL_DANHMUCKHACHHANG.phanloai IN (select val from  fun_CATCHUOI(\'"
                            + phanloai + "\'))"));
                tt423 = (tt423 + (" AND TBL_DANHMUCKHACHHANG.phanloai IN (select val from  fun_CATCHUOI(\'"
                           + phanloai + "\'))"));
                strch = (strch + (" AND TBL_DANHMUCKHACHHANG.phanloai IN (select val from  fun_CATCHUOI(\'"
                           + phanloai + "\'))"));
            }
            if (trinhduocvien != null)
            {
                strcn = (strcn + (" AND TBL_DANHMUCKHACHHANG.matdv IN (select val from  fun_CATCHUOI(\'"
                            + (String.Join(",", trinhduocvien.ToArray()).Trim() + "\'))")));
                tt423 = (tt423 + (" AND TBL_DANHMUCKHACHHANG.matdv IN (select val from  fun_CATCHUOI(\'"
                         + (String.Join(",", trinhduocvien.ToArray()).Trim() + "\'))")));
                strch = (strch + (" AND TBL_DANHMUCKHACHHANG.matdv IN (select val from  fun_CATCHUOI(\'"
                           + (String.Join(",", trinhduocvien.ToArray()).Trim() + "\'))")));
            }
            if (phanloaikhachhang != null)
            {
                strcn = (strcn + (" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN (select val from  fun_CATCHUOI(\'"
                            + (String.Join(",", phanloaikhachhang.ToArray()).Trim() + "\'))")));
                tt423 = (tt423 + (" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN (select val from  fun_CATCHUOI(\'"
                         + (String.Join(",", phanloaikhachhang.ToArray()).Trim() + "\'))")));
                strch = (strch + (" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN (select val from  fun_CATCHUOI(\'"
                          + (String.Join(",", phanloaikhachhang.ToArray()).Trim() + "\'))")));
            }
            if (quanhuyen != null)
            {
                strcn = (strcn + (" AND TBL_DANHMUCKHACHHANG.quanhuyen IN (select val from  fun_CATCHUOI(\'"
                           + (String.Join(",", quanhuyen.ToArray()).Trim() + "\'))")));
                tt423 = (tt423 + (" AND TBL_DANHMUCKHACHHANG.quanhuyen IN (select val from  fun_CATCHUOI(\'"
                          + (String.Join(",", quanhuyen.ToArray()).Trim() + "\'))")));
                strch = (strch + (" AND TBL_DANHMUCKHACHHANG.quanhuyen IN (select val from  fun_CATCHUOI(\'"
                           + (String.Join(",", quanhuyen.ToArray()).Trim() + "\'))")));
            }
            strcn = (strcn + "  order by TBL_IN_CONGNOTH.makh ");
            tt423 = (tt423 + "  order by TBL_IN_CONGNOTH.makh ");
            strch = strch + "  order by TBL_IN_CONGNOTH.makh ";
            //
            var DATAX = new List<sp_IN_TONGHOP_CONGNO_IN_Result>();
            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    if (x == "TT423")
                    {
                        DATAX.AddRange(BAOCAOCHINHANH3(queryCN.SingleOrDefault(n => n.macn == x).data, tt423));
                    }
                    else
                    {
                        DATAX.AddRange(BAOCAOCHINHANH3(queryCN.SingleOrDefault(n => n.macn == x).data, strcn));
                    }

                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(BAOCAOCUAHANG3(queryCH.SingleOrDefault(n => n.macn == x).data, strch));
                }
            }
            return DATAX;
        }
        public List<DULIEUBAOCAO29_2022> DATABAOCAO29_2022(List<string> soso, string phanloai, List<string> phanloaikhachhang, List<string> nhomhang, List<string> sanpham, List<string> quanhuyen, List<string> matinh, List<string> makh, List<string> matdv, List<string> hopdong, List<string> mapl, List<string> makm, List<string> mactht, DateTime tungay, DateTime denngay, int top)
        {


            var DATAX = new List<DULIEUBAOCAO29_2022>();
            //String CN
            string strcn = "SELECT TBL_DANHMUCKHACHHANG.MAKH AS MAHH,TBL_DANHMUCKHACHHANG.DONVI AS TENHH,TBL_DANHMUCKHACHHANG.MATINH AS DVT,SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0)) -  sum(ROUND(round(cast(DTA_CT_HOADON_XUAT.soluong as money)*cast(DTA_CT_HOADON_XUAT.dongia as money),0)*cast(DTA_CT_HOADON_XUAT.tyleck as money) /100,0))   AS TIEN ,CAST(SUM(DTA_CT_HOADON_XUAT.SOLUONG) as decimal) AS SOLUONG,( SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0))-  sum(ROUND(round(cast(DTA_CT_HOADON_XUAT.soluong as money)*cast(DTA_CT_HOADON_XUAT.dongia as money),0)*cast(DTA_CT_HOADON_XUAT.tyleck as money) /100,0)) )/SUM(DTA_CT_HOADON_XUAT.SOLUONG) AS DONGIA   ,TBL_DANHMUCCUAHANG.MACH AS NHOM, TBL_DANHMUCKHACHHANG.PHANLOAI AS MAQUAY FROM DTA_CT_HOADON_XUAT  LEFT JOIN  TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH,DTA_HOADON_XUAT LEFT JOIN TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh ,TBL_DANHMUCCUAHANG WHERE DTA_HOADON_XUAT.SOHD = DTA_CT_HOADON_XUAT.SOHD AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH = DTA_CT_HOADON_XUAT.MACH  and DTA_CT_HOADON_XUAT.kt = 1 AND DTA_HOADON_XUAT.NGAYLAPHD between '" + tungay.ToString("yyyy-MM-dd") + "' AND '" + denngay.ToString("yyyy-MM-dd") + "' ";
            //String CH
            string strch = "SELECT TBL_DANHMUCKHACHHANG.MAKH AS MAHH,TBL_DANHMUCKHACHHANG.DONVI AS TENHH,TBL_DANHMUCKHACHHANG.MATINH AS DVT,SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0)) -  sum(ROUND(round(cast(DTA_CT_HOADON_XUAT.soluong as money)*cast(DTA_CT_HOADON_XUAT.dongia as money),0)*cast(DTA_CT_HOADON_XUAT.tyleck as money) /100,0))   AS TIEN ,CAST(SUM(DTA_CT_HOADON_XUAT.SOLUONG) as decimal) AS SOLUONG,( SUM(ROUND(CAST(DTA_CT_HOADON_XUAT.SOLUONG AS MONEY)*CAST(DTA_CT_HOADON_XUAT.DONGIA AS MONEY),0))-  sum(ROUND(round(cast(DTA_CT_HOADON_XUAT.soluong as money)*cast(DTA_CT_HOADON_XUAT.dongia as money),0)*cast(DTA_CT_HOADON_XUAT.tyleck as money) /100,0)) )/SUM(DTA_CT_HOADON_XUAT.SOLUONG) AS DONGIA ,TBL_DANHMUCCUAHANG.MACH AS NHOM , TBL_DANHMUCKHACHHANG.PHANLOAI AS MAQUAY   FROM CT_HOADON_XUAT DTA_CT_HOADON_XUAT  LEFT JOIN  DM_HANGHOA TBL_DANHMUCHANGHOA ON DTA_CT_HOADON_XUAT.MAHH=TBL_DANHMUCHANGHOA.MAHH,HOADON_XUAT DTA_HOADON_XUAT LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON DTA_HOADON_XUAT.makh=TBL_DANHMUCKHACHHANG.makh ,TBL_DANHMUCCUAHANG WHERE DTA_HOADON_XUAT.SOHD=DTA_CT_HOADON_XUAT.SOHD  AND DTA_HOADON_XUAT.NGAYLAPHD=DTA_CT_HOADON_XUAT.NGAYLAPHD AND DTA_HOADON_XUAT.MACH = DTA_CT_HOADON_XUAT.MACH  and DTA_CT_HOADON_XUAT.kt = 1 AND DTA_HOADON_XUAT.NGAYLAPHD between '" + tungay.ToString("yyyy-MM-dd") + "' AND '" + denngay.ToString("yyyy-MM-dd") + "' ";
            //String MB

            if (phanloai != "ALL")
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }
            if (phanloaikhachhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            }
            //if (hopdong != null)
            //{
            //    List<string> kh = new List<string>();
            //    List<string> hd = new List<string>();
            //    foreach (var i in hopdong)
            //    {
            //        var k = i.Split('~').ToList();
            //        hd.Add(k.First());
            //        kh.Add(k.Last());
            //    }
            //    strcn = strcn + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MAKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
            //    strch = strch + string.Format(" AND HOADON.HOPDONG IN ({0})", string.Join(",", hd.Select(p => "'" + p + "'"))) + string.Format(" AND HOADON.MaKH IN ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
            //    //strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            //}
            if (nhomhang != null)
            {
                strcn = strcn + string.Format(" AND Substring(dta_ct_hoadon_xuat.mahh, 1, 2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND SUBSTRING(DTA_CT_HOADON_XUAT.MAHH,1,2) IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (sanpham != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.MAHH IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCHANGHOA.MAHH IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND replace(dclChiTietHangHoa.MaCap, ' ', '') IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
            }
            if (quanhuyen != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
            }
            if (matinh != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
            }
            if (makh != null)
            {
                strcn = strcn + string.Format(" AND DTA_HOADON_XUAT.MAKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_HOADON_XUAT.MAKH IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            }
            if (matdv != null)
            {
                strcn = strcn + string.Format(" AND dta_hoadon_xuat.matdv IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.MATDV IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            if (mapl != null)
            {
                strcn = strcn + string.Format(" AND DTA_HOADON_XUAT.MAPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_HOADON_XUAT.MAPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
            }
            if (makm != null)
            {
                strcn = strcn + string.Format(" AND DTA_CT_HOADON_XUAT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_CT_HOADON_XUAT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
            }
            if (mactht != null)
            {

                strcn = strcn + string.Format(" AND DTA_CT_HOADON_XUAT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DTA_CT_HOADON_XUAT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));

            }
            //DTA_CT_HOADON_XUAT.MAKM
            //String MB
            strcn = strcn + " GROUP BY TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.MAKH,TBL_DANHMUCKHACHHANG.DONVI,TBL_DANHMUCKHACHHANG.MATINH,TBL_DANHMUCCUAHANG.MACH HAVING SUM(DTA_CT_HOADON_XUAT.SOLUONG) <>0 ";
            strch = strch + "  GROUP BY TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.MAKH,TBL_DANHMUCKHACHHANG.DONVI,TBL_DANHMUCKHACHHANG.MATINH,TBL_DANHMUCCUAHANG.MACH HAVING SUM(DTA_CT_HOADON_XUAT.SOLUONG) <> 0 ";
            //strnew = strnew + "group by  dclChiTietKhachHang.TENCAP, dclChiTietKhachHang.TaiKhoanID,dtaChungTu.SoHoaDon,dtasoluong.TienBan, dclDanhSachDonViTinh.TenDonViTinh, dtasoluong.SOLUONG, dtasoluong.GIAban, dtaDinhKhoan.TaiKhoanNo, dtaChungTu.ngaychungtu, dclChiTietHangHoa.MaCap, dclChiTietHangHoa.TENCAP, tbl_danhmuctieudebaocao.tendvbc, tbl_mien.mien, dtaChungTu.khachhangid, TBL_DANHMUCCUAHANG.MACH ,KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang";
            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DULIEUBAOCAO29_2022>(strcn).ToList());
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DULIEUBAOCAO29_2022>(strch).ToList());
                }

            }
            return DATAX.OrderByDescending(n => n.tien).Take(top).ToList();
        }
    }
}
