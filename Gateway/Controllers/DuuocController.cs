using ApplicationChart.Models;
using Microsoft.Security.Application;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ApplicationChart.Controllers
{
    [Authorize]
    public class DuuocController : MyBaseController
    {
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();
        Entities SC = new Entities("KT_SCEntities");
        SCEntities Duuoc = new SCEntities();
        POWERBIEntities PBIDATA = new POWERBIEntities();
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
            new EntitiesCN {data = new Entities("KT_SCEntities") , macn = "SC"},
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
            new EntitiesCN {data = new Entities("KT_PTEntities") , macn = "PT"},
            new EntitiesCN {data = new Entities("KT_HNEntities") , macn = "HN"},
            new EntitiesCN {data = new Entities("KT_TNGEntities") , macn = "TNG"},
            new EntitiesCN {data = new Entities("KT_TBEntities") , macn = "TB"},
            new EntitiesCN {data = new Entities("KT_THOEntities") , macn = "THO"},
            new EntitiesCN {data = new Entities("KT_BTEntities") , macn = "BT"},
                 new EntitiesCN {data = new Entities("KT_PYPHARMEntities") , macn = "NP"},
            new EntitiesCN {data = new Entities("KT_PYPHARM_HCMEntities") , macn = "DPY_HCM"},
        };
        List<EntitiesCH> queryCH = new List<EntitiesCH> {
            new EntitiesCH {data = new CHQ10Entities1("PTTTEntities") , macn = "PTTT"},
            new EntitiesCH {data = new CHQ10Entities1("CHQ10Entities") , macn = "CHQ10"},
            new EntitiesCH {data = new CHQ10Entities1("CHPPSPEntities") , macn = "CHPPSP"},
        };
        // GET: Duuoc
        [ActionName("nhap-du-lieu")]
        public ActionResult Nhapdulieu(int? thang, int? nam)
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            ViewBag.thang = thang;
            ViewBag.nam = nam;
            var data = Duuoc.TBL_PHANQUYEN.SingleOrDefault(n => n.nguoidung == User.Identity.Name).quyen;
            ViewBag.phanquyen = data.Split(',').ToList();
            ViewBag.kenh = Duuoc.TBL_PHANQUYEN.SingleOrDefault(n => n.nguoidung == User.Identity.Name).kenh.Split(',').ToList();
            return View("Nhapdulieu");
        }
        [ActionName("bao-cao")]
        public ActionResult Baocao()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var data = Duuoc.TBL_PHANQUYEN.SingleOrDefault(n => n.nguoidung == User.Identity.Name).quyen;
            ViewBag.phanquyen = data.Split(',').ToList();
            ViewBag.kenh = Duuoc.TBL_PHANQUYEN.SingleOrDefault(n => n.nguoidung == User.Identity.Name).kenh.Split(',').ToList();
            return View("Baocao");
        }
        [ActionName("bao-cao-ton-kho")]
        public ActionResult Baocaotonkho()
        {
            string path = Server.MapPath("~/Content/Inventory updated.xlsx");

            using (var package = new ExcelPackage(new FileInfo(path)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                // Mở workbook và worksheet cần điền dữ liệu
                ExcelWorkbook workbook = package.Workbook;
                //ExcelWorksheet worksheet = workbook.Worksheets["Monthly aging view"];
                ExcelWorksheet worksheet = workbook.Worksheets["Monthly aging view"];
                // Điền dữ liệu vào các ô cần thiết
                //DATA
                var nam = DateTime.Today.AddMonths(-1).Year;
                var thang = DateTime.Today.AddMonths(-1).Month;
                var soso = "HN,PT,TB,TNG,HP,PTTT,HCM,CHQ10,CT,AG,CM,DN,LD,TG,TN,VL,BDG,BT,PY,QN,TT423,BD,DNA,GL,HUE,NA,NT,THO,SC".Split(',').ToList();

                //var data21 = SC.Database.SqlQuery<DATATONKHO>("EXEC sp_INTKHANGHOA_NHAPXUAT_SOLO " + DateTime.Today.Month + "," + DateTime.Today.Year + ",'50,51,60,61,62,63,64,64.PME,64.STA,70,99,40,50.STA,51.STA,60.STA,62.STA','OH'").ToList();
                // Lấy Sheet mà bạn muốn tìm kiếm trong
                var data21 = SC.Database.SqlQuery<TTNHANHTONKHO>("EXEC laythongtintonkho_tatca_tatca_KHO '','" + DateTime.Today.ToString("yyyy/MM/dd") + "'," + DateTime.Today.Month + "," + DateTime.Today.Year + ",'OH'").ToList();
                // Lấy Sheet mà bạn muốn tìm kiếm trong  
                ExcelWorksheet worksheet1 = package.Workbook.Worksheets["On hold"];
                // Lấy cột mà bạn muốn tìm kiếm trong 
                ExcelRange column = worksheet1.Cells["D:D"];
                worksheet1.Cells["E3"].Value = DateTime.Today.ToString("dd/MM/yyyy");
                var data22 = new List<DTA_TONKHO_CHITIET>();
                var tencn = db2.TBL_DANHSACHCHINHANH.ToList();
                //foreach (var i in soso)
                //{
                //    var ten = tencn.FirstOrDefault(o => o.macn == i).Tencn;
                //    if (queryCN.SingleOrDefault(n => n.macn == i) != null)
                //    {

                //        data22.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH" && n.trangthai == 0).Select(n => new DTA_TONKHO_CHITIET() { macn = ten, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                //    }
                //    else if (queryCH.SingleOrDefault(n => n.macn == i) != null)
                //    {
                //        data22.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH" && n.trangthai == 0).Select(n => new DTA_TONKHO_CHITIET() { macn = ten, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                //    }
                //}

                ExcelRange row1 = worksheet1.Cells["N4:AP4"];
                //foreach (var i in data22.GroupBy(n => new { n.mahh, n.macn }).Select(n => new DATATONKHO() { maquay = n.Key.macn,MAHH = n.Key.mahh, SLTON = (decimal)n.Sum(o => o.slton), SLTONHETHAN = n.Where(z => DateTime.ParseExact(z.handung, "ddMMyy", CultureInfo.InvariantCulture) < DateTime.Today).Sum(o => o.slton) }))
                //{
                //    //try
                //    //{
                //    var cell = from cell1 in column
                //               where cell1.Value?.ToString() == i.MAHH
                //               select cell1;
                //    var rowcn = from cell2 in row1
                //                where cell2.Value?.ToString() == i.maquay
                //                select cell2;
                //    if (cell.Count() > 0)
                //    {
                //        worksheet1.Cells[LayChuTrongChuoi(rowcn.First().LocalAddress) + GetNumbers(cell.First().LocalAddress)].Value = i.SLTON;
                //        worksheet1.Cells["N" + GetNumbers(cell.First().LocalAddress)].Value = i.SLTONHETHAN;
                //        // Bạn đã tìm thấy giá trị
                //        Console.WriteLine("Giá trị được tìm thấy tại hàng {0}", GetNumbers(cell.First().LocalAddress));
                //    }
                //    else
                //    {
                //        Console.WriteLine("Không tìm thấy giá trị :" + i.MAHH);
                //    }
                //    //}
                //    //catch(Exception)
                //    //{
                //    //    Console.WriteLine("Lỗi hàng hóa :" + i.MAHH);
                //    //}
                //}
                foreach (var i in data21.GroupBy(n => n.MAHH).Select(n => new DATATONKHO() { MAHH = n.Key, SLTON = n.Sum(o => o.SL_TONCUOIKY2), SLTONHETHAN = n.Where(z => DateTime.ParseExact(z.HANDUNG, "ddMMyy", CultureInfo.InvariantCulture) < DateTime.Today).Sum(o => o.SL_TONCUOIKY2) }))
                {
                    //try
                    //{

                    var cell = from cell1 in column
                               where cell1.Value?.ToString() == i.MAHH
                               select cell1;
                    if (cell.Count() > 0)
                    {
                        worksheet1.Cells["O" + GetNumbers(cell.First().LocalAddress)].Value = i.SLTON;
                        // Bạn đã tìm thấy giá trị
                        worksheet1.Cells["N" + GetNumbers(cell.First().LocalAddress)].Value = Decimal.Parse(worksheet1.Cells["N" + GetNumbers(cell.First().LocalAddress)].Value.ToString()) + i.SLTONHETHAN;
                        Console.WriteLine("Giá trị được tìm thấy tại hàng {0}", GetNumbers(cell.First().LocalAddress));
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy giá trị :" + i.MAHH);
                    }
                    //}
                    //catch(Exception)
                    //{
                    //    Console.WriteLine("Lỗi hàng hóa :" + i.MAHH);
                    //}


                }
                //end sheet on hold 
                //end sheet on hold 
                //sheet on hold
                var str3 = "EXEC laythongtintonkho_tatca_tatca  '','" + DateTime.Today.ToString("MM/dd/yyyy") + "'," + DateTime.Today.Month + "," + DateTime.Today.Year + ",''";

                List<TTNHANHTONKHO> DATAX = new List<TTNHANHTONKHO>();
                foreach (var x in soso)
                {
                    if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                    {
                        var zz = queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<TTNHANHTONKHO>(str3).ToList();
                        DATAX.AddRange(zz);
                    }
                    else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                    {
                        var zz = queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<TTNHANHTONKHO>(str3).ToList();
                        DATAX.AddRange(zz);
                    }
                }
                foreach (var i in data21.GroupBy(n => n.MAHH).Select(n => new DATATONKHO() { MAHH = n.Key, SLTON = n.Sum(o => o.SL_TONCUOIKY2), SLTONHETHAN = n.Where(z => DateTime.ParseExact(z.HANDUNG, "ddMMyy", CultureInfo.InvariantCulture) < DateTime.Today).Sum(o => o.SL_TONCUOIKY2) }))
                {
                    DATAX.SingleOrDefault(n => n.tendvbc == "Supply Chain" && n.MAHH == i.MAHH).SL_TONCUOIKY2 = ((DATAX.SingleOrDefault(n => n.tendvbc == "Supply Chain" && n.MAHH == i.MAHH).SL_TONCUOIKY2 - i.SLTON) >= 0) ? (DATAX.SingleOrDefault(n => n.tendvbc == "Supply Chain" && n.MAHH == i.MAHH).SL_TONCUOIKY2 - i.SLTON) : 0;
                }
                ExcelWorksheet worksheet2 = package.Workbook.Worksheets["Saleables stocks"];
                // Lấy cột mà bạn muốn tìm kiếm trong 
                ExcelRange column2 = worksheet2.Cells["D:D"];
                ExcelRange row2 = worksheet2.Cells["N4:AP4"];
                worksheet2.Cells["E3"].Value = DateTime.Today.ToString("dd/MM/yyyy");
                foreach (var i in DATAX)
                {
                    //try
                    //{
                    var cell = from cell1 in column2
                               where cell1.Value?.ToString() == i.MAHH
                               select cell1;
                    var rowcn = from cell2 in row2
                                where cell2.Value?.ToString() == i.tendvbc
                                select cell2;
                    if (cell.Count() > 0)
                    {
                        worksheet2.Cells[LayChuTrongChuoi(rowcn.First().LocalAddress) + GetNumbers(cell.First().LocalAddress)].Value = i.SL_TONCUOIKY2;
                        // Bạn đã tìm thấy giá trị
                        Console.WriteLine("Giá trị được tìm thấy tại hàng {0}", GetNumbers(cell.First().LocalAddress));
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy giá trị :" + i.MAHH);
                    }
                    //}
                    //catch(Exception)
                    //{
                    //    Console.WriteLine("Lỗi hàng hóa :" + i.MAHH);
                    //}
                }
                //
                var data = new List<DTA_TONKHO_CHITIET>();
                foreach (var i in soso)
                {
                    if (queryCN.SingleOrDefault(n => n.macn == i) != null)
                    {
                        data.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                    else if (queryCH.SingleOrDefault(n => n.macn == i) != null)
                    {
                        data.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                }
                //var data1 = data.GroupBy(n => new { n.mahh, n.solo }).Select(cl => new DTA_TONKHO_CHITIET_HANDUNG() { mahh = cl.Key.mahh, slton = cl.Sum(n => n.slton), handung = (cl.Where(n => n.macn == "SC").Select(n => n.handung).Distinct().Count() == 1) ? cl.Where(n => n.macn == "SC").First().handung : string.Join(",", cl.Select(n => n.handung).Distinct().Select(p => p)) }).ToList();
                var data1 = data.GroupBy(n => new { n.mahh, n.solo }).Select(cl => new DTA_TONKHO_CHITIET_HANDUNG() { mahh = cl.Key.mahh, slton = cl.Sum(n => n.slton), handung = (cl.Where(n => n.macn == "SC").Select(n => n.handung).Distinct().Count() == 1) ? cl.Where(n => n.macn == "SC").First().handung : cl.First().handung }).ToList();
                data1 = data.GroupBy(n => new { n.mahh, n.handung }).Select(cl => new DTA_TONKHO_CHITIET_HANDUNG() { mahh = cl.Key.mahh, slton = cl.Sum(n => n.slton), handung = cl.Key.handung }).ToList();
                worksheet.InsertRow(6, data1.Count() - 1);
                var dem = 2;
                var data2 = new List<DTA_TONKHO_CHITIET_HANDUNG>();
                //foreach (var i in data1)
                //{
                //    try
                //    {
                //       var ngay = DateTime.ParseExact(i.handung, "ddMMyy", CultureInfo.InvariantCulture);
                //      //data2.Add(new DTA_TONKHO_CHITIET_HANDUNG() {mahh = i.mahh , slton = i.slton ,  })
                //    }
                //    catch(Exception)
                //    {
                //        worksheet.Cells["D" + (4 + dem)].Value = i.handung;
                //    }
                //    worksheet.Cells["C" + (4 + dem)].Value = i.mahh;

                //    dem = dem + 1;
                //}
                var hanghoa = SC.TBL_DANHMUCHANGHOA.ToList();
                var ngaytinh = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1);
                worksheet.Cells["A1"].Value = ngaytinh.ToString("dd/MM/yyyy");
                foreach (var i in data1)
                {
                    try
                    {
                        var ngay = DateTime.ParseExact(i.handung, "ddMMyy", CultureInfo.InvariantCulture);
                        worksheet.Cells["D" + (3 + dem)].Value = ngay.ToString("dd/MM/yyyy");
                        var timespan = (ngay - ngaytinh).TotalDays / 30.0;
                        if (timespan > 0 && timespan <= 3)
                        {
                            worksheet.Cells["E" + (3 + dem)].Value = i.slton;
                        }
                        else if (timespan > 3 && timespan <= 6)
                        {
                            worksheet.Cells["F" + (3 + dem)].Value = i.slton;
                        }
                        else if (timespan > 6 && timespan <= 9)
                        {
                            worksheet.Cells["G" + (3 + dem)].Value = i.slton;
                        }
                        else if (timespan > 9 && timespan <= 12)
                        {
                            worksheet.Cells["H" + (3 + dem)].Value = i.slton;
                        }
                        else if (timespan > 12 && timespan <= 15)
                        {
                            worksheet.Cells["I" + (3 + dem)].Value = i.slton;
                        }
                        else if (timespan > 15 && timespan <= 18)
                        {
                            worksheet.Cells["J" + (3 + dem)].Value = i.slton;
                        }
                        else if (timespan > 18)
                        {
                            worksheet.Cells["K" + (3 + dem)].Value = i.slton;
                        }
                        worksheet.Cells["L" + (3 + dem)].Value = i.slton;
                    }
                    catch (Exception)
                    {
                        worksheet.Cells["D" + (3 + dem)].Value = i.handung;
                    }
                    worksheet.Cells["A" + (3 + dem)].Value = (hanghoa.SingleOrDefault(n => n.MAHH == i.mahh) != null) ? hanghoa.SingleOrDefault(n => n.MAHH == i.mahh).TENHH : "";

                    worksheet.Cells["C" + (3 + dem)].Value = i.mahh;
                    var cell = from cell1 in column2
                               where cell1.Value?.ToString() == i.mahh
                               select cell1;

                    if (cell.Count() > 0)
                    {
                        worksheet.Cells["B" + (3 + dem)].Value = worksheet2.Cells["B" + GetNumbers(cell.First().LocalAddress)].Value;
                        // Bạn đã tìm thấy giá trị
                        Console.WriteLine("Giá trị được tìm thấy tại hàng {0}", GetNumbers(cell.First().LocalAddress));
                    }
                    worksheet.Cells["C" + (3 + dem)].Style.Numberformat.Format = "@";
                    dem = dem + 1;
                }
                worksheet.Cells["E" + (3 + dem)].Formula = "=SUM(E5:E" + (dem + 2) + ")";
                worksheet.Cells["F" + (3 + dem)].Formula = "=SUM(F5:F" + (dem + 2) + ")";
                worksheet.Cells["G" + (3 + dem)].Formula = "=SUM(G5:G" + (dem + 2) + ")";
                worksheet.Cells["H" + (3 + dem)].Formula = "=SUM(H5:H" + (dem + 2) + ")";
                worksheet.Cells["I" + (3 + dem)].Formula = "=SUM(I5:I" + (dem + 2) + ")";
                worksheet.Cells["J" + (3 + dem)].Formula = "=SUM(J5:J" + (dem + 2) + ")";
                worksheet.Cells["K" + (3 + dem)].Formula = "=SUM(K5:K" + (dem + 2) + ")";
                worksheet.Cells["L" + (3 + dem)].Formula = "=SUM(L5:L" + (dem + 2) + ")";
                // Lưu lại file Excel
                //sheet on hold
                ExcelRange range = worksheet.Cells["A3:" + "L" + (3 + dem)]; // Apply borders to the range 
                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ///
                //
                using (var memoryStream = new MemoryStream())
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment; filename=Inventory updated " + DateTime.Today.ToString("dd-MM-yyyy") + ".xlsx");
                    package.SaveAs(memoryStream);
                    memoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
                //Response.AddHeader("content-disposition", "attachment; filename=Inventory updated " + DateTime.Today.ToString("dd-MM-yyyy") + ".xlsx");
                //package.SaveAs("C:\\fileexcel\\file.xlsx");
            }
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.quyen = Info.quyen;
            ViewBag.ten = Info.hoten;
            ViewBag.phanquyen = Duuoc.TBL_CHITIETPHANQUYEN.ToList();
            return View("Baocaotonkho");
        }
        public string LayChuTrongChuoi(string chuoi) { string chu = ""; foreach (char kyTu in chuoi) { if (char.IsLetter(kyTu)) { chu += kyTu; } } return chu; }
        public static string GetNumbers(string input)
        {
            string pattern = @"\d+"; // Mẫu để tìm các số trong chuỗi 
            string numbers = "";
            foreach (Match match in Regex.Matches(input, pattern))
            { numbers += match.Value; }
            return numbers;
        }
        [Authorize(Roles = "QLDUUOC")]
        [ActionName("quan-ly-nguoi-dung")]
        public ActionResult Quanlynguoidung()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.quyen = Info.quyen;
            ViewBag.ten = Info.hoten;
            ViewBag.phanquyen = Duuoc.TBL_CHITIETPHANQUYEN.ToList();
            ViewBag.kenh = Duuoc.TBL_KENH.ToList();
            var data = Duuoc.TBL_PHANQUYEN.ToList();
            return View("Quanlynguoidung", data);
        }
        [HttpPost]
        public ActionResult PartialQLND()
        {
            var Info = GetInfo();
            var data = Duuoc.TBL_PHANQUYEN.ToList();
            return PartialView(data);
        }
        [HttpPost]
        public JsonResult GetviewQLND(string nguoidung)
        {
            var data = Duuoc.TBL_PHANQUYEN.SingleOrDefault(n => n.nguoidung == nguoidung);
            return Json(data);
        }

        [HttpPost]
        public JsonResult EditQLND(string nguoidung, List<string> kenh, List<string> phanquyen)
        {
            string kenh1 = "";
            foreach (var item in kenh)
            {
                kenh1 = kenh1 + ',' + item;
            }
            kenh1 = kenh1.Substring(1);
            string phanquyen1 = "";
            foreach (var item in phanquyen)
            {
                phanquyen1 = phanquyen1 + ',' + item;
            }
            phanquyen1 = phanquyen1.Substring(1);
            var tv = Duuoc.TBL_PHANQUYEN.SingleOrDefault(n => n.nguoidung == nguoidung);
            if (tv != null)
            {
                tv.kenh = kenh1;
                tv.quyen = phanquyen1;
                Duuoc.SaveChanges();
            }
            else
            {
                return Json(0);
            }
            return Json(1);
        }
        [HttpPost]

        public ActionResult Checkimportdulieu(int thang, int nam, int bang, string kenh)
        {
            //var Info = GetInfo();
            var user = GetInfo();
            var count = 0;

            if (bang == 1)
            {
                var tv = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.nguoitao == User.Identity.Name && n.kenh == kenh).ToList();
                if (tv.Count == 0)
                {
                    return Json("0");
                }
                else
                {
                    if (tv.First().khoa == true)
                    {
                        return Json("2");
                    }
                    else
                    {
                        return Json("1");
                    }
                }
            }
            else if (bang == 2)
            {
                var tv = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.nguoitao == User.Identity.Name && n.kenh == kenh).ToList();
                if (tv.Count == 0)
                {
                    return Json("0");
                }
                else
                {
                    if (tv.First().khoa == true)
                    {
                        return Json("2");
                    }
                    else
                    {
                        return Json("1");
                    }
                }
            }

            else if (bang == 3)
            {
                var tv = Duuoc.TBL_SCAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.nguoitao == User.Identity.Name).ToList();
                if (tv.Count == 0)
                {
                    return Json("0");
                }
                else
                {
                    if (tv.First().khoa == true)
                    {
                        return Json("2");
                    }
                    else
                    {
                        return Json("1");
                    }
                }
            }
            else
            {
                var tv = Duuoc.TBL_QLSXAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.nguoitao == User.Identity.Name).ToList();
                if (tv.Count == 0)
                {
                    return Json("0");
                }
                else
                {
                    if (tv.First().khoa == true)
                    {
                        return Json("2");
                    }
                    else
                    {
                        return Json("1");
                    }
                }
            }
        }
        [HttpPost]
        public ActionResult Importdulieu(List<TBL_DEMANDFC> data, int bang, string kenh, int thangduuoc, int namduuoc)
        {
            if (data != null)
            {
                foreach (var i in data)
                {
                    i.thangduuoc = thangduuoc;
                    i.namduuoc = namduuoc;
                }
                if (bang != 3)
                {
                    List<TBL_DEMANDFC> duplicates = data.GroupBy(x => new { x.thangduuoc, x.namduuoc, x.thang, x.nam, x.mahh, x.kenh, x.sub }).SelectMany(g => g.Skip(1)).ToList();
                    var errortext = "Các mã dữ liệu trong file excel (Format tháng - năm - mã hàng - kênh) :";
                    foreach (var i in duplicates)
                    {
                        errortext = errortext + "[" + i.thang + " - " + i.nam + " - " + i.mahh + " - " + i.kenh + "]";
                    }
                    if (duplicates.Count != 0)
                    {
                        errortext = errortext + ". Vui lòng kiểm tra lại, hoặc gộp lại.";
                        return Json(errortext);
                    }
                }

                foreach (var i in data)
                {
                    i.khoa = false;
                    i.ngaytao = DateTime.Now;
                    i.nguoitao = User.Identity.Name;
                    i.soluong = (i.soluong != null) ? i.soluong : 0;
                    i.sotien = (i.sotien != null) ? i.sotien : 0;
                    i.sub = (i.sub != null) ? i.sub : "";
                    if (bang == 1)
                    {
                        i.trangthai = false;
                    }
                }

                if (bang == 1)
                {
                    Duuoc.TBL_DEMANDFC.AddRange(data);
                }
                else if (bang == 3)
                {
                    var datasc = data.GroupBy(n => new { n.mahh, n.nam, n.thang, n.thangduuoc, n.namduuoc }).Select(n => new TBL_SCAPPROVE() { khoa = n.First().khoa, mahh = n.Key.mahh, nam = n.Key.nam, namduuoc = n.Key.namduuoc, ngayketthucthau = n.First().ngayketthucthau, ngaytao = n.First().ngaytao, nguoitao = n.First().nguoitao, soluong = n.Sum(cl => cl.soluong), sotien = n.Sum(cl => cl.sotien), thang = n.Key.thang, thangduuoc = n.Key.thangduuoc });
                    Duuoc.TBL_SCAPPROVE.AddRange(datasc);
                    var data1 = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thangduuoc && n.namduuoc == namduuoc).ToList();
                    foreach (var item in data1)
                    {
                        item.khoa = true;
                    }
                }
                else if (bang == 4)
                {
                    var dataqlsx = data.Select(n => new TBL_QLSXAPPROVE() { khoa = n.khoa, ngayketthucthau = n.sub, mahh = n.mahh, nam = n.nam, namduuoc = n.namduuoc, ngaytao = n.ngaytao, nguoitao = n.nguoitao, soluong = n.soluong, sotien = n.sotien, thang = n.thang, thangduuoc = n.thangduuoc });
                    Duuoc.TBL_QLSXAPPROVE.AddRange(dataqlsx);
                    var data1 = Duuoc.TBL_SCAPPROVE.Where(n => n.thangduuoc == thangduuoc && n.namduuoc == namduuoc).ToList();
                    foreach (var item in data1)
                    {
                        item.khoa = true;
                    }
                }
                Duuoc.SaveChanges();
                return Json("1");
            }
            else
            {
                return Json("1");
            }

        }
        [HttpPost]

        public ActionResult Deletedulieu(int thang, int nam, int bang, string kenh)
        {
            //var Info = GetInfo();
            if (bang == 1)
            {
                var tv = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh).ToList();
                Duuoc.TBL_DEMANDFC.RemoveRange(tv);
                Duuoc.SaveChanges();
            }
            else if (bang == 2)
            {
                var tv = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh).ToList();
                Duuoc.TBL_SALEAPPROVE.RemoveRange(tv);
                Duuoc.SaveChanges();
            }
            else if (bang == 3)
            {
                var tv = Duuoc.TBL_SCAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList();
                Duuoc.TBL_SCAPPROVE.RemoveRange(tv);
                Duuoc.SaveChanges();
            }
            else if (bang == 4)
            {
                var tv = Duuoc.TBL_QLSXAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList();
                Duuoc.TBL_QLSXAPPROVE.RemoveRange(tv);
                Duuoc.SaveChanges();
            }
            return Json("1");
        }
        public ActionResult Deletedulieuapprove(int thang, int nam, int bang, string kenh)
        {
            //var Info = GetInfo();
            if (bang == 1)
            {
                var tv = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh).ToList();
                Duuoc.TBL_SALEAPPROVE.RemoveRange(tv);
                Duuoc.SaveChanges();
            }
            else if (bang == 2)
            {
                var tv = Duuoc.TBL_SCAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList();
                Duuoc.TBL_SCAPPROVE.RemoveRange(tv);
                Duuoc.SaveChanges();
            }
            else if (bang == 3)
            {
                var tv = Duuoc.TBL_QLSXAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList();
                Duuoc.TBL_QLSXAPPROVE.RemoveRange(tv);
                Duuoc.SaveChanges();
            }
            //else if (bang == 4)
            //{
            //    var tv = Duuoc.TBL_QLSXAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList();
            //    Duuoc.TBL_QLSXAPPROVE.RemoveRange(tv);
            //    Duuoc.SaveChanges();
            //}





            return Json("1");
        }
        [HttpPost]

        public ActionResult Xemdulieu(int thang, int nam, int bang, string kenh)
        {
            //var Info = GetInfo();
            ViewBag.thang = thang;
            ViewBag.nam = nam;
            var hanghoa = SC.TBL_DANHMUCHANGHOA.ToList();
            if (bang == 1)
            {
                var data = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.nguoitao == User.Identity.Name && n.kenh == kenh).ToList();
                foreach (var i in data)
                {
                    i.nguoitao = (hanghoa.SingleOrDefault(n => n.MAHH == i.mahh) != null) ? hanghoa.SingleOrDefault(n => n.MAHH == i.mahh).TENHH : "";
                }
                return PartialView(data);
            }
            else if (bang == 2)
            {
                var data = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.nguoitao == User.Identity.Name && n.kenh == kenh).ToList();
                foreach (var i in data)
                {
                    i.nguoitao = (hanghoa.SingleOrDefault(n => n.MAHH == i.mahh) != null) ? hanghoa.SingleOrDefault(n => n.MAHH == i.mahh).TENHH : "";
                }
                return PartialView("Xemdulieu2", data);
            }
            else if (bang == 3)
            {
                var data = Duuoc.TBL_SCAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.nguoitao == User.Identity.Name).ToList();
                foreach (var i in data)
                {
                    i.nguoitao = (hanghoa.SingleOrDefault(n => n.MAHH == i.mahh) != null) ? hanghoa.SingleOrDefault(n => n.MAHH == i.mahh).TENHH : "";
                }
                return PartialView("Xemdulieu3", data);
            }
            else
            {
                var data = Duuoc.TBL_QLSXAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.nguoitao == User.Identity.Name).ToList();
                foreach (var i in data)
                {
                    i.nguoitao = (hanghoa.SingleOrDefault(n => n.MAHH == i.mahh) != null) ? hanghoa.SingleOrDefault(n => n.MAHH == i.mahh).TENHH : "";
                }
                return PartialView("Xemdulieu4", data);
            }
        }

        [HttpPost]
        public JsonResult Checkdulieu(int thang, int nam, int bang, string kenh)
        {
            if (bang == 1)
            {
                var data = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.nguoitao == User.Identity.Name && n.kenh == kenh).ToList();
                if (data.Count != 0)
                {
                    if (data.First().trangthai == true)
                    {
                        return Json(1);
                    }
                    else
                    {
                        return Json(2);
                    }
                }
                else
                {
                    return Json(0);
                }

            }
            else
            {
                return Json(0);
            }
        }
        [HttpPost]
        public JsonResult Guidulieu(int thang, int nam, int bang, string kenh)
        {
            if (bang == 1)
            {
                var data = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.nguoitao == User.Identity.Name && n.kenh == kenh).ToList();
                if (data.First().khoa == false)
                {
                    foreach (var i in data)
                    {
                        i.trangthai = true;
                    }
                    Duuoc.SaveChanges();
                    return Json(1);
                }
                else
                {
                    return Json(2);
                }

            }
            else
            {
                return Json(0);
            }
        }
        [ActionName("quan-ly-du-uoc")]
        public ActionResult Quanlyduuoc()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            var data = Duuoc.TBL_PHANQUYEN.SingleOrDefault(n => n.nguoidung == User.Identity.Name).quyen;
            ViewBag.phanquyen = data.Split(',').ToList();
            ViewBag.kenh = Duuoc.TBL_PHANQUYEN.SingleOrDefault(n => n.nguoidung == User.Identity.Name).kenh.Split(',').ToList();
            return View("Quanlyduuoc");
        }
        [HttpPost]
        public ActionResult PartialQLDUtrangthai(int thang, int nam, int bang, string kenh)
        {
            var Info = GetInfo();
            var data1 = Duuoc.TBL_PHANQUYEN.SingleOrDefault(n => n.nguoidung == User.Identity.Name).quyen;
            ViewBag.phanquyen = data1.Split(',').ToList();
            if (bang == 1)
            {
                var data = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh && n.trangthai == true).ToList().GroupBy(n => new { n.thangduuoc, n.namduuoc, n.nguoitao }).Select(n => new TBL_DEMANDFC() { ngaytao = n.First().ngaytao, nguoitao = n.Key.nguoitao, kenh = string.Join(",", n.Select(z => z.kenh).Distinct()), khoa = n.First().khoa }).ToList();
                return PartialView("PartialQLDUtrangthai1", data);
            }
            else if (bang == 2)
            {
                var data = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh).ToList().GroupBy(n => new { n.thangduuoc, n.namduuoc, n.nguoitao }).Select(n => new TBL_SALEAPPROVE() { ngaytao = n.First().ngaytao, nguoitao = n.Key.nguoitao, kenh = string.Join(",", n.Select(z => z.kenh).Distinct()), khoa = n.First().khoa }).ToList();
                return PartialView("PartialQLDUtrangthai2", data);
            }
            else if (bang == 3)
            {
                var data = Duuoc.TBL_SCAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList().GroupBy(n => new { n.thangduuoc, n.namduuoc, n.nguoitao }).Select(n => new TBL_SCAPPROVE() { ngaytao = n.First().ngaytao, nguoitao = n.Key.nguoitao, khoa = n.First().khoa }).ToList();
                return PartialView("PartialQLDUtrangthai3", data);
            }
            else
            {
                var data = Duuoc.TBL_QLSXAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList().GroupBy(n => new { n.thangduuoc, n.namduuoc, n.nguoitao }).Select(n => new TBL_QLSXAPPROVE() { ngaytao = n.First().ngaytao, nguoitao = n.Key.nguoitao, khoa = n.First().khoa }).ToList();
                return PartialView("PartialQLDUtrangthai4", data);
            }
        }
        [HttpPost]
        public ActionResult ActionKhoa(int thang, int nam, int bang, string kenh, bool khoa)
        {
            var Info = GetInfo();
            if (bang == 1)
            {
                var data = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh && n.trangthai == true).ToList();
                foreach (var item in data)
                {
                    item.khoa = khoa;
                }
                Duuoc.SaveChanges();
                return Json(1);
            }
            else if (bang == 2)
            {
                var data = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList();
                foreach (var item in data)
                {
                    item.khoa = khoa;
                }
                Duuoc.SaveChanges();
                return Json(1);
            }
            else if (bang == 3)
            {
                var data = Duuoc.TBL_SCAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList();
                foreach (var item in data)
                {
                    item.khoa = khoa;
                }
                Duuoc.SaveChanges();
                return Json(1);
            }
            else if (bang == 4)
            {
                var data = Duuoc.TBL_QLSXAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList();
                foreach (var item in data)
                {
                    item.khoa = khoa;
                }
                Duuoc.SaveChanges();
                return Json(1);
            }
            {
                return Json(0);
            }

        }
        [HttpPost]
        public ActionResult PartialQLDUchitiet(int thang, int nam, int bang, string kenh)
        {
            ViewBag.thang = thang;
            ViewBag.nam = nam;
            var hanghoa = SC.TBL_DANHMUCHANGHOA.ToList();
            var data1 = Duuoc.TBL_PHANQUYEN.SingleOrDefault(n => n.nguoidung == User.Identity.Name).quyen;
            ViewBag.phanquyen = data1.Split(',').ToList();
            if (bang == 1)
            {
                var data = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh && n.trangthai == true).ToList();
                foreach (var i in data)
                {
                    i.nguoitao = (hanghoa.SingleOrDefault(n => n.MAHH == i.mahh) != null) ? hanghoa.SingleOrDefault(n => n.MAHH == i.mahh).TENHH : "";
                }
                var dataaprove = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh).ToList();
                if (data[0].khoa == true && dataaprove.Count() > 0)
                {
                    ViewBag.approve = 1;
                }
                else
                {
                    ViewBag.approve = 0;
                }
                return PartialView("PartialQLDUchitiet1", data);
            }
            else if (bang == 2)
            {
                var listkenh = Duuoc.TBL_PHANQUYEN.SingleOrDefault(n => n.nguoidung == User.Identity.Name).kenh.Split(',').ToList();
                var data = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && listkenh.Contains(n.kenh)).ToList();
                foreach (var i in data)
                {
                    i.nguoitao = (hanghoa.SingleOrDefault(n => n.MAHH == i.mahh) != null) ? hanghoa.SingleOrDefault(n => n.MAHH == i.mahh).TENHH : "";
                }
                return PartialView("PartialQLDUchitiet2", data);
            }
            else if (bang == 3)
            {
                var data = Duuoc.TBL_SCAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList();
                foreach (var i in data)
                {
                    i.nguoitao = (hanghoa.SingleOrDefault(n => n.MAHH == i.mahh) != null) ? hanghoa.SingleOrDefault(n => n.MAHH == i.mahh).TENHH : "";
                }
                //var data = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList()	
                //    .GroupBy(n => new { n.mahh })	
                //    .Select(n => new TBL_SCAPPROVE() { thangduuoc = thang, namduuoc = nam, thang = n.First().thang, nam = n.First().nam,	
                //                                        mahh = n.Key.mahh, soluong = n.Sum(m => m.soluong), sotien = n.Sum(m => m.sotien)}).ToList();	
                if (data1 == "PRODUCTAPPROVE")
                {
                    return PartialView("PartialQLDUchitiet3", data);
                }
                else
                {
                    return PartialView("PartialQLDUchitiet31", data);
                }
            }
            else
            {
                var data = Duuoc.TBL_QLSXAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList();
                foreach (var i in data)
                {
                    i.nguoitao = (hanghoa.SingleOrDefault(n => n.MAHH == i.mahh) != null) ? hanghoa.SingleOrDefault(n => n.MAHH == i.mahh).TENHH : "";
                }
                return PartialView("PartialQLDUchitiet4", data);
            }
        }
        [HttpPost]
        public JsonResult Progress(int thang, int nam, string kenh)
        {
            ViewBag.thang = thang;
            ViewBag.nam = nam;
            var Info = GetInfo();
            var progress = 0;
            var i1 = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList();
            var i2 = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList();
            var checkkenh = i2.Select(n => n.khoa).Distinct().ToList();
            var i3 = Duuoc.TBL_SCAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.khoa == false).ToList();
            var i4 = Duuoc.TBL_QLSXAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList();
            if (i4.Count() > 0)
            {
                if (i4.FirstOrDefault().khoa == true)
                {
                    progress = 5;
                }
                else
                {
                    progress = 4;
                }

            }
            else if (i3.Count() > 0)
            {
                progress = 3;
            }
            else if (checkkenh.Count() == 4)
            {
                progress = 2;
            }
            else if (i1.Count() > 0)
            {
                progress = 1;
            }

            return Json(progress);
        }
        [HttpPost]
        public JsonResult CheckKenhSC(int thang, int nam)
        {
            ViewBag.thang = thang;
            ViewBag.nam = nam;
            var Info = GetInfo();
            var kenh = new List<String>();
            var DKSH = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == "DKSH").ToList();
            var EXPORT = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == "EXPORT").ToList();
            var PYPHARM = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == "PYPHARM").ToList();
            var RxBU = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == "Rx BU").ToList();
            var CHCBU = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == "CHC BU").ToList();
            if (DKSH.Count == 0)
            {
                kenh.Add("DKSH");
            }
            if (EXPORT.Count == 0)
            {
                kenh.Add("EXPORT");
            }
            if (PYPHARM.Count == 0)
            {
                kenh.Add("PYPHARM");
            }
            if (RxBU.Count == 0)
            {
                kenh.Add("Rx BU");
            }
            if (CHCBU.Count == 0)
            {
                kenh.Add("CHC BU");
            }
            if (kenh.Count == 0)
            {
                return Json(0);
            }
            else
            {
                return Json(kenh);
            }
        }
        [HttpPost]
        public JsonResult SendMail(int thang, int nam, int bang, string kenh)
        {
            var banghoanthanh = "";
            var trangthai = "";
            var nguoiduyet = "";
            var nguoinhan = new List<String>();
            if (bang == 1)
            {
                var data1 = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh && n.trangthai == true && n.khoa == true).Select(n => n.nguoitao).Distinct().ToList();
                nguoiduyet = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToLower() == User.Identity.Name.ToLower()).hoten;
                trangthai = "PHÊ DUYỆT";
                foreach (var item in data1)
                {
                    var dataper = db2.TBL_DANHMUCNGUOIDUNG.First(n => n.nguoidung.ToLower() == item.ToLower());
                    nguoinhan.Add(dataper.email);
                }
                banghoanthanh = "ROLLING FORECAST PROPOSAL";
            }
            else if (bang == 2)
            {
                var data1 = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh && n.trangthai == true && n.khoa == true).Select(n => n.nguoitao).Distinct().ToList();
                var data2 = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh && n.khoa == true).Select(n => n.nguoitao).Distinct().ToList();
                nguoiduyet = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToLower() == User.Identity.Name.ToLower()).hoten;
                trangthai = "XÁC NHẬN";
                foreach (var item in data1)
                {
                    var dataper = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToLower() == item.ToLower());
                    nguoinhan.Add(dataper.email);
                }
                foreach (var item in data2)
                {
                    var dataper = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToLower() == item.ToLower());
                    nguoinhan.Add(dataper.email);
                }
                banghoanthanh = "ROLLING FORECAST APPROVAL";
            }
            else if (bang == 3)
            {
                var data1 = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh && n.trangthai == true && n.khoa == true).Select(n => n.nguoitao).Distinct().ToList();
                var data2 = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh && n.khoa == true).Select(n => n.nguoitao).Distinct().ToList();
                var data3 = Duuoc.TBL_SCAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.khoa == true).Select(n => n.nguoitao).Distinct().ToList();
                nguoiduyet = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToLower() == User.Identity.Name.ToLower()).hoten;
                trangthai = "XÁC NHẬN";
                foreach (var item in data1)
                {
                    var dataper = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToLower() == item.ToLower());
                    nguoinhan.Add(dataper.email);
                }

                foreach (var item in data2)
                {
                    var dataper = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToLower() == item.ToLower());
                    nguoinhan.Add(dataper.email);
                }

                foreach (var item in data3)
                {
                    var dataper = db2.TBL_DANHMUCNGUOIDUNG.First(n => n.nguoidung.ToLower() == item.ToLower());
                    nguoinhan.Add(dataper.email);
                }
                banghoanthanh = "NET SUPPLY REQUIREMENT";
            }
            else
            {
                var data1 = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh && n.trangthai == true && n.khoa == true).Select(n => n.nguoitao).Distinct().ToList();
                var data2 = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh && n.khoa == true).Select(n => n.nguoitao).Distinct().ToList();
                var data3 = Duuoc.TBL_SCAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.khoa == true).Select(n => n.nguoitao).Distinct().ToList();
                var data4 = Duuoc.TBL_QLSXAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.khoa == true).Select(n => n.nguoitao).Distinct().ToList();
                nguoiduyet = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToLower() == User.Identity.Name.ToLower()).hoten;
                trangthai = "XÁC NHẬN";
                foreach (var item in data1)
                {
                    var dataper = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToLower() == item.ToLower());
                    nguoinhan.Add(dataper.email);
                }

                foreach (var item in data2)
                {
                    var dataper = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToLower() == item.ToLower());
                    nguoinhan.Add(dataper.email);
                }

                foreach (var item in data3)
                {
                    var dataper = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToLower() == item.ToLower());
                    nguoinhan.Add(dataper.email);
                }

                foreach (var item in data4)
                {
                    var dataper = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToLower() == item.ToLower());
                    nguoinhan.Add(dataper.email);
                }
                banghoanthanh = "PRODUCTION PLANNING APPROVAL";
            }
            //var html = "<div style='width:100%;padding:15px;'><a href='https://pymepharco.com'><img style='margin-left:auto;margin-right: auto;display: block; height: 80px;' alt = 'logo2' src=\"data:image/png;base64,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\"></a><center style='width:100%;min-width:600px'><table style='border-spacing:0;border-collapse:collapse;vertical-align:top;text-align:left;padding:0'><tbody><tr style='vertical-align:top;text-align:left;padding:0'><br><td class='m_6291312848774364587container-row' style='width: 600px; overflow-wrap: break-word; vertical-align: top; text-align: left; font-family: Helvetica, Arial, sans-serif; line-height: 150%; font-size: 16px; word-break: break-word; margin: 0px 0px 12px; padding: 0px 8px; border-collapse: collapse !important;'><hr style='font-weight: normal; color: rgb(0, 0, 0); margin: 0px; border: 1px solid rgb(221, 221, 221);'><br><font color='#000000' style='font-weight: normal;'>Xin chào,</font><br><p style='font-family: Helvetica, Arial, sans-serif; text-align: left; line-height: 150%; font-size: 16px; margin: 0px 0px 10px; padding: 0px;'><span><font color='#397b21'></span><br><span style='font-weight: normal; color: rgb(0, 0, 0);'>Bảng <b>" + banghoanthanh + "</b> tháng " + thang + " năm " + nam + " đã được " + trangthai + " bởi " + nguoiduyet + " </span></p></td></tr></tbody><tbody><tr style='vertical-align:top;text-align:left;padding:0'><td style='overflow-wrap: break-word; vertical-align: top; text-align: left; color: rgb(0, 0, 0); font-family: Helvetica, Arial, sans-serif; line-height: 150%; font-size: 16px; word-break: break-word; margin: 0px; padding: 0px; border-collapse: collapse !important;'> <br><hr style='font-weight: normal; color: rgb(0, 0, 0); margin: 0px; border: 1px solid rgb(221, 221, 221);'> <p style='font-weight: normal;'>Trân trọng.</p><p style=''><b>Pymepharco</b></p></td></tr></tbody></table></center></div>";
            //MailMessage mail = new MailMessage();
            //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            //mail.From = new MailAddress("gatewaypymepharco@gmail.com");
            //foreach (var item in nguoinhan)
            //{

            //    mail.To.Add(item);

            //}
            //mail.Subject = Sanitizer.GetSafeHtmlFragment("[" + trangthai + "] Bảng " + banghoanthanh + " tháng " + thang + " năm " + nam);
            //mail.IsBodyHtml = true;
            //mail.Body = html;
            //SmtpServer.Port = 587;
            //SmtpServer.Credentials = new System.Net.NetworkCredential("gatewaypymepharco@gmail.com", "aavgvkptivazfffi");
            //SmtpServer.EnableSsl = true;
            //SmtpServer.Send(mail);
            return Json(1);
        }
        public ActionResult Reject(int thang, int nam, int bang, string kenh, string lydo)
        {
            var Info = GetInfo();
            var nguoinhan = new List<String>();
            var nguoihuy = User.Identity.Name;

            if (bang == 1)
            {
                var data = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh && n.trangthai == true && n.khoa == false).Select(n => n.nguoitao).Distinct().ToList();
                foreach (var item in data)
                {
                    var data2 = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToLower() == item.ToLower());
                    nguoinhan.Add(data2.email);
                }
                var data1 = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh && n.trangthai == true && n.khoa == false).ToList();
                foreach (var item in data1)
                {
                    item.trangthai = false;
                }
                Duuoc.SaveChanges();
            }
            //else if (bang == 2)
            //{
            //    var data = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh && n.khoa == false).Select(n => n.nguoitao).Distinct().ToList();
            //    foreach (var item in data)
            //    {
            //        var data2 = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToLower() == item.ToLower());
            //        nguoinhan.Add(data2.email);
            //        tieude = "Reject bảng Sales Approve";
            //    }
            //    var data3 = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh && n.trangthai == true && n.khoa == true).ToList();
            //    foreach (var item in data3)
            //    {
            //        item.khoa = false;
            //    }
            //    Duuoc.SaveChanges();
            //}
            //else if (bang == 3)
            //{
            //    var data = Duuoc.TBL_SCAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.khoa == false).Select(n => n.nguoitao).Distinct().ToList();
            //    foreach (var item in data)
            //    {
            //        var data2 = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToLower() == item.ToLower());
            //        nguoinhan.Add(data2.email);
            //        tieude = "Reject bảng Supply Chain Approve";
            //    }
            //}
            //else
            //{
            //    var data = Duuoc.TBL_QLSXAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.khoa == false).Select(n => n.nguoitao).Distinct().ToList();
            //    foreach (var item in data)
            //    {
            //        var data2 = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung.ToLower() == item.ToLower());
            //        nguoinhan.Add(data2.email);
            //        tieude = "Reject bảng Production Planning Approve";
            //    }
            //}
            //var html = "<div style='width:100%;padding:15px;'><a href='https://pymepharco.com'><img style='margin-left:auto;margin-right: auto;display: block; height: 80px;' alt = 'logo2' src=\"data:image/png;base64,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\"></a><center style='width:100%;min-width:600px'><table style='border-spacing:0;border-collapse:collapse;vertical-align:top;text-align:left;padding:0'><tbody><tr style='vertical-align:top;text-align:left;padding:0'><br><td class='m_6291312848774364587container-row' style='width: 600px; overflow-wrap: break-word; vertical-align: top; text-align: left; font-family: Helvetica, Arial, sans-serif; line-height: 150%; font-size: 16px; word-break: break-word; margin: 0px 0px 12px; padding: 0px 8px; border-collapse: collapse !important;'><hr style='font-weight: normal; color: rgb(0, 0, 0); margin: 0px; border: 1px solid rgb(221, 221, 221);'><br><font color='#000000' style='font-weight: normal;'>Xin chào,</font><br><p style='font-family: Helvetica, Arial, sans-serif; text-align: left; line-height: 150%; font-size: 16px; margin: 0px 0px 10px; padding: 0px;'><span><font color='#397b21'></span><br><span style='font-weight: normal; color: rgb(0, 0, 0);'>Bảng <b>ROLLING FORECAST PROPOSAL</b> tháng " + thang + " năm " + nam + " đã bị từ chối bởi " + nguoihuy + " </span><br><span style='font-weight: normal; color: rgb(0, 0, 0);'>Lý do từ chối: <b> " + lydo + " </b> </span></p></td></tr></tbody><tbody><tr style='vertical-align:top;text-align:left;padding:0'><td style='overflow-wrap: break-word; vertical-align: top; text-align: left; color: rgb(0, 0, 0); font-family: Helvetica, Arial, sans-serif; line-height: 150%; font-size: 16px; word-break: break-word; margin: 0px; padding: 0px; border-collapse: collapse !important;'> <br><hr style='font-weight: normal; color: rgb(0, 0, 0); margin: 0px; border: 1px solid rgb(221, 221, 221);'> <p style='font-weight: normal;'>Trân trọng.</p><p style=''><b>Pymepharco</b></p></td></tr></tbody></table></center></div>";
            //if (nguoinhan.Count != 0)
            //{
            //    MailMessage mail = new MailMessage();
            //    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            //    mail.From = new MailAddress("gatewaypymepharco@gmail.com");
            //    foreach (var item in nguoinhan)
            //    {

            //        mail.To.Add(item);

            //    }
            //    mail.Subject = Sanitizer.GetSafeHtmlFragment("[Bị từ chối] Bảng ROLLING FORECAST PROPOSAL tháng " + thang + " năm " + nam);
            //    mail.IsBodyHtml = true;
            //    mail.Body = html;
            //    SmtpServer.Port = 587;
            //    SmtpServer.Credentials = new System.Net.NetworkCredential("gatewaypymepharco@gmail.com", "aavgvkptivazfffi");
            //    SmtpServer.EnableSsl = true;
            //    SmtpServer.Send(mail);
            //    return Json(1);
            //}
            //else
            //{
            //    return Json(0);
            //}
            return Json(1);
        }
        [HttpPost]
        public JsonResult Approve(int thang, int nam, int bang, string kenh)
        {
            ViewBag.thang = thang;
            ViewBag.nam = nam;
            var Info = GetInfo();

            if (bang == 1)
            {
                var data = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.kenh == kenh && n.trangthai == true).ToList();

                var data1 = new List<TBL_SALEAPPROVE>();
                //if (data.First().khoa == false)
                //{
                foreach (var item in data)
                {
                    data1.Add(new TBL_SALEAPPROVE()
                    {
                        nguoitao = User.Identity.Name.ToString(),
                        thangduuoc = thang,
                        namduuoc = nam,
                        thang = item.thang,
                        nam = item.nam,
                        mahh = item.mahh,
                        kenh = item.kenh,
                        sub = item.sub,
                        soluong = item.soluong,
                        sotien = item.sotien,
                        ngayketthucthau = item.ngayketthucthau,
                        khoa = false,
                        ngaytao = DateTime.Now
                    });
                    item.khoa = true;
                }
                Duuoc.TBL_SALEAPPROVE.AddRange(data1);
                Duuoc.SaveChanges();
                return Json("1");
                //}
                //else
                //{
                //    return Json("2");
                //}

            }
            else if (bang == 2)
            {
                var data = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList();
                var data1 = new List<TBL_SCAPPROVE>();
                foreach (var item in data)
                {
                    data1.Add(new TBL_SCAPPROVE()
                    {
                        nguoitao = User.Identity.Name.ToString(),
                        thangduuoc = thang,
                        namduuoc = nam,
                        thang = item.thang,
                        nam = item.nam,
                        mahh = item.mahh,

                        soluong = item.soluong,
                        sotien = item.sotien,
                        ngayketthucthau = item.ngayketthucthau,
                        khoa = false,
                        ngaytao = DateTime.Now
                    });
                    item.khoa = true;
                    Duuoc.SaveChanges();
                }
                Duuoc.TBL_SCAPPROVE.AddRange(data1);
                Duuoc.SaveChanges();
                return Json("1");
            }
            else if (bang == 3)
            {
                var data = Duuoc.TBL_SCAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList();
                var data1 = data
                    .GroupBy(n => new { n.mahh, n.thang, n.nam })
                    .Select(n => new TBL_QLSXAPPROVE()
                    {

                        nguoitao = User.Identity.Name,
                        thangduuoc = thang,
                        namduuoc = nam,
                        thang = n.Key.thang,
                        nam = n.Key.nam,
                        mahh = n.Key.mahh,
                        soluong = n.Sum(m => m.soluong),
                        sotien = n.Sum(m => m.sotien),
                        ngayketthucthau = string.Join(",", n.Select(z => ((DateTime)z.ngayketthucthau).ToString("dd/MM/yyyy")).Distinct()),
                        khoa = false,
                        ngaytao = DateTime.Now
                    }).ToList();
                foreach (var item in data)
                {
                    item.khoa = true;
                }
                Duuoc.TBL_QLSXAPPROVE.AddRange(data1);
                Duuoc.SaveChanges();
                return Json("1");
            }
            else
            {
                var data = Duuoc.TBL_QLSXAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam).ToList();
                foreach (var item in data)
                {
                    item.khoa = true;
                }
                Duuoc.SaveChanges();
                return Json("1");
            }

        }
        [Authorize(Roles = "QLDUUOC")]
        [ActionName("danh-muc-hang-hoa")]
        public ActionResult Danhmuchanghoa()
        {
            var Info = GetInfo();
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;

            return View("Danhmuchanghoa");
        }
        [HttpPost]
        public ActionResult PartialBaocao(int bang, string kenh, int loaibaocao, int thang, int nam, int thangsosanh, int namsosanh)
        {
            ViewBag.thang = thang;
            ViewBag.nam = nam;
            var ngay = new DateTime(nam, thang, 1).AddMonths(-1);
            ViewBag.thangnam = ngay.ToString("MM/yyyy");
            var hanghoa = SC.TBL_DANHMUCHANGHOA.ToList();
            if (loaibaocao == 1)
            {
                if (bang == 1)
                {
                    var data = Duuoc.TBL_DEMANDFC.Where(n => ((n.thangduuoc == thang && n.namduuoc == nam) || (n.thangduuoc == thangsosanh && n.namduuoc == namsosanh))).ToList();
                    foreach (var i in data)
                    {
                        i.nguoitao = (hanghoa.SingleOrDefault(n => n.MAHH == i.mahh) != null) ? hanghoa.SingleOrDefault(n => n.MAHH == i.mahh).TENHH : "";
                    }
                    return PartialView(data);
                }
                else if (bang == 2)
                {
                    var data = Duuoc.TBL_SALEAPPROVE.Where(n => ((n.thangduuoc == thang && n.namduuoc == nam) || (n.thangduuoc == thangsosanh && n.namduuoc == namsosanh))).ToList();
                    foreach (var i in data)
                    {
                        i.nguoitao = (hanghoa.SingleOrDefault(n => n.MAHH == i.mahh) != null) ? hanghoa.SingleOrDefault(n => n.MAHH == i.mahh).TENHH : "";
                    }
                    return PartialView("PartialBaocao2", data);
                }
                else if (bang == 3)
                {
                    var data = Duuoc.TBL_SCAPPROVE.Where(n => ((n.thangduuoc == thang && n.namduuoc == nam) || (n.thangduuoc == thangsosanh && n.namduuoc == namsosanh))).ToList();
                    foreach (var i in data)
                    {
                        i.nguoitao = (hanghoa.SingleOrDefault(n => n.MAHH == i.mahh) != null) ? hanghoa.SingleOrDefault(n => n.MAHH == i.mahh).TENHH : "";
                    }
                    return PartialView("PartialBaocao3", data);
                }
                else
                {
                    var data = Duuoc.TBL_QLSXAPPROVE.Where(n => ((n.thangduuoc == thang && n.namduuoc == nam) || (n.thangduuoc == thangsosanh && n.namduuoc == namsosanh))).ToList();
                    foreach (var i in data)
                    {
                        i.nguoitao = (hanghoa.SingleOrDefault(n => n.MAHH == i.mahh) != null) ? hanghoa.SingleOrDefault(n => n.MAHH == i.mahh).TENHH : "";
                    }
                    return PartialView("PartialBaocao4", data);
                }
            }
            else
            {

                if (bang == 1)
                {
                    ViewBag.nam = nam;
                    var dataxuat = new List<TBL_DEMANDFC>();
                    var lockenh = Duuoc.TBL_KENH.SingleOrDefault(n => n.kenh == kenh);
                    var datatonkho = PBIDATA.DTA_TONKHO.Where(n => n.nam == ngay.Year && n.thang == ngay.Month).GroupBy(n => n.mahh).Select(n => new TBL_DEMANDFC() { thang = 0, nam = 0, mahh = n.Key, soluong = (int)n.Sum(cl => cl.slton) }).ToList();
                    if (lockenh.baogom != "ALL" && lockenh.baogom != null)
                    {
                        var baogom = lockenh.baogom.Split(',').ToList();
                        dataxuat = PBIDATA.DTA_XUAT_CHITIET.Where(n => n.NAM == nam && n.THANG < thang && baogom.Contains(n.MAKH)).GroupBy(n => new { n.MAHH, n.THANG, n.NAM }).Select(n => new TBL_DEMANDFC() { kenh = kenh, thang = (int)(n.Key.THANG), nam = (int)n.Key.NAM, mahh = n.Key.MAHH, soluong = (int)n.Sum(cl => cl.SOLUONG), sotien = n.Sum(cl => cl.DOANHTHUTHUAN) }).ToList();
                    }
                    else if (lockenh.baogom == "ALL")
                    {
                        var loaibo = lockenh.loaibo.Split(',').ToList();
                        dataxuat = PBIDATA.DTA_XUAT_CHITIET.Where(n => n.NAM == nam && n.THANG < thang && !loaibo.Contains(n.MAKH)).GroupBy(n => new { n.MAHH, n.THANG, n.NAM }).Select(n => new TBL_DEMANDFC() { kenh = kenh, thang = (int)(n.Key.THANG), nam = (int)n.Key.NAM, mahh = n.Key.MAHH, soluong = (int)n.Sum(cl => cl.SOLUONG), sotien = n.Sum(cl => cl.DOANHTHUTHUAN) }).ToList();
                    }
                    var data = Duuoc.TBL_DEMANDFC.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.nam == nam && n.thang >= thang && n.kenh == kenh).ToList();

                    var final = data.Concat(dataxuat).Concat(datatonkho);
                    foreach (var i in final)
                    {
                        i.nguoitao = (hanghoa.SingleOrDefault(n => n.MAHH == i.mahh) != null) ? hanghoa.SingleOrDefault(n => n.MAHH == i.mahh).TENHH : "";
                    }
                    return PartialView("PartialBaocao21", final);
                }
                else if (bang == 2)
                {
                    ViewBag.nam = nam;
                    var dataxuat = new List<TBL_SALEAPPROVE>();
                    var data = Duuoc.TBL_SALEAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.nam == nam && n.thang >= thang && n.kenh == kenh).ToList();
                    var datatonkho = PBIDATA.DTA_TONKHO.Where(n => n.nam == ngay.Year && n.thang == ngay.Month).GroupBy(n => n.mahh).Select(n => new TBL_SALEAPPROVE() { thang = 0, nam = 0, mahh = n.Key, soluong = (int)n.Sum(cl => cl.slton) }).ToList();
                    var listkenh = data.Select(n => n.kenh).Distinct();
                    foreach (var i in listkenh)
                    {
                        var lockenh = Duuoc.TBL_KENH.SingleOrDefault(n => n.kenh == i);
                        if (lockenh.baogom != "ALL" && lockenh.baogom != null)
                        {
                            var baogom = lockenh.baogom.Split(',').ToList();
                            dataxuat.AddRange(PBIDATA.DTA_XUAT_CHITIET.Where(n => n.NAM == nam && n.THANG < thang && baogom.Contains(n.MAKH)).GroupBy(n => new { n.MAHH, n.THANG, n.NAM }).Select(n => new TBL_SALEAPPROVE() { kenh = i, thang = (int)(n.Key.THANG), nam = (int)n.Key.NAM, mahh = n.Key.MAHH, soluong = (int)n.Sum(cl => cl.SOLUONG), sotien = n.Sum(cl => cl.DOANHTHUTHUAN) }).ToList());
                        }
                        else if (lockenh.baogom == "ALL")
                        {
                            var loaibo = lockenh.loaibo.Split(',').ToList();
                            dataxuat.AddRange(PBIDATA.DTA_XUAT_CHITIET.Where(n => n.NAM == nam && n.THANG < thang && !loaibo.Contains(n.MAKH)).GroupBy(n => new { n.MAHH, n.THANG, n.NAM }).Select(n => new TBL_SALEAPPROVE() { kenh = i, thang = (int)(n.Key.THANG), nam = (int)n.Key.NAM, mahh = n.Key.MAHH, soluong = (int)n.Sum(cl => cl.SOLUONG), sotien = n.Sum(cl => cl.DOANHTHUTHUAN) }).ToList());
                        }
                    }
                    var final = data.Concat(dataxuat).Concat(datatonkho);
                    foreach (var i in final)
                    {
                        i.nguoitao = (hanghoa.SingleOrDefault(n => n.MAHH == i.mahh) != null) ? hanghoa.SingleOrDefault(n => n.MAHH == i.mahh).TENHH : "";
                    }

                    return PartialView("PartialBaocao22", final);
                }
                else if (bang == 3)
                {
                    ViewBag.nam = nam;
                    var listchannel = Duuoc.TBL_PHANQUYEN.SingleOrDefault(n => n.nguoidung.ToUpper() == User.Identity.Name.ToUpper()).kenh.Split(',').ToList();
                    var dataxuat = new List<TBL_SCAPPROVE>();
                    var data = Duuoc.TBL_SCAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.nam == nam && n.thang >= thang).ToList();

                    var datatonkho = PBIDATA.DTA_TONKHO.Where(n => n.nam == ngay.Year && n.thang == ngay.Month).GroupBy(n => n.mahh).Select(n => new TBL_SCAPPROVE() { thang = 0, nam = 0, mahh = n.Key, soluong = (int)n.Sum(cl => cl.slton) }).ToList();
                    dataxuat.AddRange(PBIDATA.DTA_XUAT_CHITIET.Where(n => n.NAM == nam && n.THANG < thang).GroupBy(n => new { n.MAHH, n.THANG, n.NAM }).Select(n => new TBL_SCAPPROVE() { thang = (int)(n.Key.THANG), nam = (int)n.Key.NAM, mahh = n.Key.MAHH, soluong = (int)n.Sum(cl => cl.SOLUONG), sotien = n.Sum(cl => cl.DOANHTHUTHUAN) }).ToList());
                    var final = data.Concat(dataxuat).Concat(datatonkho);
                    foreach (var i in final)
                    {
                        i.nguoitao = (hanghoa.SingleOrDefault(n => n.MAHH == i.mahh) != null) ? hanghoa.SingleOrDefault(n => n.MAHH == i.mahh).TENHH : "";
                    }
                    return PartialView("PartialBaocao23", final);
                }
                else
                {
                    ViewBag.nam = nam;
                    var dataxuat = new List<TBL_QLSXAPPROVE>();
                    var datatonkho = PBIDATA.DTA_TONKHO.Where(n => n.nam == ngay.Year && n.thang == ngay.Month).GroupBy(n => n.mahh).Select(n => new TBL_QLSXAPPROVE() { thang = 0, nam = 0, mahh = n.Key, soluong = (int)n.Sum(cl => cl.slton) }).ToList();
                    var data = Duuoc.TBL_QLSXAPPROVE.Where(n => n.thangduuoc == thang && n.namduuoc == nam && n.nam == nam && n.thang >= thang).ToList();
                    dataxuat.AddRange(PBIDATA.DTA_XUAT_CHITIET.Where(n => n.NAM == nam && n.THANG < thang).GroupBy(n => new { n.MAHH, n.THANG, n.NAM }).Select(n => new TBL_QLSXAPPROVE() { thang = (int)(n.Key.THANG), nam = (int)n.Key.NAM, mahh = n.Key.MAHH, soluong = (int)n.Sum(cl => cl.SOLUONG), sotien = n.Sum(cl => cl.DOANHTHUTHUAN) }).ToList());
                    var final = data.Concat(dataxuat).Concat(datatonkho);
                    foreach (var i in final)
                    {
                        i.nguoitao = (hanghoa.SingleOrDefault(n => n.MAHH == i.mahh) != null) ? hanghoa.SingleOrDefault(n => n.MAHH == i.mahh).TENHH : "";
                    }
                    return PartialView("PartialBaocao24", final);
                }
            }
        }
        [HttpPost]
        public ActionResult PartialDMHH()
        {
            var Info = GetInfo();
            var manhom = "50,51,60,61,62,63,64,64.PME,64.STA,70,99,40,50.STA,51.STA,60.STA,62.STA".Split(',').ToList();
            var data = SC.TBL_DANHMUCHANGHOA.Where(n => manhom.Contains(n.nhom)).ToList();
            return PartialView(data);
        }
        [HttpPost]
        public JsonResult GetviewDMHH(string MAHH)
        {

            var Info = GetInfo();
            var data = SC.TBL_DANHMUCHANGHOA.SingleOrDefault(n => n.MAHH == MAHH);
            return Json(data);
        }
        [HttpPost]
        public JsonResult EditDMHH(List<string> CL, string MAHH, string TENHH, string DVT, string nhom, string GIAMUA, string GIABAN, string QUICACH, string tenhoatchat, string SDK, string nsx, List<string> chc, string SAP_code)
        {
            var tv = SC.TBL_DANHMUCHANGHOA.SingleOrDefault(n => n.MAHH == MAHH);
            if (tv != null)
            {
                if (CL[0] == "0")
                {
                    tv.CL = false;
                }
                else
                {
                    tv.CL = true;
                }
                tv.MAHH = MAHH;
                tv.TENHH = TENHH;
                tv.DVT = DVT;
                tv.nhom = nhom;
                tv.GIAMUA = GIAMUA;
                tv.GIABAN = GIABAN;
                tv.QUICACH = QUICACH;
                tv.tenhoatchat = tenhoatchat;
                tv.SDK = SDK;
                tv.nsx = nsx;
                if (chc[0] == "0")
                {
                    tv.chc = false;
                }
                else
                {
                    tv.chc = true;
                }
                tv.SAP_code = SAP_code;
                SC.SaveChanges();
            }
            else
            {
                return Json(0);
            }
            return Json(1);
        }
        public TBL_DANHMUCNGUOIDUNG GetInfo()
        {
            TBL_DANHMUCNGUOIDUNG abc = new TBL_DANHMUCNGUOIDUNG();
            abc = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name.ToString());
            return abc;
        }
    }
}