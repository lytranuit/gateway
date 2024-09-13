using ApplicationChart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationChart.Controllers
{
    [Authorize(Roles = "KETOAN")]
    public class KetoanController : MyBaseController
    {
        // GET: Ketoan
        Entities TayNinh = new Entities("KT_TNEntities");
        Entities HaNoi = new Entities("KT_HNEntities");
        Entities ThaiBinh = new Entities("KT_TBEntities");
        Entities PhuTho = new Entities("KT_PTEntities");
        Entities TNG = new Entities("KT_TNGEntities");
        CHQ10Entities1 CHQ10 = new CHQ10Entities1("CHQ10Entities");
        Entities TT423 = new Entities("TT423Entities");
        Entities BinhDinh = new Entities("KT_BDEntities");
        Entities CanTho = new Entities("KT_CTEntities");
        Entities DongNai = new Entities("KT_DNEntities");
        Entities DaNang = new Entities("KT_DNAEntities");
        Entities BinhDuong = new Entities("KT_BDGEntities");
        Entities HoChiMinh = new Entities("KT_HCMEntities");
        Entities NgheAn = new Entities("KT_NAEntities");
        Entities NgheAn2 = new Entities("KT_NA_2Entities");
        Entities QuangTri = new Entities("KT_QTEntities");
        //MAY1
        //MAY2
        Entities QuangNgai = new Entities("KT_QNEntities");
        Entities PhuYen = new Entities("KTEntities");
        Entities AnGiang = new Entities("KT_AGEntities");
        Entities CaMau = new Entities("KT_CMEntities");
        Entities GiaLai = new Entities("KT_GLEntities");
        Entities Hue = new Entities("KT_HUEEntities");
        Entities LamDong = new Entities("KT_LDEntities");
        Entities NhaTrang = new Entities("KT_NTEntities");
        Entities TienGiang = new Entities("KT_TGEntities");
        Entities VinhLong = new Entities("KT_VLEntities");
        //MAY DESKTOP
        CHQ10Entities1 PTTT = new CHQ10Entities1("PTTTEntities");
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();
        KT_THEntities1 DATATH1 = new KT_THEntities1("KT_THEntities1");
        KT_THEntities1 DATATH2 = new KT_THEntities1("KT_THEntities2");
        [ActionName("thong-ke-tai-khoan")]
        public ActionResult Thongketaikhoan()
        {
            var Info = GetInfo();
            List<TBL_DANHSACHCHINHANH> donvi = new List<TBL_DANHSACHCHINHANH>();
          
            List<string> listcn = Info.macn.Split(',').ToList();
            donvi = db2.TBL_DANHSACHCHINHANH.Where(n => listcn.Contains(n.macn) && n.check == true).ToList();
            ViewBag.donvi = donvi;
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            return View("Thongketaikhoan");
        }
        [ActionName("thong-ke-chi-tiet-tai-khoan")]
        public ActionResult Thongkechitiettaikhoan()
        {
            return View("Thongkechitiettaikhoan");
        }
        public TBL_DANHMUCNGUOIDUNG GetInfo()
        {
            TBL_DANHMUCNGUOIDUNG abc = new TBL_DANHMUCNGUOIDUNG();
            abc = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name.ToString());
            return abc;
        }
    }
}