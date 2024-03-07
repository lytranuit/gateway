using ApplicationChart.Models;
using Microsoft.Security.Application;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace ApplicationChart.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {
        //MAY1
        Entities TayNinh = new Entities("KT_TNEntities");
        Entities HaNoi = new Entities("KT_HNEntities");
        Entities ThaiBinh = new Entities("KT_TBEntities");
        CHQ10Entities1 CHQ10 = new CHQ10Entities1("CHQ10Entities");
        Entities CH163 = new Entities("CH163Entities");
        CHQ10Entities1 CH245 = new CHQ10Entities1("CH245Entities");
        Entities BinhDinh = new Entities("KT_BDEntities");
        Entities CanTho = new Entities("KT_CTEntities");
        Entities DongNai = new Entities("KT_DNEntities");
        Entities BinhDuong = new Entities("KT_BDGEntities");
        Entities DaNang = new Entities("KT_DNAEntities");
        Entities HoChiMinh = new Entities("KT_HCMEntities");
        Entities NgheAn = new Entities("KT_NAEntities");
        Entities PhuTho = new Entities("KT_PTEntities");
        //MAY1
        //MAY2
        Entities QuangNgai = new Entities("KT_QNEntities");
        CHQ10Entities1 CH178 = new CHQ10Entities1("CH178Entities");
        Entities PhuYen = new Entities("KTEntities");
        Entities AnGiang = new Entities("KT_AGEntities");
        Entities CaMau = new Entities("KT_CMEntities");
        Entities GiaLai = new Entities("KT_GLEntities");
        Entities Hue = new Entities("KT_HUEEntities");
        Entities LamDong = new Entities("KT_LDEntities");
        Entities NhaTrang = new Entities("KT_NTEntities");
        Entities TienGiang = new Entities("KT_TGEntities");
        Entities VinhLong = new Entities("KT_VLEntities");
        //
        //MAY DESKTOP
        CHQ10Entities1 PTTT = new CHQ10Entities1("PTTTEntities");
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();
        KT_THEntities1 db = new KT_THEntities1("KT_THEntities1");
        // GET: Admin

        public TBL_DANHMUCNGUOIDUNG GetInfo()
        {
            TBL_DANHMUCNGUOIDUNG abc = new TBL_DANHMUCNGUOIDUNG();
            abc = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name.ToString());
            return abc;
        }
        [ActionName("tong-quan")]
        public ActionResult Index()
        {
            JsonSerializerSettings jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
            var Info = GetInfo();
            ViewBag.ten = Info.hoten;
            if (!(db2.TBL_DANHMUCNGUOIDUNG.Any(n => n.nguoidung == User.Identity.Name)))
            {
                return RedirectToAction("dang-xuat","Home");
            }
            ViewBag.sochinhanh = db2.TBL_DANHSACHCHINHANH.Count();
            ViewBag.truycap = db2.TBL_DANHMUCNGUOIDUNG.Sum(n => n.truycap);
            ViewBag.nguoidung = db2.TBL_DANHMUCNGUOIDUNG.Count();
            ViewBag.songuoionline = (int)HttpContext.Application["UserCount"];
            //Chart
            List<DataPoint> dataPoints = new List<DataPoint>();
            List<DataPoint> dataPoints1 = new List<DataPoint>();
            List<DataPoint> dataPoints2 = new List<DataPoint>();
            var date30 = DateTime.Now.AddMonths(-1);
            var data = db2.TBL_QUANLYDANGNHAP.Where(n=>n.Ngay >= date30).GroupBy(n=>new {n.Ngay.Day , n.Ngay.Month , n.Ngay.Year}).Select(cl => new { count = cl.Count() , ngay = cl.FirstOrDefault().Ngay}).ToList();
            var data1 = db2.TBL_QUANLYDANGNHAP.Where(n=>n.systemversion != "" && n.systemversion != null).GroupBy(n =>n.systemversion).Select(cl => new { count = cl.Count(), hdh = cl.Key }).ToList();
            foreach (var i in data.OrderBy(x => x.ngay))
            {
                dataPoints.Add(new DataPoint((double)i.count,i.ngay.ToString("dd.MM")));
            }
            foreach (var i in data1.OrderByDescending(x => x.count))
            {
                dataPoints1.Add(new DataPoint((double)i.count, i.hdh));
            }
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints, jsonSetting);
            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1, jsonSetting);
            //
            return View("Index");
        }
        public string datetimetostring(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }
        [ActionName("quan-ly-thay-doi-tai-khoan")]
        public ActionResult QuanlyChinhsach()
        {
            var Info = GetInfo();
            ViewBag.ten = Info.hoten;
            ViewBag.ngaydoimk = db2.TBL_NGAYDOIMATKHAU.FirstOrDefault().Ngay;
            ViewBag.ngaykhoatk = db2.TBL_NGAYKHOATK.FirstOrDefault().Ngay;
            ViewBag.android = db2.TBL_APPVERSION.SingleOrDefault(n=>n.type == "Android").version;
            ViewBag.ios = db2.TBL_APPVERSION.SingleOrDefault(n => n.type == "IOS").version;
            ViewBag.baotri = db2.TBL_BAOTRIAPP.FirstOrDefault().baotri;
            ViewBag.messbaotri = db2.TBL_BAOTRIAPP.FirstOrDefault().message;
            ViewBag.list = db2.TBL_DANHMUCNGUOIDUNG.OrderBy(n => n.nguoidung).OrderByDescending(n=>n.ngaydoimk);
            return View("QuanlyChinhsach");
        }

        [ActionName("quan-ly-crm")]
        public ActionResult QuanlyCRM()
        {
            var Info = GetInfo();
            ViewBag.ten = Info.hoten;
            ViewBag.data = db2.TBL_PHANQUYENCRM.OrderBy(n => n.macn).ToList();
            return View("QuanlyCRM");
        }
        [ActionName("quan-ly-thay-doi-tai-khoan")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult QuanlyChinhsach(int ngaykhoa,int ngaydoi,string android,string ios,int baotri,string messbaotri)
        {
            var Info = GetInfo();
            ViewBag.ten = Info.hoten;
            TBL_NGAYDOIMATKHAU tv = db2.TBL_NGAYDOIMATKHAU.FirstOrDefault();
            tv.Ngay = ngaydoi;
            TBL_NGAYKHOATK tv1 = db2.TBL_NGAYKHOATK.FirstOrDefault();
            tv1.Ngay = ngaykhoa;
          
            db2.TBL_APPVERSION.SingleOrDefault(n => n.type == "Android").version = android;
            db2.TBL_APPVERSION.SingleOrDefault(n => n.type == "IOS").version = ios;
            db2.TBL_BAOTRIAPP.FirstOrDefault().baotri = (baotri == 1)?true:false;
            db2.TBL_BAOTRIAPP.FirstOrDefault().message = messbaotri;
            db2.SaveChanges();
            ViewBag.ngaydoimk = db2.TBL_NGAYDOIMATKHAU.FirstOrDefault().Ngay;
            ViewBag.ngaykhoatk = db2.TBL_NGAYKHOATK.FirstOrDefault().Ngay;
            ViewBag.android = db2.TBL_APPVERSION.SingleOrDefault(n => n.type == "Android").version;
            ViewBag.ios = db2.TBL_APPVERSION.SingleOrDefault(n => n.type == "IOS").version;
            ViewBag.baotri = db2.TBL_BAOTRIAPP.FirstOrDefault().baotri;
            ViewBag.messbaotri = db2.TBL_BAOTRIAPP.FirstOrDefault().message;
            ViewBag.list = db2.TBL_DANHMUCNGUOIDUNG.OrderBy(n => n.ngaydoimk);
            return View("QuanlyChinhsach");
        }
        public List<ListNhomSP> DULIEUNHOMSP(Entities data)
        {
            var All = data.Database.SqlQuery<ListNhomSP>("SELECT MAHH,TENHH,nhom AS NHOM FROM TBL_DANHMUCHANGHOA WHERE MAHH IS NOT NULL").ToList();
            return All;
        }
        [ActionName("quan-ly-tai-khoan")]
        public ActionResult Quanly()
        {
            var Info = GetInfo();
            ViewBag.ten = Info.hoten;
            List<ListNhomSP> data = new List<ListNhomSP>();
            data = DULIEUNHOMSP(PhuYen).ToList();
            var taphop = new string[] { "50", "51", "60", "61", "62", "63", "70" };
            data = data.Where(n => taphop.Contains(n.NHOM)).ToList();
            data = data.GroupBy(n => n.MaHH).Select(cl => new ListNhomSP { MaHH = cl.First().MaHH, NHOM = cl.First().NHOM, TenHH = cl.First().TenHH}).ToList();
            ViewBag.donvi = db2.TBL_DANHSACHCHINHANH.OrderBy(n => n.Tencn).ToList();
            ViewBag.tinh = db.TBL_DANHMUCTINH.OrderBy(n => n.matinh).ToList();
            ViewBag.sanpham = data.OrderBy(n => n.MaHH);
            ViewBag.data = db2.TBL_DANHMUCNGUOIDUNG.OrderBy(n => n.hoten).Where(n=>n.quyen != "ADMIN");
            return View("Quanly");
        }
        [ActionName("quan-ly-tai-khoan")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Quanly(string hoten, string taikhoan, string password, string quyen, string phanloai, string read, string pdf, string word, string excel, List<string> Checkboxlist1, List<string> Checkboxlist5, List<string> Checkboxlist6, List<string> Checkboxlist8, List<string> Checkboxlist9, string chinhanhtdv, string trinhduocvien , string quan, string chinhanhquan, string dathang)
        {
            var Info = GetInfo();
            ViewBag.ten = Info.hoten;
            var pass = EncodePassword(password);
            if (trinhduocvien == null && quan == null)
            {
                try
                {
                    TBL_DANHMUCNGUOIDUNG tv = new TBL_DANHMUCNGUOIDUNG();
                    tv.hoten = Sanitizer.GetSafeHtmlFragment(hoten);
                    tv.matkhau = Sanitizer.GetSafeHtmlFragment(pass);
                    tv.nguoidung = Sanitizer.GetSafeHtmlFragment(taikhoan);
                    tv.quyen = quyen;
                    tv.phanloai = phanloai;
                    tv.READ_ONLY = Convert.ToBoolean(Convert.ToInt16(read));
                    tv.PDF = Convert.ToBoolean(Convert.ToInt16(pdf));
                    tv.WORD = Convert.ToBoolean(Convert.ToInt16(word));
                    tv.EXCEL = Convert.ToBoolean(Convert.ToInt16(excel));
                    tv.macn = string.Join(",", Checkboxlist1.ToArray());
                    tv.ngaydoimk = DateTime.Now;
                    tv.ngaydangnhap = DateTime.Now;
                    //tv.dathang = Convert.ToBoolean(Convert.ToInt16(dathang));
                    tv.dathang = null;
                    if (Checkboxlist5 == null)
                    {
                        tv.mahh = "ALL";
                    }
                    else
                    {
                        tv.mahh = string.Join(",", Checkboxlist5.ToArray());
                    }
                    if (Checkboxlist6 == null)
                    {
                        tv.matinh = "ALL";
                    }
                    else
                    {
                        tv.matinh = string.Join(",", Checkboxlist6.ToArray());
                    }
                    tv.matdv = "ALL";
                    tv.maquan = "ALL";
                    tv.truycap = 0;
                    tv.khoatk = false;
                    db2.TBL_DANHMUCNGUOIDUNG.Add(tv);
                    db2.SaveChanges();
                }
                catch (Exception)
                {
                    ViewBag.msg = 1;
                }
            }
            else
            {
                try
                {
                    TBL_DANHMUCNGUOIDUNG tv = new TBL_DANHMUCNGUOIDUNG();
                    tv.hoten = Sanitizer.GetSafeHtmlFragment(hoten);
                    tv.matkhau = Sanitizer.GetSafeHtmlFragment(pass);
                    tv.nguoidung = Sanitizer.GetSafeHtmlFragment(taikhoan);
                    tv.quyen = quyen;
                    tv.phanloai = phanloai;
                    tv.READ_ONLY = Convert.ToBoolean(Convert.ToInt16(read));
                    tv.PDF = Convert.ToBoolean(Convert.ToInt16(pdf));
                    tv.WORD = Convert.ToBoolean(Convert.ToInt16(word));
                    tv.EXCEL = Convert.ToBoolean(Convert.ToInt16(excel)); ;
                    tv.macn = chinhanhtdv;
                    tv.ngaydoimk = DateTime.Now;
                    tv.ngaydangnhap = DateTime.Now;
                    //tv.dathang = Convert.ToBoolean(Convert.ToInt16(dathang));
                    tv.dathang = null;
                    if (Checkboxlist5 == null)
                    {
                        tv.mahh = "ALL";
                    }
                    else
                    {
                        tv.mahh = string.Join(",", Checkboxlist5.ToArray());
                    }
                    if (Checkboxlist6 == null)
                    {
                        tv.matinh = "ALL";
                    }
                    else
                    {
                        tv.matinh = string.Join(",", Checkboxlist6.ToArray());
                    }
                    if (Checkboxlist8 == null)
                    {
                        tv.matdv = "ALL";
                    }
                    else
                    {
                        tv.macn = chinhanhtdv;
                        tv.matdv = string.Join(",", Checkboxlist8.ToArray());
                    }
                    if (Checkboxlist9 == null)
                    {
                        tv.maquan = "ALL";
                    }
                    else
                    {
                        tv.macn = chinhanhquan;
                        tv.maquan = string.Join(",", Checkboxlist9.ToArray());
                    }
                    tv.truycap = 0;
                    tv.khoatk = false;
                    db2.TBL_DANHMUCNGUOIDUNG.Add(tv);
                    db2.SaveChanges();

                }
                catch (Exception)
                {
                    ViewBag.msg = 1;
                }
            }
            List<ListNhomSP> data = new List<ListNhomSP>();
            data = DULIEUNHOMSP(PhuYen).ToList();
            var taphop = new string[] { "50", "51", "60", "61", "62", "63", "70" };
            data = data.Where(n => taphop.Contains(n.NHOM)).ToList();
            data = data.GroupBy(n => n.MaHH).Select(cl => new ListNhomSP { MaHH = cl.First().MaHH, NHOM = cl.First().NHOM, TenHH = cl.First().TenHH }).ToList();
            var xoa = data.FirstOrDefault(n => n.MaHH == "");
            if (xoa != null) data.Remove(xoa);
            var xoa1 = data.FirstOrDefault(n => n.MaHH == ".");
            if (xoa1 != null) data.Remove(xoa1);
            var xoa2 = data.FirstOrDefault(n => n.MaHH == "..");
            if (xoa2 != null) data.Remove(xoa2);
            ViewBag.donvi = db2.TBL_DANHSACHCHINHANH.OrderBy(n => n.Tencn).ToList();
            ViewBag.tinh = db.TBL_DANHMUCTINH.OrderBy(n => n.matinh).ToList();
            ViewBag.sanpham = data.OrderBy(n => n.MaHH);
            ViewBag.data = db2.TBL_DANHMUCNGUOIDUNG.Where(n=>n.quyen != "ADMIN").OrderBy(n => n.hoten);
            return View("Quanly");
        }
    
        [ActionName("quan-ly-so-luong-truy-cap")]
        public ActionResult Count()
        {
            var Info = GetInfo();
      
            ViewBag.ten = Info.hoten;
            var data = db2.TBL_DANHMUCNGUOIDUNG.OrderByDescending(n => n.truycap).ToList();
            ViewBag.count = data;
            return View("Count");
        }
        [ActionName("quan-ly-lich-su-truy-cap")]
        public ActionResult History()
        {
            var Info = GetInfo();
           
            ViewBag.ten = Info.hoten;
            ViewBag.history = db2.TBL_QUANLYDANGNHAP.OrderByDescending(n => n.id).Take(1000);
            return View("History");
        }
        [ActionName("quan-ly-dang-nhap-that-bai")]
        public ActionResult LoginFail()
        {
            var Info = GetInfo();
           
            ViewBag.ten = Info.hoten;
            ViewBag.list = db2.TBL_DANGNHAPTHATBAI.OrderByDescending(n => n.Id);
            return View("LoginFail");
        }
      
        [HttpPost]
        public ActionResult TimKiemTH(string input)
        {
            List<ListNhomSP> data = new List<ListNhomSP>();
            data = DULIEUNHOMSP(PhuYen).ToList();
            var taphop = new string[] { "50", "51", "60", "61", "62", "63", "70" };
            data = data.Where(n => taphop.Contains(n.NHOM)).ToList();
            data = data.GroupBy(n => n.MaHH).Select(cl => new ListNhomSP { MaHH = cl.First().MaHH, NHOM = cl.First().NHOM, TenHH = cl.First().TenHH }).ToList();
            var data1 = new List<ListNhomSP>();
            var xoa = data.FirstOrDefault(n => n.MaHH == "");
            if (xoa != null) data.Remove(xoa);
            var xoa1 = data.FirstOrDefault(n => n.MaHH == ".");
            if (xoa1 != null) data.Remove(xoa1);
            var xoa2 = data.FirstOrDefault(n => n.MaHH == "..");
            if (xoa2 != null) data.Remove(xoa2);
            foreach (var i in data)
            {
                try
                {
                    if (i.TenHH.ToUpper().IndexOf(input.ToUpper()) > -1 || i.MaHH.ToUpper().IndexOf(input.ToUpper()) > -1)
                    {
                        data1.Add(i);
                    }
                }
                catch (Exception)
                {

                }
            }
            data = data1.Distinct().ToList();
            return Json(data.OrderBy(n => n.MaHH));
        }
      
        [HttpPost]
        public ActionResult TimKiemTinh(string input)
        {
            List<TBL_DANHMUCTINH> data1 = new List<TBL_DANHMUCTINH>();
            var data = db.TBL_DANHMUCTINH.OrderBy(n => n.matinh).ToList();
            foreach (var i in data)
            {
                try
                {
                    if (i.tentinh.ToUpper().IndexOf(input.ToUpper()) > -1 || i.matinh.ToUpper().IndexOf(input.ToUpper()) > -1)
                    {
                        data1.Add(i);
                    }
                }
                catch (Exception)
                {

                }
            }
            data = data1.Distinct().ToList();
            return Json(data.OrderBy(n => n.matinh));
        }
      
        [HttpPost]
        public ActionResult ActionKhoa(string taikhoan,bool khoatk)
        {
            var Info = GetInfo();
         
            ViewBag.ten = Info.hoten;
            var data =  db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == taikhoan);
            data.khoatk = khoatk;
            db2.SaveChanges();
            return Json(0);
        }
     
        public List<ListTrinhDuocVien> DULIEUTRINHDUOCVIEN(Entities data)
        {
            var All = data.Database.SqlQuery<ListTrinhDuocVien>("SELECT MaTDV AS MATDV, TenTDV AS TENTDV FROM TBL_DANHMUCTDV").ToList();
            return All;
        }
    
        public List<ListTrinhDuocVien> DULIEUCUAHANGTRINHDUOCVIEN(CHQ10Entities1 data)
        {
            var All = data.Database.SqlQuery<ListTrinhDuocVien>("SELECT MaTDV AS MATDV, TenTDV AS TENTDV FROM DS_TDV_PTTT").ToList();
            return All;
        }
      
        public List<ListTrinhDuocVien> DULIEUMIENBACTRINHDUOCVIEN(CHQ10Entities1 data)
        {
            var All = data.Database.SqlQuery<ListTrinhDuocVien>("SELECT MaTDV AS MATDV, TenTDV AS TENTDV FROM DS_TDV_PTTT").ToList();
            return All;
        }
  
        [HttpPost]
        public ActionResult TimKiemTDV(string ChiNhanhId, string input)
        {
            List<ListTrinhDuocVien> data = new List<ListTrinhDuocVien>();
            if (ChiNhanhId == "QN")
            {
                data = DULIEUTRINHDUOCVIEN(QuangNgai).ToList();
            }
            else if (ChiNhanhId == "TN")
            {
                data = DULIEUTRINHDUOCVIEN(TayNinh).ToList();
            }
            else if (ChiNhanhId == "TB")
            {
                //data = DULIEUMIENBACTRINHDUOCVIEN(ThaiBinh).ToList();
            }
            else if (ChiNhanhId == "HN")
            {
                //data = DULIEUMIENBACKHUYENMAI(HaNoi).ToList();
            }
            else if (ChiNhanhId == "CHQ10")
            {
                data = DULIEUCUAHANGTRINHDUOCVIEN(CHQ10).ToList();
            }
            else if (ChiNhanhId == "CH163")
            {
                data = DULIEUTRINHDUOCVIEN(CH163).ToList();
            }
            else if (ChiNhanhId == "CH245")
            {
                data = DULIEUCUAHANGTRINHDUOCVIEN(CH245).ToList();
            }
            else if (ChiNhanhId == "BD")
            {
                data = DULIEUTRINHDUOCVIEN(BinhDinh).ToList();
            }
            else if (ChiNhanhId == "CT")
            {
                data = DULIEUTRINHDUOCVIEN(CanTho).ToList();
            }
            else if (ChiNhanhId == "DN")
            {
                data = DULIEUTRINHDUOCVIEN(DongNai).ToList();
            }
            else if (ChiNhanhId == "DNA")
            {
                data = DULIEUTRINHDUOCVIEN(DaNang).ToList();
            }
            else if (ChiNhanhId == "HCM")
            {
                data = DULIEUTRINHDUOCVIEN(HoChiMinh).ToList();
            }
            else if (ChiNhanhId == "NA")
            {
                data = DULIEUTRINHDUOCVIEN(NgheAn).ToList();
            }
            else if (ChiNhanhId == "PT")
            {
                //data = DULIEUMIENBACKHACHHANG(PhuTho).ToList();
            }
            else if (ChiNhanhId == "CH178")
            {
                data = DULIEUCUAHANGTRINHDUOCVIEN(CH178).ToList();
            }
            else if (ChiNhanhId == "PY")
            {
                data = DULIEUTRINHDUOCVIEN(PhuYen).ToList();
            }
            else if (ChiNhanhId == "AG")
            {
                data = DULIEUTRINHDUOCVIEN(AnGiang).ToList();
            }
            else if (ChiNhanhId == "CM")
            {
                data = DULIEUTRINHDUOCVIEN(CaMau).ToList();
            }
            else if (ChiNhanhId == "GL")
            {
                data = DULIEUTRINHDUOCVIEN(GiaLai).ToList();
            }
            else if (ChiNhanhId == "HUE")
            {
                data = DULIEUTRINHDUOCVIEN(Hue).ToList();
            }
            else if (ChiNhanhId == "LD")
            {
                data = DULIEUTRINHDUOCVIEN(LamDong).ToList();
            }
            else if (ChiNhanhId == "NT")
            {
                data = DULIEUTRINHDUOCVIEN(NhaTrang).ToList();
            }
            else if (ChiNhanhId == "TG")
            {
                data = DULIEUTRINHDUOCVIEN(TienGiang).ToList();
            }
            else if (ChiNhanhId == "VL")
            {
                data = DULIEUTRINHDUOCVIEN(VinhLong).ToList();
            }
            else if (ChiNhanhId == "PTTT")
            {
                data = DULIEUCUAHANGTRINHDUOCVIEN(PTTT).ToList();
            }
            var data1 = new List<ListTrinhDuocVien>();
            var xoa = data.FirstOrDefault(n => n.MATDV == "");
            if (xoa != null) data.Remove(xoa);
            var xoa1 = data.FirstOrDefault(n => n.MATDV == ".");
            if (xoa1 != null) data.Remove(xoa1);
            var xoa2 = data.FirstOrDefault(n => n.MATDV == "..");
            if (xoa2 != null) data.Remove(xoa2);
            foreach (var i in data)
            {
                try
                {
                    if (i.MATDV.ToUpper().IndexOf(input.ToUpper()) > -1 || i.TENTDV.ToUpper().IndexOf(input.ToUpper()) > -1)
                    {
                        data1.Add(i);
                    }
                }
                catch (Exception)
                {

                }
            }
            data = data1.Distinct().ToList();
            return Json(data.OrderBy(n => n.MATDV));
        }
        public static string EncodePassword(string originalPassword)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
        }
   
        [HttpPost]
        public ActionResult DelUser(string taikhoan)
        {
            try
            {
                TBL_DANHMUCNGUOIDUNG tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == taikhoan);
                db2.TBL_PHANQUYENCRM.Remove(tv.TBL_PHANQUYENCRM);
                db2.TBL_DANHMUCNGUOIDUNG.Remove(tv);
                db2.SaveChanges();
            }
            catch (Exception)
            {

            }
            return Json(0);
        }
    
        [HttpPost]
        public ActionResult EditUser(string taikhoan, string hoten, string matkhau)
        {
            try
            {
                TBL_DANHMUCNGUOIDUNG tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == taikhoan);
                if (tv != null)
                {
                    tv.hoten = hoten;
                    if (matkhau != "")
                    {
                        tv.matkhau = EncodePassword(matkhau);
                        tv.doimk = true;
                        tv.ngaydoimk = DateTime.Now;
                    }
                    db2.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
            return Json(0);
        }
       
        [HttpPost]
        public ActionResult EditPermision(string taikhoan, string quyen, string phanloai, string read, string pdf, string word, string excel, List<string> Checkboxlist1, List<string> Checkboxlist5, List<string> Checkboxlist6, List<string> Checkboxlist8, List<string> Checkboxlist9, string chinhanhtdv, string trinhduocvien , string quan , string chinhanhquan, string editdathang)
        {
            if (trinhduocvien == null && quan == null)
            {
                try
                {
                    TBL_DANHMUCNGUOIDUNG tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == taikhoan);
                    if (tv != null)
                    {
                        tv.quyen = quyen;
                        tv.phanloai = phanloai;
                        tv.READ_ONLY = Convert.ToBoolean(Convert.ToInt16(read));
                        tv.PDF = Convert.ToBoolean(Convert.ToInt16(pdf));
                        tv.WORD = Convert.ToBoolean(Convert.ToInt16(word));
                        tv.EXCEL = Convert.ToBoolean(Convert.ToInt16(excel));
                        tv.macn = string.Join(",", Checkboxlist1.ToArray());
                        tv.dathang = Convert.ToInt16(editdathang);
                   
                        if (Checkboxlist5 == null)
                        {
                            tv.mahh = "ALL";
                        }
                        else
                        {
                            tv.mahh = string.Join(",", Checkboxlist5.ToArray());
                        }
                        if (Checkboxlist6 == null)
                        {
                            tv.matinh = "ALL";
                        }
                        else
                        {
                            tv.matinh = string.Join(",", Checkboxlist6.ToArray());
                        }
                        tv.matdv = "ALL";
                        tv.maquan = "ALL";
                        db2.SaveChanges();
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                try
                {
                    TBL_DANHMUCNGUOIDUNG tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == taikhoan);
                    if (tv != null)
                    {
                        tv.quyen = quyen;
                        tv.phanloai = phanloai;
                        tv.READ_ONLY = Convert.ToBoolean(Convert.ToInt16(read));
                        tv.PDF = Convert.ToBoolean(Convert.ToInt16(pdf));
                        tv.WORD = Convert.ToBoolean(Convert.ToInt16(word));
                        tv.EXCEL = Convert.ToBoolean(Convert.ToInt16(excel));
                        tv.dathang = Convert.ToInt16(editdathang);
                
                        if (Checkboxlist5 == null)
                        {
                            tv.mahh = "ALL";
                        }
                        else
                        {
                            tv.mahh = string.Join(",", Checkboxlist5.ToArray());
                        }
                        if (Checkboxlist6 == null)
                        {
                            tv.matinh = "ALL";
                        }
                        else
                        {
                            tv.matinh = string.Join(",", Checkboxlist6.ToArray());
                        }
                        if(Checkboxlist8 == null)
                        {
                            tv.matdv = "ALL";
                        }
                        else
                        {
                            tv.macn = chinhanhtdv;
                            tv.matdv = string.Join(",", Checkboxlist8.ToArray());
                        }
                        if (Checkboxlist9 == null)
                        {
                            tv.maquan = "ALL";
                        }
                        else
                        {
                            tv.macn = chinhanhquan;
                            tv.maquan = string.Join(",", Checkboxlist9.ToArray());
                        }
                        db2.SaveChanges();
                    }
                }
                catch (Exception)
                {
                }
            }
            return RedirectToAction("quan-ly-tai-khoan", "Admin");
        }
    }
}