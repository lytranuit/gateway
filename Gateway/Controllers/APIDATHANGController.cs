using ApplicationChart.Models;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationChart.Controllers
{
    [Authorize(Roles = "DONHANG,DONHANGKD")]
    public class APIDATHANGController : ApiController
    {
        Entities TayNinh = new Entities("KT_TNEntities");
        Entities HaNoi = new Entities("KT_HNEntities");
        Entities ThaiBinh = new Entities("KT_TBEntities");
        Entities ThaiNguyen = new Entities("KT_TNGEntities");
        Entities PhuTho = new Entities("KT_PTEntities");
        CHQ10Entities1 CHQ10 = new CHQ10Entities1("CHQ10Entities");
        Entities TT423 = new Entities("TT423Entities");
        Entities BinhDinh = new Entities("KT_BDEntities");
        Entities CanTho = new Entities("KT_CTEntities");
        Entities DongNai = new Entities("KT_DNEntities");
        Entities BinhDuong = new Entities("KT_BDGEntities");
        Entities DaNang = new Entities("KT_DNAEntities");
        Entities HoChiMinh = new Entities("KT_HCMEntities");
        Entities NgheAn = new Entities("KT_NAEntities");
        Entities NgheAn2 = new Entities("KT_NA_2Entities");
        Entities QuangTri = new Entities("KT_QTEntities");
        //MAY1
        //MAY2
        Entities QuangNgai = new Entities("KT_QNEntities");
        Entities PhuYen = new Entities("KTEntities");
        Entities SC = new Entities("KT_SCEntities");
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
        Entities Pypharm = new Entities("KT_PYPHARMEntities");
        //MAY DESKTOP
        CHQ10Entities1 PTTT = new CHQ10Entities1("PTTTEntities");
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();
        KT_THEntities1 DATATH1 = new KT_THEntities1("KT_THEntities1");
        KT_THEntities1 DATATH2 = new KT_THEntities1("KT_THEntities2");
        List<EntitiesCN> queryCN = new List<EntitiesCN> {
                 new EntitiesCN {data = new Entities("KT_PYPHARMEntities") , macn = "FP"},
        };
        List<EntitiesCH> queryCH = new List<EntitiesCH> {
            new EntitiesCH {data = new CHQ10Entities1("PTTTEntities") , macn = "PTTT"},
            new EntitiesCH {data = new CHQ10Entities1("CHQ10Entities") , macn = "CHQ10"},
            new EntitiesCH {data = new CHQ10Entities1("CHPPSPEntities") , macn = "CHPPSP"},
        };

        public IHttpActionResult Get()
        {
            var Info = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name);
            var tv = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name);
            var Data = DATATAO(tv.macn, tv.matdv);
            var THKM = DATATH1.TBL_DANHMUCKM.Where(n => n.ngayketthuc >= DateTime.Today && n.ngaybatdau <= DateTime.Today).ToList().Where(n => n.PHAMVI.Split(',').Contains(tv.macn)).Select(cl => new ListChuongTrinhKM { MACTKM = cl.MACTKM, BBTT = (cl.BBTT == true) ? 1 : 0, TICHDIEM = cl.TICHDIEM, TENCTKM = cl.TENCTKM, MAHH = cl.MAHH, HANMUC = cl.HANMUC, ck = cl.ck }).ToList();
            Data.ListCTKM = THKM.Concat(Data.ListCTKM.Where(n => !THKM.Select(cl => cl.MACTKM).ToList().Contains(n.MACTKM))).ToList();
            Data.ListCTHT = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.Where(n => n.ngayketthuc >= DateTime.Today && n.ngaybatdau <= DateTime.Today).ToList().Where(n => n.PHAMVI.Split(',').Contains(tv.macn)).Select(cl => new ListChuongTrinhHT { MACTHT = cl.MACTHT, TENCTHT = cl.TENCTHT, MAHH = cl.MAHH, TICHDIEM = cl.TICHDIEM, HANMUC = cl.HANMUC, MACTKM = cl.MACTKM }).ToList();
            if (tv.matdv != null)
            {
                Data.ListTDV = tv.matdv.Split(',').ToList();
            }
            else
            {
                Data.ListTDV = GetTrinhDuocVien(tv.macn);
            }
            if (Info.manhom != null)
            {
                var nhomhang = Info.manhom.Split(',').ToList();
                Data.ListHH = Data.ListHH.Where(n => nhomhang.Contains(n.NHOM)).ToList();
            }
            return Json(Data);
        }
        public IHttpActionResult GetDonhang()
        {
            var tv = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name);
            var Data = DATA(tv.macn, tv.matdv, DateTime.Now.AddMonths(-1), DateTime.Now.AddDays(1));
            var THKM = DATATH1.TBL_DANHMUCKM.Where(n => n.ngayketthuc >= DateTime.Today && n.ngaybatdau <= DateTime.Today).ToList().Where(n => n.PHAMVI.Split(',').Contains(tv.macn)).Select(cl => new ListChuongTrinhKM { MACTKM = cl.MACTKM, TICHDIEM = cl.TICHDIEM, TENCTKM = cl.TENCTKM, MAHH = cl.MAHH, ck = cl.ck }).ToList();
            Data.ListCTKM = THKM.Concat(Data.ListCTKM.Where(n => !THKM.Select(cl => cl.MACTKM).ToList().Contains(n.MACTKM))).ToList();
            Data.ListDDH = Data.ListDDH.OrderByDescending(n => n.MADH).Take(200).ToList();
            Data.ListCTHT = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.Where(n => n.ngayketthuc >= DateTime.Today).Select(cl => new ListChuongTrinhHT { MACTHT = cl.MACTHT, TENCTHT = cl.TENCTHT, MAHH = cl.MAHH, TICHDIEM = cl.TICHDIEM, MACTKM = cl.MACTKM }).ToList();
            return Json(Data);
        }
        [HttpPost]
        public IHttpActionResult PartialQLDH(modelqldh value)
        {
            var data = DATAGETQLDH(value.macn, value.matdv, value.tungay, value.denngay).ToList();
            return Json(data.OrderByDescending(n => n.MADH).Take(100));
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
                    DATAX = queryCH.SingleOrDefault(n => n.macn == x).data.DTA_DONDATHANG.Where(n => n.MATDV == matdv && n.NgayDat >= dt1 && n.NgayDat <= dt2).OrderByDescending(n => n.MADH).Take(1000).GroupBy(n => n.MADH).ToList().Select(cl => new DTA_DONDATHANG { NgayGiao = (DateTime?)cl.First().NgayGiao, MADH = cl.Key, DONVI = cl.First().DONVI, NgayDat = cl.First().NgayDat, DUYETDH = cl.OrderByDescending(n => n.DUYETDH).First().DUYETDH, USERTAO = cl.First().USERTAO, MACH = cl.First().MACH, MATDV = cl.First().MATDV }).ToList();
                }
            }
            return DATAX;
        }
        public IHttpActionResult GetChinhanh()
        {
            var tv = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name);

            List<string> listcn = tv.macn.Split(',').ToList();
            var data = db2.TBL_DANHSACHCHINHANH.Where(n => listcn.Contains(n.macn) && n.check == true).Select(cl => new BSCCHINHANH { MACN = cl.macn, MIEN = cl.Mien, TENCN = cl.Tencn, UUTIEN = cl.stt }).ToList();
            return Json(data);
        }
        [HttpPost]
        public IHttpActionResult gettdv(string macn)
        {
            List<ListTrinhDuocVien> data = new List<ListTrinhDuocVien>();
            if (queryCN.SingleOrDefault(n => n.macn == macn) != null)
            {
                data = DULIEUTRINHDUOCVIEN(queryCN.SingleOrDefault(n => n.macn == macn).data).ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == macn) != null)
            {
                data = DULIEUCUAHANGTRINHDUOCVIEN(queryCH.SingleOrDefault(n => n.macn == macn).data).ToList();
            }
            return Json(data);
        }
        public IHttpActionResult GetDonhang(string tungay, string denngay)
        {
            DateTime dt1 = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(tungay), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(Sanitizer.GetSafeHtmlFragment(denngay), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1);
            var tv = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name);
            var Data = DATA(tv.macn, tv.matdv, dt1, dt2);
            var THKM = DATATH1.TBL_DANHMUCKM.Where(n => n.ngayketthuc >= DateTime.Today && n.ngaybatdau <= DateTime.Today).ToList().Where(n => n.PHAMVI.Split(',').Contains(tv.macn)).Select(cl => new ListChuongTrinhKM { MACTKM = cl.MACTKM, TICHDIEM = cl.TICHDIEM, TENCTKM = cl.TENCTKM, MAHH = cl.MAHH, ck = cl.ck }).ToList();
            Data.ListCTKM = THKM.Concat(Data.ListCTKM.Where(n => !THKM.Select(cl => cl.MACTKM).ToList().Contains(n.MACTKM))).ToList();
            Data.ListDDH = Data.ListDDH.OrderByDescending(n => n.MADH).Take(200).ToList();
            Data.ListCTHT = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.Where(n => n.ngayketthuc >= DateTime.Today).Select(cl => new ListChuongTrinhHT { MACTHT = cl.MACTHT, TENCTHT = cl.TENCTHT, MAHH = cl.MAHH, TICHDIEM = cl.TICHDIEM }).ToList();
            return Json(Data);
        }
        public IHttpActionResult GetDonhang(string madh)
        {
            var tv = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name);
            var data = DATAGETDONHANG(tv.macn, madh);
            var datahh = SC.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH,CAST(kiemsoat AS INT) as kiemsoat,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3 from TBL_DANHMUCHANGHOA where mahh ='" + data.First().MAHH + "'").First();
            var tpcn = db2.TBL_DANHMUCTPCN.Select(n => n.mahh).ToList();
            if (tpcn.Contains(datahh.MAHH))
            {
                foreach (var i in data)
                {
                    i.NGUOIDUYET = "2";
                }
            }
            else
            {
                foreach (var i in data)
                {
                    i.NGUOIDUYET = datahh.kiemsoat.ToString();
                }
            }
            return Json(data.OrderByDescending(n => n.DUYETDH).ThenBy(n => n.STT));
        }
        public IHttpActionResult GetDonhangcn(string macn, string madh)
        {

            var data = DATAGETDONHANG(macn, madh);
            return Json(data.OrderByDescending(n => n.DUYETDH).ThenBy(n => n.STT));
        }
        [HttpPost]
        public IHttpActionResult GETCKBBTT(string mactkm, string makh)
        {
            var MACH = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name).macn;
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
        public List<CHECKBBTT> DATAGETBBTT(string x, string makh, string mactkm)
        {
            string strcn = "select LoaiBBTT,makh from TBL_DANHMUCBIENBANTHOATHUAN_2 where makh = '" + makh + "' and '" + mactkm + "' IN (SELECT VAL FROM FUN_CATCHUOI(loaibbtt)) and (thanhly is null or thanhly = 0)";
            var DATAX = new List<CHECKBBTT>();
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {

                DATAX = queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<CHECKBBTT>(strcn).ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
            {

                DATAX = queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<CHECKBBTT>(strcn).ToList();
            }
            return DATAX;
        }
        [HttpPost]
        public HttpResponseMessage checkbbtt([FromBody] CHECKBBTT x)
        {
            var tv = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name);
            var data = DATAGETBBTT(tv.macn, x.makh, x.LoaiBBTT);
            //if (tv.macn == "TB" || tv.macn == "TNG" || tv.macn == "PT")
            //{
            //    var myMess = new
            //    {
            //        Message = "Hợp lệ",
            //    };
            //    return Request.CreateResponse(HttpStatusCode.OK, myMess);
            //}
            //if (x.LoaiBBTT == "BBTT2021_PARTNERSHIP")
            //{
            //    var myMess = new
            //    {
            //        Message = "Hợp lệ",
            //    };
            //    return Request.CreateResponse(HttpStatusCode.OK, myMess);
            //}
            if (data.Any())
            {
                var myMess = new
                {
                    Message = "Hợp lệ",
                };
                return Request.CreateResponse(HttpStatusCode.OK, myMess);
            }
            else
            {
                var myError = new
                {
                    Message = "Không tìm thấy BBTT " + x.LoaiBBTT + " của khách hàng này trong danh mục BBTT. Vui lòng liên hệ bộ phận xuất hóa đơn để thêm vào danh mục BBTT !",
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, myError);
            }
        }
        [HttpPost]
        public IHttpActionResult Delete(string madh)
        {
            var tv = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name);
            string x = "";
            var MACH = tv.macn;
            try
            {
                var export = (DateTime)DATA_DEL(MACH, madh);
                x = export.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                return Json(1);
            }
            return Json(x);
        }
        [HttpPost]
        public IHttpActionResult Getcongno(string makh)
        {
            var Infocrm = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name);
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

        public HttpResponseMessage Post([FromBody] List<DONDATHANG> data1)
        {
            try
            {
                var Infocrm = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name);
                var Info = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name);
                List<DTA_DONDATHANG> data = new List<DTA_DONDATHANG>();
                var MACH = Infocrm.macn;
                if (MACH == "PTTT" && Infocrm.matdv != null)
                {
                    var strch = "SELECT makh AS MAKH, donvi AS DONVI ,hanmuc as HANMUC, matdv AS MATDV, matdv2 AS MATDV2, diachi AS DIACHI from DM_KHACHHANG_PTTT WHERE makh ='" + data1.First().KHACHHANG + "' ";
                    var laykhachhang = PTTT.Database.SqlQuery<ListKhachHang>(strch).ToList();
                    if (laykhachhang.FirstOrDefault() != null)
                    {
                        var Z = laykhachhang.FirstOrDefault();
                        var listmatdv = Infocrm.matdv.Split(',').ToList();
                        if (listmatdv.Count() == 1)
                        {
                            foreach (var i in data1)
                            {
                                i.MATDV = Infocrm.matdv;
                            }
                        }
                        else if (Z.MATDV != null && Z.MATDV != "")
                        {
                            if (listmatdv.Contains(Z.MATDV))
                            {
                                foreach (var i in data1)
                                {
                                    i.MATDV = Z.MATDV;
                                }
                            }
                            else
                            {
                                foreach (var i in data1)
                                {
                                    i.MATDV = Z.MATDV2;
                                }
                            }
                        }
                    }
                }
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
                //double? ck = 0;
                //if (data1.First().MACTKM != null)
                //{
                //    try
                //    {
                //        if (data1.First().MACTKM.Substring(0, 4) == "BBTT")
                //        {
                //            try
                //            {

                //                var makh = data1.First().KHACHHANG;
                //                ck = DATA_GETBBTT(MACH, data1.First().MACTKM, makh);
                //            }
                //            catch (Exception)
                //            {

                //                ck = 0;

                //            }
                //        }
                //    }
                //    catch (Exception)
                //    {

                //    }
                //}
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
                var myMess = new
                {
                    Message = "Tạo đơn hàng thành công",
                    MADH = data.First().MADH,
                };
                return Request.CreateResponse(HttpStatusCode.OK, myMess);
            }
            catch (Exception)
            {
                var myError = new
                {
                    Message = "Tạo đơn hàng không thành công",
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, myError);
                //return Json(0);
            }
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
        public int DATA_GET(string x)
        {
            int MADH = 0;
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                MADH = Int32.Parse(queryCN.SingleOrDefault(n => n.macn == x).data.DTA_DONDATHANG.OrderByDescending(n => n.MADH).FirstOrDefault().MADH) + 1;
            }
            else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
            {
                MADH = Int32.Parse(queryCH.SingleOrDefault(n => n.macn == x).data.DTA_DONDATHANG.OrderByDescending(n => n.MADH).FirstOrDefault().MADH) + 1;
            }
            return MADH;
        }
        public List<string> GetTrinhDuocVien(string ChiNhanhId)
        {
            List<ListTrinhDuocVien> data = new List<ListTrinhDuocVien>();
            if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
            {
                var enti = queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data;
                data = DULIEUTRINHDUOCVIEN(enti).ToList();
            }
            return data.Select(cl => cl.MATDV).ToList();
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
            string strcnctkm = "SELECT MACTKM AS MACTKM, TENCTKM AS TENCTKM from TBL_DANHMUCKM WHERE MaCTKM IS NOT NULL AND (ngayketthuc is null or ngayketthuc >= '" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
            string strcnhh = "SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN , quicach as QUICACH, nhom as NHOM from TBL_DANHMUCHANGHOA where nhom in ('50', '51', '60', '61', '62', '63','64','64.PME','64.STA', '70','99','40','50.STA','51.STA','60.STA','62.STA') and GIABAN != '0' and sudung = 1";
            var DATAX = new ListData();
            if (queryCN.SingleOrDefault(n => n.macn == x) != null)
            {
                var enti = queryCN.SingleOrDefault(n => n.macn == x).data;
                DATAX.ListCTKM = enti.Database.SqlQuery<ListChuongTrinhKM>(strcnctkm).ToList();
                DATAX.ListHH = enti.Database.SqlQuery<ListHangHoa>("SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN,CAST(SL1 AS INT) AS SL1 ,CAST(SL2 AS INT) AS SL2,CAST(SL3 AS INT) AS SL3,QUICACH as QUICACH, nhom as NHOM from TBL_DANHMUCHANGHOA where GIABAN != '0' and SL3 is not null").ToList();
                DATAX.ListKH = enti.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            return DATAX;
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
            string strcnhh = "SELECT MAHH AS MAHH, TENHH AS TENHH ,  DVT AS DVT ,GIABAN from TBL_DANHMUCHANGHOA where nhom in ('50', '51', '60', '61', '62', '63','64','64.PME','64.STA', '70','99','40','50.STA','51.STA','60.STA','62.STA') and GIABAN != '0' and sudung = 1";
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
                    DATAX.ListDDH = enti.DTA_DONDATHANG.Where(n => n.NgayDat >= tungay && n.NgayDat < denngay).GroupBy(n => n.MADH).ToList().Select(cl => new DTA_DONDATHANG { MADH = cl.Key, DONVI = cl.First().DONVI, NgayDat = cl.First().NgayDat, DUYETDH = cl.OrderByDescending(n => n.DUYETDH).First().DUYETDH, USERTAO = cl.First().USERTAO }).ToList();
                }
            }
            return DATAX;
        }
    }

}
