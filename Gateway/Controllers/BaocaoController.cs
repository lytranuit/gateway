using ApplicationChart.Models;
using DevExpress.XtraPrinting;
using Microsoft.Security.Application;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                     new EntitiesCN {data = new Entities("KT_THOEntities") , macn = "THO"},
                       new EntitiesCN {data = new Entities("KT_BTEntities") , macn = "BT"},
                            new EntitiesCN {data = new Entities("KT_PTEntities") , macn = "PT"},
            new EntitiesCN {data = new Entities("KT_HNEntities") , macn = "HN"},
               new EntitiesCN {data = new Entities("KT_TNGEntities") , macn = "TNG"},
            new EntitiesCN {data = new Entities("KT_TBEntities") , macn = "TB"},
                 new EntitiesCN {data = new Entities("KT_PYPHARMEntities") , macn = "DPY"},
                 new EntitiesCN {data = new Entities("KT_PYPHARM_HCMEntities") , macn = "DPY_HCM"},
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
            var MATDV = Infocrm.matdv;
            var MACH = Infocrm.macn;
            //if (Infocrm.quyen == "QUANLY")
            //{
            var taphop = Infocrm.macn.Split(',').ToList();
            var donvi = db2.TBL_DANHSACHCHINHANH.Where(n => taphop.Contains(n.macn)).ToList();
            ViewBag.mientrung = donvi.Where(n => n.Mien == "MIỀN TRUNG").OrderBy(n => n.stt);
            ViewBag.miennam = donvi.Where(n => n.Mien == "MIỀN NAM").OrderBy(n => n.stt);
            ViewBag.mienbac = donvi.Where(n => n.Mien == "MIỀN BẮC").OrderBy(n => n.stt);
            return View("/Views/Baocao/Quanlykhachhang.cshtml");
            //}
            //else
            //{
            //    return View("Danhsachkhachhang", DATA(MACH, MATDV, true).OrderBy(n => n.DONVI).ToList());
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
        [ActionName("danh-sach-khach-hang")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Danhsachkhachhang(string donvi, string diachi, string tennguoilh, string dt, string phanloai, string phanloaikhachhang, string matinh)
        {
            var Info = GetInfo();
            var Infocrm = GetCRM();
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            ViewBag.dathang = Info.dathang;
            var MATDV = Infocrm.matdv;
            var MACH = Infocrm.macn;

            ViewBag.phanloaikhachhang = db2.TBL_DANHMUCPHANLOAIKHACHHANG.OrderBy(n => n.phanloaikhachhang);
            ViewBag.matinh = DATAGETKHUVUC(MACH);
            if (Infocrm.quyen == "QUANLY")
            {
                ViewBag.disable = true;
                return View("Danhsachkhachhang", DATAGETKHACHHANGCN(MACH).OrderBy(n => n.DONVI).ToList());
            }
            else
            {
                if (MATDV.Split(',').ToList().Count() > 1)
                {
                    ViewBag.disable = true;
                }
                return View("Danhsachkhachhang", DATA(MACH, MATDV, true).OrderBy(n => n.DONVI).ToList());
            }
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
            var MATDV = Infocrm.matdv;
            var MACH = Infocrm.macn;
            var Data = DATA(MACH, MATDV, false);
            ViewBag.KH = Data;
            var tuantruoc = DateTime.Now.AddDays(-14);

            ViewBag.data = db2.DTA_CONGTACTRINHDUOC.Where(n => n.macn == MACH && n.matdv == Infocrm.taikhoan && n.ngay >= tuantruoc).ToList().GroupBy(n => n.ngay).Select(cl => new { ngay = cl.Key.ToString("dd/MM/yyyy"), soluong = cl.Count(), khoa = !(cl.Any(n => n.khoa == false)) }).ToList();
            return View("Lich");
        }
        public List<ListKhachHang> DATA(string x, string MATDV, bool full)
        {
            var DATAX = new List<ListKhachHang>();
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                var enti = queryCN.SingleOrDefault(n => n.macn == x).data;
                var data3 = enti.Database.SqlQuery<ListKhachHang>("SELECT makh AS MAKH, donvi AS DONVI " + ((full == true) ? " , diachi AS DIACHI , dt AS DT, ngaysinh AS NGAYSINH " : "") + " from TBL_DANHMUCKHACHHANG" + string.Format(" WHERE matdv IN ({0}) and (tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null)", string.Join(",", MATDV.Split(',').ToList().Select(p => "'" + p + "'"))));
                DATAX = data3.ToList();
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

            return PartialView(DATA(macn, String.Join(",", matdv.ToArray()), true));

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
            var MATDV = Infocrm.matdv;
            var MACH = Infocrm.macn;
            var donvi = new List<TBL_DANHSACHCHINHANH>();
            if (Infocrm.macn == "ALL")
            {
                donvi = db2.TBL_DANHSACHCHINHANH.ToList();
            }
            else
            {
                var taphop = Infocrm.macn.Split(',').ToList();
                donvi = db2.TBL_DANHSACHCHINHANH.Where(n => taphop.Contains(n.macn)).ToList();
            }
            ViewBag.mientrung = donvi.Where(n => n.Mien == "MIỀN TRUNG").OrderBy(n => n.stt);
            ViewBag.miennam = donvi.Where(n => n.Mien == "MIỀN NAM").OrderBy(n => n.stt);
            ViewBag.mienbac = donvi.Where(n => n.Mien == "MIỀN BẮC").OrderBy(n => n.stt);
            return View("Congtactrinhduoc");
        }
        [ActionName("du-lieu-bao-cao-cong-tac")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Baocaoview(List<string> chinhanh, List<string> matdv, int loaibaocao, int baocao, string tungay, string denngay, string tentdv, string thang)
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
                    var data = DATAGETKEHOACHALL(chinhanh.FirstOrDefault(), matdv.FirstOrDefault(), tungay1, denngay1).Select(cl => new { cl.checkin, cl.ghichu, cl.ketqua, cl.khoa, cl.makh, cl.ngay.Day }).ToList();
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
                        var z = DATAGETKEHOACHHETHONG(chinhanh.FirstOrDefault(), crm.matdv, matdv.FirstOrDefault(), tungay1, denngay1.AddDays(1), denngay1);
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
                        ViewBag.data = DATAGETKEHOACHHETHONG(chinhanh.FirstOrDefault(), crm.matdv, matdv.FirstOrDefault(), tungay1, denngay1.AddDays(1), denngay1);
                    }
                    var data1 = data.Where(n => n.checkin == true).GroupBy(n => n.Day).Select(cl => new Tuple<int, string>(cl.Count(), cl.Key.ToString())).ToList();
                    ViewBag.result = data1;
                    try
                    {
                        ViewBag.doanhso = DATABAOCAO0(chinhanh.FirstOrDefault().Split(',').ToList(), tungay1, denngay1, db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == matdv.FirstOrDefault())).First().TONGTIEN_CT_HOADON;
                    }
                    catch (Exception)
                    {
                        ViewBag.doanhso = null;
                    }
                    var final = new LISTBAOCAOCHITIETNGAYCRM() { tungay = tungay1, denngay = denngay1, hovaten = crm.TBL_DANHMUCNGUOIDUNG.hoten, macn = crm.macn, taikhoan = crm.TBL_DANHMUCNGUOIDUNG.nguoidung, data = DATA(chinhanh.FirstOrDefault(), crm.matdv, true).OrderBy(n => n.DONVI).ToList(), tencn = db2.TBL_DANHSACHCHINHANH.SingleOrDefault(n => n.macn == chinhanh.FirstOrDefault()).Tencn };
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
                    var data = DATAGETKEHOACHALL(chinhanh.FirstOrDefault(), matdv.FirstOrDefault(), tungay1, denngay1).Select(cl => new { cl.checkin, cl.ghichu, cl.ketqua, cl.khoa, cl.makh, cl.ngay.Day }).ToList();
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
                        var z = DATAGETKEHOACHHETHONG(chinhanh.FirstOrDefault(), crm.matdv, matdv.FirstOrDefault(), tungay1, denngay1.AddDays(1), denngay1);
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
                        ViewBag.data = DATAGETKEHOACHHETHONG(chinhanh.FirstOrDefault(), crm.matdv, matdv.FirstOrDefault(), tungay1, denngay1.AddDays(1), denngay1);
                    }
                    var data1 = data.Where(n => n.checkin == true).GroupBy(n => n.Day).Select(cl => new Tuple<int, string>(cl.Count(), cl.Key.ToString())).ToList();
                    var data3 = data.Where(n => n.checkin == true);
                    try
                    {
                        ViewBag.doanhso = DATABAOCAO0(chinhanh.FirstOrDefault().Split(',').ToList(), tungay1, denngay1, db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == matdv.FirstOrDefault())).First().TONGTIEN_CT_HOADON;
                    }
                    catch (Exception)
                    {
                        ViewBag.doanhso = null;
                    }
                    var final = new LISTBAOCAOCHITIETNGAYCRM() { tungay = tungay1, denngay = denngay1, hovaten = crm.TBL_DANHMUCNGUOIDUNG.hoten, macn = crm.macn, taikhoan = crm.TBL_DANHMUCNGUOIDUNG.nguoidung, data = DATA(chinhanh.FirstOrDefault(), crm.matdv, true).OrderBy(n => n.DONVI).ToList(), tencn = db2.TBL_DANHSACHCHINHANH.SingleOrDefault(n => n.macn == chinhanh.FirstOrDefault()).Tencn };
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
                DateTime tungay1 = (loaibaocao == 1) ? DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact(thang, "MM/yyyy", CultureInfo.InvariantCulture);
                DateTime denngay1 = (loaibaocao == 1) ? DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture) : tungay1.AddMonths(1).AddDays(-1);
                List<Tuple<int, string, string>> allDates = new List<Tuple<int, string, string>>();
                for (DateTime date = tungay1; date <= denngay1; date = date.AddDays(1))
                    allDates.Add(new Tuple<int, string, string>(date.Day, date.DayOfWeek.ToString(), date.ToString("dd/MM/yyyy")));
                var data = new LISTBAOCAOTONGHOPCRM { tungay = tungay1, denngay = denngay1, songaylamviec = allDates.Where(n => n.Item2 != "Sunday").Count() };
                var listtdv = (infocrm.quyen != "QUANLY") ? infocrm.matdv.Split(',').ToList() : null;
                var taikhoan = (infocrm.quyen == "QUANLY") ? db2.TBL_PHANQUYENCRM.Where(n => chinhanh.Contains(n.macn) && n.quyen == "TDV").ToList() : db2.TBL_PHANQUYENCRM.Where(n => listtdv.Contains(n.matdv)).ToList();
                var list = new List<BAOCAOTONGHOPCRM>();
                foreach (var i in taikhoan)
                {
                    var ngaybc = db2.DTA_CONGTACTRINHDUOC.Where(n => n.matdv == i.taikhoan && n.ngay >= tungay1 && n.ngay <= denngay1 && n.khoa == true);
                    list.Add(new BAOCAOTONGHOPCRM { doanhsootc = DATABAOCAODOANHSO(i.TBL_DANHMUCNGUOIDUNG.macn.Split(',').ToList(), tungay1, denngay1, i.TBL_DANHMUCNGUOIDUNG, new List<string> { "OTC" }), doanhsoetc = DATABAOCAODOANHSO(i.TBL_DANHMUCNGUOIDUNG.macn.Split(',').ToList(), tungay1, denngay1, i.TBL_DANHMUCNGUOIDUNG, new List<string> { "ETC" }), taikhoan = i.taikhoan, hovaten = i.TBL_DANHMUCNGUOIDUNG.hoten, chinhanh = i.macn, sodonhang = DATAGETQLDHCOUNT(i.macn, i.taikhoan, tungay1, denngay1), solantham = db2.DTA_CONGTACTRINHDUOC.Where(n => n.matdv == i.taikhoan && n.ngay >= tungay1 && n.ngay <= denngay1 && n.checkin == true).Count(), songaybaocao = (ngaybc.Count() == 0) ? 0 : ngaybc.GroupBy(n => n.ngay).Count() });
                }
                data.data = list;
                return View("/Views/Baocao/Baocaotonghop.cshtml", data);
            }
            else if (baocao == 3)
            {
                var infocrm = GetCRM();
                DateTime tungay1 = (loaibaocao == 1) ? DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact(thang, "MM/yyyy", CultureInfo.InvariantCulture);
                DateTime denngay1 = (loaibaocao == 1) ? DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture) : tungay1.AddMonths(1).AddDays(-1);
                List<Tuple<int, string, string>> allDates = new List<Tuple<int, string, string>>();
                for (DateTime date = tungay1; date <= denngay1; date = date.AddDays(1))
                    allDates.Add(new Tuple<int, string, string>(date.Day, date.DayOfWeek.ToString(), date.ToString("dd/MM/yyyy")));
                ViewBag.alldate = allDates;
                var data = new LISTBAOCAOTONGHOPTUNGNGAYCRM { tungay = tungay1, denngay = denngay1, songaylamviec = allDates.Where(n => n.Item2 != "Sunday").Count() };
                var listtdv = (infocrm.quyen != "QUANLY") ? infocrm.matdv.Split(',').ToList() : null;
                var taikhoan = (infocrm.quyen == "QUANLY") ? db2.TBL_PHANQUYENCRM.Where(n => chinhanh.Contains(n.macn) && n.quyen == "TDV").ToList() : db2.TBL_PHANQUYENCRM.Where(n => listtdv.Contains(n.matdv)).ToList();
                var chitiet = taikhoan.Select(cl => new BAOCAOTONGHOPTUNGNGAYCRM { taikhoan = cl.taikhoan, hovaten = cl.TBL_DANHMUCNGUOIDUNG.hoten, chinhanh = cl.macn }).ToList();
                foreach (var i in chitiet)
                {
                    i.chitietngay = db2.DTA_CONGTACTRINHDUOC.Where(n => chinhanh.Contains(n.macn) && n.ngay >= tungay1 && n.ngay <= denngay1 && n.matdv == i.taikhoan).GroupBy(n => n.ngay).Select(cl => new BAOCAOTUNGNGAYTDV { ngay = cl.Key.Day, ngaythang = cl.Key, kehoach = cl.Count(), dabaocao = cl.Where(c => c.khoa == true).Count(), donhang = cl.Where(c => c.ketqua == 2 && c.checkin == true).Count(), ghetham = cl.Where(c => c.ketqua == 1 && c.checkin == true).Count(), huy = cl.Where(c => c.ketqua == null && c.ghichu != null && c.checkin == false).Count() }).ToList();
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
        public ActionResult GetKhachHang(string makh, string macn)
        {
            if (macn == null)
            {
                var Infocrm = GetCRM();
                return Json(DATAGETKHACHHANGVIEW(Infocrm.macn, makh));
            }
            else
            {
                return Json(DATAGETKHACHHANGVIEW(macn, makh));
            }
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

            if (Infocrm.matdv != null)
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
        public ActionResult Addkehoach(List<DTA_CONGTACTRINHDUOC> data1)
        {
            var Info = GetInfo();
            var Infocrm = GetCRM();
            var MATDV = Infocrm.taikhoan;
            var MACH = Infocrm.macn;
            foreach (var i in data1)
            {
                i.macn = MACH;
                i.matdv = MATDV;
                if (i.makh == null)
                {
                    i.makh = "";
                }
            }
            DATADELKEHOACH(MACH, MATDV, data1.First().ngay);
            if (data1 != null)
            {
                db2.DTA_CONGTACTRINHDUOC.AddRange(data1);
            }
            db2.SaveChanges();
            return Json(data1.First().ngay.ToString("dd/MM/yyyy"));
        }
        [HttpPost]
        public ActionResult EditKhachHang(string makh, string dt, string ngaysinh)
        {
            var Infocrm = GetCRM();
            UPDATETHONGTINKHACHHANG(Infocrm.macn, makh, dt, ngaysinh);
            return Json(1);
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
        public List<DTA_CONGTACTRINHDUOC> DATAGETKEHOACHALL(string x, string MATDV, DateTime tungay, DateTime denngay)
        {
            return db2.DTA_CONGTACTRINHDUOC.Where(n => n.macn == x && n.matdv == MATDV && n.ngay >= tungay && n.ngay <= denngay).ToList();
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

        public List<BCKEHOACHCHITIET> DATAGETKEHOACHHETHONG(string x, string MATDV, string MATK, DateTime tungay, DateTime denngay, DateTime denngay1)
        {
            var DATAX = new List<BCKEHOACHCHITIET>();
            var listtdv = MATDV.Split(',').ToList();
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                var enti = queryCN.SingleOrDefault(n => n.macn == x).data;
                var data = enti.DTA_DONDATHANG.Where(n => n.NgayDat >= tungay && n.NgayDat < denngay && n.USERTAO == MATK && n.DUYETDH == true).GroupBy(n => new { n.MAKH, n.NgayDat.Day }).Select(cl => new BCKEHOACHCHITIET { makh = cl.Key.MAKH, ngay = cl.Key.Day, loai = 6 });
                DATAX = data.ToList();
            }
            return DATAX.ToList();
        }
        public KhachHangFull DATAGETKHACHHANGVIEW(string x, string makh)
        {
            var DATAX = new KhachHangFull();
            string str = "SELECT makh AS MAKH, donvi AS DONVI , tennguoigd AS TENNGUOILH , dt AS DT , diachi AS DIACHI, FORMAT(ngaygdgannhat, 'dd/MM/yyyy ') AS DONHANGGANHAT , FORMAT(ngaysinh, 'dd/MM/yyyy ') AS NGAYSINH , masothue as MST from TBL_DANHMUCKHACHHANG where makh='" + makh + "'";
            string strch = "SELECT MaKH AS MAKH, DonVi AS DONVI, DiaChi AS DIACHI, ngaygdgannhat AS DONHANGGANHAT , TENNGUOIGD AS TENNGUOILH, dt AS DT from DM_KHACHHANG_PTTT where MaKH='" + makh + "'";
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                var enti = queryCN.SingleOrDefault(n => n.macn == x).data;
                var data3 = enti.Database.SqlQuery<KhachHangFull>(str);
                if (data3.Count() == 0)
                {
                    DATAX = db2.TBL_DANHMUCKHACHHANGPHANPHOI.Where(n => n.makh == makh).Select(cl => new KhachHangFull { DIACHI = cl.diachi, DONVI = cl.donvi, DT = cl.dt, MAKH = cl.makh, NGAYSINH = (cl.ngaysinh != null) ? ((DateTime)(cl.ngaysinh)).ToString("dd/MM/yyyy") : "N/A", TENNGUOILH = cl.tennguoilh }).FirstOrDefault();
                }
                else
                {
                    DATAX = data3.First();
                }
            }
            return DATAX;
        }
        public void UPDATETHONGTINKHACHHANG(string x, string makh, string dt, string ngaysinh)
        {
            DateTime ngaysinh1 = DateTime.ParseExact(ngaysinh, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string str = "UPDATE TBL_DANHMUCKHACHHANG SET dt = '" + dt + "', ngaysinh = '" + ngaysinh1.ToString("yyyy/MM/dd") + "' WHERE makh = '" + makh + "'";
            //string strch = "SELECT MaKH AS MAKH, DonVi AS DONVI, DiaChi AS DIACHI, ngaygdgannhat AS DONHANGGANHAT , TENNGUOIGD AS TENNGUOILH, dt AS DT from DM_KHACHHANG_PTTT where MaKH='" + makh + "'";

            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                var enti = queryCN.SingleOrDefault(n => n.macn == x).data;
                enti.Database.ExecuteSqlCommand(str);
            }
        }

        public TBL_DANHMUCNGUOIDUNG GetInfo()
        {
            TBL_DANHMUCNGUOIDUNG abc = new TBL_DANHMUCNGUOIDUNG();
            abc = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name.ToString());
            return abc;
        }
        public List<DULIEUBAOCAO0> DATABAOCAO0(List<string> soso, DateTime tungay, DateTime denngay, TBL_DANHMUCNGUOIDUNG Info)
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
            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    var enti = queryCN.SingleOrDefault(n => n.macn == x).data;
                    DATAX.AddRange(BAOCAOCHINHANH0(enti, strcn));
                }
            }
            return DATAX;
        }
        public decimal? DATABAOCAODOANHSO(List<string> soso, DateTime tungay, DateTime denngay, TBL_DANHMUCNGUOIDUNG Info, List<string> phanloai)
        {
            try
            {
                List<string> nhomhang = new List<string>(new string[] { "50", "51", "60", "61", "62", "63", "70" });
                string strcn = "seleCT HOADON.MaPL, sum(  ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)) as TONGTIEN_CT_HOADON   ,  sum( round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*cast(TYLECK as money) /100,0)) as TIENCK ,TBL_MIEN.MIEN as chuky1 ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC from TBL_MIEN, TBL_DANHMUCTIEUDEBAOCAO, DTA_CT_HOADON_XUAT CT LEFT JOIN   TBL_DANHMUCHANGHOA ON CT.mahh = TBL_DANHMUCHANGHOA.mahh, DTA_HOADON_XUAT HOADON   LEFT JOIN   TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MaPL IN ('BAN','XK') AND HOADON.MACH = CT.MACH AND CT.KT = 1";
                string strch = "seleCT HOADON.MaPL, sum(  ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)) as TONGTIEN_CT_HOADON   ,  sum( round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*cast(TYLECK as money) /100,0)) as TIENCK ,TBL_MIEN.MIEN as chuky1 ,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC from TBL_MIEN,tieude TBL_DANHMUCTIEUDEBAOCAO, CT_HOADON_XUAT CT  LEFT JOIN  DM_HANGHOA ON CT.mahh = DM_HANGHOA.mahh, HOADON_XUAT  HOADON LEFT JOIN DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.MaPL IN ('BAN','XK') AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1 ";
                string strnew = "select SUM(ISNULL(CAST(TIENCHIETKHAU   AS MONEY ),0)) AS TIENCK,substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) AS MaPL,SUM(ISNULL(CAST(TIENBAN   AS MONEY), 0)) AS TONGTIEN_CT_HOADON,TBL_DANHMUCTIEUDEBAOCAO.TENDVBC, TBL_MIEN.MIEN AS chuky1 from dtasoluong, dtaDinhKhoan, dclChiTietHangHoa, dclChiTietKhachHang, dclDanhSachDonViTinh, tbl_danhmuctieudebaocao, tbl_mien, KT_TH.DBO.TBL_DANHMUCKHACHHANG right join TBL_DANHMUCCUAHANG on KT_TH.DBO.TBL_DANHMUCKHACHHANG.MACH = TBL_DANHMUCCUAHANG.MaCH right join dtaChungTu ON KT_TH.DBO.TBL_DANHMUCKHACHHANG.makh = CAST(dtaChungTu.KhachHangID as varchar) where dtasoluong.dinhkhoanid = dtaDinhKhoan.CapDKID And dclChiTietKhachHang.TaiKhoanID = dtaChungTu.KHACHHANGID And dtaDinhKhoan.chungtuid = dtaChungTu.chungtuid and dtaDinhKhoan.IDTaiKhoanCo = dclChiTietHangHoa.TaiKhoanID and dclDanhSachDonViTinh.DonViTinhID = dclChiTietHangHoa.DonViTinhID  AND substring(dtaDinhKhoan.TaiKhoanNo, 1, 3) = '632' AND dtaChungTu.ngaychungtu between '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "'";

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
                foreach (var x in soso)
                {
                    if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                    {
                        var enti = queryCN.SingleOrDefault(n => n.macn == x).data;
                        DATAX.AddRange(BAOCAOCHINHANH0(enti, strcn));
                    }

                }
                return DATAX.Sum(cl => cl.TONGTIEN_CT_HOADON);
            }
            catch (Exception)
            {
                return null;
            }
            //var Info = GetInfo();
            //String CN

        }
        public int DATAGETQLDHCOUNT(string x, string taikhoan, DateTime tungay, DateTime denngay)
        {
            int DATAX = 0;
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                var enti = queryCN.SingleOrDefault(n => n.macn == x).data;
                DATAX = enti.DTA_DONDATHANG.Where(n => n.USERTAO == taikhoan && n.NgayDat >= tungay && n.NgayDat <= denngay).Count();
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