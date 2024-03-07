using ApplicationChart.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Hosting;
using System.Web.Http;
using static ApplicationChart.Models.apiviettinbank;

namespace ApplicationChart.Controllers
{
    public class APIGETController : ApiController
    {
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();
        [HttpGet]
        public IHttpActionResult Getversion()
        {
            var tv = db2.TBL_APPVERSION.ToList();
            return Json(tv);
        }
        [HttpGet]
        public IHttpActionResult GetMien()
        {
            var tv = db2.TBL_DANHMUCMIEN.ToList();
            return Json(tv);
        }
        [HttpPost]
        public HttpResponseMessage Checkbaotri()
        {
            var tv = db2.TBL_BAOTRIAPP.FirstOrDefault();
            if (tv != null && tv.baotri == true)
            {
                var myMess = new
                {
                    Message = tv.message,
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, myMess);
            }
            else
            {
                var myMess = new
                {
                    Message = tv.message,
                };
                return Request.CreateResponse(HttpStatusCode.OK, myMess);
            }
        }
        [HttpPost]
        public HttpResponseMessage Dangky([FromBody]TBL_DANHMUCNGUOIDUNG data)
        {
            try
            {
                data.doimk = false;
                data.khoatk = false;
                data.dathang = 1;
                data.macn = "NA2";
                data.mahh = "ALL";
                data.maquan = "ALL";
                data.matinh = "ALL";
                data.matdv = "ALL";
                data.matkhau = EncodePassword(data.matkhau);
                data.quyen = "CAP1,CAP2,KEHOACH,DONHANG,DONHANGKD,QLKHKD,TRACUU,TDTHAU,CAP3";
                data.READ_ONLY = false;
                data.PDF = true;
                data.WORD = true;
                data.EXCEL = true;
                data.ngaydangnhap = DateTime.Now;
                data.ngaydoimk = DateTime.Now;
                data.phanloai = "ETC,OTC";
                data.truycap = 1;
                data.dathang = 1;
                var crm = new TBL_PHANQUYENCRM() { macn = "NA2", matdv = "NA.TIEN", quyen = "TDV", taikhoan = data.nguoidung };
                data.TBL_PHANQUYENCRM = crm;
                db2.TBL_DANHMUCNGUOIDUNG.Add(data);
                db2.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Tạo tài khoản thành công");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Tạo tài khoản không thành công");
            }
        }
        [HttpPost]
        public IHttpActionResult Getphanmem([FromBody]TBL_UPDATE_PROGRAM2 x)
        {
            if (x.authtoken == "Qhfk@qo1h15h12j4h125@h")
            {
                var tv = db2.TBL_UPDATE_PROGRAM.SingleOrDefault(n => n.tenphanmem == x.tenphanmem);
                if (tv != null)
                {
                    if (x.phienban == tv.phienban)
                    {
                        return Json(new JsonMessage() { status = "0", message = "Phiên bản của bạn đã là phiên bản mới nhất" });
                    }
                    else
                    {
                        return Json(new JsonMessage() { status = "1", message = "Phiên bản của bạn đã cũ, vui lòng cập nhật", data = tv.program });
                    }
                }
                else
                {
                    return Json(new JsonMessage() { status = "0", message = "Không tìm thấy phần mềm" });
                }
            }
            else
            {
                return Json(new JsonMessage() { status = "0", message = "Mã xác thực không hợp lệ" });
            }
        }
        [HttpPost]
        public IHttpActionResult Gettigiaviettinbank([FromBody]Request x)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var request = new Request() { requestId = DateTime.Now.ToString("yyyyMMddHHmmss"), providerId = "PYMEPHARCO", merchantId = "PYMEPHARCO", trans_date = x.trans_date, language = "vi", channel = "BRANCH", version = "1.0.1", clientIP = "117.2.32.239" };
                    request.signature = SignData(request.requestId + request.trans_date, "C:\\pymepharco.pfx");
                    //var x = VerifyData(request.signature, request.requestId + request.providerId + request.merchantId + request.trans_date + request.language + request.channel + request.version + request.clientIP, @"G:\chungthuc\pymepharco.pfx");
                    client.BaseAddress = new Uri("https://api.vietinbank.vn/");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("x-ibm-client-secret", "uN0rI0hJ0eL3fA5wB5jU7mR3aD3yV0xO8cN0kO3gL8hN8wN6tN");
                    client.DefaultRequestHeaders.Add("x-ibm-client-id", "7d8220c3-00dc-4db4-ae36-ed20a93f1650");
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-ibm-client-secret", "uS7pQ2cV4yQ4iK7mT2mF6jH0wU3kA7pQ0lX8mF7kX3jO7kC2wV");
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-ibm-client-id", "9049dbd1-2f74-4df9-a0c6-4acb50bd3f01");
                    var response = client.PostAsJsonAsync("vtb/public/v1/fxrate/fxRateInq", request).Result;
                    var status = (int)response.StatusCode;
                    if (status == 200)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        ////Deserializing the response recieved from web api and storing into the Employee list  
                        var z = JsonConvert.DeserializeObject<Root>(data);
                        return Json(z);
                    }
                    else
                    {
                        return Json(new Root() { });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public string SignData(string data, string str_privatekey)
        {
            try
            {
                encoding = new UTF8Encoding();
                rsaCSP = new RSACryptoServiceProvider();
                cert = GetCertificate2FromFile(str_privatekey, sign_passpharse);
                rsaCSP = GetPrivateKey(cert);
                //return Convert.ToBase64String(rsaCSP.SignData(encoding.GetBytes(data), "SHA1"));
                return Convert.ToBase64String(rsaCSP.SignData(encoding.GetBytes(data), hashAlgorithm));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cert = null;
                rsaCSP = null;
                encoding = null;
            }
        }
        private string sign_passpharse = "123456";
        private string hashAlgorithm = "SHA1"; //"MD5";
        private bool m_pemFormat = false;
        //Added by thinhdt - date 16/08/2014
        private bool _ignore_expire_date = false;
        private Encoding _encoding = Encoding.UTF8;//Default
        StreamReader sr = null;//Read private key pem
        //cert = GetCertificate2FromFile(sign_privatekey, sign_passpharse);
        public Encoding ENCODING
        {
            get { return _encoding; }
            set { _encoding = value; }
        }

        //Added by thinhdt - date 20/07/2015

        bool _UsingX509KeyStorageFlags = false;

        public bool UsingX509KeyStorageFlags
        {
            get { return _UsingX509KeyStorageFlags; }
            set { _UsingX509KeyStorageFlags = value; }
        }

        X509KeyStorageFlags _X509KeyStorageFlags = X509KeyStorageFlags.MachineKeySet;

        public X509KeyStorageFlags X509KeyStorageFLAGS
        {
            get { return _X509KeyStorageFlags; }
            set { _X509KeyStorageFlags = value; }
        }
        public bool IGNORE_EXPIRE_DATE
        {
            get { return _ignore_expire_date; }
            set { _ignore_expire_date = value; }
        }

        /// <summary>
        /// Used to set hash algorithm (SHA1, MD5) for signing data; Default is 'SHA1'.
        /// </summary>
        public string HASH_ALGORITHM
        {
            get { return hashAlgorithm; }
            set { hashAlgorithm = value; }
        }

        UTF8Encoding encoding = null;
        RSACryptoServiceProvider rsaCSP = null;
        private X509Certificate2 cert = null;

        private RSACryptoServiceProvider GetPrivateKey(X509Certificate2 cert)
        {
            try
            {
                return (RSACryptoServiceProvider)cert.PrivateKey;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private X509Certificate2 GetCertificate2FromFile(string filePath, string passWord)
        {
            try
            {
                X509Certificate2 cert = null;

                //Added by thinhdt - Date 26/04/2014
                if (m_pemFormat)
                {

                    string sPublicKey = GetCertString(filePath);

                    //Modified by thinhdt - Date 26/04/2014
                    string cf = sPublicKey.Replace("-----BEGIN PRIVATE KEY-----\n", "");
                    cf = cf.Replace("\n-----END PRIVATE KEY-----\n", "");
                    byte[] bInput;
                    bInput = Convert.FromBase64String(cf);
                    cert = new X509Certificate2();
                    if (string.IsNullOrEmpty(passWord))
                    {
                        cert.Import(bInput);
                    }
                    else
                    {
                        cert.Import(bInput);
                        //cert.Import(bInput, passWord, X509KeyStorageFlags.Exportable);
                    }

                    return cert;
                }

                if (passWord != "")
                {
                    if (_UsingX509KeyStorageFlags == false)
                    {
                        cert = new X509Certificate2(filePath, passWord);
                    }
                    else
                    {
                        //For Windows 2008 64bit
                        cert = new X509Certificate2(filePath, passWord, _X509KeyStorageFlags);//X509KeyStorageFlags.MachineKeySet
                    }
                }
                else
                {
                    cert = new X509Certificate2(filePath);
                }

                return cert;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetCertString(string filePath)
        {
            try
            {

                sr = new StreamReader(filePath);
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new Exception("GetCertString(): " + ex.Message);
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
