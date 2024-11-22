using ApplicationChart.Models;
using DevExpress.XtraPrinting;
using DocumentFormat.OpenXml.Spreadsheet;
using it_report.Models;
using Microsoft.Security.Application;
using MoreLinq;
using NPOI.SS.Formula.Functions;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using static DevExpress.XtraPrinting.Export.Pdf.PdfImageCache;
using System.Data.SqlClient;

namespace ApplicationChart.Controllers
{
    [Authorize(Roles = "KEHOACH")]
    public class BaocaoController : MyBaseController
    {
        Entities TayNinh = new Entities("KT_TNEntities");
        CHQ10Entities1 CHQ10 = new CHQ10Entities1("CHQ10Entities");
        Entities TT423 = new Entities("TT423Entities");
        Entities BinhDinh = new Entities("KT_BDEntities");
        Entities CanTho = new Entities("KT_CTEntities");
        Entities DongNai = new Entities("KT_DNEntities");
        Entities DaNang = new Entities("KT_DNAEntities");
        Entities HoChiMinh = new Entities("KT_HCMEntities");
        Entities NgheAn = new Entities("KT_NAEntities");
        Entities QuangNgai = new Entities("KT_QNEntities");
        Entities PhuYen = new Entities("KTEntities");
        Entities AnGiang = new Entities("KT_AGEntities");
        Entities BinhDuong = new Entities("KT_BDGEntities");
        Entities CaMau = new Entities("KT_CMEntities");
        Entities GiaLai = new Entities("KT_GLEntities");
        Entities Hue = new Entities("KT_HUEEntities");
        Entities LamDong = new Entities("KT_LDEntities");
        Entities NhaTrang = new Entities("KT_NTEntities");
        Entities QuangTri = new Entities("KT_QTEntities");
        Entities TienGiang = new Entities("KT_TGEntities");
        Entities VinhLong = new Entities("KT_VLEntities");
        Entities NgheAn2 = new Entities("KT_NA_2Entities");
        Entities ThanhHoa = new Entities("KT_THOEntities");
        // MIỀN BẮC
        Entities HaNoi = new Entities("KT_HNEntities");
        Entities ThaiBinh = new Entities("KT_TBEntities");
        Entities ThaiNguyen = new Entities("KT_TNGEntities");

        Entities PhuTho = new Entities("KT_PTEntities");
        Entities HaiPhong = new Entities("KT_HPEntities");
        //MAY DESKTOP
        CHQ10Entities1 PTTT = new CHQ10Entities1("PTTTEntities");
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();

        List<EntitiesCN> queryCN = new List<EntitiesCN> {
            //new EntitiesCN {data = new Entities("KT_QTEntities") , macn = "QT"},
                 new EntitiesCN {data = new Entities("KT_PYPHARMEntities") , macn = "DPY"},
                 new EntitiesCN {data = new Entities("KT_PYPHARM_HCMEntities") , macn = "DPY_HCM"},
        };
        List<EntitiesCN> query = new List<EntitiesCN> {
            new EntitiesCN {data = new Entities("KT_PYPHARMEntities") , macn = "DPY"},
                 new EntitiesCN {data = new Entities("KT_PYPHARM_HCMEntities") , macn = "DPY_HCM"},
                 //new EntitiesCN {data = new Entities("KT_QTEntities") , macn = "QT"},
        };
        List<EntitiesKT> queryKT = new List<EntitiesKT> {
            //new EntitiesKT {data = new KTContext("KT_QTEntities1") , macn = "QT"},
                 new EntitiesKT {data = new KTContext("KT_PYPHARMEntities1") , macn = "DPY"},
                 new EntitiesKT {data = new KTContext("KT_PYPHARM_HCMEntities1") , macn = "DPY_HCM"},
        };
        public TBL_PHANQUYENCRM GetCRM()
        {
            TBL_PHANQUYENCRM abc = new TBL_PHANQUYENCRM();
            abc = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan.ToUpper() == User.Identity.Name.ToUpper().ToString());
            return abc;
        }
        // GET: Baocao
        [ActionName("danh-sach-khach-hang")]
        public ActionResult Danhsachkhachhang()
        {
            var Info = GetInfo();
            var Infocrm = GetCRM();
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            ViewBag.dathang = Info.dathang;
            return View("Danhsachkhachhang");
            //}
        }
        [ActionName("huong-dan-crm")]
        public ActionResult Huongdancrm()
        {
            var Info = GetInfo();
            var Infocrm = GetCRM();
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            ViewBag.dathang = Info.dathang;
            return View("Huongdancrm");
        }


        [HttpPost]
        public JsonResult Sosanhtoado(Sosanhtoado o)
        {
            try
            {
                DateTime date = DateTime.ParseExact(o.ngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var tv = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name);
                var kh = db2.DTA_TOADOKHACHHANG.SingleOrDefault(n => n.makh == o.makh && n.macn == tv.macn);
                var vitri = new Coordinates(kh.latitude, kh.longitude);
                var distance = vitri.DistanceTo(new Coordinates(o.latitude, o.longitude), UnitOfLength.Kilometers) * 1000;
                if (distance <= 100)
                {
                    return Json(1);
                }
                else
                {
                    return Json(0);
                }
            }
            catch (Exception)
            {
                return Json(2);
            }
        }
        [ActionName("ke-hoach-cong-tac")]
        public ActionResult Lich()
        {
            var Info = GetInfo();
            var Infocrm = GetCRM();
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            ViewBag.dathang = Info.dathang;
            var MACH = Infocrm.macn;
            var Data = DATA(null);
            ViewBag.KH = Data;
            var tuantruoc = DateTime.Now.AddDays(-14);

            ViewBag.data = db2.DTA_CONGTACTRINHDUOC.Where(n => n.macn == MACH && n.matdv == Infocrm.taikhoan && n.ngay >= tuantruoc).ToList()
                .GroupBy(n => n.ngay).Select(cl => new { ngay = cl.Key.ToString("dd/MM/yyyy"), soluong = cl.Count(), khoa = !(cl.Any(n => n.khoa == false)) }).ToList();
            return View("Lich");
        }
        public List<ListKhachHang> DATA(string MATDV)
        {
            var Info = GetInfo();

            string strcn = "SELECT makh AS MAKH, donvi AS DONVI,phanloai,matinh,matdv,quanhuyen,macn,diachi,dt,tinhtrang FROM TBL_DANHMUCKHACHHANG WHERE (tinhtrang != N'Ngừng giao dịch' or tinhtrang is null)";
            if (Info.phanloai != "ALL")
            {
                var listpl = Info.phanloai.Split(',').ToList();
                strcn = strcn + string.Format(" AND phanloai IN ({0})", string.Join(",", listpl.Select(p => "'" + p + "'")));
            }
            if (Info.matinh != "ALL")
            {
                var listmt = Info.matinh.Split(',').ToList();
                strcn = strcn + string.Format(" AND matinh IN ({0})", string.Join(",", listmt.Select(p => "'" + p + "'")));
            }
            if (Info.matdv != "ALL")
            {
                var listtdv = Info.matdv.Split(',').ToList();
                strcn = strcn + string.Format(" AND matdv IN ({0})", string.Join(",", listtdv.Select(p => "'" + p + "'")));
            }
            if (Info.maquan != "ALL")
            {
                var listquan = Info.maquan.Split(',').ToList();
                strcn = strcn + string.Format(" AND quanhuyen IN ({0})", string.Join(",", listquan.Select(p => "'" + p + "'")));
            }
            //if (Info.macn != "ALL")
            //{
            //    var listcn = Info.macn.Split(',').ToList();
            //    strcn = strcn + string.Format(" AND macn IN ({0})", string.Join(",", listcn.Select(p => "'" + p + "'")));
            //}

            if (MATDV != null && MATDV != "")
            {
                var listtdv = MATDV.Split(',').ToList();
                strcn = strcn + string.Format(" AND matdv IN ({0})", string.Join(",", listtdv.Select(p => "'" + p + "'")));
            }
            List<ListKhachHang> DATAX = new List<ListKhachHang>();

            foreach (var item in query)
            {
                var data3 = item.data.Database.SqlQuery<ListKhachHang>(strcn);
                DATAX.AddRange(data3.ToList());
            }


            return DATAX;
        }
        public List<Sodonhang> DATASODH(string x, string taikhoan, string MAKH, DateTime ngay)
        {
            var DATAX = new List<Sodonhang>();

            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                var enti = queryCN.SingleOrDefault(n => n.macn == x).data;
                DATAX = enti.DTA_DONDATHANG.Where(n => n.MAKH == MAKH && n.USERTAO == taikhoan && EntityFunctions.TruncateTime(n.NgayDat) == ngay).GroupBy(n => n.MADH).Select(cl => new Sodonhang { SODH = cl.Key, SOHD = cl.FirstOrDefault().SOHD, DUYET = cl.FirstOrDefault().DUYETDH }).ToList();

            }

            return DATAX;
        }
        public List<DTA_DONDATHANG> DATADH(string x, string MADH)
        {
            var DATAX = new List<DTA_DONDATHANG>();
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                var enti = queryCN.SingleOrDefault(n => n.macn == x).data;
                DATAX = enti.DTA_DONDATHANG.Where(n => n.MADH == MADH).ToList();
            }

            return DATAX;
        }
        [HttpPost]
        public ActionResult PartialQLKH(List<string> matdv, string macn)
        {

            return PartialView(DATA(String.Join(",", matdv.ToArray())));

        }
        [HttpPost]
        public ActionResult GetKhuVuc()
        {
            var Infocrm = GetCRM();
            var taikhoan = Infocrm.taikhoan;
            var macn = Infocrm.macn;
            if (queryKT.SingleOrDefault(n => n.macn == macn) != null)
            {
                KTContext enti = queryKT.SingleOrDefault(n => n.macn == macn).data;
                var data = enti.TBL_DANHMUCDONVI.Where(d => d.MaTinh != null).OrderBy(q => q.MaTinh).ToList();

                return Json(data);
            }
            return Json(new { });
        }
        [HttpPost]
        public ActionResult savekh(string tenkh, string diachi, string nguoilienhe, string dienthoai, string matinh, string xeploai, string maquan, string masothue, string macn)
        {
            var Infocrm = GetCRM();
            var taikhoan = Infocrm.taikhoan;
            //var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()

            KTContext enti = queryKT.SingleOrDefault(d => d.macn == "DPY").data;
            //var data = enti.DTA_DONDATHANG.Where(n => n.DUYETDH == true).ToList();

            var last_record = enti.TBL_DANHMUCKHACHHANG.Where(d => d.tinhtrang == "Khách hàng mới" && d.matdv == taikhoan).OrderByDescending(q => q.stt).FirstOrDefault();
            var stt = last_record != null ? last_record.stt + 1 : 1;
            //var stt = 1;
            var KHmoi = new TBL_DANHMUCKHACHHANG()
            {
                makh = $"NEW.{taikhoan}_{stt}",
                macn = macn,
                donvi = tenkh,
                tennguoigd = nguoilienhe,
                diachi = diachi,
                dt = dienthoai,
                matdv = taikhoan,
                matinh = matinh,
                quanhuyen = maquan,
                masothue = masothue,
                phanloai = "OTC",
                tk = "131",
                stt = stt,
                tinhtrang = "Khách hàng mới",
                xeploai = xeploai,
                ngaycapnhat = DateTime.Now
            };
            enti.TBL_DANHMUCKHACHHANG.Add(KHmoi);
            enti.SaveChanges();

            return Json(new { success = true });
        }
        [HttpPost]
        public ActionResult changeMAKH(string fromKH, string toKH)
        {


            try
            {
                foreach (var item in query)
                {
                    var enti = item.data;
                    var a = enti.Database.SqlQuery<T>("UPDATE TBL_DANHMUCKHACHHANG SET makh = '" + toKH + "', tinhtrang = N'Đang giao dịch' WHERE makh = '" + fromKH + "'").ToList();

                    var c = enti.Database.SqlQuery<T>("UPDATE DTA_DONDATHANG SET makh = '" + toKH + "' WHERE makh = '" + fromKH + "'").ToList();

                }
                var b = db2.Database.SqlQuery<T>("UPDATE DTA_CONGTACTRINHDUOC SET makh = '" + toKH + "' WHERE makh = '" + fromKH + "'").ToList();


            }
            catch (Exception ex)
            {

                return Json(new { success = false });
            }

            return Json(new { success = true });
        }
        [HttpPost]
        public ActionResult xoaMAKH(string makh)
        {


            try
            {
                foreach (var item in queryKT)
                {
                    var enti = item.data;
                    var kh = enti.TBL_DANHMUCKHACHHANG.Where(d => d.makh == makh).FirstOrDefault();
                    if (kh != null)
                    {
                        enti.TBL_DANHMUCKHACHHANG.Remove(kh);
                        enti.SaveChanges();
                    }
                }


            }
            catch (Exception ex)
            {

                return Json(new { success = false });
            }

            return Json(new { success = true });
        }

        [ActionName("bao-cao-cong-tac-trinh-duoc")]
        public ActionResult Congtactrinhduoc()
        {
            var Info = GetInfo();
            var Infocrm = GetCRM();
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            ViewBag.quyencrm = Infocrm.quyen;
            ViewBag.dathang = Info.dathang;
            return View("Congtactrinhduoc");
        }
        [ActionName("du-lieu-bao-cao-cong-tac")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Baocaoview(List<string> matdv, int loaibaocao, int baocao, string tungay, string denngay, string tentdv, string thang)
        {
            var crm = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == matdv.FirstOrDefault());
            if (baocao == 1)
            {
                if (loaibaocao == 1)
                {
                    DateTime tungay1 = DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime denngay1 = DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    List<Tuple<int, string, string>> allDates = new List<Tuple<int, string, string>>();
                    for (DateTime date = tungay1; date <= denngay1; date = date.AddDays(1))
                        allDates.Add(new Tuple<int, string, string>(date.Day, date.DayOfWeek.ToString(), date.ToString("dd/MM/yyyy")));
                    ViewBag.alldate = allDates;
                    var data = DATAGETKEHOACHALL(matdv.FirstOrDefault(), tungay1, denngay1).Select(cl => new { cl.checkin, cl.ghichu, cl.ketqua, cl.khoa, cl.makh, cl.ngay.Day }).ToList();
                    List<BCKEHOACHCHITIET> data2 = new List<BCKEHOACHCHITIET>();
                    foreach (var i in data)
                    {
                        if (i.checkin == true && i.ketqua == 1)
                        {
                            data2.Add(new BCKEHOACHCHITIET { makh = i.makh, loai = 1, ngay = i.Day });
                        }
                        else if (i.checkin == true && i.ketqua == 2)
                        {
                            data2.Add(new BCKEHOACHCHITIET { makh = i.makh, loai = 2, ngay = i.Day });
                        }
                        else if (i.checkin == false && i.khoa == true)
                        {
                            data2.Add(new BCKEHOACHCHITIET { makh = i.makh, loai = 3, ngay = i.Day, ghichu = i.ghichu });
                        }
                        else if (i.checkin == false && i.khoa == false)
                        {
                            data2.Add(new BCKEHOACHCHITIET { makh = i.makh, loai = 4, ngay = i.Day });
                        }
                    }
                    if (data2 != null)
                    {
                        var z = DATAGETKEHOACHHETHONG(matdv.FirstOrDefault(), tungay1, denngay1.AddDays(1));
                        foreach (var i in z)
                        {
                            if (data2.SingleOrDefault(n => n.loai == 2 && n.makh == i.makh && n.ngay == i.ngay) != null)
                            {
                                data2.SingleOrDefault(n => n.loai == 2 && n.makh == i.makh && n.ngay == i.ngay).loai = 7;
                            }
                            else
                            {
                                data2.Add(i);
                            }
                        }
                        ViewBag.data = data2;
                    }
                    else
                    {
                        ViewBag.data = DATAGETKEHOACHHETHONG(matdv.FirstOrDefault(), tungay1, denngay1.AddDays(1));
                    }
                    var data1 = data.Where(n => n.checkin == true).GroupBy(n => n.Day).Select(cl => new Tuple<int, string>(cl.Count(), cl.Key.ToString())).ToList();
                    ViewBag.result = data1;
                    try
                    {
                        ViewBag.doanhso = DATABAOCAODOANHSO(tungay1, denngay1, matdv.FirstOrDefault());
                    }
                    catch (Exception)
                    {
                        ViewBag.doanhso = null;
                    }
                    var final = new LISTBAOCAOCHITIETNGAYCRM()
                    {
                        tungay = tungay1,
                        denngay = denngay1,
                        hovaten = crm.TBL_DANHMUCNGUOIDUNG.hoten,
                        macn = crm.macn,
                        taikhoan = crm.TBL_DANHMUCNGUOIDUNG.nguoidung,
                        data = DATA(crm.matdv).OrderBy(n => n.DONVI).ToList(),
                        tencn = ""
                    };
                    return View("/Views/Baocao/Baocaochitietngay.cshtml", final);
                }
                else if (loaibaocao == 2)
                {
                    DateTime tungay1 = DateTime.ParseExact(thang, "MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime denngay1 = tungay1.AddMonths(1).AddDays(-1);
                    List<Tuple<int, string, string>> allDates = new List<Tuple<int, string, string>>();
                    for (DateTime date = tungay1; date <= denngay1; date = date.AddDays(1))
                        allDates.Add(new Tuple<int, string, string>(date.Day, date.DayOfWeek.ToString(), date.ToString("dd/MM/yyyy")));
                    ViewBag.alldate = allDates;
                    var data = DATAGETKEHOACHALL(matdv.FirstOrDefault(), tungay1, denngay1).Select(cl => new { cl.checkin, cl.ghichu, cl.ketqua, cl.khoa, cl.makh, cl.ngay.Day }).ToList();
                    List<BCKEHOACHCHITIET> data2 = new List<BCKEHOACHCHITIET>();
                    foreach (var i in data)
                    {
                        if (i.checkin == true && i.ketqua == 1)
                        {
                            data2.Add(new BCKEHOACHCHITIET { makh = i.makh, loai = 1, ngay = i.Day });
                        }
                        else if (i.checkin == true && i.ketqua == 2)
                        {
                            data2.Add(new BCKEHOACHCHITIET { makh = i.makh, loai = 2, ngay = i.Day });
                        }
                        else if (i.checkin == false && i.khoa == true)
                        {
                            data2.Add(new BCKEHOACHCHITIET { makh = i.makh, loai = 3, ngay = i.Day, ghichu = i.ghichu });
                        }
                        else if (i.checkin == false && i.khoa == false)
                        {
                            data2.Add(new BCKEHOACHCHITIET { makh = i.makh, loai = 4, ngay = i.Day });
                        }
                    }
                    if (data2 != null)
                    {
                        var z = DATAGETKEHOACHHETHONG(matdv.FirstOrDefault(), tungay1, denngay1.AddDays(1));
                        foreach (var i in z)
                        {
                            if (data2.SingleOrDefault(n => n.loai == 2 && n.makh == i.makh && n.ngay == i.ngay) != null)
                            {
                                data2.SingleOrDefault(n => n.loai == 2 && n.makh == i.makh && n.ngay == i.ngay).loai = 7;
                            }
                            else
                            {
                                data2.Add(i);
                            }
                        }
                        ViewBag.data = data2;
                    }
                    else
                    {
                        ViewBag.data = DATAGETKEHOACHHETHONG(matdv.FirstOrDefault(), tungay1, denngay1.AddDays(1));
                    }
                    var data1 = data.Where(n => n.checkin == true).GroupBy(n => n.Day).Select(cl => new Tuple<int, string>(cl.Count(), cl.Key.ToString())).ToList();
                    var data3 = data.Where(n => n.checkin == true);
                    try
                    {
                        ViewBag.doanhso = DATABAOCAO0(tungay1, denngay1, db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == matdv.FirstOrDefault())).First().TONGTIEN_CT_HOADON;
                    }
                    catch (Exception)
                    {
                        ViewBag.doanhso = null;
                    }
                    var final = new LISTBAOCAOCHITIETNGAYCRM() { tungay = tungay1, denngay = denngay1, hovaten = crm.TBL_DANHMUCNGUOIDUNG.hoten, macn = crm.macn, taikhoan = crm.TBL_DANHMUCNGUOIDUNG.nguoidung, data = DATA(crm.matdv).OrderBy(n => n.DONVI).ToList(), tencn = "" };
                    ViewBag.result = data1;
                    ViewBag.tuan11 = data3.Where(n => n.Day <= 7).Count();
                    ViewBag.tuan21 = data3.Where(n => n.Day > 7 && n.Day <= 14).Count();
                    ViewBag.tuan31 = data3.Where(n => n.Day > 14 && n.Day <= 21).Count();
                    ViewBag.tuan41 = data3.Where(n => n.Day > 21 && n.Day <= 31).Count();
                    ViewBag.tuan12 = data3.Where(n => n.Day <= 7 && n.ketqua == 2).Count();
                    ViewBag.tuan22 = data3.Where(n => n.Day > 7 && n.Day <= 14 && n.ketqua == 2).Count();
                    ViewBag.tuan32 = data3.Where(n => n.Day > 14 && n.Day <= 21 && n.ketqua == 2).Count();
                    ViewBag.tuan42 = data3.Where(n => n.Day > 21 && n.Day <= 31 && n.ketqua == 2).Count();
                    return View("/Views/Baocao/Baocaochitietthang.cshtml", final);
                }
            }
            else if (baocao == 2)
            {
                var infocrm = GetCRM();
                var Info = GetInfo();
                DateTime tungay1 = (loaibaocao == 1) ? DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact(thang, "MM/yyyy", CultureInfo.InvariantCulture);
                DateTime denngay1 = (loaibaocao == 1) ? DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture) : tungay1.AddMonths(1).AddDays(-1);
                List<Tuple<int, string, string>> allDates = new List<Tuple<int, string, string>>();
                for (DateTime date = tungay1; date <= denngay1; date = date.AddDays(1))
                    allDates.Add(new Tuple<int, string, string>(date.Day, date.DayOfWeek.ToString(), date.ToString("dd/MM/yyyy")));
                var data = new LISTBAOCAOTONGHOPCRM { tungay = tungay1, denngay = denngay1, songaylamviec = allDates.Where(n => n.Item2 != "Sunday").Count() };
                var alltdv = db2.TBL_PHANQUYENCRM.Where(d => d.quyen == "TDV");

                if (Info.matdv != "ALL")
                {
                    List<string> listtdv = Info.matdv.Split(',').ToList();
                    alltdv = alltdv.Where(n => listtdv.Contains(n.taikhoan));
                }
                if (Info.macn != "ALL")
                {
                    List<string> listcn = Info.macn.Split(',').ToList();
                    alltdv = alltdv.Where(n => listcn.Contains(n.macn));
                }
                var taikhoan = alltdv.ToList();
                var list = new List<BAOCAOTONGHOPCRM>();
                foreach (var i in taikhoan)
                {
                    var ngaybc = db2.DTA_CONGTACTRINHDUOC.Where(n => n.matdv == i.taikhoan && n.ngay >= tungay1 && n.ngay <= denngay1 && n.khoa == true);
                    list.Add(new BAOCAOTONGHOPCRM
                    {
                        doanhso = DATABAOCAODOANHSO(tungay1, denngay1, i.taikhoan),
                        taikhoan = i.taikhoan,
                        hovaten = i.TBL_DANHMUCNGUOIDUNG.hoten,
                        chinhanh = i.macn,
                        sodonhang = db2.DTA_CONGTACTRINHDUOC.Where(n => n.matdv == i.taikhoan && n.ngay >= tungay1 && n.ngay <= denngay1 && n.ketqua == 2 && n.checkin == true).Count(),
                        solantham = db2.DTA_CONGTACTRINHDUOC.Where(n => n.matdv == i.taikhoan && n.ngay >= tungay1 && n.ngay <= denngay1 && n.checkin == true).Count(),
                        songaybaocao = (ngaybc.Count() == 0) ? 0 : ngaybc.GroupBy(n => n.ngay).Count()
                    });
                }
                data.data = list;
                return View("/Views/Baocao/Baocaotonghop.cshtml", data);
            }
            else if (baocao == 3)
            {
                var infocrm = GetCRM();
                var Info = GetInfo();
                DateTime tungay1 = (loaibaocao == 1) ? DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact(thang, "MM/yyyy", CultureInfo.InvariantCulture);
                DateTime denngay1 = (loaibaocao == 1) ? DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture) : tungay1.AddMonths(1).AddDays(-1);
                List<Tuple<int, string, string>> allDates = new List<Tuple<int, string, string>>();
                for (DateTime date = tungay1; date <= denngay1; date = date.AddDays(1))
                    allDates.Add(new Tuple<int, string, string>(date.Day, date.DayOfWeek.ToString(), date.ToString("dd/MM/yyyy")));
                ViewBag.alldate = allDates;
                var data = new LISTBAOCAOTONGHOPTUNGNGAYCRM { tungay = tungay1, denngay = denngay1, songaylamviec = allDates.Where(n => n.Item2 != "Sunday").Count() };

                //var enti = query.SingleOrDefault(d => d.macn == "DPY").data;
                var alltdv = db2.TBL_PHANQUYENCRM.Where(d => d.quyen == "TDV");

                if (Info.matdv != "ALL")
                {
                    List<string> listtdv = Info.matdv.Split(',').ToList();
                    alltdv = alltdv.Where(n => listtdv.Contains(n.taikhoan));
                }
                if (Info.macn != "ALL")
                {
                    List<string> listcn = Info.macn.Split(',').ToList();
                    alltdv = alltdv.Where(n => listcn.Contains(n.macn));
                }
                var taikhoan = alltdv.ToList();
                var chitiet = taikhoan.Select(cl => new BAOCAOTONGHOPTUNGNGAYCRM { taikhoan = cl.taikhoan, hovaten = cl.TBL_DANHMUCNGUOIDUNG.hoten, chinhanh = cl.macn }).ToList();
                foreach (var i in chitiet)
                {
                    i.chitietngay = db2.DTA_CONGTACTRINHDUOC.Where(n => n.ngay >= tungay1 && n.ngay <= denngay1 && n.matdv == i.taikhoan)
                        .GroupBy(n => n.ngay)
                        .Select(cl => new BAOCAOTUNGNGAYTDV
                        {
                            ngay = cl.Key.Day,
                            ngaythang = cl.Key,
                            kehoach = cl.Count(),
                            dabaocao = cl.Where(c => c.khoa == true).Count(),
                            donhang = cl.Where(c => c.ketqua == 2 && c.checkin == true).Count(),
                            ghetham = cl.Where(c => c.checkin == true).Count(),
                            huy = cl.Where(c => c.ketqua == null && c.ghichu != null && c.checkin == false).Count()
                        }).ToList();
                }
                data.data = chitiet;
                return View("/Views/Baocao/Baocaotonghoptungngay.cshtml", data);
            }
            return View();
        }
        [HttpPost]
        public ActionResult GetSoDonHang(string makh, string ngay, string matdv, string macn)
        {
            DateTime ngaydat = DateTime.ParseExact(ngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var data = DATASODH(macn, matdv, makh, ngaydat);
            return Json(data.OrderBy(n => n.SODH));
        }
        [HttpPost]
        public ActionResult GetEditDonHang(string madh, string matdv, string macn)
        {
            var Info = GetInfo();
            var data = DATADH(macn, madh);
            return Json(data.OrderBy(n => n.STT));
        }

        [HttpPost]
        public ActionResult GetKhachHang(string makh)
        {

            return Json(DATAGETKHACHHANGVIEW(makh));
        }
        [HttpPost]
        public ActionResult GetKehoach(string ngay)
        {
            var Infocrm = GetCRM();
            var MATDV = Infocrm.taikhoan;
            var MACH = Infocrm.macn;
            return Json(DATAGETKEHOACH(MACH, MATDV, ngay));
        }
        public List<ListTrinhDuocVien> DULIEUTRINHDUOCVIEN(Entities data)
        {
            var All = data.Database.SqlQuery<ListTrinhDuocVien>("SELECT MaTDV AS MATDV, TenTDV AS TENTDV FROM TBL_DANHMUCTDV WHERE MaTDV IS NOT NULL").ToList();
            return All;
        }
        public List<ListTrinhDuocVien> DULIEUCUAHANGTRINHDUOCVIEN(CHQ10Entities1 data)
        {
            var All = data.Database.SqlQuery<ListTrinhDuocVien>("SELECT MaTDV AS MATDV, TenTDV AS TENTDV FROM DS_TDV_PTTT WHERE MaTDV IS NOT NULL").ToList();
            return All;
        }
        public List<ListTrinhDuocVien> DULIEUMIENBACTRINHDUOCVIEN(CHQ10Entities1 data)
        {
            var All = data.Database.SqlQuery<ListTrinhDuocVien>("SELECT MaTDV AS MATDV, TenTDV AS TENTDV FROM DS_TDV_PTTT").ToList();
            return All;
        }
        [HttpPost]
        public ActionResult GetTrinhDuocVien(string macn)
        {
            var Infocrm = GetCRM();
            List<ListTrinhDuocVien> data = new List<ListTrinhDuocVien>();

            if (Infocrm.matdv != null && Infocrm.matdv != "")
            {
                var TDV = Infocrm.matdv.Split(',').ToList();
                data = db2.TBL_PHANQUYENCRM.Where(n => n.macn == macn && TDV.Contains(n.matdv)).Select(cl => new ListTrinhDuocVien { MATDV = cl.taikhoan, TENTDV = cl.TBL_DANHMUCNGUOIDUNG.hoten }).ToList();
            }
            else
            {
                data = db2.TBL_PHANQUYENCRM.Where(n => n.macn == macn && n.quyen == "TDV").Select(cl => new ListTrinhDuocVien { MATDV = cl.taikhoan, TENTDV = cl.TBL_DANHMUCNGUOIDUNG.hoten }).ToList();
            }

            return Json(data);
        }
        [ValidateJsonAntiForgeryToken]
        [HttpPost]
        public ActionResult Addkehoach(List<DTA_CONGTACTRINHDUOC> data1, DateTime ngay)
        {
            var Info = GetInfo();
            var Infocrm = GetCRM();
            var MATDV = Infocrm.taikhoan;
            var MACH = Infocrm.macn;
            if (data1 != null)
            {


                foreach (var i in data1)
                {
                    i.macn = MACH;
                    i.matdv = MATDV;
                    if (i.makh == null)
                    {
                        i.makh = "";
                    }
                }
            }
            DATADELKEHOACH(MACH, MATDV, ngay);
            if (data1 != null)
            {
                db2.DTA_CONGTACTRINHDUOC.AddRange(data1);
                db2.SaveChanges();
            }

            return Json(ngay.ToString("dd/MM/yyyy"));
        }
        [HttpPost]
        public ActionResult EditKhachHang(string macn, string makh, string dt, string xeploai, string matinh, string diachi, string lienhe, string quanhuyen, string masothue)
        {
            var Infocrm = GetCRM();
            UPDATETHONGTINKHACHHANG(macn, makh, dt, xeploai, matinh, diachi, lienhe, quanhuyen, masothue);
            return Json(1);
        }
        public ActionResult ExcelKhachhang(string matdv)
        {

            string path = Server.MapPath("~/Content/mauKHmoi.xlsx");
            using (var memoryStream = new MemoryStream())
            {
                using (var package = new ExcelPackage(new FileInfo(path)))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorkbook workbook = package.Workbook;
                    ExcelWorksheet worksheet = workbook.Worksheets[0];

                    var tdv = db2.TBL_DANHMUCNGUOIDUNG.FirstOrDefault(d => d.nguoidung == matdv);
                    if (tdv != null)
                    {
                        var matinh = tdv.matinh;
                        var hoten = tdv.hoten;

                        worksheet.Cells["C1"].Value = matdv + " - " + hoten;

                        var enti = queryKT.SingleOrDefault(d => d.macn == "DPY").data;
                        var enti1 = queryKT.SingleOrDefault(d => d.macn == "DPY_HCM").data;
                        var tinh = enti.TBL_DANHMUCDONVI.Where(r => r.MaTinh == matinh).FirstOrDefault();
                        if (tinh != null)
                        {
                            worksheet.Cells["C2"].Value = tinh.TenTinh;
                        }
                        else
                        {
                            worksheet.Cells["C2"].Value = matinh;
                        }
                        var danhsach = enti.TBL_DANHMUCKHACHHANG
                            .Where(d => d.matdv == matdv && d.tinhtrang != "Ngừng giao dịch")
                            .ToList();
                        danhsach.AddRange(enti1.TBL_DANHMUCKHACHHANG
                            .Where(d => d.matdv == matdv && d.tinhtrang != "Ngừng giao dịch")
                            .ToList());

                        int start_r = 4;
                        foreach (var d in danhsach)
                        {
                            worksheet.Cells["A" + start_r].Value = d.donvi;
                            worksheet.Cells["B" + start_r].Value = d.diachi;
                            var quan = enti.TBL_DANHMUCQUAN.Where(r => r.maquan == d.quanhuyen).FirstOrDefault();
                            if (quan != null)
                            {
                                worksheet.Cells["C" + start_r].Value = quan.tenquan;
                            }
                            else
                            {
                                worksheet.Cells["C" + start_r].Value = d.quanhuyen;
                            }
                            var tinh1 = enti.TBL_DANHMUCDONVI.Where(r => r.MaTinh == d.matinh).FirstOrDefault();
                            if (tinh1 != null)
                            {
                                worksheet.Cells["D" + start_r].Value = tinh1.TenTinh;
                            }
                            else
                            {
                                worksheet.Cells["D" + start_r].Value = d.matinh;
                            }
                            worksheet.Cells["E" + start_r].Value = d.tennguoigd;
                            worksheet.Cells["F" + start_r].Value = d.dt;
                            worksheet.Cells["G" + start_r].Value = d.xeploai;
                            worksheet.Cells["H" + start_r].Value = d.ngaycapnhat != null ? d.ngaycapnhat.Value.ToString("dd/MM/yyyy") : "";
                            worksheet.Cells["I" + start_r].Value = d.makh;
                            start_r++;
                        }

                    }
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    package.SaveAs(memoryStream);
                }
                memoryStream.Seek(0, SeekOrigin.Begin);
                memoryStream.Position = 0;
                return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");


            }

        }
        public ActionResult ExcelKhachhangMoi(string matdv)
        {

            string path = Server.MapPath("~/Content/mauKHmoi.xlsx");
            using (var memoryStream = new MemoryStream())
            {
                using (var package = new ExcelPackage(new FileInfo(path)))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorkbook workbook = package.Workbook;
                    ExcelWorksheet worksheet = workbook.Worksheets[0];

                    var tdv = db2.TBL_DANHMUCNGUOIDUNG.FirstOrDefault(d => d.nguoidung == matdv);
                    if (tdv != null)
                    {
                        var matinh = tdv.matinh;
                        var hoten = tdv.hoten;

                        worksheet.Cells["C1"].Value = matdv + " - " + hoten;

                        var enti = queryKT.SingleOrDefault(d => d.macn == "DPY").data;
                        var tinh = enti.TBL_DANHMUCDONVI.Where(r => r.MaTinh == matinh).FirstOrDefault();
                        if (tinh != null)
                        {
                            worksheet.Cells["C2"].Value = tinh.TenTinh;
                        }
                        else
                        {
                            worksheet.Cells["C2"].Value = matinh;
                        }

                        var danhsach = enti.TBL_DANHMUCKHACHHANG
                            .Where(d => d.matdv == matdv && d.tinhtrang == "Khách hàng mới")
                            .ToList();

                        int start_r = 4;
                        foreach (var d in danhsach)
                        {
                            worksheet.Cells["A" + start_r].Value = d.donvi;
                            worksheet.Cells["B" + start_r].Value = d.diachi;
                            var quan = enti.TBL_DANHMUCQUAN.Where(r => r.maquan == d.quanhuyen).FirstOrDefault();
                            if (quan != null)
                            {
                                worksheet.Cells["C" + start_r].Value = quan.tenquan;
                            }
                            else
                            {
                                worksheet.Cells["C" + start_r].Value = d.quanhuyen;
                            }
                            var tinh1 = enti.TBL_DANHMUCDONVI.Where(r => r.MaTinh == d.matinh).FirstOrDefault();
                            if (tinh1 != null)
                            {
                                worksheet.Cells["D" + start_r].Value = tinh1.TenTinh;
                            }
                            else
                            {
                                worksheet.Cells["D" + start_r].Value = d.matinh;
                            }
                            worksheet.Cells["E" + start_r].Value = d.tennguoigd;
                            worksheet.Cells["F" + start_r].Value = d.dt;
                            worksheet.Cells["G" + start_r].Value = d.xeploai;
                            worksheet.Cells["H" + start_r].Value = d.ngaycapnhat != null ? d.ngaycapnhat.Value.ToString("dd/MM/yyyy") : "";
                            start_r++;
                        }

                    }
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    package.SaveAs(memoryStream);
                }
                memoryStream.Seek(0, SeekOrigin.Begin);
                memoryStream.Position = 0;
                return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");


            }

        }
        public ActionResult Excelbaocaongay(string matdv, DateTime tungay, DateTime denngay)
        {

            string path = Server.MapPath("~/Content/mauBCNgay.xlsx");
            using (var memoryStream = new MemoryStream())
            {
                using (var package = new ExcelPackage(new FileInfo(path)))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorkbook workbook = package.Workbook;
                    ExcelWorksheet worksheet = workbook.Worksheets[0];


                    var db3 = queryKT.SingleOrDefault(d => d.macn == "DPY").data;
                    var tdv = db2.TBL_DANHMUCNGUOIDUNG.FirstOrDefault(d => d.nguoidung == matdv);
                    if (tdv != null)
                    {
                        var matinh = tdv.matinh;
                        var hoten = tdv.hoten;

                        worksheet.Cells["C1"].Value = matdv + " - " + hoten;

                        var enti = db3;
                        var tinh = enti.TBL_DANHMUCDONVI.Where(r => r.MaTinh == matinh).FirstOrDefault();
                        if (tinh != null)
                        {
                            worksheet.Cells["C2"].Value = tinh.TenTinh;
                        }
                        else
                        {
                            worksheet.Cells["C2"].Value = matinh;
                        }



                    }
                    var enti2 = queryKT.SingleOrDefault(d => d.macn == "DPY").data;
                    var enti1 = queryKT.SingleOrDefault(d => d.macn == "DPY_HCM").data;
                    var danhsach = enti2.TBL_DANHMUCKHACHHANG
                          .Where(d => d.tinhtrang != "Ngừng giao dịch")
                          .ToList();
                    danhsach.AddRange(enti1.TBL_DANHMUCKHACHHANG
                        .Where(d => d.tinhtrang != "Ngừng giao dịch")
                        .ToList());


                    var congtac = db2.DTA_CONGTACTRINHDUOC.Where(d => d.matdv == matdv && d.ngay >= tungay && d.ngay <= denngay).ToList();
                    var groupby_ngay = congtac.GroupBy(d => d.ngay).Select(d => new
                    {
                        ngay = d.Key,
                        data = d.ToList()
                    }).OrderBy(d => d.ngay).ToList();

                    foreach (var group in groupby_ngay)
                    {

                        ExcelWorksheet destinationWorksheet = workbook.Worksheets.Copy("Sheet1", group.ngay.ToString("yyyy/MM/dd"));
                        destinationWorksheet.Cells["C3"].Value = group.ngay.ToString("dd/MM/yyyy");
                        int start_r = 5;
                        foreach (var d in group.data)
                        {


                            var enti = db3;
                            var kh = danhsach.Where(r => r.makh == d.makh).FirstOrDefault();

                            if (kh != null)
                            {

                                var tinh = enti.TBL_DANHMUCQUAN.Where(r => r.maquan == kh.quanhuyen).FirstOrDefault();
                                if (tinh != null)
                                {
                                    destinationWorksheet.Cells["A" + start_r].Value = tinh.tenquan;
                                }
                                else
                                {
                                    destinationWorksheet.Cells["A" + start_r].Value = kh.quanhuyen;
                                }
                            }

                            destinationWorksheet.Cells["B" + start_r].Value = d.makh + " - " + d.tenkh;
                            destinationWorksheet.Cells["C" + start_r].Value = d.ghichu;
                            destinationWorksheet.Cells["D" + start_r].Value = d.ketqua_text;
                            start_r++;

                            destinationWorksheet.Cells[destinationWorksheet.Dimension.Address].AutoFitColumns();
                        }
                    }
                    package.Workbook.Worksheets.Delete(worksheet);
                    package.SaveAs(memoryStream);
                }
                memoryStream.Seek(0, SeekOrigin.Begin);
                memoryStream.Position = 0;
                return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");


            }

        }


        public ActionResult excelkehoachtuan(string matdv, DateTime ngay)
        {

            string path = Server.MapPath("~/Content/mauKHtuan.xlsx");
            using (var memoryStream = new MemoryStream())
            {
                using (var package = new ExcelPackage(new FileInfo(path)))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorkbook workbook = package.Workbook;
                    ExcelWorksheet worksheet = workbook.Worksheets[0];

                    var t2 = ngay.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                    var t3 = ngay.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Tuesday);
                    var t4 = ngay.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Wednesday);
                    var t5 = ngay.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Thursday);
                    var t6 = ngay.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Friday);
                    var t7 = ngay.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Saturday);
                    var cn = ngay.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Sunday);

                    worksheet.Cells["A3"].Value = $" KẾ HOẠCH LÀM VIỆC TUẦN   /  TỪ   {t2.ToString("dd/MM/yyyy")}   ĐẾN    {t7.ToString("dd/MM/yyyy")}";
                    var db3 = queryKT.SingleOrDefault(d => d.macn == "DPY").data;
                    var tdv = db2.TBL_DANHMUCNGUOIDUNG.FirstOrDefault(d => d.nguoidung == matdv);
                    if (tdv != null)
                    {
                        var matinh = tdv.matinh;
                        var hoten = tdv.hoten;

                        worksheet.Cells["C1"].Value = matdv + " - " + hoten;

                        var enti = db3;
                        var tinh = enti.TBL_DANHMUCDONVI.Where(r => r.MaTinh == matinh).FirstOrDefault();
                        if (tinh != null)
                        {
                            worksheet.Cells["C2"].Value = tinh.TenTinh;
                        }
                        else
                        {
                            worksheet.Cells["C2"].Value = matinh;
                        }



                    }
                    var congtac_t2 = db2.DTA_CONGTACTRINHDUOC.Where(d => d.matdv == matdv && d.ngay == t2).ToList();
                    int start_r = 5;

                    var enti2 = queryKT.SingleOrDefault(d => d.macn == "DPY").data;
                    var enti1 = queryKT.SingleOrDefault(d => d.macn == "DPY_HCM").data;
                    var danhsach = enti2.TBL_DANHMUCKHACHHANG
                          .Where(d => d.tinhtrang != "Ngừng giao dịch")
                          .ToList();
                    danhsach.AddRange(enti1.TBL_DANHMUCKHACHHANG
                        .Where(d => d.tinhtrang != "Ngừng giao dịch")
                        .ToList());

                    foreach (var d in congtac_t2)
                    {



                        var enti = db3;
                        var kh = danhsach.Where(r => r.makh == d.makh).FirstOrDefault();
                        if (kh != null)
                        {

                            var tinh = enti.TBL_DANHMUCQUAN.Where(r => r.maquan == kh.quanhuyen).FirstOrDefault();
                            if (tinh != null)
                            {
                                worksheet.Cells["B" + start_r].Value = tinh.tenquan;
                            }
                            else
                            {
                                worksheet.Cells["B" + start_r].Value = kh.quanhuyen;
                            }
                        }

                        worksheet.Cells["C" + start_r].Value = d.makh + " - " + d.tenkh;
                        worksheet.Cells["D" + start_r].Value = d.ghichu;
                        start_r++;


                    }

                    var congtac_t3 = db2.DTA_CONGTACTRINHDUOC.Where(d => d.matdv == matdv && d.ngay == t3).ToList();
                    start_r = 18;

                    foreach (var d in congtac_t3)
                    {


                        var enti = db3;
                        var kh = danhsach.Where(r => r.makh == d.makh).FirstOrDefault();
                        if (kh != null)
                        {

                            var tinh = enti.TBL_DANHMUCQUAN.Where(r => r.maquan == kh.quanhuyen).FirstOrDefault();
                            if (tinh != null)
                            {
                                worksheet.Cells["B" + start_r].Value = tinh.tenquan;
                            }
                            else
                            {
                                worksheet.Cells["B" + start_r].Value = kh.quanhuyen;
                            }
                        }

                        worksheet.Cells["C" + start_r].Value = d.makh + " - " + d.tenkh;
                        worksheet.Cells["D" + start_r].Value = d.ghichu;
                        start_r++;


                    }

                    var congtac_t4 = db2.DTA_CONGTACTRINHDUOC.Where(d => d.matdv == matdv && d.ngay == t4).ToList();
                    start_r = 31;
                    foreach (var d in congtac_t4)
                    {

                        var enti = db3;
                        var kh = danhsach.Where(r => r.makh == d.makh).FirstOrDefault();
                        if (kh != null)
                        {

                            var tinh = enti.TBL_DANHMUCQUAN.Where(r => r.maquan == kh.quanhuyen).FirstOrDefault();
                            if (tinh != null)
                            {
                                worksheet.Cells["B" + start_r].Value = tinh.tenquan;
                            }
                            else
                            {
                                worksheet.Cells["B" + start_r].Value = kh.quanhuyen;
                            }
                        }

                        worksheet.Cells["C" + start_r].Value = d.makh + " - " + d.tenkh;
                        worksheet.Cells["D" + start_r].Value = d.ghichu;
                        start_r++;


                    }
                    var congtac_t5 = db2.DTA_CONGTACTRINHDUOC.Where(d => d.matdv == matdv && d.ngay == t5).ToList();
                    start_r = 44;
                    foreach (var d in congtac_t5)
                    {

                        var enti = db3;
                        var kh = danhsach.Where(r => r.makh == d.makh).FirstOrDefault();
                        if (kh != null)
                        {

                            var tinh = enti.TBL_DANHMUCQUAN.Where(r => r.maquan == kh.quanhuyen).FirstOrDefault();
                            if (tinh != null)
                            {
                                worksheet.Cells["B" + start_r].Value = tinh.tenquan;
                            }
                            else
                            {
                                worksheet.Cells["B" + start_r].Value = kh.quanhuyen;
                            }
                        }

                        worksheet.Cells["C" + start_r].Value = d.makh + " - " + d.tenkh;
                        worksheet.Cells["D" + start_r].Value = d.ghichu;
                        start_r++;


                    }

                    var congtac_t6 = db2.DTA_CONGTACTRINHDUOC.Where(d => d.matdv == matdv && d.ngay == t6).ToList();
                    start_r = 57;
                    foreach (var d in congtac_t6)
                    {

                        var enti = db3;
                        var kh = danhsach.Where(r => r.makh == d.makh).FirstOrDefault();
                        if (kh != null)
                        {

                            var tinh = enti.TBL_DANHMUCQUAN.Where(r => r.maquan == kh.quanhuyen).FirstOrDefault();
                            if (tinh != null)
                            {
                                worksheet.Cells["B" + start_r].Value = tinh.tenquan;
                            }
                            else
                            {
                                worksheet.Cells["B" + start_r].Value = kh.quanhuyen;
                            }
                        }

                        worksheet.Cells["C" + start_r].Value = d.makh + " - " + d.tenkh;
                        worksheet.Cells["D" + start_r].Value = d.ghichu;
                        start_r++;


                    }

                    var congtac_t7 = db2.DTA_CONGTACTRINHDUOC.Where(d => d.matdv == matdv && d.ngay == t7).ToList();
                    start_r = 70;
                    foreach (var d in congtac_t7)
                    {


                        var enti = db3;
                        var kh = danhsach.Where(r => r.makh == d.makh).FirstOrDefault();
                        if (kh != null)
                        {

                            var tinh = enti.TBL_DANHMUCQUAN.Where(r => r.maquan == kh.quanhuyen).FirstOrDefault();
                            if (tinh != null)
                            {
                                worksheet.Cells["B" + start_r].Value = tinh.tenquan;
                            }
                            else
                            {
                                worksheet.Cells["B" + start_r].Value = kh.quanhuyen;
                            }
                        }

                        worksheet.Cells["C" + start_r].Value = d.makh + " - " + d.tenkh;
                        worksheet.Cells["D" + start_r].Value = d.ghichu;
                        start_r++;


                    }
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    package.SaveAs(memoryStream);
                }
                memoryStream.Seek(0, SeekOrigin.Begin);
                memoryStream.Position = 0;
                return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");


            }

        }
        //[HttpPost]
        //public ActionResult DelKhachHang(string tenkh)
        //{
        //    var Infocrm = GetCRM();
        //    var MATDV = Infocrm.matdv;
        //    var MACH = Infocrm.macn.Split(',').ToList().First();
        //    DATADELKH(MACH, MATDV, tenkh);
        //    return Json(1);
        //}
        //public void DATASAVEKHTN(string x, TBL_DANHMUCKHACHHANGTIEMNANG data)
        //{
        //    if (x == "QN")
        //    {
        //        QuangNgai.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        QuangNgai.SaveChanges();
        //    }
        //    else if (x == "TN")
        //    {
        //        TayNinh.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        TayNinh.SaveChanges();
        //    }
        //    else if (x == "CHQ10")
        //    {
        //        CHQ10.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        CHQ10.SaveChanges();
        //    }
        //    else if (x == "CH163")
        //    {
        //        db2.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        db2.SaveChanges();
        //    }
        //    else if (x == "CH245")
        //    {
        //        db2.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        db2.SaveChanges();
        //    }
        //    else if (x == "BD")
        //    {
        //        BinhDinh.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        BinhDinh.SaveChanges();
        //    }
        //    else if (x == "CT")
        //    {
        //        CanTho.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        CanTho.SaveChanges();
        //    }
        //    else if (x == "DN")
        //    {
        //        DongNai.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        DongNai.SaveChanges();
        //    }
        //    else if (x == "DNA")
        //    {
        //        DaNang.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        DaNang.SaveChanges();
        //    }
        //    else if (x == "HCM")
        //    {
        //        HoChiMinh.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        HoChiMinh.SaveChanges();
        //    }
        //    else if (x == "NA")
        //    {
        //        NgheAn.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        NgheAn.SaveChanges();
        //    }
        //    else if (x == "NA2")
        //    {
        //        NgheAn.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        NgheAn.SaveChanges();
        //    }
        //    else if (x == "PY")
        //    {
        //        PhuYen.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        PhuYen.SaveChanges();
        //    }
        //    else if (x == "AG")
        //    {
        //        AnGiang.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        AnGiang.SaveChanges();
        //    }
        //    else if (x == "CM")
        //    {
        //        CaMau.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        CaMau.SaveChanges();
        //    }
        //    else if (x == "GL")
        //    {
        //        GiaLai.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        GiaLai.SaveChanges();
        //    }
        //    else if (x == "HUE")
        //    {
        //        Hue.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        Hue.SaveChanges();
        //    }
        //    else if (x == "LD")
        //    {
        //        LamDong.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        LamDong.SaveChanges();
        //    }
        //    else if (x == "NT")
        //    {
        //        NhaTrang.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        NhaTrang.SaveChanges();
        //    }
        //    else if (x == "TG")
        //    {
        //        TienGiang.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        TienGiang.SaveChanges();
        //    }
        //    else if (x == "VL")
        //    {
        //        VinhLong.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        VinhLong.SaveChanges();
        //    }
        //    else if (x == "PTTT")
        //    {
        //        PTTT.TBL_DANHMUCKHACHHANGTIEMNANG.Add(data);
        //        PTTT.SaveChanges();
        //    }
        //}

        //public void DATAUPDATEKEHOACH(string x, DTA_CONGTACTRINHDUOC data)
        //{
        //    if (x == "QN")
        //    {
        //        var datax = QuangNgai.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            QuangNgai.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        QuangNgai.SaveChanges();
        //    }
        //    else if (x == "TN")
        //    {
        //        var datax = TayNinh.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            TayNinh.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        TayNinh.SaveChanges();
        //    }
        //    else if (x == "CHQ10")
        //    {
        //        var datax = CHQ10.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            CHQ10.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        CHQ10.SaveChanges();
        //    }
        //    else if (x == "CH163")
        //    {
        //        var datax = db2.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            db2.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        db2.SaveChanges();
        //    }
        //    else if (x == "CH245")
        //    {
        //        var datax = db2.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            db2.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        db2.SaveChanges();
        //    }
        //    else if (x == "BD")
        //    {
        //        var datax = BinhDinh.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            BinhDinh.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        BinhDinh.SaveChanges();
        //    }
        //    else if (x == "CT")
        //    {
        //        var datax = CanTho.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            CanTho.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        CanTho.SaveChanges();
        //    }
        //    else if (x == "DN")
        //    {
        //        var datax = DongNai.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            DongNai.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        DongNai.SaveChanges();
        //    }
        //    else if (x == "DNA")
        //    {
        //        var datax = DaNang.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            DaNang.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        DaNang.SaveChanges();
        //    }
        //    else if (x == "HCM")
        //    {
        //        var datax = HoChiMinh.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            HoChiMinh.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        HoChiMinh.SaveChanges();
        //    }
        //    else if (x == "NA")
        //    {
        //        var datax = NgheAn.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            NgheAn.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        NgheAn.SaveChanges();
        //    }
        //    else if (x == "PY")
        //    {
        //        var datax = PhuYen.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            PhuYen.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        PhuYen.SaveChanges();
        //    }
        //    else if (x == "AG")
        //    {
        //        var datax = AnGiang.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            AnGiang.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        AnGiang.SaveChanges();
        //    }
        //    else if (x == "CM")
        //    {
        //        var datax = CaMau.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            CaMau.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        CaMau.SaveChanges();
        //    }
        //    else if (x == "GL")
        //    {
        //        var datax = GiaLai.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            GiaLai.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        GiaLai.SaveChanges();
        //    }
        //    else if (x == "HUE")
        //    {
        //        var datax = Hue.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            Hue.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        Hue.SaveChanges();
        //    }
        //    else if (x == "LD")
        //    {
        //        var datax = LamDong.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            LamDong.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        LamDong.SaveChanges();
        //    }
        //    else if (x == "NT")
        //    {
        //        var datax = NhaTrang.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            NhaTrang.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        NhaTrang.SaveChanges();
        //    }
        //    else if (x == "TG")
        //    {
        //        var datax = TienGiang.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            TienGiang.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        TienGiang.SaveChanges();
        //    }
        //    else if (x == "VL")
        //    {
        //        var datax = VinhLong.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            VinhLong.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        VinhLong.SaveChanges();
        //    }
        //    else if (x == "PTTT")
        //    {
        //        var datax = PTTT.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.ngay == data.ngay && n.tenkh == data.tenkh && n.matdv == data.matdv);
        //        if (datax != null)
        //        {
        //            datax.ghichu = data.ghichu;
        //            datax.ketqua = data.ketqua;
        //            datax.checkin = data.checkin;
        //            datax.khoa = data.khoa;
        //        }
        //        else
        //        {
        //            PTTT.DTA_CONGTACTRINHDUOC.Add(data);
        //        }
        //        PTTT.SaveChanges();
        //    }
        //}
        public void DATADELKEHOACH(string x, string MATDV, DateTime ngay)
        {
            var data = db2.DTA_CONGTACTRINHDUOC.Where(n => n.macn == x && n.matdv == MATDV && n.ngay == ngay);
            db2.DTA_CONGTACTRINHDUOC.RemoveRange(data);
            db2.SaveChanges();
        }

        public List<DTA_CONGTACTRINHDUOC> DATAGETKEHOACH(string x, string MATDV, string ngay)
        {
            DateTime date = DateTime.ParseExact(ngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return db2.DTA_CONGTACTRINHDUOC.Where(n => n.macn == x && n.matdv == MATDV && n.ngay == date).ToList();
        }
        public List<DTA_CONGTACTRINHDUOC> DATAGETKEHOACHALL(string MATDV, DateTime tungay, DateTime denngay)
        {
            return db2.DTA_CONGTACTRINHDUOC.Where(n => n.matdv == MATDV && n.ngay >= tungay && n.ngay <= denngay).ToList();
        }
        public DTA_CONGTACTRINHDUOC DATAGETKEHOACHNOW(string x, string MATDV, string ngay, string makh, string tenkh)
        {
            DateTime ngay1 = DateTime.ParseExact(ngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return db2.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.macn == x && n.matdv == MATDV && n.ngay == ngay1 && n.makh == makh);
        }

        public List<ListKhachHangFull> DATAGETKHACHHANGCN(string x)
        {
            var DATAX = new List<ListKhachHangFull>();
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                var enti = queryCN.SingleOrDefault(n => n.macn == x).data;
                var data3 = enti.Database.SqlQuery<ListKhachHangFull>("SELECT makh AS MAKH, donvi AS DONVI , tennguoigd AS TENNGUOILH , dt AS DT from TBL_DANHMUCKHACHHANG");
                DATAX = DATAX.Concat(data3).ToList();
            }
            return DATAX;
        }

        public List<BCKEHOACHCHITIET> DATAGETKEHOACHHETHONG(string MATK, DateTime tungay, DateTime denngay)
        {
            var DATAX = new List<BCKEHOACHCHITIET>();
            foreach (var item in query)
            {
                var enti = item.data;
                var data = enti.DTA_DONDATHANG.Where(n => n.NgayDat >= tungay && n.NgayDat < denngay && n.USERTAO == MATK && n.DUYETDH == true).GroupBy(n => new { n.MAKH, n.NgayDat.Day }).Select(cl => new BCKEHOACHCHITIET { makh = cl.Key.MAKH, ngay = cl.Key.Day, loai = 6 });
                DATAX.AddRange(data.ToList());
            }

            return DATAX.ToList();
        }
        public KhachHangFull DATAGETKHACHHANGVIEW(string makh)
        {
            var DATAX = new KhachHangFull();
            string str = "SELECT macn,makh AS MAKH, donvi AS DONVI , tennguoigd AS TENNGUOILH , dt AS DT , diachi AS DIACHI, FORMAT(ngaygdgannhat, 'dd/MM/yyyy ') AS DONHANGGANHAT , FORMAT(ngaysinh, 'dd/MM/yyyy ') AS NGAYSINH , masothue as MST,xeploai,matinh,quanhuyen from TBL_DANHMUCKHACHHANG where makh='" + makh + "'";
            foreach (var item in query)
            {
                var data3 = item.data.Database.SqlQuery<KhachHangFull>(str);
                if (data3.Count() > 0)
                {
                    DATAX = data3.First();
                    break;
                }
            }




            return DATAX;
        }

        public void UPDATETHONGTINKHACHHANG(string macn, string makh, string dt, string xeploai, string matinh, string diachi, string lienhe, string quanhuyen, string masothue)
        {
            //DateTime ngaysinh1 = DateTime.ParseExact(ngaysinh, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //string str = "UPDATE TBL_DANHMUCKHACHHANG SET dt = '" + dt + "', xeploai = '" + xeploai + "' WHERE makh = '" + makh + "'";
            //string strch = "SELECT MaKH AS MAKH, DonVi AS DONVI, DiaChi AS DIACHI, ngaygdgannhat AS DONHANGGANHAT , TENNGUOIGD AS TENNGUOILH, dt AS DT from DM_KHACHHANG_PTTT where MaKH='" + makh + "'";

            foreach (var item in queryKT)
            {
                var enti = item.data;
                var record = enti.TBL_DANHMUCKHACHHANG.Where(d => d.makh == makh).FirstOrDefault();
                if (record != null)
                {
                    record.dt = dt;
                    record.xeploai = xeploai;
                    record.matinh = matinh;
                    record.masothue = masothue;
                    record.diachi = diachi;
                    record.quanhuyen = quanhuyen;
                    record.tennguoigd = lienhe;
                    record.ngaycapnhat = DateTime.Now;
                    record.macn = macn;
                    enti.TBL_DANHMUCKHACHHANG.AddOrUpdate(record);
                    enti.SaveChanges();
                }
            }

        }

        public TBL_DANHMUCNGUOIDUNG GetInfo()
        {
            TBL_DANHMUCNGUOIDUNG abc = new TBL_DANHMUCNGUOIDUNG();
            abc = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name.ToString());
            return abc;
        }
        public List<DULIEUBAOCAO0> DATABAOCAO0(DateTime tungay, DateTime denngay, TBL_DANHMUCNGUOIDUNG Info)
        {
            //var Info = GetInfo();
            //String CN
            List<string> nhomhang = new List<string>(new string[] { "50", "51", "60", "61", "62", "63", "70" });
            string strcn = "seleCT HOADON.MaPL,  sum(  ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)) as TONGTIEN_CT_HOADON   ,  sum( round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*cast(TYLECK as money) /100,0)) as TIENCK ,TBL_MIEN.MIEN as chuky1 ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC from TBL_MIEN, TBL_DANHMUCTIEUDEBAOCAO, DTA_CT_HOADON_XUAT CT LEFT JOIN   TBL_DANHMUCHANGHOA ON CT.mahh = TBL_DANHMUCHANGHOA.mahh, DTA_HOADON_XUAT HOADON   LEFT JOIN   TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MaPL IN ('BAN','XK') AND HOADON.MACH = CT.MACH AND CT.KT = 1";
            string strch = "seleCT HOADON.MaPL,  sum(  ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)) as TONGTIEN_CT_HOADON   ,  sum( round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*cast(TYLECK as money) /100,0)) as TIENCK ,TBL_MIEN.MIEN as chuky1 ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC from TBL_MIEN,tieude TBL_DANHMUCTIEUDEBAOCAO, CT_HOADON_XUAT CT  LEFT JOIN  DM_HANGHOA ON CT.mahh = DM_HANGHOA.mahh, HOADON_XUAT  HOADON LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.MaPL IN ('BAN','XK') AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1 ";
            string strnew = "select SUM(ISNULL(CAST(TIENCHIETKHAU   AS MONEY ),0)) AS TIENCK,substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) AS MaPL,SUM(ISNULL(CAST(TIENBAN   AS MONEY), 0)) AS TONGTIEN_CT_HOADON,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_MIEN.MIEN AS chuky1 from dtasoluong, dtaDinhKhoan, dclChiTietHangHoa, dclChiTietKhachHang, dclDanhSachDonViTinh, tbl_danhmuctieudebaocao, tbl_mien, KT_TH.DBO.TBL_DANHMUCKHACHHANG right join TBL_DANHMUCCUAHANG on KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = TBL_DANHMUCCUAHANG.MaCH right join dtaChungTu ON KT_TH.DBO.TBL_DANHMUCKHACHHANG.makh = CAST(dtaChungTu.KhachHangID as varchar) where dtasoluong.dinhkhoanid = dtaDinhKhoan.CapDKID And dclChiTietKhachHang.TaiKhoanID = dtaChungTu.KHACHHANGID And dtaDinhKhoan.chungtuid = dtaChungTu.chungtuid and dtaDinhKhoan.IDTaiKhoanCo = dclChiTietHangHoa.TaiKhoanID and dclDanhSachDonViTinh.DonViTinhID = dclChiTietHangHoa.DonViTinhID  AND substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) = '632' AND dtaChungTu.ngaychungtu between '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "'";
            var phanloai = Info.phanloai.Split(',').ToList();
            strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", string.Join(",", phanloai.Select(p => "'" + p + "'")));
            strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.phanloai IN ({0})", string.Join(",", phanloai.Select(p => "'" + p + "'")));
            strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", string.Join(",", phanloai.Select(p => "'" + p + "'")));
            if (nhomhang != null)
            {
                strcn = strcn + string.Format(" AND TBL_DANHMUCHANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND DM_HANGHOA.nhom IN ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND substring(replace(dclChiTietHangHoa.MaCap, ' ', ''), 1, 2) in ({0})", string.Join(",", nhomhang.Select(p => "'" + p + "'")));
            }
            if (Info.matinh != "ALL")
            {
                var matinh = Info.matinh.Split(',').ToList();
                strcn = strcn + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.matinh IN ({0})", string.Join(",", matinh.Select(p => "'" + p + "'")));
                strnew = strnew + string.Format(" AND cast(dtaChungTu.KHACHHANGID as varchar) IN (select makh from KT_TH.DBO.TBL_DANHMUCKHACHHANG where MACH=@MACN AND matinh IN ({0}))", string.Join(",", matinh.Select(p => "'" + p + "'")));
            }
            if (Info.matdv != "ALL")
            {
                var matdv = Info.matdv.Split(',').ToList();
                strcn = strcn + string.Format(" AND HOADON.MaTDV IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
                strch = strch + string.Format(" AND TBL_DANHMUCKHACHHANG.MATDV IN ({0})", string.Join(",", matdv.Select(p => "'" + p + "'")));
            }
            strcn = strcn + " GROUP BY  TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc , HOADON.MaPL";
            strch = strch + " GROUP BY HOADON.MaPL, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc";
            strnew = strnew + " group by substring(dtaDinhKhoan.TaiKhoanNo, 1, 3),tbl_danhmuctieudebaocao.tendvbc, tbl_mien.mien";
            var DATAX = new List<DULIEUBAOCAO0>();
            foreach (var item in query)
            {

                var enti = item.data;
                DATAX.AddRange(BAOCAOCHINHANH0(enti, strcn));

            }
            return DATAX;
        }
        public decimal? DATABAOCAODOANHSO(DateTime tungay, DateTime denngay, string matdv)
        {
            try
            {
                string strcn = "seleCT ROUND(CAST(CT.SOLUONG AS MONEY) * (CAST(CT.GIABAN_VAT AS MONEY)), 0) as TONGTIEN_CT_HOADON  " +
                    " ,  ROUND(SUM(CT.SOLUONG * (CT.GIABAN_VAT / (1 + (CAST(CT.vat as MONEY)/100))) * (CAST(CT.ck AS MONEY)/100)),0) AS TIENCK " +
                    "from DTA_DONDATHANG CT " +
                        "LEFT JOIN   TBL_DANHMUCHANGHOA ON CT.MAHH = TBL_DANHMUCHANGHOA.MAHH " +
                         "LEFT JOIN   TBL_DANHMUCKHACHHANG ON CT.MAKH = TBL_DANHMUCKHACHHANG.makh " +
                        "LEFT JOIN TBL_DANHMUCTDV on CT.MATDV = TBL_DANHMUCTDV.MaTDV   " +
                    "where CT.NgayDat>= '" + tungay.ToString("yyyy-MM-dd") + "' and CT.NgayDat <='" + denngay.AddDays(1).ToString("yyyy-MM-dd") + "'";


                strcn = strcn + string.Format(" AND CT.MaTDV = '" + matdv + "'");

                strcn = strcn + " GROUP BY  CT.MACH,CT.SOLUONG,CT.GIABAN_VAT";
                var DATAX = new List<DULIEUBAOCAO0>();
                foreach (var item in query)
                {
                    var enti = item.data;
                    DATAX.AddRange(BAOCAOCHINHANH0(enti, strcn));
                }
                return DATAX.Sum(cl => cl.TONGTIEN_CT_HOADON);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int DATAGETQLDHCOUNT(string taikhoan, DateTime tungay, DateTime denngay)
        {
            int DATAX = 0;
            foreach (var item in query)
            {
                var enti = item.data;
                DATAX += enti.DTA_DONDATHANG.Where(n => n.MATDV == taikhoan && n.NgayDat >= tungay && n.NgayDat <= denngay).GroupBy(d => d.MADH).Count();
            }

            return DATAX;
        }
        public List<DULIEUBAOCAO0> BAOCAOCHINHANH0(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<DULIEUBAOCAO0>(str).ToList();
            return All;
        }
        public List<ListKhuVuc> DATAGETKHUVUC(string x)
        {
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                var enti = queryCN.SingleOrDefault(n => n.macn == x).data;
                var All = enti.Database.SqlQuery<ListKhuVuc>("SELECT MaTinh, TenTinh FROM TBL_DANHMUCDONVI WHERE MaTinh IS NOT NULL").ToList();
                return All;
            }

            else
            {
                return null;
            }
        }
    }
}