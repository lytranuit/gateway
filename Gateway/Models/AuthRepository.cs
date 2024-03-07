using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ApplicationChart.Models
{
    public class AuthRepository
    {
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();

        public Tuple<bool?,string> ValidateUser(string username,string password, string ip,string os)
        {
            var matkhau = EncodePassword(password);
            var tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == username && n.matkhau == matkhau);
            if(tv != null)
            {
                if(tv.khoatk == true)
                {
                    return new Tuple<bool?, string>(null,tv.quyen);
                }
                else
                {
                    db2.TBL_QUANLYDANGNHAP.Add(new TBL_QUANLYDANGNHAP() { IP = ip, Ngay = DateTime.Now, pcname = "APPMOBILE", Username = username, systemversion = os });
                    db2.SaveChanges();
                    return new Tuple<bool?, string>(true, tv.quyen);
                }
            }
            else
            {
                return new Tuple<bool?, string>(false, null);
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