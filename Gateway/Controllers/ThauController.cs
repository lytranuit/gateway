using ApplicationChart.Models;
using ApplicationChart.Report;
using ClosedXML.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ApplicationChart.Controllers
{
    [Authorize(Roles = "TDTHAU")]
    public class ThauController : MyBaseController
    {
        // GET: Thau
        Entities HaNoi = new Entities("KT_HNEntities");
        Entities ThaiBinh = new Entities("KT_TBEntities");
        Entities ThaiNguyen = new Entities("KT_TNGEntities");
        Entities PhuTho = new Entities("KT_PTEntities");
        Entities TT423 = new Entities("TT423Entities");
        Entities TayNinh = new Entities("KT_TNEntities");
        Entities BinhDinh = new Entities("KT_BDEntities");
        Entities CanTho = new Entities("KT_CTEntities");
        Entities DongNai = new Entities("KT_DNEntities");
        Entities BinhDuong = new Entities("KT_BDGEntities");
        Entities DaNang = new Entities("KT_DNAEntities");
        Entities HoChiMinh = new Entities("KT_HCMEntities");
        Entities NgheAn = new Entities("KT_NAEntities");
        Entities NgheAn2 = new Entities("KT_NA_2Entities");
        Entities QuangTri = new Entities("KT_QTEntities");
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

        CHQ10Entities1 PTTT = new CHQ10Entities1("PTTTEntities");
        CHQ10Entities1 CHQ10 = new CHQ10Entities1("CHQ10Entities");
        CHQ10Entities1 CHPPSP = new CHQ10Entities1("CHPPSPEntities");
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();
        POWERBIEntities PBIDATA = new POWERBIEntities();
        KT_THEntities1 DATATH1 = new KT_THEntities1("KT_THEntities1");
        KT_THEntities1 DATATH2 = new KT_THEntities1("KT_THEntities2");

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
            new EntitiesCN {data = new Entities("KT_PYPHARMEntities") , macn = "DPY"},
                 new EntitiesCN {data = new Entities("KT_PYPHARM_HCMEntities") , macn = "DPY_HCM"},
        };
        List<EntitiesCH> queryCH = new List<EntitiesCH> {
            new EntitiesCH {data = new CHQ10Entities1("PTTTEntities") , macn = "PTTT"},
            new EntitiesCH {data = new CHQ10Entities1("CHQ10Entities") , macn = "CHQ10"},
            new EntitiesCH {data = new CHQ10Entities1("CHPPSPEntities") , macn = "CHPPSP"},
        };

        [ActionName("theo-doi-hang-thau")]
        public ActionResult Index()
        {
            var Info = GetInfo();
            List<TBL_DANHSACHCHINHANH> donvi = new List<TBL_DANHSACHCHINHANH>();
            List<string> listcn = Info.macn.Split(',').ToList();
            donvi = db2.TBL_DANHSACHCHINHANH.Where(n => listcn.Contains(n.macn) && n.macn != "SC").ToList();
            ViewBag.mientrung = donvi.Where(n => n.Mien == "MIỀN TRUNG").OrderBy(n => n.stt);
            ViewBag.miennam = donvi.Where(n => n.Mien == "MIỀN NAM").OrderBy(n => n.stt);
            ViewBag.mienbac = donvi.Where(n => n.Mien == "MIỀN BẮC").OrderBy(n => n.stt);
            ViewBag.dathang = Info.dathang;
            ViewBag.ten = Info.hoten;
            ViewBag.quyen = Info.quyen;
            return View("Index");
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult IndexIN(int btnin, List<string> macn, int loai, List<string> mahh, List<string> mahd, string tungay, string denngay)
        {
            //try {
            ViewBag.PDF = 1;
            var hopdong = new List<ListDMThau>();
            foreach (var i in mahd)
            {
                hopdong.Add(JsonConvert.DeserializeObject<ListDMThau>(i));
            }
            //var ngay2020 = new DateTime(2020, 1, 1);

            DateTime tungay1 = DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime denngay1 = DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var data = new List<ListKQHopdong>();
            var data1 = new List<ListKQHopdong1>();
            data = DATAGETKQNEW(hopdong, tungay1, denngay1, mahh);
            if (loai == 9)
            {
                string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                string fileName = "THAU.xlsx";
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        IXLWorksheet worksheet =
                        workbook.Worksheets.Add("THAU");
                        worksheet.Cell(1, 1).Value = "MÃ CHI NHÁNH";
                        worksheet.Cell(1, 2).Value = "CHI NHÁNH";
                        worksheet.Cell(1, 3).Value = "MÃ KHÁCH HÀNG";
                        worksheet.Cell(1, 4).Value = "TÊN KHÁCH HÀNG";
                        worksheet.Cell(1, 5).Value = "MÃ TỈNH";
                        worksheet.Cell(1, 6).Value = "TÊN TỈNH";
                        worksheet.Cell(1, 7).Value = "MÃ HỢP ĐỒNG";
                        worksheet.Cell(1, 8).Value = "MÃ HÀNG HÓA";
                        worksheet.Cell(1, 9).Value = "TÊN HÀNG HÓA";
                        worksheet.Cell(1, 10).Value = "SỐ LƯỢNG THẦU";
                        worksheet.Cell(1, 11).Value = "GIÁ TRÚNG THẦU";
                        worksheet.Cell(1, 12).Value = "TIỀN THẦU";
                        worksheet.Cell(1, 13).Value = "SỐ LƯỢNG TRƯỚC KÝ";
                        worksheet.Cell(1, 14).Value = "TIỀN TRƯỚC KỲ";
                        worksheet.Cell(1, 15).Value = "SỐ LƯỢNG TRONG KỲ";
                        worksheet.Cell(1, 16).Value = "TIỀN TRONG KỲ";
                        worksheet.Cell(1, 17).Value = "SỐ LƯỢNG CÒN HIỆU LỰC";
                        worksheet.Cell(1, 18).Value = "TIỀN";

                        for (int index = 1; index <= data.Count; index++)
                        {
                            worksheet.Cell(index + 1, 1).Value = data[index - 1].MACN;
                            worksheet.Cell(index + 1, 2).Value = data[index - 1].TENDVBC;
                            worksheet.Cell(index + 1, 3).Value = data[index - 1].MAKH;
                            worksheet.Cell(index + 1, 4).Value = data[index - 1].DONVI;
                            worksheet.Cell(index + 1, 5).Value = data[index - 1].MATINH;
                            worksheet.Cell(index + 1, 6).Value = data[index - 1].TENTINH;
                            worksheet.Cell(index + 1, 7).Value = data[index - 1].MAHD;
                            worksheet.Cell(index + 1, 8).Value = data[index - 1].MAHH;

                            worksheet.Cell(index + 1, 9).Value = data[index - 1].tenhh;
                            worksheet.Cell(index + 1, 10).Value = data[index - 1].SL;
                            worksheet.Cell(index + 1, 11).Value = data[index - 1].GIASP;
                            worksheet.Cell(index + 1, 12).Value = data[index - 1].tienhd;
                            worksheet.Cell(index + 1, 13).Value = data[index - 1].sldauky;
                            worksheet.Cell(index + 1, 14).Value = data[index - 1].tiendauky;
                            worksheet.Cell(index + 1, 15).Value = data[index - 1].TT;
                            worksheet.Cell(index + 1, 16).Value = data[index - 1].tienps;
                            worksheet.Cell(index + 1, 17).Value = data[index - 1].sldu;
                            worksheet.Cell(index + 1, 18).Value = data[index - 1].tiendu;
                        }
                        //required using System.IO;
                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            var content = stream.ToArray();
                            return File(content, contentType, fileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Content("<script type='text/javascript'>alert('Không có dữ liệu'); window.close();</script>");
                }
            }
            if (mahh != null)
            {

                //foreach (var i in hopdong)
                //{
                //    string str = " exec sp_INSOCTIET_HOPDONG_KHACHHANG_TONGHOP_MAHH '" + i.MAKH + "','" + i.MAHD + "','" + tungay1.ToString("MM/dd/yyyy") + "','" + denngay1.ToString("MM/dd/yyyy") + "',N'" + i.DONVI + "','" + String.Join(",", mahh.ToArray()) + "' ";
                //    data.AddRange(DATAGETKQ(i.MACN, str));

                //}
                if (data.Count() != 0)
                {
                    data1 = data.Select(cl => new ListKQHopdong1 { MATINH = (cl.ngayketthuc != null) ? ((DateTime)cl.ngayketthuc).ToString("dd/MM/yyyy") : "", ngaybatdau = (cl.ngaybatdau != null) ? ((DateTime)cl.ngaybatdau).ToString("dd/MM/yyyy") : "", ngayketthuc = (cl.ngayketthuc != null) ? ((DateTime)cl.ngayketthuc).ToString("dd/MM/yyyy") : "", DENNGAY = cl.DENNGAY, DONVI = cl.DONVI, MAHD = cl.MAHD, MAHH = cl.MAHH, MAKH = cl.MAKH, SL = cl.SL, sldauky = cl.sldauky, sldu = cl.sldu, TENDVBC = cl.TENDVBC, tenhh = cl.tenhh, TENTINH = cl.TENTINH, tiendauky = cl.tiendauky, tiendu = cl.tiendu, tienhd = cl.tienhd, tienps = cl.tienps, TT = cl.TT, TUNGAY = cl.TUNGAY }).ToList();
                }
                if (loai == 0)
                {
                    CR_THEODOIHANGTHAU_CHITIET rpt = new CR_THEODOIHANGTHAU_CHITIET();
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    if (btnin == 4)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                        return File(s, "application/msword", "CHITETTHAU.doc");
                    }
                    else if (btnin == 2)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return File(s, "application/pdf", "CHITETTHAU.pdf");
                    }
                    else if (btnin == 3)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);

                        return File(s, "application/vnd.ms-excel", "CHITETTHAU.xls");
                    }
                    else if (btnin == 1)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return View("IndexIN", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                    }
                }
                else if (loai == 1)
                {
                    CR_THEODOIHANGTHAU_CHITIET_KHUVUC_MAKH_MAHH rpt = new CR_THEODOIHANGTHAU_CHITIET_KHUVUC_MAKH_MAHH();
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    if (btnin == 4)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                        return File(s, "application/msword", "CHITETTHAU.doc");
                    }
                    else if (btnin == 2)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return File(s, "application/pdf", "CHITETTHAU.pdf");
                    }
                    else if (btnin == 3)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);
                        return File(s, "application/vnd.ms-excel", "CHITETTHAU.xls");
                    }
                    else if (btnin == 1)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return View("IndexIN", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                    }
                }
                else if (loai == 2)
                {
                    CR_THEODOIHANGTHAU_CHITIET_KHUVUC_MAHH rpt = new CR_THEODOIHANGTHAU_CHITIET_KHUVUC_MAHH();
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    if (btnin == 4)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                        return File(s, "application/msword", "CHITETTHAU.doc");
                    }
                    else if (btnin == 2)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return File(s, "application/pdf", "CHITETTHAU.pdf");
                    }
                    else if (btnin == 3)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);

                        return File(s, "application/vnd.ms-excel", "CHITETTHAU.xls");
                    }
                    else if (btnin == 1)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return View("IndexIN", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                    }
                }
                else if (loai == 3)
                {
                    CR_THEODOIHANGTHAU_CHITIET_MAHH_KHUVUC rpt = new CR_THEODOIHANGTHAU_CHITIET_MAHH_KHUVUC();
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    if (btnin == 4)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                        return File(s, "application/msword", "CHITETTHAU.doc");
                    }
                    else if (btnin == 2)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return File(s, "application/pdf", "CHITETTHAU.pdf");
                    }
                    else if (btnin == 3)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);

                        return File(s, "application/vnd.ms-excel", "CHITETTHAU.xls");
                    }
                    else if (btnin == 1)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return View("IndexIN", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                    }
                }
                else if (loai == 4)
                {
                    CR_THEODOIHANGTHAU_CHITIET_MAHH_MAKH rpt = new CR_THEODOIHANGTHAU_CHITIET_MAHH_MAKH();
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    if (btnin == 4)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                        return File(s, "application/msword", "CHITETTHAU.doc");
                    }
                    else if (btnin == 2)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return File(s, "application/pdf", "CHITETTHAU.pdf");
                    }
                    else if (btnin == 3)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);

                        return File(s, "application/vnd.ms-excel", "CHITETTHAU.xls");
                    }
                    else if (btnin == 1)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return View("IndexIN", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                    }
                }
                else if (loai == 5)
                {
                    CR_THEODOIHANGTHAU_CHITIET_KHUVUC_MAKH_MAHH_NGAY rpt = new CR_THEODOIHANGTHAU_CHITIET_KHUVUC_MAKH_MAHH_NGAY();
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    if (btnin == 4)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                        return File(s, "application/msword", "CHITETTHAU.doc");
                    }
                    else if (btnin == 2)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return File(s, "application/pdf", "CHITETTHAU.pdf");
                    }
                    else if (btnin == 3)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);

                        return File(s, "application/vnd.ms-excel", "CHITETTHAU.xls");
                    }
                    else if (btnin == 1)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return View("IndexIN", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                    }
                }
                else if (loai == 6)
                {
                    CR_THEODOIHANGTHAU_CHITIET_KHUVUC_MAKH_MAHH_NGAY_EXCEL rpt = new CR_THEODOIHANGTHAU_CHITIET_KHUVUC_MAKH_MAHH_NGAY_EXCEL();
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    if (btnin == 4)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                        return File(s, "application/msword", "CHITETTHAU.doc");
                    }
                    else if (btnin == 2)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return File(s, "application/pdf", "CHITETTHAU.pdf");
                    }
                    else if (btnin == 3)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);

                        return File(s, "application/vnd.ms-excel", "CHITETTHAU.xls");
                    }
                    else if (btnin == 1)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return View("IndexIN", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                    }
                }
                else if (loai == 7)
                {
                    BAOCAO7_EXCEL rpt = new BAOCAO7_EXCEL();

                    rpt.Load();
                    rpt.SetDataSource(data1);
                    if (btnin == 4)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                        return File(s, "application/msword", "CHITETTHAU.doc");
                    }
                    else if (btnin == 2)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return File(s, "application/pdf", "CHITETTHAU.pdf");
                    }
                    else if (btnin == 3)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);
                        return File(s, "application/vnd.ms-excel", "CHITETTHAU.xls");
                    }
                    else if (btnin == 1)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return View("IndexIN", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                    }
                }
            }
            else
            {
                //foreach (var i in hopdong)
                //{
                //    string str = " exec sp_INSOCTIET_HOPDONG_KHACHHANG_TONGHOP '" + i.MAKH + "','" + i.MAHD + "','" + tungay1.ToString("MM/dd/yyyy") + "','" + denngay1.ToString("MM/dd/yyyy") + "',N'" + i.DONVI + "'";
                //    data.AddRange(DATAGETKQ(i.MACN, str));
                //}
                if (data.Count() != 0)
                {
                    data1 = data.Select(cl => new ListKQHopdong1 { MATINH = (cl.ngayketthuc != null) ? ((DateTime)cl.ngayketthuc).ToString("dd/MM/yyyy") : "", ngaybatdau = (cl.ngaybatdau != null) ? ((DateTime)cl.ngaybatdau).ToString("dd/MM/yyyy") : "", ngayketthuc = (cl.ngayketthuc != null) ? ((DateTime)cl.ngayketthuc).ToString("dd/MM/yyyy") : "", DENNGAY = cl.DENNGAY, DONVI = cl.DONVI, MAHD = cl.MAHD, MAHH = cl.MAHH, MAKH = cl.MAKH, SL = cl.SL, sldauky = cl.sldauky, sldu = cl.sldu, TENDVBC = cl.TENDVBC, tenhh = cl.tenhh, TENTINH = cl.TENTINH, tiendauky = cl.tiendauky, tiendu = cl.tiendu, tienhd = cl.tienhd, tienps = cl.tienps, TT = cl.TT, TUNGAY = cl.TUNGAY }).ToList();
                }
                if (loai == 0)
                {
                    CR_THEODOIHANGTHAU_CHITIET rpt = new CR_THEODOIHANGTHAU_CHITIET();
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    if (btnin == 4)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                        return File(s, "application/msword", "CHITETTHAU.doc");
                    }
                    else if (btnin == 2)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return File(s, "application/pdf", "CHITETTHAU.pdf");
                    }
                    else if (btnin == 3)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);
                        return File(s, "application/vnd.ms-excel", "CHITETTHAU.xls");
                    }
                    else if (btnin == 1)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return View("IndexIN", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                    }
                }
                else if (loai == 1)
                {
                    CR_THEODOIHANGTHAU_CHITIET_KHUVUC_MAKH_MAHH rpt = new CR_THEODOIHANGTHAU_CHITIET_KHUVUC_MAKH_MAHH();
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    if (btnin == 4)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                        return File(s, "application/msword", "CHITETTHAU.doc");
                    }
                    else if (btnin == 2)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return File(s, "application/pdf", "CHITETTHAU.pdf");
                    }
                    else if (btnin == 3)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);

                        return File(s, "application/vnd.ms-excel", "CHITETTHAU.xls");
                    }
                    else if (btnin == 1)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return View("IndexIN", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                    }
                }
                else if (loai == 2)
                {
                    CR_THEODOIHANGTHAU_CHITIET_KHUVUC_MAHH rpt = new CR_THEODOIHANGTHAU_CHITIET_KHUVUC_MAHH();
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    if (btnin == 4)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                        return File(s, "application/msword", "CHITETTHAU.doc");
                    }
                    else if (btnin == 2)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return File(s, "application/pdf", "CHITETTHAU.pdf");
                    }
                    else if (btnin == 3)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);

                        return File(s, "application/vnd.ms-excel", "CHITETTHAU.xls");
                    }
                    else if (btnin == 1)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return View("IndexIN", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                    }
                }
                else if (loai == 3)
                {
                    CR_THEODOIHANGTHAU_CHITIET_MAHH_KHUVUC rpt = new CR_THEODOIHANGTHAU_CHITIET_MAHH_KHUVUC();
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    if (btnin == 4)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                        return File(s, "application/msword", "CHITETTHAU.doc");
                    }
                    else if (btnin == 2)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return File(s, "application/pdf", "CHITETTHAU.pdf");
                    }
                    else if (btnin == 3)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);
                        return File(s, "application/vnd.ms-excel", "CHITETTHAU.xls");
                    }
                    else if (btnin == 1)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return View("IndexIN", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                    }
                }
                else if (loai == 4)
                {
                    CR_THEODOIHANGTHAU_CHITIET_MAHH_MAKH rpt = new CR_THEODOIHANGTHAU_CHITIET_MAHH_MAKH();
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    if (btnin == 4)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                        return File(s, "application/msword", "CHITETTHAU.doc");
                    }
                    else if (btnin == 2)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return File(s, "application/pdf", "CHITETTHAU.pdf");
                    }
                    else if (btnin == 3)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);

                        return File(s, "application/vnd.ms-excel", "CHITETTHAU.xls");
                    }
                    else if (btnin == 1)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return View("IndexIN", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                    }
                }
                else if (loai == 5)
                {
                    CR_THEODOIHANGTHAU_CHITIET_KHUVUC_MAKH_MAHH_NGAY rpt = new CR_THEODOIHANGTHAU_CHITIET_KHUVUC_MAKH_MAHH_NGAY();
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    if (btnin == 4)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                        return File(s, "application/msword", "CHITETTHAU.doc");
                    }
                    else if (btnin == 2)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return File(s, "application/pdf", "CHITETTHAU.pdf");
                    }
                    else if (btnin == 3)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);

                        return File(s, "application/vnd.ms-excel", "CHITETTHAU.xls");
                    }
                    else if (btnin == 1)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return View("IndexIN", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                    }
                }
                else if (loai == 6)
                {
                    CR_THEODOIHANGTHAU_CHITIET_KHUVUC_MAKH_MAHH_NGAY_EXCEL rpt = new CR_THEODOIHANGTHAU_CHITIET_KHUVUC_MAKH_MAHH_NGAY_EXCEL();
                    rpt.Load();
                    rpt.SetDataSource(data1);
                    if (btnin == 4)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                        return File(s, "application/msword", "CHITETTHAU.doc");
                    }
                    else if (btnin == 2)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return File(s, "application/pdf", "CHITETTHAU.pdf");
                    }
                    else if (btnin == 3)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);
                        return File(s, "application/vnd.ms-excel", "CHITETTHAU.xls");
                    }
                    else if (btnin == 1)
                    {
                        Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        return View("IndexIN", new PDFBase64 { Base64 = Convert.ToBase64String(ReadFully(s)) });
                    }
                }
                else if (loai == 8)
                {

                }
            }
            return RedirectToAction("CloseTab", "Home");
            //}
            //catch(Exception)
            //{
            //    return RedirectToAction("CloseTab","Home");
            //}
        }
        [HttpPost]
        public ActionResult GetPartialThau(List<string> macn, string tungay, string denngay, int hieuluc)
        {
            var Info = GetInfo();
            var data = new Dulieuthau();
            DateTime tungay1 = DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime denngay1 = DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            data.KHUVUC = DATAGETKHUVUC(macn, Info);
            data.SANPHAM = DATAGETSP(macn);
            data.DANHMUC = DATAGETDM(macn, Info, tungay1, denngay1, hieuluc);
            data.LOAIHD = DATAGETLOAIHD(macn, tungay1, denngay1).Where(n => n != null).ToList();
            data.QUYETDINH = DATAGETQD(macn, tungay1, denngay1).Where(n => n.MAQD != null).ToList();
            ViewBag.maplkh = db2.TBL_DANHMUCPHANLOAIKHACHHANG.OrderBy(n => n.phanloaikhachhang).ToList();
            return PartialView(data);
        }
        [HttpPost]
        public ActionResult GetPartialLocHD(List<string> macn, string tungay, string denngay, List<string> khuvuc, List<string> phanloai, List<string> phanloaikhachhang, List<string> loaihd, List<string> maqd)
        {
            var Info = GetInfo();
            DateTime tungay1 = DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime denngay1 = DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var data = DATAGETDMLOC(macn, Info, tungay1, denngay1, khuvuc, phanloai, phanloaikhachhang, loaihd, maqd);
            return PartialView(data);
        }
        private List<ListQuyetDinh> DATAGETQD(List<string> macn, DateTime tungay, DateTime denngay)
        {
            var data = new List<ListQuyetDinh>();
            string str1 = "select DISTINCT tbl_danhmuchopdong.MAQD,tbl_danhmuchopdong.TENQD from tbl_danhmuchopdong,tbl_danhmuckhachhang where ngayketthuc >= '" + denngay.ToString("MM/dd/yyyy") + "'";
            str1 = str1 + " and tbl_danhmuckhachhang.tk='131'";
            str1 = str1 + " AND tbl_danhmuckhachhang.MAKH=tbl_danhmuchopdong.MAKH ";
            //str1 = str1 + " AND ISNULL(tbl_danhmuchopdong.KT,0)=0 ";
            string str2 = "select DISTINCT tbl_danhmuchopdong.MAQD,tbl_danhmuchopdong.TENQD from tbl_danhmuchopdong,dm_khachhang_pttt tbl_danhmuckhachhang where (tbl_danhmuchopdong.ngayketthuc >= '" + denngay.ToString("MM/dd/yyyy") + "' or   tbl_danhmuchopdong.ngayketthuc >= '" + tungay.ToString("MM/dd/yyyy") + "') ";
            str2 = str2 + " AND tbl_danhmuckhachhang.MAKH=tbl_danhmuchopdong.MAKH ";
            //str2 = str2 + " AND ISNULL(tbl_danhmuchopdong.KT,0)=0 ";
            foreach (var ChiNhanhId in macn)
            {
                if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data.AddRange(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<ListQuyetDinh>(str1).ToList());
                }
                else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data.AddRange(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<ListQuyetDinh>(str2).ToList());
                }
            }
            return data.Distinct().ToList();
        }
        private List<string> DATAGETLOAIHD(List<string> macn, DateTime tungay, DateTime denngay)
        {
            var data = new List<string>();
            string str1 = "select DISTINCT tbl_danhmuchopdong.LOAIHD from tbl_danhmuchopdong,tbl_danhmuckhachhang where ";
            str1 = str1 + " tbl_danhmuckhachhang.tk='131'";
            str1 = str1 + " AND tbl_danhmuckhachhang.MAKH=tbl_danhmuchopdong.MAKH ";
            //str1 = str1 + " AND ISNULL(tbl_danhmuchopdong.KT,0)=0 ";
            string str2 = "select DISTINCT tbl_danhmuchopdong.LOAIHD from tbl_danhmuchopdong,dm_khachhang_pttt tbl_danhmuckhachhang where ";
            str2 = str2 + " tbl_danhmuckhachhang.MAKH=tbl_danhmuchopdong.MAKH ";
            //str2 = str2 + " AND ISNULL(tbl_danhmuchopdong.KT,0)=0 ";
            foreach (var ChiNhanhId in macn)
            {
                if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.CommandTimeout = 3200;
                    data.AddRange(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<string>(str1).ToList());
                    //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                }
                else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.CommandTimeout = 3200;
                    data.AddRange(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<string>(str2).ToList());
                    //PBIDATA.DTA_TONKHO.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").GroupBy(n => n.mahh).Select(cl => new DTA_TONKHO() { macn = i, mahh = cl.Key, nam = nam, thang = thang, slton = cl.Sum(z => z.slton) }));
                    //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                }
            }
            return data.Distinct().ToList();
        }
        private List<ListDMThau> DATAGETDMLOC(List<string> macn, TBL_DANHMUCNGUOIDUNG info, DateTime tungay, DateTime denngay, List<string> khuvuc, List<string> phanloai, List<string> phanloaikhachhang, List<string> loaihd, List<string> maqd)
        {
            var data = new List<ListDMThau>();
            foreach (var ChiNhanhId in macn)
            {
                string str1 = "select tbl_danhmuchopdong.MAKH,tbl_danhmuchopdong.MAHD,tbl_danhmuchopdong.donvi,'" + ChiNhanhId + "' AS MACN from tbl_danhmuchopdong,tbl_danhmuckhachhang where ngayketthuc >= '" + denngay.ToString("MM/dd/yyyy") + "'";
                str1 = str1 + " and tbl_danhmuckhachhang.tk='131'";
                str1 = str1 + " AND tbl_danhmuckhachhang.MAKH=tbl_danhmuchopdong.MAKH ";
                //str1 = str1 + " AND ISNULL(tbl_danhmuchopdong.KT,0)=0 ";
                string str2 = "select tbl_danhmuchopdong.MAKH,tbl_danhmuchopdong.MAHD,tbl_danhmuchopdong.donvi,'" + ChiNhanhId + "' AS MACN from tbl_danhmuchopdong,dm_khachhang_pttt tbl_danhmuckhachhang where (tbl_danhmuchopdong.ngayketthuc >= '" + denngay.ToString("MM/dd/yyyy") + "' or   tbl_danhmuchopdong.ngayketthuc >= '" + tungay.ToString("MM/dd/yyyy") + "') ";
                str2 = str2 + " AND tbl_danhmuckhachhang.MAKH=tbl_danhmuchopdong.MAKH ";
                //str2 = str2 + " AND ISNULL(tbl_danhmuchopdong.KT,0)=0 ";
                if (khuvuc != null)
                {
                    str1 = str1 + string.Format(" AND tbl_danhmuckhachhang.matinh IN({0}) ", string.Join(",", khuvuc.Select(p => "'" + p + "'")));
                    str2 = str2 + string.Format(" AND tbl_danhmuckhachhang.matinh IN({0}) ", string.Join(",", khuvuc.Select(p => "'" + p + "'")));
                }
                else if (khuvuc == null && info.matinh != "ALL")
                {
                    str1 = str1 + string.Format(" AND tbl_danhmuckhachhang.matinh IN({0}) ", string.Join(",", info.matinh.Split(',').ToList().Select(p => "'" + p + "'")));
                    str2 = str2 + string.Format(" AND tbl_danhmuckhachhang.matinh IN({0}) ", string.Join(",", info.matinh.Split(',').ToList().Select(p => "'" + p + "'")));
                }
                if (phanloai != null)
                {
                    str1 = str1 + string.Format(" AND tbl_danhmuckhachhang.phanloai IN({0}) ", string.Join(",", phanloai.Select(p => "'" + p + "'")));
                    str2 = str2 + string.Format(" AND tbl_danhmuckhachhang.phanloai IN({0}) ", string.Join(",", phanloai.Select(p => "'" + p + "'")));
                }
                else if (phanloai == null && info.phanloai != "ETC,OTC")
                {
                    str1 = str1 + string.Format(" AND tbl_danhmuckhachhang.phanloai IN({0}) ", string.Join(",", info.phanloai.Split(',').ToList().Select(p => "'" + p + "'")));
                    str2 = str2 + string.Format(" AND tbl_danhmuckhachhang.phanloai IN({0}) ", string.Join(",", info.phanloai.Split(',').ToList().Select(p => "'" + p + "'")));
                }
                if (phanloaikhachhang != null)
                {
                    str1 = str1 + string.Format(" AND tbl_danhmuckhachhang.phanloaikhachhang IN({0}) ", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                    str2 = str2 + string.Format(" AND tbl_danhmuckhachhang.phanloaikhachhang IN({0}) ", string.Join(",", phanloaikhachhang.Select(p => "'" + p + "'")));
                }
                if (loaihd != null)
                {
                    str1 = str1 + string.Format(" AND LOAIHD IN({0}) ", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
                    str2 = str2 + string.Format(" AND LOAIHD IN({0}) ", string.Join(",", loaihd.Select(p => "N'" + p + "'")));
                }
                if (maqd != null)
                {
                    str1 = str1 + string.Format(" AND MAQD IN({0}) ", string.Join(",", maqd.Select(p => "N'" + p + "'")));
                    str2 = str2 + string.Format(" AND MAQD IN({0}) ", string.Join(",", maqd.Select(p => "N'" + p + "'")));
                }
                if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data.AddRange(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<ListDMThau>(str1).ToList());
                }
                else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data.AddRange(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<ListDMThau>(str2).ToList());
                }

            }
            return data;
        }

        private List<ListDMThau> DATAGETDM(List<string> macn, TBL_DANHMUCNGUOIDUNG info, DateTime tungay, DateTime denngay, int hieuluc)
        {
            var data = new List<ListDMThau>();

            foreach (var ChiNhanhId in macn)
            {
                string str1 = "select tbl_danhmuchopdong.MAKH,tbl_danhmuchopdong.MAHD,tbl_danhmuchopdong.donvi,'" + ChiNhanhId + "' AS MACN from tbl_danhmuchopdong,tbl_danhmuckhachhang where ngayketthuc >= '" + denngay.ToString("MM/dd/yyyy") + "'";
                str1 = str1 + " and tbl_danhmuckhachhang.tk='131'";
                str1 = str1 + " AND tbl_danhmuckhachhang.MAKH=tbl_danhmuchopdong.MAKH ";
                //str1 = str1 + " AND ISNULL(tbl_danhmuchopdong.KT,0)=0 ";

                //string str2 = "select tbl_danhmuchopdong.MAKH,tbl_danhmuchopdong.MAHD,tbl_danhmuchopdong.donvi,'" + ChiNhanhId + "' AS MACN from tbl_danhmuchopdong,dm_khachhang_pttt tbl_danhmuckhachhang where (tbl_danhmuchopdong.ngayketthuc >= '" + denngay.ToString("MM/dd/yyyy") + "' or   tbl_danhmuchopdong.ngayketthuc >= '" + tungay.ToString("MM/dd/yyyy") + "') ";
                string str2 = "select tbl_danhmuchopdong.MAKH,tbl_danhmuchopdong.MAHD,tbl_danhmuchopdong.donvi,'" + ChiNhanhId + "' AS MACN from tbl_danhmuchopdong,dm_khachhang_pttt tbl_danhmuckhachhang where ";
                str2 = str2 + " tbl_danhmuckhachhang.MAKH=tbl_danhmuchopdong.MAKH ";
                //str2 = str2 + " AND ISNULL(tbl_danhmuchopdong.KT,0)=0 ";
                if (hieuluc == 1)
                {
                    str1 = str1 + " AND tbl_danhmuchopdong.ngayketthuc >= '" + DateTime.Today.ToString("yyyy-MM-dd") + "' ";
                    str2 = str2 + " AND tbl_danhmuchopdong.ngayketthuc >= '" + DateTime.Today.ToString("yyyy-MM-dd") + "' ";
                }
                else
                {
                    str1 = str1 + " AND tbl_danhmuchopdong.ngayketthuc < '" + DateTime.Today.ToString("yyyy-MM-dd") + "' ";
                    str2 = str2 + " AND tbl_danhmuchopdong.ngayketthuc < '" + DateTime.Today.ToString("yyyy-MM-dd") + "' ";
                }
                if (info.matinh != "ALL")
                {
                    str1 = str1 + string.Format(" AND tbl_danhmuckhachhang.matinh IN({0}) ", string.Join(",", info.matinh.Split(',').ToList().Select(p => "'" + p + "'")));
                    str2 = str2 + string.Format(" AND tbl_danhmuckhachhang.matinh IN({0}) ", string.Join(",", info.matinh.Split(',').ToList().Select(p => "'" + p + "'")));
                }
                if (info.phanloai != "ETC,OTC")
                {
                    str1 = str1 + string.Format(" AND tbl_danhmuckhachhang.phanloai IN({0}) ", string.Join(",", info.phanloai.Split(',').ToList().Select(p => "'" + p + "'")));
                    str2 = str2 + string.Format(" AND tbl_danhmuckhachhang.phanloai IN({0}) ", string.Join(",", info.phanloai.Split(',').ToList().Select(p => "'" + p + "'")));
                }
                if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.CommandTimeout = 3200;
                    data.AddRange(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<ListDMThau>(str1).ToList());
                    //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                }
                else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.CommandTimeout = 3200;
                    data.AddRange(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<ListDMThau>(str2).ToList());
                    //PBIDATA.DTA_TONKHO.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").GroupBy(n => n.mahh).Select(cl => new DTA_TONKHO() { macn = i, mahh = cl.Key, nam = nam, thang = thang, slton = cl.Sum(z => z.slton) }));
                    //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                }

            }
            return data;
        }
        public List<ListKhachHang> GETCHITIETKH(string ChiNhanhId, string makh)
        {
            var Info = GetInfo();
            var listpl = Info.phanloai.Split(',').ToList();
            string strcn = "SELECT makh AS MAKH, donvi AS DONVI, matinh as MATINH FROM TBL_DANHMUCKHACHHANG where makh ='" + makh + "'";
            string strch = "SELECT MaKH AS MAKH, DonVi AS DONVI, matinh as MATINH FROM DM_KHACHHANG_PTTT where makh ='" + makh + "'";


            List<ListKhachHang> data = new List<ListKhachHang>();
            if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
            {
                data = DULIEUKHACHHANG(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data, strcn).ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
            {
                data = DULIEUCUAHANGKHACHHANG(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data, strch).ToList();
            }

            return data;
        }
        public List<ListKhachHang> DULIEUKHACHHANG(Entities data, string str)
        {
            try
            {
                data.Database.CommandTimeout = 320;
                var All = data.Database.SqlQuery<ListKhachHang>(str).ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListKhachHang>();
            }

        }
        public List<ListKhachHang> DULIEUCUAHANGKHACHHANG(CHQ10Entities1 data, string str)
        {
            try
            {
                data.Database.CommandTimeout = 320;
                var All = data.Database.SqlQuery<ListKhachHang>(str).ToList();
                return All;
            }
            catch (Exception)
            {
                return new List<ListKhachHang>();
            }


        }
        private List<ListKQHopdong> DATAGETKQNEW(List<ListDMThau> hopdong, DateTime tungay, DateTime denngay, List<string> mahh)
        {
            var data = new List<ListKQHopdong>();
            var danhmuchh = SC.TBL_DANHMUCHANGHOA.ToList().Select(n => new TBL_DANHMUCHANGHOA() { MAHH = n.MAHH, TENHH = n.TENHH }).ToList();
            var matinh = PBIDATA.TBL_DANHMUCTINH.ToList();
            var macn = db2.TBL_DANHSACHCHINHANH.ToList();

            foreach (var i in hopdong)
            {
                try
                {
                    var khachhang = GETCHITIETKH(i.MACN, i.MAKH);
                    var tonghophopdong = PBIDATA.TBL_DANHMUCHOPDONG.SingleOrDefault(n => n.MACN == i.MACN && n.MAHD == i.MAHD && n.MAKH == i.MAKH);
                    var hoadon = PBIDATA.DTA_XUAT_CHITIET_HOADON.Where(n => n.NGAYLAPHD >= tonghophopdong.NGAYBATDAU && n.NGAYLAPHD <= denngay && n.MAHD == i.MAHD && n.MAKH == i.MAKH && n.MACN == i.MACN).ToList().Select(c => new DTA_XUAT_CHITIET_HOADON { NGAYLAPHD = c.NGAYLAPHD, SOLUONG = c.SOLUONG, TENHH = c.TENHH, TENDVBC = c.TENDVBC, MATINH = c.MATINH, MAHH = c.MAHH, DONVI = c.DONVI }).ToList();
                    var datahopdong = (from t1 in PBIDATA.TBL_CT_DANHMUCHOPDONG join t2 in PBIDATA.TBL_DANHMUCHOPDONG on new { t1.MACN, t1.MAHD, t1.MAKH } equals new { t2.MACN, t2.MAHD, t2.MAKH } where t1.MACN == i.MACN && t1.MAHD == i.MAHD && t1.MAKH == i.MAKH select new ListKQHopdong { MACN = t2.MACN, MAHD = t1.MAHD, MAKH = t1.MAKH, ngaybatdau = t2.NGAYBATDAU, ngayketthuc = t2.NGAYKETTHUC, MAHH = t1.MAHH, SL = (t1.SOLUONG != null) ? (int)t1.SOLUONG : 0, tienhd = (t1.SOLUONG != null && t1.GIASP != null) ? (decimal)(t1.SOLUONG * t1.GIASP) : 0, TUNGAY = tungay, DENNGAY = denngay, sldauky = 0, sldu = 0, tiendauky = 0, tiendu = 0, tienps = 0, TT = 0, GIASP = (t1.GIASP != null) ? (decimal)(t1.GIASP) : 0 }).ToList();
                    foreach (var z in datahopdong)
                    {
                        z.tenhh = (danhmuchh.SingleOrDefault(n => n.MAHH == z.MAHH) != null) ? danhmuchh.SingleOrDefault(n => n.MAHH == z.MAHH).TENHH : "";
                        z.sldauky = (decimal)hoadon.Where(n => n.MAHH == z.MAHH && n.NGAYLAPHD >= tonghophopdong.NGAYBATDAU && n.NGAYLAPHD < tungay).Sum(n => n.SOLUONG);
                        z.tiendauky = z.sldauky * z.GIASP;
                        z.TT = (decimal)hoadon.Where(n => n.MAHH == z.MAHH && n.NGAYLAPHD >= tungay && n.NGAYLAPHD <= denngay).Sum(n => n.SOLUONG);
                        z.tienps = z.TT * z.GIASP;
                        z.DONVI = (khachhang.SingleOrDefault() != null) ? khachhang.SingleOrDefault().DONVI : "";
                        z.MATINH = (khachhang.SingleOrDefault() != null) ? khachhang.SingleOrDefault().MATINH : "";
                        z.TENDVBC = (macn.SingleOrDefault(n => n.macn == z.MACN) != null) ? macn.SingleOrDefault(n => n.macn == z.MACN).Tencn : "";
                        z.TENTINH = (matinh.SingleOrDefault(n => n.matinh == z.MATINH) != null) ? matinh.SingleOrDefault(n => n.matinh == z.MATINH).tentinh : "";
                        z.sldu = z.SL - z.sldauky - z.TT;
                        z.tiendu = z.sldu * z.GIASP;
                    }
                    if (mahh != null)
                    {
                        data.AddRange(datahopdong.Where(n => mahh.Contains(n.MAHH)));
                    }
                    else
                    {
                        data.AddRange(datahopdong);
                    }
                }
                catch (Exception)
                {

                }
            }

            return data;
        }

        private List<ListKQHopdong> DATAGETKQ(string ChiNhanhId, string str)
        {
            var data = new List<ListKQHopdong>();

            var Info = GetInfo();
            if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
            {
                queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.CommandTimeout = 3200;
                data = queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<ListKQHopdong>(str).ToList();
            }
            else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
            {
                queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.CommandTimeout = 3200;
                data = queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data.Database.SqlQuery<ListKQHopdong>(str).ToList();
            }

            return data;
        }
        private List<ListNhomSP> DATAGETSP(List<string> macn)
        {
            List<ListNhomSP> data = new List<ListNhomSP>();
            if (macn.Count > 1)
            {
                data = DULIEUNHOMSP(PhuYen).ToList();
            }
            else
            {
                var ChiNhanhId = macn.First();
                if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data = DULIEUNHOMSP(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data).ToList();
                }
                else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data = DULIEUCUAHANGNHOMSP(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data).ToList();
                }
            }
            return data;
        }

        private List<ListKhuVuc> DATAGETKHUVUC(List<string> macn, TBL_DANHMUCNGUOIDUNG Info)
        {
            List<ListKhuVuc> data = new List<ListKhuVuc>();
            foreach (var ChiNhanhId in macn)
            {
                if (queryCN.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data.AddRange(DULIEUKHUVUC(queryCN.SingleOrDefault(n => n.macn == ChiNhanhId).data).ToList());
                }
                else if (queryCH.SingleOrDefault(n => n.macn == ChiNhanhId) != null)
                {
                    data.AddRange(DULIEUCUAHANGKHUVUC(queryCH.SingleOrDefault(n => n.macn == ChiNhanhId).data).ToList());
                }

            }

            if (Info.matinh != "ALL")
            {
                var taphop = Info.matinh.Split(',').ToList();
                data = data.Distinct().Where(n => taphop.Contains(n.matinh)).ToList();
            }
            return data;
        }
        public List<ListKhuVuc> DULIEUKHUVUC(Entities data)
        {
            var All = data.Database.SqlQuery<ListKhuVuc>("SELECT MaTinh, TenTinh FROM TBL_DANHMUCDONVI WHERE MaTinh IS NOT NULL").ToList();
            return All;
        }
        public List<ListKhuVuc> DULIEUCUAHANGKHUVUC(CHQ10Entities1 data)
        {
            var All = data.Database.SqlQuery<ListKhuVuc>("SELECT MaTinh, TenTinh FROM DS_TINH WHERE MaTinh IS NOT NULL").ToList();
            return All;
        }

        public TBL_DANHMUCNGUOIDUNG GetInfo()
        {
            TBL_DANHMUCNGUOIDUNG abc = new TBL_DANHMUCNGUOIDUNG();
            abc = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == User.Identity.Name.ToString());
            return abc;
        }
        public List<ListNhomSP> DULIEUNHOMSP(Entities data)
        {
            var All = data.Database.SqlQuery<ListNhomSP>("SELECT MAHH,TENHH,nhom AS NHOM FROM TBL_DANHMUCHANGHOA WHERE MAHH IS NOT NULL AND NHOM IN ('50', '51', '60', '61', '62', '63', '70')").ToList();
            return All;
        }

        public List<ListNhomSP> DULIEUMIENBACNHOMSP(KT_TBEntities1 data)
        {
            var All = data.Database.SqlQuery<ListNhomSP>("SELECT  REPLACE(dclChiTietHangHoa.MACAP,' ','')  AS MAHH, (select dbo.TCVN2Unicode(dclChiTietHangHoa.TENCAP)) AS TENHH, SUBSTRING(REPLACE(dclChiTietHangHoa.MACAP, ' ', ''), 1, 2)  AS NHOM FROM dclChiTietHangHoa WHERE REPLACE(dclChiTietHangHoa.MACAP,' ','') IS NOT NULL").ToList();
            return All;
        }

        public List<ListNhomSP> DULIEUCUAHANGNHOMSP(CHQ10Entities1 data)
        {
            var All = data.Database.SqlQuery<ListNhomSP>("SELECT MAHH,TENHH,nhom AS NHOM FROM DM_HANGHOA WHERE MAHH IS NOT NULL AND NHOM IN ('50', '51', '60', '61', '62', '63', '70')").ToList();
            return All;
        }
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}