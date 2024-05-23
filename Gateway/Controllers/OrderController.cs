using ApplicationChart.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Security.Application;
using System.Web.Security;
using System.IO;
using CrystalDecisions.Shared;
using ApplicationChart.Report;
using System.Text;
using Exportable.Engines;
using Exportable.Engines.Excel;
using ClosedXML.Excel;
using APIInvoice;

namespace ApplicationChart.Controllers
{

    [Authorize(Roles = "DONHANG,DONHANGKD,GIAOHANG,QLGIAOHANG,DONHANGHCM,DONHANGSC,QLDHKD,QLDHHCM,QLDHSC,KHOWS,KINHDOANHWS,QUANLYWS")]
    public class OrderController : MyBaseController
    {
        Entities HaNoi = new Entities("KT_HNEntities");
        Entities ThaiBinh = new Entities("KT_TBEntities");
        Entities ThaiNguyen = new Entities("KT_TNGEntities");
        Entities PhuTho = new Entities("KT_PTEntities");
        Entities TayNinh = new Entities("KT_TNEntities");
        CHQ10Entities1 CHQ10 = new CHQ10Entities1("CHQ10Entities");
        Entities TT423 = new Entities("TT423Entities");
        Entities BinhDinh = new Entities("KT_BDEntities");
        Entities CanTho = new Entities("KT_CTEntities");
        Entities DongNai = new Entities("KT_DNEntities");
        Entities DaNang = new Entities("KT_DNAEntities");
        Entities HoChiMinh = new Entities("KT_HCMEntities");
        Entities NgheAn = new Entities("KT_NAEntities");
        Entities NgheAn2 = new Entities("KT_NA_2Entities");
        Entities QuangNgai = new Entities("KT_QNEntities");
        Entities PhuYen = new Entities("KTEntities");
        Entities SC = new Entities("KT_SCEntities");
        Entities AnGiang = new Entities("KT_AGEntities");
        Entities CaMau = new Entities("KT_CMEntities");
        Entities GiaLai = new Entities("KT_GLEntities");
        Entities BinhDuong = new Entities("KT_BDGEntities");
        Entities Hue = new Entities("KT_HUEEntities");
        Entities HaiPhong = new Entities("KT_HPEntities");
        Entities LamDong = new Entities("KT_LDEntities");
        Entities QuangTri = new Entities("KT_QTEntities");
        Entities NhaTrang = new Entities("KT_NTEntities");
        Entities TienGiang = new Entities("KT_TGEntities");
        Entities VinhLong = new Entities("KT_VLEntities");
        Entities Daknong = new Entities("KT_DNONGEntities");
        Entities ThanhHoa = new Entities("KT_THOEntities");
        Entities BinhThuan = new Entities("KT_BTEntities");

        CHQ10Entities1 CHPPSP = new CHQ10Entities1("CHPPSPEntities");
        Entities Pypharm = new Entities("KT_PYPHARMEntities");
        KT_THEntities1 DATATH1 = new KT_THEntities1("KT_THEntities1");
        KT_THEntities1 DATATH2 = new KT_THEntities1("KT_THEntities2");
        CHQ10Entities1 PTTT = new CHQ10Entities1("PTTTEntities");
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();
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
                new EntitiesCN {data = new Entities("KT_SCEntities") , macn = "SC"},
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
            new EntitiesCN {data = new Entities("KT_THOEntities") , macn = "THO"},
               new EntitiesCN {data = new Entities("KT_BTEntities") , macn = "BT"},
                     new EntitiesCN {data = new Entities("KT_PTEntities") , macn = "PT"},
            new EntitiesCN {data = new Entities("KT_HNEntities") , macn = "HN"},
               new EntitiesCN {data = new Entities("KT_TNGEntities") , macn = "TNG"},
            new EntitiesCN {data = new Entities("KT_TBEntities") , macn = "TB"},
                 new EntitiesCN {data = new Entities("KT_PYPHARMEntities") , macn = "DPY"},
                 new EntitiesCN {data = new Entities("KT_PYPHARM_HCMEntities") , macn = "DPY_HCM"},
        };
        List<EntitiesCH> queryCH = new List<EntitiesCH> {
            new EntitiesCH {data = new CHQ10Entities1("PTTTEntities") , macn = "PTTT"},
            new EntitiesCH {data = new CHQ10Entities1("CHQ10Entities") , macn = "CHQ10"},
            new EntitiesCH {data = new CHQ10Entities1("CHPPSPEntities") , macn = "CHPPSP"},
        };
        Thuvieninvoice abc = new Thuvieninvoice();
        VNPTINVOICEEntities datainvoice = new VNPTINVOICEEntities();
        [ActionName("cap-nhat-gia")]
        public ActionResult Capnhatgia()
        {
            var Info = GetInfo();
            var listcn = Info.macn.Split(',').ToList();

            foreach (var macn in listcn)
            {
                var datahanghoa = DATATAO(macn, null);
                if (queryCN.SingleOrDefault(n => n.macn == macn) != null)
                {
                    var data = queryCN.SingleOrDefault(n => n.macn == macn).data.DTA_DONDATHANG.Where(n => n.GIABAN_VAT == null);
                    foreach (var i in data)
                    {
                        try
                        {
                            i.GIABAN_VAT = Convert.ToDecimal(datahanghoa.ListHH.SingleOrDefault(n => n.MAHH == i.MAHH).GIABAN);
                        }
                        catch (Exception)
                        {
                            i.GIABAN_VAT = 0;
                        }

                    }
                    queryCN.SingleOrDefault(n => n.macn == macn).data.SaveChanges();
                }
                else if (queryCH.SingleOrDefault(n => n.macn == macn) != null)
                {
                    var data = queryCH.SingleOrDefault(n => n.macn == macn).data.DTA_DONDATHANG.Where(n => n.GIABAN_VAT == null);
                    foreach (var i in data)
                    {
                        try
                        {
                            i.GIABAN_VAT = Convert.ToDecimal(datahanghoa.ListHH.SingleOrDefault(n => n.MAHH == i.MAHH).GIABAN);
                        }
                        catch (Exception)
                        {
                            i.GIABAN_VAT = 0;
                        }
                    }
                    queryCH.SingleOrDefault(n => n.macn == macn).data.SaveChanges();
                }
            }
            return Content("<script type='text/javascript'>alert('Hoàn tất');</script>");
        }
        [ActionName("danh-sach-don-dat-hang")]
        public ActionResult Danhsachdonhang()
        {
            var Info = GetInfo();
            var Infocrm = GetCRM();
            if (Info.dathang == 1 || Info.dathang == 2)
            {
                ViewBag.dathang = Info.dathang;
                ViewBag.ten = Info.hoten;
                ViewBag.quyen = Info.quyen;
                var MATDV = Infocrm.matdv;
                var MACH = Infocrm.macn;
                ViewBag.MACH = MACH;
                var Data = DATA(MACH, MATDV, DateTime.Today.AddMonths(-1), DateTime.Today.AddDays(1));
                ViewBag.TDV = MATDV;
                var THKM = DATATH1.TBL_DANHMUCKM.Where(n => n.ngayketthuc >= DateTime.Today && n.ngaybatdau <= DateTime.Today).ToList().Where(n => n.PHAMVI.Split(',').Contains(Infocrm.macn)).Select(cl => new ListChuongTrinhKM { MACTKM = cl.MACTKM, BBTT = (cl.BBTT == true) ? 1 : 0, TENCTKM = cl.TENCTKM, MAHH = cl.MAHH, TICHDIEM = cl.TICHDIEM, ck = cl.ck }).ToList();
                Data.ListCTKM = THKM.Concat(Data.ListCTKM.Where(n => !THKM.Select(cl => cl.MACTKM).ToList().Contains(n.MACTKM))).ToList();
                Data.ListDDH = Data.ListDDH.OrderByDescending(n => n.MADH).ToList();
                Data.ListCTHT = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.Where(n => n.ngayketthuc >= DateTime.Today && n.ngaybatdau <= DateTime.Today).Select(cl => new ListChuongTrinhHT { MACTHT = cl.MACTHT, TENCTHT = cl.TENCTHT, MAHH = cl.MAHH, TICHDIEM = cl.TICHDIEM, MACTKM = cl.MACTKM }).ToList();
                ViewBag.tungay = DateTime.Today.ToString("01/MM/yyyy");
                ViewBag.denngay = DateTime.Today.ToString("dd/MM/yyyy");
                return View("Danhsachdonhang", Data);
            }
            else
            {
                return RedirectToAction("bao-cao-bsc", "Home");
            }
        }
        [ActionName("tra-cuu-so-dang-ky")]
        public ActionResult Tracuusdk()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            return View("Tracuusdk", PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH,TENHH,DVT,SDK FROM TBL_DANHMUCHANGHOA WHERE MAHH IS NOT NULL AND SDK is not null and SDK != ''").ToList());
        }
        [Authorize(Roles = "KHUYENMAI,DONHANG")]
        [ActionName("quan-ly-quy-doi-diem-tich-luy")]
        public ActionResult Quanlyquydoi()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var data = DATATH1.TBL_DANHMUCKM.Where(n => n.TICHDIEM != null).Select(cl => new ListKhuyenMai { MAKM = cl.MACTKM, TENKM = cl.TENCTKM }).ToList();
            var data1 = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.Where(n => n.TICHDIEM != null).Select(cl => new ListKhuyenMai { MAKM = cl.MACTHT, TENKM = cl.TENCTHT }).ToList();
            return View("Quanlyquydoi", data.Concat(data1));
        }
        [Authorize(Roles = "KHUYENMAI")]
        [ActionName("quan-ly-hang-hoa")]
        public ActionResult Quanlyhanghoa()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var data = SC.Database.SqlQuery<Quanlyhanghoa>("SELECT MAHH AS MAHH, TENHH AS TENHH ,tenhoatchat AS HOATCHAT,  DVT AS DVT3 ,cAST(GIABAN AS MONEY) AS GIABAN3, DVT2 AS DVT2, (cAST(GIABAN AS MONEY)*SL3/SL2) AS GIABAN2 from TBL_DANHMUCHANGHOA where 1=1 and GIABAN != '' and GIABAN != '0' and SL3 != 0 AND MAHH IS NOT NULL AND MAHH != ''").ToList();
            return View("Quanlyhanghoa", data);
        }
        [Authorize(Roles = "KHUYENMAICN")]
        [ActionName("quan-ly-chuong-trinh-ban-hang-chi-nhanh")]
        public ActionResult QuanlyCTBHCN()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var data = new QuanlyCTBH { CHINHANH = db2.TBL_DANHSACHCHINHANH.Where(n => n.check == true).OrderBy(n => n.Mien).ThenByDescending(n => n.stt).ToList(), HANGHOA = SC.Database.SqlQuery<ListHangHoa>("SELECT MAHH,TENHH,DVT,GIABAN FROM TBL_DANHMUCHANGHOA WHERE MAHH IS NOT NULL AND MAHH != '' AND MAHH != '..'").ToList() };
            return View("QuanlyCTBHCN", data);
        }
        [Authorize(Roles = "KHUYENMAI")]
        [ActionName("quan-ly-chuong-trinh-ban-hang")]
        public ActionResult QuanlyCTBH()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var data = new QuanlyCTBH
            {
                CHINHANH = db2.TBL_DANHSACHCHINHANH.Where(n => n.check == true).OrderBy(n => n.Mien).ThenByDescending(n => n.stt).ToList(),
                HANGHOA = SC.Database.SqlQuery<ListHangHoa>("SELECT MAHH,TENHH,DVT,GIABAN FROM TBL_DANHMUCHANGHOA WHERE MAHH IS NOT NULL AND MAHH != '' AND MAHH != '..' ").ToList()
            };
            return View("QuanlyCTBH", data);
        }
        [Authorize(Roles = "HANGHOA")]
        [ActionName("quan-ly-danh-muc-hang-hoa")]
        public ActionResult QuanlyDMHH()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var data = DULIEUNHOM(SC);
            return View("QuanlyDMHH", data);
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
        [Authorize(Roles = "HANGHOA")]
        [ActionName("quan-ly-thay-doi")]
        public ActionResult Quanlythaydoi()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var data = DATATH1.dta_Products_pending.OrderByDescending(n => n.ngay_yeu_cau).ToList();
            return View("Quanlythaydoi", data);
        }

        [Authorize(Roles = "KHUYENMAI")]
        [ActionName("tai-chi-tiet-khuyen-mai")]
        public ActionResult Taichitietkhuyenmai()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var data = (from p in DATATH1.TBL_DANHMUCKM_CHITIET
                        join c in DATATH1.TBL_DANHMUCKM on p.MACTKM equals c.MACTKM
                        select new DATA_DANHMUCKM_CHITIET
                        {
                            MACTKM = p.MACTKM,
                            TENCTKM = c.TENCTKM,
                            BBTT = (c.BBTT == true) ? "CÓ" : "KHÔNG",
                            ngaybatdau = c.ngaybatdau,
                            ngayketthuc = c.ngayketthuc,
                            MAHH = c.MAHH,
                            PHAMVI = c.PHAMVI,
                            GHICHU = c.GHICHU,
                            HANMUC = c.HANMUC,

                            ckhd = (c.ck != null) ? (double)c.ck : 0,
                            DSTU = p.DSTU,
                            DSDEN = p.DSDEN,
                            ck = p.ck
                        }).ToList();
            var datalist = data.Select(cl => cl.MACTKM).Distinct().ToList();
            var data1 = DATATH1.TBL_DANHMUCKM.Select(c => new DATA_DANHMUCKM_CHITIET
            {
                MACTKM = c.MACTKM,
                TENCTKM = c.TENCTKM,
                BBTT = (c.BBTT == true) ? "CÓ" : "KHÔNG",
                ngaybatdau = c.ngaybatdau,
                ngayketthuc = c.ngayketthuc,
                MAHH = c.MAHH,
                PHAMVI = c.PHAMVI,
                GHICHU = c.GHICHU,
                HANMUC = c.HANMUC,

                ckhd = (c.ck != null) ? (double)c.ck : 0,

            }).ToList();
            var datafinal = data1.Where(n => !datalist.Contains(n.MACTKM)).ToList().Concat(data.ToList()).ToList();
            foreach (var i in datafinal)
            {
                i.PHAMVICOUNT = i.PHAMVI.Split(',').ToList().Count + " CHI NHÁNH";
                i.MAHHCOUNT = ((i.MAHH != null) ? i.MAHH.Split(',').ToList().Count : 0) + " SẢN PHẨM";
            }
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "chitietkhuyenmai.xlsx";
            //try
            //{
            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet =
                workbook.Worksheets.Add("CHITIET");
                worksheet.Cell(1, 1).Value = "MÃ CT";
                worksheet.Cell(1, 2).Value = "TÊN CHƯƠNG TRÌNH BÁN HÀNG";
                worksheet.Cell(1, 3).Value = "BIÊN BẢN THỎA THUẬN";
                worksheet.Cell(1, 4).Value = "PHẠM VI ÁP DỤNG";
                worksheet.Cell(1, 5).Value = "PHẠM VI ÁP DỤNG CHI TIẾT";
                worksheet.Cell(1, 6).Value = "TỪ NGÀY";
                worksheet.Cell(1, 7).Value = "ĐẾN NGÀY";
                worksheet.Cell(1, 8).Value = "SẢN PHẨM";
                worksheet.Cell(1, 9).Value = "SẢN PHẨM CHI TIẾT";
                worksheet.Cell(1, 10).Value = "CHIẾT KHẤU (%)";
                worksheet.Cell(1, 11).Value = "HẠN MỨC THÀNH TIỀN";
                worksheet.Cell(1, 12).Value = "GHI CHÚ";
                worksheet.Cell(1, 13).Value = "DOANH SỐ TỪ (VNĐ)";
                worksheet.Cell(1, 14).Value = "DOANH SỐ ĐẾN (VNĐ)";
                worksheet.Cell(1, 15).Value = "TỈ LỆ CHIẾT KHẤU %";
                for (int index = 1; index <= datafinal.Count; index++)
                {
                    worksheet.Cell(index + 1, 1).Value = datafinal[index - 1].MACTKM;
                    worksheet.Cell(index + 1, 2).Value = datafinal[index - 1].TENCTKM;
                    worksheet.Cell(index + 1, 3).Value = datafinal[index - 1].BBTT;
                    worksheet.Cell(index + 1, 4).Value = datafinal[index - 1].PHAMVICOUNT;
                    worksheet.Cell(index + 1, 5).Value = datafinal[index - 1].PHAMVI;
                    worksheet.Cell(index + 1, 6).Value = ((DateTime)(datafinal[index - 1].ngaybatdau)).ToString("dd/MM/yyyy");
                    worksheet.Cell(index + 1, 7).Value = ((DateTime)(datafinal[index - 1].ngayketthuc)).ToString("dd/MM/yyyy");
                    worksheet.Cell(index + 1, 8).Value = datafinal[index - 1].MAHHCOUNT;
                    worksheet.Cell(index + 1, 9).Value = datafinal[index - 1].MAHH;
                    worksheet.Cell(index + 1, 10).Value = datafinal[index - 1].ckhd;
                    worksheet.Cell(index + 1, 11).Value = datafinal[index - 1].HANMUC;
                    worksheet.Cell(index + 1, 12).Value = datafinal[index - 1].GHICHU;
                    worksheet.Cell(index + 1, 13).Value = datafinal[index - 1].DSDEN;
                    worksheet.Cell(index + 1, 14).Value = datafinal[index - 1].DSTU;
                    worksheet.Cell(index + 1, 15).Value = datafinal[index - 1].ck;
                }
                //required using System.IO;
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, contentType, fileName);
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    return Content("<script type='text/javascript'>alert('Không có dữ liệu'); window.close();</script>");
            //}
        }
        [Authorize(Roles = "KHUYENMAI")]
        [ActionName("tai-chi-tiet-ho-tro")]
        public ActionResult Taichitiethotro()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var data = (from p in DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO_CHITIET
                        join c in DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO on p.MACTHT equals c.MACTHT
                        select new DATA_DANHMUCHT_CHITIET
                        {
                            MACTHT = p.MACTHT,
                            TENCTHT = c.TENCTHT,
                            // = (c.BBTT == true) ? "CÓ" : "KHÔNG",
                            ngaybatdau = c.ngaybatdau,
                            ngayketthuc = c.ngayketthuc,
                            MAHH = c.MAHH,
                            PHAMVI = c.PHAMVI,
                            GHICHU = c.GHICHU,
                            HANMUC = c.HANMUC,

                            MACTKM = c.MACTKM,
                            DSTU = p.DSTU,
                            DSDEN = p.DSDEN,
                            ck = p.ck
                        }).ToList();
            var datalist = data.Select(cl => cl.MACTHT).Distinct().ToList();
            var data1 = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.Select(c => new DATA_DANHMUCHT_CHITIET
            {
                MACTHT = c.MACTHT,
                TENCTHT = c.MACTHT,

                ngaybatdau = c.ngaybatdau,
                ngayketthuc = c.ngayketthuc,
                MAHH = c.MAHH,
                PHAMVI = c.PHAMVI,
                GHICHU = c.GHICHU,
                HANMUC = c.HANMUC,
                MACTKM = c.MACTKM,


            }).ToList();
            var datafinal = data1.Where(n => !datalist.Contains(n.MACTHT)).ToList().Concat(data.ToList()).ToList();
            foreach (var i in datafinal)
            {
                i.PHAMVICOUNT = i.PHAMVI.Split(',').ToList().Count + " CHI NHÁNH";
                i.MAHHCOUNT = ((i.MAHH != null) ? i.MAHH.Split(',').ToList().Count : 0) + " SẢN PHẨM";
            }
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "chitiethotro.xlsx";
            //try
            //{
            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet =
                workbook.Worksheets.Add("CHITIET");
                worksheet.Cell(1, 1).Value = "MÃ CT";
                worksheet.Cell(1, 2).Value = "TÊN CHƯƠNG TRÌNH HỖ TRỢ";
                worksheet.Cell(1, 3).Value = "MÃ CTKM";
                worksheet.Cell(1, 4).Value = "PHẠM VI ÁP DỤNG";
                worksheet.Cell(1, 5).Value = "PHẠM VI ÁP DỤNG CHI TIẾT";
                worksheet.Cell(1, 6).Value = "TỪ NGÀY";
                worksheet.Cell(1, 7).Value = "ĐẾN NGÀY";
                worksheet.Cell(1, 8).Value = "SẢN PHẨM";
                worksheet.Cell(1, 9).Value = "SẢN PHẨM CHI TIẾT";

                worksheet.Cell(1, 10).Value = "HẠN MỨC THÀNH TIỀN";
                worksheet.Cell(1, 11).Value = "GHI CHÚ";
                worksheet.Cell(1, 12).Value = "DOANH SỐ TỪ (VNĐ)";
                worksheet.Cell(1, 13).Value = "DOANH SỐ ĐẾN (VNĐ)";
                worksheet.Cell(1, 14).Value = "TỈ LỆ CHIẾT KHẤU %";
                for (int index = 1; index <= datafinal.Count; index++)
                {
                    worksheet.Cell(index + 1, 1).Value = datafinal[index - 1].MACTHT;
                    worksheet.Cell(index + 1, 2).Value = datafinal[index - 1].TENCTHT;
                    worksheet.Cell(index + 1, 3).Value = datafinal[index - 1].MACTKM;
                    worksheet.Cell(index + 1, 4).Value = datafinal[index - 1].PHAMVICOUNT;
                    worksheet.Cell(index + 1, 5).Value = datafinal[index - 1].PHAMVI;
                    worksheet.Cell(index + 1, 6).Value = ((DateTime)(datafinal[index - 1].ngaybatdau)).ToString("dd/MM/yyyy");
                    worksheet.Cell(index + 1, 7).Value = ((DateTime)(datafinal[index - 1].ngayketthuc)).ToString("dd/MM/yyyy");
                    worksheet.Cell(index + 1, 8).Value = datafinal[index - 1].MAHHCOUNT;
                    worksheet.Cell(index + 1, 9).Value = datafinal[index - 1].MAHH;

                    worksheet.Cell(index + 1, 10).Value = datafinal[index - 1].HANMUC;
                    worksheet.Cell(index + 1, 11).Value = datafinal[index - 1].GHICHU;
                    worksheet.Cell(index + 1, 12).Value = datafinal[index - 1].DSDEN;
                    worksheet.Cell(index + 1, 13).Value = datafinal[index - 1].DSTU;
                    worksheet.Cell(index + 1, 14).Value = datafinal[index - 1].ck;
                }
                //required using System.IO;
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, contentType, fileName);
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    return Content("<script type='text/javascript'>alert('Không có dữ liệu'); window.close();</script>");
            //}
        }
        [Authorize(Roles = "KHUYENMAI")]
        [ActionName("quan-ly-chuong-trinh-ho-tro")]
        public ActionResult QuanlyCTHT()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var data = new QuanlyCTBH { CHINHANH = db2.TBL_DANHSACHCHINHANH.Where(n => n.check == true).OrderBy(n => n.Mien).ThenByDescending(n => n.stt).ToList(), HANGHOA = SC.Database.SqlQuery<ListHangHoa>("SELECT MAHH,TENHH,DVT,GIABAN FROM TBL_DANHMUCHANGHOA WHERE MAHH IS NOT NULL AND MAHH != '' AND MAHH != '..' AND nhom IN ('35','50', '51', '60', '61', '62', '63','64','64.PME','64.STA', '70','99','40','50.STA','51.STA','60.STA','62.STA')").ToList(), KHUYENMAI = DATATH1.TBL_DANHMUCKM.ToList() };
            return View("QuanlyCTHT", data);
        }
        [ActionName("chuong-trinh-ban-hang")]
        public ActionResult CTBH()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var data = new CTBH();
            var macn = GetCRM().macn.Split(',').ToList();
            var dmkm = DATATH1.TBL_DANHMUCKM.Where(n => n.ngayketthuc >= DateTime.Today && n.ngaybatdau <= DateTime.Today).OrderByDescending(n => n.ngayketthuc).ThenBy(n => n.MACTKM).ToList().Select(cl => new DANHMUCKHUYENMAI { MACTKM = cl.MACTKM, TENCTKM = cl.TENCTKM, ngaybatdau = (DateTime)cl.ngaybatdau, ngayketthuc = (DateTime)cl.ngayketthuc, PHAMVI = cl.PHAMVI.Split(',').ToList(), FILEDATA = (cl.FILEDATA != null) ? true : false }).ToList();
            var dmht = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.Where(n => n.ngayketthuc >= DateTime.Today && n.ngaybatdau <= DateTime.Today).OrderByDescending(n => n.ngayketthuc).ThenBy(n => n.MACTKM).ToList().Select(cl => new DANHMUCKHUYENMAI { MACTKM = cl.MACTHT, TENCTKM = cl.TENCTHT, ngaybatdau = (DateTime)cl.ngaybatdau, ngayketthuc = (DateTime)cl.ngayketthuc, PHAMVI = cl.PHAMVI.Split(',').ToList(), FILEDATA = (cl.FILEDATA != null) ? true : false }).ToList();
            data.ctkm = dmkm.Where(n => n.PHAMVI.Where(cl => macn.Contains(cl)).Count() != 0).ToList();
            data.ctht = dmht.Where(n => n.PHAMVI.Where(cl => macn.Contains(cl)).Count() != 0).ToList();
            return View("CTBH", data);
        }
        [ActionName("chuong-trinh-khuyen-mai-chi-nhanh")]
        public ActionResult Chuongtrinhkmcn()
        {
            var Info = GetInfo();
            var Infocrm = Info.TBL_PHANQUYENCRM;
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var Data = DATATAO(Infocrm.macn, Infocrm.matdv);
            return View("Chuongtrinhkmcn", Data.ListCTKM);
        }
        [ActionName("danh-sach-don-dat-hang")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Danhsachdonhang(string tungay, string denngay)
        {
            var Info = GetInfo();
            var Infocrm = GetCRM();
            ViewBag.dathang = Info.dathang;
            DateTime dt1 = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(tungay), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(denngay), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1);
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var MATDV = Infocrm.matdv;
            var MACH = Infocrm.macn;
            ViewBag.MACH = MACH;
            var Data = DATA(MACH, MATDV, dt1, dt2);
            ViewBag.TDV = MATDV;
            var THKM = DATATH1.TBL_DANHMUCKM.Where(n => n.ngayketthuc >= DateTime.Today).Select(cl => new ListChuongTrinhKM { MACTKM = cl.MACTKM, TICHDIEM = cl.TICHDIEM, TENCTKM = cl.TENCTKM, MAHH = cl.MAHH, ck = cl.ck }).ToList();
            Data.ListCTKM = THKM.Concat(Data.ListCTKM.Where(n => !THKM.Select(cl => cl.MACTKM).ToList().Contains(n.MACTKM))).ToList();

            Data.ListDDH = Data.ListDDH.OrderByDescending(n => n.MADH).ToList();
            Data.ListCTHT = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.Where(n => n.ngayketthuc >= DateTime.Today).Select(cl => new ListChuongTrinhHT { MACTHT = cl.MACTHT, TENCTHT = cl.TENCTHT, MAHH = cl.MAHH, TICHDIEM = cl.TICHDIEM }).ToList();
            ViewBag.tungay = tungay;
            ViewBag.denngay = denngay;
            return View("Danhsachdonhang", Data);
        }
        [ActionName("quan-ly-don-dat-hang")]
        public ActionResult Quanlydonhang()
        {
            var Info = GetInfo();
            var Infocrm = GetCRM();
            if (Info.dathang == 0 || Info.dathang == 2)
            {
                ViewBag.dathang = Info.dathang;
                ViewBag.ten = Info.hoten;
                ViewBag.quyen = Info.quyen;
                var donvi = new List<TBL_DANHSACHCHINHANH>();
                if (Infocrm.macn == "ALL")
                {
                    donvi = db2.TBL_DANHSACHCHINHANH.Where(n => n.check == true).ToList();
                }
                else
                {
                    var taphop = Infocrm.macn.Split(',').ToList();
                    donvi = db2.TBL_DANHSACHCHINHANH.Where(n => taphop.Contains(n.macn)).ToList();
                }
                ViewBag.mientrung = donvi.Where(n => n.Mien == "MIỀN TRUNG").OrderBy(n => n.stt);
                ViewBag.miennam = donvi.Where(n => n.Mien == "MIỀN NAM").OrderBy(n => n.stt);
                ViewBag.mienbac = donvi.Where(n => n.Mien == "MIỀN BẮC").OrderBy(n => n.stt);
                return View("Quanlydonhang", new List<DTA_DONDATHANG>());
            }
            else
            {
                return RedirectToAction("bao-cao-bsc", "Home");
            }
        }
        [ActionName("theo-doi-duong-di")]
        public ActionResult Theodoiduongdi()
        {
            var Info = GetInfo();
            var Infocrm = Info.TBL_PHANQUYENCRM;
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            return View("Theodoiduongdi");
        }
        [Authorize(Roles = "GIAOHANG,QUANLY")]
        [ActionName("lay-don-hang")]
        public ActionResult Laydonhang()
        {
            var Info = GetInfo();
            var Infocrm = Info.TBL_PHANQUYENCRM;
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            List<string> matdv = null;
            if (Info.matdv != "ALL")
            {
                matdv = Info.matdv.Split(',').ToList();
            }
            var data = new LOCLAYDONHANG();
            if (queryCN.SingleOrDefault(n => n.macn == Info.macn) != null)
            {
                data.khuvuc = DULIEUKHUVUC(queryCN.SingleOrDefault(n => n.macn == Info.macn).data);
                if (Info.matinh != "ALL")
                {
                    var taphop = Info.matinh.Split(',').ToList();
                    data.khuvuc = data.khuvuc.Where(n => taphop.Contains(n.matinh)).ToList();
                }
                data.matdv = DULIEUTRINHDUOCVIENLOC(queryCN.SingleOrDefault(n => n.macn == Info.macn).data, matdv).ToList();
                data.makh = GetMAKH(Info.macn, Info, null, null, null);
            }
            //data.nguoigiaohang = db2.TBL_DANHMUCNGUOIDUNG.Where(n => n.macn == Info.macn && n.quyen == "GIAOHANG").ToList();
            return View("Laydonhang", data);
        }
        [Authorize(Roles = "QLGIAOHANG,QUANLY")]
        [ActionName("phan-don-hang")]
        public ActionResult Phandonhang()
        {
            var Info = GetInfo();
            var Infocrm = Info.TBL_PHANQUYENCRM;
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            //List<string> matdv = null;
            //if (Info.matdv != "ALL")
            //{
            //    matdv = Info.matdv.Split(',').ToList();
            //}

            var data = new LOCLAYDONHANG();
            if (queryCN.SingleOrDefault(n => n.macn == Info.macn) != null)
            {

                data.khuvuc = DULIEUKHUVUC(queryCN.SingleOrDefault(n => n.macn == Info.macn).data);
                if (Info.matinh != "ALL")
                {
                    var taphop = Info.matinh.Split(',').ToList();
                    data.khuvuc = data.khuvuc.Where(n => taphop.Contains(n.matinh)).ToList();
                }
                data.matdv = DULIEUTRINHDUOCVIENLOC(queryCN.SingleOrDefault(n => n.macn == Info.macn).data, null).ToList();
                data.makh = GetMAKH(Info.macn, Info, null, null, null);
            }
            data.nguoigiaohang = db2.TBL_DANHMUCNGUOIDUNG.Where(n => n.macn == Info.macn && n.quyen == "GIAOHANG").ToList();
            return View("Phandonhang", data);
        }

        public List<DULIEUBAOCAO> DATABAOCAODH(List<string> soso, DateTime tungay, DateTime denngay, List<string> matinh, List<string> matdv, List<string> makh)
        {
            var DATAX = new List<DULIEUBAOCAO>();
            //String CN
            string strcn = "seleCT SUM((ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)  -  ROUND(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CT.TYLECK/100,0) ) *HOADON.THUESUAT/100) AS tienvat,HOADON.SoHD,HOADON.SOHD_DT,SUM(round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CAST(TYLECK AS MONEY)/100,0)) AS TIENCK,HOADON.MaTDV AS MATDV ,TBL_DANHMUCTDV.TenTDV AS TENTDV,HOADON.ngaylaphd AS NGAY, HOADON.MaPL,TBL_MIEN.mien AS MIEN,TBL_DANHMUCTIEUDEBAOCAO.tendvbc AS TENDVBC,TBL_DANHMUCKHACHHANG.diachi AS DIACHI,TBL_DANHMUCKHACHHANG.matinh AS MATINH,CT.MAKM AS MAKM,CT.MACTHT AS MACTHT,CT.mahh AS MAHH,CT.tenhh AS TENHH, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, SUM(CAST(CT.SOLUONG AS MONEY)) AS SOLUONG, CAST(CT.DonGia AS MONEY) AS DONGIA, CT.DVT, TBL_DANHMUCHANGHOA.nhom AS NHOM, ROUND(CAST(CT.SOLUONG AS MONEY) * (CAST(CT.DONGIA AS MONEY)), 0) AS TIEN from TBL_MIEN, TBL_DANHMUCTIEUDEBAOCAO, DTA_CT_HOADON_XUAT CT LEFT JOIN   TBL_DANHMUCHANGHOA ON CT.mahh = TBL_DANHMUCHANGHOA.mahh, DTA_HOADON_XUAT HOADON   LEFT JOIN   TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh LEFT JOIN TBL_DANHMUCTDV on HOADON.matdv = TBL_DANHMUCTDV.MaTDV where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1";
            //String CH
            string strch = "Select SUM((ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)  -  ROUND(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CT.TYLECK/100,0) ) *HOADON.THUESUAT/100) AS tienvat,HOADON.SoHD,HOADON.SOHD_DT,SUM(round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CAST(TYLECK AS MONEY)/100,0)) AS TIENCK,TBL_DANHMUCKHACHHANG.MATDV AS MATDV,DS_TDV_PTTT.TenTDV AS TENTDV,HOADON.ngaylaphd AS NGAY, HOADON.MaPL, TBL_MIEN.mien AS MIEN, TBL_DANHMUCTIEUDEBAOCAO.tendvbc AS TENDVBC,TBL_DANHMUCKHACHHANG.diachi AS DIACHI, TBL_DANHMUCKHACHHANG.matinh AS MATINH,CT.MAKM AS MAKM , CT.mahh AS MAHH, CT.tenhh AS TENHH, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, SUM(CAST(CT.SOLUONG AS MONEY)) AS SOLUONG, CAST(CT.DonGia AS MONEY) AS DONGIA , CT.DVT ,DM_HANGHOA.nhom AS NHOM , ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0) AS TIEN from TBL_MIEN,tieude TBL_DANHMUCTIEUDEBAOCAO, CT_HOADON_XUAT CT  LEFT JOIN  DM_HANGHOA ON CT.mahh = DM_HANGHOA.mahh, DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG right join HOADON_XUAT  HOADON on TBL_DANHMUCKHACHHANG.makh = HOADON.makh left join DS_TDV_PTTT on TBL_DANHMUCKHACHHANG.MaTDV = DS_TDV_PTTT.MaTDV  where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1 ";
            //String MB
            string strnew = "select SUM(ISNULL(CAST(TIENCHIETKHAU   AS MONEY ),0)) as TIENCK,CAST(sum((ISNULL(CAST(TIENBAN   AS MONEY ),0) -   ISNULL(CAST(TIENCHIETKHAU   AS MONEY ),0)  )*dtasoluong.tylethue/100 ) as FLOAT) as TIENVAT, (select dbo.TCVN2Unicode(dclDanhSachDonViTinh.TenDonViTinh)) as DVT , SUM(ISNULL(CAST(dtasoluong.SOLUONG AS MONEY),0)) as SOLUONG ,SUM(CAST(TIENBAN   AS MONEY))/SUM(CAST(dtasoluong.SOLUONG AS MONEY)) as DONGIA,substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) AS MAPL , dtaChungTu.ngaychungtu as NGAY, substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) as NHOM ,replace(dclChiTietHangHoa.MaCap, ' ', '') AS MAHH, replace(dclChiTietHangHoa.TENCAP, ' ', '')  AS TENHH, ISNULL(CAST(TIENBAN   AS MONEY), 0)  AS TIEN, TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_MIEN.MIEN, KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh as MATINH,dtaChungTu.SoHoaDon as SOHD, cast(dtaChungTu.KHACHHANGID as varchar) as MAKH, (select dbo.TCVN2Unicode(dclChiTietKhachHang.TENCAP)) as DONVI, KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang FROM dtasoluong, dtaDinhKhoan, dclChiTietHangHoa, dclChiTietKhachHang, dclDanhSachDonViTinh, tbl_danhmuctieudebaocao, tbl_mien , KT_TH.DBO.TBL_DANHMUCKHACHHANG right join TBL_DANHMUCCUAHANG on KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = TBL_DANHMUCCUAHANG.MaCH right join dtaChungTu ON KT_TH.DBO.TBL_DANHMUCKHACHHANG.makh = CAST(dtaChungTu.KhachHangID as varchar) where dtasoluong.dinhkhoanid = dtaDinhKhoan.CapDKID And dclChiTietKhachHang.TaiKhoanID = dtaChungTu.KHACHHANGID And dtaDinhKhoan.chungtuid = dtaChungTu.chungtuid and dtaDinhKhoan.IDTaiKhoanCo = dclChiTietHangHoa.TaiKhoanID and dclDanhSachDonViTinh.DonViTinhID = dclChiTietHangHoa.DonViTinhID and dtasoluong.SOLUONG != 0  And dtaChungTu.KHACHHANGID IN(select dclChiTietKhachHang.TaiKhoanID from dclChiTietKhachHang) AND substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) = '632' AND dtaChungTu.ngaychungtu between  '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "'";
            //if (mapl != null)
            //{
            //    strcn = strcn + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
            //    strch = strch + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
            //    //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            //}
            //if (phanloai != "ALL")
            //{
            //    strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            //    strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            //    strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            //}
            //if (phanloaikhachhang != null)
            //{
            //    strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            //    strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            //    strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang IN ({0})", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
            //}
            //if (loaihd != null)
            //{
            //    strcn = strcn + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
            //    strch = strch + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
            //    strnew = strnew + " AND HOADON.SOHD=DTA_HOADON_XUAT_1.SOHD And HOADON.NGAYLAPHD=DTA_HOADON_XUAT_1.NGAYLAPHD And HOADON.MACH=DTA_HOADON_XUAT_1.MACH " + string.Format("AND tbl_danhmuchopdong.loaihd IN ({0})", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
            //}
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
            //if (nhomhang != null)
            //{
            //    strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            //    strch = strch + string.Format(" AND DM_HANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            //    strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            //}
            //if (sanpham != null)
            //{
            //    strcn = strcn + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
            //    strch = strch + string.Format(" AND CT.mahh IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
            //    strnew = strnew + string.Format(" AND replace(dclChiTietHangHoa.MaCap, ' ', '') IN ({0})", string.Join(",", sanpham.Select(p => "'" + p + "'")));
            //}
            //if (quanhuyen != null)
            //{
            //    strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
            //    strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.quanhuyen IN ({0})", string.Join(",", quanhuyen.Select(p => "'" + p + "'")));
            //}
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
            //if (makm != null)
            //{
            //    strcn = strcn + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
            //    strch = strch + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", makm.Select(p => "'" + p + "'")));
            //}
            //if (mactht != null)
            //{

            //    strcn = strcn + string.Format(" AND CT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));
            //    strch = strch + string.Format(" AND CT.MACTHT IN ({0})", string.Join(",", mactht.Select(p => "'" + p + "'")));

            //}
            //String MB
            strcn = strcn + " GROUP BY TBL_DANHMUCTDV.TenTDV,HOADON.SOHD,HOADON.SOHD_DT,CT.MAKM,TBL_DANHMUCKHACHHANG.diachi,CT.MACTHT,HOADON.MATDV,HOADON.ngaylaphd, HOADON.MaPL, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, CT.tenhh, TBL_DANHMUCKHACHHANG.phanloai, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, CAST(CT.SOLUONG AS MONEY), CT.DonGia, CT.DVT, TBL_DANHMUCHANGHOA.nhom, ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)";
            strnew = strnew + "group by  dclChiTietKhachHang.TENCAP, dclChiTietKhachHang.TaiKhoanID,dtaChungTu.SoHoaDon,dtasoluong.TienBan, dclDanhSachDonViTinh.TenDonViTinh, dtasoluong.SOLUONG, dtasoluong.GIAban, dtaDinhKhoan.TaiKhoanNo, dtaChungTu.ngaychungtu, dclChiTietHangHoa.MaCap, dclChiTietHangHoa.TENCAP, tbl_danhmuctieudebaocao.tendvbc, tbl_mien.mien, dtaChungTu.khachhangid, TBL_DANHMUCCUAHANG.MACH ,KT_TH.DBO.TBL_DANHMUCKHACHHANG.matinh , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai , KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloaikhachhang";
            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    var enti = queryCN.SingleOrDefault(n => n.macn == x).data;
                    DATAX.AddRange(BAOCAOCHINHANHHD(enti, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
            }
            return DATAX;
        }
        public List<DULIEUBAOCAO> BAOCAOCUAHANGHD(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO> BAOCAOCHINHANHHD(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO>(str).ToList();
            return All;
        }
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
        [Authorize(Roles = "GIAOHANG,QUANLY")]
        [ActionName("trang-thai-don-hang")]
        public ActionResult Trangthaidonhang()
        {
            var Info = GetInfo();
            var Infocrm = Info.TBL_PHANQUYENCRM;
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            List<string> matdv = null;
            if (Info.matdv != "ALL")
            {
                matdv = Info.matdv.Split(',').ToList();
            }
            var data = new LOCLAYDONHANG();
            if (queryCN.SingleOrDefault(n => n.macn == Info.macn) != null)
            {
                data.khuvuc = DULIEUKHUVUC(queryCN.SingleOrDefault(n => n.macn == Info.macn).data);
                if (Info.matinh != "ALL")
                {
                    var taphop = Info.matinh.Split(',').ToList();
                    data.khuvuc = data.khuvuc.Where(n => taphop.Contains(n.matinh)).ToList();
                }
                data.matdv = DULIEUTRINHDUOCVIENLOC(queryCN.SingleOrDefault(n => n.macn == Info.macn).data, matdv).ToList();
                data.makh = GetMAKH(Info.macn, Info, null, null, null);
            }
            return View("Trangthaidonhang", data);
        }
        [Authorize(Roles = "QLGIAOHANG,QUANLY")]
        [ActionName("quan-ly-don-hang-da-giao")]
        public ActionResult Quanlydonhangdagiao()
        {

            var Info = GetInfo();
            var Infocrm = Info.TBL_PHANQUYENCRM;
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            List<string> matdv = null;
            if (Info.matdv != "ALL")
            {
                matdv = Info.matdv.Split(',').ToList();
            }

            var data = new LOCLAYDONHANG();
            if (queryCN.SingleOrDefault(n => n.macn == Info.macn) != null)
            {
                data.khuvuc = DULIEUKHUVUC(queryCN.SingleOrDefault(n => n.macn == Info.macn).data);
                if (Info.matinh != "ALL")
                {
                    var taphop = Info.matinh.Split(',').ToList();
                    data.khuvuc = data.khuvuc.Where(n => taphop.Contains(n.matinh)).ToList();
                }
                data.matdv = DULIEUTRINHDUOCVIENLOC(queryCN.SingleOrDefault(n => n.macn == Info.macn).data, matdv).ToList();
                data.makh = GetMAKH(Info.macn, Info, null, null, null);
            }
            data.nguoigiaohang = db2.TBL_DANHMUCNGUOIDUNG.Where(n => n.macn == Info.macn && n.quyen == "GIAOHANG").ToList();
            return View("Quanlydonhangdagiao", data);
        }
        [ActionName("vi-tri-khach-hang")]
        public ActionResult Vitrikhachhang()
        {
            var Info = GetInfo();
            var Infocrm = GetCRM();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var donvi = new List<TBL_DANHSACHCHINHANH>();
            if (Infocrm.macn == "ALL")
            {
                donvi = db2.TBL_DANHSACHCHINHANH.Where(n => n.check == true).ToList();
            }
            else
            {
                var taphop = Infocrm.macn.Split(',').ToList();
                donvi = db2.TBL_DANHSACHCHINHANH.Where(n => taphop.Contains(n.macn)).ToList();
            }
            ViewBag.mientrung = donvi.Where(n => n.Mien == "MIỀN TRUNG").OrderBy(n => n.stt);
            ViewBag.miennam = donvi.Where(n => n.Mien == "MIỀN NAM").OrderBy(n => n.stt);
            ViewBag.mienbac = donvi.Where(n => n.Mien == "MIỀN BẮC").OrderBy(n => n.stt);
            return View("Vitrikhachhang");
        }
        [HttpGet]
        public JsonResult GetToado(string makh)
        {
            var tv = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name);
            var z = db2.DTA_TOADOKHACHHANG.SingleOrDefault(n => n.macn == tv.macn && n.makh == makh);
            return Json(z);
        }
        [ActionName("thu-thap-vi-tri-khach-hang")]
        public ActionResult Thuthapvitri()
        {
            var Info = GetInfo();
            var Infocrm = GetCRM();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var tv = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name);
            var Data = DATAGETKH(Infocrm.macn, Infocrm.matdv.Split(',').ToList());
            return View("Thuthapvitri", Data);
        }
        [HttpPost]
        public JsonResult PostToado(DTA_TOADOKHACHHANG data)
        {
            try
            {
                var tv = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name);
                var z = db2.DTA_TOADOKHACHHANG.SingleOrDefault(n => n.makh == data.makh && n.macn == tv.macn);
                if (z != null)
                {
                    z.latitude = data.latitude;
                    z.longitude = data.longitude;
                    z.lastupdate = DateTime.Now;
                    z.usernhap = User.Identity.Name;
                    z.tenkh = data.tenkh;
                }
                else
                {
                    db2.DTA_TOADOKHACHHANG.Add(new DTA_TOADOKHACHHANG() { macn = tv.macn, makh = data.makh, latitude = data.latitude, lastupdate = DateTime.Now, longitude = data.longitude, usernhap = User.Identity.Name, tenkh = data.tenkh });
                }
                db2.SaveChanges();
                return Json(1);
            }
            catch (Exception)
            {

                return Json(0);
            }
        }
        [HttpPost]
        public ActionResult PartialTracuukhachhang(string macn, string makh, string tungay, string denngay)
        {
            var data = new datatracuukhachhang { thongtinkhachhang = Getthongtinkhachhang(macn, makh), thongtinbbtt = Getthongtinbbtt(macn, makh) };
            var x = DATABAOCAO(macn, tungay, denngay, makh, null).GroupBy(n => n.MAHH).Select(n => new DATATRACUUKHACHHANG { MAHH = n.Key, DVT = n.First().DVT, NGAY = n.OrderByDescending(cl => cl.NGAY).First().NGAY, SOLUONG = n.Sum(cl => cl.SOLUONG), TENHH = n.First().TENHH }).ToList();
            var listkm = DATATH1.TBL_DANHMUCKM.Where(n => n.ngaybatdau <= DateTime.Today && n.ngayketthuc >= DateTime.Today).ToList().Where(n => n.PHAMVI.Split(',').Contains(macn)).Select(cl => new TBL_DANHMUCKM { MACTKM = cl.MACTKM, MAHH = cl.MAHH });
            var listht = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.Where(n => n.ngaybatdau <= DateTime.Today && n.ngayketthuc >= DateTime.Today).ToList().Where(n => n.PHAMVI.Split(',').Contains(macn)).Select(cl => new TBL_DANHMUCKM { MACTKM = cl.MACTHT, MAHH = cl.MAHH });
            var listkmht = listkm.Concat(listht).Where(n => n.MACTKM.Substring(0, 4) != "BBTT");
            foreach (var i in x)
            {
                i.MAKM = listkmht.Where(n => n.MAHH != null).Where(n => n.MAHH.Split(',').ToList().Contains(i.MAHH)).Select(cl => cl.MACTKM).ToList();
                i.MAKM.AddRange(listkmht.Where(n => n.MAHH == null).Select(n => n.MACTKM));
            }
            if (data.thongtinbbtt != null)
            {
                data.thongtinbbtt.Doanhso = DATABAOCAO(macn, "01/01/" + DateTime.Today.Year, "31/12/" + DateTime.Today.Year, makh, data.thongtinbbtt.LoaiBBTT).Sum(n => n.TIEN);
            }
            data.listdata = x;
            return PartialView(data);
        }
        [HttpPost]
        public ActionResult PartialTimkiemkhachhang(List<string> macn)
        {
            //
            var Info = GetInfo();
            var listpl = Info.phanloai.Split(',').ToList();
            string strcn = "SELECT makh AS MAKH, ngaysinh AS NGAYSINH,masothue as masothue, donvi AS DONVI, diachi as DIACHI,macn,tennguoigd,dt as DT,phanloai,phanloaikhachhang FROM TBL_DANHMUCKHACHHANG";
            string strch = "SELECT  makh AS MAKH, ngaysinh AS NGAYSINH,MaThue as masothue, donvi AS DONVI, diachi as DIACHI,macn,TENNGUOIGD as tennguoigd,dt as DT,PHANLOAI as phanloai,phanloaikhachhang FROM DM_KHACHHANG_PTTT";
            if (Info.matinh != "ALL")
            {
                var listmt = Info.matinh.Split(',').ToList();
                strcn = strcn + string.Format(" AND matinh IN ({0})", string.Join(",", listmt.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND MaTinh IN ({0})", string.Join(",", listmt.Select(p => "'" + p + "'")));
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
            foreach (var i in macn)
            {
                if (queryCN.SingleOrDefault(n => n.macn == i) != null)
                {
                    if (i == "TT423")
                    {
                        data.AddRange(DULIEUKHACHHANG(queryCN.SingleOrDefault(n => n.macn == i).data, strcn.Replace(" ngaysinh AS NGAYSINH", " TRY_CONVERT(datetime, sinhngay, 103) AS NGAYSINH ")).ToList());

                    }
                    else
                    {
                        data.AddRange(DULIEUKHACHHANG(queryCN.SingleOrDefault(n => n.macn == i).data, strcn).ToList());
                    }

                }
                else if (queryCH.SingleOrDefault(n => n.macn == i) != null)
                {
                    data.AddRange(DULIEUCUAHANGKHACHHANG(queryCH.SingleOrDefault(n => n.macn == i).data, strch).ToList());
                }
            }
            //

            return PartialView(data);
        }
        [Authorize(Roles = "GIAOHANG,QUANLY")]
        [HttpPost]
        public ActionResult GetPartialLaydonhang(string tungay, string denngay, List<string> makh, List<string> matinh, List<string> matdv)
        {
            var info = GetInfo();
            DateTime tungay1 = DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime denngay1 = DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (info.matinh != "ALL")
            {
                matinh = (matinh != null && info.matinh.Split(',').Intersect(matinh).ToList().Count() > 0) ? info.matinh.Split(',').Intersect(matinh).ToList() : info.matinh.Split(',').ToList();
            }
            if (info.matdv != "ALL" && matdv == null)
            {

                matdv = info.matdv.Split(',').ToList();

            }
            var data = DATABAOCAODH(new List<string> { info.macn }, tungay1, denngay1, matinh, matdv, makh);
            var dacheck = new List<string>();
            if (matdv != null)
            {
                dacheck = db2.DTA_GIAOHANG.Where(n => n.macn == info.macn && n.ngayhoadon >= tungay1 && n.ngayhoadon <= denngay1 && matdv.Contains(n.matdv)).Select(n => n.sohd).ToList();
            }
            else
            {
                dacheck = db2.DTA_GIAOHANG.Where(n => n.macn == info.macn && n.ngayhoadon >= tungay1 && n.ngayhoadon <= denngay1).Select(n => n.sohd).ToList();
            }
            var x = data.GroupBy(n => n.SOHD).Select(cl => new DATALAYDONHANG() { SOHD = cl.Key, SOHD_DT = cl.First().SOHD_DT, DONVI = cl.First().DONVI, MAKH = cl.First().MAKH, DIACHI = cl.First().DIACHI, MATDV = cl.First().MATDV, NGAYLAPHD = cl.First().NGAY, TONGTIEN_CT_HOADON = (double)cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)), tendvbc = info.macn }).OrderByDescending(n => n.NGAYLAPHD).ThenByDescending(n => n.SOHD).ToList();
            foreach (var i in x)
            {
                if (dacheck.Contains(i.SOHD))
                {
                    i.check = true;
                }
            }
            return PartialView(x);
        }
        [Authorize(Roles = "QLGIAOHANG,QUANLY")]
        [HttpPost]
        public ActionResult GetPartialPhandonhang(string tungay, string denngay, List<string> makh, List<string> matinh, List<string> matdv)
        {
            var info = GetInfo();
            DateTime tungay1 = DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime denngay1 = DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (info.matinh != "ALL")
            {
                matinh = (matinh != null && info.matinh.Split(',').Intersect(matinh).ToList().Count() > 0) ? info.matinh.Split(',').Intersect(matinh).ToList() : info.matinh.Split(',').ToList();
            }
            if (info.matdv != "ALL" && matdv == null)
            {

                matdv = info.matdv.Split(',').ToList();

            }
            var data = DATABAOCAODH(new List<string> { info.macn }, tungay1, denngay1, matinh, matdv, makh);
            var dacheck = new List<string>();
            if (matdv != null)
            {
                dacheck = db2.DTA_GIAOHANG.Where(n => n.macn == info.macn && n.ngayhoadon >= tungay1 && n.ngayhoadon <= denngay1 && matdv.Contains(n.matdv)).Select(n => n.sohd).ToList();
            }
            else
            {
                dacheck = db2.DTA_GIAOHANG.Where(n => n.macn == info.macn && n.ngayhoadon >= tungay1 && n.ngayhoadon <= denngay1).Select(n => n.sohd).ToList();
            }
            var x = data.GroupBy(n => n.SOHD).Select(cl => new DATALAYDONHANG() { SOHD = cl.Key, DONVI = cl.First().DONVI, MAKH = cl.First().MAKH, DIACHI = cl.First().DIACHI, MATDV = cl.First().MATDV, NGAYLAPHD = cl.First().NGAY, TONGTIEN_CT_HOADON = (double)cl.Sum(z => Math.Round(z.SOLUONG * z.DONGIA, 0, MidpointRounding.AwayFromZero)), tendvbc = info.macn }).OrderByDescending(n => n.NGAYLAPHD).ThenByDescending(n => n.SOHD).ToList();
            foreach (var i in x)
            {
                if (dacheck.Contains(i.SOHD))
                {
                    i.check = true;
                }
            }
            return PartialView(x);
        }
        [Authorize(Roles = "GIAOHANG,QUANLY")]
        [HttpPost]
        public ActionResult GetPartialTrangthaidonhang(string tungay, string denngay, List<string> makh, List<string> matdv, bool? giaohang, bool? thutien)
        {
            var info = GetInfo();
            DateTime tungay1 = DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime denngay1 = DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var data = new List<DTA_GIAOHANG>();
            var listquyen = info.quyen.Split(',').ToList();
            if (listquyen.Contains("QLGIAOHANG"))
            {
                data = db2.DTA_GIAOHANG.Where(n => n.macn == info.macn && n.ngay >= tungay1 && n.ngay <= denngay1).ToList();
            }
            else
            {
                data = db2.DTA_GIAOHANG.Where(n => n.macn == info.macn && n.taikhoan == User.Identity.Name && n.ngay >= tungay1 && n.ngay <= denngay1).ToList();
            }
            if (matdv != null)
            {
                data = data.Where(n => matdv.Contains(n.matdv)).ToList();
            }
            if (giaohang != null)
            {
                data = data.Where(n => n.giaohang == giaohang).ToList();
            }
            if (thutien != null)
            {
                data = data.Where(n => n.thutien == thutien).ToList();
            }
            return PartialView(data);
        }
        [Authorize(Roles = "QLGIAOHANG,QUANLY")]
        [HttpPost]
        public ActionResult GetPartialQuanlydonhang(string tungay, string denngay, List<string> makh, List<string> matdv, int? giaohang, bool? thutien, List<string> nguoigiaohang)
        {
            var info = GetInfo();
            DateTime tungay1 = DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime denngay1 = DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1);
            var data = new List<DTA_GIAOHANG>();

            data = db2.DTA_GIAOHANG.Where(n => n.macn == info.macn && n.ngay >= tungay1 && n.ngay < denngay1).ToList();

            if (nguoigiaohang.Contains("null"))
            {
                data = data.Where(n => nguoigiaohang.Contains(n.taikhoan)).ToList();
            }
            if (matdv != null)
            {
                data = data.Where(n => matdv.Contains(n.matdv)).ToList();
            }
            if (giaohang == 1)
            {
                data = data.Where(n => n.giaohang == true).ToList();
            }
            else if (giaohang == 0)
            {
                data = data.Where(n => n.giaohang == false).ToList();
            }
            else if (giaohang == null)
            {
                data = data.Where(n => n.giaohang == null).ToList();
            }
            if (thutien != null)
            {
                data = data.Where(n => n.thutien == thutien).ToList();
            }

            return PartialView(data);
        }
        //[HttpPost]
        //public ActionResult GetPartialQuanlydonhang(string tungay, string denngay, List<string> makh, List<string> matdv, bool? giaohang, bool? thutien)
        //{
        //    var info = GetInfo();
        //    DateTime tungay1 = DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //    DateTime denngay1 = DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        //    var data = db2.DTA_GIAOHANG.Where(n => n.macn == info.macn && n.ngay >= tungay1 && n.ngay <= denngay1);
        //    if (matdv != null)
        //    {
        //        data = data.Where(n => matdv.Contains(n.matdv));
        //    }
        //    if (giaohang != null)
        //    {
        //        data = data.Where(n => n.giaohang == giaohang);
        //    }
        //    if (thutien != null)
        //    {
        //        data = data.Where(n => n.thutien == thutien);
        //    }
        //    return PartialView(data);
        //}
        [HttpPost]
        public ActionResult PartialDanhsachkhachhangchoduyet(string macn, string tungay, string denngay, string matdv, string phanloai, string duyet)
        {
            DateTime tungay1 = DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime denngay1 = DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var info = GetInfo();
            var listphanloai = phanloai.Split(',').ToList();
            var data = DATATH1.TBL_DANHMUCKHACHHANG_PENDING.Where(n => n.macn == macn && n.ngayyeucau >= tungay1 && n.ngayyeucau <= denngay1 && listphanloai.Contains(n.phanloai)).OrderByDescending(n => n.ngayyeucau).ToList();
            if (duyet != "ALL")
            {
                var boolduyet = (duyet == "1") ? true : false;
                data = data.Where(n => n.pheduyet == boolduyet).ToList();
            }
            if (info.matdv != "ALL")
            {
                var matdvlist = info.matdv.Split(',').ToList();
                data = data.Where(n => matdv.Contains(n.matdv)).ToList();
            }
            if (info.matinh != "ALL")
            {
                var matinh = info.matinh.Split(',').ToList();
                data = data.Where(n => matinh.Contains(n.matinh)).ToList();
            }
            if (matdv != "ALL")
            {
                data = data.Where(n => n.matdv == matdv).ToList();
            }
            return PartialView(data);
        }
        public List<DATATRACUUKHACHHANG> BAOCAOCHINHANH(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DATATRACUUKHACHHANG>(str).ToList();
            return All;
        }
        public List<DATATRACUUKHACHHANG> DATABAOCAO(string x, string tungay1, string denngay1, string makh, string makm)
        {
            DateTime tungay = DateTime.ParseExact(tungay1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime denngay = DateTime.ParseExact(denngay1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var DATAX = new List<DATATRACUUKHACHHANG>();
            //String CN
            string strcn = "seleCT HOADON.ngaylaphd AS NGAY,CT.MAKM AS MAKM,CT.mahh AS MAHH,CT.tenhh AS TENHH, SUM(CAST(CT.SOLUONG AS MONEY)) AS SOLUONG, CT.DVT, ROUND(CAST(CT.SOLUONG AS MONEY) * (CAST(CT.DONGIA AS MONEY)), 0) AS TIEN from TBL_MIEN, TBL_DANHMUCTIEUDEBAOCAO, DTA_CT_HOADON_XUAT CT LEFT JOIN   TBL_DANHMUCHANGHOA ON CT.mahh = TBL_DANHMUCHANGHOA.mahh, DTA_HOADON_XUAT HOADON   LEFT JOIN   TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh LEFT JOIN TBL_DANHMUCTDV on HOADON.matdv = TBL_DANHMUCTDV.MaTDV  where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1";
            //String CH
            if (makh != null)
            {
                strcn = strcn + " AND HOADON.makh = '" + makh + "' ";
            }
            if (makm != null)
            {
                strcn = strcn + " AND CT.MAKM = '" + makm + "' ";
            }
            //String MB
            strcn = strcn + " GROUP BY CT.MAKM,HOADON.ngaylaphd, CT.mahh, CT.tenhh, CAST(CT.SOLUONG AS MONEY), CT.DVT, ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)";
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                var enti = queryCN.SingleOrDefault(n => n.macn == x).data;
                DATAX.AddRange(BAOCAOCHINHANH(enti, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
            }
            return DATAX;
        }
        private thongtinkhachhang Getthongtinkhachhang(string x, string makh)
        {
            var str = "select makh,donvi,diachi,tennguoigd,matdv,matinh,ngaygdgannhat,dt from TBL_DANHMUCKHACHHANG where  makh = '" + makh + "'";
            var DATAX = new thongtinkhachhang();
            string strch = "SELECT MaKH AS MAKH, DonVi AS DONVI, DiaChi AS DIACHI, ngaygdgannhat AS DONHANGGANHAT , TENNGUOIGD AS TENNGUOILH, dt AS DT from DM_KHACHHANG_PTTT where MaKH='" + makh + "'";
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                DATAX = queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<thongtinkhachhang>(str).First();

            }
            else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
            {
                DATAX = queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<thongtinkhachhang>(strch).First();
            }
            return DATAX;
        }
        private thongtinbbtt Getthongtinbbtt(string x, string makh)
        {
            try
            {
                var str = "select LoaiBBTT,Tong from TBL_DANHMUCBIENBANTHOATHUAN_2 where makh = '" + makh + "' and nam=" + DateTime.Now.Year;
                string strch = "SELECT MaKH AS MAKH, DonVi AS DONVI, DiaChi AS DIACHI, ngaygdgannhat AS DONHANGGANHAT , TENNGUOIGD AS TENNGUOILH, dt AS DT from DM_KHACHHANG_PTTT where MaKH='" + makh + "'";
                var data3 = new List<thongtinbbtt>();
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    if (x == "PY")
                    {
                        data3 = PhuYen.Database.SqlQuery<thongtinbbtt>("SELECT makh AS MAKH, donvi AS DONVI, tennguoigd AS TENNGUOILH, diachi AS DIACHI from TBL_DANHMUCKHACHHANG where makh = '" + makh + "'").ToList();
                    }
                    else
                    {
                        data3 = queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<thongtinbbtt>(str).ToList();
                    }
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    data3 = queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<thongtinbbtt>(strch).ToList();
                }
                if (data3.Count != 0)
                {
                    return data3.First();
                }
                else
                {
                    return new thongtinbbtt();
                }
            }
            catch (Exception)
            {
                return new thongtinbbtt();
            }
        }

        [HttpPost]
        public ActionResult PartialMapkhachhang(string macn, List<string> matdv, List<string> makh)
        {
            var listkh = DATAGETKH(macn, matdv).Select(n => n.MAKH);
            var data = db2.DTA_TOADOKHACHHANG.Where(n => n.macn == macn && listkh.Contains(n.makh)).ToList();
            if (makh != null && !makh.Contains("ALL"))
            {
                data = data.Where(n => makh.Contains(n.makh)).ToList();
            }
            return Json(data);
        }
        public ActionResult Getkhachhang(string x, List<string> matdv)
        {
            string strcn = "";
            string strch = "";

            if (matdv != null)
            {
                strcn = "SELECT makh AS MAKH, donvi AS DONVI from TBL_DANHMUCKHACHHANG" + string.Format(" WHERE (matdv IN ({0}) or matdv = '' or matdv is null) and (tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch')", string.Join(",", matdv.Select(p => "'" + p + "'")));
                strch = "SELECT makh AS MAKH, donvi AS DONVI from DM_KHACHHANG_PTTT" + string.Format(" WHERE (matdv IN ({0}) or matdv = '' or matdv is null) and (tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch')", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            else
            {
                strcn = "SELECT makh AS MAKH, donvi AS DONVI from TBL_DANHMUCKHACHHANG WHERE tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch'";
                strch = "SELECT makh AS MAKH, donvi AS DONVI from DM_KHACHHANG_PTTT WHERE tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch'";
            }
            var DATAX = new List<ListKhachHang>();
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                DATAX = queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
            {
                DATAX = queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<ListKhachHang>(strch).ToList();
            }
            return Json(DATAX);
        }
        public List<ListKhachHang> DATAGETKH(string x, List<string> MATDV)
        {
            string strcn = "";
            string strch = "";

            if (MATDV != null)
            {
                strcn = "SELECT makh AS MAKH, donvi AS DONVI from TBL_DANHMUCKHACHHANG" + string.Format(" WHERE (matdv IN ({0}) or matdv = '' or matdv is null) and (tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch')", string.Join(",", MATDV.Select(p => "'" + p + "'")));
                strch = "SELECT makh AS MAKH, donvi AS DONVI from DM_KHACHHANG_PTTT" + string.Format(" WHERE (matdv IN ({0}) or matdv = '' or matdv is null) and (tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch')", string.Join(",", MATDV.Select(p => "'" + p + "'")));
            }
            else
            {
                strcn = "SELECT makh AS MAKH, donvi AS DONVI from TBL_DANHMUCKHACHHANG WHERE tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch'";
                strch = "SELECT makh AS MAKH, donvi AS DONVI from DM_KHACHHANG_PTTT WHERE tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch'";
            }
            var DATAX = new List<ListKhachHang>();
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {

                DATAX = queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
            {
                DATAX = queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<ListKhachHang>(strch).ToList();
            }
            return DATAX;
        }
        public List<ListKhachHang> GetMAKH(string ChiNhanhId, TBL_DANHMUCNGUOIDUNG Info, List<string> matinh, List<string> matdv, List<string> maquan)
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
            return data.OrderBy(n => n.MAKH).ToList();
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
        public List<ListKhachHang> DATAGETKHETC(string x, List<string> MATDV)
        {
            string strcn = "";
            string strch = "";
            if (MATDV != null)
            {
                strcn = "SELECT makh AS MAKH, donvi AS DONVI from TBL_DANHMUCKHACHHANG" + string.Format(" WHERE phanloai='ETC' and (matdv IN ({0}) or matdv = '' or matdv is null) and (tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch')", string.Join(",", MATDV.Select(p => "'" + p + "'")));
                strch = "SELECT makh AS MAKH, donvi AS DONVI from DM_KHACHHANG_PTTT" + string.Format(" WHERE phanloai='ETC' and (matdv IN ({0}) or matdv = '' or matdv is null) and (tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch')", string.Join(",", MATDV.Select(p => "'" + p + "'")));
            }
            else
            {
                strcn = "SELECT makh AS MAKH, donvi AS DONVI from TBL_DANHMUCKHACHHANG WHERE phanloai='ETC' and tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch'";
                strch = "SELECT makh AS MAKH, donvi AS DONVI from DM_KHACHHANG_PTTT WHERE phanloai='ETC' and tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch'";
            }
            var DATAX = new List<ListKhachHang>();
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {

                DATAX = queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
            {
                DATAX = queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<ListKhachHang>(strch).ToList();
            }
            return DATAX;
        }
        public List<CHECKBBTT> DATAGETBBTT(string x, string makh, string mactkm)
        {
            string strcn = "select LoaiBBTT,makh from TBL_DANHMUCBIENBANTHOATHUAN_2 where makh = '" + makh + "' and '" + mactkm + "' IN (SELECT VAL FROM FUN_CATCHUOI(loaibbtt)) and (thanhly is null or thanhly = 0)";
            var DATAX = new List<CHECKBBTT>();
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {

                DATAX = queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<CHECKBBTT>(strcn).ToList();
            }
            if (queryCH.SingleOrDefault(n => n.macn == x) != null)
            {

                DATAX = queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<CHECKBBTT>(strcn).ToList();
            }
            return DATAX;
        }
        [HttpPost]
        public ActionResult Checkdiemden(string macn, List<string> matdv, string makh)
        {
            var data = db2.DTA_TOADOKHACHHANG.Where(n => n.macn == macn && matdv.Contains(n.usernhap));
            if (makh != null)
            {
                data = data.Where(n => makh.Contains(n.makh));
            }
            return PartialView(data);
        }
        [ActionName("chi-tiet-chuong-trinh-ban-hang")]
        public ActionResult ViewFile(string MACTKM, string MACTHT)
        {
            if (MACTKM != null)
            {
                var tv = DATATH1.TBL_DANHMUCKM.SingleOrDefault(n => n.MACTKM == MACTKM);
                if (tv.FILEDATA != null)
                {
                    return new FileContentResult(tv.FILEDATA, "application/pdf");
                    //return View("/Views/Order/PDFVIEWER.cshtml", new PDFBase64 { Base64 = Convert.ToBase64String(tv.FILEDATA) });
                }
                else
                {
                    return Content("<script type='text/javascript'>alert('Không tìm thấy file cho mã CTBH này'); window.close();</script>");
                }
            }
            else
            {
                var tv = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.SingleOrDefault(n => n.MACTHT == MACTHT);
                if (tv.FILEDATA != null)
                {
                    //return View("/Views/Order/PDFVIEWER.cshtml", new PDFBase64 { Base64 = Convert.ToBase64String(tv.FILEDATA) });
                    return new FileContentResult(tv.FILEDATA, "application/pdf");
                }
                else
                {
                    return Content("<script type='text/javascript'>alert('Không tìm thấy file cho mã CTHT này'); window.close();</script>");
                }
            }
        }

        //[Authorize(Roles = "KHUYENMAI")]
        //[HttpPost]
        //public ActionResult AddFileCTHT(string MACTHT, HttpPostedFileBase postedFile)
        //{
        //    if (postedFile != null)
        //    {
        //        byte[] bytes;
        //        using (BinaryReader br = new BinaryReader(postedFile.InputStream))
        //        {
        //            bytes = br.ReadBytes(postedFile.ContentLength);
        //        }
        //        var tv = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.SingleOrDefault(n => n.MACTHT == MACTHT);
        //        if (tv != null)
        //        {
        //            tv.FILEDATA = bytes;
        //            DATATH1.SaveChanges();
        //        }
        //    }
        //    else
        //    {
        //        var tv = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.SingleOrDefault(n => n.MACTHT == MACTHT);
        //        if (tv != null)
        //        {
        //            tv.FILEDATA = null;
        //            DATATH1.SaveChanges();
        //        }
        //    }
        //    return RedirectToAction("quan-ly-chuong-trinh-ho-tro");
        //}

        [HttpPost]
        public ActionResult checkbbtt(string makh, string mactkm)
        {
            var infocrm = GetCRM();
            var data = DATAGETBBTT(infocrm.macn, makh, mactkm);
            //if(infocrm.macn == "TB" || infocrm.macn == "TNG" || infocrm.macn == "PT")
            //{
            //    return Json(1);
            //}
            //if(mactkm == "BBTT2021_PARTNERSHIP")
            //{
            //    return Json(1);
            //}
            if (data.Any())
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpPost]
        public ActionResult AddCTBH(string tenctkm, string mactkm, string ngaybatdau, string ngayketthuc, string bbtt, List<string> phamvi, List<string> mahh, string hanmuc, List<string> mactht, float? ck, string ghichu)
        {
            bool? bbtt1 = (bbtt == "1") ? true : false;
            decimal? hanmuc1 = null;
            if (hanmuc == "N/A" || hanmuc == "" || hanmuc == null)
            {
                hanmuc1 = null;
            }
            else
            {
                hanmuc1 = decimal.Parse(hanmuc);
            }
            string phamvi1 = null;
            if (phamvi.Contains("null"))
            {
                phamvi1 = null;
            }
            else
            {
                phamvi1 = string.Join(",", phamvi.ToArray());
            }
            string mahh1 = null;

            mahh1 = string.Join(",", mahh.ToArray());

            DATATH1.TBL_DANHMUCKM.Add(new TBL_DANHMUCKM { HANMUC = hanmuc1, ck = ck, MACTKM = mactkm, MAHH = mahh1, ngaybatdau = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngaybatdau), "dd/MM/yyyy", CultureInfo.InvariantCulture), ngayketthuc = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngayketthuc), "dd/MM/yyyy", CultureInfo.InvariantCulture), PHAMVI = phamvi1, BBTT = bbtt1, TENCTKM = tenctkm, GHICHU = ghichu });
            DATATH1.SaveChanges();
            try
            {
                DATATH2.TBL_DANHMUCKM.Add(new TBL_DANHMUCKM { HANMUC = hanmuc1, ck = ck, MACTKM = mactkm, MAHH = mahh1, ngaybatdau = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngaybatdau), "dd/MM/yyyy", CultureInfo.InvariantCulture), ngayketthuc = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngayketthuc), "dd/MM/yyyy", CultureInfo.InvariantCulture), PHAMVI = phamvi1, BBTT = bbtt1, TENCTKM = tenctkm, GHICHU = ghichu });
                DATATH2.SaveChanges();
            }
            catch
            {

            }
            return Json(1);
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpPost]
        public ActionResult AddCTBHCHITIET(List<TBL_DANHMUCKM_CHITIET> data)
        {

            DATATH1.TBL_DANHMUCKM_CHITIET.AddRange(data);
            DATATH1.SaveChanges();
            try
            {

                DATATH2.TBL_DANHMUCKM_CHITIET.AddRange(data);
                DATATH2.SaveChanges();
            }
            catch
            {
            }
            return Json(1);
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpPost]
        public ActionResult DelCTBHCHITIET(string mactkm)
        {
            var tv = DATATH1.TBL_DANHMUCKM_CHITIET.Where(n => n.MACTKM == mactkm);
            DATATH1.TBL_DANHMUCKM_CHITIET.RemoveRange(tv);

            DATATH1.SaveChanges();
            try
            {
                DATATH2.TBL_DANHMUCKM_CHITIET.RemoveRange(tv);

                DATATH2.SaveChanges();
            }
            catch
            {

            }
            return Json(1);
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpPost]
        public ActionResult AddCTHTCHITIET(List<TBL_DANHMUCCHUONGTRINHHOTRO_CHITIET> data)
        {

            DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO_CHITIET.AddRange(data);
            DATATH1.SaveChanges();
            try
            {

                DATATH2.TBL_DANHMUCCHUONGTRINHHOTRO_CHITIET.AddRange(data);
                DATATH2.SaveChanges();
            }
            catch
            {
            }
            return Json(1);
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpPost]
        public ActionResult DelCTHTCHITIET(string mactht)
        {
            var tv = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO_CHITIET.Where(n => n.MACTHT == mactht);
            DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO_CHITIET.RemoveRange(tv);

            DATATH1.SaveChanges();
            try
            {
                DATATH2.TBL_DANHMUCCHUONGTRINHHOTRO_CHITIET.RemoveRange(tv);

                DATATH2.SaveChanges();
            }
            catch
            {

            }
            return Json(1);
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpPost]
        public ActionResult AddCTHT(string tenctht, string mactht, string ngaybatdau, string ngayketthuc, List<string> phamvi, List<string> mahh, string hanmuc, List<string> mactkm, string ghichu)
        {
            decimal? hanmuc1 = null;
            if (hanmuc == "N/A" || hanmuc == "" || hanmuc == null)
            {
                hanmuc1 = null;
            }
            else
            {
                hanmuc1 = decimal.Parse(hanmuc);
            }
            string phamvi1 = null;
            if (phamvi.Contains("null"))
            {
                phamvi1 = null;
            }
            else
            {
                phamvi1 = string.Join(",", phamvi.ToArray());
            }
            string mahh1 = null;
            mahh1 = string.Join(",", mahh.ToArray());
            DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.Add(new TBL_DANHMUCCHUONGTRINHHOTRO { HANMUC = hanmuc1, MACTHT = mactht, MAHH = mahh1, ngaybatdau = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngaybatdau), "dd/MM/yyyy", CultureInfo.InvariantCulture), ngayketthuc = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngayketthuc), "dd/MM/yyyy", CultureInfo.InvariantCulture), PHAMVI = phamvi1, TENCTHT = tenctht, MACTKM = (mactkm != null) ? string.Join(",", mactkm.ToArray()) : null, GHICHU = ghichu });
            DATATH1.SaveChanges();
            try
            {
                DATATH2.TBL_DANHMUCCHUONGTRINHHOTRO.Add(new TBL_DANHMUCCHUONGTRINHHOTRO { HANMUC = hanmuc1, MACTHT = mactht, MAHH = mahh1, ngaybatdau = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngaybatdau), "dd/MM/yyyy", CultureInfo.InvariantCulture), ngayketthuc = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngayketthuc), "dd/MM/yyyy", CultureInfo.InvariantCulture), PHAMVI = phamvi1, TENCTHT = tenctht, MACTKM = (mactkm != null) ? string.Join(",", mactkm.ToArray()) : null, GHICHU = ghichu });
                DATATH2.SaveChanges();
            }
            catch
            {

            }
            return Json(1);
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpPost]
        public ActionResult EditCTBH(string tenctkm, float? ck, string mactkm, string ngaybatdau, string ngayketthuc, string bbtt, List<string> phamvi, List<string> mahh, string hanmuc, List<string> mactht, string ghichu)
        {
            bool? bbtt1 = (bbtt == "1") ? true : false;
            decimal? hanmuc1 = null;
            if (hanmuc == "N/A" || hanmuc == "" || hanmuc == null)
            {
                hanmuc1 = null;
            }
            else
            {
                hanmuc1 = decimal.Parse(hanmuc);
            }
            string phamvi1 = null;
            if (phamvi.Contains("null"))
            {
                phamvi1 = null;
            }
            else
            {
                phamvi1 = string.Join(",", phamvi.ToArray());
            }
            string mahh1 = null;

            mahh1 = string.Join(",", mahh.ToArray());

            var tv = DATATH1.TBL_DANHMUCKM.SingleOrDefault(n => n.MACTKM == mactkm);
            if (tv != null)
            {
                tv.TENCTKM = tenctkm;
                tv.ngaybatdau = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngaybatdau), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                tv.ngayketthuc = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngayketthuc), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                tv.PHAMVI = phamvi1;
                tv.BBTT = bbtt1;
                tv.HANMUC = hanmuc1;
                tv.MAHH = mahh1;
                tv.GHICHU = ghichu;
                tv.ck = ck;
                DATATH1.SaveChanges();
            }
            var tv2 = DATATH2.TBL_DANHMUCKM.SingleOrDefault(n => n.MACTKM == mactkm);
            if (tv2 != null)
            {
                tv2.TENCTKM = tenctkm;
                tv2.ngaybatdau = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngaybatdau), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                tv2.ngayketthuc = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngayketthuc), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                tv2.PHAMVI = phamvi1;
                tv.BBTT = bbtt1;
                tv2.HANMUC = hanmuc1;
                tv2.MAHH = mahh1;
                tv2.GHICHU = ghichu;
                tv2.ck = ck;
                DATATH2.SaveChanges();
            }
            return Json(1);
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpPost]
        public ActionResult EditCTHT(string tenctht, string mactht, string ngaybatdau, string ngayketthuc, List<string> phamvi, List<string> mahh, string hanmuc, List<string> mactkm, string ghichu)
        {
            decimal? hanmuc1 = null;
            if (hanmuc == "N/A" || hanmuc == "" || hanmuc == null)
            {
                hanmuc1 = null;
            }
            else
            {
                hanmuc1 = decimal.Parse(hanmuc);
            }
            string phamvi1 = null;
            if (phamvi.Contains("null"))
            {
                phamvi1 = null;
            }
            else
            {
                phamvi1 = string.Join(",", phamvi.ToArray());
            }
            string mahh1 = null;

            mahh1 = string.Join(",", mahh.ToArray());

            var tv = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.SingleOrDefault(n => n.MACTHT == mactht);
            if (tv != null)
            {
                tv.TENCTHT = tenctht;
                tv.ngaybatdau = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngaybatdau), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                tv.ngayketthuc = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngayketthuc), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                tv.PHAMVI = phamvi1;
                tv.HANMUC = hanmuc1;
                tv.MAHH = mahh1;
                tv.GHICHU = ghichu;
                tv.MACTKM = (mactkm != null) ? string.Join(",", mactkm.ToArray()) : null;
                DATATH1.SaveChanges();
            }
            var tv2 = DATATH2.TBL_DANHMUCCHUONGTRINHHOTRO.SingleOrDefault(n => n.MACTHT == mactht);
            if (tv2 != null)
            {
                tv2.TENCTHT = tenctht;
                tv2.ngaybatdau = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngaybatdau), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                tv2.ngayketthuc = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngayketthuc), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                tv2.PHAMVI = phamvi1;
                tv2.HANMUC = hanmuc1;
                tv2.MAHH = mahh1;
                tv2.GHICHU = ghichu;
                tv2.MACTKM = (mactkm != null) ? string.Join(",", mactkm.ToArray()) : null;
                DATATH2.SaveChanges();
            }
            return Json(1);
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpPost]
        public ActionResult DelCTBH(string mactkm)
        {
            var tv = DATATH1.TBL_DANHMUCKM.SingleOrDefault(n => n.MACTKM == mactkm);
            var tv1 = DATATH1.TBL_DANHMUCKM_CHITIET.Where(n => n.MACTKM == mactkm);
            DATATH1.TBL_DANHMUCKM.Remove(tv);
            DATATH1.TBL_DANHMUCKM_CHITIET.RemoveRange(tv1);
            DATATH1.SaveChanges();
            try
            {
                DATATH2.TBL_DANHMUCKM.Remove(tv);
                DATATH2.TBL_DANHMUCKM_CHITIET.RemoveRange(tv1);
                DATATH2.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return Json(1);
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpPost]
        public ActionResult DelCTHT(string mactht)
        {
            var tv = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.SingleOrDefault(n => n.MACTHT == mactht);
            var tv1 = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO_CHITIET.Where(n => n.MACTHT == mactht);
            DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.Remove(tv);
            DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO_CHITIET.RemoveRange(tv1);
            DATATH1.SaveChanges();
            try
            {
                DATATH2.TBL_DANHMUCCHUONGTRINHHOTRO.Remove(tv);
                DATATH2.TBL_DANHMUCCHUONGTRINHHOTRO_CHITIET.RemoveRange(tv1);
                DATATH2.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return Json(1);
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpPost]
        public ActionResult GetCTBH(string mactkm)
        {
            var tv = DATATH1.TBL_DANHMUCKM.SingleOrDefault(n => n.MACTKM == mactkm);
            tv.FILEDATA = null;
            return Json(tv);
        }
        [Authorize(Roles = "KHUYENMAICN")]
        [HttpPost]
        public ActionResult GetCTBHCN(string mactkm)
        {
            var InfoCRM = GetCRM();
            var macn = InfoCRM.macn;
            string strcnctkm = "SELECT MACTKM AS MAKM, TENCTKM AS TENKM, MAHH,ck  from TBL_DANHMUCKM WHERE MaCTKM = '" + mactkm + "'";
            var data = new List<ListKhuyenMai>();
            if (queryCN.SingleOrDefault(n => n.macn == macn) != null)
            {
                data = queryCN.SingleOrDefault(n => n.macn == macn).data.Database.SqlQuery<ListKhuyenMai>(strcnctkm).ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == macn) != null)
            {
                data = queryCH.SingleOrDefault(n => n.macn == macn).data.Database.SqlQuery<ListKhuyenMai>(strcnctkm).ToList();
            }
            return Json(data.FirstOrDefault());
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpPost]
        public ActionResult GetCTHT(string mactht)
        {
            var tv = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.SingleOrDefault(n => n.MACTHT == mactht);
            tv.FILEDATA = null;
            return Json(tv);
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpPost]
        public ActionResult PartialEditCTBHCHITIET(string mactkm)
        {
            var data = DATATH1.TBL_DANHMUCKM_CHITIET.Where(n => n.MACTKM == mactkm).ToList();
            return PartialView(data);
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpPost]
        public ActionResult PartialCTHTCHITIET(string mactht)
        {
            var data = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO_CHITIET.Where(n => n.MACTHT == mactht).ToList();
            return PartialView(data);
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpPost]
        public ActionResult PartialEditCTHTCHITIET(string mactht)
        {
            var data = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO_CHITIET.Where(n => n.MACTHT == mactht).ToList();
            return PartialView(data);
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpPost]
        public ActionResult PartialCTBHCHITIET(string mactkm)
        {
            var data = DATATH1.TBL_DANHMUCKM_CHITIET.Where(n => n.MACTKM == mactkm).ToList();
            return PartialView(data);
        }
        [HttpPost]
        public ActionResult PartialQLDH(string tungay, string denngay, string matdv, string macn)
        {
            var data = DATAGETQLDH(macn, matdv, tungay, denngay).ToList();
            return PartialView(data.OrderByDescending(n => n.MADH).Take(500));
        }
        [HttpPost]
        public ActionResult PartialTracuuthecao(int qui, string matdv, List<string> macn, int nam)
        {
            var Infocrm = GetCRM();
            //var listcn = macn.Split(',').ToList();
            if (matdv == "ALL" && Infocrm.matdv != null)
            {
                var listmatdv = matdv.Split(',').ToList();
                var data = db2.DTA_SOTHE.Where(n => macn.Contains(n.macn) && n.qui == qui && n.nam == nam && listmatdv.Contains(n.matdv)).GroupBy(n => n.makh).Select(cl => new Ketquathecao { MAKH = cl.Key, soluongthe = cl.Count(), listsothe = cl.Select(n => n.sothe).ToList(), TENKH = cl.FirstOrDefault().tenkh }).ToList();
                return PartialView(data);
            }
            else if (matdv == "ALL" && Infocrm.matdv == null)
            {
                var data = db2.DTA_SOTHE.Where(n => macn.Contains(n.macn) && n.qui == qui && n.nam == nam).GroupBy(n => n.makh).Select(cl => new Ketquathecao { MAKH = cl.Key, soluongthe = cl.Count(), listsothe = cl.Select(n => n.sothe).ToList(), TENKH = cl.FirstOrDefault().tenkh }).ToList();
                return PartialView(data);
            }
            else
            {
                var data = db2.DTA_SOTHE.Where(n => macn.Contains(n.macn) && n.qui == qui && n.nam == nam && n.matdv == matdv).GroupBy(n => n.makh).Select(cl => new Ketquathecao { MAKH = cl.Key, soluongthe = cl.Count(), listsothe = cl.Select(n => n.sothe).ToList(), TENKH = cl.FirstOrDefault().tenkh }).ToList();
                return PartialView(data);
            }
        }
        [HttpPost]
        public ActionResult PartialEditdonhangkd(string madh)
        {
            var data = PhuYen.DTA_DONDATHANG_KD.Where(n => n.MADH == madh).ToList();
            var makh = data.FirstOrDefault().MAKH;
            var strkh = "SELECT makh AS MAKH, donvi AS DONVI, diachi AS DIACHI from TBL_DANHMUCKHACHHANG where makh = '" + makh + "'";
            ListDataKD Data = new ListDataKD { ListDDH = data, ListHopdong = PhuYen.Database.SqlQuery<ListHopdongKD>("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").ToList(), ListKH = PhuYen.Database.SqlQuery<ListKhachHang>(strkh).ToList(), ListHH = PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList() };
            ViewBag.ss = CultureInfo.GetCultureInfo("en-GB");
            return PartialView(Data);
        }
        [HttpPost]
        public ActionResult PartialEditdonhangws(string madh)
        {
            var data = PhuYen.DTA_DONDATHANG_WS.Where(n => n.MADH == madh).ToList();
            var makh = data.FirstOrDefault().MAKH;
            var strkh = "SELECT makh AS MAKH, donvi AS DONVI, diachi AS DIACHI from TBL_DANHMUCKHACHHANG where makh = '" + makh + "'";
            ListDataWS Data = new ListDataWS { ListDDH = data, ListHH = PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList(), ListHopdong = PhuYen.TBL_DANHMUCHOPDONG_WS.Where(n => makh.Contains(n.MAKH)).ToList(), ListKH = PhuYen.Database.SqlQuery<ListKhachHang>(strkh).ToList() };
            ViewBag.ss = CultureInfo.GetCultureInfo("en-GB");
            return PartialView(Data);
        }
        [HttpPost]
        public ActionResult PartialEditdonhangwsmobile(string madh)
        {
            var data = PhuYen.DTA_DONDATHANG_WS.Where(n => n.MADH == madh).ToList();
            var makh = data.FirstOrDefault().MAKH;
            var strkh = "SELECT makh AS MAKH, donvi AS DONVI, diachi AS DIACHI from TBL_DANHMUCKHACHHANG where makh = '" + makh + "'";
            ListDataWS Data = new ListDataWS { ListDDH = data, ListHH = PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList(), ListHopdong = PhuYen.TBL_DANHMUCHOPDONG_WS.Where(n => makh.Contains(n.MAKH)).ToList(), ListKH = PhuYen.Database.SqlQuery<ListKhachHang>(strkh).ToList() };
            return PartialView(Data);
        }
        [HttpPost]
        public ActionResult PartialEditdonhangkdmobile(string madh)
        {
            var data = PhuYen.DTA_DONDATHANG_KD.Where(n => n.MADH == madh).ToList();
            var makh = data.FirstOrDefault().MAKH;
            var strkh = "SELECT makh AS MAKH, donvi AS DONVI, diachi AS DIACHI from TBL_DANHMUCKHACHHANG where makh = '" + makh + "'";
            ListDataKD Data = new ListDataKD { ListDDH = data, ListHopdong = PhuYen.Database.SqlQuery<ListHopdongKD>("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").ToList(), ListKH = PhuYen.Database.SqlQuery<ListKhachHang>(strkh).ToList(), ListHH = PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList() };
            return PartialView(Data);
        }
        [HttpPost]
        public ActionResult PartialEditdonhanghcm(string madh)
        {
            var data = HoChiMinh.DTA_DONDATHANG_KD.Where(n => n.MADH == madh).ToList();
            var makh = data.FirstOrDefault().MAKH;
            var strkh = "SELECT makh AS MAKH, donvi AS DONVI, diachi AS DIACHI from TBL_DANHMUCKHACHHANG where makh = '" + makh + "'";
            ListDataKD Data = new ListDataKD { ListDDH = data, ListHopdong = HoChiMinh.Database.SqlQuery<ListHopdongKD>("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").ToList(), ListKH = HoChiMinh.Database.SqlQuery<ListKhachHang>(strkh).ToList(), ListHH = HoChiMinh.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList() };
            ViewBag.ss = CultureInfo.GetCultureInfo("en-GB");
            return PartialView(Data);
        }
        [HttpPost]
        public ActionResult PartialEditdonhanghcmmobile(string madh)
        {
            var data = HoChiMinh.DTA_DONDATHANG_KD.Where(n => n.MADH == madh).ToList();
            var makh = data.FirstOrDefault().MAKH;
            var strkh = "SELECT makh AS MAKH, donvi AS DONVI, diachi AS DIACHI from TBL_DANHMUCKHACHHANG where makh = '" + makh + "'";
            ListDataKD Data = new ListDataKD { ListDDH = data, ListHopdong = HoChiMinh.Database.SqlQuery<ListHopdongKD>("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").ToList(), ListKH = HoChiMinh.Database.SqlQuery<ListKhachHang>(strkh).ToList(), ListHH = HoChiMinh.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList() };
            return PartialView(Data);
        }
        [HttpPost]
        public ActionResult PartialEditdonhangsc(string madh)
        {
            var data = SC.DTA_DONDATHANG_KD.Where(n => n.MADH == madh).ToList();
            var makh = data.FirstOrDefault().MAKH;
            var strkh = "SELECT makh AS MAKH, donvi AS DONVI, diachi AS DIACHI from TBL_DANHMUCKHACHHANG where makh = '" + makh + "'";
            ListDataKD Data = new ListDataKD { ListDDH = data, ListHopdong = SC.Database.SqlQuery<ListHopdongKD>("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").ToList(), ListKH = SC.Database.SqlQuery<ListKhachHang>(strkh).ToList(), ListHH = SC.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList() };
            ViewBag.ss = CultureInfo.GetCultureInfo("en-GB");
            return PartialView(Data);
        }
        [HttpPost]
        public ActionResult PartialEditdonhangscmobile(string madh)
        {
            var data = SC.DTA_DONDATHANG_KD.Where(n => n.MADH == madh).ToList();
            var makh = data.FirstOrDefault().MAKH;
            var strkh = "SELECT makh AS MAKH, donvi AS DONVI, diachi AS DIACHI from TBL_DANHMUCKHACHHANG where makh = '" + makh + "'";
            ListDataKD Data = new ListDataKD { ListDDH = data, ListHopdong = SC.Database.SqlQuery<ListHopdongKD>("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").ToList(), ListKH = SC.Database.SqlQuery<ListKhachHang>(strkh).ToList(), ListHH = SC.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList() };
            return PartialView(Data);
        }
        [HttpPost]
        public ActionResult PartialQLDHSC(string tungay, string denngay, string matinh, string usertao)
        {
            DateTime dt1 = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(tungay), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(denngay), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1);
            var Info = GetInfo();
            ViewBag.quanly = Info.TBL_DANHMUCPHANQUYENSC.quyen;
            if (Info.TBL_DANHMUCPHANQUYENSC.makh == null)
            {
                var data = SC.DTA_DONDATHANG_KD.Where(n => n.NgayDat >= dt1 && n.NgayDat <= dt2).ToList().GroupBy(n => new { n.MADH, n.NgayDat, n.DONVI, n.MAKH, n.HOPDONG, n.USERTAO, n.MACH }).Select(cl => new DTA_DONDATHANG_KD { MADH = cl.Key.MADH, DONVI = cl.Key.DONVI, NgayDat = cl.Key.NgayDat, DUYETDH = cl.OrderByDescending(n => n.DUYETDH).First().DUYETDH, USERTAO = cl.Key.USERTAO, MACH = cl.Key.MACH, HOPDONG = cl.Key.HOPDONG, MAKH = cl.Key.MAKH, NGAYLAPHD = cl.First().NGAYLAPHD }).OrderByDescending(n => n.MADH).ToList();
                if (usertao != "")
                {
                    data = data.Where(n => n.USERTAO == usertao).ToList();
                }
                if (matinh != "")
                {
                    var khtinh = SC.Database.SqlQuery<string>("SELECT makh AS MAKH from TBL_DANHMUCKHACHHANG where matinh = '" + matinh + "'").ToList();
                    data = data.Where(n => khtinh.Contains(n.MAKH)).ToList();
                }
                return PartialView(data);
            }
            else
            {
                var makh = Info.TBL_DANHMUCPHANQUYENSC.makh.Split(',').ToList();
                var data = SC.DTA_DONDATHANG_KD.Where(n => n.NgayDat >= dt1 && n.NgayDat <= dt2 && makh.Contains(n.MAKH)).ToList().GroupBy(n => new { n.MADH, n.NgayDat, n.DONVI, n.MAKH, n.HOPDONG, n.USERTAO, n.MACH }).Select(cl => new DTA_DONDATHANG_KD { MADH = cl.Key.MADH, DONVI = cl.Key.DONVI, NgayDat = cl.Key.NgayDat, DUYETDH = cl.OrderByDescending(n => n.DUYETDH).First().DUYETDH, USERTAO = cl.Key.USERTAO, MACH = cl.Key.MACH, HOPDONG = cl.Key.HOPDONG, MAKH = cl.Key.MAKH, NGAYLAPHD = cl.First().NGAYLAPHD }).OrderByDescending(n => n.MADH).ToList();
                if (usertao != "")
                {
                    data = data.Where(n => n.USERTAO == usertao).ToList();
                }
                if (matinh != "")
                {
                    var khtinh = SC.Database.SqlQuery<string>("SELECT makh AS MAKH from TBL_DANHMUCKHACHHANG where matinh = '" + matinh + "'").ToList();
                    data = data.Where(n => khtinh.Contains(n.MAKH)).ToList();
                }
                return PartialView(data);
            }
        }
        [HttpPost]
        public ActionResult PartialQLDHKD(string tungay, string denngay, string matinh, string usertao)
        {
            DateTime dt1 = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(tungay), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(denngay), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1);
            var Info = GetInfo();
            ViewBag.quanly = Info.TBL_DANHMUCPHANQUYENKD.quyen;
            if (Info.TBL_DANHMUCPHANQUYENKD.makh == null)
            {
                var data = PhuYen.DTA_DONDATHANG_KD.Where(n => n.NgayDat >= dt1 && n.NgayDat <= dt2).ToList().GroupBy(n => new { n.MADH, n.NgayDat, n.DONVI, n.MAKH, n.HOPDONG, n.USERTAO, n.MACH }).Select(cl => new DTA_DONDATHANG_KD { MADH = cl.Key.MADH, DONVI = cl.Key.DONVI, NgayDat = cl.Key.NgayDat, DUYETDH = cl.OrderByDescending(n => n.DUYETDH).First().DUYETDH, USERTAO = cl.Key.USERTAO, MACH = cl.Key.MACH, HOPDONG = cl.Key.HOPDONG, MAKH = cl.Key.MAKH, NGAYLAPHD = cl.First().NGAYLAPHD }).OrderByDescending(n => n.MADH).ToList();
                if (usertao != "")
                {
                    data = data.Where(n => n.USERTAO == usertao).ToList();
                }
                if (matinh != "")
                {
                    var khtinh = PhuYen.Database.SqlQuery<string>("SELECT makh AS MAKH from TBL_DANHMUCKHACHHANG where matinh = '" + matinh + "'").ToList();
                    data = data.Where(n => khtinh.Contains(n.MAKH)).ToList();
                }
                return PartialView(data);
            }
            else
            {
                var makh = Info.TBL_DANHMUCPHANQUYENKD.makh.Split(',').ToList();
                var data = PhuYen.DTA_DONDATHANG_KD.Where(n => n.NgayDat >= dt1 && n.NgayDat <= dt2 && makh.Contains(n.MAKH)).ToList().GroupBy(n => new { n.MADH, n.NgayDat, n.DONVI, n.MAKH, n.HOPDONG, n.USERTAO, n.MACH }).Select(cl => new DTA_DONDATHANG_KD { MADH = cl.Key.MADH, DONVI = cl.Key.DONVI, NgayDat = cl.Key.NgayDat, DUYETDH = cl.OrderByDescending(n => n.DUYETDH).First().DUYETDH, USERTAO = cl.Key.USERTAO, MACH = cl.Key.MACH, HOPDONG = cl.Key.HOPDONG, MAKH = cl.Key.MAKH, NGAYLAPHD = cl.First().NGAYLAPHD }).OrderByDescending(n => n.MADH).ToList();
                if (usertao != "")
                {
                    data = data.Where(n => n.USERTAO == usertao).ToList();
                }
                if (matinh != "")
                {
                    var khtinh = PhuYen.Database.SqlQuery<string>("SELECT makh AS MAKH from TBL_DANHMUCKHACHHANG where matinh = '" + matinh + "'").ToList();
                    data = data.Where(n => khtinh.Contains(n.MAKH)).ToList();
                }
                return PartialView(data);
            }
        }
        [Authorize(Roles = "DONHANGWS,KINHDOANHWS")]
        [HttpPost]
        public ActionResult PartialQLDHWS(string tungay, string denngay, string matinh, string usertao)
        {
            DateTime dt1 = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(tungay), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(denngay), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1);
            var Info = GetInfo();
            ViewBag.quanly = Info.TBL_DANHMUCPHANQUYENWS.quyen;
            ViewBag.quyen = Info.quyen;
            if (Info.TBL_DANHMUCPHANQUYENWS.makh == null)
            {
                var data = PhuYen.DTA_DONDATHANG_WS.Where(n => n.NgayDat >= dt1 && n.NgayDat <= dt2).ToList().GroupBy(n => new { n.MADH, n.NgayDat, n.DONVI, n.MAKH, n.HOPDONG, n.USERTAO, n.MACH }).Select(cl => new DTA_DONDATHANG_WS { MADH = cl.Key.MADH, DONVI = cl.Key.DONVI, NgayDat = cl.Key.NgayDat, DUYETDH = cl.OrderByDescending(n => n.DUYETDH).First().DUYETDH, USERTAO = cl.Key.USERTAO, MACH = cl.Key.MACH, HOPDONG = cl.Key.HOPDONG, MAKH = cl.Key.MAKH, NGAYLAPHD = cl.First().NGAYLAPHD }).OrderByDescending(n => n.MADH).ToList();
                if (usertao != "")
                {
                    data = data.Where(n => n.USERTAO == usertao).ToList();
                }
                if (matinh != "")
                {
                    var khtinh = PhuYen.Database.SqlQuery<string>("SELECT makh AS MAKH from TBL_DANHMUCKHACHHANG where matinh = '" + matinh + "'").ToList();
                    data = data.Where(n => khtinh.Contains(n.MAKH)).ToList();
                }
                return PartialView(data);
            }
            else
            {
                var makh = Info.TBL_DANHMUCPHANQUYENWS.makh.Split(',').ToList();
                var data = PhuYen.DTA_DONDATHANG_WS.Where(n => n.NgayDat >= dt1 && n.NgayDat <= dt2 && makh.Contains(n.MAKH)).ToList().GroupBy(n => new { n.MADH, n.NgayDat, n.DONVI, n.MAKH, n.HOPDONG, n.USERTAO, n.MACH }).Select(cl => new DTA_DONDATHANG_WS { MADH = cl.Key.MADH, DONVI = cl.Key.DONVI, NgayDat = cl.Key.NgayDat, DUYETDH = cl.OrderByDescending(n => n.DUYETDH).First().DUYETDH, USERTAO = cl.Key.USERTAO, MACH = cl.Key.MACH, HOPDONG = cl.Key.HOPDONG, MAKH = cl.Key.MAKH, NGAYLAPHD = cl.First().NGAYLAPHD }).OrderByDescending(n => n.MADH).ToList();
                if (usertao != "")
                {
                    data = data.Where(n => n.USERTAO == usertao).ToList();
                }
                if (matinh != "")
                {
                    var khtinh = PhuYen.Database.SqlQuery<string>("SELECT makh AS MAKH from TBL_DANHMUCKHACHHANG where matinh = '" + matinh + "'").ToList();
                    data = data.Where(n => khtinh.Contains(n.MAKH)).ToList();
                }
                return PartialView(data);
            }
        }
        [HttpPost]
        public ActionResult PartialQLDHHCM(string tungay, string denngay, string matinh, string usertao)
        {
            DateTime dt1 = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(tungay), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(denngay), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1);
            var Info = GetInfo();
            ViewBag.quanly = Info.TBL_DANHMUCPHANQUYENHCM.quyen;
            if (Info.TBL_DANHMUCPHANQUYENHCM.makh == null)
            {
                var data = HoChiMinh.DTA_DONDATHANG_KD.Where(n => n.NgayDat >= dt1 && n.NgayDat <= dt2).ToList().GroupBy(n => new { n.MADH, n.NgayDat, n.DONVI, n.MAKH, n.HOPDONG, n.USERTAO, n.MACH }).Select(cl => new DTA_DONDATHANG_KD { MADH = cl.Key.MADH, DONVI = cl.Key.DONVI, NgayDat = cl.Key.NgayDat, DUYETDH = cl.OrderByDescending(n => n.DUYETDH).First().DUYETDH, USERTAO = cl.Key.USERTAO, MACH = cl.Key.MACH, HOPDONG = cl.Key.HOPDONG, MAKH = cl.Key.MAKH, NGAYLAPHD = cl.First().NGAYLAPHD }).OrderByDescending(n => n.MADH).ToList();
                if (usertao != "")
                {
                    data = data.Where(n => n.USERTAO == usertao).ToList();
                }
                if (matinh != "")
                {
                    var khtinh = HoChiMinh.Database.SqlQuery<string>("SELECT makh AS MAKH from TBL_DANHMUCKHACHHANG where matinh = '" + matinh + "'").ToList();
                    data = data.Where(n => khtinh.Contains(n.MAKH)).ToList();
                }
                return PartialView(data);
            }
            else
            {
                var makh = Info.TBL_DANHMUCPHANQUYENHCM.makh.Split(',').ToList();
                var data = HoChiMinh.DTA_DONDATHANG_KD.Where(n => n.NgayDat >= dt1 && n.NgayDat <= dt2 && makh.Contains(n.MAKH)).ToList().GroupBy(n => new { n.MADH, n.NgayDat, n.DONVI, n.MAKH, n.HOPDONG, n.USERTAO, n.MACH }).Select(cl => new DTA_DONDATHANG_KD { MADH = cl.Key.MADH, DONVI = cl.Key.DONVI, NgayDat = cl.Key.NgayDat, DUYETDH = cl.OrderByDescending(n => n.DUYETDH).First().DUYETDH, USERTAO = cl.Key.USERTAO, MACH = cl.Key.MACH, HOPDONG = cl.Key.HOPDONG, MAKH = cl.Key.MAKH, NGAYLAPHD = cl.First().NGAYLAPHD }).OrderByDescending(n => n.MADH).ToList();
                if (usertao != "")
                {
                    data = data.Where(n => n.USERTAO == usertao).ToList();
                }
                if (matinh != "")
                {
                    var khtinh = HoChiMinh.Database.SqlQuery<string>("SELECT makh AS MAKH from TBL_DANHMUCKHACHHANG where matinh = '" + matinh + "'").ToList();
                    data = data.Where(n => khtinh.Contains(n.MAKH)).ToList();
                }
                return PartialView(data);
            }
        }
        [HttpPost]
        public ActionResult PartialQLQD(string mactkm)
        {
            var data = DATATH1.TBL_DANHMUCHANGHOATICHDIEM.Where(n => n.MACT == mactkm).Select(cl => new ListQLQD { MAHH = cl.MAHH, DIEM = cl.DIEM, HOP = cl.HOP, SL = cl.SOLUONG }).ToList();
            var str = string.Format("SELECT MAHH AS MAHH, TENHH AS TENHH from TBL_DANHMUCHANGHOA where MAHH in ({0})", string.Join(",", data.Select(cl => cl.MAHH).Select(p => "'" + p + "'")));
            var listhh = PhuYen.Database.SqlQuery<ListQLQD>(str).ToList();
            foreach (var i in data)
            {
                i.TENHH = listhh.SingleOrDefault(n => n.MAHH == i.MAHH).TENHH;
            }
            return PartialView(data.OrderByDescending(n => n.MAHH));
        }
        [HttpPost]
        public ActionResult Addkhachhangqldhkd(string makh)
        {
            var kh = makh.ToUpper().Split(',').ToList();
            var str = string.Format("SELECT MAKH AS MAKH, DONVI AS DONVI from TBL_DANHMUCKHACHHANG where MAKH in ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
            var listkh = PhuYen.Database.SqlQuery<Khachhang>(str).ToList();
            return Json(listkh);
        }
        [ActionName("in-phieu-xuat-kho-ws")]
        public ActionResult HtmlPhieugiaohang(string kyhieu, string sohdnb)
        {
            ViewBag.CurrentNumberFormat = new CultureInfo("de-DE");
            var tv = datainvoice.TBL_DANHMUCTAIKHOAN.SingleOrDefault(n => n.macn == "PY");

            var data = abc.laythongtinhoadonfkey(sohdnb, "PY");

            if (data.Status == 0)
            {
                return Content("<script type='text/javascript'>alert('Không có dữ liệu'); window.close();</script>");
            }
            else
            {
                ViewBag.pattern = kyhieu;
                var sohddt = Int32.Parse(data.Inv.Invoice.InvoiceNo).ToString("00000000");
                var diachigiaohang = PhuYen.DTA_DONDATHANG_WS.First(n => n.SOHD == sohddt).DIACHIGIAOHANG;
                var datamau = new PHIEUXUATKHO() { thongtin = tv, Invoice = data.Inv.Invoice, DIACHIGIAOHANG = diachigiaohang };
                return View("HtmlPhieugiaohang", datamau);
                //return View("HtmlPhieugiaohang", datamau);
            }

        }
        [Authorize(Roles = "QUANLYWS")]
        [ActionName("xem-hoa-don-ws")]
        public ActionResult HtmlHoadon(string sohdnb, string kyhieu)
        {
            var layhtlmmau = abc.layhtmlhoadon(sohdnb, "PY");
            return Content(layhtlmmau.Message);
        }
        [Authorize(Roles = "QUANLYWS")]
        [ActionName("xem-hoa-don-chuyen-doi-ws")]
        public ActionResult HtmlHoadonchuyendoi(string sohdnb, string kyhieu)
        {
            var layhtlmmau = abc.layhtmlchuyendoi(sohdnb, "PY");
            return Content(layhtlmmau.Message);
        }
        [HttpPost]
        public ActionResult Addkhachhangqldhsc(string makh)
        {
            var kh = makh.ToUpper().Split(',').ToList();
            var str = string.Format("SELECT MAKH AS MAKH, DONVI AS DONVI from TBL_DANHMUCKHACHHANG where MAKH in ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
            var listkh = SC.Database.SqlQuery<Khachhang>(str).ToList();
            return Json(listkh);
        }
        [HttpPost]
        public ActionResult Addkhachhangqldhhcm(string makh)
        {
            var kh = makh.ToUpper().Split(',').ToList();
            var str = string.Format("SELECT MAKH AS MAKH, DONVI AS DONVI from TBL_DANHMUCKHACHHANG where MAKH in ({0})", string.Join(",", kh.Select(p => "'" + p + "'")));
            var listkh = HoChiMinh.Database.SqlQuery<Khachhang>(str).ToList();
            return Json(listkh);
        }
        [HttpPost]
        public ActionResult KhoaDonHangKD(string madh)
        {
            var dh = PhuYen.DTA_DONDATHANG_KD.Where(n => n.MADH == madh);
            foreach (var i in dh)
            {
                if (i.DUYETDH == false)
                {
                    i.DUYETDH = true;
                }
                else
                {
                    i.DUYETDH = false;
                }
            }
            PhuYen.SaveChanges();
            return Json(dh.First().DUYETDH);
        }
        [HttpPost]
        public ActionResult KhoaDonHangSC(string madh)
        {
            var dh = SC.DTA_DONDATHANG_KD.Where(n => n.MADH == madh);
            foreach (var i in dh)
            {
                if (i.DUYETDH == false)
                {
                    i.DUYETDH = true;
                }
                else
                {
                    i.DUYETDH = false;
                }
            }
            SC.SaveChanges();
            return Json(dh.First().DUYETDH);
        }
        [HttpPost]
        public ActionResult KhoaDonHangHCM(string madh)
        {
            var dh = SC.DTA_DONDATHANG_KD.Where(n => n.MADH == madh);
            foreach (var i in dh)
            {
                if (i.DUYETDH == false)
                {
                    i.DUYETDH = true;
                }
                else
                {
                    i.DUYETDH = false;
                }
            }
            HoChiMinh.SaveChanges();
            return Json(dh.First().DUYETDH);
        }
        [HttpPost]
        public ActionResult Editkhachhangkd(List<string> makh, string taikhoan)
        {
            var dh = db2.TBL_DANHMUCPHANQUYENKD.SingleOrDefault(n => n.taikhoan == taikhoan);
            dh.makh = String.Join(",", makh.ToArray());
            db2.SaveChanges();
            return Json(1);
        }
        [HttpPost]
        public ActionResult Editkhachhangsc(List<string> makh, string taikhoan)
        {
            var dh = db2.TBL_DANHMUCPHANQUYENSC.SingleOrDefault(n => n.taikhoan == taikhoan);
            dh.makh = String.Join(",", makh.ToArray());
            db2.SaveChanges();
            return Json(1);
        }
        [HttpPost]
        public ActionResult Editkhachhanghcm(List<string> makh, string taikhoan)
        {
            var dh = db2.TBL_DANHMUCPHANQUYENHCM.SingleOrDefault(n => n.taikhoan == taikhoan);
            dh.makh = String.Join(",", makh.ToArray());
            db2.SaveChanges();
            return Json(1);
        }
        [HttpPost]
        public ActionResult PartialViewCTBH(string mactkm)
        {
            //    var Info = GetInfo();
            //    var macn = Info.macn.Split(',').FirstOrDefault();
            var data = DATATH1.TBL_DANHMUCKM.SingleOrDefault(n => n.MACTKM == mactkm);
            if (data.PHAMVI != null && data.MAHH != null)
            {
                var macn = data.PHAMVI.Split(',').ToList();
                var mahh = data.MAHH.Split(',').ToList();
                ChitietCTBH final = new ChitietCTBH
                {
                    dulieu = data,
                    macn = db2.TBL_DANHSACHCHINHANH.Where(n => macn.Contains(n.macn)).OrderBy(n => n.Mien).ThenByDescending(n => n.stt).ToList(),
                    mahh = PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH,TENHH FROM TBL_DANHMUCHANGHOA WHERE MAHH IS NOT NULL AND MAHH != '' ").Where(n => mahh.Contains(n.MAHH)).ToList()
                };
                return PartialView(final);
            }
            else if (data.PHAMVI == null && data.MAHH != null)
            {
                var mahh = data.MAHH.Split(',').ToList();
                ChitietCTBH final = new ChitietCTBH
                {
                    dulieu = data,
                    mahh = PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH,TENHH FROM TBL_DANHMUCHANGHOA WHERE MAHH IS NOT NULL AND MAHH != '' ").Where(n => mahh.Contains(n.MAHH)).ToList()
                };
                return PartialView(final);
            }
            else if (data.PHAMVI != null && data.MAHH == null)
            {
                var macn = data.PHAMVI.Split(',').ToList();
                ChitietCTBH final = new ChitietCTBH
                {
                    dulieu = data,
                    macn = db2.TBL_DANHSACHCHINHANH.Where(n => macn.Contains(n.macn)).OrderBy(n => n.Mien).ThenByDescending(n => n.stt).ToList()
                };
                return PartialView(final);
            }
            else
            {
                ChitietCTBH final = new ChitietCTBH { dulieu = data };
                return PartialView(final);
            }
        }
        [HttpPost]
        public ActionResult PartialViewCTHT(string mactht)
        {
            var data = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.SingleOrDefault(n => n.MACTHT == mactht);
            if (data.PHAMVI != null && data.MAHH != null)
            {
                var macn = data.PHAMVI.Split(',').ToList();
                var mahh = data.MAHH.Split(',').ToList();
                ChitietCTHT final = new ChitietCTHT { dulieu = data, macn = db2.TBL_DANHSACHCHINHANH.Where(n => macn.Contains(n.macn)).OrderBy(n => n.Mien).ThenByDescending(n => n.stt).ToList(), mahh = PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH,TENHH FROM TBL_DANHMUCHANGHOA WHERE MAHH IS NOT NULL AND MAHH != '' ").Where(n => mahh.Contains(n.MAHH)).ToList() };
                return PartialView(final);
            }
            else if (data.PHAMVI == null && data.MAHH != null)
            {
                var mahh = data.MAHH.Split(',').ToList();
                ChitietCTHT final = new ChitietCTHT { dulieu = data, mahh = PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH,TENHH FROM TBL_DANHMUCHANGHOA WHERE MAHH IS NOT NULL AND MAHH != '' ").Where(n => mahh.Contains(n.MAHH)).ToList() };
                return PartialView(final);
            }
            else if (data.PHAMVI != null && data.MAHH == null)
            {
                var macn = data.PHAMVI.Split(',').ToList();
                ChitietCTHT final = new ChitietCTHT { dulieu = data, macn = db2.TBL_DANHSACHCHINHANH.Where(n => macn.Contains(n.macn)).OrderBy(n => n.Mien).ThenByDescending(n => n.stt).ToList() };
                return PartialView(final);
            }
            else
            {
                ChitietCTHT final = new ChitietCTHT { dulieu = data };
                return PartialView(final);
            }
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpGet]
        public ActionResult PartialQLBH()
        {
            var data = DATATH1.TBL_DANHMUCKM.OrderByDescending(n => n.ngayketthuc).ThenBy(n => n.MACTKM);
            return PartialView(data);
        }
        [Authorize(Roles = "KHUYENMAICN")]
        [HttpGet]
        public ActionResult PartialQLBHCN()
        {
            var InfoCRM = GetCRM();
            var macn = InfoCRM.macn;
            string strcnctkm = "SELECT MACTKM AS MAKM, TENCTKM AS TENKM, MAHH,ngaybatdau,ngayketthuc  from TBL_DANHMUCKM WHERE MaCTKM IS NOT NULL";
            var data = new List<ListKhuyenMai>();
            if (queryCN.SingleOrDefault(n => n.macn == macn) != null)
            {
                data = queryCN.SingleOrDefault(n => n.macn == macn).data.Database.SqlQuery<ListKhuyenMai>(strcnctkm).ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == macn) != null)
            {
                data = queryCH.SingleOrDefault(n => n.macn == macn).data.Database.SqlQuery<ListKhuyenMai>(strcnctkm).ToList();
            }
            return PartialView(data);
        }
        [Authorize(Roles = "KHUYENMAI")]
        [HttpGet]
        public ActionResult PartialQLHT()
        {
            var data = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.OrderByDescending(n => n.ngayketthuc).ThenBy(n => n.MACTHT);
            return PartialView(data);
        }
        [Authorize(Roles = "DONHANGHCM")]
        [ActionName("tao-don-dat-hang-ve-hcm")]
        public ActionResult Taodonhanghcm()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var makh = Info.TBL_DANHMUCPHANQUYENHCM.makh.Split(',').ToList();
            var strkh = string.Format("SELECT makh AS MAKH, donvi AS DONVI, diachi AS DIACHI from TBL_DANHMUCKHACHHANG where makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            //var list = db2.TBL_DANHMUCHOPDONGCHUNG.ToList();
            //var hdchung = HoChiMinh.Database.SqlQuery<ListHopdongKD>(string.Format("select MAHD AS MAHOPDONG, noidung AS TENHOPDONG, 0 AS ck from TBL_DANHMUCHOPDONG where mahd IN ({0}) and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'", string.Join(",", list.Select(p => "'" + p.MAHD + "'")))).ToList();
            if (makh.Count() == 1)
            {
                ListDataKD Data = new ListDataKD { ListHopdong = HoChiMinh.Database.SqlQuery<ListHopdongKD>("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG from TBL_DANHMUCHOPDONG where makh = '" + Info.TBL_DANHMUCPHANQUYENHCM.makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").ToList(), ListKH = HoChiMinh.Database.SqlQuery<ListKhachHang>(strkh).ToList() };
                return View("Taodonhanghcm", Data);
            }
            else
            {
                ListDataKD Data = new ListDataKD { ListHopdong = null, ListKH = HoChiMinh.Database.SqlQuery<ListKhachHang>(strkh).ToList() };
                return View("Taodonhanghcm", Data);
            }
        }
        [Authorize(Roles = "DONHANGSC")]
        [ActionName("tao-don-dat-hang-ve-sc")]
        public ActionResult Taodonhangsc()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var makh = Info.TBL_DANHMUCPHANQUYENSC.makh.Split(',').ToList();
            var strkh = string.Format("SELECT makh AS MAKH, donvi AS DONVI, diachi AS DIACHI from TBL_DANHMUCKHACHHANG where makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            var list = SC.TBL_DANHMUCHOPDONGCHUNG.ToList();
            var hdchung = SC.Database.SqlQuery<ListHopdongKD>(string.Format("select MAHD AS MAHOPDONG, noidung AS TENHOPDONG, CAST(ck AS INT) AS ck from TBL_DANHMUCHOPDONG where mahd IN ({0}) and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'", string.Join(",", list.Select(p => "'" + p.MAHD + "'")))).ToList();
            if (makh.Count() == 1)
            {
                ListDataKD Data = new ListDataKD { ListHopdong = SC.Database.SqlQuery<ListHopdongKD>("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG from TBL_DANHMUCHOPDONG where makh = '" + Info.TBL_DANHMUCPHANQUYENSC.makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").Concat(hdchung).Distinct().ToList(), ListKH = SC.Database.SqlQuery<ListKhachHang>(strkh).ToList() };
                return View("Taodonhangsc", Data);
            }
            else
            {
                ListDataKD Data = new ListDataKD { ListHopdong = null, ListKH = HoChiMinh.Database.SqlQuery<ListKhachHang>(strkh).ToList() };
                return View("Taodonhangsc", Data);
            }
        }
        [Authorize(Roles = "DONHANGSC")]
        [ActionName("tao-don-dat-hang-ve-sc-mobile")]
        public ActionResult Taodonhangscmobile()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var makh = Info.TBL_DANHMUCPHANQUYENSC.makh.Split(',').ToList();
            var strkh = string.Format("SELECT makh AS MAKH, donvi AS DONVI, diachi AS DIACHI from TBL_DANHMUCKHACHHANG where makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            var list = SC.TBL_DANHMUCHOPDONGCHUNG.ToList();
            var hdchung = SC.Database.SqlQuery<ListHopdongKD>(string.Format("select MAHD AS MAHOPDONG, noidung AS TENHOPDONG, CAST(ck AS INT) AS ck from TBL_DANHMUCHOPDONG where mahd IN ({0}) and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'", string.Join(",", list.Select(p => "'" + p.MAHD + "'")))).ToList();
            if (makh.Count() == 1)
            {
                ListDataKD Data = new ListDataKD { ListHopdong = SC.Database.SqlQuery<ListHopdongKD>("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG from TBL_DANHMUCHOPDONG where makh = '" + Info.TBL_DANHMUCPHANQUYENSC.makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").Concat(hdchung).Distinct().ToList(), ListKH = SC.Database.SqlQuery<ListKhachHang>(strkh).ToList() };
                return View("Taodonhangscmobile", Data);
            }
            else
            {
                ListDataKD Data = new ListDataKD { ListHopdong = null, ListKH = SC.Database.SqlQuery<ListKhachHang>(strkh).ToList() };
                return View("Taodonhangscmobile", Data);
            }

        }
        [Authorize(Roles = "DONHANGHCM")]
        [ActionName("tao-don-dat-hang-ve-hcm-mobile")]
        public ActionResult Taodonhanghcmmobile()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var makh = Info.TBL_DANHMUCPHANQUYENHCM.makh.Split(',').ToList();
            var strkh = string.Format("SELECT makh AS MAKH, donvi AS DONVI, diachi AS DIACHI from TBL_DANHMUCKHACHHANG where makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            //var list = db2.TBL_DANHMUCHOPDONGCHUNG.ToList();
            //var hdchung = PhuYen.Database.SqlQuery<ListHopdongKD>(string.Format("select MAHD AS MAHOPDONG, noidung AS TENHOPDONG, CAST(ck AS INT) AS ck from TBL_DANHMUCHOPDONG where mahd IN ({0}) and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'", string.Join(",", list.Select(p => "'" + p.MAHD + "'")))).ToList();
            if (makh.Count() == 1)
            {
                ListDataKD Data = new ListDataKD { ListHopdong = HoChiMinh.Database.SqlQuery<ListHopdongKD>("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG from TBL_DANHMUCHOPDONG where makh = '" + Info.TBL_DANHMUCPHANQUYENHCM.makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").ToList(), ListKH = HoChiMinh.Database.SqlQuery<ListKhachHang>(strkh).ToList() };
                return View("Taodonhanghcmmobile", Data);
            }
            else
            {
                ListDataKD Data = new ListDataKD { ListHopdong = null, ListKH = HoChiMinh.Database.SqlQuery<ListKhachHang>(strkh).ToList() };
                return View("Taodonhanghcmmobile", Data);
            }

        }
        [Authorize(Roles = "DONHANGKD")]
        [ActionName("tao-don-dat-hang-ve-phong-kinh-doanh")]
        public ActionResult Taodonhangkd()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var makh = Info.TBL_DANHMUCPHANQUYENKD.makh.Split(',').ToList();
            var strkh = string.Format("SELECT makh AS MAKH, donvi AS DONVI, diachi AS DIACHI from TBL_DANHMUCKHACHHANG where makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            var list = PhuYen.TBL_DANHMUCHOPDONGCHUNG.ToList();
            var hdchung = PhuYen.Database.SqlQuery<ListHopdongKD>(string.Format("select MAHD AS MAHOPDONG, noidung AS TENHOPDONG, CAST(ck AS INT) AS ck from TBL_DANHMUCHOPDONG where mahd IN ({0}) and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'", string.Join(",", list.Select(p => "'" + p.MAHD + "'")))).ToList();
            if (makh.Count() == 1)
            {
                ListDataKD Data = new ListDataKD { ListHopdong = PhuYen.Database.SqlQuery<ListHopdongKD>("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG from TBL_DANHMUCHOPDONG where makh = '" + Info.TBL_DANHMUCPHANQUYENKD.makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").Concat(hdchung).Distinct().ToList(), ListKH = PhuYen.Database.SqlQuery<ListKhachHang>(strkh).ToList() };
                return View("Taodonhangkd", Data);
            }
            else
            {
                ListDataKD Data = new ListDataKD { ListHopdong = null, ListKH = PhuYen.Database.SqlQuery<ListKhachHang>(strkh).ToList() };
                return View("Taodonhangkd", Data);
            }
        }

        [Authorize(Roles = "QUANLYWS")]
        [HttpGet]
        public ActionResult PartialDMHDWS()
        {
            var data = PhuYen.TBL_DANHMUCHOPDONG_WS.OrderByDescending(n => n.NGAYKETTHUC).ThenBy(n => n.MACN);
            return PartialView(data);
        }
        [Authorize(Roles = "QUANLYWS")]
        [ActionName("danh-muc-hop-dong-ws")]
        public ActionResult NhapdanhmuchopdongWS()
        {
            var Info = GetInfo();
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            ViewBag.macn = Info.macn.Split(',').ToList();
            var data = new QuanlyCTBH { CHINHANH = db2.TBL_DANHSACHCHINHANH.Where(n => n.check == true).OrderBy(n => n.Mien).ThenByDescending(n => n.stt).ToList(), HANGHOA = SC.Database.SqlQuery<ListHangHoa>("SELECT MAHH,TENHH,DVT,GIABAN FROM TBL_DANHMUCHANGHOA WHERE MAHH IS NOT NULL AND MAHH != '' AND MAHH != '..' AND nhom IN ('35','50', '51', '60', '61', '62', '63','64','64.PME','64.STA', '70','99','40','50.STA','51.STA','60.STA','62.STA')").ToList() };
            return View("NhapdanhmuchopdongWS", data);
        }
        [HttpPost]
        [Authorize(Roles = "QUANLYWS")]
        public ActionResult ImportHopDongWS(List<ImportHopDongWS> data)
        {
            var hopdong = data.GroupBy(n => new { n.MAHD, n.MAKH }).Select(n => new TBL_DANHMUCHOPDONG_WS() { MACN = "PY", MAKH = n.Key.MAKH, MAHD = n.Key.MAHD, diachigiaohang = n.First().DIACHIGIAOHANG, donvi = n.First().TENKH, GHICHU = n.First().GHICHU, NGAYBATDAU = n.First().NGAYBATDAU, NGAYKETTHUC = n.First().NGAYKETTHUC, nguoidung = User.Identity.Name, noidung = n.First().NOIDUNG });
            var cthopdong = data.Select(n => new TBL_CT_DANHMUCHOPDONG_WS() { MACN = "PY", MAHD = n.MAHD, MAKH = n.MAKH, GIASP = n.GIASP, MAHH = n.MAHH, SODK = n.SDK, SOLUONGNAM = n.SLNAM, SOLUONGQUI = n.SLQUI });
            PhuYen.TBL_DANHMUCHOPDONG_WS.AddRange(hopdong);
            PhuYen.TBL_CT_DANHMUCHOPDONG_WS.AddRange(cthopdong);
            PhuYen.SaveChanges();
            return Json("1");
        }
        [Authorize(Roles = "QUANLYWS")]
        [HttpPost]
        public ActionResult PartialCTDMHDWS(string macn, string makh, string mahd)
        {
            var data = PhuYen.TBL_CT_DANHMUCHOPDONG_WS.Where(n => n.MACN == macn && n.MAKH == makh && n.MAHD == mahd).ToList();
            return PartialView(data);
        }
        [Authorize(Roles = "HANGHOA")]
        [HttpPost]
        public ActionResult PartialQLHH(List<string> locnhom, string locsudung, string locthuockedon, string locchc, string lockiemsoatdacbiet)
        {

            var data = DATATH1.dta_Products.ToList();
            if (locnhom != null)
            {
                data = data.Where(n => locnhom.Contains(n.nhom)).ToList();
            }
            if (locsudung != "null" && locsudung != null)
            {
                if (locsudung == "1")
                {
                    data = data.Where(n => n.HIENTHI == true).ToList();
                }
                else if (locsudung == "0")
                {
                    data = data.Where(n => n.HIENTHI == false).ToList();
                }

            }
            if (locthuockedon != "null" && locthuockedon != null)
            {
                if (locthuockedon == "1")
                {
                    data = data.Where(n => n.thuockedon == true).ToList();
                }
                else if (locthuockedon == "0")
                {
                    data = data.Where(n => n.thuockedon == false).ToList();
                }

            }
            if (locchc != "null" && locchc != null)
            {
                if (locchc == "1")
                {
                    data = data.Where(n => n.chc == true).ToList();
                }
                else if (locsudung == "0")
                {
                    data = data.Where(n => n.chc == false).ToList();
                }

            }
            if (lockiemsoatdacbiet != "null" && lockiemsoatdacbiet != null)
            {
                if (lockiemsoatdacbiet == "1")
                {
                    data = data.Where(n => n.kiemsoatdacbiet == true).ToList();
                }
                else if (lockiemsoatdacbiet == "0")
                {
                    data = data.Where(n => n.kiemsoatdacbiet == false).ToList();
                }

            }
            return PartialView(data);
        }
        [Authorize(Roles = "HANGHOA")]
        [HttpPost]
        public ActionResult Partialchitiethanghoa(string mahh)
        {
            var data = DATATH1.dta_Products.SingleOrDefault(n => n.MAHH == mahh);
            return PartialView(data);
        }
        [Authorize(Roles = "HANGHOA")]
        [HttpPost]
        public ActionResult Partialeditchitiethanghoa(string mahh)
        {
            var data = DATATH1.dta_Products.SingleOrDefault(n => n.MAHH == mahh);
            return PartialView(data);
        }
        [Authorize(Roles = "QUANLYWS")]
        [HttpPost]
        public ActionResult PartialEditCTDMHDWS(string macn, string makh, string mahd)
        {
            var data = PhuYen.TBL_CT_DANHMUCHOPDONG_WS.Where(n => n.MACN == macn && n.MAKH == makh && n.MAHD == mahd).ToList();
            return PartialView(data);
        }
        [Authorize(Roles = "QUANLYWS")]
        [HttpPost]
        public ActionResult AddCTDMHDWS(List<TBL_CT_DANHMUCHOPDONG_WS> data)
        {
            PhuYen.TBL_CT_DANHMUCHOPDONG_WS.AddRange(data);
            PhuYen.SaveChanges();
            return Json(1);
        }
        [Authorize(Roles = "QUANLYWS")]
        [HttpPost]
        public ActionResult DelCTDMHDWS(string macn, string makh, string mahd)
        {
            var tv = PhuYen.TBL_CT_DANHMUCHOPDONG_WS.Where(n => n.MACN == macn && n.MAKH == makh && n.MAHD == mahd);
            PhuYen.TBL_CT_DANHMUCHOPDONG_WS.RemoveRange(tv);
            PhuYen.SaveChanges();
            return Json(1);
        }
        [Authorize(Roles = "HANGHOA")]
        [HttpPost]
        public ActionResult Yeucauxoahh(string mahh)
        {
            var tv = DATATH1.dta_Products.SingleOrDefault(n => n.MAHH == mahh);
            if (tv != null)
            {
                DATATH1.dta_Products_pending.Add(new dta_Products_pending() { ngay_yeu_cau = DateTime.Now, user_yeu_cau = User.Identity.Name, MAHH = mahh, TENHH = tv.TENHH, loaiyeucau = "DELETE" });
                DATATH1.SaveChanges();
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }
        [Authorize(Roles = "HANGHOA")]
        [HttpPost]
        public ActionResult Yeucauthaydoigiahh(string mahh, decimal giaban)
        {
            var tv = DATATH1.dta_Products.SingleOrDefault(n => n.MAHH == mahh);
            if (tv != null)
            {
                DATATH1.dta_Products_pending.Add(new dta_Products_pending() { ngay_yeu_cau = DateTime.Now, user_yeu_cau = User.Identity.Name, MAHH = mahh, TENHH = tv.TENHH, loaiyeucau = "PRICE", GIABAN = giaban, mota = "Yêu cầu thay đổi giá bán của hàng hóa " + tv.MAHH + "-" + tv.TENHH + " từ " + string.Format("{0:#,##0.00}", tv.GIABAN) + " thành " + string.Format("{0:#,##0.00}", giaban) });
                DATATH1.SaveChanges();
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }
        [Authorize(Roles = "HANGHOA")]
        [HttpPost]
        public ActionResult Yeucauthaydoithongtin(string mahh, decimal giaban)
        {
            var tv = DATATH1.dta_Products.SingleOrDefault(n => n.MAHH == mahh);
            if (tv != null)
            {
                DATATH1.dta_Products_pending.Add(new dta_Products_pending() { ngay_yeu_cau = DateTime.Now, user_yeu_cau = User.Identity.Name, MAHH = mahh, TENHH = tv.TENHH, loaiyeucau = "INFO", GIABAN = giaban, mota = "Yêu cầu thay đổi giá bán của hàng hóa " + tv.MAHH + "-" + tv.TENHH + " từ " + string.Format("{0:#,##0.00}", tv.GIABAN) + " thành " + string.Format("{0:#,##0.00}", giaban) });
                DATATH1.SaveChanges();
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }
        [Authorize(Roles = "HANGHOA")]
        [HttpPost]
        public ActionResult Yeucautaohanghoa(string mahh, decimal giaban)
        {
            var tv = DATATH1.dta_Products.SingleOrDefault(n => n.MAHH == mahh);
            if (tv != null)
            {
                DATATH1.dta_Products_pending.Add(new dta_Products_pending() { ngay_yeu_cau = DateTime.Now, user_yeu_cau = User.Identity.Name, MAHH = mahh, TENHH = tv.TENHH, loaiyeucau = "CREATE", GIABAN = giaban, mota = "Yêu cầu thay đổi giá bán của hàng hóa " + tv.MAHH + "-" + tv.TENHH + " từ " + string.Format("{0:#,##0.00}", tv.GIABAN) + " thành " + string.Format("{0:#,##0.00}", giaban) });
                DATATH1.SaveChanges();
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }
        [Authorize(Roles = "QUANLYWS")]
        [HttpPost]
        public ActionResult AddDMHDWS(string macn, string makh, string mahd, string noidung,
                                                string ngaybatdau, string ngayketthuc, string donvi,
                                                string diachigiaohang, string ghichu)
        {
            PhuYen.TBL_DANHMUCHOPDONG_WS.Add(new TBL_DANHMUCHOPDONG_WS
            {
                MACN = macn,
                MAKH = makh,
                MAHD = mahd,
                noidung = noidung,
                NGAYBATDAU = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngaybatdau), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                NGAYKETTHUC = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngayketthuc), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                donvi = donvi,
                diachigiaohang = diachigiaohang,
                nguoidung = User.Identity.Name,
                GHICHU = ghichu
            });
            PhuYen.SaveChanges();
            return Json(1);
        }
        [Authorize(Roles = "QUANLYWS")]
        [HttpPost]
        public ActionResult GetDMHDWS(string macn, string makh, string mahd)
        {
            var tv = PhuYen.TBL_DANHMUCHOPDONG_WS.SingleOrDefault(n => n.MACN == macn && n.MAKH == makh && n.MAHD == mahd);

            return Json(tv);
        }
        [Authorize(Roles = "QUANLYWS")]
        [HttpPost]
        public ActionResult DelHDWS(string macn, string makh, string mahd)
        {
            var tv = PhuYen.TBL_DANHMUCHOPDONG_WS.SingleOrDefault(n => n.MACN == macn && n.MAKH == makh && n.MAHD == mahd);
            var tv1 = PhuYen.TBL_CT_DANHMUCHOPDONG_WS.Where(n => n.MACN == macn && n.MAKH == makh && n.MAHD == mahd);
            PhuYen.TBL_DANHMUCHOPDONG_WS.Remove(tv);
            PhuYen.TBL_CT_DANHMUCHOPDONG_WS.RemoveRange(tv1);
            PhuYen.SaveChanges();
            return Json(1);
        }
        [Authorize(Roles = "QUANLYWS")]
        [HttpPost]
        public ActionResult EditDMHDWS(string macn, string makh, string mahd, string noidung,
                                       string ngaybatdau, string ngayketthuc, string donvi,
                                       string diachigiaohang, string nguoidung, string ghichu)
        {

            var tv = PhuYen.TBL_DANHMUCHOPDONG_WS.SingleOrDefault(n => n.MACN == macn && n.MAKH == makh && n.MAHD == mahd);
            if (tv != null)
            {
                tv.noidung = noidung;
                tv.NGAYBATDAU = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngaybatdau), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                tv.NGAYKETTHUC = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(ngayketthuc), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                tv.donvi = donvi;
                tv.diachigiaohang = diachigiaohang;
                tv.nguoidung = User.Identity.Name;
                tv.GHICHU = ghichu;
                PhuYen.SaveChanges();
            }
            return Json(1);
        }
        [Authorize(Roles = "KHOWS,KINHDOANHWS")]
        [ActionName("quan-ly-kho-ws")]
        public ActionResult Quanlykhows()
        {
            var Info = GetInfo();
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            return View("Quanlykhows");
        }
        [Authorize(Roles = "QUANLYWS,KINHDOANHWS")]
        [ActionName("tim-kiem-hoa-don-ws")]
        public ActionResult TimkiemhoadonWS()
        {
            var Info = GetInfo();

            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            return View("TimkiemhoadonWS");
        }
        //[Authorize(Roles = "DONHANGWS")]
        //[HttpPost]
        //public ActionResult GetPartialTimKiemWS(List<string> macn)
        //{
        //    var Info = GetInfo();
        //    var data = new DulieutimkiemWS();
        //    data.KHACHHANG = DATAGETKHACHHANG(macn.FirstOrDefault(), Info);
        //    return PartialView(data);
        //}
        [Authorize(Roles = "QUANLYWS,KINHDOANHWS")]
        [HttpPost]
        public ActionResult GetPartialKetquaWS(string kyhieu, string makh, string tungay, string denngay, string tuso, string denso, string sohdnb, string sohddt)
        {
            var Info = GetInfo();
            ViewBag.quyen = Info.quyen;
            var data = abc.tracuuhoadon(null, null, "1/001", "K23TPP", tungay, denngay, tuso, denso, 1, 1000, "PY");
            return PartialView(data);
        }

        [Authorize(Roles = "KHOWS,KINHDOANHWS")]
        [HttpPost]
        public ActionResult GetPartialKhoWS(string kyhieu, string makh, string tungay, string denngay, string tuso, string denso, string sohdnb, string sohddt)
        {
            var Info = GetInfo();
            ViewBag.quyen = Info.quyen;
            var data = abc.tracuuhoadon(null, null, "1/001", "K23TPP", tungay, denngay, tuso, denso, 1, 1000, "PY");
            return PartialView(data);
        }
        [HttpPost]
        [Authorize(Roles = "QUANLYWS")]
        public ActionResult CheckimportdanhmuchopdongWS(string macn, string makh, string mahd)
        {
            //var Info = GetInfo();
            var tv = new TBL_DANHMUCHOPDONG_WS();
            tv = PhuYen.TBL_DANHMUCHOPDONG_WS.SingleOrDefault(n => n.MACN == macn && n.MAKH == makh && n.MAHD == mahd);

            if (tv != null)
            {
                return Json("0");
            }
            else
            {
                return Json("1");
            }
        }
        [Authorize(Roles = "KINHDOANHWS")]
        [ActionName("phat-hanh-hoa-don-ws")]
        public ActionResult Phathanhhoadonws(string madh)
        {
            if (madh != null && madh != "")
            {
                var data1 = PhuYen.DTA_DONDATHANG_WS.Where(n => n.MADH == madh);
                foreach (var i in data1)
                {
                    i.DUYETDH = true;
                    i.NGAYTHUCHIEN = null;
                }
                PhuYen.SaveChanges();
            }
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            ViewBag.madh = madh;
            var makh = PhuYen.TBL_DANHMUCHOPDONG_WS.Select(n => n.MAKH).Distinct().ToList();
            var strkh = string.Format("SELECT makh AS MAKH, donvi AS DONVI, diachi AS DIACHI,tennguoigd,masothue,email,taikhoan,nganhang,matinh as MATINH from TBL_DANHMUCKHACHHANG where makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            var data = new ListDataHoaDonWS { ListKH = PhuYen.Database.SqlQuery<ListKhachHang>(strkh).ToList(), ListHH = PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3,DVT,DVT1,DVT2 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList(), ListDDH = (madh != null) ? PhuYen.DTA_DONDATHANG_WS.Where(n => n.MADH == madh).ToList() : null };
            return View("Phathanhhoadonws", data);
        }

        [ActionName("tra-cuu-hoa-don")]
        public ActionResult tracuuhoadon()
        {
            var listdata = new List<Item>();
            var list = "HN,PT,TB,TNG,HP,HCM,CT,AG,CM,DN,LD,TG,TN,VL,BDG,BT,PY,QN,BD,DNA,GL,HUE,NA,NT,THO".Split(',').ToList();
            foreach (var i in list)
            {
                var z = i;
                if (i == "DNA")
                {
                    z = "DA";
                }
                else if (i == "HUE")
                {
                    z = "HU";

                }
                else if (i == "HCM")
                {
                    z = "SG";

                }
                else if (i == "BDG")
                {
                    z = "BG";
                }
                else if (i == "TNG")
                {
                    z = "TN";
                }
                else if (i == "TN")
                {
                    z = "TA";
                }
                else if (i == "THO")
                {
                    z = "TH";
                }
                listdata.AddRange(abc.tracuuhoadon(null, null, "1/001", (i == "DNA") ? "C23T" : "K23T" + z, "01/09/2023", "29/09/2023", null, null, 1, 1000, i).Item);
            }
            IExportEngine engine = new ExcelExportEngine();
            engine.AddData(listdata);
            MemoryStream memory = engine.Export();
            GC.Collect();
            return File(memory, "text/csv", "DATAHANGHOA-KHACHHANG-THANG.csv");
        }
        [Authorize(Roles = "DONHANGWS")]
        [ActionName("tao-don-dat-hang-ws")]
        public ActionResult Taodonhangws()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var makh = Info.TBL_DANHMUCPHANQUYENWS.makh.Split(',').ToList();
            var strkh = string.Format("SELECT makh AS MAKH, donvi AS DONVI, diachi AS DIACHI from TBL_DANHMUCKHACHHANG where makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            ListDataWS Data = new ListDataWS { ListHopdong = PhuYen.TBL_DANHMUCHOPDONG_WS.Where(n => makh.Contains(n.MAKH)).ToList(), ListKH = PhuYen.Database.SqlQuery<ListKhachHang>(strkh).ToList() };
            return View("Taodonhangws", Data);
        }
        [Authorize(Roles = "DONHANGWS")]
        [ActionName("tao-don-dat-hang-ws-mobile")]
        public ActionResult Taodonhangwsmobile()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var makh = Info.TBL_DANHMUCPHANQUYENWS.makh.Split(',').ToList();
            var strkh = string.Format("SELECT makh AS MAKH, donvi AS DONVI, diachi AS DIACHI from TBL_DANHMUCKHACHHANG where makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            ListDataWS Data = new ListDataWS { ListHopdong = PhuYen.TBL_DANHMUCHOPDONG_WS.Where(n => makh.Contains(n.MAKH)).ToList(), ListKH = PhuYen.Database.SqlQuery<ListKhachHang>(strkh).ToList() };
            return View("Taodonhangwsmobile", Data);
        }
        [Authorize(Roles = "DONHANGKD")]
        [ActionName("tao-don-dat-hang-ve-phong-kinh-doanh-mobile")]
        public ActionResult Taodonhangkdmobile()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var makh = Info.TBL_DANHMUCPHANQUYENKD.makh.Split(',').ToList();
            var strkh = string.Format("SELECT makh AS MAKH, donvi AS DONVI, diachi AS DIACHI from TBL_DANHMUCKHACHHANG where makh IN ({0})", string.Join(",", makh.Select(p => "'" + p + "'")));
            var list = PhuYen.TBL_DANHMUCHOPDONGCHUNG.ToList();
            var hdchung = PhuYen.Database.SqlQuery<ListHopdongKD>(string.Format("select MAHD AS MAHOPDONG, noidung AS TENHOPDONG, CAST(ck AS INT) AS ck from TBL_DANHMUCHOPDONG where mahd IN ({0}) and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'", string.Join(",", list.Select(p => "'" + p.MAHD + "'")))).ToList();
            if (makh.Count() == 1)
            {
                ListDataKD Data = new ListDataKD { ListHopdong = PhuYen.Database.SqlQuery<ListHopdongKD>("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG from TBL_DANHMUCHOPDONG where makh = '" + Info.TBL_DANHMUCPHANQUYENKD.makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").Concat(hdchung).Distinct().ToList(), ListKH = PhuYen.Database.SqlQuery<ListKhachHang>(strkh).ToList() };
                return View("Taodonhangkdmobile", Data);
            }
            else
            {
                ListDataKD Data = new ListDataKD { ListHopdong = null, ListKH = PhuYen.Database.SqlQuery<ListKhachHang>(strkh).ToList() };
                return View("Taodonhangkdmobile", Data);
            }
        }
        [Authorize(Roles = "DONHANGKD")]
        [ActionName("quan-ly-don-hang-ve-phong-kinh-doanh")]
        public ActionResult Quanlydonhangkd()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            ViewBag.nguoitao = db2.TBL_DANHMUCPHANQUYENKD.Where(n => n.quyen == "TDV").Select(cl => new NGUOIDUNG { TAIKHOAN = cl.taikhoan, HOVATEN = cl.TBL_DANHMUCNGUOIDUNG.hoten });
            return View("Quanlydonhangkd", DATATH1.TBL_DANHMUCTINH.ToList());

        }
        [Authorize(Roles = "DONHANGWS,KINHDOANHWS")]
        [ActionName("quan-ly-don-hang-ws")]
        public ActionResult Quanlydonhangws()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            ViewBag.nguoitao = db2.TBL_DANHMUCPHANQUYENWS.Where(n => n.quyen == "TDV").Select(cl => new NGUOIDUNG { TAIKHOAN = cl.taikhoan, HOVATEN = cl.TBL_DANHMUCNGUOIDUNG.hoten });
            return View("Quanlydonhangws", DATATH1.TBL_DANHMUCTINH.ToList());

        }
        [Authorize(Roles = "DONHANGHCM")]
        [ActionName("quan-ly-don-hang-ve-hcm")]
        public ActionResult Quanlydonhanghcm()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            ViewBag.nguoitao = db2.TBL_DANHMUCPHANQUYENHCM.Where(n => n.quyen == "TDV").Select(cl => new NGUOIDUNG { TAIKHOAN = cl.taikhoan, HOVATEN = cl.TBL_DANHMUCNGUOIDUNG.hoten });
            return View("Quanlydonhanghcm", DATATH1.TBL_DANHMUCTINH.ToList());
        }
        [Authorize(Roles = "DONHANGSC")]
        [ActionName("quan-ly-don-hang-ve-sc")]
        public ActionResult Quanlydonhangsc()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            ViewBag.nguoitao = db2.TBL_DANHMUCPHANQUYENSC.Where(n => n.quyen == "TDV").Select(cl => new NGUOIDUNG { TAIKHOAN = cl.taikhoan, HOVATEN = cl.TBL_DANHMUCNGUOIDUNG.hoten });
            return View("Quanlydonhangsc", DATATH1.TBL_DANHMUCTINH.ToList());
        }
        [Authorize(Roles = "QLKHKD")]
        [ActionName("quan-ly-khach-hang-kinh-doanh")]
        public ActionResult QLKHKD()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var list = PhuYen.TBL_DANHMUCHOPDONGCHUNG.ToList();
            var data = new QLKHKD() { nguoidung = db2.TBL_DANHMUCPHANQUYENKD.Where(n => n.quyen != "QUANLY"), hopdong = SC.Database.SqlQuery<ListHopdongKD>(string.Format("select MAHD AS MAHOPDONG, noidung AS TENHOPDONG, CAST(ck AS INT) AS ck,NGAYBATDAU AS ngaybatdau,NGAYKETTHUC AS ngayketthuc from TBL_DANHMUCHOPDONG where mahd IN ({0})", string.Join(",", list.Select(p => "'" + p.MAHD + "'")))).ToList() };

            return View("QLKHKD", data);
        }
        [Authorize(Roles = "QLKHSC")]
        [ActionName("quan-ly-khach-hang-sc")]
        public ActionResult QLKHSC()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var list = SC.TBL_DANHMUCHOPDONGCHUNG.ToList();
            var data = new QLKHSC() { nguoidung = db2.TBL_DANHMUCPHANQUYENSC.Where(n => n.quyen != "QUANLY"), hopdong = SC.Database.SqlQuery<ListHopdongKD>(string.Format("select MAHD AS MAHOPDONG, noidung AS TENHOPDONG, CAST(ck AS INT) AS ck,NGAYBATDAU AS ngaybatdau,NGAYKETTHUC AS ngayketthuc from TBL_DANHMUCHOPDONG where mahd IN ({0})", string.Join(",", list.Select(p => "'" + p.MAHD + "'")))).ToList() };

            return View("QLKHSC", data);
        }
        [Authorize(Roles = "QLKHHCM")]
        [ActionName("quan-ly-khach-hang-hcm")]
        public ActionResult QLKHHCM()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var data = db2.TBL_DANHMUCPHANQUYENHCM.Where(n => n.quyen != "QUANLY").ToList();
            return View("QLKHHCM", data);
        }
        [HttpPost]
        public ActionResult PartialViewQLDHKD(string taikhoan)
        {
            var data = db2.TBL_DANHMUCPHANQUYENKD.Single(n => n.taikhoan == taikhoan);
            var listkh = data.makh.Split(',').ToList();
            var stringsql = string.Format("select makh as MAKH, donvi AS DONVI from TBL_DANHMUCKHACHHANG where makh in ({0})", string.Join(",", listkh.Select(p => "'" + p + "'")));
            var kh = PhuYen.Database.SqlQuery<Khachhang>(stringsql).ToList();
            var export = new ViewQLDHKD { khachhang = kh, hoten = data.TBL_DANHMUCNGUOIDUNG.hoten, chinhanh = data.macn, taikhoan = data.taikhoan };
            return PartialView(export);
        }
        [HttpPost]
        public ActionResult PartialViewQLDHHCM(string taikhoan)
        {
            var data = db2.TBL_DANHMUCPHANQUYENHCM.Single(n => n.taikhoan == taikhoan);
            var listkh = data.makh.Split(',').ToList();
            var stringsql = string.Format("select makh as MAKH, donvi AS DONVI from TBL_DANHMUCKHACHHANG where makh in ({0})", string.Join(",", listkh.Select(p => "'" + p + "'")));
            var kh = HoChiMinh.Database.SqlQuery<Khachhang>(stringsql).ToList();
            var export = new ViewQLDHKD { khachhang = kh, hoten = data.TBL_DANHMUCNGUOIDUNG.hoten, chinhanh = data.macn, taikhoan = data.taikhoan };
            return PartialView(export);
        }
        [HttpPost]
        public ActionResult PartialViewQLDHSC(string taikhoan)
        {
            var data = db2.TBL_DANHMUCPHANQUYENSC.Single(n => n.taikhoan == taikhoan);
            var listkh = data.makh.Split(',').ToList();
            var stringsql = string.Format("select makh as MAKH, donvi AS DONVI from TBL_DANHMUCKHACHHANG where makh in ({0})", string.Join(",", listkh.Select(p => "'" + p + "'")));
            var kh = SC.Database.SqlQuery<Khachhang>(stringsql).ToList();
            var export = new ViewQLDHKD { khachhang = kh, hoten = data.TBL_DANHMUCNGUOIDUNG.hoten, chinhanh = data.macn, taikhoan = data.taikhoan };
            return PartialView(export);
        }
        [HttpPost]
        public ActionResult HuyHoadonWS(string kyhieu, string sohdnb)
        {
            var tv = PhuYen.DTA_HOADON_XUAT.SingleOrDefault(n => n.SoHD == sohdnb && kyhieu == kyhieu);
            if (tv != null)
            {
                var stringsql = "select ngaykhoa from DTA_KHOA_KETOAN WHERE THANG=" + tv.NgayLapHD.Month + " AND NAM =" + tv.NgayLapHD.Year + " AND MACN='PY'";
                var khoa = PhuYen.Database.SqlQuery<DateTime>(stringsql).ToList();


                if (khoa.Count() > 0)
                {
                    return Json("Ngày " + tv.NgayLapHD.ToString("dd/MM/yyyy") + " đã khóa sổ !!!!!");
                }
                else if (tv.kt == true)
                {
                    return Json("Hóa đơn này đã được cập nhật qua kế toán !!!!!");
                }
                else
                {
                    var result = abc.huyhoadondaphathanh(sohdnb, "PY");
                    if (result.Status == 1)
                    {
                        return Json(1);
                    }
                    else
                    {
                        return Json(result.Message);
                    }
                }

            }
            else
            {
                return Json("Không tìm thấy hóa đơn");
            }
        }
        [HttpPost]
        public ActionResult TuchoidonhangWS(string madh, string lydo)
        {
            var tv = PhuYen.DTA_DONDATHANG_WS.Where(n => n.MADH == madh);
            foreach (var i in tv)
            {
                i.DUYETDH = null;
                i.NGAYTHUCHIEN = DateTime.Now;
                i.GHICHU = i.GHICHU + " - Lý do từ chối : " + lydo;
            }
            PhuYen.SaveChanges();
            return Json(1);
        }
        [HttpPost]
        public ActionResult Deletehopdongchungsc(string mahd)
        {
            var tv = SC.TBL_DANHMUCHOPDONGCHUNG.SingleOrDefault(n => n.MAHD == mahd);
            if (tv != null)
            {
                SC.TBL_DANHMUCHOPDONGCHUNG.Remove(tv);
                SC.SaveChanges();
            }
            return Json(0);
        }
        [HttpPost]
        public ActionResult Addhopdongchungsc(string mahd)
        {
            SC.TBL_DANHMUCHOPDONGCHUNG.Add(new TBL_DANHMUCHOPDONGCHUNG { MAHD = mahd });
            SC.SaveChanges();
            return Json(0);
        }
        [HttpPost]
        public ActionResult Deletehopdongchungkd(string mahd)
        {
            var tv = PhuYen.TBL_DANHMUCHOPDONGCHUNG.SingleOrDefault(n => n.MAHD == mahd);
            if (tv != null)
            {
                PhuYen.TBL_DANHMUCHOPDONGCHUNG.Remove(tv);
                PhuYen.SaveChanges();
            }
            return Json(0);
        }
        [HttpPost]
        public ActionResult Addhopdongchungkd(string mahd)
        {
            PhuYen.TBL_DANHMUCHOPDONGCHUNG.Add(new TBL_DANHMUCHOPDONGCHUNG { MAHD = mahd });
            PhuYen.SaveChanges();
            return Json(0);
        }
        [HttpPost]
        public ActionResult Adddonhang(List<DTA_GIAOHANG> data)
        {
            var info = GetInfo();
            if (data.First().taikhoan == null)
            {
                data.ForEach(s => { s.ngay = DateTime.Today; s.taikhoanphan = User.Identity.Name; s.taikhoan = info.nguoidung; s.nguoigiaohang = info.hoten; s.macn = info.macn; });
            }
            else
            {
                data.ForEach(s => { s.ngay = DateTime.Today; s.taikhoanphan = User.Identity.Name; s.macn = info.macn; });
            }

            db2.DTA_GIAOHANG.AddRange(data);
            db2.SaveChanges();
            return Json(0);
        }
        [HttpPost]
        public ActionResult Deletedonhang(string sohd)
        {
            var info = GetInfo();
            var tv = db2.DTA_GIAOHANG.SingleOrDefault(n => n.macn == info.macn && n.sohd == sohd);
            db2.DTA_GIAOHANG.Remove(tv);
            db2.SaveChanges();
            return Json(0);
        }
        [HttpPost]
        public ActionResult Updatedonhang(string sohd, int loai, string lido)
        {

            var info = GetInfo();
            var tv = db2.DTA_GIAOHANG.SingleOrDefault(n => n.macn == info.macn && n.sohd == sohd);
            if (tv != null)
            {
                if (loai == 1)
                {
                    tv.ngaygiaohang = DateTime.Now;
                    tv.giaohang = true;
                }
                else if (loai == 2)
                {
                    tv.thutien = true;
                }
                else if (loai == 0)
                {
                    tv.giaohang = false;
                    tv.ngaygiaohang = DateTime.Now;
                    tv.lido = lido;
                }
                db2.SaveChanges();
                return Json(0);
            }
            else
            {
                return Json(1);
            }
        }
        [HttpPost]
        public ActionResult PartialEditQLDHKD(string taikhoan)
        {
            var data = db2.TBL_DANHMUCPHANQUYENKD.Single(n => n.taikhoan == taikhoan);
            var listkh = data.makh.Split(',').ToList();
            var stringsql = string.Format("select makh as MAKH, donvi AS DONVI from TBL_DANHMUCKHACHHANG where makh in ({0})", string.Join(",", listkh.Select(p => "'" + p + "'")));
            var kh = PhuYen.Database.SqlQuery<Khachhang>(stringsql).ToList();
            var export = new ViewQLDHKD { khachhang = kh, hoten = data.TBL_DANHMUCNGUOIDUNG.hoten, chinhanh = data.macn, taikhoan = data.taikhoan };
            return PartialView(export);
        }
        [HttpPost]
        public ActionResult PartialEditQLDHHCM(string taikhoan)
        {
            var data = db2.TBL_DANHMUCPHANQUYENHCM.Single(n => n.taikhoan == taikhoan);
            var listkh = data.makh.Split(',').ToList();
            var stringsql = string.Format("select makh as MAKH, donvi AS DONVI from TBL_DANHMUCKHACHHANG where makh in ({0})", string.Join(",", listkh.Select(p => "'" + p + "'")));
            var kh = HoChiMinh.Database.SqlQuery<Khachhang>(stringsql).ToList();
            var export = new ViewQLDHKD { khachhang = kh, hoten = data.TBL_DANHMUCNGUOIDUNG.hoten, chinhanh = data.macn, taikhoan = data.taikhoan };
            return PartialView(export);
        }
        [HttpPost]
        public ActionResult PartialEditQLDHSC(string taikhoan)
        {
            var data = db2.TBL_DANHMUCPHANQUYENSC.Single(n => n.taikhoan == taikhoan);
            var listkh = data.makh.Split(',').ToList();
            var stringsql = string.Format("select makh as MAKH, donvi AS DONVI from TBL_DANHMUCKHACHHANG where makh in ({0})", string.Join(",", listkh.Select(p => "'" + p + "'")));
            var kh = SC.Database.SqlQuery<Khachhang>(stringsql).ToList();
            var export = new ViewQLDHKD { khachhang = kh, hoten = data.TBL_DANHMUCNGUOIDUNG.hoten, chinhanh = data.macn, taikhoan = data.taikhoan };
            return PartialView(export);
        }
        [Authorize(Roles = "DONHANGWS")]
        [ActionName("in-don-dat-hang-ws")]
        public ActionResult Indonhangws(string madh)
        {
            var listdh = madh.Split(',').ToList();
            var data = PhuYen.DTA_DONDATHANG_WS.Where(n => madh.Contains(n.MADH)).ToList();

            return View("/Views/Order/PDFVIEWER.cshtml", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(null)) });

            //}

        }
        //[Authorize(Roles = "DONHANGWS")]
        //[ActionName("in-phieu-xuat-kho-ws")]
        //public ActionResult Inphieuxuatkhows(string sohdnb,string kyhieu)
        //{

        //    return View("/Views/Order/PDFVIEWER.cshtml", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(null)) });

        //}
        [Authorize(Roles = "DONHANGKD")]
        [ActionName("in-don-dat-hang-kd")]
        public ActionResult Indonhangkd(string madh, int loai)
        {
            var listdh = madh.Split(',').ToList();

            var data = PhuYen.DTA_DONDATHANG_KD.Where(n => madh.Contains(n.MADH)).ToList();
            var macn = data.FirstOrDefault().MACH;
            var taikhoan = data.FirstOrDefault().USERTAO;
            string tencn = "";
            try
            {
                tencn = db2.TBL_DANHSACHCHINHANH.SingleOrDefault(n => n.macn == macn).Tencn;
            }
            catch (Exception)
            {
                tencn = "N/A";
            }
            if (loai == 1)
            {
                BIEUMAU_DONDATHANG_KD rpt = new BIEUMAU_DONDATHANG_KD();
                rpt.Load();
                rpt.SetDataSource(data.Select(cl => new DTA_DONDATHANGKD_IN { MADH = cl.MADH, DVT = cl.DVT, DATE = cl.DATE, MAHH = cl.MAHH, GIABAN_VAT = (decimal)cl.GIABAN_VAT, HOPDONG = cl.HOPDONG, SOLUONG = (decimal)cl.SOLUONG, TENHH = cl.TENHH, NgayDat = cl.NgayDat }).ToList());
                rpt.SetParameterValue("chinhanh", tencn);
                var chuky = db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == taikhoan);
                rpt.SetParameterValue("giamdoccn", System.Web.Hosting.HostingEnvironment.MapPath(chuky.TBL_DANHMUCCHUKYCN.url));
                rpt.SetParameterValue("nguoidutru", System.Web.Hosting.HostingEnvironment.MapPath(chuky.url));
                rpt.SetParameterValue("tengiamdoccn", chuky.TBL_DANHMUCCHUKYCN.hoten);
                rpt.SetParameterValue("tennguoidutru", chuky.hoten);
                try
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath(db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == User.Identity.Name.ToUpper()).url));
                }
                catch
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath("~/Content/CHUKY/NULL.png"));
                }
                if (chuky.macn == "TT423")
                {
                    rpt.SetParameterValue("labelgiamdoc", "Trưởng trung tâm");
                }
                else
                {
                    rpt.SetParameterValue("labelgiamdoc", "Giám đốc CN");
                }
                var quyen = db2.TBL_DANHMUCPHANQUYENKD.SingleOrDefault(n => n.taikhoan.ToUpper() == User.Identity.Name.ToUpper());

                if (quyen != null)
                {
                    try
                    {
                        if (quyen.quyen == "QUANLY")
                        {
                            var hoten = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToUpper() == User.Identity.Name.ToUpper());
                            rpt.SetParameterValue("tennguoixuly", hoten.hoten);
                        }
                        else
                        {
                            rpt.SetParameterValue("tennguoixuly", " ");
                        }
                    }
                    catch (Exception)
                    {

                        rpt.SetParameterValue("tennguoixuly", " ");

                    }

                }
                Stream s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                return View("/Views/Order/PDFVIEWER.cshtml", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });
            }
            else
            {
                BIEUMAU_DONDATHANG_KD1 rpt = new BIEUMAU_DONDATHANG_KD1();
                rpt.Load();
                rpt.SetDataSource(data.Select(cl => new DTA_DONDATHANGKD_IN { MADH = cl.MADH, DVT = cl.DVT, DATE = cl.DATE, MAHH = cl.MAHH, GIABAN_VAT = (decimal)cl.GIABAN_VAT, HOPDONG = cl.HOPDONG, SOLUONG = (decimal)cl.SOLUONG, TENHH = cl.TENHH, NgayDat = cl.NgayDat }).ToList());
                rpt.SetParameterValue("chinhanh", tencn);
                var chuky = db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == taikhoan);
                rpt.SetParameterValue("giamdoccn", System.Web.Hosting.HostingEnvironment.MapPath(chuky.TBL_DANHMUCCHUKYCN.url));
                rpt.SetParameterValue("nguoidutru", System.Web.Hosting.HostingEnvironment.MapPath(chuky.url));
                rpt.SetParameterValue("tengiamdoccn", chuky.TBL_DANHMUCCHUKYCN.hoten);
                rpt.SetParameterValue("tennguoidutru", chuky.hoten);
                try
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath(db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == User.Identity.Name.ToUpper()).url));
                }
                catch
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath("~/Content/CHUKY/NULL.png"));
                }
                if (chuky.macn == "TT423")
                {
                    rpt.SetParameterValue("labelgiamdoc", "Trưởng trung tâm");
                }
                else
                {
                    rpt.SetParameterValue("labelgiamdoc", "Giám đốc CN");
                }
                var quyen = db2.TBL_DANHMUCPHANQUYENKD.SingleOrDefault(n => n.taikhoan.ToUpper() == User.Identity.Name.ToUpper());

                if (quyen != null)
                {
                    try
                    {
                        if (quyen.quyen == "QUANLY")
                        {
                            var hoten = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToUpper() == User.Identity.Name.ToUpper());
                            rpt.SetParameterValue("tennguoixuly", hoten.hoten);
                        }
                        else
                        {
                            rpt.SetParameterValue("tennguoixuly", " ");
                        }
                    }
                    catch (Exception)
                    {

                        rpt.SetParameterValue("tennguoixuly", " ");

                    }

                }
                //if (User.Identity.Name.ToUpper() == "PY.VIANH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Nguyễn Hoàng Vĩ Anh");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.HONG")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Hoàng Thị Ánh Hồng");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.QUYNH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Trần Thị Thảo Quỳnh");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.DANGKHOA")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Phạm Đăng Khoa");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.TRAM")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Đỗ Thị Ngọc Trâm");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.TINH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Lê Minh Tính");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.THICH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Nguyễn Đình Thích");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.THU")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Nguyễn Thị Ánh Thư");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.DIEN")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Nguyễn Thị Điền");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.HANH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Lê Thị Hạnh");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.MYHANH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Bùi Thị Mỹ Hạnh");
                //}
                //else
                //{
                //    rpt.SetParameterValue("tennguoixuly", " ");
                //}
                Stream s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                return View("/Views/Order/PDFVIEWER.cshtml", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });
            }

        }
        [Authorize(Roles = "DONHANGKD")]
        [ActionName("in-don-dat-hang-kd-khu-vuc")]
        public ActionResult Indonhangkdkhuvuc(string madh, int loai)
        {
            var listdh = madh.Split(',').ToList();

            var data = PhuYen.DTA_DONDATHANG_KD.Where(n => listdh.Contains(n.MADH)).ToList();
            var makh = data.FirstOrDefault().MAKH;
            var taikhoan = data.FirstOrDefault().USERTAO;
            var stringsql = string.Format("select makh as MAKH, donvi AS DONVI, matinh from TBL_DANHMUCKHACHHANG where makh = '" + makh + "'");
            var makhuvuc = PhuYen.Database.SqlQuery<Khachhang>(stringsql).FirstOrDefault().matinh;

            if (loai == 1)
            {
                BIEUMAU_DONDATHANG_KD_KHUVUC rpt = new BIEUMAU_DONDATHANG_KD_KHUVUC();
                rpt.Load();
                rpt.SetDataSource(data.Select(cl => new DTA_DONDATHANGKD_IN { MADH = cl.MADH, HOPDONG = cl.HOPDONG, GIABAN_VAT = (decimal)cl.GIABAN_VAT, DVT = cl.DVT, DATE = cl.DATE, MAHH = cl.MAHH, SOLUONG = (decimal)cl.SOLUONG, STT = (int)cl.STT, TENHH = cl.TENHH, DONVI = cl.DONVI, MAKH = cl.MAKH, NgayDat = cl.NgayDat }).ToList());
                try
                {
                    rpt.SetParameterValue("chinhanh", "KHU VỰC " + db2.KhuVucs.SingleOrDefault(n => n.MaKhuVuc == makhuvuc).TenKhuVuc.ToUpper());
                }
                catch (Exception)
                {
                    rpt.SetParameterValue("chinhanh", "KHU VỰC N/A");
                }
                var chuky = db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == taikhoan);
                rpt.SetParameterValue("nguoidutru", System.Web.Hosting.HostingEnvironment.MapPath(chuky.url));
                rpt.SetParameterValue("tennguoidutru", chuky.hoten);
                rpt.SetParameterValue("giamdoccn", System.Web.Hosting.HostingEnvironment.MapPath(chuky.TBL_DANHMUCCHUKYCN.url));

                rpt.SetParameterValue("tengiamdoccn", chuky.TBL_DANHMUCCHUKYCN.hoten);
                try
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath(db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == User.Identity.Name.ToUpper()).url));
                }
                catch
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath("~/Content/CHUKY/NULL.png"));
                }
                if (chuky.macn == "TT423")
                {
                    rpt.SetParameterValue("labelgiamdoc", "Trưởng trung tâm");
                }
                else
                {
                    rpt.SetParameterValue("labelgiamdoc", "Giám đốc CN");
                }
                var quyen = db2.TBL_DANHMUCPHANQUYENKD.SingleOrDefault(n => n.taikhoan.ToUpper() == User.Identity.Name.ToUpper());

                if (quyen != null)
                {
                    try
                    {
                        if (quyen.quyen == "QUANLY")
                        {
                            var hoten = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToUpper() == User.Identity.Name.ToUpper());
                            rpt.SetParameterValue("tennguoixuly", hoten.hoten);
                        }
                        else
                        {
                            rpt.SetParameterValue("tennguoixuly", " ");
                        }
                    }
                    catch (Exception)
                    {

                        rpt.SetParameterValue("tennguoixuly", " ");

                    }

                }

                Stream s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                return View("/Views/Order/PDFVIEWER.cshtml", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });
            }
            else
            {
                BIEUMAU_DONDATHANG_KD_KHUVUC1 rpt = new BIEUMAU_DONDATHANG_KD_KHUVUC1();
                rpt.Load();
                rpt.SetDataSource(data.Select(cl => new DTA_DONDATHANGKD_IN { MADH = cl.MADH, HOPDONG = cl.HOPDONG, GIABAN_VAT = (decimal)cl.GIABAN_VAT, DVT = cl.DVT, DATE = cl.DATE, MAHH = cl.MAHH, SOLUONG = (decimal)cl.SOLUONG, STT = (int)cl.STT, TENHH = cl.TENHH, DONVI = cl.DONVI, MAKH = cl.MAKH, NgayDat = cl.NgayDat }).ToList());
                try
                {
                    rpt.SetParameterValue("chinhanh", "KHU VỰC " + db2.KhuVucs.SingleOrDefault(n => n.MaKhuVuc == makhuvuc).TenKhuVuc.ToUpper());
                }
                catch (Exception)
                {
                    rpt.SetParameterValue("chinhanh", "KHU VỰC N/A");
                }
                var chuky = db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == taikhoan);
                rpt.SetParameterValue("nguoidutru", System.Web.Hosting.HostingEnvironment.MapPath(chuky.url));
                rpt.SetParameterValue("tennguoidutru", chuky.hoten);
                rpt.SetParameterValue("giamdoccn", System.Web.Hosting.HostingEnvironment.MapPath(chuky.TBL_DANHMUCCHUKYCN.url));
                rpt.SetParameterValue("tengiamdoccn", chuky.TBL_DANHMUCCHUKYCN.hoten);
                try
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath(db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == User.Identity.Name.ToUpper()).url));
                }
                catch
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath("~/Content/CHUKY/NULL.png"));
                }
                if (chuky.macn == "TT423")
                {
                    rpt.SetParameterValue("labelgiamdoc", "Trưởng trung tâm");
                }
                else
                {
                    rpt.SetParameterValue("labelgiamdoc", "Giám đốc CN");
                }
                var quyen = db2.TBL_DANHMUCPHANQUYENKD.SingleOrDefault(n => n.taikhoan.ToUpper() == User.Identity.Name.ToUpper());

                if (quyen != null)
                {
                    try
                    {
                        if (quyen.quyen == "QUANLY")
                        {
                            var hoten = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToUpper() == User.Identity.Name.ToUpper());
                            rpt.SetParameterValue("tennguoixuly", hoten.hoten);
                        }
                        else
                        {
                            rpt.SetParameterValue("tennguoixuly", " ");
                        }
                    }
                    catch (Exception)
                    {

                        rpt.SetParameterValue("tennguoixuly", " ");

                    }

                }

                Stream s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                return View("/Views/Order/PDFVIEWER.cshtml", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });
            }
        }
        [Authorize(Roles = "DONHANGHCM")]
        [ActionName("in-don-dat-hang-hcm")]
        public ActionResult Indonhanghcm(string madh, int loai)
        {
            var listdh = madh.Split(',').ToList();

            var data = HoChiMinh.DTA_DONDATHANG_KD.Where(n => madh.Contains(n.MADH)).ToList();
            var macn = data.FirstOrDefault().MACH;
            var taikhoan = data.FirstOrDefault().USERTAO;
            string tencn = "";
            try
            {
                tencn = db2.TBL_DANHSACHCHINHANH.SingleOrDefault(n => n.macn == macn).Tencn;
            }
            catch (Exception)
            {
                tencn = "N/A";
            }
            if (loai == 1)
            {
                BIEUMAU_DONDATHANG_KD rpt = new BIEUMAU_DONDATHANG_KD();
                rpt.Load();
                rpt.SetDataSource(data.Select(cl => new DTA_DONDATHANGKD_IN { MADH = cl.MADH, DVT = cl.DVT, DATE = cl.DATE, MAHH = cl.MAHH, GIABAN_VAT = (decimal)cl.GIABAN_VAT, HOPDONG = cl.HOPDONG, SOLUONG = (decimal)cl.SOLUONG, TENHH = cl.TENHH, NgayDat = cl.NgayDat }).ToList());
                rpt.SetParameterValue("chinhanh", tencn);
                var chuky = db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == taikhoan);
                rpt.SetParameterValue("giamdoccn", System.Web.Hosting.HostingEnvironment.MapPath(chuky.TBL_DANHMUCCHUKYCN.url));
                rpt.SetParameterValue("nguoidutru", System.Web.Hosting.HostingEnvironment.MapPath(chuky.url));
                rpt.SetParameterValue("tengiamdoccn", chuky.TBL_DANHMUCCHUKYCN.hoten);
                rpt.SetParameterValue("tennguoidutru", chuky.hoten);
                try
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath(db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == User.Identity.Name.ToUpper()).url));
                }
                catch
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath("~/Content/CHUKY/NULL.png"));
                }
                if (chuky.macn == "TT423")
                {
                    rpt.SetParameterValue("labelgiamdoc", "Trưởng trung tâm");
                }
                else
                {
                    rpt.SetParameterValue("labelgiamdoc", "Giám đốc CN");
                }
                var quyen = db2.TBL_DANHMUCPHANQUYENHCM.SingleOrDefault(n => n.taikhoan.ToUpper() == User.Identity.Name.ToUpper());

                if (quyen != null)
                {
                    try
                    {
                        if (quyen.quyen == "QUANLY")
                        {
                            var hoten = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToUpper() == User.Identity.Name.ToUpper());
                            rpt.SetParameterValue("tennguoixuly", hoten.hoten);
                        }
                        else
                        {
                            rpt.SetParameterValue("tennguoixuly", " ");
                        }
                    }
                    catch (Exception)
                    {

                        rpt.SetParameterValue("tennguoixuly", " ");

                    }

                }

                Stream s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                return View("/Views/Order/PDFVIEWER.cshtml", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });
            }
            else
            {
                BIEUMAU_DONDATHANG_KD1 rpt = new BIEUMAU_DONDATHANG_KD1();
                rpt.Load();
                rpt.SetDataSource(data.Select(cl => new DTA_DONDATHANGKD_IN { MADH = cl.MADH, DVT = cl.DVT, DATE = cl.DATE, MAHH = cl.MAHH, GIABAN_VAT = (decimal)cl.GIABAN_VAT, HOPDONG = cl.HOPDONG, SOLUONG = (decimal)cl.SOLUONG, TENHH = cl.TENHH, NgayDat = cl.NgayDat }).ToList());
                rpt.SetParameterValue("chinhanh", tencn);
                var chuky = db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == taikhoan);
                rpt.SetParameterValue("giamdoccn", System.Web.Hosting.HostingEnvironment.MapPath(chuky.TBL_DANHMUCCHUKYCN.url));
                rpt.SetParameterValue("nguoidutru", System.Web.Hosting.HostingEnvironment.MapPath(chuky.url));
                rpt.SetParameterValue("tengiamdoccn", chuky.TBL_DANHMUCCHUKYCN.hoten);
                rpt.SetParameterValue("tennguoidutru", chuky.hoten);
                try
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath(db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == User.Identity.Name.ToUpper()).url));
                }
                catch
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath("~/Content/CHUKY/NULL.png"));
                }
                if (chuky.macn == "TT423")
                {
                    rpt.SetParameterValue("labelgiamdoc", "Trưởng trung tâm");
                }
                else
                {
                    rpt.SetParameterValue("labelgiamdoc", "Giám đốc CN");
                }
                var quyen = db2.TBL_DANHMUCPHANQUYENHCM.SingleOrDefault(n => n.taikhoan.ToUpper() == User.Identity.Name.ToUpper());

                if (quyen != null)
                {
                    try
                    {
                        if (quyen.quyen == "QUANLY")
                        {
                            var hoten = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToUpper() == User.Identity.Name.ToUpper());
                            rpt.SetParameterValue("tennguoixuly", hoten.hoten);
                        }
                        else
                        {
                            rpt.SetParameterValue("tennguoixuly", " ");
                        }
                    }
                    catch (Exception)
                    {

                        rpt.SetParameterValue("tennguoixuly", " ");

                    }

                }

                Stream s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                return View("/Views/Order/PDFVIEWER.cshtml", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });
            }

        }
        [Authorize(Roles = "DONHANGHCM")]
        [ActionName("in-don-dat-hang-hcm-khu-vuc")]
        public ActionResult Indonhanghcmkhuvuc(string madh, int loai)
        {
            var listdh = madh.Split(',').ToList();

            var data = HoChiMinh.DTA_DONDATHANG_KD.Where(n => listdh.Contains(n.MADH)).ToList();
            var makh = data.FirstOrDefault().MAKH;
            var taikhoan = data.FirstOrDefault().USERTAO;
            var stringsql = string.Format("select makh as MAKH, donvi AS DONVI, matinh from TBL_DANHMUCKHACHHANG where makh = '" + makh + "'");
            var makhuvuc = HoChiMinh.Database.SqlQuery<Khachhang>(stringsql).FirstOrDefault().matinh;
            if (loai == 1)
            {
                BIEUMAU_DONDATHANG_KD_KHUVUC rpt = new BIEUMAU_DONDATHANG_KD_KHUVUC();
                rpt.Load();
                rpt.SetDataSource(data.Select(cl => new DTA_DONDATHANGKD_IN { MADH = cl.MADH, HOPDONG = cl.HOPDONG, GIABAN_VAT = (decimal)cl.GIABAN_VAT, DVT = cl.DVT, DATE = cl.DATE, MAHH = cl.MAHH, SOLUONG = (decimal)cl.SOLUONG, STT = (int)cl.STT, TENHH = cl.TENHH, DONVI = cl.DONVI, MAKH = cl.MAKH, NgayDat = cl.NgayDat }).ToList());
                try
                {
                    rpt.SetParameterValue("chinhanh", "KHU VỰC " + db2.KhuVucs.SingleOrDefault(n => n.MaKhuVuc == makhuvuc).TenKhuVuc.ToUpper());
                }
                catch (Exception)
                {
                    rpt.SetParameterValue("chinhanh", "KHU VỰC N/A");
                }
                var chuky = db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == taikhoan);
                rpt.SetParameterValue("nguoidutru", System.Web.Hosting.HostingEnvironment.MapPath(chuky.url));
                rpt.SetParameterValue("tennguoidutru", chuky.hoten);
                rpt.SetParameterValue("giamdoccn", System.Web.Hosting.HostingEnvironment.MapPath(chuky.TBL_DANHMUCCHUKYCN.url));

                rpt.SetParameterValue("tengiamdoccn", chuky.TBL_DANHMUCCHUKYCN.hoten);
                try
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath(db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == User.Identity.Name.ToUpper()).url));
                }
                catch
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath("~/Content/CHUKY/NULL.png"));
                }
                if (chuky.macn == "TT423")
                {
                    rpt.SetParameterValue("labelgiamdoc", "Trưởng trung tâm");
                }
                else
                {
                    rpt.SetParameterValue("labelgiamdoc", "Giám đốc CN");
                }
                var quyen = db2.TBL_DANHMUCPHANQUYENHCM.SingleOrDefault(n => n.taikhoan.ToUpper() == User.Identity.Name.ToUpper());

                if (quyen != null)
                {
                    try
                    {
                        if (quyen.quyen == "QUANLY")
                        {
                            var hoten = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToUpper() == User.Identity.Name.ToUpper());
                            rpt.SetParameterValue("tennguoixuly", hoten.hoten);
                        }
                        else
                        {
                            rpt.SetParameterValue("tennguoixuly", " ");
                        }
                    }
                    catch (Exception)
                    {

                        rpt.SetParameterValue("tennguoixuly", " ");

                    }

                }

                Stream s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                return View("/Views/Order/PDFVIEWER.cshtml", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });
            }
            else
            {
                BIEUMAU_DONDATHANG_KD_KHUVUC1 rpt = new BIEUMAU_DONDATHANG_KD_KHUVUC1();
                rpt.Load();
                rpt.SetDataSource(data.Select(cl => new DTA_DONDATHANGKD_IN { MADH = cl.MADH, HOPDONG = cl.HOPDONG, GIABAN_VAT = (decimal)cl.GIABAN_VAT, DVT = cl.DVT, DATE = cl.DATE, MAHH = cl.MAHH, SOLUONG = (decimal)cl.SOLUONG, STT = (int)cl.STT, TENHH = cl.TENHH, DONVI = cl.DONVI, MAKH = cl.MAKH, NgayDat = cl.NgayDat }).ToList());
                try
                {
                    rpt.SetParameterValue("chinhanh", "KHU VỰC " + db2.KhuVucs.SingleOrDefault(n => n.MaKhuVuc == makhuvuc).TenKhuVuc.ToUpper());
                }
                catch (Exception)
                {
                    rpt.SetParameterValue("chinhanh", "KHU VỰC N/A");
                }
                var chuky = db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == taikhoan);
                rpt.SetParameterValue("nguoidutru", System.Web.Hosting.HostingEnvironment.MapPath(chuky.url));
                rpt.SetParameterValue("tennguoidutru", chuky.hoten);
                rpt.SetParameterValue("giamdoccn", System.Web.Hosting.HostingEnvironment.MapPath(chuky.TBL_DANHMUCCHUKYCN.url));
                rpt.SetParameterValue("tengiamdoccn", chuky.TBL_DANHMUCCHUKYCN.hoten);
                try
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath(db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == User.Identity.Name.ToUpper()).url));
                }
                catch
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath("~/Content/CHUKY/NULL.png"));
                }
                if (chuky.macn == "TT423")
                {
                    rpt.SetParameterValue("labelgiamdoc", "Trưởng trung tâm");
                }
                else
                {
                    rpt.SetParameterValue("labelgiamdoc", "Giám đốc CN");
                }
                var quyen = db2.TBL_DANHMUCPHANQUYENHCM.SingleOrDefault(n => n.taikhoan.ToUpper() == User.Identity.Name.ToUpper());

                if (quyen != null)
                {
                    try
                    {
                        if (quyen.quyen == "QUANLY")
                        {
                            var hoten = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToUpper() == User.Identity.Name.ToUpper());
                            rpt.SetParameterValue("tennguoixuly", hoten.hoten);
                        }
                        else
                        {
                            rpt.SetParameterValue("tennguoixuly", " ");
                        }
                    }
                    catch (Exception)
                    {

                        rpt.SetParameterValue("tennguoixuly", " ");

                    }

                }

                Stream s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                return View("/Views/Order/PDFVIEWER.cshtml", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });
            }
        }
        [Authorize(Roles = "DONHANGSC")]
        [ActionName("in-don-dat-hang-sc")]
        public ActionResult Indonhangsc(string madh, int loai)
        {
            var listdh = madh.Split(',').ToList();

            var data = SC.DTA_DONDATHANG_KD.Where(n => madh.Contains(n.MADH)).ToList();
            var macn = data.FirstOrDefault().MACH;
            var taikhoan = data.FirstOrDefault().USERTAO;
            string tencn = "";
            try
            {
                tencn = db2.TBL_DANHSACHCHINHANH.SingleOrDefault(n => n.macn == macn).Tencn;
            }
            catch (Exception)
            {
                tencn = "N/A";
            }
            if (loai == 1)
            {
                BIEUMAU_DONDATHANG_KD rpt = new BIEUMAU_DONDATHANG_KD();
                rpt.Load();
                rpt.SetDataSource(data.Select(cl => new DTA_DONDATHANGKD_IN { MADH = cl.MADH, DVT = cl.DVT, DATE = cl.DATE, MAHH = cl.MAHH, GIABAN_VAT = (decimal)cl.GIABAN_VAT, HOPDONG = cl.HOPDONG, SOLUONG = (decimal)cl.SOLUONG, TENHH = cl.TENHH, NgayDat = cl.NgayDat }).ToList());
                rpt.SetParameterValue("chinhanh", tencn);
                var chuky = db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == taikhoan);
                rpt.SetParameterValue("giamdoccn", System.Web.Hosting.HostingEnvironment.MapPath(chuky.TBL_DANHMUCCHUKYCN.url));
                rpt.SetParameterValue("nguoidutru", System.Web.Hosting.HostingEnvironment.MapPath(chuky.url));
                rpt.SetParameterValue("tengiamdoccn", chuky.TBL_DANHMUCCHUKYCN.hoten);
                rpt.SetParameterValue("tennguoidutru", chuky.hoten);
                try
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath(db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == User.Identity.Name.ToUpper()).url));
                }
                catch
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath("~/Content/CHUKY/NULL.png"));
                }
                if (chuky.macn == "TT423")
                {
                    rpt.SetParameterValue("labelgiamdoc", "Trưởng trung tâm");
                }
                else
                {
                    rpt.SetParameterValue("labelgiamdoc", "Giám đốc CN");
                }
                var quyen = db2.TBL_DANHMUCPHANQUYENSC.SingleOrDefault(n => n.taikhoan.ToUpper() == User.Identity.Name.ToUpper());

                if (quyen != null)
                {
                    try
                    {
                        if (quyen.quyen == "QUANLY")
                        {
                            var hoten = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToUpper() == User.Identity.Name.ToUpper());
                            rpt.SetParameterValue("tennguoixuly", hoten.hoten);
                        }
                        else
                        {
                            rpt.SetParameterValue("tennguoixuly", " ");
                        }
                    }
                    catch (Exception)
                    {

                        rpt.SetParameterValue("tennguoixuly", " ");

                    }

                }

                Stream s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                return View("/Views/Order/PDFVIEWER.cshtml", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });
            }
            else
            {
                BIEUMAU_DONDATHANG_KD1 rpt = new BIEUMAU_DONDATHANG_KD1();
                rpt.Load();
                rpt.SetDataSource(data.Select(cl => new DTA_DONDATHANGKD_IN { MADH = cl.MADH, DVT = cl.DVT, DATE = cl.DATE, MAHH = cl.MAHH, GIABAN_VAT = (decimal)cl.GIABAN_VAT, HOPDONG = cl.HOPDONG, SOLUONG = (decimal)cl.SOLUONG, TENHH = cl.TENHH, NgayDat = cl.NgayDat }).ToList());
                rpt.SetParameterValue("chinhanh", tencn);
                var chuky = db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == taikhoan);
                rpt.SetParameterValue("giamdoccn", System.Web.Hosting.HostingEnvironment.MapPath(chuky.TBL_DANHMUCCHUKYCN.url));
                rpt.SetParameterValue("nguoidutru", System.Web.Hosting.HostingEnvironment.MapPath(chuky.url));
                rpt.SetParameterValue("tengiamdoccn", chuky.TBL_DANHMUCCHUKYCN.hoten);
                rpt.SetParameterValue("tennguoidutru", chuky.hoten);
                try
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath(db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == User.Identity.Name.ToUpper()).url));
                }
                catch
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath("~/Content/CHUKY/NULL.png"));
                }
                if (chuky.macn == "TT423")
                {
                    rpt.SetParameterValue("labelgiamdoc", "Trưởng trung tâm");
                }
                else
                {
                    rpt.SetParameterValue("labelgiamdoc", "Giám đốc CN");
                }
                var quyen = db2.TBL_DANHMUCPHANQUYENSC.SingleOrDefault(n => n.taikhoan.ToUpper() == User.Identity.Name.ToUpper());

                if (quyen != null)
                {
                    try
                    {
                        if (quyen.quyen == "QUANLY")
                        {
                            var hoten = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToUpper() == User.Identity.Name.ToUpper());
                            rpt.SetParameterValue("tennguoixuly", hoten.hoten);
                        }
                        else
                        {
                            rpt.SetParameterValue("tennguoixuly", " ");
                        }
                    }
                    catch (Exception)
                    {

                        rpt.SetParameterValue("tennguoixuly", " ");

                    }

                }

                Stream s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                return View("/Views/Order/PDFVIEWER.cshtml", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });
            }

        }
        [Authorize(Roles = "DONHANGSC")]
        [ActionName("in-don-dat-hang-sc-khu-vuc")]
        public ActionResult Indonhangsckhuvuc(string madh, int loai)
        {
            var listdh = madh.Split(',').ToList();

            var data = SC.DTA_DONDATHANG_KD.Where(n => listdh.Contains(n.MADH)).ToList();
            var makh = data.FirstOrDefault().MAKH;
            var taikhoan = data.FirstOrDefault().USERTAO;
            var stringsql = string.Format("select makh as MAKH, donvi AS DONVI, matinh from TBL_DANHMUCKHACHHANG where makh = '" + makh + "'");
            var makhuvuc = SC.Database.SqlQuery<Khachhang>(stringsql).FirstOrDefault().matinh;
            if (loai == 1)
            {
                BIEUMAU_DONDATHANG_KD_KHUVUC rpt = new BIEUMAU_DONDATHANG_KD_KHUVUC();
                rpt.Load();
                rpt.SetDataSource(data.Select(cl => new DTA_DONDATHANGKD_IN { MADH = cl.MADH, HOPDONG = cl.HOPDONG, GIABAN_VAT = (decimal)cl.GIABAN_VAT, DVT = cl.DVT, DATE = cl.DATE, MAHH = cl.MAHH, SOLUONG = (decimal)cl.SOLUONG, STT = (int)cl.STT, TENHH = cl.TENHH, DONVI = cl.DONVI, MAKH = cl.MAKH, NgayDat = cl.NgayDat }).ToList());
                try
                {
                    rpt.SetParameterValue("chinhanh", "KHU VỰC " + db2.KhuVucs.SingleOrDefault(n => n.MaKhuVuc == makhuvuc).TenKhuVuc.ToUpper());
                }
                catch (Exception)
                {
                    rpt.SetParameterValue("chinhanh", "KHU VỰC N/A");
                }
                var chuky = db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == taikhoan);
                rpt.SetParameterValue("nguoidutru", System.Web.Hosting.HostingEnvironment.MapPath(chuky.url));
                rpt.SetParameterValue("tennguoidutru", chuky.hoten);
                rpt.SetParameterValue("giamdoccn", System.Web.Hosting.HostingEnvironment.MapPath(chuky.TBL_DANHMUCCHUKYCN.url));

                rpt.SetParameterValue("tengiamdoccn", chuky.TBL_DANHMUCCHUKYCN.hoten);
                try
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath(db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == User.Identity.Name.ToUpper()).url));
                }
                catch
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath("~/Content/CHUKY/NULL.png"));
                }
                if (chuky.macn == "TT423")
                {
                    rpt.SetParameterValue("labelgiamdoc", "Trưởng trung tâm");
                }
                else
                {
                    rpt.SetParameterValue("labelgiamdoc", "Giám đốc CN");
                }
                var quyen = db2.TBL_DANHMUCPHANQUYENSC.SingleOrDefault(n => n.taikhoan.ToUpper() == User.Identity.Name.ToUpper());

                if (quyen != null)
                {
                    try
                    {
                        if (quyen.quyen == "QUANLY")
                        {
                            var hoten = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToUpper() == User.Identity.Name.ToUpper());
                            rpt.SetParameterValue("tennguoixuly", hoten.hoten);
                        }
                        else
                        {
                            rpt.SetParameterValue("tennguoixuly", " ");
                        }
                    }
                    catch (Exception)
                    {

                        rpt.SetParameterValue("tennguoixuly", " ");

                    }

                }
                //if (User.Identity.Name.ToUpper() == "PY.VIANH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Nguyễn Hoàng Vĩ Anh");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.HONG")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Hoàng Thị Ánh Hồng");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.QUYNH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Trần Thị Thảo Quỳnh");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.DANGKHOA")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Phạm Đăng Khoa");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.TRAM")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Đỗ Thị Ngọc Trâm");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.TINH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Lê Minh Tính");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.THICH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Nguyễn Đình Thích");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.THU")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Nguyễn Thị Ánh Thư");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.DIEN")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Nguyễn Thị Điền");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.HANH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Lê Thị Hạnh");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.MYHANH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Bùi Thị Mỹ Hạnh");
                //}
                //else
                //{
                //    rpt.SetParameterValue("tennguoixuly", " ");
                //}
                Stream s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                return View("/Views/Order/PDFVIEWER.cshtml", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });
            }
            else
            {
                BIEUMAU_DONDATHANG_KD_KHUVUC1 rpt = new BIEUMAU_DONDATHANG_KD_KHUVUC1();
                rpt.Load();
                rpt.SetDataSource(data.Select(cl => new DTA_DONDATHANGKD_IN { MADH = cl.MADH, HOPDONG = cl.HOPDONG, GIABAN_VAT = (decimal)cl.GIABAN_VAT, DVT = cl.DVT, DATE = cl.DATE, MAHH = cl.MAHH, SOLUONG = (decimal)cl.SOLUONG, STT = (int)cl.STT, TENHH = cl.TENHH, DONVI = cl.DONVI, MAKH = cl.MAKH, NgayDat = cl.NgayDat }).ToList());
                try
                {
                    rpt.SetParameterValue("chinhanh", "KHU VỰC " + db2.KhuVucs.SingleOrDefault(n => n.MaKhuVuc == makhuvuc).TenKhuVuc.ToUpper());
                }
                catch (Exception)
                {
                    rpt.SetParameterValue("chinhanh", "KHU VỰC N/A");
                }
                var chuky = db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == taikhoan);
                rpt.SetParameterValue("nguoidutru", System.Web.Hosting.HostingEnvironment.MapPath(chuky.url));
                rpt.SetParameterValue("tennguoidutru", chuky.hoten);
                rpt.SetParameterValue("giamdoccn", System.Web.Hosting.HostingEnvironment.MapPath(chuky.TBL_DANHMUCCHUKYCN.url));
                rpt.SetParameterValue("tengiamdoccn", chuky.TBL_DANHMUCCHUKYCN.hoten);
                try
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath(db2.TBL_DANHMUCCHUKY.SingleOrDefault(n => n.taikhoan == User.Identity.Name.ToUpper()).url));
                }
                catch
                {
                    rpt.SetParameterValue("nguoixuly", System.Web.Hosting.HostingEnvironment.MapPath("~/Content/CHUKY/NULL.png"));
                }
                if (chuky.macn == "TT423")
                {
                    rpt.SetParameterValue("labelgiamdoc", "Trưởng trung tâm");
                }
                else
                {
                    rpt.SetParameterValue("labelgiamdoc", "Giám đốc CN");
                }
                var quyen = db2.TBL_DANHMUCPHANQUYENSC.SingleOrDefault(n => n.taikhoan.ToUpper() == User.Identity.Name.ToUpper());

                if (quyen != null)
                {
                    try
                    {
                        if (quyen.quyen == "QUANLY")
                        {
                            var hoten = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToUpper() == User.Identity.Name.ToUpper());
                            rpt.SetParameterValue("tennguoixuly", hoten.hoten);
                        }
                        else
                        {
                            rpt.SetParameterValue("tennguoixuly", " ");
                        }
                    }
                    catch (Exception)
                    {

                        rpt.SetParameterValue("tennguoixuly", " ");

                    }

                }
                //if (User.Identity.Name.ToUpper() == "PY.VIANH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Nguyễn Hoàng Vĩ Anh");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.HONG")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Hoàng Thị Ánh Hồng");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.QUYNH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Trần Thị Thảo Quỳnh");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.DANGKHOA")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Phạm Đăng Khoa");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.TRAM")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Đỗ Thị Ngọc Trâm");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.TINH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Lê Minh Tính");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.THICH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Nguyễn Đình Thích");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.THU")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Nguyễn Thị Ánh Thư");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.DIEN")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Nguyễn Thị Điền");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.HANH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Lê Thị Hạnh");
                //}
                //else if (User.Identity.Name.ToUpper() == "PY.MYHANH")
                //{
                //    rpt.SetParameterValue("tennguoixuly", "Bùi Thị Mỹ Hạnh");
                //}
                //else
                //{
                //    rpt.SetParameterValue("tennguoixuly", " ");
                //}
                Stream s1 = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                return View("/Views/Order/PDFVIEWER.cshtml", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s1)) });
            }
        }
        [ActionName("tao-moi-don-dat-hang")]
        public ActionResult Taodonhang(string makh)
        {
            var Info = GetInfo();
            var Infocrm = Info.TBL_PHANQUYENCRM;
            if (Info.dathang == 1 || Info.dathang == 2)
            {
                ViewBag.dathang = Info.dathang;
                ViewBag.ten = Info.hoten;
                ViewBag.quyen = Info.quyen;
                ViewBag.makh = makh;
                ViewBag.macn = Infocrm.macn;
                var Data = DATATAO(Infocrm.macn, Infocrm.matdv);
                var THKM = DATATH1.TBL_DANHMUCKM.Where(n => n.ngayketthuc >= DateTime.Today && n.ngaybatdau <= DateTime.Today).ToList().Where(n => n.PHAMVI.Split(',').Contains(Infocrm.macn)).Select(cl => new ListChuongTrinhKM { MACTKM = cl.MACTKM, BBTT = (cl.BBTT == true) ? 1 : 0, TICHDIEM = cl.TICHDIEM, TENCTKM = cl.TENCTKM, MAHH = cl.MAHH, HANMUC = cl.HANMUC, ck = cl.ck }).ToList();
                Data.ListCTKM = THKM.Concat(Data.ListCTKM.Where(n => !THKM.Select(cl => cl.MACTKM).ToList().Contains(n.MACTKM))).ToList();
                Data.ListCTHT = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.Where(n => n.ngayketthuc >= DateTime.Today && n.ngaybatdau <= DateTime.Today).ToList().Where(n => n.PHAMVI.Split(',').Contains(Infocrm.macn)).Select(cl => new ListChuongTrinhHT { MACTHT = cl.MACTHT, TENCTHT = cl.TENCTHT, MAHH = cl.MAHH, TICHDIEM = cl.TICHDIEM, HANMUC = cl.HANMUC, MACTKM = cl.MACTKM }).ToList();
                if (Infocrm.matdv != null)
                {
                    Data.ListTDV = Infocrm.matdv.Split(',').ToList();
                }
                else
                {
                    Data.ListTDV = GetTrinhDuocVien(Infocrm.macn);
                }
                //if (Info.manhom != null)
                //{
                //    var nhomhang = Info.manhom.Split(',').ToList();
                //    Data.ListHH = Data.ListHH.Where(n => nhomhang.Contains(n.NHOM)).ToList();
                //}
                return View("Taodonhang", Data);
            }
            else
            {
                return RedirectToAction("bao-cao-bsc", "Home");
            }
        }
        [ActionName("nhap-the-cao")]
        public ActionResult Nhapthecao()
        {
            var Info = GetInfo();
            var Infocrm = Info.TBL_PHANQUYENCRM;
            if (Info.dathang == 1 || Info.dathang == 2)
            {
                ViewBag.dathang = Info.dathang;
                ViewBag.ten = Info.hoten;
                ViewBag.quyen = Info.quyen;
                ViewBag.macn = Infocrm.macn;
                var Data = DATATAO(Infocrm.macn, Infocrm.matdv);
                return View("Nhapthecao", Data);
            }
            else
            {
                return RedirectToAction("bao-cao-bsc", "Home");
            }
        }
        public PartialViewResult PartialNhapthecao(string makh, int qui, int nam)
        {
            var Info = GetInfo();
            var Infocrm = Info.TBL_PHANQUYENCRM;
            if (makh != "" && makh != null)
            {
                var Data = db2.DTA_SOTHE.Where(n => n.nguoitao == User.Identity.Name && n.makh == makh && n.qui == qui && n.nam == nam);
                return PartialView(Data);
            }
            else
            {
                var Data = db2.DTA_SOTHE.Where(n => n.nguoitao == User.Identity.Name && n.qui == qui && n.nam == nam);
                return PartialView(Data);
            }
        }

        [ActionName("tra-cuu-the-cao")]
        public ActionResult Tracuuthecao()
        {
            var Info = GetInfo();
            var Infocrm = GetCRM();

            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var donvi = new List<TBL_DANHSACHCHINHANH>();
            if (Infocrm.macn == "ALL")
            {
                donvi = db2.TBL_DANHSACHCHINHANH.Where(n => n.check == true).ToList();
            }
            else
            {
                var taphop = Infocrm.macn.Split(',').ToList();
                donvi = db2.TBL_DANHSACHCHINHANH.Where(n => taphop.Contains(n.macn)).ToList();
            }
            ViewBag.mientrung = donvi.Where(n => n.Mien == "MIỀN TRUNG").OrderBy(n => n.stt);
            ViewBag.miennam = donvi.Where(n => n.Mien == "MIỀN NAM").OrderBy(n => n.stt);
            ViewBag.mienbac = donvi.Where(n => n.Mien == "MIỀN BẮC").OrderBy(n => n.stt);
            return View("Tracuuthecao");

        }
        [ActionName("quan-ly-the-cao")]
        public ActionResult Quanlythecao()
        {
            var Info = GetInfo();
            var Infocrm = Info.TBL_PHANQUYENCRM;

            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            ViewBag.macn = Infocrm.macn;
            var Data = DATATAO(Infocrm.macn, Infocrm.matdv);

            return View("Quanlythecao", Data);

        }
        [ActionName("tao-don-dat-hang-etc")]
        public ActionResult Taodonhangetc()
        {
            var Info = GetInfo();
            var Infocrm = Info.TBL_PHANQUYENCRM;
            if (Info.dathang == 1 || Info.dathang == 2)
            {
                ViewBag.dathang = Info.dathang;
                ViewBag.ten = Info.hoten;
                ViewBag.quyen = Info.quyen;
                var Data = new List<ListKhachHang>();
                if (Infocrm.matdv != null)
                {
                    Data = DATAGETKHETC(Infocrm.macn, new List<string> { Infocrm.matdv });
                }
                else
                {
                    Data = DATAGETKHETC(Infocrm.macn, null);
                }
                return View("Taodonhangetc", Data);
            }
            else
            {
                return RedirectToAction("bao-cao-bsc", "Home");
            }
        }
        [ActionName("tao-don-dat-hang-etc-mobile")]
        public ActionResult Taodonhangetcmobile()
        {
            var Info = GetInfo();
            var Infocrm = Info.TBL_PHANQUYENCRM;
            if (Info.dathang == 1 || Info.dathang == 2)
            {
                ViewBag.dathang = Info.dathang;
                ViewBag.ten = Info.hoten;
                ViewBag.quyen = Info.quyen;
                var Data = new List<ListKhachHang>();
                if (Infocrm.matdv != null)
                {
                    Data = DATAGETKHETC(Infocrm.macn, new List<string> { Infocrm.matdv });
                }
                else
                {
                    Data = DATAGETKHETC(Infocrm.macn, null);
                }
                return View("Taodonhangetcmobile", Data);
            }
            else
            {
                return RedirectToAction("bao-cao-bsc", "Home");
            }
        }
        [ActionName("tra-cuu-khach-hang")]
        public ActionResult Tracuukhachhang()
        {
            var Info = GetInfo();
            var Infocrm = GetCRM();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var taphop = Infocrm.macn.Split(',').ToList();
            var donvi = db2.TBL_DANHSACHCHINHANH.Where(n => taphop.Contains(n.macn)).ToList();
            ViewBag.mientrung = donvi.Where(n => n.Mien == "MIỀN TRUNG").OrderBy(n => n.stt);
            ViewBag.miennam = donvi.Where(n => n.Mien == "MIỀN NAM").OrderBy(n => n.stt);
            ViewBag.mienbac = donvi.Where(n => n.Mien == "MIỀN BẮC").OrderBy(n => n.stt);
            return View("Tracuukhachhang");
        }
        [ActionName("tim-kiem-khach-hang")]
        public ActionResult Timkiemkhachhang()
        {
            var Info = GetInfo();
            var Infocrm = GetCRM();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var taphop = Infocrm.macn.Split(',').ToList();
            var donvi = db2.TBL_DANHSACHCHINHANH.Where(n => taphop.Contains(n.macn)).ToList();
            ViewBag.mientrung = donvi.Where(n => n.Mien == "MIỀN TRUNG").OrderBy(n => n.stt);
            ViewBag.miennam = donvi.Where(n => n.Mien == "MIỀN NAM").OrderBy(n => n.stt);
            ViewBag.mienbac = donvi.Where(n => n.Mien == "MIỀN BẮC").OrderBy(n => n.stt);
            return View("Timkiemkhachhang");
        }

        [ActionName("danh-sach-khach-hang-cho-duyet")]
        public ActionResult Danhsachkhachhangchoduyet()
        {
            var Info = GetInfo();

            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var taphop = Info.macn.Split(',').ToList();
            var donvi = db2.TBL_DANHSACHCHINHANH.Where(n => taphop.Contains(n.macn)).ToList();
            ViewBag.mientrung = donvi.Where(n => n.Mien == "MIỀN TRUNG").OrderBy(n => n.stt);
            ViewBag.miennam = donvi.Where(n => n.Mien == "MIỀN NAM").OrderBy(n => n.stt);
            ViewBag.mienbac = donvi.Where(n => n.Mien == "MIỀN BẮC").OrderBy(n => n.stt);
            return View("Danhsachkhachhangchoduyet");
        }
        [ActionName("tao-moi-don-dat-hang-mobile")]
        public ActionResult Taodonhangmobile(string makh)
        {
            var Info = GetInfo();
            var Infocrm = Info.TBL_PHANQUYENCRM;
            if (Info.dathang == 1 || Info.dathang == 2)
            {
                ViewBag.dathang = Info.dathang;
                ViewBag.ten = Info.hoten;
                ViewBag.quyen = Info.quyen;
                ViewBag.makh = makh;
                ViewBag.macn = Infocrm.macn;
                var Data = DATATAO(Infocrm.macn, Infocrm.matdv);
                var THKM = DATATH1.TBL_DANHMUCKM.Where(n => n.ngayketthuc >= DateTime.Today && n.ngaybatdau <= DateTime.Today).ToList().Where(n => n.PHAMVI.Split(',').Contains(Infocrm.macn)).Select(cl => new ListChuongTrinhKM { MACTKM = cl.MACTKM, BBTT = (cl.BBTT == true) ? 1 : 0, TENCTKM = cl.TENCTKM, MAHH = cl.MAHH, TICHDIEM = cl.TICHDIEM, HANMUC = cl.HANMUC, ck = cl.ck }).ToList();
                Data.ListCTKM = THKM.Concat(Data.ListCTKM.Where(n => !THKM.Select(cl => cl.MACTKM).ToList().Contains(n.MACTKM))).ToList();
                Data.ListCTHT = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.Where(n => n.ngayketthuc >= DateTime.Today && n.ngaybatdau <= DateTime.Today).ToList().Where(n => n.PHAMVI.Split(',').Contains(Infocrm.macn)).Select(cl => new ListChuongTrinhHT { MACTHT = cl.MACTHT, TENCTHT = cl.TENCTHT, MAHH = cl.MAHH, TICHDIEM = cl.TICHDIEM, HANMUC = cl.HANMUC, MACTKM = cl.MACTKM }).ToList();
                if (Infocrm.matdv != null)
                {
                    Data.ListTDV = Infocrm.matdv.Split(',').ToList();
                }
                else
                {
                    Data.ListTDV = GetTrinhDuocVien(Infocrm.macn);
                }
                //if (Info.manhom != null)
                //{
                //    var nhomhang = Info.manhom.Split(',').ToList();
                //    Data.ListHH = Data.ListHH.Where(n => nhomhang.Contains(n.NHOM)).ToList();
                //}
                return View("Taodonhangmobile", Data);
            }
            else
            {
                return RedirectToAction("bao-cao-bsc", "Home");
            }
        }

        public TBL_DANHMUCNGUOIDUNG GetInfo()
        {
            TBL_DANHMUCNGUOIDUNG abc = new TBL_DANHMUCNGUOIDUNG();
            abc = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name.ToString());
            return abc;
        }
        public TBL_PHANQUYENCRM GetCRM()
        {
            TBL_PHANQUYENCRM abc = new TBL_PHANQUYENCRM();
            abc = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name.ToUpper().ToString());
            return abc;
        }
        [HttpPost]
        public ActionResult GETCKBBTT(string mactkm, string makh)
        {
            var Infocrm = GetCRM();
            var MACH = Infocrm.macn;
            double? ck = 0;
            if (mactkm != null)
            {
                try
                {
                    if (DATATH1.TBL_DANHMUCKM.SingleOrDefault(n => n.MACTKM == mactkm).BBTT == true)
                    {
                        try
                        {
                            ck = DATA_GETBBTT(MACH, mactkm, makh);
                        }
                        catch (Exception)
                        {
                            ck = 12;
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
            return Json(ck);
        }
        [HttpPost]
        public ActionResult GETCKCHITIET(string mactkm, decimal tongtien)
        {
            try
            {
                var data = DATATH1.TBL_DANHMUCKM_CHITIET.SingleOrDefault(n => n.MACTKM == mactkm && n.DSTU <= tongtien && n.DSDEN >= tongtien).ck;
                return Json(data);
            }
            catch
            {
                return Json(0);
            }

        }
        [HttpPost]
        public ActionResult getdoanhsothecao(string makh, int qui)
        {
            var Infocrm = GetCRM();
            var MACH = Infocrm.macn;
            DateTime tungay = new DateTime();
            DateTime denngay = new DateTime();
            if (qui == 3)
            {
                tungay = DateTime.ParseExact("01/07/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                denngay = DateTime.ParseExact("30/09/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else if (qui == 1)
            {
                tungay = DateTime.ParseExact("01/01/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                denngay = DateTime.ParseExact("31/03/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else if (qui == 4)
            {
                tungay = DateTime.ParseExact("01/10/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                denngay = DateTime.ParseExact("31/12/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            var data = DATABAOCAODOANHSOKH(MACH, tungay, denngay, makh);
            if (data == null || data.Count() == 0)
            {
                return Json("0 - 0 thẻ");
            }
            else
            {
                var str = string.Format("{0:#,##0}", data.FirstOrDefault().TONGTIEN_CT_HOADON) + " - " + ((int)(data.FirstOrDefault().TONGTIEN_CT_HOADON / 10000000)) + " thẻ";
                return Json(str);
            }

        }
        public List<DULIEUBAOCAO0> DATABAOCAODOANHSOKH(string soso, DateTime tungay, DateTime denngay, string makh)
        {
            List<string> ctkm = new List<string>() { };
            ctkm.Add("BBTT2021_PARTNERSHIP");
            ctkm.Add("PARTNERSHIP/MN/2021");
            string strcn = "seleCT HOADON.MaPL,  sum(  ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)) as TONGTIEN_CT_HOADON   ,  sum( round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*cast(TYLECK as money) /100,0)) as TIENCK ,TBL_MIEN.MIEN as chuky1 ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC from TBL_MIEN, TBL_DANHMUCTIEUDEBAOCAO, DTA_CT_HOADON_XUAT CT LEFT JOIN   TBL_DANHMUCHANGHOA ON CT.mahh = TBL_DANHMUCHANGHOA.mahh, DTA_HOADON_XUAT HOADON   LEFT JOIN   TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MaPL IN ('BAN','XK') AND HOADON.MACH = CT.MACH AND CT.KT = 1";
            string strch = "seleCT HOADON.MaPL,  sum(  ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)) as TONGTIEN_CT_HOADON   ,  sum( round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*cast(TYLECK as money) /100,0)) as TIENCK ,TBL_MIEN.MIEN as chuky1 ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC from TBL_MIEN,tieude TBL_DANHMUCTIEUDEBAOCAO, CT_HOADON_XUAT CT  LEFT JOIN  DM_HANGHOA ON CT.mahh = DM_HANGHOA.mahh, HOADON_XUAT  HOADON LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.MaPL IN ('BAN','XK') AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1 ";
            if (makh != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.makh IN ('{0}')", makh);
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.makh IN ('{0}')", makh);
            }
            strcn = strcn + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", ctkm.Select(p => "'" + p + "'")));
            strch = strch + string.Format(" AND CT.MAKM IN ({0})", string.Join(",", ctkm.Select(p => "'" + p + "'")));
            strcn = strcn + " GROUP BY  TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc , HOADON.MaPL";
            strch = strch + " GROUP BY HOADON.MaPL, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc";
            var DATAX = new List<DULIEUBAOCAO0>();
            if (queryCN.SingleOrDefault(n => n.macn == soso) != null)
            {
                DATAX.AddRange(BAOCAOCHINHANH0(queryCN.SingleOrDefault(n => n.macn == soso).data, strcn));
            }
            else if (queryCH.SingleOrDefault(n => n.macn == soso) != null)
            {
                DATAX.AddRange(BAOCAOCUAHANG0(queryCH.SingleOrDefault(n => n.macn == soso).data, strch));
            }
            return DATAX;
        }
        public List<DULIEUBAOCAO0> BAOCAOCHINHANH0(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO0>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAO0> BAOCAOCUAHANG0(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO0>(str).ToList();
            return All;
        }
        [HttpPost]
        public ActionResult GETCONGNOQUAHAN(string makh)
        {
            var Infocrm = GetCRM();
            var MACH = Infocrm.macn;
            var data = new List<TIENNOQUAHAN>();
            try
            {
                if (queryCN.SingleOrDefault(n => n.macn == MACH) != null)
                {
                    var strcn = "exec sp_kyhan_capnhap_DENNGAY_MAKH_KIEMTRA '131','" + makh + "'";

                    data = queryCN.SingleOrDefault(n => n.macn == MACH).data.Database.SqlQuery<TIENNOQUAHAN>(strcn).ToList();
                    if (data.Count() != 0)
                    {
                        return Json(1);
                    }
                    else
                    {
                        return Json(0);
                    }
                }
                else if (queryCH.SingleOrDefault(n => n.macn == MACH) != null)
                {
                    var strcn = "exec sp_kyhan_capnhap_DENNGAY_MAKH_KIEMTRA '131','" + makh + "'";

                    data = queryCH.SingleOrDefault(n => n.macn == MACH).data.Database.SqlQuery<TIENNOQUAHAN>(strcn).ToList();
                    if (data.Count() != 0)
                    {
                        return Json(1);
                    }
                    else
                    {
                        return Json(0);
                    }
                }
            }
            catch (Exception)
            {
                return Json(new DATATIENNO());
            }
            return Json(new DATATIENNO());
        }
        [HttpPost]
        public ActionResult GETCONGNO(string makh)
        {
            var Infocrm = GetCRM();
            var MACH = Infocrm.macn;
            var data = new DATATIENNO();
            try
            {
                if (queryCN.SingleOrDefault(n => n.macn == MACH) != null)
                {
                    var strcn = " exec sp_kyhan_inct_capnhap '131'," + DateTime.Today.Month + "," + DateTime.Today.Year + ",'','" + makh + "','" + DateTime.Today.ToString("MM/dd/yyyy") + "' ";
                    data.tienno = queryCN.SingleOrDefault(n => n.macn == MACH).data.Database.SqlQuery<TIENNO>(strcn).ToList();
                    try
                    {
                        var str = "select tien,sct,ngay from [kiemtra_kyhancongno] ('131','" + DateTime.Today.ToString("MM/dd/yyyy") + "','" + makh + "')";
                        data.tienquahan = queryCN.SingleOrDefault(n => n.macn == MACH).data.Database.SqlQuery<TIENNOQUAHAN>(str).ToList();
                    }
                    catch (Exception)
                    {
                        data.tienquahan = new List<TIENNOQUAHAN>();
                    }
                    return Json(data);
                }
                else if (queryCH.SingleOrDefault(n => n.macn == MACH) != null)
                {
                    return Json(new DATATIENNO());
                }
            }
            catch (Exception)
            {
                return Json(new DATATIENNO());
            }
            return Json(new DATATIENNO());
        }
        public double? DATA_GETBBTT(string x, string LoaiBBTT, string makh)
        {
            var str = "SELECT TOP 1 ck from TBL_DANHMUCBIENBANTHOATHUAN_2 WHERE '" + LoaiBBTT + "' IN (SELECT VAL FROM FUN_CATCHUOI(loaibbtt)) AND makh = '" + makh + "'";
            double? data = 0;
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                data = queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<double>(str).First();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
            {
                data = queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<double>(str).First();
            }
            return data;
        }
        public List<ListTrinhDuocVien> DULIEUTRINHDUOCVIENLOC(Entities data, List<string> MATDV)
        {
            var All = data.Database.SqlQuery<ListTrinhDuocVien>("SELECT MaTDV AS MATDV, TenTDV AS TENTDV FROM TBL_DANHMUCTDV WHERE MaTDV IS NOT NULL").ToList();
            if (MATDV != null)
            {

                All = All.Where(n => MATDV.Contains(n.MATDV)).ToList();
            }
            return All;
        }
        public List<ListTrinhDuocVien> DULIEUTRINHDUOCVIEN(Entities data)
        {
            var All = data.Database.SqlQuery<ListTrinhDuocVien>("SELECT MaTDV AS MATDV, TenTDV AS TENTDV FROM TBL_DANHMUCTDV WHERE MaTDV IS NOT NULL").ToList();
            return All;
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
        public List<ListTrinhDuocVien> DULIEUCUAHANGTRINHDUOCVIEN(CHQ10Entities1 data)
        {
            var All = data.Database.SqlQuery<ListTrinhDuocVien>("SELECT MaTDV AS MATDV, TenTDV AS TENTDV FROM DS_TDV_PTTT WHERE MaTDV IS NOT NULL").ToList();
            return All;
        }
        public List<string> GetTrinhDuocVien(string ChiNhanhId)
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
            return data.Select(cl => cl.MATDV).ToList();
        }
        public int DATA_GET(string x)
        {
            int MADH = 0;
            try
            {

                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    var enti = queryCN.SingleOrDefault(n => n.macn == x).data;
                    var DTA_DONDATHANG = enti.Database.SqlQuery<DTA_DONDATHANG>("SELECT * FROM DTA_DONDATHANG order by cast (MADH as int) desc").ToList();
                    var old_MADH = DTA_DONDATHANG.FirstOrDefault().MADH;

                    MADH = Int32.Parse(old_MADH) + 1;
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    MADH = Int32.Parse(queryCH.SingleOrDefault(n => n.macn == x).data.DTA_DONDATHANG.OrderByDescending(n => n.MADH).FirstOrDefault().MADH) + 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return MADH;
        }

        [HttpPost]
        public ActionResult GetHopDongKD(string makh)
        {
            var ListHopdong = PhuYen.Database.SqlQuery<ListHopdongKD>("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG ,CAST(ck AS INT) AS ck from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").ToList();
            var list = PhuYen.TBL_DANHMUCHOPDONGCHUNG.ToList();
            var hdchung = PhuYen.Database.SqlQuery<ListHopdongKD>(string.Format("select MAHD AS MAHOPDONG, noidung AS TENHOPDONG, CAST(ck AS INT) AS ck from TBL_DANHMUCHOPDONG where mahd IN ({0}) and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'", string.Join(",", list.Select(p => "'" + p.MAHD + "'")))).ToList();
            return Json(ListHopdong.Concat(hdchung).Distinct());
        }
        [HttpPost]
        public ActionResult GetHopDongWS(string makh)
        {
            var ListHopdong = PhuYen.TBL_DANHMUCHOPDONG_WS.Where(n => n.MAKH == makh).GroupBy(n => n.MAHD).Select(n => n.Key).ToList();

            return Json(ListHopdong);
        }
        [HttpPost]
        public ActionResult GetHopDongSC(string makh)
        {
            var ListHopdong = SC.Database.SqlQuery<ListHopdongKD>("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG ,CAST(ck AS INT) AS ck from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").ToList();
            var list = SC.TBL_DANHMUCHOPDONGCHUNG.ToList();
            var hdchung = SC.Database.SqlQuery<ListHopdongKD>(string.Format("select MAHD AS MAHOPDONG, noidung AS TENHOPDONG, CAST(ck AS INT) AS ck from TBL_DANHMUCHOPDONG where mahd IN ({0}) and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'", string.Join(",", list.Select(p => "'" + p.MAHD + "'")))).ToList();
            return Json(ListHopdong.Concat(hdchung).Distinct());
        }
        [HttpPost]
        public ActionResult GetHopDongHCM(string makh)
        {
            var ListHopdong = PhuYen.Database.SqlQuery<ListHopdongKD>("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG ,0 AS ck from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").ToList();

            return Json(ListHopdong);
        }
        [HttpPost]
        public ActionResult GetHopDongETC(string makh)
        {
            var Infocrm = GetCRM();
            var x = Infocrm.macn;
            var ListHopdong = new List<ListHopdongKD>();
            //var list = db2.TBL_DANHMUCHOPDONGCHUNG.ToList();
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                //var str = string.Format("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG from TBL_DANHMUCHOPDONG where (makh = '" + makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "')", string.Join(",", list.Select(p => "'" + p.MAHD + "'")));
                ListHopdong = queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<ListHopdongKD>("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
            {
                ListHopdong = queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<ListHopdongKD>("select MAHD AS MAHOPDONG,noidung AS TENHOPDONG from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and NGAYBATDAU <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and NGAYKETTHUC >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").ToList();
            }
            return Json(ListHopdong);
        }
        [HttpPost]
        public ActionResult GetSanPhamHDETC(string makh, string mahd)
        {
            var Infocrm = GetCRM();
            var macn = Infocrm.macn;
            var ListHopdong = new List<ListHangHoa>();
            //var list = db2.TBL_DANHMUCHOPDONGCHUNG.ToList();
            //var list = new List<string> { "TQG", "OTC", "PY2018", "QT2018", "92NS", "92NS(2020)", "36NS", "MSTTL2(2019)" };
            //if (list.SingleOrDefault(n => n.MAHD == mahd) == null)
            //{
            //    if (queryCN.SingleOrDefault(n => n.macn == macn) != null)
            //    {
            //        ListHopdong = queryCN.SingleOrDefault(n => n.macn == macn).data.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and mahd = '" + mahd + "'").ToList();
            //    }
            //    else if (queryCH.SingleOrDefault(n => n.macn == macn) != null)
            //    {
            //        ListHopdong = queryCH.SingleOrDefault(n => n.macn == macn).data.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and mahd = '" + mahd + "'").ToList();
            //    }
            //}
            //else
            //{
            if (queryCN.SingleOrDefault(n => n.macn == macn) != null)
            {
                ListHopdong = queryCN.SingleOrDefault(n => n.macn == macn).data.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where mahd = '" + mahd + "' and makh='" + makh + "' ").ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == macn) != null)
            {
                ListHopdong = queryCH.SingleOrDefault(n => n.macn == macn).data.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where mahd = '" + mahd + "' and makh='" + makh + "' ").ToList();
            }

            //}

            if (ListHopdong.FirstOrDefault().MAHH != null && ListHopdong.FirstOrDefault().MAHH != "")
            {
                var mahh = ListHopdong.FirstOrDefault().MAHH.Split(',').ToList();
                var giaban = ListHopdong.FirstOrDefault().GIABAN.Split(',').ToList();
                var result = mahh.Zip(giaban, (x, y) => new Tuple<string, string>(x, y))
                .ToList();
                var hh = (from p in result
                          join c in queryCN.SingleOrDefault(n => n.macn == macn).data.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN ,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList()
                          on p.Item1 equals c.MAHH
                          select new ListHangHoa
                          {
                              MAHH = p.Item1,
                              DVT = c.DVT,
                              GIABAN = p.Item2,

                              TENHH = c.TENHH,
                              SL1 = c.SL1,
                              SL2 = c.SL2,
                              SL3 = c.SL3
                          }).ToList();
                return PartialView(hh);
            }
            //else
            //{
            //var banle = queryCN.SingleOrDefault(n => n.macn == macn).data.Database.SqlQuery<TBL_GIABAN>("SELECT top 1 mahh AS MAHH, gia AS GIABAN from TBL_GIABAN where nam ='" + DateTime.Now.Year + "'").ToList();
            //var mahh = banle.FirstOrDefault().MAHH.Split(',').ToList();
            // var giaban = banle.FirstOrDefault().GIABAN.Split(',').ToList();
            //  var result = mahh.Zip(giaban, (x, y) => new Tuple<string, string>(x, y))
            //.ToList();
            //  var hh = (from p in result
            //            join c in PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,SDK AS SDK, TENHH AS TENHH ,  DVT AS DVT ,GIABAN ,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList()
            //            on p.Item1 equals c.MAHH
            //            select new ListHangHoa
            //            {
            //                MAHH = p.Item1,
            //                DVT = c.DVT,
            //                GIABAN = p.Item2,
            //                SDK = c.SDK,
            //                TENHH = c.TENHH,
            //                SL1 = c.SL1,
            //                SL2 = c.SL2,
            //                SL3 = c.SL3
            //            }).ToList();
            //return PartialView(hh);
            //}
            return PartialView();
        }
        [HttpPost]
        public ActionResult GetSanPhamHDETCMobile(string makh, string mahd)
        {
            var Infocrm = GetCRM();
            var macn = Infocrm.macn;
            var ListHopdong = new List<ListHangHoa>();
            //var list = db2.TBL_DANHMUCHOPDONGCHUNG.ToList();
            //var list = new List<string> { "TQG", "OTC", "PY2018", "QT2018", "92NS", "92NS(2020)", "36NS", "MSTTL2(2019)" };
            //if (list.SingleOrDefault(n => n.MAHD == mahd) == null)
            //{
            //    if (queryCN.SingleOrDefault(n => n.macn == macn) != null)
            //    {
            //        ListHopdong = queryCN.SingleOrDefault(n => n.macn == macn).data.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and mahd = '" + mahd + "'").ToList();
            //    }
            //    else if (queryCH.SingleOrDefault(n => n.macn == macn) != null)
            //    {
            //        ListHopdong = queryCH.SingleOrDefault(n => n.macn == macn).data.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and mahd = '" + mahd + "'").ToList();
            //    }
            //}
            //else
            //{
            if (queryCN.SingleOrDefault(n => n.macn == macn) != null)
            {
                ListHopdong = queryCN.SingleOrDefault(n => n.macn == macn).data.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where mahd = '" + mahd + "' and makh='" + makh + "' ").ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == macn) != null)
            {
                ListHopdong = queryCH.SingleOrDefault(n => n.macn == macn).data.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where mahd = '" + mahd + "' and makh='" + makh + "' ").ToList();
            }

            //}

            if (ListHopdong.FirstOrDefault().MAHH != null && ListHopdong.FirstOrDefault().MAHH != "")
            {
                var mahh = ListHopdong.FirstOrDefault().MAHH.Split(',').ToList();
                var giaban = ListHopdong.FirstOrDefault().GIABAN.Split(',').ToList();
                var result = mahh.Zip(giaban, (x, y) => new Tuple<string, string>(x, y))
                .ToList();
                var hh = (from p in result
                          join c in queryCN.SingleOrDefault(n => n.macn == macn).data.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN ,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList()
                          on p.Item1 equals c.MAHH
                          select new ListHangHoa
                          {
                              MAHH = p.Item1,
                              DVT = c.DVT,
                              GIABAN = p.Item2,
                              TENHH = c.TENHH,
                              SL1 = c.SL1,
                              SL2 = c.SL2,
                              SL3 = c.SL3
                          }).ToList();
                return PartialView(hh);
            }
            //else
            //{
            //var banle = queryCN.SingleOrDefault(n => n.macn == macn).data.Database.SqlQuery<TBL_GIABAN>("SELECT top 1 mahh AS MAHH, gia AS GIABAN from TBL_GIABAN where nam ='" + DateTime.Now.Year + "'").ToList();
            //var mahh = banle.FirstOrDefault().MAHH.Split(',').ToList();
            // var giaban = banle.FirstOrDefault().GIABAN.Split(',').ToList();
            //  var result = mahh.Zip(giaban, (x, y) => new Tuple<string, string>(x, y))
            //.ToList();
            //  var hh = (from p in result
            //            join c in PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,SDK AS SDK, TENHH AS TENHH ,  DVT AS DVT ,GIABAN ,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList()
            //            on p.Item1 equals c.MAHH
            //            select new ListHangHoa
            //            {
            //                MAHH = p.Item1,
            //                DVT = c.DVT,
            //                GIABAN = p.Item2,
            //                SDK = c.SDK,
            //                TENHH = c.TENHH,
            //                SL1 = c.SL1,
            //                SL2 = c.SL2,
            //                SL3 = c.SL3
            //            }).ToList();
            //return PartialView(hh);
            //}
            return PartialView();
        }
        [HttpPost]
        public ActionResult GetSanPhamHDHCM(string makh, string mahd)
        {
            var ListHopdong = new List<ListHangHoa>();
            ListHopdong = HoChiMinh.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where mahd = '" + mahd + "'").ToList();
            if (ListHopdong.FirstOrDefault().MAHH != null && ListHopdong.FirstOrDefault().MAHH != "")
            {
                var mahh = ListHopdong.FirstOrDefault().MAHH.Split(',').ToList();
                var giaban = ListHopdong.FirstOrDefault().GIABAN.Split(',').ToList();
                var result = mahh.Zip(giaban, (x, y) => new Tuple<string, string>(x, y))
                .ToList();
                var hh = (from p in result
                          join c in SC.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,SDK AS SDK, TENHH AS TENHH ,  DVT AS DVT ,GIABAN ,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3, QUICACH as QUICACH from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList()
                          on p.Item1 equals c.MAHH
                          select new ListHangHoa
                          {
                              MAHH = p.Item1,
                              DVT = c.DVT,
                              GIABAN = p.Item2,
                              SDK = c.SDK,
                              TENHH = c.TENHH,
                              SL1 = c.SL1,
                              SL2 = c.SL2,
                              SL3 = c.SL3,
                              QUICACH = c.QUICACH
                          }).ToList();
                return PartialView(hh);
            }
            else
            {
                var banle = SC.Database.SqlQuery<TBL_GIABAN>("SELECT top 1 mahh AS MAHH, gia AS GIABAN from TBL_GIABAN where nam ='" + DateTime.Now.Year + "'").ToList();
                var mahh = banle.FirstOrDefault().MAHH.Split(',').ToList();
                var giaban = banle.FirstOrDefault().GIABAN.Split(',').ToList();
                var result = mahh.Zip(giaban, (x, y) => new Tuple<string, string>(x, y))
              .ToList();
                var hh = (from p in result
                          join c in SC.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,SDK AS SDK, TENHH AS TENHH ,  DVT AS DVT ,GIABAN ,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3, QUICACH as QUICACH from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList()
                          on p.Item1 equals c.MAHH
                          select new ListHangHoa
                          {
                              MAHH = p.Item1,
                              DVT = c.DVT,
                              GIABAN = p.Item2,
                              SDK = c.SDK,
                              TENHH = c.TENHH,
                              SL1 = c.SL1,
                              SL2 = c.SL2,
                              SL3 = c.SL3,
                              QUICACH = c.QUICACH
                          }).ToList();
                return PartialView(hh);

            }
        }
        [HttpPost]
        public ActionResult GetSanPhamHDHCMMobile(string makh, string mahd)
        {
            var ListHopdong = new List<ListHangHoa>();
            ListHopdong = HoChiMinh.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where mahd = '" + mahd + "'").ToList();
            if (ListHopdong.FirstOrDefault().MAHH != null && ListHopdong.FirstOrDefault().MAHH != "")
            {
                var mahh = ListHopdong.FirstOrDefault().MAHH.Split(',').ToList();
                var giaban = ListHopdong.FirstOrDefault().GIABAN.Split(',').ToList();
                var result = mahh.Zip(giaban, (x, y) => new Tuple<string, string>(x, y))
                .ToList();
                var hh = (from p in result
                          join c in SC.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN ,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3, QUICACH as QUICACH from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList()
                          on p.Item1 equals c.MAHH
                          select new ListHangHoa
                          {
                              MAHH = p.Item1,
                              DVT = c.DVT,
                              GIABAN = p.Item2,
                              TENHH = c.TENHH,
                              SL1 = c.SL1,
                              SL2 = c.SL2,
                              SL3 = c.SL3,
                              QUICACH = c.QUICACH
                          }).ToList();
                return PartialView(hh);
            }
            else
            {
                var banle = SC.Database.SqlQuery<TBL_GIABAN>("SELECT top 1 mahh AS MAHH, gia AS GIABAN from TBL_GIABAN where nam ='" + DateTime.Now.Year + "'").ToList();
                var mahh = banle.FirstOrDefault().MAHH.Split(',').ToList();
                var giaban = banle.FirstOrDefault().GIABAN.Split(',').ToList();
                var result = mahh.Zip(giaban, (x, y) => new Tuple<string, string>(x, y))
              .ToList();
                var hh = (from p in result
                          join c in SC.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN ,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3, QUICACH as QUICACH from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList()
                          on p.Item1 equals c.MAHH
                          select new ListHangHoa
                          {
                              MAHH = p.Item1,
                              DVT = c.DVT,
                              GIABAN = p.Item2,
                              TENHH = c.TENHH,
                              SL1 = c.SL1,
                              SL2 = c.SL2,
                              SL3 = c.SL3,
                              QUICACH = c.QUICACH
                          }).ToList();
                return PartialView(hh);
            }
        }
        [HttpPost]
        public ActionResult GetSanPhamHDSC(string makh, string mahd)
        {
            var ListHopdong = new List<ListHangHoa>();
            var list = SC.TBL_DANHMUCHOPDONGCHUNG.ToList();
            //var list = new List<string> { "TQG", "OTC", "PY2018", "QT2018", "92NS", "92NS(2020)", "36NS", "MSTTL2(2019)" };
            if (list.SingleOrDefault(n => n.MAHD == mahd) == null)
            {
                ListHopdong = SC.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and mahd = '" + mahd + "'").ToList();
            }
            else
            {
                ListHopdong = SC.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where mahd = '" + mahd + "'").ToList();
            }

            if (ListHopdong.FirstOrDefault().MAHH != null && ListHopdong.FirstOrDefault().MAHH != "")
            {
                var mahh = ListHopdong.FirstOrDefault().MAHH.Split(',').ToList();
                var giaban = ListHopdong.FirstOrDefault().GIABAN.Split(',').ToList();
                var result = mahh.Zip(giaban, (x, y) => new Tuple<string, string>(x, y))
                .ToList();
                var hh = (from p in result
                          join c in SC.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,SDK AS SDK, TENHH AS TENHH ,  DVT AS DVT ,GIABAN ,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3, QUICACH as QUICACH from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList()
                          on p.Item1 equals c.MAHH
                          select new ListHangHoa
                          {
                              MAHH = p.Item1,
                              DVT = c.DVT,
                              GIABAN = p.Item2,
                              SDK = c.SDK,
                              TENHH = c.TENHH,
                              SL1 = c.SL1,
                              SL2 = c.SL2,
                              SL3 = c.SL3,
                              QUICACH = c.QUICACH
                          }).ToList();
                return PartialView(hh.OrderBy(n => n.MAHH));
            }
            else
            {
                var banle = SC.Database.SqlQuery<TBL_GIABAN>("SELECT top 1 mahh AS MAHH, gia AS GIABAN from TBL_GIABAN where nam ='" + DateTime.Now.Year + "'").ToList();
                var mahh = banle.FirstOrDefault().MAHH.Split(',').ToList();
                var giaban = banle.FirstOrDefault().GIABAN.Split(',').ToList();
                var result = mahh.Zip(giaban, (x, y) => new Tuple<string, string>(x, y))
              .ToList();
                var hh = (from p in result
                          join c in SC.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,SDK AS SDK, TENHH AS TENHH ,  DVT AS DVT ,GIABAN ,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3, QUICACH as QUICACH from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList()
                          on p.Item1 equals c.MAHH
                          select new ListHangHoa
                          {
                              MAHH = p.Item1,
                              DVT = c.DVT,
                              GIABAN = p.Item2,
                              SDK = c.SDK,
                              TENHH = c.TENHH,
                              SL1 = c.SL1,
                              SL2 = c.SL2,
                              SL3 = c.SL3,
                              QUICACH = c.QUICACH
                          }).ToList();
                return PartialView(hh.OrderBy(n => n.MAHH));
            }
        }
        [HttpPost]
        public ActionResult GetSanPhamHDSCMobile(string makh, string mahd)
        {
            var ListHopdong = new List<ListHangHoa>();
            var list = SC.TBL_DANHMUCHOPDONGCHUNG.ToList();
            //var list = new List<string> { "TQG", "OTC", "PY2018", "QT2018", "92NS", "92NS(2020)", "36NS", "MSTTL2(2019)" };
            if (list.SingleOrDefault(n => n.MAHD == mahd) == null)
            {
                ListHopdong = SC.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and mahd = '" + mahd + "'").ToList();
            }
            else
            {
                ListHopdong = SC.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where mahd = '" + mahd + "'").ToList();
            }

            if (ListHopdong.FirstOrDefault().MAHH != null && ListHopdong.FirstOrDefault().MAHH != "")
            {
                var mahh = ListHopdong.FirstOrDefault().MAHH.Split(',').ToList();
                var giaban = ListHopdong.FirstOrDefault().GIABAN.Split(',').ToList();
                var result = mahh.Zip(giaban, (x, y) => new Tuple<string, string>(x, y))
                .ToList();
                var hh = (from p in result
                          join c in SC.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN ,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3, QUICACH as QUICACH from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList()
                          on p.Item1 equals c.MAHH
                          select new ListHangHoa
                          {
                              MAHH = p.Item1,
                              DVT = c.DVT,
                              GIABAN = p.Item2,
                              TENHH = c.TENHH,
                              SL1 = c.SL1,
                              SL2 = c.SL2,
                              SL3 = c.SL3,
                              QUICACH = c.QUICACH
                          }).ToList();
                return PartialView(hh);
            }
            else
            {
                var banle = SC.Database.SqlQuery<TBL_GIABAN>("SELECT top 1 mahh AS MAHH, gia AS GIABAN from TBL_GIABAN where nam ='" + DateTime.Now.Year + "'").ToList();
                var mahh = banle.FirstOrDefault().MAHH.Split(',').ToList();
                var giaban = banle.FirstOrDefault().GIABAN.Split(',').ToList();
                var result = mahh.Zip(giaban, (x, y) => new Tuple<string, string>(x, y))
              .ToList();
                var hh = (from p in result
                          join c in SC.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN ,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3, QUICACH as QUICACH from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList()
                          on p.Item1 equals c.MAHH
                          select new ListHangHoa
                          {
                              MAHH = p.Item1,
                              DVT = c.DVT,
                              GIABAN = p.Item2,
                              TENHH = c.TENHH,
                              SL1 = c.SL1,
                              SL2 = c.SL2,
                              SL3 = c.SL3,
                              QUICACH = c.QUICACH
                          }).ToList();
                return PartialView(hh);
            }
        }
        [HttpPost]
        public ActionResult GetSanPhamHDKD(string makh, string mahd)
        {
            var ListHopdong = new List<ListHangHoa>();
            var list = PhuYen.TBL_DANHMUCHOPDONGCHUNG.ToList();
            //var list = new List<string> { "TQG", "OTC", "PY2018", "QT2018", "92NS", "92NS(2020)", "36NS", "MSTTL2(2019)" };
            if (list.SingleOrDefault(n => n.MAHD == mahd) == null)
            {
                ListHopdong = PhuYen.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and mahd = '" + mahd + "'").ToList();
            }
            else
            {
                ListHopdong = PhuYen.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where mahd = '" + mahd + "'").ToList();
            }

            if (ListHopdong.FirstOrDefault().MAHH != null && ListHopdong.FirstOrDefault().MAHH != "")
            {
                var mahh = ListHopdong.FirstOrDefault().MAHH.Split(',').ToList();
                var giaban = ListHopdong.FirstOrDefault().GIABAN.Split(',').ToList();
                var result = mahh.Zip(giaban, (x, y) => new Tuple<string, string>(x, y))
                .ToList();
                var hh = (from p in result
                          join c in PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,SDK AS SDK, TENHH AS TENHH ,  DVT AS DVT ,GIABAN ,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3, QUICACH as QUICACH from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList()
                          on p.Item1 equals c.MAHH
                          select new ListHangHoa
                          {
                              MAHH = p.Item1,
                              DVT = c.DVT,
                              GIABAN = p.Item2,
                              SDK = c.SDK,
                              TENHH = c.TENHH,
                              SL1 = c.SL1,
                              SL2 = c.SL2,
                              SL3 = c.SL3,
                              QUICACH = c.QUICACH
                          }).ToList();
                return PartialView(hh.OrderBy(n => n.MAHH));
            }
            else
            {
                var banle = PhuYen.Database.SqlQuery<TBL_GIABAN>("SELECT top 1 mahh AS MAHH, gia AS GIABAN from TBL_GIABAN where nam ='" + DateTime.Now.Year + "'").ToList();
                var mahh = banle.FirstOrDefault().MAHH.Split(',').ToList();
                var giaban = banle.FirstOrDefault().GIABAN.Split(',').ToList();
                var result = mahh.Zip(giaban, (x, y) => new Tuple<string, string>(x, y))
              .ToList();
                var hh = (from p in result
                          join c in PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,SDK AS SDK, TENHH AS TENHH ,  DVT AS DVT ,GIABAN ,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3, QUICACH as QUICACH from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList()
                          on p.Item1 equals c.MAHH
                          select new ListHangHoa
                          {
                              MAHH = p.Item1,
                              DVT = c.DVT,
                              GIABAN = p.Item2,
                              SDK = c.SDK,
                              TENHH = c.TENHH,
                              SL1 = c.SL1,
                              SL2 = c.SL2,
                              SL3 = c.SL3,
                              QUICACH = c.QUICACH
                          }).ToList();
                return PartialView(hh.OrderBy(n => n.MAHH));
            }
        }
        [HttpPost]
        public ActionResult GetSanPhamHDWS(string makh, string mahd)
        {
            var ListHopdong = new List<ListHangHoa>();
            // var list = PhuYen.TBL_DANHMUCHOPDONGCHUNG.ToList();
            //var list = new List<string> { "TQG", "OTC", "PY2018", "QT2018", "92NS", "92NS(2020)", "36NS", "MSTTL2(2019)" };
            var result = PhuYen.TBL_CT_DANHMUCHOPDONG_WS.Where(n => n.MAKH == makh && n.MAHD == mahd).ToList();
            var hh = (from p in result
                      join c in PhuYen.Database.SqlQuery<ListHangHoaWS>("SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3, QUICACH as QUICACH from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList()
                      on p.MAHH equals c.MAHH
                      select new ListHangHoaWS
                      {
                          MAHH = p.MAHH,
                          DVT = c.DVT,

                          SDK = c.SDK,
                          TENHH = c.TENHH,
                          SL1 = c.SL1,
                          SL2 = c.SL2,
                          SL3 = c.SL3,
                          QUICACH = c.QUICACH
                      }).ToList();
            return PartialView(hh.OrderBy(n => n.MAHH));
        }
        [HttpPost]
        public ActionResult GetSolohandung(string mahh)
        {
            var data = PhuYen.Database.SqlQuery<BANGSOLOHANDUNG>("EXEC sp_INSOCTIET_KHO_MALO_HANDUNG_MAQUAY_TONGHOP " + DateTime.Today.Month + "," + DateTime.Today.Month + "," + DateTime.Today.Year + ",'" + mahh + "'").ToList();
            return PartialView(data);
        }
        [HttpPost]
        public ActionResult GetSanPhamHDKDMobile(string makh, string mahd)
        {
            var ListHopdong = new List<ListHangHoa>();
            var list = PhuYen.TBL_DANHMUCHOPDONGCHUNG.ToList();
            //var list = new List<string> { "TQG", "OTC", "PY2018", "QT2018", "92NS", "92NS(2020)", "36NS", "MSTTL2(2019)" };
            if (list.SingleOrDefault(n => n.MAHD == mahd) == null)
            {
                ListHopdong = PhuYen.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where makh = '" + makh + "' and mahd = '" + mahd + "'").ToList();
            }
            else
            {
                ListHopdong = PhuYen.Database.SqlQuery<ListHangHoa>("select top 1 sp AS MAHH,GIASP AS GIABAN from TBL_DANHMUCHOPDONG where mahd = '" + mahd + "'").ToList();
            }

            if (ListHopdong.FirstOrDefault().MAHH != null && ListHopdong.FirstOrDefault().MAHH != "")
            {
                var mahh = ListHopdong.FirstOrDefault().MAHH.Split(',').ToList();
                var giaban = ListHopdong.FirstOrDefault().GIABAN.Split(',').ToList();
                var result = mahh.Zip(giaban, (x, y) => new Tuple<string, string>(x, y))
                .ToList();
                var hh = (from p in result
                          join c in PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN ,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3, QUICACH as QUICACH from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList()
                          on p.Item1 equals c.MAHH
                          select new ListHangHoa
                          {
                              MAHH = p.Item1,
                              DVT = c.DVT,
                              GIABAN = p.Item2,
                              TENHH = c.TENHH,
                              SL1 = c.SL1,
                              SL2 = c.SL2,
                              SL3 = c.SL3,
                              QUICACH = c.QUICACH
                          }).ToList();
                return PartialView(hh);
            }
            else
            {
                var banle = PhuYen.Database.SqlQuery<TBL_GIABAN>("SELECT top 1 mahh AS MAHH, gia AS GIABAN from TBL_GIABAN where nam ='" + DateTime.Now.Year + "'").ToList();
                var mahh = banle.FirstOrDefault().MAHH.Split(',').ToList();
                var giaban = banle.FirstOrDefault().GIABAN.Split(',').ToList();
                var result = mahh.Zip(giaban, (x, y) => new Tuple<string, string>(x, y))
              .ToList();
                var hh = (from p in result
                          join c in PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN ,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3, QUICACH as QUICACH from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList()
                          on p.Item1 equals c.MAHH
                          select new ListHangHoa
                          {
                              MAHH = p.Item1,
                              DVT = c.DVT,
                              GIABAN = p.Item2,
                              TENHH = c.TENHH,
                              SL1 = c.SL1,
                              SL2 = c.SL2,
                              SL3 = c.SL3,
                              QUICACH = c.QUICACH
                          }).ToList();
                return PartialView(hh);
            }
        }
        [HttpPost]
        public ActionResult GetDiemtichluy(string mactkm, string mahh, int hop)
        {
            try
            {
                var tv = DATATH1.TBL_DANHMUCHANGHOATICHDIEM.SingleOrDefault(n => n.MACT == mactkm && n.MAHH == mahh);
                if (tv != null)
                {
                    var diem = (hop / tv.HOP) * tv.DIEM;
                    return Json(diem);
                }
                else
                {
                    return Json(0);
                }
            }
            catch (Exception)
            {
                var tv = DATATH1.TBL_DANHMUCHANGHOATICHDIEM.Where(n => n.MACT == mactkm && n.MAHH == mahh).ToList();
                if (tv.Any())
                {
                    if ((hop % tv.LastOrDefault().HOP) % tv.FirstOrDefault().HOP == 0)
                    {
                        var diem = (hop / tv.LastOrDefault().HOP) * tv.LastOrDefault().DIEM + (hop % tv.LastOrDefault().HOP) / tv.FirstOrDefault().HOP * tv.FirstOrDefault().DIEM;
                        return Json(diem);
                    }
                    else if (hop % tv.FirstOrDefault().HOP == 0)
                    {
                        var diem = hop / tv.FirstOrDefault().HOP * tv.FirstOrDefault().DIEM;
                        return Json(diem);
                    }
                    else
                    {
                        var diem = (hop / tv.LastOrDefault().HOP) * tv.LastOrDefault().DIEM + (hop % tv.LastOrDefault().HOP) / tv.FirstOrDefault().HOP * tv.FirstOrDefault().DIEM;
                        return Json(diem);
                    }
                }
                else
                {
                    return Json(0);
                }
            }
            //return Json(0);
        }
        [HttpPost]
        public ActionResult GetTongdiemtichluy(string mactkm, string SODH)
        {
            try
            {
                var tv = DATATH1.TBL_DANHMUCHANGHOATICHDIEM.Where(n => n.MACT == mactkm);
                if (tv.Count() != 0)
                {
                    var tongdiem = 0;
                    var data = DATAGETDONHANG(GetCRM().macn, SODH);
                    foreach (var i in data)
                    {
                        try
                        {
                            var z = tv.SingleOrDefault(n => n.MAHH == i.MAHH);
                            tongdiem = tongdiem + (int)((Convert.ToInt32(i.SOLUONG) / z.SOLUONG) * z.DIEM);
                        }
                        catch (Exception)
                        {
                            var z = tv.Where(n => n.MAHH == i.MAHH).ToList();
                            if ((i.SOLUONG % z.LastOrDefault().SOLUONG) % z.FirstOrDefault().SOLUONG == 0)
                            {
                                tongdiem = tongdiem + (int)(((Convert.ToInt32(i.SOLUONG) / z.LastOrDefault().SOLUONG) * z.LastOrDefault().DIEM + (i.SOLUONG % z.LastOrDefault().SOLUONG) / z.FirstOrDefault().SOLUONG * z.FirstOrDefault().DIEM));

                            }
                            else if (i.SOLUONG % tv.FirstOrDefault().HOP == 0)
                            {
                                tongdiem = tongdiem + (int)((Convert.ToInt32(i.SOLUONG) / z.FirstOrDefault().SOLUONG * z.FirstOrDefault().DIEM));

                            }
                            else
                            {
                                tongdiem = tongdiem + (int)((Convert.ToInt32(i.SOLUONG) / z.LastOrDefault().SOLUONG) * z.LastOrDefault().DIEM + (i.SOLUONG % z.LastOrDefault().SOLUONG) / z.FirstOrDefault().SOLUONG * z.FirstOrDefault().DIEM);

                            }
                        }

                    }
                    return Json(tongdiem);
                }
                else
                {
                    return Json(0);
                }
            }
            catch (Exception)
            {
                return Json(0);
            }
        }
        [HttpPost]
        public ActionResult GetTongdiemtichluyCN(string mactkm, string SODH, string macn)
        {
            var tv = DATATH1.TBL_DANHMUCHANGHOATICHDIEM.Where(n => n.MACT == mactkm);
            if (tv.Count() != 0)
            {
                var tongdiem = 0;
                var data = DATAGETDONHANG(macn, SODH);
                foreach (var i in data)
                {
                    try
                    {
                        var z = tv.SingleOrDefault(n => n.MAHH == i.MAHH);
                        tongdiem = tongdiem + (int)((Convert.ToInt32(i.SOLUONG) / z.SOLUONG) * z.DIEM);
                    }
                    catch (Exception)
                    {
                        var z = tv.Where(n => n.MAHH == i.MAHH).ToList();
                        if ((i.SOLUONG % z.LastOrDefault().SOLUONG) % z.FirstOrDefault().SOLUONG == 0)
                        {
                            tongdiem = tongdiem + (int)(((Convert.ToInt32(i.SOLUONG) / z.LastOrDefault().SOLUONG) * z.LastOrDefault().DIEM + (i.SOLUONG % z.LastOrDefault().SOLUONG) / z.FirstOrDefault().SOLUONG * z.FirstOrDefault().DIEM));
                        }
                        else if (i.SOLUONG % tv.FirstOrDefault().HOP == 0)
                        {
                            tongdiem = tongdiem + (int)((Convert.ToInt32(i.SOLUONG) / z.FirstOrDefault().SOLUONG * z.FirstOrDefault().DIEM));
                        }
                        else
                        {
                            tongdiem = tongdiem + (int)((Convert.ToInt32(i.SOLUONG) / z.LastOrDefault().SOLUONG) * z.LastOrDefault().DIEM + (i.SOLUONG % z.LastOrDefault().SOLUONG) / z.FirstOrDefault().SOLUONG * z.FirstOrDefault().DIEM);
                        }
                    }
                }
                return Json(tongdiem);
            }
            else
            {
                return Json(0);
            }
        }
        [HttpPost]
        public ActionResult AddDonHangSC(List<DONDATHANG_KD> data1)
        {
            //try
            //{

            List<DTA_DONDATHANG_KD> data = new List<DTA_DONDATHANG_KD>();
            var MACH = GetInfo().TBL_DANHMUCPHANQUYENSC.macn;
            if (data1.First().MADH == 0)
            {
                try
                {
                    data1 = data1.Select(cl => { cl.MADH = Int32.Parse(SC.DTA_DONDATHANG_KD.OrderByDescending(n => n.MADH).FirstOrDefault().MADH) + 1; ; return cl; }).ToList();
                }
                catch (Exception)
                {
                    data1 = data1.Select(cl => { cl.MADH = 1; return cl; }).ToList();
                }
            }
            foreach (var i in data1)
            {
                data.Add(new DTA_DONDATHANG_KD { DONVI = i.DONVI, DUYETDH = false, DVT = i.DVT, MACH = MACH, HOPDONG = i.HOPDONG, MADH = i.MADH.ToString("00000"), MAHH = i.MAHH, MAKH = i.KHACHHANG, NgayDat = DateTime.Now, SOLUONG = i.SOLUONG, STT = i.STT, TENHH = i.TENHH, ck = i.ck, GHICHU = i.GHICHU, GIABAN_VAT = i.GIABAN_VAT, VAT = i.VAT, USERTAO = User.Identity.Name.ToUpper(), MALO = i.MALO, HANDUNG = i.HANDUNG, DATE = i.DATE });
            }
            SC.DTA_DONDATHANG_KD.AddRange(data);
            SC.SaveChanges();
            return Json(data.First().MADH);
            //}
            //catch (Exception)
            //{
            //    return Json(0);
            //}
        }

        [HttpPost]
        public ActionResult DelDonHangSC(string madh)
        {
            var tv = SC.DTA_DONDATHANG_KD.Where(n => n.MADH == madh);
            if (tv.First().DUYETDH == false)
            {
                SC.DTA_DONDATHANG_KD.RemoveRange(tv);
                SC.SaveChanges();
                return Json(0);
            }
            else
            {
                return Json(1);
            }
        }
        [HttpPost]
        public ActionResult AddDonHangKD(List<DONDATHANG_KD> data1)
        {
            //try
            //{

            List<DTA_DONDATHANG_KD> data = new List<DTA_DONDATHANG_KD>();
            var MACH = GetInfo().TBL_DANHMUCPHANQUYENKD.macn;
            if (data1.First().MADH == 0)
            {
                try
                {
                    data1 = data1.Select(cl => { cl.MADH = Int32.Parse(PhuYen.DTA_DONDATHANG_KD.OrderByDescending(n => n.MADH).FirstOrDefault().MADH) + 1; ; return cl; }).ToList();
                }
                catch (Exception)
                {
                    data1 = data1.Select(cl => { cl.MADH = 1; return cl; }).ToList();
                }
            }
            foreach (var i in data1)
            {
                data.Add(new DTA_DONDATHANG_KD { DONVI = i.DONVI, DUYETDH = false, DVT = i.DVT, MACH = MACH, HOPDONG = i.HOPDONG, MADH = i.MADH.ToString("00000"), MAHH = i.MAHH, MAKH = i.KHACHHANG, NgayDat = DateTime.Now, SOLUONG = i.SOLUONG, STT = i.STT, TENHH = i.TENHH, ck = i.ck, GHICHU = i.GHICHU, GIABAN_VAT = i.GIABAN_VAT, VAT = i.VAT, USERTAO = User.Identity.Name.ToUpper(), MALO = i.MALO, HANDUNG = i.HANDUNG, DATE = i.DATE });
            }
            PhuYen.DTA_DONDATHANG_KD.AddRange(data);
            PhuYen.SaveChanges();
            return Json(data.First().MADH);
            //}
            //catch (Exception)
            //{
            //    return Json(0);
            //}
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
            string temp = "";
            // While i < 2= ""
            // temp = str_tien(i)
            // str_tien_donvi = temp
            // End While
            if (chieudai >= 3)
                str_tien_donvi = str_hangdonvi.Substring(chieudai - 3);
            else
                str_tien_donvi = str_hangdonvi;
            // XAC DINH CAC THANH PHAN CUA CHUOI
            i = 0;
            // Dim int_array() As String
            string str_chuoi_so = "";
            try
            {
                // 'doc hang don vi
                // i = str_tien.Length - 1
                while (i <= str_tien_donvi.Length - 1)
                {
                    int int_so = System.Convert.ToInt32(str_tien_donvi[i].ToString());
                    // 'doc hang don vi ''doc h
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
            // ' doc hang ngan 
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
            // Dim str_tien_ty_ty As String
            string str_tien_hang_ngan = "";
            int chieudaichuoitien = str_tong_tien.Length;
            if (str_tong_tien == "0")
                str_tien_don_vi = "Không đồng ";
            else
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

        public string doctien(long thanhtien)
        {

            string str1;
            string str_vat;
            if (thanhtien.ToString().IndexOf(".") != -1)
                str1 = thanhtien.ToString().Remove(thanhtien.ToString().IndexOf("."), thanhtien.ToString().Length - thanhtien.ToString().IndexOf("."));
            else
                str1 = thanhtien.ToString();
            str1 = str1.Replace(",", "");
            str1 = str1.Replace(".", "");
            // MsgBox(str_vat)
            string str_tien = docso(str1);
            if (str_tien.Length > 18)
            {
                var strr = str_tien[2];
                var strr1 = strr.ToString().ToUpper();
                str_tien = str_tien.Remove(2, 1);
                str_tien = str_tien.Insert(2, strr1);
            }
            return str_tien;
        }
        [Authorize(Roles = "KINHDOANHWS")]
        [HttpPost]
        public ActionResult AddHoadonWS(DATA_HOADON_WS hoadon, List<DATA_CHITIET_HOADON_WS> chitiet)
        {
            //var listhttt = PhuYen.Database.SqlQuery<ListHTTT>("select MATT,TENTT from tbl_danhmucHTTTOAN where maTT='" + hoadon.HTTT + "' ");
            var dataz = new Inv()
            {
                key = "WS-" + (((hoadon.MADH != "" && hoadon.MADH != null) == true) ? hoadon.MADH + "-" : "") + DateTime.Now.ToString("yyMMddHHmm"),
                Invoice = new Invoice
                {
                    Buyer = hoadon.TENNGUOIGD + " (" + hoadon.MAKH + ")",
                    //EmailDeliver = hoadon.EMAILKH,
                    EmailDeliver = hoadon.EMAILKH,
                    Amount = 0,
                    AmountInWords = "",
                    CusAddress = hoadon.DIACHI,
                    CusCode = hoadon.MAKH,
                    CusName = hoadon.DONVI,
                    CusPhone = "",
                    CusTaxCode = hoadon.MASOTHUE,
                    DiscountAmount = 0,
                    KindOfService = 0,
                    PaymentMethod = hoadon.HTTT,
                    Total = 0,
                    VATAmount = 0,
                    Extra9 = "",
                    ArisingDate = DateTime.Now.ToString("dd/MM/yyyy"),
                    DiscountRate = 0,
                    GrossValue8 = 0,
                    GrossValue = 0,
                    GrossValue0 = 0,
                    GrossValue10 = 0,
                    GrossValue5 = 0,
                    VatAmount0 = 0,
                    VatAmount10 = 0,
                    VatAmount5 = 0,
                    VatAmount8 = 0,
                    Extra10 = "PY",
                    CusBankName = hoadon.NGANHANG,
                    CusBankNo = hoadon.TAIKHOAN,
                    VATRate = hoadon.PPTT,
                    Products = new Products
                    {
                        Product = new List<Product>
                        {
                        }
                    }
                }
            };

            var listhh = PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3,DVT,DVT1,DVT2 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList();
            var listhd = PhuYen.TBL_CT_DANHMUCHOPDONG_WS.Where(n => n.MACN == "PY" && n.MAHD == hoadon.MAHD).ToList();
            var listhhct = new List<DTA_CT_HOADON_XUAT>();
            var stt = 1;
            foreach (var i in chitiet)
            {
                var tenhh = i.TENHH;
                if (i.MALO != "" && i.MALO != null)
                {
                    tenhh = tenhh + ";" + "Số lô:" + i.MALO;
                }
                if (i.HANDUNG != "" && i.HANDUNG != null)
                {
                    if (i.MALO != "" && i.MALO != null)
                    {
                        tenhh = tenhh + " Hạn dùng:" + i.HANDUNG;
                    }
                    else
                    {
                        tenhh = tenhh + ";" + "Hạn dùng:" + i.HANDUNG;
                    }

                }
                dataz.Invoice.Products.Product.Add(new Product
                {
                    ProdName = tenhh,
                    Code = i.MAHH,
                    ProdUnit = i.DVT + "; (" + i.THUNG + " " + listhh.SingleOrDefault(n => n.MAHH == i.MAHH).DVT1 + " " + +i.HOP + " " + listhh.SingleOrDefault(n => n.MAHH == i.MAHH).DVT2 + ")",
                    ProdPrice = (decimal)listhd.SingleOrDefault(n => n.MAHH == i.MAHH).GIASP,
                    Total = Math.Round(i.SOLUONG * (decimal)listhd.SingleOrDefault(n => n.MAHH == i.MAHH).GIASP),
                    IsSum = hoadon.TINHCHATHOADON,
                    Discount = 0,
                    DiscountAmount = 0,
                    VATRate = hoadon.PPTT,
                    VATAmount = i.SOLUONG * (decimal)listhd.SingleOrDefault(n => n.MAHH == i.MAHH).GIASP * hoadon.PPTT / 100,
                    ProdQuantity = i.SOLUONG
                });
                listhhct.Add(new DTA_CT_HOADON_XUAT() { KTKM = false, SoHD = dataz.key, NgayLapHD = DateTime.Today, MaCH = User.Identity.Name.ToUpper(), MaHH = i.MAHH, TenHH = i.TENHH, DVT = i.DVT, SoLuong = (double)i.SOLUONG, DonGia = (decimal)listhd.SingleOrDefault(n => n.MAHH == i.MAHH).GIASP, ThanhTien = Math.Round((double)(i.SOLUONG * (decimal)listhd.SingleOrDefault(n => n.MAHH == i.MAHH).GIASP)), TyLeCK = 0, MaLo = i.MALO, HanDung = i.HANDUNG, stt = stt, MAKM = "", GHICHU = "", DOWN = "0", KT_KHO = false, KHO = hoadon.KHO, SODK = listhd.SingleOrDefault(n => n.MAHH == i.MAHH).SODK, DONGIA_VAT = (decimal)(listhd.SingleOrDefault(n => n.MAHH == i.MAHH).GIASP * (100 + hoadon.PPTT) / 100), KT = true });
                stt = stt + 1;
            }
            dataz.Invoice.Extra9 = dataz.key + ";PY";
            dataz.Invoice.Total = Math.Round(dataz.Invoice.Products.Product.Sum(n => n.Total));
            dataz.Invoice.VATAmount = Math.Round(dataz.Invoice.Products.Product.Sum(n => n.Total) * hoadon.PPTT / 100);
            dataz.Invoice.Amount = Math.Round(dataz.Invoice.Total + dataz.Invoice.VATAmount);
            dataz.Invoice.AmountInWords = doctien(Decimal.ToInt64(dataz.Invoice.Amount));
            if (hoadon.PPTT == 0)
            {
                dataz.Invoice.VatAmount0 = dataz.Invoice.VATAmount;
                dataz.Invoice.GrossValue0 = dataz.Invoice.Total;
            }
            else if (hoadon.PPTT == 5)
            {
                dataz.Invoice.VatAmount5 = dataz.Invoice.VATAmount;
                dataz.Invoice.GrossValue5 = dataz.Invoice.Total;
            }
            else if (hoadon.PPTT == 8)
            {
                dataz.Invoice.VatAmount8 = dataz.Invoice.VATAmount;
                dataz.Invoice.GrossValue8 = dataz.Invoice.Total;
            }
            else if (hoadon.PPTT == 10)
            {
                dataz.Invoice.VatAmount10 = dataz.Invoice.VATAmount;
                dataz.Invoice.GrossValue10 = dataz.Invoice.Total;
            }
            if (PhuYen.Database.SqlQuery<int>("select count(*) as no from kt_th.dbo.DTA_KHACHHANG_PHEDUYET where pheduyet=1 and makh = '" + hoadon.MAKH + "'  and CONVERT(date, getdate()) between ngaybatdau and ngayketthuc").FirstOrDefault() == 0)
            {
                if (KT_HANMUC_CONGNO(hoadon.MAKH, dataz.Invoice.Amount) == false || KT_HANNO_2(hoadon.MAKH) == false || KT_NGAYNO(hoadon.MAKH) == false)
                {
                    var loi = new ResultAPI() { Status = 0, Message = "Công nợ của khách hàng : " + hoadon.MAKH + " quá hạn mức hoặc quá kỳ hạn nợ !!! Bạn nên kiểm tra lại thông tin khách hàng này " };
                    return Json(loi);
                }
            }

            var x = abc.taovaphathanhhoadon(dataz, "1/001", "K23TPP", "PY");
            if (x.Status == 1 && (hoadon.MADH != null && hoadon.MADH != ""))
            {
                var ddh = PhuYen.DTA_DONDATHANG_WS.Where(n => n.MADH == hoadon.MADH);
                if (ddh != null)
                {
                    foreach (var i in ddh)
                    {
                        i.SOHD = Int32.Parse(x.Message.Split('_')[1].ToString()).ToString("00000000");
                        i.NGAYLAPHD = DateTime.Today;
                        i.NGAYTHUCHIEN = DateTime.Now;
                        i.DUYETDH = true;
                    }
                }
                ////var zz = new DTA_HOADON_XUAT() { SoHD = dataz.key,kt = true,MaTDV ="", NgayLapHD = DateTime.Today, MaPL = hoadon.PHANLOAI, MaKH = hoadon.MAKH, DONVI = hoadon.DONVI, DIACHI = hoadon.DIACHI, kihieu = hoadon.KYHIEU, PPTT = "Tính " + hoadon.PPTT + "%", nhaptaikho = hoadon.KHO, MaTinh = hoadon.MATINH, MATT = hoadon.HTTT, MATHUE = hoadon.MASOTHUE, MaCH = User.Identity.Name.ToUpper(), ThueSuat = hoadon.PPTT, tienvat = dataz.Invoice.VATAmount, tienck = 0, thanhtien_hd = dataz.Invoice.Total, TONGTIEN = dataz.Invoice.Amount, NGAYGIAOHANG = DateTime.Today, TENNGUOIGD = hoadon.TENNGUOIGD, HOPDONG = hoadon.MAHD, CTGS = "", PL = "TP", txttien = dataz.Invoice.AmountInWords, SOHD_DT = Int32.Parse("5").ToString("00000000"), ngaytt = layngaytt(DateTime.Today, hoadon.MAKH), KT_CHANLE = false };
                ////PhuYen.DTA_HOADON_XUAT.Add(zz);
                var zz = new DTA_HOADON_XUAT() { SoHD = dataz.key, kt = null, MaTDV = "", NgayLapHD = DateTime.Today, MaPL = hoadon.PHANLOAI, MaKH = hoadon.MAKH, DONVI = hoadon.DONVI, DIACHI = hoadon.DIACHI, kihieu = hoadon.KYHIEU, PPTT = "Tính " + hoadon.PPTT + "%", nhaptaikho = hoadon.KHO, MaTinh = hoadon.MATINH, MATT = hoadon.HTTT, MATHUE = hoadon.MASOTHUE, MaCH = User.Identity.Name.ToUpper(), ThueSuat = hoadon.PPTT, tienvat = dataz.Invoice.VATAmount, tienck = 0, thanhtien_hd = dataz.Invoice.Total, TONGTIEN = dataz.Invoice.Amount, NGAYGIAOHANG = DateTime.Today, TENNGUOIGD = hoadon.TENNGUOIGD, HOPDONG = hoadon.MAHD, CTGS = "", PL = "TP", txttien = dataz.Invoice.AmountInWords, SOHD_DT = Int32.Parse(x.Message.Split('_')[1].ToString()).ToString("00000000"), ngaytt = layngaytt(DateTime.Today, hoadon.MAKH), KT_CHANLE = false };
                PhuYen.DTA_HOADON_XUAT.Add(zz);
                PhuYen.DTA_CT_HOADON_XUAT.AddRange(listhhct);
                PhuYen.SaveChanges();
            }
            if (x.Status == 1)
            {
                x.Message = Int32.Parse(x.Message.Split('_')[1].ToString()).ToString("00000000");
            }
            return Json(0);
        }
        public DateTime layngaytt(DateTime ngayct, string makh)
        {
            // Dim ngaytt As Date
            string str = " select ngayno from TBL_DANHMUCKHACHHANG where makh='" + makh + "' AND NGAYNO IS NOT NULL ";

            int ngay = 0, thang = 0, nam = 0, ngay_du = 0;

            try
            {
                thang = ngayct.Month;
                nam = ngayct.Year;
                ngay = ngayct.Day;
                var dta = PhuYen.Database.SqlQuery<int>(str);

                if (dta.Count() > 0)
                {

                    try
                    {
                        thang = thang + dta.First() / 30;
                        ngay_du = dta.First() % 30;
                    }
                    catch (Exception ex)
                    {
                    }

                }
                else
                {
                    str = " select ngayno from TBL_NGAYNO ";
                    var dta1 = PhuYen.Database.SqlQuery<int>(str);

                    try
                    {
                        thang = thang + dta1.First() / 30;
                        ngay_du = dta1.First() % 30;
                    }
                    catch (Exception ex)
                    {
                    }

                }
            }
            catch (Exception ex)
            {
            }


            if (thang - 12 == 2)
            {
                if (ngay_du + ngay >= 28)
                {
                    thang = thang + 1;
                    ngay = ngay_du + ngay - 28;
                }
                else
                    ngay = ngay_du + ngay;
            }
            else if (ngay_du + ngay >= 30)
            {
                thang = thang + 1;
                ngay = ngay_du + ngay - 30;
            }
            else
                ngay = ngay_du + ngay;

            if (thang > 12)
            {
                thang = thang - 12;
                nam = nam + 1;
            }

            if (ngay == 0)
                ngay = 1;

            return System.Convert.ToDateTime(ngay + "/" + thang + "/" + nam);
        }


        [Authorize(Roles = "KINHDOANHWS")]
        [HttpPost]
        public ActionResult Hoadonmau(DATA_HOADON_WS hoadon, List<DATA_CHITIET_HOADON_WS> chitiet)
        {
            //var listhttt = PhuYen.Database.SqlQuery<ListHTTT>("select MATT,TENTT from tbl_danhmucHTTTOAN where maTT='" + hoadon.HTTT + "' ");
            var dataz = new Inv()
            {

                Invoice = new Invoice
                {
                    Buyer = hoadon.TENNGUOIGD + " (" + hoadon.MAKH + ")",
                    //EmailDeliver = hoadon.EMAILKH,
                    EmailDeliver = hoadon.EMAILKH,
                    Amount = 0,
                    AmountInWords = "",
                    CusAddress = hoadon.DIACHI,
                    CusCode = hoadon.MAKH,
                    CusName = hoadon.DONVI,
                    CusPhone = "",
                    CusTaxCode = hoadon.MASOTHUE,
                    DiscountAmount = 0,
                    KindOfService = 0,
                    PaymentMethod = hoadon.HTTT,
                    Total = 0,
                    VATAmount = 0,
                    Extra9 = "",
                    ArisingDate = DateTime.Now.ToString("dd/MM/yyyy"),
                    DiscountRate = 0,
                    GrossValue8 = 0,
                    GrossValue = 0,
                    GrossValue0 = 0,
                    GrossValue10 = 0,
                    GrossValue5 = 0,
                    VatAmount0 = 0,

                    VatAmount10 = 0,
                    VatAmount5 = 0,
                    VatAmount8 = 0,
                    Extra10 = "PY",
                    CusBankName = hoadon.NGANHANG,
                    CusBankNo = hoadon.TAIKHOAN,
                    VATRate = hoadon.PPTT,
                    Products = new Products
                    {
                        Product = new List<Product>
                        {
                        }
                    }
                }
            };

            var listhh = PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3,DVT,DVT1,DVT2 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList();
            var listhd = PhuYen.TBL_CT_DANHMUCHOPDONG_WS.Where(n => n.MACN == "PY" && n.MAHD == hoadon.MAHD).ToList();
            foreach (var i in chitiet)
            {
                var tenhh = i.TENHH;
                if (i.MALO != "" && i.MALO != null)
                {
                    tenhh = tenhh + ";" + "Số lô:" + i.MALO;
                }
                if (i.HANDUNG != "" && i.HANDUNG != null)
                {
                    if (i.MALO != "" && i.MALO != null)
                    {
                        tenhh = tenhh + " Hạn dùng:" + i.HANDUNG;
                    }
                    else
                    {
                        tenhh = tenhh + ";" + "Hạn dùng:" + i.HANDUNG;
                    }

                }
                dataz.Invoice.Products.Product.Add(new Product
                {
                    ProdName = tenhh,
                    Code = i.MAHH,
                    ProdUnit = i.DVT + "; (" + i.THUNG + " " + listhh.SingleOrDefault(n => n.MAHH == i.MAHH).DVT1 + " " + +i.HOP + " " + listhh.SingleOrDefault(n => n.MAHH == i.MAHH).DVT2 + ")",
                    ProdPrice = (decimal)listhd.SingleOrDefault(n => n.MAHH == i.MAHH).GIASP,
                    Total = i.SOLUONG * (decimal)listhd.SingleOrDefault(n => n.MAHH == i.MAHH).GIASP,
                    IsSum = hoadon.TINHCHATHOADON,
                    Discount = 0,
                    DiscountAmount = 0,
                    VATRate = hoadon.PPTT,
                    VATAmount = i.SOLUONG * (decimal)listhd.SingleOrDefault(n => n.MAHH == i.MAHH).GIASP * hoadon.PPTT / 100,
                    ProdQuantity = i.SOLUONG
                });
            }
            dataz.Invoice.Extra9 = dataz.key + ";MÃ CN";
            dataz.Invoice.Total = dataz.Invoice.Products.Product.Sum(n => n.Total);
            dataz.Invoice.VATAmount = Math.Round(dataz.Invoice.Products.Product.Sum(n => n.Total) * hoadon.PPTT / 100);
            dataz.Invoice.Amount = dataz.Invoice.Total + dataz.Invoice.VATAmount;
            dataz.Invoice.AmountInWords = doctien(Decimal.ToInt64(dataz.Invoice.Amount));
            if (hoadon.PPTT == 0)
            {
                dataz.Invoice.VatAmount0 = dataz.Invoice.VATAmount;
                dataz.Invoice.GrossValue0 = dataz.Invoice.Total;
            }
            else if (hoadon.PPTT == 5)
            {
                dataz.Invoice.VatAmount5 = dataz.Invoice.VATAmount;
                dataz.Invoice.GrossValue5 = dataz.Invoice.Total;
            }
            else if (hoadon.PPTT == 8)
            {
                dataz.Invoice.VatAmount8 = dataz.Invoice.VATAmount;
                dataz.Invoice.GrossValue8 = dataz.Invoice.Total;
            }
            else if (hoadon.PPTT == 10)
            {
                dataz.Invoice.VatAmount10 = dataz.Invoice.VATAmount;
                dataz.Invoice.GrossValue10 = dataz.Invoice.Total;
            }
            dataz.Invoice.InvoiceNo = "0";
            ViewBag.pattern = hoadon.KYHIEU;
            //var sohddt = Int32.Parse(dataz.Invoice.InvoiceNo).ToString("00000000");
            var diachigiaohang = hoadon.DIACHIGIAOHANG;
            ViewBag.CurrentNumberFormat = new CultureInfo("de-DE");
            var tv = datainvoice.TBL_DANHMUCTAIKHOAN.SingleOrDefault(n => n.macn == "PY");

            var datamau = new PHIEUXUATKHO() { thongtin = tv, Invoice = dataz.Invoice, DIACHIGIAOHANG = diachigiaohang };
            return View("HtmlPhieugiaohang", datamau);
        }
        private bool KT_HANNO_2(string mAKH)
        {
            var kyhan = PhuYen.Database.SqlQuery<THONGTINKYHANNO>("exec sp_kyhan_capnhap_DENNGAY_MAKH_KIEMTRA '131','" + mAKH + "'").ToList();
            if (kyhan.Count() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private bool KT_NGAYNO(string mAKH)
        {
            var ngayno = PhuYen.Database.SqlQuery<int>("select count(*) as no from [kiemtra_kyhancongno] ('131','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + mAKH + "')").ToList();
            if (ngayno.First() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private bool KT_HANMUC_CONGNO(string mAKH, decimal tongtien)
        {
            var nocuoiky = PhuYen.Database.SqlQuery<THONGTINNO>("exec THONGKEDOANHSO_MAKH_NGAY_HANMUC '" + DateTime.Today.ToString("yyyy-01-01") + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + mAKH + "'").ToList();
            decimal tienno = 0;
            if (nocuoiky.First().COCUOIKY > 0)
            {
                tienno = nocuoiky.First().COCUOIKY * -1;
            }
            else
            {
                tienno = nocuoiky.First().NOCUOIKY;
            }
            var hanmuc = PhuYen.Database.SqlQuery<double>("select HANMUC from TBL_DANHMUCKHACHHANG where makh = '" + mAKH + "'").ToList();
            tongtien = tongtien + tienno;
            if (tongtien > (decimal)hanmuc.First())
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        [HttpPost]
        public ActionResult AddDonHangWS(List<DONDATHANG_WS> data1)
        {
            //try
            //{

            List<DTA_DONDATHANG_WS> data = new List<DTA_DONDATHANG_WS>();
            var MACH = GetInfo().TBL_DANHMUCPHANQUYENWS.macn;
            if (data1.First().MADH == 0)
            {
                try
                {
                    data1 = data1.Select(cl => { cl.MADH = Int32.Parse(PhuYen.DTA_DONDATHANG_WS.OrderByDescending(n => n.MADH).FirstOrDefault().MADH) + 1; ; return cl; }).ToList();
                }
                catch (Exception)
                {
                    data1 = data1.Select(cl => { cl.MADH = 1; return cl; }).ToList();
                }
            }
            foreach (var i in data1)
            {
                data.Add(new DTA_DONDATHANG_WS { DONVI = i.DONVI, DUYETDH = false, DVT = i.DVT, MACH = MACH, HOPDONG = i.HOPDONG, DIACHIGIAOHANG = i.DIACHIGIAOHANG, MADH = i.MADH.ToString("00000"), MAHH = i.MAHH, MAKH = i.KHACHHANG, NgayDat = DateTime.Now, SOLUONG = i.SOLUONG, STT = i.STT, TENHH = i.TENHH, GHICHU = i.GHICHU, USERTAO = User.Identity.Name.ToUpper(), MALO = i.MALO, HANDUNG = i.HANDUNG });
            }
            PhuYen.DTA_DONDATHANG_WS.AddRange(data);
            PhuYen.SaveChanges();
            return Json(data.First().MADH);
            //}
            //catch (Exception)
            //{
            //    return Json(0);
            //}
        }
        [HttpPost]
        public ActionResult DelDonHangKD(string madh)
        {
            var tv = PhuYen.DTA_DONDATHANG_KD.Where(n => n.MADH == madh);
            if (tv.First().DUYETDH == false)
            {
                PhuYen.DTA_DONDATHANG_KD.RemoveRange(tv);
                PhuYen.SaveChanges();
                return Json(0);
            }
            else
            {
                return Json(1);
            }
        }
        [HttpPost]
        public ActionResult DelDonHangWS(string madh)
        {
            var tv = PhuYen.DTA_DONDATHANG_WS.Where(n => n.MADH == madh);
            if (tv.First().DUYETDH == false)
            {
                PhuYen.DTA_DONDATHANG_WS.RemoveRange(tv);
                PhuYen.SaveChanges();
                return Json(0);
            }
            else
            {
                return Json(1);
            }
        }
        [HttpPost]
        public ActionResult AddDonHangHCM(List<DONDATHANG_KD> data1)
        {
            try
            {
                List<DTA_DONDATHANG_KD> data = new List<DTA_DONDATHANG_KD>();
                var MACH = GetInfo().TBL_DANHMUCPHANQUYENHCM.macn;
                if (data1.First().MADH == 0)
                {
                    try
                    {
                        data1 = data1.Select(cl => { cl.MADH = Int32.Parse(HoChiMinh.DTA_DONDATHANG_KD.OrderByDescending(n => n.MADH).FirstOrDefault().MADH) + 1; ; return cl; }).ToList();
                    }
                    catch (Exception)
                    {
                        data1 = data1.Select(cl => { cl.MADH = 1; return cl; }).ToList();
                    }
                }
                foreach (var i in data1)
                {
                    data.Add(new DTA_DONDATHANG_KD { DONVI = i.DONVI, DUYETDH = false, DVT = i.DVT, MACH = MACH, HOPDONG = i.HOPDONG, MADH = i.MADH.ToString("00000"), MAHH = i.MAHH, MAKH = i.KHACHHANG, NgayDat = DateTime.Now, SOLUONG = i.SOLUONG, STT = i.STT, TENHH = i.TENHH, ck = i.ck, GHICHU = i.GHICHU, GIABAN_VAT = i.GIABAN_VAT, VAT = i.VAT, USERTAO = User.Identity.Name.ToUpper(), MALO = i.MALO, HANDUNG = i.HANDUNG, DATE = i.DATE });
                }
                HoChiMinh.DTA_DONDATHANG_KD.AddRange(data);
                HoChiMinh.SaveChanges();
                return Json(data.First().MADH);
            }
            catch (Exception)
            {
                return Json(0);
            }
        }

        [HttpPost]
        public ActionResult DelDonHangHCM(string madh)
        {
            var tv = HoChiMinh.DTA_DONDATHANG_KD.Where(n => n.MADH == madh);
            if (tv.First().DUYETDH == false)
            {
                HoChiMinh.DTA_DONDATHANG_KD.RemoveRange(tv);
                HoChiMinh.SaveChanges();
                return Json(0);
            }
            else
            {
                return Json(1);
            }
        }
        public void DATA_ADD(string x, List<DTA_DONDATHANG> data)
        {
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                queryCN.SingleOrDefault(n => n.macn == x).data.DTA_DONDATHANG.AddRange(data);
                queryCN.SingleOrDefault(n => n.macn == x).data.SaveChanges();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
            {
                queryCH.SingleOrDefault(n => n.macn == x).data.DTA_DONDATHANG.AddRange(data);
                queryCH.SingleOrDefault(n => n.macn == x).data.SaveChanges();
            }
        }
        public ListData DATA(string x, string MATDV, DateTime tungay, DateTime denngay)
        {
            string strcn = "";
            string strch = "";
            List<string> listMATDV = null;
            if (MATDV != null)
            {
                listMATDV = MATDV.Split(',').ToList();
                strcn = "SELECT makh AS MAKH, donvi AS DONVI, matdv AS MATDV, diachi AS DIACHI,phanloaikhachhang from TBL_DANHMUCKHACHHANG" + string.Format(" WHERE (matdv IN ({0}) or matdv = '' or matdv is null) and (tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch')", string.Join(",", listMATDV.Select(p => "'" + p + "'")));
                strch = "SELECT makh AS MAKH, donvi AS DONVI, matdv AS MATDV, diachi AS DIACHI,phanloaikhachhang from DM_KHACHHANG_PTTT" + string.Format(" WHERE (matdv IN ({0}) or matdv = '' or matdv is null) and (tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch')", string.Join(",", listMATDV.Select(p => "'" + p + "'")));
            }
            else
            {
                strcn = "SELECT makh AS MAKH, donvi AS DONVI, matdv AS MATDV, diachi AS DIACHI, phanloaikhachhang from TBL_DANHMUCKHACHHANG WHERE tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch'";
                strch = "SELECT makh AS MAKH, donvi AS DONVI, matdv AS MATDV, phanloaikhachhang from DM_KHACHHANG_PTTT WHERE tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch'";
            }
            string strcnctkm = "SELECT MACTKM AS MACTKM, TENCTKM AS TENCTKM from TBL_DANHMUCKM WHERE MaCTKM IS NOT NULL AND (ngayketthuc is null or ngayketthuc >= '" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
            string strcnhh = "SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN from TBL_DANHMUCHANGHOA where 1=1 and GIABAN != '0' and sudung = 1";
            var DATAX = new ListData();
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                var enti = queryCN.SingleOrDefault(n => n.macn == x).data;
                DATAX.ListCTKM = enti.Database.SqlQuery<ListChuongTrinhKM>(strcnctkm).ToList();
                DATAX.ListHH = enti.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3,QUICACH as QUICACH from TBL_DANHMUCHANGHOA where GIABAN != '0' and SL3 is not null").ToList();
                DATAX.ListKH = enti.Database.SqlQuery<ListKhachHang>(strcn).ToList();
                if (listMATDV != null)
                {
                    DATAX.ListDDH = enti.DTA_DONDATHANG.Where(n => (listMATDV.Contains(n.MATDV) || n.USERTAO == User.Identity.Name) && n.NgayDat >= tungay && n.NgayDat < denngay).GroupBy(n => n.MADH).ToList().Select(cl => new DTA_DONDATHANG { MADH = cl.Key, DONVI = cl.First().DONVI, NgayDat = cl.First().NgayDat, DUYETDH = cl.OrderByDescending(n => n.DUYETDH).First().DUYETDH, USERTAO = cl.First().USERTAO }).ToList();
                }
                else
                {
                    var don = enti.DTA_DONDATHANG.Where(n => n.NgayDat >= tungay && n.NgayDat < denngay).ToList();

                    DATAX.ListDDH = don.GroupBy(n => n.MADH).Select(cl => new DTA_DONDATHANG { MADH = cl.Key, DONVI = cl.First().DONVI, NgayDat = cl.First().NgayDat, DUYETDH = cl.OrderByDescending(n => n.DUYETDH).First().DUYETDH, USERTAO = cl.First().USERTAO }).ToList();
                }
            }
            return DATAX;
        }
        public List<ListChuongTrinhKM> DATACTHT(List<string> macn)
        {
            if (macn == null)
            {
                macn = "TT423,GL,NA,DNA,QN,HUE,BD,NT".Split(',').ToList();
            }
            var DATAX = new List<ListChuongTrinhKM>();
            //string strcnctkm = "SELECT MACTKM AS MACTKM, TENCTKM AS TENCTKM from TBL_DANHMUCKM WHERE MaCTKM IS NOT NULL AND (ngayketthuc is null or ngayketthuc >= '" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
            //foreach (var x in macn)
            //{
            //    if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            //    {
            //        if (x == "TT423")
            //        {
            //            DATAX.AddRange(TT423.Database.SqlQuery<ListChuongTrinhKM>("SELECT MACTKM AS MACTKM, TENCTKM AS TENCTKM from TBL_DANHMUCKHUYENMAI WHERE MaCTKM IS NOT NULL AND (ngaykt = '' or convert(datetime, ngaykt, 103) >= '" + DateTime.Now.ToString("yyyy/MM/dd") + "')").ToList());
            //        }
            //        else
            //        {
            //            DATAX.AddRange(queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<ListChuongTrinhKM>(strcnctkm).ToList());
            //        }
            //    }
            //}
            DATAX.AddRange(DATATH1.TBL_DANHMUCKM.Select(cl => new ListChuongTrinhKM { MACTKM = cl.MACTKM, TENCTKM = cl.TENCTKM }));
            return DATAX.GroupBy(c => c.MACTKM).Select(cl => new ListChuongTrinhKM { MACTKM = cl.Key, TENCTKM = cl.FirstOrDefault().TENCTKM }).OrderBy(n => n.MACTKM).ToList();
        }
        public ListData DATATAO(string x, string MATDV)
        {
            string strcn = "";
            string strch = "";
            if (MATDV != null)
            {
                var listMATDV = MATDV.Split(',').ToList();
                strcn = "SELECT makh AS MAKH, donvi AS DONVI ,hanmuc as HANMUC, matdv AS MATDV, diachi AS DIACHI, phanloaikhachhang from TBL_DANHMUCKHACHHANG" + string.Format(" WHERE (matdv IN ({0}) or matdv = '' or matdv is null) and (tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch')", string.Join(",", listMATDV.Select(p => "'" + p + "'")));
                strch = "SELECT makh AS MAKH, donvi AS DONVI ,hanmuc as HANMUC, matdv AS MATDV, diachi AS DIACHI, phanloaikhachhang from DM_KHACHHANG_PTTT" + string.Format(" WHERE (matdv IN ({0})" + ((x == "PTTT") ? " or matdv2 IN ({0}) " : "") + " or matdv = '' or matdv is null) and (tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch')", string.Join(",", listMATDV.Select(p => "'" + p + "'")));
            }
            else
            {
                strcn = "SELECT makh AS MAKH, donvi AS DONVI,hanmuc as HANMUC, matdv AS MATDV, diachi AS DIACHI,phanloaikhachhang from TBL_DANHMUCKHACHHANG WHERE tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch'";
                strch = "SELECT makh AS MAKH, donvi AS DONVI,hanmuc as HANMUC, matdv AS MATDV, phanloaikhachhang from DM_KHACHHANG_PTTT WHERE tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch'";
            }
            string strcnctkm = "SELECT MACTKM AS MACTKM, TENCTKM AS TENCTKM,ngaybatdau,ngayketthuc from TBL_DANHMUCKM WHERE MaCTKM IS NOT NULL AND (ngayketthuc is null or (ngayketthuc >= '" + DateTime.Now.ToString("yyyy/MM/dd") + "' and ngaybatdau <= '" + DateTime.Now.ToString("yyyy/MM/dd") + "'))";
            string strcnhh = "SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN , quicach as QUICACH, nhom as NHOM from TBL_DANHMUCHANGHOA where 1=1 and GIABAN != '0' and sudung = 1";
            var DATAX = new ListData();
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                var enti = queryCN.SingleOrDefault(n => n.macn == x).data;
                DATAX.ListCTKM = enti.Database.SqlQuery<ListChuongTrinhKM>(strcnctkm).ToList();
                DATAX.ListHH = enti.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3,QUICACH as QUICACH, nhom as NHOM from TBL_DANHMUCHANGHOA where GIABAN != '0' and SL3 is not null").ToList();
                DATAX.ListKH = enti.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }

            //if (x == "QT")
            //{
            //    DATAX.ListCTKM = QuangTri.Database.SqlQuery<ListChuongTrinhKM>(strcnctkm).ToList();
            //    DATAX.ListHH = QuangTri.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3,QUICACH as QUICACH, nhom as NHOM from TBL_DANHMUCHANGHOA where GIABAN != '0' and SL3 is not null").ToList();
            //    DATAX.ListKH = QuangTri.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            //}
            //else if (x == "DPY")
            //{
            //    DATAX.ListCTKM = Pypharm.Database.SqlQuery<ListChuongTrinhKM>(strcnctkm).ToList();
            //    DATAX.ListHH = Pypharm.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3,QUICACH as QUICACH, nhom as NHOM from TBL_DANHMUCHANGHOA where GIABAN != '0' and SL3 is not null").ToList();
            //    DATAX.ListKH = Pypharm.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            //}
            //else if (x == "DPY_HCM")
            //{
            //    DATAX.ListCTKM = Pypharm.Database.SqlQuery<ListChuongTrinhKM>(strcnctkm).ToList();
            //    DATAX.ListHH = Pypharm.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3,QUICACH as QUICACH, nhom as NHOM from TBL_DANHMUCHANGHOA where GIABAN != '0' and SL3 is not null").ToList();
            //    DATAX.ListKH = Pypharm.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            //}

            return DATAX;
        }
        public List<DTA_DONDATHANG> DATAGETQLDH(string x, string matdv, string tungay, string denngay)
        {
            DateTime dt1 = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(tungay), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(denngay), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1);
            var DATAX = new List<DTA_DONDATHANG>();
            if (matdv != "ALL")
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX = queryCN.SingleOrDefault(n => n.macn == x).data.DTA_DONDATHANG.Where(n => n.MATDV == matdv && n.NgayDat >= dt1 && n.NgayDat <= dt2).OrderByDescending(n => n.MADH).Take(1000).GroupBy(n => n.MADH).ToList().Select(cl => new DTA_DONDATHANG { NgayGiao = (DateTime?)cl.First().NgayGiao, MADH = cl.Key, DONVI = cl.First().DONVI, NgayDat = cl.First().NgayDat, DUYETDH = cl.OrderByDescending(n => n.DUYETDH).First().DUYETDH, USERTAO = cl.First().USERTAO, MACH = cl.First().MACH, MATDV = cl.First().MATDV }).ToList();
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX = queryCH.SingleOrDefault(n => n.macn == x).data.DTA_DONDATHANG.Where(n => n.MATDV == matdv && n.NgayDat >= dt1 && n.NgayDat <= dt2).OrderByDescending(n => n.MADH).Take(1000).GroupBy(n => n.MADH).ToList().Select(cl => new DTA_DONDATHANG { NgayGiao = (DateTime?)cl.First().NgayGiao, MADH = cl.Key, DONVI = cl.First().DONVI, NgayDat = cl.First().NgayDat, DUYETDH = cl.OrderByDescending(n => n.DUYETDH).First().DUYETDH, USERTAO = cl.First().USERTAO, MACH = cl.First().MACH, MATDV = cl.First().MATDV }).ToList();
                }
            }
            else
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX = queryCN.SingleOrDefault(n => n.macn == x).data.DTA_DONDATHANG.Where(n => n.NgayDat >= dt1 && n.NgayDat <= dt2).OrderByDescending(n => n.MADH).Take(1000).GroupBy(n => n.MADH).ToList().Select(cl => new DTA_DONDATHANG { NgayGiao = (DateTime?)cl.First().NgayGiao, MADH = cl.Key, DONVI = cl.First().DONVI, NgayDat = cl.First().NgayDat, DUYETDH = cl.OrderByDescending(n => n.DUYETDH).First().DUYETDH, USERTAO = cl.First().USERTAO, MACH = cl.First().MACH, MATDV = cl.First().MATDV }).ToList();
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX = queryCH.SingleOrDefault(n => n.macn == x).data.DTA_DONDATHANG.Where(n => n.NgayDat >= dt1 && n.NgayDat <= dt2).OrderByDescending(n => n.MADH).Take(1000).GroupBy(n => n.MADH).ToList().Select(cl => new DTA_DONDATHANG { NgayGiao = (DateTime?)cl.First().NgayGiao, MADH = cl.Key, DONVI = cl.First().DONVI, NgayDat = cl.First().NgayDat, DUYETDH = cl.OrderByDescending(n => n.DUYETDH).First().DUYETDH, USERTAO = cl.First().USERTAO, MACH = cl.First().MACH, MATDV = cl.First().MATDV }).ToList();
                }
            }
            return DATAX;
        }

        public List<DTA_DONDATHANG> DATAGETDONHANG(string x, string MADH)
        {
            var DATAX = new List<DTA_DONDATHANG>();
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                DATAX = queryCN.SingleOrDefault(n => n.macn == x).data.DTA_DONDATHANG.Where(n => n.MADH == MADH).ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
            {
                DATAX = queryCH.SingleOrDefault(n => n.macn == x).data.DTA_DONDATHANG.Where(n => n.MADH == MADH).ToList();
            }
            var datahh = SC.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,CAST(kiemsoat AS INT) as kiemsoat,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where mahh ='" + DATAX.First().MAHH + "'").First();
            var tpcn = db2.TBL_DANHMUCTPCN.Select(n => n.mahh).ToList();
            if (tpcn.Contains(datahh.MAHH))
            {
                foreach (var i in DATAX)
                {
                    i.NGUOIDUYET = "2";
                }
            }
            else
            {
                foreach (var i in DATAX)
                {
                    i.NGUOIDUYET = datahh.kiemsoat.ToString();
                }
            }
            return DATAX;
        }
        [HttpPost]
        public ActionResult GetEditHoaDon(string Id)
        {
            var Infocrm = GetCRM();
            var MACH = Infocrm.macn;
            var data = DATAGETDONHANG(MACH, Id);
            return Json(data.OrderByDescending(n => n.DUYETDH).ThenBy(n => n.STT));
        }

        [HttpPost]
        public ActionResult GetEditDonHangQLDH(string Id, string macn)
        {
            var data = DATAGETDONHANG(macn, Id);
            return Json(data.OrderByDescending(n => n.DUYETDH).ThenBy(n => n.STT));
        }
        [HttpPost]
        public ActionResult GetEditDonHangKD(string Id)
        {
            var data = PhuYen.DTA_DONDATHANG_KD.Where(n => n.MADH == Id).ToList();
            var user = data.FirstOrDefault().USERTAO;
            var ten = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == user).hoten;
            var hh = PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList();
            return Json(data.Select(cl => new DTA_DONDATHANG_KD_QUYDOI { USERTAO = ten, MALO = cl.MALO, HANDUNG = cl.HANDUNG, ck = cl.ck, DATE = cl.DATE, DONVI = cl.DONVI, DUYETDH = cl.DUYETDH, DVT = cl.DVT, GHICHU = cl.GHICHU, GIABAN_VAT = cl.GIABAN_VAT, THUNG = ((int)cl.SOLUONG / (int)hh.SingleOrDefault(n => n.MAHH == cl.MAHH).SL3), HOPDONG = cl.HOPDONG, MACH = cl.MACH, MADH = cl.MADH, MAHH = cl.MAHH, MAKH = cl.MAKH, NgayDat = cl.NgayDat, NGAYLAPHD = cl.NGAYLAPHD, NGAYTHUCHIEN = cl.NGAYTHUCHIEN, SOHD = cl.SOHD, SOLUONG = cl.SOLUONG, STT = cl.STT, TENHH = cl.TENHH, HOP = ((int)(((int)cl.SOLUONG % (int)hh.SingleOrDefault(n => n.MAHH == cl.MAHH).SL3)) * hh.SingleOrDefault(n => n.MAHH == cl.MAHH).SL2 / hh.SingleOrDefault(n => n.MAHH == cl.MAHH).SL3), VAT = cl.VAT }).OrderByDescending(n => n.DUYETDH).ThenBy(n => n.STT));
        }
        [HttpPost]
        public ActionResult GetEditDonHangWS(string Id)
        {
            var data = PhuYen.DTA_DONDATHANG_WS.Where(n => n.MADH == Id).ToList();
            var user = data.FirstOrDefault().USERTAO;
            var ten = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == user).hoten;
            var hh = PhuYen.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList();
            return Json(data.Select(cl => new DTA_DONDATHANG_KD_QUYDOI { USERTAO = ten, MALO = cl.MALO, HANDUNG = cl.HANDUNG, DONVI = cl.DONVI, DUYETDH = cl.DUYETDH, DVT = cl.DVT, GHICHU = cl.GHICHU, THUNG = ((int)cl.SOLUONG / (int)hh.SingleOrDefault(n => n.MAHH == cl.MAHH).SL3), HOPDONG = cl.HOPDONG, MACH = cl.MACH, MADH = cl.MADH, DIACHIGIAOHANG = cl.DIACHIGIAOHANG, MAHH = cl.MAHH, MAKH = cl.MAKH, NgayDat = cl.NgayDat, NGAYLAPHD = cl.NGAYLAPHD, NGAYTHUCHIEN = cl.NGAYTHUCHIEN, SOHD = cl.SOHD, SOLUONG = cl.SOLUONG, STT = cl.STT, TENHH = cl.TENHH, HOP = ((int)(((int)cl.SOLUONG % (int)hh.SingleOrDefault(n => n.MAHH == cl.MAHH).SL3)) * hh.SingleOrDefault(n => n.MAHH == cl.MAHH).SL2 / hh.SingleOrDefault(n => n.MAHH == cl.MAHH).SL3) }).OrderByDescending(n => n.DUYETDH).ThenBy(n => n.STT));
        }
        [HttpPost]
        public ActionResult GetEditDonHangSC(string Id)
        {
            var data = SC.DTA_DONDATHANG_KD.Where(n => n.MADH == Id).ToList();
            var user = data.FirstOrDefault().USERTAO;
            var ten = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == user).hoten;
            var hh = SC.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList();
            return Json(data.Select(cl => new DTA_DONDATHANG_KD_QUYDOI { USERTAO = ten, MALO = cl.MALO, HANDUNG = cl.HANDUNG, ck = cl.ck, DATE = cl.DATE, DONVI = cl.DONVI, DUYETDH = cl.DUYETDH, DVT = cl.DVT, GHICHU = cl.GHICHU, GIABAN_VAT = cl.GIABAN_VAT, THUNG = ((int)cl.SOLUONG / (int)hh.SingleOrDefault(n => n.MAHH == cl.MAHH).SL3), HOPDONG = cl.HOPDONG, MACH = cl.MACH, MADH = cl.MADH, MAHH = cl.MAHH, MAKH = cl.MAKH, NgayDat = cl.NgayDat, NGAYLAPHD = cl.NGAYLAPHD, NGAYTHUCHIEN = cl.NGAYTHUCHIEN, SOHD = cl.SOHD, SOLUONG = cl.SOLUONG, STT = cl.STT, TENHH = cl.TENHH, HOP = ((int)(((int)cl.SOLUONG % (int)hh.SingleOrDefault(n => n.MAHH == cl.MAHH).SL3)) * hh.SingleOrDefault(n => n.MAHH == cl.MAHH).SL2 / hh.SingleOrDefault(n => n.MAHH == cl.MAHH).SL3), VAT = cl.VAT }).OrderByDescending(n => n.DUYETDH).ThenBy(n => n.STT));
        }
        [HttpPost]
        public ActionResult GetEditDonHangHCM(string Id)
        {
            var data = HoChiMinh.DTA_DONDATHANG_KD.Where(n => n.MADH == Id).ToList();
            var user = data.FirstOrDefault().USERTAO;
            var ten = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == user).hoten;
            var hh = HoChiMinh.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where SL3 is not null and SL2 is not null and SL1 is not null").ToList();
            return Json(data.Select(cl => new DTA_DONDATHANG_KD_QUYDOI { USERTAO = ten, MALO = cl.MALO, HANDUNG = cl.HANDUNG, ck = cl.ck, DATE = cl.DATE, DONVI = cl.DONVI, DUYETDH = cl.DUYETDH, DVT = cl.DVT, GHICHU = cl.GHICHU, GIABAN_VAT = cl.GIABAN_VAT, THUNG = ((int)cl.SOLUONG / (int)hh.SingleOrDefault(n => n.MAHH == cl.MAHH).SL3), HOPDONG = cl.HOPDONG, MACH = cl.MACH, MADH = cl.MADH, MAHH = cl.MAHH, MAKH = cl.MAKH, NgayDat = cl.NgayDat, NGAYLAPHD = cl.NGAYLAPHD, NGAYTHUCHIEN = cl.NGAYTHUCHIEN, SOHD = cl.SOHD, SOLUONG = cl.SOLUONG, STT = cl.STT, TENHH = cl.TENHH, HOP = ((int)(((int)cl.SOLUONG % (int)hh.SingleOrDefault(n => n.MAHH == cl.MAHH).SL3)) * hh.SingleOrDefault(n => n.MAHH == cl.MAHH).SL2 / hh.SingleOrDefault(n => n.MAHH == cl.MAHH).SL3), VAT = cl.VAT }).OrderByDescending(n => n.DUYETDH).ThenBy(n => n.STT));
        }

        [HttpPost]
        public ActionResult GetDuyetHoaDon(string Id)
        {
            var Info = GetInfo();
            var MACH = Info.macn;
            var data = DATAGETDONHANG(MACH, Id);
            return Json(data.OrderBy(n => n.STT));
        }
        [HttpPost]
        public ActionResult GetCTKM(string macn)
        {
            if (macn.Contains("null"))
            {
                macn = null;
            }
            return Json(DATACTHT(macn.Split(',').ToList()));
        }
        [HttpPost]
        public ActionResult DelHoaDon(string Id)
        {
            var Infocrm = GetCRM();
            string x = "";
            var MACH = Infocrm.macn;
            try
            {
                var export = (DateTime)DATA_DEL(MACH, Id);
                x = export.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                return Json(1);
            }
            return Json(x);
        }
        [HttpPost]
        public ActionResult Themthecao(string makh, string tenkh, string sothe, int qui, int nam, string matdv)
        {
            var Infocrm = GetCRM();
            var MACH = Infocrm.macn;
            var data = new JsonMessage();
            var listsothe = sothe.Split(',');
            var listthanhcong = new List<int>();
            var listthatbai = new List<int>();
            foreach (var i in listsothe)
            {
                var so = Int32.Parse(i);
                var tv = db2.DTA_SOTHE.SingleOrDefault(n => n.qui == qui && n.nam == nam && n.sothe == so);
                if (tv == null)
                {
                    try
                    {
                        listthanhcong.Add(so);
                        db2.DTA_SOTHE.Add(new DTA_SOTHE() { macn = MACH, makh = makh, tenkh = tenkh, matdv = matdv, nguoitao = User.Identity.Name, qui = qui, nam = nam, sothe = so, ngaytao = DateTime.Now });

                    }
                    catch (Exception)
                    {
                        listthatbai.Add(so);

                    }
                }
                else
                {
                    listthatbai.Add(so);

                }
            }
            db2.SaveChanges();
            if (listthanhcong.Count() == 0)
            {
                data.status = "error";
                data.message = "Số thẻ " + string.Join(",", listthatbai) + " đã được người khác thêm. Vui lòng chọn số thẻ khác hoặc báo cho phòng Marketing";
            }
            else
            {
                data.status = "success";
                data.message += "Nhập thành công thẻ " + string.Join(",", listthanhcong) + " cho khách hàng " + tenkh;
                if (listthatbai.Count() != 0)
                {
                    data.message += " .Số thẻ " + string.Join(",", listthatbai) + " đã được người khác thêm. Vui lòng chọn số thẻ khác hoặc báo cho phòng Marketing";

                }
            }
            return Json(data);
        }
        [HttpPost]
        public ActionResult Xoathecao(int sothe, int qui, int nam)
        {
            var tv = db2.DTA_SOTHE.SingleOrDefault(n => n.sothe == sothe && n.qui == qui && n.nam == nam);
            var data = new JsonMessage();
            if (tv != null)
            {
                if (tv.nguoitao.ToUpper() == User.Identity.Name.ToUpper())
                {
                    db2.DTA_SOTHE.Remove(tv);
                    db2.SaveChanges();
                    data.status = "success";
                    data.message = "Xóa thành công thẻ " + sothe + " cho khách hàng " + tv.tenkh;
                    return Json(data);
                }
                else
                {
                    data.status = "error";
                    data.message = "Bạn không phải là người tạo bạn không thể xóa số thẻ này";
                    return Json(data);
                }
            }
            else
            {
                data.status = "error";
                data.message = "Số thẻ này hiện không tồn tại";
                return Json(data);
            }
        }

        public DateTime DATA_DEL(string x, string MADH)
        {
            DateTime ngaydat = new DateTime();
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                var data = queryCN.SingleOrDefault(n => n.macn == x).data.DTA_DONDATHANG.Where(n => n.MADH == MADH && n.DUYETDH == false);
                ngaydat = data.FirstOrDefault().NgayDat;
                queryCN.SingleOrDefault(n => n.macn == x).data.DTA_DONDATHANG.RemoveRange(data);
                queryCN.SingleOrDefault(n => n.macn == x).data.SaveChanges();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
            {
                var data = queryCH.SingleOrDefault(n => n.macn == x).data.DTA_DONDATHANG.Where(n => n.MADH == MADH && n.DUYETDH == false);
                ngaydat = data.FirstOrDefault().NgayDat;
                queryCH.SingleOrDefault(n => n.macn == x).data.DTA_DONDATHANG.RemoveRange(data);
                queryCH.SingleOrDefault(n => n.macn == x).data.SaveChanges();
            }

            return ngaydat;
        }

        [HttpPost]
        public ActionResult AddHoaDon(List<DONDATHANG> data1)
        {
            //try
            //{
            var Infocrm = GetCRM();
            var Info = GetInfo();
            List<DTA_DONDATHANG> data = new List<DTA_DONDATHANG>();
            var MACH = Infocrm.macn;

            if (data1.First().MADH == null)
            {
                try
                {
                    data1 = data1.Select(cl => { cl.MADH = DATA_GET(MACH).ToString("0000000"); return cl; }).ToList();
                }
                catch (Exception)
                {
                    data1 = data1.Select(cl => { cl.MADH = "0000001"; return cl; }).ToList();
                }
            }

            foreach (var i in data1)
            {
                DateTime? ngaygiao;
                if (i.NGAYGIAO != null)
                {
                    ngaygiao = DateTime.ParseExact(i.NGAYGIAO, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    ngaygiao = null;
                }
                data.Add(new DTA_DONDATHANG { DONVI = i.DONVI, DUYETDH = false, DVT = i.DVT, MACH = MACH, MACTKM = i.MACTKM, MADH = i.MADH, MAHH = i.MAHH, MAKH = i.KHACHHANG, MATDV = i.MATDV, NgayDat = (i.NGAY == null) ? DateTime.Now : DateTime.ParseExact(i.NGAY, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture), NgayGiao = ngaygiao, SOLUONG = i.SOLUONG, SOLUONG2 = i.SOLUONG2, SOLUONG3 = i.SOLUONG3, STT = i.STT, TENHH = i.TENHH, ck = i.ck, GHICHU = i.GHICHU, GIABAN_VAT = i.GIABAN_VAT, VAT = i.VAT, USERTAO = User.Identity.Name.ToUpper(), TENCTKM = i.TENCTKM, MACTHT = (i.MACTHT == "") ? null : i.MACTHT });
            }
            DATA_ADD(MACH, data);
            return Json(data.First().MADH);
            //}
            //catch (Exception)
            //{
            //    return Json(0);
            //}
        }
        [ValidateJsonAntiForgeryToken]
        [HttpPost]
        public ActionResult Taolaidonhang(string madh, string ngaygiao, string ghichu)
        {
            var Infocrm = GetCRM();
            var madhmoi = DATA_GET(Infocrm.macn);
            DateTime? dategiao;
            if (ngaygiao != "")
            {
                dategiao = DateTime.ParseExact(ngaygiao, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                dategiao = null;
            }
            var data = new List<DTA_DONDATHANG>();
            foreach (var i in DATAGETDONHANG(Infocrm.macn, madh).ToList())
            {
                data.Add(new DTA_DONDATHANG { ck = i.ck, DONVI = i.DONVI, DUYETDH = false, DVT = i.DVT, GHICHU = ghichu, GIABAN_VAT = i.GIABAN_VAT, MACH = i.MACH, MACTKM = i.MACTKM, MADH = madhmoi.ToString("0000000"), MAHH = i.MAHH, MAKH = i.MAKH, MATDV = i.MATDV, NgayDat = DateTime.Now, NgayGiao = dategiao, SOLUONG = i.SOLUONG, STT = i.STT, TENCTKM = i.TENCTKM, TENHH = i.TENHH, USERTAO = i.USERTAO, VAT = i.VAT, MACTHT = i.MACTHT, SOLUONG2 = i.SOLUONG2, SOLUONG3 = i.SOLUONG3 });
            }
            if (data.First().USERTAO.ToUpper() == Infocrm.taikhoan.ToUpper())
            {
                DATA_ADD(Infocrm.macn, data);
                return Json(madhmoi.ToString("0000000"));
            }
            else
            {
                return Json(0);
            }
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
    }
}