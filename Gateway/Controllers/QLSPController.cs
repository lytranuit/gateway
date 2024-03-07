using ApplicationChart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationChart.Controllers
{
    [Authorize(Roles = "QLHH1,QLHH2")]
    public class QLSPController : MyBaseController
    {
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();
        Entities PhuYen = new Entities("KTEntities");
        KT_THEntities1 DATATH1 = new KT_THEntities1("KT_THEntities1");
        KT_THEntities1 DATATH2 = new KT_THEntities1("KT_THEntities2");

        public TBL_DANHMUCNGUOIDUNG GetInfo()
        {
            TBL_DANHMUCNGUOIDUNG abc = new TBL_DANHMUCNGUOIDUNG();
            abc = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name.ToString());
            return abc;
        }
        // GET: QLSP
        [ActionName("quan-ly-san-pham")]
     
        public ActionResult Quanlysanpham()
        {
            var Info = GetInfo();
            ViewBag.quyen = Info.quyen;
            ViewBag.ten = Info.hoten;
            var taphop = new string[] { "50", "51", "60", "61", "62", "63" ,"64", "64.PME", "64.STA", "70" };
            ViewBag.datahanghoa = PhuYen.Database.SqlQuery<ListQLHH>("SELECT MAHH,TENHH,nhom AS NHOM,DVT,SDK FROM TBL_DANHMUCHANGHOA WHERE MAHH IS NOT NULL").Where(n => taphop.Contains(n.NHOM)).ToList();
            ViewBag.datatable = db2.TBL_DANHMUCSODANGKY.OrderBy(n => n.MAHH).ToList();
            return View("Quanlysanpham");
        }
        [HttpPost]
        [ActionName("quan-ly-san-pham")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "QLHH1")]
        public ActionResult Quanlysanpham(string MAHH, string TENHH, string SOLO, string SODK, string DVT, string HANDUNG)
        {
            var Info = GetInfo();
            ViewBag.quyen = Info.quyen;
            ViewBag.ten = Info.hoten;
            if (db2.TBL_DANHMUCSODANGKY.Any(n => n.MAHH == MAHH && n.SODK == SODK && n.SOLO == SOLO))
            {
                ViewBag.msg = "Hàng hóa bạn nhập đã tồn tại";
            }
            else
            {
                try
                {
                    TBL_DANHMUCSODANGKY data = new TBL_DANHMUCSODANGKY { DVT = DVT, MAHH = MAHH, SODK = SODK, SOLO = SOLO, TENHH = TENHH, NGUOITAO = Info.nguoidung, HANDUNG = HANDUNG };
                    db2.TBL_DANHMUCSODANGKY.Add(data);
                    db2.SaveChanges();
                    DONGBOTHEMSODANGKY(data);
                    ViewBag.msg1 = "Thêm thành công";
                }
                catch (Exception)
                {
                    ViewBag.msg = "Thông tin bạn nhập không hợp lệ";
                }
            }
            var taphop = new string[] { "50", "51", "60", "61", "62", "63", "70" };
            ViewBag.datahanghoa = PhuYen.Database.SqlQuery<ListQLHH>("SELECT MAHH,TENHH,nhom AS NHOM,DVT FROM TBL_DANHMUCHANGHOA WHERE MAHH IS NOT NULL").Where(n => taphop.Contains(n.NHOM)).ToList();
            return View("Quanlysanpham");
        }
     
        public ActionResult PartialQLHH()
        {
            return PartialView(db2.TBL_DANHMUCSODANGKY.OrderBy(n => n.MAHH).ToList());
        }
        [Authorize(Roles = "QLHH1")]
        [HttpPost]
        public ActionResult DelQLHH(string MAHH, string SOLO, string SODK)
        {
            var Info = GetInfo();
            var tv = db2.TBL_DANHMUCSODANGKY.SingleOrDefault(n => n.MAHH == MAHH && n.SODK == SODK && n.SOLO == SOLO);
            if (tv != null)
            {
                var audit = new TBL_DANHMUCSODANGKY_AUDIT { DVT = tv.DVT, LOAI = "DELETE", MAHH = tv.MAHH, NGAY = DateTime.Now, NGUOISUA = Info.nguoidung, NGUOITAO = tv.NGUOITAO, SODK = tv.SODK, SOLO = tv.SOLO, TENHH = tv.TENHH, HANDUNG = tv.HANDUNG };
                db2.TBL_DANHMUCSODANGKY_AUDIT.Add(audit);
                db2.TBL_DANHMUCSODANGKY.Remove(tv);
                db2.SaveChanges();
                DONGBOXOASODANGKY(tv);
            }
            else
            {
                return Json(1);
            }
            return Json(0);
        }
        [Authorize(Roles = "QLHH1")]
        public Tuple<string, string> DELETEQLHH(string MAHH, string SOLO, string SODK)
        {
            var tv1 = db2.TBL_DANHMUCSODANGKY.SingleOrDefault(n => n.MAHH == MAHH && n.SODK == SODK && n.SOLO == SOLO);
            var NGUOITAO = tv1.NGUOITAO;
            var HANDUNG = tv1.HANDUNG;
            db2.TBL_DANHMUCSODANGKY.Remove(tv1);
            db2.SaveChanges();
            DONGBOXOASODANGKY(tv1);
            Tuple<string, string> data = new Tuple<string, string>(NGUOITAO, HANDUNG);
            return data;
        }
        [Authorize(Roles = "QLHH1")]
        [HttpPost]
        public ActionResult EditQLHH(string MAHH, string SOLO, string SODK, string TENHH, string DVT, string HANDUNG, string SOLOOLD, string SODKOLD)
        {
            var Info = GetInfo();
            var datatuple = DELETEQLHH(MAHH, SOLOOLD, SODKOLD);

            var tv = db2.TBL_DANHMUCSODANGKY.SingleOrDefault(n => n.MAHH == MAHH && n.SODK == SODK && n.SOLO == SOLO);
            if (tv != null)
            {
                TBL_DANHMUCSODANGKY data = new TBL_DANHMUCSODANGKY { DVT = DVT, MAHH = MAHH, SODK = SODKOLD, SOLO = SOLOOLD, TENHH = TENHH, NGUOITAO = datatuple.Item1, HANDUNG = datatuple.Item2 };
                db2.TBL_DANHMUCSODANGKY.Add(data);
                db2.SaveChanges();
                DONGBOTHEMSODANGKY(data);
                return Json(1);
            }
            else
            {
                try
                {
                    TBL_DANHMUCSODANGKY data = new TBL_DANHMUCSODANGKY { DVT = DVT, MAHH = MAHH, SODK = SODK, SOLO = SOLO, TENHH = TENHH, NGUOITAO = Info.nguoidung, HANDUNG = HANDUNG };
                    db2.TBL_DANHMUCSODANGKY.Add(data);
                    var audit = new TBL_DANHMUCSODANGKY_AUDIT { DVT = DVT, LOAI = "UPDATEOLD", MAHH = MAHH, NGAY = DateTime.Now, NGUOISUA = Info.nguoidung, NGUOITAO = datatuple.Item1, SODK = SODKOLD, SOLO = SOLOOLD, TENHH = TENHH, HANDUNG = datatuple.Item2 };
                    var audit1 = new TBL_DANHMUCSODANGKY_AUDIT { DVT = DVT, LOAI = "UPDATENEW", MAHH = MAHH, NGAY = DateTime.Now, NGUOISUA = Info.nguoidung, NGUOITAO = datatuple.Item1, SODK = SODK, SOLO = SOLO, TENHH = TENHH, HANDUNG = HANDUNG };
                    db2.TBL_DANHMUCSODANGKY_AUDIT.Add(audit);
                    db2.TBL_DANHMUCSODANGKY_AUDIT.Add(audit1);
                    db2.SaveChanges();
                    DONGBOTHEMSODANGKY(data);
                    return Json(0);
                }
                catch (Exception)
                {
                    return Json(2);
                }
            }

        }
        private void DONGBOTHEMSODANGKY(TBL_DANHMUCSODANGKY data)
        {
            try
            {
                DATATH1.TBL_DANHMUCSODANGKY.Add(data);
                DATATH1.SaveChanges();
            }
            catch (Exception)
            {

            }
            try
            {
                DATATH2.TBL_DANHMUCSODANGKY.Add(data);
                DATATH2.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
        private void DONGBOXOASODANGKY(TBL_DANHMUCSODANGKY data)
        {
            try
            {
                DATATH1.TBL_DANHMUCSODANGKY.Attach(data);
                DATATH1.TBL_DANHMUCSODANGKY.Remove(data);
                DATATH1.SaveChanges();

            }
            catch (Exception)
            {

            }
            try
            {
                DATATH2.TBL_DANHMUCSODANGKY.Attach(data);
                DATATH2.TBL_DANHMUCSODANGKY.Remove(data);
                DATATH2.SaveChanges();
            }
            catch (Exception)
            {

            }

        }
    }
}