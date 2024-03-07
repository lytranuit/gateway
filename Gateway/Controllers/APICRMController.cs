using ApplicationChart.Models;
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
    public class APICRMController : ApiController
    {
        Entities TayNinh = new Entities("KT_TNEntities");
        Entities HaNoi = new Entities("KT_HNEntities");
        Entities ThaiBinh = new Entities("KT_TBEntities");
        Entities PhuTho = new Entities("KT_PTEntities");
        Entities ThaiNguyen = new Entities("KT_TNGEntities");
        CHQ10Entities1 CHQ10 = new CHQ10Entities1("CHQ10Entities");
        Entities TT423 = new Entities("TT423Entities");
        Entities BinhDinh = new Entities("KT_BDEntities");
        Entities CanTho = new Entities("KT_CTEntities");
        Entities DongNai = new Entities("KT_DNEntities");
        Entities DaNang = new Entities("KT_DNAEntities");
        Entities HoChiMinh = new Entities("KT_HCMEntities");
        Entities NgheAn = new Entities("KT_NAEntities");
        Entities BinhDuong = new Entities("KT_BDGEntities");
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
        Entities HaiPhong = new Entities("KT_HPEntities");
        Entities LamDong = new Entities("KT_LDEntities");
        Entities NhaTrang = new Entities("KT_NTEntities");
        Entities TienGiang = new Entities("KT_TGEntities");
        Entities VinhLong = new Entities("KT_VLEntities");
        Entities Daknong = new Entities("KT_DNONGEntities");
        Entities ThanhHoa = new Entities("KT_THOEntities");
        //MAY DESKTOP
        CHQ10Entities1 PTTT = new CHQ10Entities1("PTTTEntities");
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();
        KT_THEntities1 DATATH1 = new KT_THEntities1("KT_THEntities1");
        KT_THEntities1 DATATH2 = new KT_THEntities1("KT_THEntities2");
        public IHttpActionResult GetKhachhang()
        {
            var tv = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name);
            var Data = DATAGETKH(tv.macn, tv.matdv);
            return Json(Data);
        }
        [HttpPost]
        public HttpResponseMessage PostToado([FromBody]DTA_TOADOKHACHHANG data)
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
                var myMess = new
                {
                    Message = "Thành công",
                };
                return Request.CreateResponse(HttpStatusCode.OK, myMess);
            }
            catch (Exception)
            {
                var myError = new
                {
                    Message = "Không thành công",
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, myError);
                //return Json(0);
            }
        }
        [HttpGet]
        public IHttpActionResult GetToado(string makh)
        {
            var tv = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name);
            var z = db2.DTA_TOADOKHACHHANG.SingleOrDefault(n => n.macn == tv.macn && n.makh == makh);
            return Json(z);
        }
        [HttpPost]
        public HttpResponseMessage Sosanhtoado([FromBody] Sosanhtoado o)
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
                    var z = db2.DTA_CONGTACTRINHDUOC.SingleOrDefault(n => n.macn == tv.macn && n.makh == o.makh && n.ngay == date && n.matdv == User.Identity.Name);
                    if (z != null)
                    {
                        z.checkgps = true;
                        z.checkin = true;
                        db2.SaveChanges();
                        var myMess = new
                        {
                            Message = "Checkin GPS thành công",
                            Hople = true
                        };
                        return Request.CreateResponse(HttpStatusCode.OK, myMess);
                    }
                    else
                    {
                        var myMess = new
                        {
                            Message = "Không tìm thấy dữ liệu báo cáo",
                            Hople = false
                        };
                        return Request.CreateResponse(HttpStatusCode.OK, myMess);
                    }
                }
                else
                {
                    var myMess = new
                    {
                        Message = "Khoảng cách so với vị trí khách hàng lớn hơn 100m",
                        Hople = false
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, myMess);
                }
            }
            catch (Exception)
            {
                var myError = new
                {
                    Message = "Không thành công",
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, myError);
            }
        }
        [HttpPost]
        public HttpResponseMessage Addkehoach(List<DTA_CONGTACTRINHDUOC> data1)
        {
            try
            {
                var Infocrm = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name);
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
                var myMess = new
                {
                    Message = "Thành công",
                };
                return Request.CreateResponse(HttpStatusCode.OK, myMess);
            }
            catch (Exception)
            {
                var myError = new
                {
                    Message = "Không thành công",
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, myError);
            }
        }
        [HttpGet]
        public IHttpActionResult GetKehoach(string ngay)
        {
            var Infocrm = db2.TBL_PHANQUYENCRM.SingleOrDefault(n => n.taikhoan == User.Identity.Name);
            var MATDV = Infocrm.taikhoan;
            var MACH = Infocrm.macn;
            return Json(DATAGETKEHOACH(MACH, MATDV, ngay));
        }
        public List<DTA_CONGTACTRINHDUOC> DATAGETKEHOACH(string x, string MATDV, string ngay)
        {
            DateTime date = DateTime.ParseExact(ngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return db2.DTA_CONGTACTRINHDUOC.Where(n => n.macn == x && n.matdv == MATDV && n.ngay == date).ToList();
        }
        public void DATADELKEHOACH(string x, string MATDV, DateTime ngay)
        {
            var data = db2.DTA_CONGTACTRINHDUOC.Where(n => n.macn == x && n.matdv == MATDV && n.ngay == ngay);
            db2.DTA_CONGTACTRINHDUOC.RemoveRange(data);
            db2.SaveChanges();
        }
        public List<ListKhachHang> DATAGETKH(string x, string MATDV)
        {
            string strcn = "";
            string strch = "";
            List<string> listMATDV = null;
            if (MATDV != null)
            {
                listMATDV = MATDV.Split(',').ToList();
                strcn = "SELECT makh AS MAKH, donvi AS DONVI, matdv AS MATDV, diachi AS DIACHI from TBL_DANHMUCKHACHHANG" + string.Format(" WHERE (matdv IN ({0}) or matdv = '' or matdv is null) and (tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch')", string.Join(",", listMATDV.Select(p => "'" + p + "'")));
                strch = "SELECT makh AS MAKH, donvi AS DONVI, matdv AS MATDV, diachi AS DIACHI from DM_KHACHHANG_PTTT" + string.Format(" WHERE (matdv IN ({0}) or matdv = '' or matdv is null) and (tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch')", string.Join(",", listMATDV.Select(p => "'" + p + "'")));
            }
            else
            {
                strcn = "SELECT makh AS MAKH, donvi AS DONVI, matdv AS MATDV, diachi AS DIACHI from TBL_DANHMUCKHACHHANG WHERE tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch'";
                strch = "SELECT makh AS MAKH, donvi AS DONVI, matdv AS MATDV from DM_KHACHHANG_PTTT WHERE tinhtrang = N'Đang giao dịch' or tinhtrang = N'Nợ quá hạn' or tinhtrang is null or tinhtrang = '' or tinhtrang = 'Giao d?ch'";
            }

            var DATAX = new List<ListKhachHang>();
            if (x == "QN")
            {
                DATAX = QuangNgai.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "TN")
            {
                DATAX = TayNinh.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "TT423")
            {
                DATAX = TT423.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "BD")
            {
                DATAX = BinhDinh.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "CT")
            {
                DATAX = CanTho.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "DN")
            {
                DATAX = DongNai.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "BDG")
            {
                DATAX = BinhDuong.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "DNA")
            {
                DATAX = DaNang.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "HCM")
            {
                DATAX = HoChiMinh.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "NA")
            {
                DATAX = NgheAn.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "NA2")
            {
                DATAX = NgheAn2.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "PY")
            {
                DATAX = PhuYen.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "AG")
            {
                DATAX = AnGiang.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "CM")
            {
                DATAX = CaMau.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "GL")
            {
                DATAX = GiaLai.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "HUE")
            {
                DATAX = Hue.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "LD")
            {
                DATAX = LamDong.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "NT")
            {
                DATAX = NhaTrang.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "TG")
            {
                DATAX = TienGiang.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "VL")
            {
                DATAX = VinhLong.Database.SqlQuery<ListKhachHang>(strcn).ToList();
            }
            else if (x == "PTTT")
            {
                DATAX = PTTT.Database.SqlQuery<ListKhachHang>(strch).ToList();
            }

            return DATAX;
        }
    }
}
