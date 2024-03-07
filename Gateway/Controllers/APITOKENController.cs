using ApplicationChart.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Security;

namespace ApplicationChart.Controllers
{
    [Authorize]
    public class APITOKENController : ApiController
    {
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();
        public IHttpActionResult Get()
        {
            db2.Configuration.ProxyCreationEnabled = false;
            var data = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name);
            data.ngaydangnhap = DateTime.Now;
            db2.SaveChanges();
            return Json(new { hoten = data.hoten,macn = data.macn, quyen = data.quyen, nguoidung = data.nguoidung, email = data.email, sdt = data.sdt, dathang = data.dathang , doimk = data.doimk});
        }
        public IHttpActionResult getnow()
        {
            return Json(DateTime.Now);
        }
        // GET api/values/5
        public HttpResponseMessage Logout()
        {
            FormsAuthentication.SignOut();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        // POST api/values
        public void Post([FromBody]APILOGINLOG value)
        {
            try
            {
                TBL_DANHMUCNGUOIDUNG tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == value.taikhoan.ToUpper());
                if (tv != null)
                {
                    tv.truycap = tv.truycap + 1;
                    tv.ngaydangnhap = DateTime.Now;
                }
                TBL_QUANLYDANGNHAP data = new TBL_QUANLYDANGNHAP { Ngay = DateTime.Now, Username = value.taikhoan, IP = value.IP, pcname = value.pcname, systemversion = "App Mobile" };
                db2.TBL_QUANLYDANGNHAP.Add(data);
                db2.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public HttpResponseMessage Doimatkhau([FromBody]JObject data)
        {
            var mkc = EncodePassword(data["matkhaucu"].ToString());
            var mkm = EncodePassword(data["matkhaumoi"].ToString());
            var tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name);
            if (tv.matkhau == mkc)
            {
                tv.matkhau = mkm;
                tv.doimk = false;
                db2.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        public HttpResponseMessage Doimatkhaulandau([FromBody]JObject data)
        {
            var mkm = EncodePassword(data["matkhaumoi"].ToString());
            var tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name);
            tv.matkhau = mkm;
            tv.doimk = false;
            db2.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        public HttpResponseMessage Updatethongtin([FromBody]JObject data)
        {
            var tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name);
            if (tv != null)
            {
                tv.sdt = data["sdt"].ToString();
                tv.email = data["email"].ToString();
                db2.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
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
    }
}
