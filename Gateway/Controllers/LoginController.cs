using ApplicationChart.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ApplicationChart.Controllers
{
    public class MyBaseControllerLogin : BaseController
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.flag = Thread.CurrentThread.CurrentCulture.Name;
            base.OnActionExecuting(filterContext);
        }
    }
    public class LoginController : MyBaseController

    {
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();
        // GET: Login
        [ActionName("chinh-sach-bao-mat")]
        public ActionResult Chinhsachbaomat()
        {
            return View("Chinhsachbaomat");
        }
        [ActionName("dem-block")]
        public ActionResult Demblock()
        {
            return View("Demblock");
        }
        [ActionName("dang-nhap-oid")]
        public void SignIn()
        {
            if (!Request.IsAuthenticated)
            {
                // Signal OWIN to send an authorization request to Azure
                Request.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties { RedirectUri = "/" },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }
        [ActionName("dang-xuat-oid")]
        public ActionResult SignOut()
        {
            if (Request.IsAuthenticated)
            {
                Request.GetOwinContext().Authentication.SignOut(
                    CookieAuthenticationDefaults.AuthenticationType);
            }

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Error(string message, string debug)
        {
            Flash(message, debug);
            return RedirectToAction("Index");
        }   
        [ActionName("dang-nhap")]
        public ActionResult Dangnhap(string returnUrl)
        {
            var zzz = DateTime.Today.ToString("01/01/yyyy");
            //var result = "OK:1/001;K22THP-HP-002006_721";
            //var stringhd = result.Split('-').First();
            ViewBag.ReturnUrl = returnUrl;
            try
            {
                TBL_DANHMUCNGUOIDUNG Info = GetInfo();
                if(Info == null)
                {
                    Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                    Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-10);
                    return View("Dangnhap", new LoginModel { taikhoan = null, matkhau = null });
                }
                if (Info.doimk == true)
                {
                    return RedirectToAction("doi-mat-khau-lan-dau");
                }
                else if (Info.quyen.Split(',').Contains("ADMIN") || Info.quyen.Split(',').Contains("CAP1"))
                {
                    return RedirectToAction("bao-cao-bsc", "Home");
                }
                else if (Info.quyen.Split(',').Contains("CAP2") || Info.quyen.Split(',').Contains("QLHH1") || Info.quyen.Split(',').Contains("QLHH2") || Info.quyen.Split(',').Contains("KEHOACH") || Info.quyen.Split(',').Contains("DONHANG") || Info.quyen.Split(',').Contains("DONHANGKD") || Info.quyen.Split(',').Contains("DONHANGSC") || Info.quyen.Split(',').Contains("DONHANGHCM") || Info.quyen.Split(',').Contains("NHAPTON") || Info.quyen.Split(',').Contains("TONKHO") || Info.quyen.Split(',').Contains("GIAOHANG") || Info.quyen.Split(',').Contains("QLGIAOHANG") || Info.quyen.Split(',').Contains("DUUOC"))
                {
                    if (Info.ngaydoimk != null)
                    {
                        TimeSpan span = DateTime.Now.Subtract((DateTime)Info.ngaydoimk);
                        if (span.TotalDays > db2.TBL_NGAYDOIMATKHAU.FirstOrDefault().Ngay)
                        {
                            return RedirectToAction("doi-mat-khau-dinh-ky");
                        }
                    }
                    if (Info.quyen.Split(',').Contains("CAP2"))
                    {
                        return RedirectToAction("bao-cao-bsc", "Home");
                    }
                    else if (Info.quyen.Split(',').Contains("KEHOACH"))
                    {
                        if (Info.dathang != 0)
                        {
                            return RedirectToAction("ke-hoach-cong-tac", "Baocao");
                        }
                        else
                        {
                            return RedirectToAction("bao-cao-cong-tac-trinh-duoc", "Baocao");
                        }
                    }
                    else if (Info.quyen.Split(',').Contains("DONHANGKD"))
                    {
                        return RedirectToAction("quan-ly-don-hang-ve-phong-kinh-doanh", "Order");
                    }
                    else if (Info.quyen.Split(',').Contains("DONHANGHCM"))
                    {
                        return RedirectToAction("quan-ly-don-hang-ve-hcm", "Order");
                    }
                    else if (Info.quyen.Split(',').Contains("DONHANGSC"))
                    {
                        return RedirectToAction("quan-ly-don-hang-ve-sc", "Order");
                    }
                    else if (Info.quyen.Split(',').Contains("NHAPTON"))
                    {
                        return RedirectToAction("bao-cao-ton-kho", "Home");
                    }
                    else if (Info.quyen.Split(',').Contains("TONKHO"))
                    {
                        return RedirectToAction("thong-tin-nhanh-ton-kho", "Home");
                    }
                    else if (Info.quyen.Split(',').Contains("GIAOHANG"))
                    {
                        return RedirectToAction("lay-don-hang", "Order");
                    }
                    else if (Info.quyen.Split(',').Contains("QLGIAOHANG"))
                    {
                        return RedirectToAction("phan-don-hang", "Order");
                    }
                    else if (Info.quyen.Split(',').Contains("DUUOC"))
                    {
                        return RedirectToAction("quan-ly-du-uoc", "Duuoc");
                    }
                    else
                    {
                        return RedirectToAction("quan-ly-san-pham", "QLSP");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-10);
                return View("Dangnhap", new LoginModel { taikhoan = null, matkhau = null });
            }
            Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
            Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-10);
            return View("Dangnhap", new LoginModel { taikhoan = null, matkhau = null });
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
        public void CountLogin(string taikhoan)
        {
            try
            {
                TBL_DANHMUCNGUOIDUNG tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == taikhoan);
                if (tv != null)
                {
                    tv.truycap = tv.truycap + 1;
                    tv.ngaydangnhap = DateTime.Now;
                }
                TBL_QUANLYDANGNHAP data = new TBL_QUANLYDANGNHAP { Ngay = DateTime.Now, Username = taikhoan, IP = GetUserIP(), pcname = string.Format("{0} {1}", Request.Browser.Browser, Request.Browser.Version), systemversion = GetUserPlatform(Request) };
                db2.TBL_QUANLYDANGNHAP.Add(data);
                db2.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
        //
        private string GetUserIP()
        {
            string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }
            return Request.ServerVariables["REMOTE_ADDR"];
        }

        public String GetUserPlatform(HttpRequestBase request)
        {
            try
            {
                var ua = request.UserAgent;
                if (ua.Contains("Android"))
                    return string.Format("Android {0}", GetMobileVersion(ua, "Android"));

                if (ua.Contains("iPad"))
                    return string.Format("iPad OS {0}", GetMobileVersion(ua, "OS"));

                if (ua.Contains("iPhone"))
                    return string.Format("iPhone OS {0}", GetMobileVersion(ua, "OS"));

                if (ua.Contains("Linux") && ua.Contains("KFAPWI"))
                    return "Kindle Fire";

                if (ua.Contains("RIM Tablet") || (ua.Contains("BB") && ua.Contains("Mobile")))
                    return "Black Berry";

                if (ua.Contains("Windows Phone"))
                    return string.Format("Windows Phone {0}", GetMobileVersion(ua, "Windows Phone"));

                if (ua.Contains("Mac OS"))
                    return "Mac OS";

                if (ua.Contains("Windows NT 5.1") || ua.Contains("Windows NT 5.2"))
                    return "Windows XP";

                if (ua.Contains("Windows NT 6.0"))
                    return "Windows Vista";

                if (ua.Contains("Windows NT 6.1"))
                    return "Windows 7";

                if (ua.Contains("Windows NT 6.2"))
                    return "Windows 8";

                if (ua.Contains("Windows NT 6.3"))
                    return "Windows 8.1";

                if (ua.Contains("Windows NT 10"))
                    return "Windows 10";
                //fallback to basic platform:
                return request.Browser.Platform + (ua.Contains("Mobile") ? " Mobile " : "");
            }
            catch (Exception)
            {
                return "N/A";
            }
        }
        public void PhanQuyen(string TaiKhoan, string Quyen)
        {
            FormsAuthentication.Initialize();
            var ticket = new FormsAuthenticationTicket(1,
            TaiKhoan,
            DateTime.Now,
            DateTime.Now.AddMonths(3),
            false,
            Quyen,
            FormsAuthentication.FormsCookiePath);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket)) { HttpOnly = true, Secure = FormsAuthentication.RequireSSL };
            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
            Response.Cookies.Add(cookie);
        }
        public String GetMobileVersion(string userAgent, string device)
        {
            var temp = userAgent.Substring(userAgent.IndexOf(device) + device.Length).TrimStart();
            var version = string.Empty;
            foreach (var character in temp)
            {
                var validCharacter = false;
                int test = 0;

                if (Int32.TryParse(character.ToString(), out test))
                {
                    version += character;
                    validCharacter = true;
                }

                if (character == '.' || character == '_')
                {
                    version += '.';
                    validCharacter = true;
                }

                if (validCharacter == false)
                    break;
            }
            return version;
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("bao-cao-bsc", "Home");
        }
        [ActionName("dang-nhap")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dangnhap(LoginModel model, string returnUrl)
        {
            try
            {
                if (model.taikhoan.IndexOf("'") > -1 || model.matkhau.IndexOf("=") > -1)
                {
                    ViewBag.msg = 1;
                    return View("Dangnhap", model);
                }
            }
            catch (Exception)
            {

            }
            try
            {
                string taikhoan = Sanitizer.GetSafeHtmlFragment(model.taikhoan);
                string matkhau = Sanitizer.GetSafeHtmlFragment(EncodePassword(model.matkhau));
                TBL_DANHMUCNGUOIDUNG user = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == taikhoan && n.matkhau == matkhau);
                if (user != null)
                {
                    if (user.khoatk == false)
                    {
                        CountLogin(user.nguoidung);
                        string Quyen = user.quyen;
                        PhanQuyen(taikhoan, Quyen); //Xử lý phương thức phân quyền
                        if (user.doimk == true)
                        {
                            return RedirectToAction("doi-mat-khau-lan-dau");
                        }
                        if (user.quyen.Split(',').Contains("ADMIN") || user.quyen.Split(',').Contains("CAP1"))
                        {
                            return RedirectToLocal(returnUrl);
                        }
                        else if (user.quyen.Split(',').Contains("CAP2") || user.quyen.Split(',').Contains("QLHH1") || user.quyen.Split(',').Contains("QLHH2") || user.quyen.Split(',').Contains("KEHOACH") || user.quyen.Split(',').Contains("DONHANG") || user.quyen.Split(',').Contains("DONHANGKD") || user.quyen.Split(',').Contains("DONHANGSC") || user.quyen.Split(',').Contains("DONHANGHCM") || user.quyen.Split(',').Contains("NHAPTON") || user.quyen.Split(',').Contains("TONKHO") || user.quyen.Split(',').Contains("GIAOHANG") || user.quyen.Split(',').Contains("QLGIAOHANG") || user.quyen.Split(',').Contains("DUUOC"))
                        {
                            if (user.ngaydoimk != null)
                            {
                                TimeSpan span = DateTime.Now.Subtract((DateTime)user.ngaydoimk);
                                if (span.TotalDays > db2.TBL_NGAYDOIMATKHAU.FirstOrDefault().Ngay)
                                {
                                    return RedirectToAction("doi-mat-khau-dinh-ky");
                                }
                            }
                            if (user.quyen.Split(',').Contains("CAP2"))
                            {
                                return RedirectToLocal(returnUrl);
                            }
                            else if (user.quyen.Split(',').Contains("KEHOACH"))
                            {
                                if (user.dathang != 0)
                                {
                                    return RedirectToAction("ke-hoach-cong-tac", "Baocao");
                                }
                                else
                                {
                                    return RedirectToAction("bao-cao-cong-tac-trinh-duoc", "Baocao");
                                }
                            }
                            else if (user.quyen.Split(',').Contains("DONHANGKD"))
                            {
                                return RedirectToAction("quan-ly-don-hang-ve-phong-kinh-doanh", "Order");
                            }
                            else if (user.quyen.Split(',').Contains("DONHANGSC"))
                            {
                                return RedirectToAction("quan-ly-don-hang-ve-sc", "Order");
                            }
                            else if (user.quyen.Split(',').Contains("DONHANGHCM"))
                            {
                                return RedirectToAction("quan-ly-don-hang-ve-hcm", "Order");
                            }
                            else if (user.quyen.Split(',').Contains("NHAPTON"))
                            {
                                return RedirectToAction("bao-cao-ton-kho", "Home");
                            }
                            else if (user.quyen.Split(',').Contains("TONKHO"))
                            {
                                return RedirectToAction("thong-tin-nhanh-ton-kho", "Home");
                            }
                            else if (user.quyen.Split(',').Contains("GIAOHANG"))
                            {
                                return RedirectToAction("lay-don-hang", "Order");
                            }
                            else if (user.quyen.Split(',').Contains("QLGIAOHANG"))
                            {
                                return RedirectToAction("phan-don-hang", "Order");
                            }
                            else if (user.quyen.Split(',').Contains("DUUOC"))
                            {
                                return RedirectToAction("quan-ly-du-uoc", "Duuoc");
                            }
                            else
                            {
                                return RedirectToAction("quan-ly-san-pham", "QLSP");
                            }
                        }
                        return RedirectToAction("bao-cao-bsc", "Home");
                    }
                    else
                    {
                        ViewBag.msg = 2;
                        return View("Dangnhap", model);
                    }
                }
                else
                {
                    ViewBag.msg = 1;
                    TBL_DANGNHAPTHATBAI item = new TBL_DANGNHAPTHATBAI { taikhoan = model.taikhoan, thoigian = DateTime.Now, IP = GetUserIP() };
                    db2.TBL_DANGNHAPTHATBAI.Add(item);
                    db2.SaveChanges();
                    return View("Dangnhap", model);
                }
            }
            catch
            {
                return RedirectToAction("dang-xuat");
            }
            ViewBag.msg = 1;
            return View("Dangnhap", model);
        }
        [ActionName("doi-mat-khau")]
        [Authorize]
        public ActionResult Password()
        {
            return View("Password");
        }
        [ActionName("doi-mat-khau-reset-code")]
        public ActionResult PasswordResetcode(string code)
        {
            ViewBag.code = code;
            return View("PasswordResetcode");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("doi-mat-khau-reset-code")]
        public ActionResult PasswordResetcode(string mahoamoi, string code)
        {
            return Json("Hệ thống đang khóa chức năng này!");
            var tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.resetcode == code);
            if (tv != null)
            {
                tv.matkhau = Sanitizer.GetSafeHtmlFragment(EncodePassword(mahoamoi));
                tv.ngaydoimk = DateTime.Now;
                tv.resetcode = null;
                db2.SaveChanges();
                return Content("<script type='text/javascript'>alert('Đặt lại mật khẩu thành công'); window.location.href = 'https://gateway.pymepharco.com';</script>");
            }
            else
            {
                return Content("<script type='text/javascript'>alert('Đường dẫn của bạn không hợp lệ, vui lòng chọn quên mật khẩu và thử lại !'); window.location.href = 'https://gateway.pymepharco.com';</script>");
            }
        }
        [HttpPost]
        [ActionName("quen-mat-khau")]
        public ActionResult ResetPassword(string taikhoan)
        {
            return Json("Hệ thống đang khóa chức năng này!");
            var tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToLower() == taikhoan.ToLower());
            if (tv != null)
            {
                if (tv.email != null)
                {
                    try
                    {
                        string html = "<div style='width:100%;padding:15px;'><a href='https://gateway.pymepharco.com'><img style='margin-left:auto;margin-right: auto;display: block;' alt = 'logo2' src = 'https://gateway.pymepharco.com/Content/Layout1/images/logover2.png'></a></div><center style='width:100%;min-width:600px'><table style='border-spacing:0;border-collapse:collapse;vertical-align:top;text-align:left;padding:0'> <tbody> <tr style='vertical-align:top;text-align:left;padding:0'> <td class='m_6291312848774364587container-row' style='width: 600px; overflow-wrap: break-word; vertical-align: top; text-align: left; font-family: Helvetica, Arial, sans-serif; line-height: 150%; font-size: 16px; word-break: break-word; margin: 0px 0px 12px; padding: 0px 8px; border-collapse: collapse !important;'> <hr style='font-weight: normal; color: rgb(0, 0, 0); margin: 0px; border: 1px solid rgb(221, 221, 221);'> <br><font color='#000000' style='font-weight: normal;'>Xin chào,</font><br><p style='font-family: Helvetica, Arial, sans-serif; text-align: left; line-height: 150%; font-size: 16px; margin: 0px 0px 10px; padding: 0px;'><span style='font-weight: normal; color: rgb(0, 0, 0);'>Bạn vui lòng click vào đường link bên dưới để thực hiện đặt lại mật khẩu cho tài khoản trên hệ thống </span><b style=''><font color='#397b21'>GATEWAY.PYMEPHARCO.COM</font></b></p></td></tr><tr style='vertical-align:top;text-align:left;padding:0'> <td class='m_6291312848774364587container-row' style='width:600px;word-wrap:break-word;border-collapse:collapse!important;vertical-align:top;text-align:left;color:#000;font-family:Helvetica,Arial,sans-serif;font-weight:normal;line-height:150%;font-size:16px;word-break:break-word;margin:0;padding:0 4px'> <table style='width:100%;border-spacing:0;border-collapse:separate;vertical-align:top;text-align:left;border-radius:20px;overflow:hidden;padding:0;border:1px solid #ddd'> <tbody> <tr style='vertical-align:top;text-align:left;padding:0'> <td style='width:100%;word-wrap:break-word;border-collapse:collapse!important;vertical-align:top;text-align:left;color:#000;font-family:Helvetica,Arial,sans-serif;font-weight:normal;line-height:150%;font-size:16px;word-break:break-word;margin:0;padding:24px'><table style='background-color: rgb(255, 255, 255); width: 600px; vertical-align: top; padding: 0px;'><tbody><tr style='vertical-align: top; padding: 0px;'><td height='24px' style='overflow-wrap: break-word; vertical-align: top; color: rgb(0, 0, 0); line-height: 24px; word-break: break-word; margin: 0px; border-collapse: collapse !important;'></td></tr></tbody></table><table cellpadding='0px' style='background-color: rgb(255, 255, 255); width: 600px; vertical-align: top; margin: 0px; padding: 0px;'><tbody><tr style='vertical-align: top; padding: 0px;'><td style='overflow-wrap: break-word; vertical-align: top; color: rgb(0, 0, 0); line-height: 24px; word-break: break-word; margin: 0px; border-collapse: collapse !important;'><center style='width: 600px; min-width: 600px;'><table cellpadding='0px' style='width: 600px; vertical-align: top; padding: 0px;'><tbody><tr style='vertical-align: top; padding: 0px;'><td valign='middle' style='background-color: inherit; overflow-wrap: break-word; vertical-align: top; color: rgb(254, 254, 254); line-height: 24px; word-break: break-word; width: 600px; margin: 0px; border-collapse: collapse !important;'><center style='width: 600px; min-width: 600px;'><a href='https://gateway.pymepharco.com/doi-mat-khau-reset-code?code=ABCTOKEN' target='_blank' data-saferedirecturl='https://www.google.com/url?q=https://gateway.pymepharco.com/doi-mat-khau-reset-code?code=ABCTOKEN' style='background-color: rgb(9, 84, 211); color: rgb(254, 254, 254); font-weight: bold; line-height: 24px; display: inline-block; border-radius: 3px; width: 360px; margin: 0px; padding: 12px 0px; border: 0px solid rgb(30, 136, 229);'>XÁC THỰC EMAIL ▸</a></center></td></tr></tbody></table></center></td></tr></tbody></table> </td></tr><tr style='background-color:#f8f8f8!important;vertical-align:top;text-align:left;padding:0'> <td style='word-wrap:break-word;border-collapse:collapse!important;vertical-align:top;text-align:left;color:#000;font-family:Helvetica,Arial,sans-serif;font-weight:normal;line-height:150%;font-size:16px;word-break:break-word;margin:0;padding:16px 24px 20px'> <table style='border-spacing:0;border-collapse:collapse;vertical-align:top;text-align:left;padding:0'> <tbody> <tr style='vertical-align:top;text-align:left;padding:0'> <td style='word-wrap:break-word;border-collapse:collapse!important;vertical-align:top;text-align:left;color:#0954d3;font-family:'Helvetica Neue',sans-serif;font-weight:700;line-height:1em;font-size:11px;word-break:break-word;display:block;letter-spacing:0.7px;text-transform:uppercase;margin:0;padding:0 0 12px'>LƯU Ý</td></tr><tr style='vertical-align:top;text-align:left;padding:0'> <td style='overflow-wrap: break-word; vertical-align: top; text-align: left; color: rgb(51, 51, 51); font-family: &quot;Helvetica Neue&quot;, sans-serif; line-height: 1.4em; font-size: 15px; word-break: break-word; max-height: 88px; overflow: hidden; text-overflow: ellipsis; margin: 0px; padding: 4px 0px 0px; border-collapse: collapse !important;'><span style='font-weight: normal;'>Thư này được tạo ra tự động, nếu bạn cần sự trợ giúp vui lòng liên hệ email </span><b>quang.nguyennhat@stada.com</b> hoặc SĐT <b>0387246802</b> (Quang)</td></tr></tbody></table> </td></tr></tbody> </table><table cellpadding='0px' style='width:100%;border-spacing:0;border-collapse:collapse;vertical-align:top;text-align:left;margin:0px;padding:0'><tbody><tr style='vertical-align:top;text-align:left;padding:0'><td style='word-wrap:break-word;border-collapse:collapse!important;vertical-align:top;text-align:left;color:#000;font-family:Helvetica,Arial,sans-serif;font-weight:normal;line-height:150%;font-size:16px;word-break:break-word;margin:0;padding:0'><center style='width:100%;min-width:600px'><table cellpadding='0px' style='width:100%;border-spacing:0;border-collapse:collapse;vertical-align:top;text-align:center;box-sizing:border-box;padding:0'><tbody> </tbody> </table> </center> </td></tr></tbody> </table> <table style='width:100%;border-spacing:0;border-collapse:collapse;vertical-align:top;text-align:left;padding:0'> <tbody> <tr style='vertical-align:top;text-align:left;padding:0'> <td height='12px' style='word-wrap:break-word;border-collapse:collapse!important;vertical-align:top;text-align:left;color:#000;font-family:Helvetica,Arial,sans-serif;font-weight:normal;line-height:150%;font-size:16px;word-break:break-word;margin:0;padding:0'><br></td></tr></tbody> </table> </td></tr><tr style='vertical-align:top;text-align:left;padding:0'> <td style='word-wrap:break-word;border-collapse:collapse!important;vertical-align:top;text-align:left;color:#000;font-family:Helvetica,Arial,sans-serif;font-weight:normal;line-height:150%;font-size:16px;word-break:break-word;margin:0;padding:0'> <hr style='margin:0px;border:1px solid #ddd'> </td></tr><tr style='vertical-align:top;text-align:left;padding:0'> <td style='overflow-wrap: break-word; vertical-align: top; text-align: left; color: rgb(0, 0, 0); font-family: Helvetica, Arial, sans-serif; line-height: 150%; font-size: 16px; word-break: break-word; margin: 0px; padding: 0px; border-collapse: collapse !important;'><p style='font-weight: normal;'> <br>Trân trọng.</p><p style=''><b>PHÒNG TIN HỌC VÀ PHÂN TÍCH DỮ LIỆU</b></p></td></tr></tbody></table></center>";
                        string resetCode = Guid.NewGuid().ToString();
                        tv.resetcode = resetCode;
                        db2.SaveChanges();
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.office365.com",587);
                        mail.From = new MailAddress("pme.it@stada.com", "Pymepharco System");
                        mail.To.Add(tv.email);
                        mail.Subject = Sanitizer.GetSafeHtmlFragment("XÁC THỰC TÀI KHOẢN HỆ THỐNG GATEWAY.PYMEPHARCO.COM");
                        mail.IsBodyHtml = true;
                        mail.Body = html.Replace("ABCTOKEN", resetCode);
                        mail.BodyEncoding = System.Text.Encoding.UTF8;
                        mail.SubjectEncoding = System.Text.Encoding.UTF8;
                        //SmtpServer.Port = 587;
                        SmtpServer.UseDefaultCredentials = false;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("pme.it@stada.com", "Le=7bAeWfDWtYye7");
                        SmtpServer.EnableSsl = true;
                        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                        SmtpServer.TargetName = "STARTTLS/smtp.office365.com";
                        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                      | SecurityProtocolType.Tls11
                                      | SecurityProtocolType.Tls12;
                        SmtpServer.Send(mail);
                        return Json("Email xác nhận đã được gửi về địa chỉ email " + tv.email);
                    }
                    catch(Exception ex)
                    {
                        return Json(ex);
                    }
                    
                }
                else
                {
                    return Json("Bạn chưa điền email cho tài khoản của bạn !");
                }
            }
            return Json("Tài khoản bạn nhập không tồn tại trong hệ thống !");
        }
        [ActionName("doi-mat-khau")]
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Password(string mahoamoi, string mahoacu)
        {
            var passmoi = Sanitizer.GetSafeHtmlFragment(EncodePassword(mahoamoi));
            var passcu = Sanitizer.GetSafeHtmlFragment(EncodePassword(mahoacu));
            if (passmoi == passcu)
            {
                ViewBag.msg = 2;
                return View("Password");
            }
            try
            {
                TBL_DANHMUCNGUOIDUNG tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name.ToString());
                if (tv.matkhau == passcu)
                {
                    tv.matkhau = passmoi;
                    tv.ngaydoimk = DateTime.Now;
                    db2.SaveChanges();
                    return RedirectToAction("dang-xuat");
                }
            }
            catch (Exception)
            {

            }
            ViewBag.msg = 1;
            return View("Password");
        }
        [ActionName("doi-mat-khau-dinh-ky")]
        [Authorize]
        public ActionResult PasswordDinhky()
        {
            ViewBag.ngay = db2.TBL_NGAYDOIMATKHAU.FirstOrDefault().Ngay;
            return View("PasswordDinhky");
        }

        [ActionName("doi-mat-khau-dinh-ky")]
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PasswordDinhky(string mahoamoi, string mahoacu)
        {
            var passmoi = Sanitizer.GetSafeHtmlFragment(EncodePassword(mahoamoi));
            var passcu = Sanitizer.GetSafeHtmlFragment(EncodePassword(mahoacu));
            if (passmoi == passcu)
            {
                ViewBag.msg = 2;
                return View("PasswordDinhky");
            }
            try
            {
                TBL_DANHMUCNGUOIDUNG tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name.ToString());
                if (tv.matkhau == passcu)
                {
                    tv.matkhau = passmoi;
                    tv.ngaydoimk = DateTime.Now;

                    db2.SaveChanges();
                    return RedirectToAction("dang-xuat");
                }
            }
            catch (Exception)
            {

            }
            ViewBag.ngay = db2.TBL_NGAYDOIMATKHAU.FirstOrDefault().Ngay;
            ViewBag.msg = 1;
            return View("PasswordDinhky");
        }
        [ActionName("doi-mat-khau-lan-dau")]
        [Authorize]
        public ActionResult PasswordLandau()
        {
            return View("PasswordLandau");
        }
        [ActionName("doi-mat-khau-lan-dau")]
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PasswordLandau(string mahoamoi)
        {
            var passmoi = Sanitizer.GetSafeHtmlFragment(EncodePassword(mahoamoi));

            try
            {
                TBL_DANHMUCNGUOIDUNG tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name.ToString());
                if (tv != null)
                {
                    tv.matkhau = passmoi;
                    tv.ngaydoimk = DateTime.Now;
                    tv.doimk = false;
                    db2.SaveChanges();
                    return RedirectToAction("dang-nhap");
                }
            }
            catch (Exception)
            {

            }
            ViewBag.msg = 1;
            return View("PasswordLandau");
        }
        [ActionName("dang-xuat")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-10);
            }
            if (Request.Cookies["AuthenticationToken"] != null)
            {
                Response.Cookies["AuthenticationToken"].Value = string.Empty;
                Response.Cookies["AuthenticationToken"].Expires = DateTime.Now.AddMonths(-10);
            }
            return RedirectToAction("dang-nhap");
        }
        [Authorize]
        public TBL_DANHMUCNGUOIDUNG GetInfo()
        {
            TBL_DANHMUCNGUOIDUNG abc = new TBL_DANHMUCNGUOIDUNG();
            abc = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name.ToString());
            return abc;
        }
    }
}