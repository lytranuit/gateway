using ApplicationChart.Models;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;


namespace ApplicationChart.Controllers
{
    public class ScheduleJob : IJob
    {
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();
        KT_THEntities1 DATATH1 = new KT_THEntities1("KT_THEntities1");
        KT_THEntities1 DATATH2 = new KT_THEntities1("KT_THEntities2");
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
       
        Entities ThanhHoa = new Entities("KT_THOEntities");
        Entities BinhThuan = new Entities("KT_BTEntities");

        CHQ10Entities1 PTTT = new CHQ10Entities1("PTTTEntities");
        CHQ10Entities1 CHQ10 = new CHQ10Entities1("CHQ10Entities");
        CHQ10Entities1 CHPPSP = new CHQ10Entities1("CHPPSPEntities");

        POWERBIEntities PBIDATA = new POWERBIEntities();
        //KT_THEntities1 DATATH2 = new KT_THEntities1("KT_THEntities2");
        public void Execute(IJobExecutionContext context)
        {
            PhuYen.Database.ExecuteSqlCommand("update DTA_DONDATHANG_KD set SOHD = 0 , NGAYLAPHD = NGAYTHUCHIEN where DUYETDH = 1 and SOHD is null");
            foreach (var i in db2.TBL_DANHMUCNGUOIDUNG.Where(n => n.nguoidung != "TGD" && n.nguoidung != "LUC" && n.nguoidung != "phamvantan"))
            {
                try
                {
                    if (i.truycap > 1 && i.ngaydangnhap != null)
                    {
                        TimeSpan span = DateTime.Now.Subtract((DateTime)i.ngaydangnhap);
                        if (span.TotalDays > db2.TBL_NGAYKHOATK.FirstOrDefault().Ngay)
                        {
                            TBL_DANHMUCNGUOIDUNG tv = db2.TBL_DANHMUCNGUOIDUNG.SingleOrDefault(n => n.nguoidung == i.nguoidung);
                            tv.khoatk = true;
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
            db2.SaveChanges();
        }
    }
    public class ScheduleJob2 : IJob
    {
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
        POWERBIEntities PBIDATA = new POWERBIEntities();
        public void Execute(IJobExecutionContext context)
        {
            //var soso = "NA,PTTT,HN,HCM,PY,SC".Split(',').ToList();
            var soso = "HN,PT,TB,TNG,HP,PTTT,HCM,CHQ10,CT,AG,CM,DN,LD,TG,TN,VL,BDG,BT,PY,QN,TT423,BD,DNA,GL,HUE,NA,NT,THO".Split(',').ToList();
            var strcn = "EXEC A_HOPDONG_CHUYEN";
            var data = new List<DATAHOPDONG>();
            var log = "";

            foreach (var i in soso)
            {
                try
                {
                    if (queryCN.SingleOrDefault(n => n.macn == i) != null)
                    {
                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320000;
                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(strcn);
                        //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                    else if (queryCH.SingleOrDefault(n => n.macn == i) != null)
                    {
                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320000;
                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(strcn);
                        //PBIDATA.DTA_TONKHO.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").GroupBy(n => n.mahh).Select(cl => new DTA_TONKHO() { macn = i, mahh = cl.Key, nam = nam, thang = thang, slton = cl.Sum(z => z.slton) }));
                        //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                }
                catch (Exception ex)
                {
                    log = log + "," + i;
                }

            }
            //var soso = "HN,PT,TB,TNG,HP,PTTT,HCM,CHQ10,CT,AG,CM,DN,LD,TG,TN,VL,BDG,BT,PY,QN,TT423,BD,DNA,GL,HUE,NA,NT,THO".Split(',').ToList();
            //if (macn != null && macn != "")
            //{
            //    soso = macn.Split(',').ToList();
            //}

            //var strcn = "select MACN,* from TBL_DANHMUCHOPDONG where MAKH not in ('') and MAHD not in ('') and NGAYKETTHUC > '2022-01-01'";
            //var data = new List<DATAHOPDONG>();
            //var log = "";
            foreach (var i in soso)
            {
                try
                {
                    if (queryCN.SingleOrDefault(n => n.macn == i) != null)
                    {
                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 3200;
                        data.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.Database.SqlQuery<DATAHOPDONG>(strcn.Replace("MACN", "'" + i + "' AS MACN")).ToList());
                        //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                    else if (queryCH.SingleOrDefault(n => n.macn == i) != null)
                    {
                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 3200;
                        data.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.Database.SqlQuery<DATAHOPDONG>(strcn.Replace("MACN", "'" + i + "' AS MACN")).ToList());
                        //PBIDATA.DTA_TONKHO.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").GroupBy(n => n.mahh).Select(cl => new DTA_TONKHO() { macn = i, mahh = cl.Key, nam = nam, thang = thang, slton = cl.Sum(z => z.slton) }));
                        //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                }
                catch (Exception ex)
                {
                    log = log + "," + i;
                }
            }
            var data1 = data.Select(cl => new TBL_DANHMUCHOPDONG() { MACN = cl.MACN, donvi = cl.donvi, GHICHU = cl.GHICHU, LOAIHD = cl.LOAIHD, MAHD = cl.MAHD, MAKH = cl.MAKH, MAQD = cl.MAQD, NGAYBATDAU = cl.NGAYBATDAU, NGAYKETTHUC = cl.NGAYKETTHUC, NGAYQD = cl.NGAYQD, nguoidung = cl.nguoidung, noidung = cl.noidung, phuluc = cl.phuluc, TENQD = cl.TENQD });
            var data2 = new List<TBL_CT_DANHMUCHOPDONG>();
            foreach (var i in data)
            {
                if (i.sp != null && i.sp != "")
                {
                    var mahh = i.sp.Split(',').ToList();
                    var giaban = i.GIASP.Split(',').ToList();
                    if (mahh.Count() == giaban.Count())
                    {
                        for (int e = 0; e < mahh.Count; e++)
                        {
                            var dulieu = new TBL_CT_DANHMUCHOPDONG();
                            if (mahh[e] != "")
                            {
                                dulieu.MAHH = mahh[e];

                                try
                                {
                                    dulieu.GIASP = (giaban[e] != "") ? decimal.Parse(giaban[e].Replace(".00", "").Replace(".0", "")) : 0;
                                }
                                catch (Exception)
                                {
                                    dulieu.GIASP = 0;
                                }
                                //try
                                //{
                                //    dulieu.PHI = (i.PHI != null) ? i.PHI.Split(',').ToList()[e] : null;
                                //}
                                //catch (Exception)
                                //{
                                //    dulieu.PHI = null;
                                //}
                                try
                                {
                                    dulieu.SODK = (i.sodk != null) ? i.sodk.Split(',').ToList()[e] : null;
                                }
                                catch (Exception)
                                {
                                    dulieu.SODK = null;
                                }
                                try
                                {
                                    dulieu.SOLUONG = (i.SL != null) ? int.Parse(i.SL.Split(',').ToList()[e]) : 0;
                                }
                                catch (Exception)
                                {
                                    dulieu.SOLUONG = null;
                                }

                                dulieu.MACN = i.MACN;
                                dulieu.MAHD = i.MAHD;
                                dulieu.MAKH = i.MAKH;
                                data2.Add(dulieu);
                            }

                        }
                    }
                }


                //data2.AddRange(Enumerable.Range(0, mahh.Count).Select(z => new TBL_CT_DANHMUCHOPDONG()
                //{

                //    MAHH = mahh[z],
                //    GIASP = (giaban[z] != "") ? decimal.Parse(giaban[z]) : 0,
                //    //PHI = (i.PHI != null) ? i.PHI.Split(',').ToList()[z] : null,
                //    SODK = (i.sodk != null) ? i.sodk.Split(',').ToList()[z] : null,
                //    //SOLUONG = (i.SL != null) ? int.Parse((i.SL.Split(',').ToList()[z] != "") ? i.SL.Split(',').ToList()[z] : "0") : 0,
                //    MACN = i.MACN,
                //    MAHD = i.MAHD,
                //    MAKH = i.MAKH
                //}).ToList());
            }
            data2 = data2.GroupBy(n => new { n.MACN, n.MAHD, n.MAKH, n.MAHH }).Select(n => new TBL_CT_DANHMUCHOPDONG() { GIASP = n.First().GIASP, MACN = n.Key.MACN, MAHD = n.Key.MAHD, MAHH = n.Key.MAHH, MAKH = n.Key.MAKH, PHI = n.First().PHI, SODK = n.First().SODK, SOLUONG = n.First().SOLUONG }).ToList();
            PBIDATA.TBL_DANHMUCHOPDONG.RemoveRange(PBIDATA.TBL_DANHMUCHOPDONG);
            PBIDATA.TBL_CT_DANHMUCHOPDONG.RemoveRange(PBIDATA.TBL_CT_DANHMUCHOPDONG);
            PBIDATA.TBL_DANHMUCHOPDONG.AddRange(data1);
            PBIDATA.TBL_CT_DANHMUCHOPDONG.AddRange(data2);
            PBIDATA.SaveChanges();

        }
    }
    public class ScheduleJob3 : IJob
    {
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();
        KT_THEntities1 DATATH1 = new KT_THEntities1("KT_THEntities1");
        KT_THEntities1 DATATH2 = new KT_THEntities1("KT_THEntities2");
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
        
        Entities ThanhHoa = new Entities("KT_THOEntities");
        Entities BinhThuan = new Entities("KT_BTEntities");

        CHQ10Entities1 PTTT = new CHQ10Entities1("PTTTEntities");
        CHQ10Entities1 CHQ10 = new CHQ10Entities1("CHQ10Entities");
        CHQ10Entities1 CHPPSP = new CHQ10Entities1("CHPPSPEntities");

        POWERBIEntities PBIDATA = new POWERBIEntities();
        //KT_THEntities1 DATATH2 = new KT_THEntities1("KT_THEntities2");
        public List<DULIEUBAOCAOPOWERBI> BAOCAOCHINHANHPOWERBI(Entities data, string str)
        {
            data.Database.CommandTimeout = 60000;
            var All = data.Database.SqlQuery<DULIEUBAOCAOPOWERBI>(str).ToList();
            return All;
        }
        public List<DULIEUBAOCAOPOWERBI> BAOCAOCUAHANGPOWERBI(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 60000;
            var All = data.Database.SqlQuery<DULIEUBAOCAOPOWERBI>(str).ToList();
            return All;
        }
        public List<DTA_XUAT_CHITIET_HOADON> BAOCAOCHINHANHLAY2(Entities data, string str)
        {
            data.Database.CommandTimeout = 60000;
            var All = data.Database.SqlQuery<DTA_XUAT_CHITIET_HOADON>(str).ToList();
            return All;
        }
        public List<DTA_XUAT_CHITIET_HOADON> BAOCAOCUAHANGLAY2(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 60000;
            var All = data.Database.SqlQuery<DTA_XUAT_CHITIET_HOADON>(str).ToList();
            return All;
        }
        public void Execute(IJobExecutionContext context)
        {
            var tungay1 = DateTime.Today.AddMonths(-3).ToString("01/MM/yyyy");
            var denngay1 = DateTime.Today.ToString("dd/MM/yyyy");

            if (DateTime.Today.Month < 4)
            {
                switch (DateTime.Today.Month)
                {
                    case 1:
                        tungay1 = DateTime.Today.ToString("01/MM/yyyy");
                        break;
                    case 2:
                        tungay1 = DateTime.Today.AddMonths(-1).ToString("01/MM/yyyy");
                        break;
                    default:
                        tungay1 = DateTime.Today.AddMonths(-2).ToString("01/MM/yyyy");
                        break;
                }               
            }

            PBIDATA.Database.CommandTimeout = 320000;
            DateTime tungay = DateTime.ParseExact(tungay1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime denngay = DateTime.ParseExact(denngay1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var soso = "HN,PT,TB,TNG,HP,PTTT,HCM,CHQ10,CT,AG,CM,DN,LD,TG,TN,VL,BDG,BT,PY,QN,TT423,BD,DNA,GL,HUE,NA,NT,THO,CHPPSP,SC".Split(',').ToList();
            var mapl = "BAN,XK,PP,TM,WS".Split(',').ToList();
            //PBIDATA.DTA_XUAT_CHITIET_HOADON.RemoveRange(PBIDATA.DTA_XUAT_CHITIET_HOADON.Where(n => n.NGAYLAPHD.Value.Year == denngay.Year));
            PBIDATA.Database.ExecuteSqlCommand("DELETE FROM DTA_XUAT_CHITIET_HOADON WHERE NGAYLAPHD >= '"+ tungay.ToString("MM/dd/yyyy") +"' AND NGAYLAPHD <= '"+ denngay.ToString("MM/dd/yyyy") + "'" );
            //String CN
            string strcn1 = "seleCT MACN ,TBL_DANHMUCKHACHHANG.quanhuyen as QUANHUYEN, TBL_DANHMUCKHACHHANG.Diachi as DIACHI, TBL_DANHMUCKHACHHANG.phanloai as PHANLOAI, TBL_DANHMUCKHACHHANG.hanmuc as HANMUC, TBL_DANHMUCKHACHHANG.ngayno as NGAYNO, TBL_DANHMUCKHACHHANG.tinhtrang as TINHTRANG, SUM((ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)  -  ROUND(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CT.TYLECK/100,0) ) *HOADON.THUESUAT/100) AS TIENVAT,HOADON.SOHD as SOHD,HOADON.MaTDV AS MATDV ,TBL_DANHMUCTDV.TenTDV AS TENTDV,HOADON.ngaylaphd AS NGAYLAPHD, HOADON.MaPL as PHANLOAIHD,TBL_MIEN.mien AS MIEN,TBL_DANHMUCTIEUDEBAOCAO.tendvbc AS TENDVBC,TBL_DANHMUCKHACHHANG.matinh AS MATINH,CT.MAKM AS MACTKM,CT.MACTHT AS MACTHT,CT.mahh AS MAHH,TBL_DANHMUCHANGHOA.TENHH AS TENHH, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, SUM(CAST(CT.SOLUONG AS MONEY)) AS SOLUONG, CAST(CT.DonGia AS MONEY) AS DONGIA, CT.DVT, CT.MaLo AS SOLO, CT.HanDung as HANDUNG, TBL_DANHMUCHANGHOA.nhom AS NHOM, ROUND(CAST(CT.SOLUONG AS MONEY) * (CAST(CT.DONGIA AS MONEY)), 0) AS DOANHTHU, SUM(ROUND(CAST(CT.SOLUONG AS MONEY) * (CAST(CT.DONGIA AS MONEY)), 0)) - SUM(round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY), 0)*CAST(TYLECK AS MONEY)/100, 0)) AS DOANHTHUTHUAN, HOADON.HOPDONG AS MAHD from TBL_MIEN, TBL_DANHMUCTIEUDEBAOCAO, DTA_CT_HOADON_XUAT CT LEFT JOIN   TBL_DANHMUCHANGHOA ON CT.mahh = TBL_DANHMUCHANGHOA.mahh, DTA_HOADON_XUAT HOADON   LEFT JOIN   TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh LEFT JOIN TBL_DANHMUCTDV on HOADON.matdv = TBL_DANHMUCTDV.MaTDV where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1  AND HOADON.SOHD_DT is not null ";
            //String CH
            string strch1 = "Select MACN ,TBL_DANHMUCKHACHHANG.quanhuyen as QUANHUYEN, TBL_DANHMUCKHACHHANG.Diachi as DIACHI, TBL_DANHMUCKHACHHANG.PHANLOAI, TBL_DANHMUCKHACHHANG.hanmuc as HANMUC, TBL_DANHMUCKHACHHANG.ngayno as NGAYNO, TBL_DANHMUCKHACHHANG.tinhtrang as TINHTRANG, SUM((ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)  -  ROUND(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CT.TYLECK/100,0) ) *HOADON.THUESUAT/100) AS TIENVAT,HOADON.SOHD as SOHD,HOADON.MaTDV AS MATDV,DS_TDV_PTTT.TenTDV AS TENTDV,HOADON.ngaylaphd AS NGAYLAPHD, HOADON.MaPL as PHANLOAIHD, TBL_MIEN.mien AS MIEN, TBL_DANHMUCTIEUDEBAOCAO.tendvbc AS TENDVBC, TBL_DANHMUCKHACHHANG.matinh AS MATINH,CT.MAKM AS MACTKM , CT.mahh AS MAHH, DM_HANGHOA.TENHH AS TENHH, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, SUM(CAST(CT.SOLUONG AS MONEY)) AS SOLUONG, CAST(CT.DonGia AS MONEY) AS DONGIA , CT.DVT , CT.MaLo AS SOLO, CT.HanDung as HANDUNG ,DM_HANGHOA.nhom AS NHOM , ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0) AS DOANHTHU,SUM(ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)) - SUM(round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY), 0)*CAST(TYLECK AS MONEY)/100, 0)) AS DOANHTHUTHUAN, HOADON.HOPDONG AS MAHD from TBL_MIEN,tieude TBL_DANHMUCTIEUDEBAOCAO, CT_HOADON_XUAT CT  LEFT JOIN  DM_HANGHOA ON CT.mahh = DM_HANGHOA.mahh, DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG right join HOADON_XUAT  HOADON on TBL_DANHMUCKHACHHANG.makh = HOADON.makh left join DS_TDV_PTTT on HOADON.MaTDV = DS_TDV_PTTT.MaTDV  where HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' and '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1  AND HOADON.SOHD_DT is not null ";
            if (mapl != null)
            {
                strcn1 = strcn1 + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                strch1 = strch1 + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }//String MB
            strcn1 = strcn1 + " GROUP BY TBL_DANHMUCTDV.TenTDV,TBL_DANHMUCKHACHHANG.Diachi,HOADON.HOPDONG,TBL_DANHMUCKHACHHANG.quanhuyen,TBL_DANHMUCKHACHHANG.ngayno,TBL_DANHMUCKHACHHANG.hanmuc,TBL_DANHMUCKHACHHANG.tinhtrang,HOADON.SOHD,CT.MAKM,CT.MaLo,CT.HanDung,CT.MACTHT,HOADON.MATDV,HOADON.ngaylaphd, HOADON.MaPL, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, TBL_DANHMUCHANGHOA.TENHH, TBL_DANHMUCKHACHHANG.phanloai, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, CAST(CT.SOLUONG AS MONEY), CT.DonGia, CT.DVT, TBL_DANHMUCHANGHOA.nhom, ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)";
            strch1 = strch1 + " GROUP BY DS_TDV_PTTT.TenTDV,TBL_DANHMUCKHACHHANG.Diachi,HOADON.HOPDONG,TBL_DANHMUCKHACHHANG.quanhuyen,TBL_DANHMUCKHACHHANG.ngayno,TBL_DANHMUCKHACHHANG.hanmuc,TBL_DANHMUCKHACHHANG.tinhtrang,HOADON.SOHD,CT.MAKM,CT.MaLo,CT.HanDung ,HOADON.MaTDV,DM_HANGHOA.nhom, HOADON.MaPL, HOADON.ngaylaphd, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, DM_HANGHOA.TENHH, TBL_DANHMUCKHACHHANG.phanloai, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, CAST(CT.SOLUONG AS MONEY), CT.DonGia, CT.DVT, ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)";                                                                                                                                                                                                                                                                                                                                                                                                                                        //var soso = "CHPPSP".Split(',').ToList();                                                                                                                                                                                                                                                                                                                                                                                                                       //,CT,AG,CM,DN,LD,TG,TN,VL,BDG,BT
            if (mapl.Contains("TH") || mapl.Contains("NTH"))
            {
                strcn1 = strcn1.Replace("DTA_HOADON_XUAT", "DTA_HOADON_NHAP").Replace("DTA_CT_HOADON_XUAT", "DTA_CT_HOADON_NHAP").Replace("AND HOADON.MACH = CT.MACH", "");
                strch1 = strch1.Replace("HOADON_XUAT", "HOADON_NHAP").Replace("CT_HOADON_XUAT", "CT_HOADON_NHAP").Replace("AND HOADON.MACH = CT.MACH", "").Replace("*(1 + HOADON.THUESUAT/100.0)", "");
            }
            if (soso == null)
            {
                soso = "HN,PT,TB,TNG,HP,PTTT,HCM,CHQ10,CT,AG,CM,DN,LD,TG,TN,VL,BDG,BT,PY,QN,TT423,BD,DNA,GL,HUE,NA,NT,THO,CHPPSP,SC".Split(',').ToList();
            }
            foreach (var x in soso)
            {
                var strcn = strcn1.Replace("MACN", "'" + x + "' AS MACN");
                var strch = strch1.Replace("MACN", "'" + x + "' AS MACN");
                if (x == "QN")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(QuangNgai, strcn));
                }
                else if (x == "TN")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(TayNinh, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }

                else if (x == "CHQ10")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCUAHANGLAY2(CHQ10, strch));
                }
                else if (x == "CHPPSP")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCUAHANGLAY2(CHPPSP, strch.Replace("SOHD_DT", "SoHD")));
                }
                else if (x == "TT423")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(TT423, strcn));
                }
                else if (x == "BD")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(BinhDinh, strcn));
                }
                else if (x == "CT")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(CanTho, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DN")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(DongNai, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "BDG")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(BinhDuong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DNA")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(DaNang, strcn));
                }
                else if (x == "HCM")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(HoChiMinh, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "NA")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(NgheAn, strcn));
                }
                else if (x == "HN")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(HaNoi, strcn));
                }
                else if (x == "TB")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(ThaiBinh, strcn));
                }
                else if (x == "PT")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(PhuTho, strcn));
                }
                else if (x == "TNG")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(ThaiNguyen, strcn));
                }
                else if (x == "BT")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(BinhThuan, strcn));
                }

                else if (x == "THO")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(ThanhHoa, strcn));
                }
                //else if (x == "PT2")
                //{
                //    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOMIENBAC(PhuTho2, strnew));
                //}
                else if (x == "PY")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(PhuYen, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "SC")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(SC, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "AG")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(AnGiang, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "CM")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(CaMau, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "GL")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(GiaLai, strcn));
                }
                else if (x == "HUE")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(Hue, strcn));
                }
                else if (x == "HP")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(HaiPhong, strcn));
                }
                else if (x == "LD")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(LamDong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "NT")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(NhaTrang, strcn));
                }
                else if (x == "TG")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(TienGiang, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "VL")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCHINHANHLAY2(VinhLong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "PTTT")
                {
                    PBIDATA.DTA_XUAT_CHITIET_HOADON.AddRange(BAOCAOCUAHANGLAY2(PTTT, strch));
                }
            }
            PBIDATA.TBL_THOIGIAN_CHITIET_HOADON.RemoveRange(PBIDATA.TBL_THOIGIAN_CHITIET_HOADON);
            PBIDATA.TBL_THOIGIAN_CHITIET_HOADON.Add(new TBL_THOIGIAN_CHITIET_HOADON() { thoigian = DateTime.Now });
            PBIDATA.SaveChanges();
        }
    }
    public class ScheduleJob4 : IJob
    {
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();
        KT_THEntities1 DATATH1 = new KT_THEntities1("KT_THEntities1");
        KT_THEntities1 DATATH2 = new KT_THEntities1("KT_THEntities2");
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
        
        Entities ThanhHoa = new Entities("KT_THOEntities");
        Entities BinhThuan = new Entities("KT_BTEntities");

        CHQ10Entities1 PTTT = new CHQ10Entities1("PTTTEntities");
        CHQ10Entities1 CHQ10 = new CHQ10Entities1("CHQ10Entities");
        CHQ10Entities1 CHPPSP = new CHQ10Entities1("CHPPSPEntities");

        POWERBIEntities PBIDATA = new POWERBIEntities();
        //KT_THEntities1 DATATH2 = new KT_THEntities1("KT_THEntities2");
        public List<DTA_XUAT_CHITIET> BAOCAOCUAHANGLAY(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 6000;
            var All = data.Database.SqlQuery<DTA_XUAT_CHITIET>(str).ToList();
            var kq = (from item1 in All
                      join item2 in PBIDATA.TBL_CUSTOMER_CHANNEL on new { item1.PHANLOAI, item1.phanloaikhachhang } equals new { item2.PHANLOAI, item2.phanloaikhachhang }
                      select new DTA_XUAT_CHITIET()
                      {
                          THANG = item1.THANG,
                          NAM = item1.NAM,
                          TENDVBC = item1.TENDVBC,
                          MATINH = item1.MATINH,
                          QUANHUYEN = item1.QUANHUYEN,
                          MIEN = item1.MIEN,
                          PHANLOAIHD = item1.PHANLOAIHD,
                          PHANLOAI = item1.PHANLOAI,
                          NHOM = item1.NHOM,
                          MATDV = item1.MATDV,
                          TENTDV = item1.TENTDV,
                          phanloaikhachhang = item1.phanloaikhachhang,
                          MAHH = item1.MAHH,
                          TENHH = item1.TENHH,
                          SOLUONG = item1.SOLUONG,
                          MAKH = item1.MAKH,
                          DONVI = item1.DONVI,
                          DIACHI = item1.DIACHI,
                          DOANHTHUTHUAN = item1.DOANHTHUTHUAN,
                          DOANHTHU = item1.DOANHTHU,
                          TIENVAT = item1.TIENVAT,
                          id = item1.id,
                          KENH = item2.KENH
                      }).ToList();
            return kq;

        }
        public List<DTA_XUAT_CHITIET> BAOCAOCHINHANHLAY(Entities data, string str)
        {
            data.Database.CommandTimeout = 6000;
            var All = data.Database.SqlQuery<DTA_XUAT_CHITIET>(str).ToList();
            var kq = (from item1 in All
                      join item2 in PBIDATA.TBL_CUSTOMER_CHANNEL on new { item1.PHANLOAI, item1.phanloaikhachhang } equals new { item2.PHANLOAI, item2.phanloaikhachhang }
                      select new DTA_XUAT_CHITIET()
                      {
                          THANG = item1.THANG,
                          NAM = item1.NAM,
                          TENDVBC = item1.TENDVBC,
                          MATINH = item1.MATINH,
                          QUANHUYEN = item1.QUANHUYEN,
                          MIEN = item1.MIEN,
                          PHANLOAIHD = item1.PHANLOAIHD,
                          PHANLOAI = item1.PHANLOAI,
                          NHOM = item1.NHOM,
                          MATDV = item1.MATDV,
                          TENTDV = item1.TENTDV,
                          phanloaikhachhang = item1.phanloaikhachhang,
                          MAHH = item1.MAHH,
                          TENHH = item1.TENHH,
                          SOLUONG = item1.SOLUONG,
                          MAKH = item1.MAKH,
                          DONVI = item1.DONVI,
                          DIACHI = item1.DIACHI,
                          DOANHTHUTHUAN = item1.DOANHTHUTHUAN,
                          DOANHTHU = item1.DOANHTHU,
                          TIENVAT = item1.TIENVAT,
                          id = item1.id,
                          KENH = item2.KENH
                      }).ToList();
            return kq;

        }

        public void Execute(IJobExecutionContext context)
        {
            //var tungay = DateTime.Today.ToString("01/01/yyyy");
            //var denngay = DateTime.Today.ToString("31/12/yyyy");
            var tungay1 = DateTime.Today.AddMonths(-3).ToString("01/MM/yyyy");
            var denngay1 = DateTime.Today.ToString("dd/MM/yyyy");
           
            PBIDATA.Database.CommandTimeout = 320000;
            DateTime tungay = DateTime.ParseExact(tungay1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime denngay = DateTime.ParseExact(denngay1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var soso = "HN,PT,TB,TNG,HP,PTTT,HCM,CHQ10,CT,AG,CM,DN,LD,TG,TN,VL,BDG,BT,PY,QN,TT423,BD,DNA,GL,HUE,NA,NT,THO,CHPPSP,SC".Split(',').ToList();
            var mapl = "BAN,XK,PP,TM,WS".Split(',').ToList();
            //PBIDATA.DTA_XUAT_CHITIET.RemoveRange(PBIDATA.DTA_XUAT_CHITIET.Where(n => n.NAM == denngay1.Year));
            if(DateTime.Today.Month >= 4)
            {
                var listthang =new List<int>() { DateTime.Today.Month, DateTime.Today.Month - 1, DateTime.Today.Month - 2, DateTime.Today.Month - 3 };
                var strdel = string.Format("DELETE FROM DTA_XUAT_CHITIET WHERE THANG IN ({0}) AND NAM = " + DateTime.Today.Year, string.Join(",", listthang.Select(p => p)));
                PBIDATA.Database.ExecuteSqlCommand(strdel);
            }
            else
            {
                switch (DateTime.Today.Month)
                {
                    case 1:
                        var listthang = new List<int>() { DateTime.Today.Month, DateTime.Today.Month - 1, DateTime.Today.Month - 2, DateTime.Today.Month - 3 };
                        var strdel = string.Format("DELETE FROM DTA_XUAT_CHITIET WHERE THANG = 1 AND NAM = DateTime.Today.Year");
                        PBIDATA.Database.ExecuteSqlCommand(strdel);
                        break;
                    case 2:
                        listthang = new List<int>() { DateTime.Today.Month, DateTime.Today.Month - 1, DateTime.Today.Month - 2, DateTime.Today.Month - 3 };
                        strdel = string.Format("DELETE FROM DTA_XUAT_CHITIET WHERE THANG IN ({1,2}) AND NAM = DateTime.Today.Year");
                        PBIDATA.Database.ExecuteSqlCommand(strdel);
                        break;
                    default:
                        listthang = new List<int>() { DateTime.Today.Month, DateTime.Today.Month - 1, DateTime.Today.Month - 2, DateTime.Today.Month - 3 };
                        strdel = string.Format("DELETE FROM DTA_XUAT_CHITIET WHERE THANG IN (1,2,3) AND NAM = DateTime.Today.Year");
                        PBIDATA.Database.ExecuteSqlCommand(strdel);
                        break;
                }
                
            }
            //String CN
            string strcn1 = "SELECT MACN, MONTH(HOADON.NGAYLAPHD) AS THANG, YEAR(HOADON.NGAYLAPHD) AS NAM, TBL_DANHMUCTIEUDEBAOCAO.tendvbc AS TENDVBC, TBL_DANHMUCKHACHHANG.matinh AS MATINH, TBL_DANHMUCKHACHHANG.Diachi as DIACHI, TBL_MIEN.mien AS MIEN, TBL_DANHMUCKHACHHANG.quanhuyen as QUANHUYEN, TBL_DANHMUCKHACHHANG.phanloai as PHANLOAI, TBL_DANHMUCHANGHOA.nhom AS NHOM, HOADON.MaTDV AS MATDV, TBL_DANHMUCTDV.TenTDV AS TENTDV, TBL_DANHMUCKHACHHANG.phanloaikhachhang, CT.mahh AS MAHH, CT.tenhh AS TENHH, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, SUM(ROUND(CAST(CT.SOLUONG AS MONEY) * (CAST(CT.DONGIA AS MONEY)), 0)) - SUM(round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY), 0)*CAST(TYLECK AS MONEY)/100, 0)) AS DOANHTHUTHUAN, SUM(ROUND(CAST(CT.SOLUONG AS MONEY) * (CAST(CT.DONGIA AS MONEY)), 0)) AS DOANHTHU, SUM((ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)  -  ROUND(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CT.TYLECK/100,0) ) *HOADON.THUESUAT/100) AS TIENVAT,SUM(CAST(CT.SOLUONG AS MONEY)) AS SOLUONG, HOADON.MaPL AS PHANLOAIHD FROM TBL_MIEN, TBL_DANHMUCTIEUDEBAOCAO, DTA_CT_HOADON_XUAT CT LEFT JOIN TBL_DANHMUCHANGHOA ON CT.mahh = TBL_DANHMUCHANGHOA.mahh, DTA_HOADON_XUAT HOADON LEFT JOIN TBL_DANHMUCKHACHHANG ON HOADON.makh = TBL_DANHMUCKHACHHANG.makh LEFT JOIN TBL_DANHMUCTDV ON HOADON.matdv = TBL_DANHMUCTDV.MaTDV WHERE HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' AND '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1  AND HOADON.SOHD_DT is not null ";
            //String CH
            string strch1 = "SELECT MACN, MONTH(HOADON.NGAYLAPHD) AS THANG, YEAR(HOADON.NGAYLAPHD) AS NAM, TBL_DANHMUCTIEUDEBAOCAO.tendvbc AS TENDVBC, TBL_DANHMUCKHACHHANG.matinh AS MATINH, TBL_DANHMUCKHACHHANG.Diachi as DIACHI, TBL_MIEN.mien AS MIEN, TBL_DANHMUCKHACHHANG.quanhuyen as QUANHUYEN,TBL_DANHMUCKHACHHANG.PHANLOAI, DM_HANGHOA.nhom AS NHOM, TBL_DANHMUCKHACHHANG.MATDV AS MATDV, DS_TDV_PTTT.TenTDV AS TENTDV, TBL_DANHMUCKHACHHANG.phanloaikhachhang, CT.mahh AS MAHH, CT.tenhh AS TENHH, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, SUM(ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)) - SUM(round(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY), 0)*CAST(TYLECK AS MONEY)/100, 0)) AS DOANHTHUTHUAN, SUM(ROUND(CAST(CT.SOLUONG AS MONEY) * CAST(CT.DONGIA AS MONEY), 0)) AS DOANHTHU, SUM((ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)  -  ROUND(ROUND(CAST(CT.SOLUONG AS MONEY)*CAST(CT.DONGIA AS MONEY),0)*CT.TYLECK/100,0) ) *HOADON.THUESUAT/100) AS TIENVAT, SUM(CAST(CT.SOLUONG AS MONEY)) AS SOLUONG, HOADON.MaPL AS PHANLOAIHD FROM TBL_MIEN, tieude TBL_DANHMUCTIEUDEBAOCAO, CT_HOADON_XUAT CT LEFT JOIN DM_HANGHOA ON CT.mahh = DM_HANGHOA.mahh, DM_KHACHHANG_PTTT TBL_DANHMUCKHACHHANG RIGHT JOIN HOADON_XUAT HOADON ON TBL_DANHMUCKHACHHANG.makh = HOADON.makh LEFT JOIN DS_TDV_PTTT ON TBL_DANHMUCKHACHHANG.MaTDV = DS_TDV_PTTT.MaTDV WHERE HOADON.ngaylaphd BETWEEN '" + tungay.ToString("yyyy-MM-dd") + "' AND '" + denngay.ToString("yyyy-MM-dd") + "' AND HOADON.SOHD = CT.SOHD AND HOADON.NGAYLAPHD = CT.NGAYLAPHD AND HOADON.MACH = CT.MACH AND CT.KT = 1  AND HOADON.SOHD_DT is not null ";

            if (mapl != null)
            {
                strcn1 = strcn1 + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                strch1 = strch1 + string.Format(" AND HOADON.MaPL IN ({0})", string.Join(",", mapl.Select(p => "'" + p + "'")));
                //strnew = strnew + string.Format(" AND KT_TH.DBO.TBL_DANHMUCKHACHHANG.phanloai IN ({0})", "'" + phanloai + "'");
            }//String MB
            strcn1 = strcn1 + " GROUP BY TBL_DANHMUCTDV.TenTDV, MONTH(HOADON.NGAYLAPHD), YEAR(HOADON.NGAYLAPHD), HOADON.MATDV, TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.quanhuyen, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, CT.tenhh, TBL_DANHMUCKHACHHANG.phanloai,TBL_DANHMUCKHACHHANG.Diachi, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, TBL_DANHMUCHANGHOA.nhom, HOADON.MaPL";
            strch1 = strch1 + " GROUP BY DS_TDV_PTTT.TenTDV, TBL_DANHMUCKHACHHANG.MATDV, DM_HANGHOA.nhom, TBL_DANHMUCKHACHHANG.quanhuyen, TBL_DANHMUCKHACHHANG.PHANLOAI,TBL_DANHMUCKHACHHANG.Diachi, MONTH(HOADON.ngaylaphd), YEAR(HOADON.ngaylaphd), TBL_MIEN.mien, TBL_DANHMUCTIEUDEBAOCAO.tendvbc, TBL_DANHMUCKHACHHANG.matinh, CT.mahh, CT.tenhh, TBL_DANHMUCKHACHHANG.phanloaikhachhang, HOADON.MAKH, TBL_DANHMUCKHACHHANG.DONVI, HOADON.MaPL"; //var soso = "CT,AG,CM,DN,LD,TG,TN,VL,BDG,BT".Split(',').ToList();
                                                                                                                                                                                                                                                                                                                                                                                                                                                     //var soso = "CHPPSP".Split(',').ToList();                                                                                                                                                                                                                                                                                                                                                                                                                         //,CT,AG,CM,DN,LD,TG,TN,VL,BDG,BT
            if (mapl.Contains("TH") || mapl.Contains("NTH"))
            {
                strcn1 = strcn1.Replace("DTA_HOADON_XUAT", "DTA_HOADON_NHAP").Replace("DTA_CT_HOADON_XUAT", "DTA_CT_HOADON_NHAP").Replace("AND HOADON.MACH = CT.MACH", "");
                strch1 = strch1.Replace("HOADON_XUAT", "HOADON_NHAP").Replace("CT_HOADON_XUAT", "CT_HOADON_NHAP").Replace("AND HOADON.MACH = CT.MACH", "").Replace("*(1 + HOADON.THUESUAT/100.0)", "");
            }
            if (soso == null)
            {
                soso = "HN,PT,TB,TNG,HP,PTTT,HCM,CHQ10,CT,AG,CM,DN,LD,TG,TN,VL,BDG,BT,PY,QN,TT423,BD,DNA,GL,HUE,NA,NT,THO,CHPPSP,SC".Split(',').ToList();
            }

            foreach (var x in soso)
            {
                var strcn = strcn1.Replace("MACN", "'" + x + "' AS MACN");
                var strch = strch1.Replace("MACN", "'" + x + "' AS MACN");
                if (x == "QN")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(QuangNgai, strcn));
                }
                else if (x == "TN")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(TayNinh, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "CHQ10")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCUAHANGLAY(CHQ10, strch));
                }
                else if (x == "CHPPSP")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCUAHANGLAY(CHPPSP, strch.Replace("SOHD_DT", "SoHD")));
                }
                else if (x == "TT423")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(TT423, strcn));
                }
                else if (x == "BD")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(BinhDinh, strcn));
                }
                else if (x == "CT")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(CanTho, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DN")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(DongNai, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "BDG")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(BinhDuong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "DNA")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(DaNang, strcn));
                }
                else if (x == "HCM")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(HoChiMinh, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "NA")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(NgheAn, strcn));
                }
                else if (x == "HN")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(HaNoi, strcn));
                }
                else if (x == "TB")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(ThaiBinh, strcn));
                }
                else if (x == "PT")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(PhuTho, strcn));
                }
                else if (x == "TNG")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(ThaiNguyen, strcn));
                }
                else if (x == "BT")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(BinhThuan, strcn));
                }
                else if (x == "THO")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(ThanhHoa, strcn));
                }
                //else if (x == "PT2")
                //{
                //    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOMIENBAC(PhuTho2, strnew));
                //}
                else if (x == "PY")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(PhuYen, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "SC")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(SC, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "AG")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(AnGiang, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "CM")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(CaMau, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "GL")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(GiaLai, strcn));
                }
                else if (x == "HUE")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(Hue, strcn));
                }
                else if (x == "HP")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(HaiPhong, strcn));
                }
                else if (x == "LD")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(LamDong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "NT")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(NhaTrang, strcn));
                }
                else if (x == "TG")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(TienGiang, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }
                else if (x == "VL")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCHINHANHLAY(VinhLong, strcn.Replace(",CT.MACTHT AS MACTHT", "").Replace(",CT.MACTHT", "")));
                }

                else if (x == "PTTT")
                {
                    PBIDATA.DTA_XUAT_CHITIET.AddRange(BAOCAOCUAHANGLAY(PTTT, strch));
                }

            }
            PBIDATA.TBL_THOIGIAN_CHITIET.RemoveRange(PBIDATA.TBL_THOIGIAN_CHITIET);
            PBIDATA.TBL_THOIGIAN_CHITIET.Add(new TBL_THOIGIAN_CHITIET() { thoigian = DateTime.Now });
            PBIDATA.SaveChanges();
        }
    }
   
    public class ScheduleJob7 : IJob
    {
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
        POWERBIEntities PBIDATA = new POWERBIEntities();
        //KT_THEntities1 DATATH2 = new KT_THEntities1("KT_THEntities2");

        public void Execute(IJobExecutionContext context)
        {
            var messagle = "";
            var nam = DateTime.Today.Year;
            var thang = DateTime.Today.Month;
            PBIDATA.DTA_CONGNOHANGNGAY.RemoveRange(PBIDATA.DTA_CONGNOHANGNGAY.Where(n => n.NGAYCUOI.Month == thang && n.NGAYCUOI.Year == nam));
            var thangnay = new DateTime(nam, thang, 1);
            var macn = "HN,PT,TB,TNG,HP,PTTT,HCM,CHQ10,CT,AG,CM,DN,LD,TG,TN,VL,BDG,BT,PY,QN,TT423,BD,DNA,GL,HUE,NA,NT,THO,SC".Split(',').ToList();
            //var macn = "CHQ10".Split(',').ToList();

            var macn1 = macn.First();
            var denngay = (thangnay.Month == DateTime.Today.Month) ? DateTime.Today : new DateTime(nam, thang, 1).AddMonths(1).AddDays(-1);
            var ngaycuoithangtruoc = thangnay.AddDays(-1);
            //Đầu kỳ
            var str1 = "EXEC sp_kyhan_capnhap_DENNGAY_2 '131','" + ngaycuoithangtruoc.ToString("MM/dd/yyyy") + "'";
            //var str1 = "EXEC sp_kyhan_capnhap_DENNGAY_2 '131','" + DateTime.Today.ToString("MM/dd/yyyy") + "'";
            foreach (var i in macn)
            {
                try
                {
                    if (queryCN.SingleOrDefault(n => n.macn == i) != null)
                    {
                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320;
                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(str1);
                        //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                    else if (queryCH.SingleOrDefault(n => n.macn == i) != null)
                    {
                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320;
                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(str1);
                    }
                }
                catch (Exception ex)
                {
                    messagle = messagle + ". Bước 1 :" + i + " Lỗi : " + ex;
                }
            }
            var strcn = "DECLARE @ngay_etc int, @ngay_otc int, @ngay_etc_cu int, @ngay_otc_cu int SET @ngay_etc = (SELECT ngay FROM KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='ETC') SET @ngay_otc = (SELECT ngay FROM KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='OTC') SET @ngay_etc_cu = (SELECT ngay_cu FROM KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='ETC') SET @ngay_otc_cu = (SELECT ngay_cu FROM KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='OTC') DECLARE @TBL_IN TABLE(MACH VARCHAR(100),TENCH NVARCHAR(500), SCT VARCHAR(100), NGAY SMALLDATETIME, MAKH1 VARCHAR(100), DONVI NVARCHAR(500),MATDV NVARCHAR(500), MATINH NVARCHAR(500), PHANLOAI VARCHAR(20), PHANLOAIKHACHHANG VARCHAR(20), TIEN MONEY, NGAYDENHAN SMALLDATETIME, SONGAY FLOAT ,QUAHAN_SONGAY FLOAT ,D_0_6 FLOAT ,D_7_14 FLOAT ,D_15_30 FLOAT ,D_31_60 FLOAT ,D_61_90 FLOAT ,D_91_120 FLOAT ,D_121_180 FLOAT ,D_OVER_180 FLOAT ,QUAHAN_1_6 FLOAT ,QUAHAN_7_14 FLOAT ,QUAHAN_15_30 FLOAT ,QUAHAN_31_60 FLOAT ,QUAHAN_61_90 FLOAT ,QUAHAN_91_120 FLOAT ,QUAHAN_121_180 FLOAT ,QUAHAN_181_360 FLOAT ,QUAHAN_361_720 FLOAT ,QUAHAN_LON_720 FLOAT ,SONGAY_FORECAST_1 FLOAT ) INSERT INTO @TBL_IN(sct, ngay, makh1, tien) SELECT sct, ngay, makh, tien FROM DTA_KYHANCONGNO_TEMP UPDATE @TBL_IN SET DONVI = (SELECT DONVI FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET MATDV = (SELECT MATDV FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET MATINH = (SELECT MATINH FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAI = (SELECT PHANLOAI FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAIKHACHHANG = (SELECT PHANLOAIKHACHHANG FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAI='OTC' WHERE PHANLOAI NOT IN('OTC', 'ETC') UPDATE @TBL_IN SET TENCH = (SELECT TenCH FROM TBL_DANHMUCCUAHANG) UPDATE @TBL_IN SET MACH = (SELECT MACH FROM TBL_DANHMUCCUAHANG) DECLARE contro_tiennhap CURSOR FOR SELECT DISTINCT PHANLOAI FROM @TBL_IN OPEN contro_tiennhap DECLARE @PHANLOAI varchar(20) FETCH NEXT FROM contro_tiennhap INTO @PHANLOAI WHILE @@FETCH_STATUS=0 BEGIN IF @PHANLOAI='OTC' BEGIN UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngay_otc, ngay) WHERE PHANLOAI=@PHANLOAI AND ngay>'03/31/2023' UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngay_otc_cu, ngay) WHERE PHANLOAI=@PHANLOAI AND ngay<='03/31/2023' END ELSE BEGIN UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngay_etc, ngay) WHERE PHANLOAI=@PHANLOAI AND ngay>'03/31/2023' UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngay_etc_cu, ngay) WHERE PHANLOAI=@PHANLOAI AND ngay<='03/31/2023' END FETCH NEXT FROM contro_tiennhap INTO @PHANLOAI END CLOSE contro_tiennhap DEALLOCATE contro_tiennhap UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, 60, ngay) WHERE MAKH1 in ('50CT90') UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, 90, ngay) WHERE MAKH1 in ('78CT13') UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, 150, ngay) WHERE MAKH1 in ('78CT13_E') UPDATE @TBL_IN SET songay= DATEDIFF(dd, NGAYDENHAN, '" + ngaycuoithangtruoc.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET D_0_6=tien WHERE songay <=0 AND songay>=-6 UPDATE @TBL_IN SET D_7_14=tien WHERE songay<-6 AND songay>=-14 UPDATE @TBL_IN SET D_15_30=tien WHERE songay<-14 AND songay>=-30 UPDATE @TBL_IN SET D_31_60=tien WHERE songay<-30 AND songay>=-60 UPDATE @TBL_IN SET D_61_90=tien WHERE songay<-60 AND songay>=-90 UPDATE @TBL_IN SET D_91_120=tien WHERE songay<-90 AND songay>=-120 UPDATE @TBL_IN SET D_121_180=tien WHERE songay<-120 AND songay>=-180 UPDATE @TBL_IN SET D_OVER_180=tien WHERE songay<-180 UPDATE @TBL_IN SET QUAHAN_songay=DATEDIFF (dd, NGAYDENHAN, '" + ngaycuoithangtruoc.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET QUAHAN_1_6=tien WHERE QUAHAN_songay>0 AND QUAHAN_songay<=6 UPDATE @TBL_IN SET QUAHAN_7_14=tien WHERE QUAHAN_songay>6 AND QUAHAN_songay<=14 UPDATE @TBL_IN SET QUAHAN_15_30=tien WHERE QUAHAN_songay>14 AND QUAHAN_songay<=30 UPDATE @TBL_IN SET QUAHAN_31_60=tien WHERE QUAHAN_songay>30 AND QUAHAN_songay<=60 UPDATE @TBL_IN SET QUAHAN_61_90=tien WHERE QUAHAN_songay>60 AND QUAHAN_songay<=90 UPDATE @TBL_IN SET QUAHAN_91_120=tien WHERE QUAHAN_songay>90 AND QUAHAN_songay<=120 UPDATE @TBL_IN SET QUAHAN_121_180=tien WHERE QUAHAN_songay>120 AND QUAHAN_songay<=180 UPDATE @TBL_IN SET QUAHAN_181_360=tien WHERE QUAHAN_songay>180 AND QUAHAN_songay<=360 UPDATE @TBL_IN SET QUAHAN_361_720=tien WHERE QUAHAN_songay>360 AND QUAHAN_songay<=720 UPDATE @TBL_IN SET QUAHAN_LON_720=tien WHERE QUAHAN_songay>720 SELECT MACH,TENCH, MAKH1, DONVI, MATDV, MATINH, PHANLOAI, PHANLOAIKHACHHANG, SUM(ISNULL(D_0_6, 0)) +SUM(ISNULL(D_7_14, 0)) +SUM(ISNULL(D_15_30, 0)) +SUM(ISNULL(D_31_60, 0)) +SUM(ISNULL(D_61_90, 0)) +SUM(ISNULL(D_91_120, 0)) +SUM(ISNULL(D_121_180, 0)) +SUM(ISNULL(D_OVER_180, 0)) +SUM(ISNULL(QUAHAN_1_6, 0)) +SUM(ISNULL(QUAHAN_7_14, 0)) +SUM(ISNULL(QUAHAN_15_30, 0)) +SUM(ISNULL(QUAHAN_31_60, 0)) +SUM(ISNULL(QUAHAN_61_90, 0)) +SUM(ISNULL(QUAHAN_91_120, 0)) +SUM(ISNULL(QUAHAN_121_180, 0)) +SUM(ISNULL(QUAHAN_181_360, 0)) +SUM(ISNULL(QUAHAN_361_720, 0)) +SUM(ISNULL(QUAHAN_LON_720, 0)) AS OI_balance, SUM(ISNULL(QUAHAN_1_6, 0)) + SUM(ISNULL(QUAHAN_7_14, 0)) +SUM(ISNULL(QUAHAN_15_30, 0)) +SUM(ISNULL(QUAHAN_31_60, 0)) +SUM(ISNULL(QUAHAN_61_90, 0)) +SUM(ISNULL(QUAHAN_91_120, 0)) +SUM(ISNULL(QUAHAN_121_180, 0)) +SUM(ISNULL(QUAHAN_181_360, 0)) +SUM(ISNULL(QUAHAN_361_720, 0)) +SUM(ISNULL(QUAHAN_LON_720, 0)) AS OI_Balance_Overdue, SUM(ISNULL(QUAHAN_1_6, 0)) + SUM(ISNULL(QUAHAN_7_14, 0)) + SUM(ISNULL(QUAHAN_15_30, 0)) AS QUAHAN_1_30, SUM(ISNULL(QUAHAN_31_60, 0)) AS QUAHAN_31_60, SUM(ISNULL(QUAHAN_61_90, 0)) + SUM(ISNULL(QUAHAN_91_120, 0)) AS QUAHAN_61_120, SUM(ISNULL(QUAHAN_121_180, 0)) + SUM(ISNULL(QUAHAN_181_360, 0)) AS QUAHAN_121_360, SUM(ISNULL(QUAHAN_361_720, 0)) + SUM(ISNULL(QUAHAN_LON_720, 0)) AS QUAHAN_LON_360 FROM @TBL_IN GROUP BY MACH,TENCH, MAKH1, DONVI, MATDV, MATINH, PHANLOAI, PHANLOAIKHACHHANG";
            var strch = "DECLARE @ngay_etc int, @ngay_otc int, @ngay_etc_cu int, @ngay_otc_cu int SET @ngay_etc = (SELECT ngay FROM KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='ETC') SET @ngay_otc = (SELECT ngay FROM KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='OTC') SET @ngay_etc_cu = (SELECT ngay_cu FROM KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='ETC') SET @ngay_otc_cu = (SELECT ngay_cu FROM KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='OTC') DECLARE @TBL_IN TABLE(MACH VARCHAR(100), TENCH NVARCHAR(500), SCT VARCHAR(100), NGAY SMALLDATETIME, MAKH1 VARCHAR(100), DONVI NVARCHAR(500), MATINH NVARCHAR(500), PHANLOAI VARCHAR(20), PHANLOAIKHACHHANG VARCHAR(20), TIEN MONEY, NGAYDENHAN SMALLDATETIME, SONGAY FLOAT ,QUAHAN_SONGAY FLOAT ,D_0_6 FLOAT ,D_7_14 FLOAT ,D_15_30 FLOAT ,D_31_60 FLOAT ,D_61_90 FLOAT ,D_91_120 FLOAT ,D_121_180 FLOAT ,D_OVER_180 FLOAT ,QUAHAN_1_6 FLOAT ,QUAHAN_7_14 FLOAT ,QUAHAN_15_30 FLOAT ,QUAHAN_31_60 FLOAT ,QUAHAN_61_90 FLOAT ,QUAHAN_91_120 FLOAT ,QUAHAN_121_180 FLOAT ,QUAHAN_181_360 FLOAT ,QUAHAN_361_720 FLOAT ,QUAHAN_LON_720 FLOAT ,SONGAY_FORECAST_1 FLOAT ,SONGAY_FORECAST_2 FLOAT ,FORECAST_TUAN_1 FLOAT ,FORECAST_TUAN_2 FLOAT ,T1 FLOAT ,T2 FLOAT ,T3 FLOAT ,T4 FLOAT ,T5 FLOAT ,T6 FLOAT ,T7 FLOAT ,T8 FLOAT ,T9 FLOAT ,T10 FLOAT ,T11 FLOAT ,T12 FLOAT) INSERT INTO @TBL_IN(sct, ngay, makh1, tien) SELECT sct, ngay, makh, tien FROM DTA_KYHANCONGNO_TEMP UPDATE @TBL_IN SET DONVI = (SELECT DONVI FROM DM_KHACHHANG_PTTT WHERE MAKH=MAKH1) UPDATE @TBL_IN SET MATINH = (SELECT MATINH FROM DM_KHACHHANG_PTTT WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAI = (SELECT PHANLOAI FROM DM_KHACHHANG_PTTT WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAIKHACHHANG = (SELECT PHANLOAIKHACHHANG FROM DM_KHACHHANG_PTTT WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAI='OTC' WHERE PHANLOAI NOT IN('OTC', 'ETC') UPDATE @TBL_IN SET TENCH = (SELECT TenCH FROM TBL_DANHMUCCUAHANG) UPDATE @TBL_IN SET MACH = (SELECT MACH FROM TBL_DANHMUCCUAHANG) DECLARE contro_tiennhap CURSOR FOR SELECT DISTINCT PHANLOAI FROM @TBL_IN OPEN contro_tiennhap DECLARE @PHANLOAI varchar(20) FETCH NEXT FROM contro_tiennhap INTO @PHANLOAI WHILE @@FETCH_STATUS=0 BEGIN IF @PHANLOAI='OTC' BEGIN UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngay_otc, ngay) WHERE PHANLOAI=@PHANLOAI AND ngay>'03/31/2023' UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngay_otc_cu, ngay) WHERE PHANLOAI=@PHANLOAI AND ngay<='03/31/2023' END ELSE BEGIN UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngay_etc, ngay) WHERE PHANLOAI=@PHANLOAI AND ngay>'03/31/2023' UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngay_etc_cu, ngay) WHERE PHANLOAI=@PHANLOAI AND ngay<='03/31/2023' END FETCH NEXT FROM contro_tiennhap INTO @PHANLOAI END CLOSE contro_tiennhap DEALLOCATE contro_tiennhap UPDATE @TBL_IN SET songay= DATEDIFF(dd, NGAYDENHAN, '" + ngaycuoithangtruoc.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET SONGAY_FORECAST_1= DATEDIFF(dd, NGAYDENHAN- 7, '" + ngaycuoithangtruoc.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET SONGAY_FORECAST_2= DATEDIFF(dd, NGAYDENHAN-14, '" + ngaycuoithangtruoc.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET D_0_6=tien WHERE songay <=0 AND songay>=-6 UPDATE @TBL_IN SET D_7_14=tien WHERE songay<-6 AND songay>=-14 UPDATE @TBL_IN SET D_15_30=tien WHERE songay<-14 AND songay>=-30 UPDATE @TBL_IN SET D_31_60=tien WHERE songay<-30 AND songay>=-60 UPDATE @TBL_IN SET D_61_90=tien WHERE songay<-60 AND songay>=-90 UPDATE @TBL_IN SET D_91_120=tien WHERE songay<-90 AND songay>=-120 UPDATE @TBL_IN SET D_121_180=tien WHERE songay<-120 AND songay>=-180 UPDATE @TBL_IN SET D_OVER_180=tien WHERE songay<-180 UPDATE @TBL_IN SET QUAHAN_songay=DATEDIFF (dd, NGAYDENHAN, '" + ngaycuoithangtruoc.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET QUAHAN_1_6=tien WHERE QUAHAN_songay>0 AND QUAHAN_songay<=6 UPDATE @TBL_IN SET QUAHAN_7_14=tien WHERE QUAHAN_songay>6 AND QUAHAN_songay<=14 UPDATE @TBL_IN SET QUAHAN_15_30=tien WHERE QUAHAN_songay>14 AND QUAHAN_songay<=30 UPDATE @TBL_IN SET QUAHAN_31_60=tien WHERE QUAHAN_songay>30 AND QUAHAN_songay<=60 UPDATE @TBL_IN SET QUAHAN_61_90=tien WHERE QUAHAN_songay>60 AND QUAHAN_songay<=90 UPDATE @TBL_IN SET QUAHAN_91_120=tien WHERE QUAHAN_songay>90 AND QUAHAN_songay<=120 UPDATE @TBL_IN SET QUAHAN_121_180=tien WHERE QUAHAN_songay>120 AND QUAHAN_songay<=180 UPDATE @TBL_IN SET QUAHAN_181_360=tien WHERE QUAHAN_songay>180 AND QUAHAN_songay<=360 UPDATE @TBL_IN SET QUAHAN_361_720=tien WHERE QUAHAN_songay>360 AND QUAHAN_songay<=720 UPDATE @TBL_IN SET QUAHAN_LON_720=tien WHERE QUAHAN_songay>720 SELECT MACH, TENCH, MAKH1, DONVI, MATINH, PHANLOAI, PHANLOAIKHACHHANG, SUM(ISNULL(D_0_6, 0)) +SUM(ISNULL(D_7_14, 0)) +SUM(ISNULL(D_15_30, 0)) +SUM(ISNULL(D_31_60, 0)) +SUM(ISNULL(D_61_90, 0)) +SUM(ISNULL(D_91_120, 0)) +SUM(ISNULL(D_121_180, 0)) +SUM(ISNULL(D_OVER_180, 0)) +SUM(ISNULL(QUAHAN_1_6, 0)) +SUM(ISNULL(QUAHAN_7_14, 0)) +SUM(ISNULL(QUAHAN_15_30, 0)) +SUM(ISNULL(QUAHAN_31_60, 0)) +SUM(ISNULL(QUAHAN_61_90, 0)) +SUM(ISNULL(QUAHAN_91_120, 0)) +SUM(ISNULL(QUAHAN_121_180, 0)) +SUM(ISNULL(QUAHAN_181_360, 0)) +SUM(ISNULL(QUAHAN_361_720, 0)) +SUM(ISNULL(QUAHAN_LON_720, 0)) AS OI_balance, SUM(ISNULL(QUAHAN_1_6, 0)) + SUM(ISNULL(QUAHAN_7_14, 0)) +SUM(ISNULL(QUAHAN_15_30, 0)) +SUM(ISNULL(QUAHAN_31_60, 0)) +SUM(ISNULL(QUAHAN_61_90, 0)) +SUM(ISNULL(QUAHAN_91_120, 0)) +SUM(ISNULL(QUAHAN_121_180, 0)) +SUM(ISNULL(QUAHAN_181_360, 0)) +SUM(ISNULL(QUAHAN_361_720, 0)) +SUM(ISNULL(QUAHAN_LON_720, 0)) AS OI_Balance_Overdue, SUM(ISNULL(QUAHAN_1_6, 0)) + SUM(ISNULL(QUAHAN_7_14, 0)) + SUM(ISNULL(QUAHAN_15_30, 0)) AS QUAHAN_1_30, SUM(ISNULL(QUAHAN_31_60, 0)) AS QUAHAN_31_60, SUM(ISNULL(QUAHAN_61_90, 0)) + SUM(ISNULL(QUAHAN_91_120, 0)) AS QUAHAN_61_120, SUM(ISNULL(QUAHAN_121_180, 0)) + SUM(ISNULL(QUAHAN_181_360, 0)) AS QUAHAN_121_360, SUM(ISNULL(QUAHAN_361_720, 0)) + SUM(ISNULL(QUAHAN_LON_720, 0)) AS QUAHAN_LON_360 FROM @TBL_IN GROUP BY MACH, TENCH, MAKH1, DONVI, MATINH, PHANLOAI, PHANLOAIKHACHHANG";
            var DATAX = new List<DTA_CONGNOHANGNGAY>();
            foreach (var x in macn)
            {
                try
                {
                    if (x == "PY")
                    {
                        var strcn1 = "DECLARE @TBL_IN TABLE(MACH VARCHAR(100), TENCH NVARCHAR(500), SCT VARCHAR(100), NGAY SMALLDATETIME, MAKH1 VARCHAR(100), DONVI NVARCHAR(500), MATINH NVARCHAR(500), PHANLOAI VARCHAR(20), PHANLOAIKHACHHANG VARCHAR(20), TIEN MONEY, NGAYDENHAN SMALLDATETIME, SONGAY FLOAT ,QUAHAN_SONGAY FLOAT ,D_0_6 FLOAT ,D_7_14 FLOAT ,D_15_30 FLOAT ,D_31_60 FLOAT ,D_61_90 FLOAT ,D_91_120 FLOAT ,D_121_180 FLOAT ,D_OVER_180 FLOAT ,QUAHAN_1_6 FLOAT ,QUAHAN_7_14 FLOAT ,QUAHAN_15_30 FLOAT ,QUAHAN_31_60 FLOAT ,QUAHAN_61_90 FLOAT ,QUAHAN_91_120 FLOAT ,QUAHAN_121_180 FLOAT ,QUAHAN_181_360 FLOAT ,QUAHAN_361_720 FLOAT ,QUAHAN_LON_720 FLOAT ,SONGAY_FORECAST_1 FLOAT ,SONGAY_FORECAST_2 FLOAT ,FORECAST_TUAN_1 FLOAT ,FORECAST_TUAN_2 FLOAT ,T1 FLOAT ,T2 FLOAT ,T3 FLOAT ,T4 FLOAT ,T5 FLOAT ,T6 FLOAT ,T7 FLOAT ,T8 FLOAT ,T9 FLOAT ,T10 FLOAT ,T11 FLOAT ,T12 FLOAT) INSERT INTO @TBL_IN(sct, ngay, makh1, tien) SELECT sct, ngay, makh, tien FROM DTA_KYHANCONGNO_TEMP UPDATE @TBL_IN SET DONVI = (SELECT DONVI FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET MATINH = (SELECT MATINH FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAI = (SELECT PHANLOAI FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAIKHACHHANG = (SELECT PHANLOAIKHACHHANG FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAI='OTC' WHERE PHANLOAI NOT IN('OTC', 'ETC') UPDATE @TBL_IN SET TENCH = (SELECT TenCH FROM TBL_DANHMUCCUAHANG) UPDATE @TBL_IN SET MACH = (SELECT MACH FROM TBL_DANHMUCCUAHANG) DECLARE @ngayno_10 int DECLARE contro_tiennhap CURSOR FOR SELECT MAKH1 FROM @TBL_IN OPEN contro_tiennhap DECLARE @MAKH_10 varchar(20) FETCH NEXT FROM contro_tiennhap INTO @MAKH_10 WHILE @@FETCH_STATUS=0 BEGIN SET @ngayno_10= (SELECT isnull(ngayno, 0) FROM tbl_danhmuckhachhang WHERE makh=@MAKH_10) UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngayno_10, ngay) WHERE makh1=@MAKH_10 FETCH NEXT FROM contro_tiennhap INTO @MAKH_10 END CLOSE contro_tiennhap DEALLOCATE contro_tiennhap UPDATE @TBL_IN SET songay= DATEDIFF(dd, NGAYDENHAN, '" + ngaycuoithangtruoc.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET SONGAY_FORECAST_1= DATEDIFF(dd, NGAYDENHAN- 7, '" + ngaycuoithangtruoc.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET SONGAY_FORECAST_2= DATEDIFF(dd, NGAYDENHAN-14, '" + ngaycuoithangtruoc.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET D_0_6=tien WHERE songay <=0 AND songay>=-6 UPDATE @TBL_IN SET D_7_14=tien WHERE songay<-6 AND songay>=-14 UPDATE @TBL_IN SET D_15_30=tien WHERE songay<-14 AND songay>=-30 UPDATE @TBL_IN SET D_31_60=tien WHERE songay<-30 AND songay>=-60 UPDATE @TBL_IN SET D_61_90=tien WHERE songay<-60 AND songay>=-90 UPDATE @TBL_IN SET D_91_120=tien WHERE songay<-90 AND songay>=-120 UPDATE @TBL_IN SET D_121_180=tien WHERE songay<-120 AND songay>=-180 UPDATE @TBL_IN SET D_OVER_180=tien WHERE songay<-180 UPDATE @TBL_IN SET QUAHAN_songay=DATEDIFF (dd, NGAYDENHAN, '" + ngaycuoithangtruoc.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET QUAHAN_1_6=tien WHERE QUAHAN_songay>0 AND QUAHAN_songay<=6 UPDATE @TBL_IN SET QUAHAN_7_14=tien WHERE QUAHAN_songay>6 AND QUAHAN_songay<=14 UPDATE @TBL_IN SET QUAHAN_15_30=tien WHERE QUAHAN_songay>14 AND QUAHAN_songay<=30 UPDATE @TBL_IN SET QUAHAN_31_60=tien WHERE QUAHAN_songay>30 AND QUAHAN_songay<=60 UPDATE @TBL_IN SET QUAHAN_61_90=tien WHERE QUAHAN_songay>60 AND QUAHAN_songay<=90 UPDATE @TBL_IN SET QUAHAN_91_120=tien WHERE QUAHAN_songay>90 AND QUAHAN_songay<=120 UPDATE @TBL_IN SET QUAHAN_121_180=tien WHERE QUAHAN_songay>120 AND QUAHAN_songay<=180 UPDATE @TBL_IN SET QUAHAN_181_360=tien WHERE QUAHAN_songay>180 AND QUAHAN_songay<=360 UPDATE @TBL_IN SET QUAHAN_361_720=tien WHERE QUAHAN_songay>360 AND QUAHAN_songay<=720 UPDATE @TBL_IN SET QUAHAN_LON_720=tien WHERE QUAHAN_songay>720 SELECT MACH,TENCH, MAKH1, DONVI, MATINH, PHANLOAI, PHANLOAIKHACHHANG, SUM(ISNULL(D_0_6, 0)) +SUM(ISNULL(D_7_14, 0)) +SUM(ISNULL(D_15_30, 0)) +SUM(ISNULL(D_31_60, 0)) +SUM(ISNULL(D_61_90, 0)) +SUM(ISNULL(D_91_120, 0)) +SUM(ISNULL(D_121_180, 0)) +SUM(ISNULL(D_OVER_180, 0)) +SUM(ISNULL(QUAHAN_1_6, 0)) +SUM(ISNULL(QUAHAN_7_14, 0)) +SUM(ISNULL(QUAHAN_15_30, 0)) +SUM(ISNULL(QUAHAN_31_60, 0)) +SUM(ISNULL(QUAHAN_61_90, 0)) +SUM(ISNULL(QUAHAN_91_120, 0)) +SUM(ISNULL(QUAHAN_121_180, 0)) +SUM(ISNULL(QUAHAN_181_360, 0)) +SUM(ISNULL(QUAHAN_361_720, 0)) +SUM(ISNULL(QUAHAN_LON_720, 0)) AS OI_balance, SUM(ISNULL(QUAHAN_1_6, 0)) + SUM(ISNULL(QUAHAN_7_14, 0)) +SUM(ISNULL(QUAHAN_15_30, 0)) +SUM(ISNULL(QUAHAN_31_60, 0)) +SUM(ISNULL(QUAHAN_61_90, 0)) +SUM(ISNULL(QUAHAN_91_120, 0)) +SUM(ISNULL(QUAHAN_121_180, 0)) +SUM(ISNULL(QUAHAN_181_360, 0)) +SUM(ISNULL(QUAHAN_361_720, 0)) +SUM(ISNULL(QUAHAN_LON_720, 0)) AS OI_Balance_Overdue, SUM(ISNULL(QUAHAN_1_6, 0)) + SUM(ISNULL(QUAHAN_7_14, 0)) + SUM(ISNULL(QUAHAN_15_30, 0)) AS QUAHAN_1_30, SUM(ISNULL(QUAHAN_31_60, 0)) AS QUAHAN_31_60, SUM(ISNULL(QUAHAN_61_90, 0)) + SUM(ISNULL(QUAHAN_91_120, 0)) AS QUAHAN_61_120, SUM(ISNULL(QUAHAN_121_180, 0)) + SUM(ISNULL(QUAHAN_181_360, 0)) AS QUAHAN_121_360, SUM(ISNULL(QUAHAN_361_720, 0)) + SUM(ISNULL(QUAHAN_LON_720, 0)) AS QUAHAN_LON_360 FROM @TBL_IN GROUP BY MACH,TENCH, MAKH1, DONVI, MATINH, PHANLOAI, PHANLOAIKHACHHANG";
                        DATAX.AddRange(queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DTA_CONGNOHANGNGAY>(strcn1).ToList());
                    }
                    else if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                    {
                        DATAX.AddRange(queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DTA_CONGNOHANGNGAY>(strcn).ToList());
                    }
                    else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                    {
                        DATAX.AddRange(queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DTA_CONGNOHANGNGAY>(strch).ToList());
                    }
                }
                catch (Exception ex)
                {
                    messagle = messagle + ". Bước 2 :" + x + " Lỗi : " + ex;
                }
            }
            //Doanh số trong tháng
            var khloaitru = ("78TT26,13111,1320").Split(',').ToList();
            var data0 = DATABAOCAO3(macn, thangnay, denngay, "ALL", null, null, null, null).Where(n => !khloaitru.Contains(n.MAKH)).ToList();


            foreach (var i in data0)
            {
                try
                {
                    var tv = DATAX.SingleOrDefault(n => n.MAKH1.ToUpper() == i.MAKH.ToUpper() && n.MACH == i.MACN);
                    if (tv != null)
                    {
                        tv.PSNO = ((i.PSNO != null) ? (double)i.PSNO : 0);
                        tv.PSCO = ((i.PSCO != null) ? (double)i.PSCO : 0);
                        tv.OI_balance = i.NODAUKY;
                        tv.MAKH1 = tv.MAKH1.ToUpper();
                        tv.NGAYDAU = ngaycuoithangtruoc;
                        //tv.NGAYCUOI = DateTime.Now;
                        tv.NGAYCUOI = (thangnay.Month == DateTime.Today.Month) ? DateTime.Today : new DateTime(nam, thang, 1).AddMonths(1).AddDays(-1);
                    }
                    else
                    {
                        DATAX.Add(new DTA_CONGNOHANGNGAY()
                        {
                            NGAYDAU = ngaycuoithangtruoc,
                            NGAYCUOI = (thangnay.Month == DateTime.Today.Month) ? DateTime.Today : new DateTime(nam, thang, 1).AddMonths(1).AddDays(-1),
                            DONVI = i.NOIDUNG,
                            MACH = i.MACN,
                            MATDV = i.matdv,
                            MAKH1 = i.MAKH.ToUpper(),
                            MATINH = i.matinh,
                            QUAHAN_121_360 = 0,
                            QUAHAN_1_30 = 0,
                            QUAHAN_31_60 = 0,
                            QUAHAN_61_120 = 0,
                            QUAHAN_LON_360 = 0,
                            PSNO = ((i.PSNO != null) ? (double)i.PSNO : 0),
                            OI_balance = i.NODAUKY,
                            OI_Balance_Overdue = 0,
                            PHANLOAI = i.PHANLOAI,
                            PSCO = ((i.PSCO != null) ? (double)i.PSCO : 0)
                        });
                    }
                }
                catch (Exception ex)
                {
                    messagle = messagle + ". Bước 3 :" + i + " Lỗi : " + ex;
                }
            }



            //Cuối kỳ
            //DateTime dateck = new DateTime(2023, 08, 31);
            DateTime dateck = DateTime.Today;
            var str2 = "EXEC sp_kyhan_capnhap_DENNGAY_2 '131','" + dateck.ToString("MM/dd/yyyy") + "'";
            foreach (var i in macn)
            {
                try
                {
                    if (queryCN.SingleOrDefault(n => n.macn == i) != null)
                    {
                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320;
                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(str2);
                    }
                    else if (queryCH.SingleOrDefault(n => n.macn == i) != null)
                    {
                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320;
                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(str2);
                    }
                }
                catch (Exception ex)
                {
                    messagle = messagle + ". Bước 4 :" + i + " Lỗi : " + ex;
                }
            }
            var strcn2 = "DECLARE @ngay_etc int, @ngay_otc int, @ngay_etc_cu int, @ngay_otc_cu int SET @ngay_etc = (SELECT ngay FROM KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='ETC') SET @ngay_otc = (SELECT ngay FROM KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='OTC') SET @ngay_etc_cu = (SELECT ngay_cu FROM KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='ETC') SET @ngay_otc_cu = (SELECT ngay_cu FROM KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='OTC') DECLARE @TBL_IN TABLE(MACH VARCHAR(100),TENCH NVARCHAR(500), SCT VARCHAR(100), NGAY SMALLDATETIME, MAKH1 VARCHAR(100), DONVI NVARCHAR(500),MATDV NVARCHAR(500), MATINH NVARCHAR(500), PHANLOAI VARCHAR(20), PHANLOAIKHACHHANG VARCHAR(20), TIEN MONEY, NGAYDENHAN SMALLDATETIME, SONGAY FLOAT ,QUAHAN_SONGAY FLOAT ,D_0_6 FLOAT ,D_7_14 FLOAT ,D_15_30 FLOAT ,D_31_60 FLOAT ,D_61_90 FLOAT ,D_91_120 FLOAT ,D_121_180 FLOAT ,D_OVER_180 FLOAT ,QUAHAN_1_6 FLOAT ,QUAHAN_7_14 FLOAT ,QUAHAN_15_30 FLOAT ,QUAHAN_31_60 FLOAT ,QUAHAN_61_90 FLOAT ,QUAHAN_91_120 FLOAT ,QUAHAN_121_180 FLOAT ,QUAHAN_181_360 FLOAT ,QUAHAN_361_720 FLOAT ,QUAHAN_LON_720 FLOAT ,SONGAY_FORECAST_1 FLOAT ) INSERT INTO @TBL_IN(sct, ngay, makh1, tien) SELECT sct, ngay, makh, tien FROM DTA_KYHANCONGNO_TEMP UPDATE @TBL_IN SET DONVI = (SELECT DONVI FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET MATDV = (SELECT MATDV FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET MATINH = (SELECT MATINH FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAI = (SELECT PHANLOAI FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAIKHACHHANG = (SELECT PHANLOAIKHACHHANG FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAI='OTC' WHERE PHANLOAI NOT IN('OTC', 'ETC') UPDATE @TBL_IN SET TENCH = (SELECT TenCH FROM TBL_DANHMUCCUAHANG) UPDATE @TBL_IN SET MACH = (SELECT MACH FROM TBL_DANHMUCCUAHANG) DECLARE contro_tiennhap CURSOR FOR SELECT DISTINCT PHANLOAI FROM @TBL_IN OPEN contro_tiennhap DECLARE @PHANLOAI varchar(20) FETCH NEXT FROM contro_tiennhap INTO @PHANLOAI WHILE @@FETCH_STATUS=0 BEGIN IF @PHANLOAI='OTC' BEGIN UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngay_otc, ngay) WHERE PHANLOAI=@PHANLOAI AND ngay>'03/31/2023' UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngay_otc_cu, ngay) WHERE PHANLOAI=@PHANLOAI AND ngay<='03/31/2023' END ELSE BEGIN UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngay_etc, ngay) WHERE PHANLOAI=@PHANLOAI AND ngay>'03/31/2023' UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngay_etc_cu, ngay) WHERE PHANLOAI=@PHANLOAI AND ngay<='03/31/2023' END FETCH NEXT FROM contro_tiennhap INTO @PHANLOAI END CLOSE contro_tiennhap DEALLOCATE contro_tiennhap UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, 60, ngay) WHERE MAKH1 in ('50CT90') UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, 90, ngay) WHERE MAKH1 in ('78CT13') UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, 150, ngay) WHERE MAKH1 in ('78CT13_E') UPDATE @TBL_IN SET songay= DATEDIFF(dd, NGAYDENHAN, '" + dateck.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET D_0_6=tien WHERE songay <=0 AND songay>=-6 UPDATE @TBL_IN SET D_7_14=tien WHERE songay<-6 AND songay>=-14 UPDATE @TBL_IN SET D_15_30=tien WHERE songay<-14 AND songay>=-30 UPDATE @TBL_IN SET D_31_60=tien WHERE songay<-30 AND songay>=-60 UPDATE @TBL_IN SET D_61_90=tien WHERE songay<-60 AND songay>=-90 UPDATE @TBL_IN SET D_91_120=tien WHERE songay<-90 AND songay>=-120 UPDATE @TBL_IN SET D_121_180=tien WHERE songay<-120 AND songay>=-180 UPDATE @TBL_IN SET D_OVER_180=tien WHERE songay<-180 UPDATE @TBL_IN SET QUAHAN_songay=DATEDIFF (dd, NGAYDENHAN, '" + dateck.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET QUAHAN_1_6=tien WHERE QUAHAN_songay>0 AND QUAHAN_songay<=6 UPDATE @TBL_IN SET QUAHAN_7_14=tien WHERE QUAHAN_songay>6 AND QUAHAN_songay<=14 UPDATE @TBL_IN SET QUAHAN_15_30=tien WHERE QUAHAN_songay>14 AND QUAHAN_songay<=30 UPDATE @TBL_IN SET QUAHAN_31_60=tien WHERE QUAHAN_songay>30 AND QUAHAN_songay<=60 UPDATE @TBL_IN SET QUAHAN_61_90=tien WHERE QUAHAN_songay>60 AND QUAHAN_songay<=90 UPDATE @TBL_IN SET QUAHAN_91_120=tien WHERE QUAHAN_songay>90 AND QUAHAN_songay<=120 UPDATE @TBL_IN SET QUAHAN_121_180=tien WHERE QUAHAN_songay>120 AND QUAHAN_songay<=180 UPDATE @TBL_IN SET QUAHAN_181_360=tien WHERE QUAHAN_songay>180 AND QUAHAN_songay<=360 UPDATE @TBL_IN SET QUAHAN_361_720=tien WHERE QUAHAN_songay>360 AND QUAHAN_songay<=720 UPDATE @TBL_IN SET QUAHAN_LON_720=tien WHERE QUAHAN_songay>720 SELECT MACH,TENCH, MAKH1, DONVI, MATDV, MATINH, PHANLOAI, PHANLOAIKHACHHANG, SUM(ISNULL(D_0_6, 0)) +SUM(ISNULL(D_7_14, 0)) +SUM(ISNULL(D_15_30, 0)) +SUM(ISNULL(D_31_60, 0)) +SUM(ISNULL(D_61_90, 0)) +SUM(ISNULL(D_91_120, 0)) +SUM(ISNULL(D_121_180, 0)) +SUM(ISNULL(D_OVER_180, 0)) +SUM(ISNULL(QUAHAN_1_6, 0)) +SUM(ISNULL(QUAHAN_7_14, 0)) +SUM(ISNULL(QUAHAN_15_30, 0)) +SUM(ISNULL(QUAHAN_31_60, 0)) +SUM(ISNULL(QUAHAN_61_90, 0)) +SUM(ISNULL(QUAHAN_91_120, 0)) +SUM(ISNULL(QUAHAN_121_180, 0)) +SUM(ISNULL(QUAHAN_181_360, 0)) +SUM(ISNULL(QUAHAN_361_720, 0)) +SUM(ISNULL(QUAHAN_LON_720, 0)) AS OI_balance, SUM(ISNULL(QUAHAN_1_6, 0)) + SUM(ISNULL(QUAHAN_7_14, 0)) +SUM(ISNULL(QUAHAN_15_30, 0)) +SUM(ISNULL(QUAHAN_31_60, 0)) +SUM(ISNULL(QUAHAN_61_90, 0)) +SUM(ISNULL(QUAHAN_91_120, 0)) +SUM(ISNULL(QUAHAN_121_180, 0)) +SUM(ISNULL(QUAHAN_181_360, 0)) +SUM(ISNULL(QUAHAN_361_720, 0)) +SUM(ISNULL(QUAHAN_LON_720, 0)) AS OI_Balance_Overdue, SUM(ISNULL(QUAHAN_1_6, 0)) + SUM(ISNULL(QUAHAN_7_14, 0)) + SUM(ISNULL(QUAHAN_15_30, 0)) AS QUAHAN_1_30, SUM(ISNULL(QUAHAN_31_60, 0)) AS QUAHAN_31_60, SUM(ISNULL(QUAHAN_61_90, 0)) + SUM(ISNULL(QUAHAN_91_120, 0)) AS QUAHAN_61_120, SUM(ISNULL(QUAHAN_121_180, 0)) + SUM(ISNULL(QUAHAN_181_360, 0)) AS QUAHAN_121_360, SUM(ISNULL(QUAHAN_361_720, 0)) + SUM(ISNULL(QUAHAN_LON_720, 0)) AS QUAHAN_LON_360 FROM @TBL_IN GROUP BY MACH,TENCH, MAKH1, DONVI, MATDV, MATINH, PHANLOAI, PHANLOAIKHACHHANG";
            var strch2 = "DECLARE @ngay_etc int, @ngay_otc int, @ngay_etc_cu int, @ngay_otc_cu int SET @ngay_etc = (SELECT ngay FROM KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='ETC') SET @ngay_otc = (SELECT ngay FROM KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='OTC') SET @ngay_etc_cu = (SELECT ngay_cu FROM KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='ETC') SET @ngay_otc_cu = (SELECT ngay_cu FROM KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='OTC') DECLARE @TBL_IN TABLE(MACH VARCHAR(100), TENCH NVARCHAR(500), SCT VARCHAR(100), NGAY SMALLDATETIME, MAKH1 VARCHAR(100), DONVI NVARCHAR(500), MATINH NVARCHAR(500), PHANLOAI VARCHAR(20), PHANLOAIKHACHHANG VARCHAR(20), TIEN MONEY, NGAYDENHAN SMALLDATETIME, SONGAY FLOAT ,QUAHAN_SONGAY FLOAT ,D_0_6 FLOAT ,D_7_14 FLOAT ,D_15_30 FLOAT ,D_31_60 FLOAT ,D_61_90 FLOAT ,D_91_120 FLOAT ,D_121_180 FLOAT ,D_OVER_180 FLOAT ,QUAHAN_1_6 FLOAT ,QUAHAN_7_14 FLOAT ,QUAHAN_15_30 FLOAT ,QUAHAN_31_60 FLOAT ,QUAHAN_61_90 FLOAT ,QUAHAN_91_120 FLOAT ,QUAHAN_121_180 FLOAT ,QUAHAN_181_360 FLOAT ,QUAHAN_361_720 FLOAT ,QUAHAN_LON_720 FLOAT ,SONGAY_FORECAST_1 FLOAT ,SONGAY_FORECAST_2 FLOAT ,FORECAST_TUAN_1 FLOAT ,FORECAST_TUAN_2 FLOAT ,T1 FLOAT ,T2 FLOAT ,T3 FLOAT ,T4 FLOAT ,T5 FLOAT ,T6 FLOAT ,T7 FLOAT ,T8 FLOAT ,T9 FLOAT ,T10 FLOAT ,T11 FLOAT ,T12 FLOAT) INSERT INTO @TBL_IN(sct, ngay, makh1, tien) SELECT sct, ngay, makh, tien FROM DTA_KYHANCONGNO_TEMP UPDATE @TBL_IN SET DONVI = (SELECT DONVI FROM DM_KHACHHANG_PTTT WHERE MAKH=MAKH1) UPDATE @TBL_IN SET MATINH = (SELECT MATINH FROM DM_KHACHHANG_PTTT WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAI = (SELECT PHANLOAI FROM DM_KHACHHANG_PTTT WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAIKHACHHANG = (SELECT PHANLOAIKHACHHANG FROM DM_KHACHHANG_PTTT WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAI='OTC' WHERE PHANLOAI NOT IN('OTC', 'ETC') UPDATE @TBL_IN SET TENCH = (SELECT TenCH FROM TBL_DANHMUCCUAHANG) UPDATE @TBL_IN SET MACH = (SELECT MACH FROM TBL_DANHMUCCUAHANG) DECLARE contro_tiennhap CURSOR FOR SELECT DISTINCT PHANLOAI FROM @TBL_IN OPEN contro_tiennhap DECLARE @PHANLOAI varchar(20) FETCH NEXT FROM contro_tiennhap INTO @PHANLOAI WHILE @@FETCH_STATUS=0 BEGIN IF @PHANLOAI='OTC' BEGIN UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngay_otc, ngay) WHERE PHANLOAI=@PHANLOAI AND ngay>'03/31/2023' UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngay_otc_cu, ngay) WHERE PHANLOAI=@PHANLOAI AND ngay<='03/31/2023' END ELSE BEGIN UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngay_etc, ngay) WHERE PHANLOAI=@PHANLOAI AND ngay>'03/31/2023' UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngay_etc_cu, ngay) WHERE PHANLOAI=@PHANLOAI AND ngay<='03/31/2023' END FETCH NEXT FROM contro_tiennhap INTO @PHANLOAI END CLOSE contro_tiennhap DEALLOCATE contro_tiennhap UPDATE @TBL_IN SET songay= DATEDIFF(dd, NGAYDENHAN, '" + dateck.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET SONGAY_FORECAST_1= DATEDIFF(dd, NGAYDENHAN- 7, '" + dateck.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET SONGAY_FORECAST_2= DATEDIFF(dd, NGAYDENHAN-14, '" + dateck.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET D_0_6=tien WHERE songay <=0 AND songay>=-6 UPDATE @TBL_IN SET D_7_14=tien WHERE songay<-6 AND songay>=-14 UPDATE @TBL_IN SET D_15_30=tien WHERE songay<-14 AND songay>=-30 UPDATE @TBL_IN SET D_31_60=tien WHERE songay<-30 AND songay>=-60 UPDATE @TBL_IN SET D_61_90=tien WHERE songay<-60 AND songay>=-90 UPDATE @TBL_IN SET D_91_120=tien WHERE songay<-90 AND songay>=-120 UPDATE @TBL_IN SET D_121_180=tien WHERE songay<-120 AND songay>=-180 UPDATE @TBL_IN SET D_OVER_180=tien WHERE songay<-180 UPDATE @TBL_IN SET QUAHAN_songay=DATEDIFF (dd, NGAYDENHAN, '" + dateck.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET QUAHAN_1_6=tien WHERE QUAHAN_songay>0 AND QUAHAN_songay<=6 UPDATE @TBL_IN SET QUAHAN_7_14=tien WHERE QUAHAN_songay>6 AND QUAHAN_songay<=14 UPDATE @TBL_IN SET QUAHAN_15_30=tien WHERE QUAHAN_songay>14 AND QUAHAN_songay<=30 UPDATE @TBL_IN SET QUAHAN_31_60=tien WHERE QUAHAN_songay>30 AND QUAHAN_songay<=60 UPDATE @TBL_IN SET QUAHAN_61_90=tien WHERE QUAHAN_songay>60 AND QUAHAN_songay<=90 UPDATE @TBL_IN SET QUAHAN_91_120=tien WHERE QUAHAN_songay>90 AND QUAHAN_songay<=120 UPDATE @TBL_IN SET QUAHAN_121_180=tien WHERE QUAHAN_songay>120 AND QUAHAN_songay<=180 UPDATE @TBL_IN SET QUAHAN_181_360=tien WHERE QUAHAN_songay>180 AND QUAHAN_songay<=360 UPDATE @TBL_IN SET QUAHAN_361_720=tien WHERE QUAHAN_songay>360 AND QUAHAN_songay<=720 UPDATE @TBL_IN SET QUAHAN_LON_720=tien WHERE QUAHAN_songay>720 SELECT MACH, TENCH, MAKH1, DONVI, MATINH, PHANLOAI, PHANLOAIKHACHHANG, SUM(ISNULL(D_0_6, 0)) +SUM(ISNULL(D_7_14, 0)) +SUM(ISNULL(D_15_30, 0)) +SUM(ISNULL(D_31_60, 0)) +SUM(ISNULL(D_61_90, 0)) +SUM(ISNULL(D_91_120, 0)) +SUM(ISNULL(D_121_180, 0)) +SUM(ISNULL(D_OVER_180, 0)) +SUM(ISNULL(QUAHAN_1_6, 0)) +SUM(ISNULL(QUAHAN_7_14, 0)) +SUM(ISNULL(QUAHAN_15_30, 0)) +SUM(ISNULL(QUAHAN_31_60, 0)) +SUM(ISNULL(QUAHAN_61_90, 0)) +SUM(ISNULL(QUAHAN_91_120, 0)) +SUM(ISNULL(QUAHAN_121_180, 0)) +SUM(ISNULL(QUAHAN_181_360, 0)) +SUM(ISNULL(QUAHAN_361_720, 0)) +SUM(ISNULL(QUAHAN_LON_720, 0)) AS OI_balance, SUM(ISNULL(QUAHAN_1_6, 0)) + SUM(ISNULL(QUAHAN_7_14, 0)) +SUM(ISNULL(QUAHAN_15_30, 0)) +SUM(ISNULL(QUAHAN_31_60, 0)) +SUM(ISNULL(QUAHAN_61_90, 0)) +SUM(ISNULL(QUAHAN_91_120, 0)) +SUM(ISNULL(QUAHAN_121_180, 0)) +SUM(ISNULL(QUAHAN_181_360, 0)) +SUM(ISNULL(QUAHAN_361_720, 0)) +SUM(ISNULL(QUAHAN_LON_720, 0)) AS OI_Balance_Overdue, SUM(ISNULL(QUAHAN_1_6, 0)) + SUM(ISNULL(QUAHAN_7_14, 0)) + SUM(ISNULL(QUAHAN_15_30, 0)) AS QUAHAN_1_30, SUM(ISNULL(QUAHAN_31_60, 0)) AS QUAHAN_31_60, SUM(ISNULL(QUAHAN_61_90, 0)) + SUM(ISNULL(QUAHAN_91_120, 0)) AS QUAHAN_61_120, SUM(ISNULL(QUAHAN_121_180, 0)) + SUM(ISNULL(QUAHAN_181_360, 0)) AS QUAHAN_121_360, SUM(ISNULL(QUAHAN_361_720, 0)) + SUM(ISNULL(QUAHAN_LON_720, 0)) AS QUAHAN_LON_360 FROM @TBL_IN GROUP BY MACH, TENCH, MAKH1, DONVI, MATINH, PHANLOAI, PHANLOAIKHACHHANG";
            var DATAX2 = new List<DTA_CONGNOHANGNGAY>();
            foreach (var x in macn)
            {
                try
                {
                    if (x == "PY")
                    {
                        var strcn3 = "DECLARE @TBL_IN TABLE(MACH VARCHAR(100), TENCH NVARCHAR(500), SCT VARCHAR(100), NGAY SMALLDATETIME, MAKH1 VARCHAR(100), DONVI NVARCHAR(500), MATINH NVARCHAR(500), PHANLOAI VARCHAR(20), PHANLOAIKHACHHANG VARCHAR(20), TIEN MONEY, NGAYDENHAN SMALLDATETIME, SONGAY FLOAT ,QUAHAN_SONGAY FLOAT ,D_0_6 FLOAT ,D_7_14 FLOAT ,D_15_30 FLOAT ,D_31_60 FLOAT ,D_61_90 FLOAT ,D_91_120 FLOAT ,D_121_180 FLOAT ,D_OVER_180 FLOAT ,QUAHAN_1_6 FLOAT ,QUAHAN_7_14 FLOAT ,QUAHAN_15_30 FLOAT ,QUAHAN_31_60 FLOAT ,QUAHAN_61_90 FLOAT ,QUAHAN_91_120 FLOAT ,QUAHAN_121_180 FLOAT ,QUAHAN_181_360 FLOAT ,QUAHAN_361_720 FLOAT ,QUAHAN_LON_720 FLOAT ,SONGAY_FORECAST_1 FLOAT ,SONGAY_FORECAST_2 FLOAT ,FORECAST_TUAN_1 FLOAT ,FORECAST_TUAN_2 FLOAT ,T1 FLOAT ,T2 FLOAT ,T3 FLOAT ,T4 FLOAT ,T5 FLOAT ,T6 FLOAT ,T7 FLOAT ,T8 FLOAT ,T9 FLOAT ,T10 FLOAT ,T11 FLOAT ,T12 FLOAT) INSERT INTO @TBL_IN(sct, ngay, makh1, tien) SELECT sct, ngay, makh, tien FROM DTA_KYHANCONGNO_TEMP UPDATE @TBL_IN SET DONVI = (SELECT DONVI FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET MATINH = (SELECT MATINH FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAI = (SELECT PHANLOAI FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAIKHACHHANG = (SELECT PHANLOAIKHACHHANG FROM TBL_DANHMUCKHACHHANG WHERE MAKH=MAKH1) UPDATE @TBL_IN SET PHANLOAI='OTC' WHERE PHANLOAI NOT IN('OTC', 'ETC') UPDATE @TBL_IN SET TENCH = (SELECT TenCH FROM TBL_DANHMUCCUAHANG) UPDATE @TBL_IN SET MACH = (SELECT MACH FROM TBL_DANHMUCCUAHANG) DECLARE @ngayno_10 int DECLARE contro_tiennhap CURSOR FOR SELECT MAKH1 FROM @TBL_IN OPEN contro_tiennhap DECLARE @MAKH_10 varchar(20) FETCH NEXT FROM contro_tiennhap INTO @MAKH_10 WHILE @@FETCH_STATUS=0 BEGIN SET @ngayno_10= (SELECT isnull(ngayno, 0) FROM tbl_danhmuckhachhang WHERE makh=@MAKH_10) UPDATE @TBL_IN SET NGAYDENHAN=DATEADD(DAY, @ngayno_10, ngay) WHERE makh1=@MAKH_10 FETCH NEXT FROM contro_tiennhap INTO @MAKH_10 END CLOSE contro_tiennhap DEALLOCATE contro_tiennhap UPDATE @TBL_IN SET songay= DATEDIFF(dd, NGAYDENHAN, '" + dateck.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET SONGAY_FORECAST_1= DATEDIFF(dd, NGAYDENHAN- 7, '" + dateck.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET SONGAY_FORECAST_2= DATEDIFF(dd, NGAYDENHAN-14, '" + dateck.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET D_0_6=tien WHERE songay <=0 AND songay>=-6 UPDATE @TBL_IN SET D_7_14=tien WHERE songay<-6 AND songay>=-14 UPDATE @TBL_IN SET D_15_30=tien WHERE songay<-14 AND songay>=-30 UPDATE @TBL_IN SET D_31_60=tien WHERE songay<-30 AND songay>=-60 UPDATE @TBL_IN SET D_61_90=tien WHERE songay<-60 AND songay>=-90 UPDATE @TBL_IN SET D_91_120=tien WHERE songay<-90 AND songay>=-120 UPDATE @TBL_IN SET D_121_180=tien WHERE songay<-120 AND songay>=-180 UPDATE @TBL_IN SET D_OVER_180=tien WHERE songay<-180 UPDATE @TBL_IN SET QUAHAN_songay=DATEDIFF (dd, NGAYDENHAN, '" + dateck.ToString("MM/dd/yyyy") + "') UPDATE @TBL_IN SET QUAHAN_1_6=tien WHERE QUAHAN_songay>0 AND QUAHAN_songay<=6 UPDATE @TBL_IN SET QUAHAN_7_14=tien WHERE QUAHAN_songay>6 AND QUAHAN_songay<=14 UPDATE @TBL_IN SET QUAHAN_15_30=tien WHERE QUAHAN_songay>14 AND QUAHAN_songay<=30 UPDATE @TBL_IN SET QUAHAN_31_60=tien WHERE QUAHAN_songay>30 AND QUAHAN_songay<=60 UPDATE @TBL_IN SET QUAHAN_61_90=tien WHERE QUAHAN_songay>60 AND QUAHAN_songay<=90 UPDATE @TBL_IN SET QUAHAN_91_120=tien WHERE QUAHAN_songay>90 AND QUAHAN_songay<=120 UPDATE @TBL_IN SET QUAHAN_121_180=tien WHERE QUAHAN_songay>120 AND QUAHAN_songay<=180 UPDATE @TBL_IN SET QUAHAN_181_360=tien WHERE QUAHAN_songay>180 AND QUAHAN_songay<=360 UPDATE @TBL_IN SET QUAHAN_361_720=tien WHERE QUAHAN_songay>360 AND QUAHAN_songay<=720 UPDATE @TBL_IN SET QUAHAN_LON_720=tien WHERE QUAHAN_songay>720 SELECT MACH,TENCH, MAKH1, DONVI, MATINH, PHANLOAI, PHANLOAIKHACHHANG, SUM(ISNULL(D_0_6, 0)) +SUM(ISNULL(D_7_14, 0)) +SUM(ISNULL(D_15_30, 0)) +SUM(ISNULL(D_31_60, 0)) +SUM(ISNULL(D_61_90, 0)) +SUM(ISNULL(D_91_120, 0)) +SUM(ISNULL(D_121_180, 0)) +SUM(ISNULL(D_OVER_180, 0)) +SUM(ISNULL(QUAHAN_1_6, 0)) +SUM(ISNULL(QUAHAN_7_14, 0)) +SUM(ISNULL(QUAHAN_15_30, 0)) +SUM(ISNULL(QUAHAN_31_60, 0)) +SUM(ISNULL(QUAHAN_61_90, 0)) +SUM(ISNULL(QUAHAN_91_120, 0)) +SUM(ISNULL(QUAHAN_121_180, 0)) +SUM(ISNULL(QUAHAN_181_360, 0)) +SUM(ISNULL(QUAHAN_361_720, 0)) +SUM(ISNULL(QUAHAN_LON_720, 0)) AS OI_balance, SUM(ISNULL(QUAHAN_1_6, 0)) + SUM(ISNULL(QUAHAN_7_14, 0)) +SUM(ISNULL(QUAHAN_15_30, 0)) +SUM(ISNULL(QUAHAN_31_60, 0)) +SUM(ISNULL(QUAHAN_61_90, 0)) +SUM(ISNULL(QUAHAN_91_120, 0)) +SUM(ISNULL(QUAHAN_121_180, 0)) +SUM(ISNULL(QUAHAN_181_360, 0)) +SUM(ISNULL(QUAHAN_361_720, 0)) +SUM(ISNULL(QUAHAN_LON_720, 0)) AS OI_Balance_Overdue, SUM(ISNULL(QUAHAN_1_6, 0)) + SUM(ISNULL(QUAHAN_7_14, 0)) + SUM(ISNULL(QUAHAN_15_30, 0)) AS QUAHAN_1_30, SUM(ISNULL(QUAHAN_31_60, 0)) AS QUAHAN_31_60, SUM(ISNULL(QUAHAN_61_90, 0)) + SUM(ISNULL(QUAHAN_91_120, 0)) AS QUAHAN_61_120, SUM(ISNULL(QUAHAN_121_180, 0)) + SUM(ISNULL(QUAHAN_181_360, 0)) AS QUAHAN_121_360, SUM(ISNULL(QUAHAN_361_720, 0)) + SUM(ISNULL(QUAHAN_LON_720, 0)) AS QUAHAN_LON_360 FROM @TBL_IN GROUP BY MACH,TENCH, MAKH1, DONVI, MATINH, PHANLOAI, PHANLOAIKHACHHANG";
                        DATAX2.AddRange(queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DTA_CONGNOHANGNGAY>(strcn3).ToList());
                    }
                    else if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                    {
                        DATAX2.AddRange(queryCN.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DTA_CONGNOHANGNGAY>(strcn2).ToList());
                    }
                    else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                    {
                        DATAX2.AddRange(queryCH.SingleOrDefault(n => n.macn == x).data.Database.SqlQuery<DTA_CONGNOHANGNGAY>(strch2).ToList());
                    }
                }
                catch (Exception ex)
                {
                    messagle = messagle + ". Bước 5 :" + x + " Lỗi : " + ex;
                }
            }

            foreach (var i in DATAX2)
            {
                try
                {
                    var tv = DATAX.SingleOrDefault(n => n.MAKH1.ToUpper() == i.MAKH1.ToUpper() && n.MACH == i.MACH);
                    if (tv != null)
                    {
                        tv.Balance = i.OI_balance;
                        tv.Balance_Overdue = i.OI_Balance_Overdue;
                    }
                    else
                    {
                        DATAX.Add(new DTA_CONGNOHANGNGAY()
                        {
                            NGAYDAU = ngaycuoithangtruoc,
                            NGAYCUOI = DateTime.Now,
                            DONVI = i.DONVI,
                            MACH = i.MACH,
                            MATDV = i.MATDV,
                            MAKH1 = i.MAKH1.ToUpper(),
                            MATINH = i.MATINH,
                            QUAHAN_121_360 = 0,
                            QUAHAN_1_30 = 0,
                            QUAHAN_31_60 = 0,
                            QUAHAN_61_120 = 0,
                            QUAHAN_LON_360 = 0,
                            PSNO = ((i.PSNO != null) ? (double)i.PSNO : 0),
                            OI_balance = 0,
                            OI_Balance_Overdue = 0,
                            PHANLOAI = i.PHANLOAI,
                            PSCO = ((i.PSCO != null) ? (double)i.PSCO : 0),
                            Balance = i.OI_balance,
                            Balance_Overdue = i.OI_Balance_Overdue
                        });
                    }
                }
                catch (Exception ex)
                {
                    messagle = messagle + ". Bước 6 :" + i + " Lỗi : " + ex;
                }
            }

            PBIDATA.DTA_CONGNOHANGNGAY.AddRange(DATAX);
            PBIDATA.TBL_THOIGIAN_CONGNOHANGNGAY.Add(new TBL_THOIGIAN_CONGNOHANGNGAY() { ngay = DateTime.Now, status = "Thành công", message = messagle });
            PBIDATA.SaveChanges();



        }

        public List<sp_IN_TONGHOP_CONGNO_IN_Result> DATABAOCAO3(List<string> soso, DateTime tungay, DateTime denngay, string phanloai, List<string> phanloaikhachhang, List<string> khuvuc, List<string> trinhduocvien, List<string> quanhuyen)
        {
            string tk = "131";
            string strcn = "";
            strcn = (strcn + " DECLARE @TBL_IN_0 TABLE( ");
            strcn = (strcn + " MAKH VARCHAR(20)   ");
            strcn = (strcn + " ,DAUNAM_NO FLOAT DEFAULT  NULL ,TENKH NVARCHAR(300) ");
            strcn = (strcn + "  ,DAUNAM_CO FLOAT DEFAULT  NULL ");
            strcn = (strcn + "  ,PSNO_0 FLOAT DEFAULT  NULL ");
            strcn = (strcn + "  ,PSCO_0 FLOAT DEFAULT  NULL ");
            strcn = (strcn + "  ,DKNO FLOAT DEFAULT  NULL ");
            strcn = (strcn + "  ,DKCO FLOAT DEFAULT  NULL ");
            strcn = (strcn + " ,PSNO FLOAT DEFAULT  NULL  ");
            strcn = (strcn + "   ,PSCO FLOAT DEFAULT  NULL");
            strcn = (strcn + "  ,CKNO FLOAT DEFAULT  NULL ");
            strcn = (strcn + "   ,CKCO FLOAT DEFAULT  NULL");
            strcn = (strcn + "   ,MAKH1 VARCHAR(20) )");
            strcn = (strcn + "   insert into @TBL_IN_0(makh,daunam_no,daunam_co)");
            strcn = (strcn + "  select dta_daukytaikhoan.matk,isnull(dta_daukytaikhoan.duno,0),isnull(duco,0) ");
            strcn = (strcn + "  FROM dta_daukytaikhoan ,TBL_DANHMUCKHACHHANG ");
            strcn = (strcn + "  WHERE ");
            strcn = ((strcn + "  dta_daukytaikhoan. nam=") + tungay.Year);
            // nam
            strcn = (strcn + "  AND dta_daukytaikhoan.MATK=TBL_DANHMUCKHACHHANG.MAKH ");
            strcn = ((strcn + "  AND TBL_DANHMUCKHACHHANG.TK=\'") + (tk + "\' "));
            strcn = (strcn + "  insert into @TBL_IN_0(makh,psno_0)  ");
            strcn = (strcn + "  select makhn,isnull(sum(tien),0)  ");
            strcn = (strcn + "  FROM dta_dinhkhoan ");
            strcn = ((strcn + "  where  NGAY BETWEEN CAST( \'01/01/\'+CAST(YEAR(\'") + (tungay.ToString("MM/dd/yyyy") + "\') AS VARCHAR) AS SMALLDATETIME)  "));
            strcn = ((strcn + "  and   dbo.funNgaycuoiThang (\'") + (tungay.ToString("MM/dd/yyyy") + "\')"));
            strcn = (strcn + "  and kt=1 and makhn<>\'\'  ");
            strcn = (strcn + "  group by makhn ");
            strcn = (strcn + "  insert into @TBL_IN_0(makh,psco_0) ");
            strcn = (strcn + "  select makhc,isnull(sum(tien),0)  ");
            strcn = (strcn + "  FROM dta_dinhkhoan ");
            strcn = ((strcn + "  where  NGAY BETWEEN CAST( \'01/01/\'+CAST(YEAR(\'") + (tungay.ToString("MM/dd/yyyy") + "\') AS VARCHAR) AS SMALLDATETIME)  "));
            strcn = ((strcn + "  and   dbo.funNgaycuoiThang (\'") + (tungay.ToString("MM/dd/yyyy") + "\')"));
            strcn = (strcn + "  and kt=1 and   makhc<>\'\'  ");
            strcn = (strcn + "   group by makhc ");
            strcn = (strcn + "  insert into @TBL_IN_0(makh,psno) ");
            strcn = (strcn + "  select makhn,isnull(sum(tien),0)  ");
            strcn = (strcn + " FROM dta_dinhkhoan");
            strcn = ((strcn + " where NGAY BETWEEN  \'") + (tungay.ToString("MM/dd/yyyy") + ("\'  AND \'" + (denngay.ToString("MM/dd/yyyy") + "\' "))));
            strcn = (strcn + "  and makhn<>\'\' ");
            strcn = (strcn + "  and kt=1 group by makhn ");
            strcn = (strcn + "  insert into @TBL_IN_0(makh,psco) ");
            strcn = (strcn + "   select makhc,isnull(sum(tien),0) ");
            strcn = (strcn + " FROM dta_dinhkhoan ");
            strcn = ((strcn + " where NGAY BETWEEN  \'") + (tungay.ToString("MM/dd/yyyy") + ("\'  AND \'" + (denngay.ToString("MM/dd/yyyy") + "\' "))));
            strcn = (strcn + "  and makhc<>\'\' ");
            strcn = (strcn + "  and kt=1 group by makhc  ");
            strcn = (strcn + " DECLARE @TBL_IN_CONGNOTH TABLE( ");
            strcn = (strcn + " MAKH VARCHAR(20)   ");
            strcn = (strcn + " ,DAUNAM_NO FLOAT DEFAULT  NULL ,TENKH NVARCHAR(200) ");
            strcn = (strcn + "  ,DAUNAM_CO FLOAT DEFAULT  NULL ");
            strcn = (strcn + "  ,PSNO_0 FLOAT DEFAULT  NULL ");
            strcn = (strcn + "  ,PSCO_0 FLOAT DEFAULT  NULL ");
            strcn = (strcn + "  ,DKNO FLOAT DEFAULT  NULL ");
            strcn = (strcn + "  ,DKCO FLOAT DEFAULT  NULL ");
            strcn = (strcn + " ,PSNO FLOAT DEFAULT  NULL  ");
            strcn = (strcn + "   ,PSCO FLOAT DEFAULT  NULL");
            strcn = (strcn + "  ,CKNO FLOAT DEFAULT  NULL ");
            strcn = (strcn + "   ,CKCO FLOAT DEFAULT  NULL");
            strcn = (strcn + "   ,DONVI NVARCHAR(300)");
            strcn = (strcn + "   ,DIACHI NVARCHAR(300)");
            strcn = (strcn + "  ,PHANLOAI VARCHAR(20)");
            strcn = (strcn + ",PHANLOAIKHACHHANG VARCHAR(20)");
            strcn = (strcn + " ,MATINH1 VARCHAR(20)");
            strcn = (strcn + " ,TENTINH NVARCHAR(100)");
            strcn = (strcn + ",MATDV1 VARCHAR(20) ");
            strcn = (strcn + ",TENTDV NVARCHAR(100) ");
            strcn = (strcn + ",TENDVBC NVARCHAR(200) ");
            strcn = (strcn + ",MACH VARCHAR(20),MIEN NVARCHAR(50)  ) ");
            strcn = (strcn + "   insert into @TBL_IN_CONGNOTH(makh,daunam_no,daunam_co,psno_0,psco_0,dkno,dkco,psno,psco,ckno,ckco)" +
            "");
            strcn = (strcn + "   select makh,sum(isnull(daunam_no,0)),sum(isnull(daunam_co,0)),sum(isnull(psno_0,0))");
            strcn = (strcn + "  ,sum(isnull(psco_0,0)),sum(isnull(dkno,0)),sum(isnull(dkco,0)),sum(isnull(psno,0)),sum(isnull(psco," +
            "0)) ");
            strcn = (strcn + "  ,sum(isnull(ckno,0)),sum(isnull(ckco,0)) ");
            strcn = (strcn + "  from @TBL_IN_0 ");
            strcn = (strcn + "  group by makh ");
            strcn = (strcn + "  update @TBL_IN_CONGNOTH ");
            strcn = (strcn + "   set dkno= daunam_no - daunam_co + psno_0 - psco_0 ");
            strcn = (strcn + "  update @TBL_IN_CONGNOTH ");
            strcn = (strcn + "  set ckno= dkno +  psno - psco  ");
            strcn = (strcn + "  update @TBL_IN_CONGNOTH ");
            strcn = (strcn + "   set dkco=-dkno,dkno=0");
            strcn = (strcn + "  where dkno<0 ");
            strcn = (strcn + "  update @TBL_IN_CONGNOTH ");
            strcn = (strcn + "  set ckco=-ckno,ckno=0 ");
            strcn = (strcn + "  where ckno<0 ");
            strcn = (strcn + " delete @TBL_IN_CONGNOTH");
            strcn = (strcn + "   where (isnull(dkno,0) + isnull(dkco,0) +isnull(psno,0) +isnull(psco,0) +isnull(Ckno,0)  + isnull(C" +
            "kco,0) )=0 ");
            strcn = (strcn + "  SELECT 'ABC' AS MACN, TBL_IN_CONGNOTH.makh ");
            strcn = (strcn + "  ,TBL_IN_CONGNOTH.dkno as nodauky ");
            strcn = (strcn + "  ,TBL_IN_CONGNOTH.dkco  as codauky ");
            strcn = (strcn + "  ,TBL_IN_CONGNOTH.psno as psno ");
            strcn = (strcn + "   ,TBL_IN_CONGNOTH.psco as psco");
            strcn = (strcn + "  ,TBL_IN_CONGNOTH.ckno as nocuoiky ");
            strcn = (strcn + "  ,TBL_IN_CONGNOTH.ckco as cocuoiky ");
            strcn = (strcn + "  ,TBL_DANHMUCKHACHHANG.donvi as noidung ");
            strcn = (strcn + "  ,TBL_DANHMUCTIEUDEBAOCAO.tendvbc , TBL_DANHMUCTIEUDEBAOCAO.tinh , TBL_DANHMUCTIEUDEBAOCAO.chuky1, TBL_DANHMUCTIEUDEBAOCAO.chuky3 , TBL_DANHMUCTIEUDEBAOCAO.chuky2b ");
            strcn = ((strcn + "   ,cast(\'") + (tungay.ToString("MM/dd/yyyy") + "\' as smalldatetime)   AS TUNGAY "));
            strcn = ((strcn + "   ,cast(\'") + (denngay.ToString("MM/dd/yyyy") + "\' as smalldatetime) AS DENNGAY "));
            strcn = ((strcn + "   ,\'") + (tk + "\' as MATK"));
            strcn = ((strcn + "   ,cast(\'") + (DateTime.Now.ToString("MM/dd/yyyy") + "\' as smalldatetime)  AS ngayin "));
            strcn = (strcn + "  , TBL_DANHMUCKHACHHANG.PHANLOAI ");
            strcn = (strcn + "  , TBL_DANHMUCKHACHHANG.matdv ");
            strcn = (strcn + "   , TBL_DANHMUCKHACHHANG.matinh");
            strcn = (strcn + "  FROM @TBL_IN_CONGNOTH TBL_IN_CONGNOTH ,TBL_DANHMUCKHACHHANG,TBL_DANHMUCTIEUDEBAOCAO ");
            strcn = (strcn + "  where TBL_IN_CONGNOTH.makh=TBL_DANHMUCKHACHHANG.makh ");
            strcn = ((strcn + "   and TBL_DANHMUCKHACHHANG.tk=\'") + (tk + "\' "));
            //TT423
            string tt423 = "";
            //NEW
            tt423 = tt423 + " declare @tuthang int,@denthang int,@nam int";
            tt423 = tt423 + " declare @TUNGAY SMALLDATETIME,@DENNGAY SMALLDATETIME";
            tt423 = tt423 + " set @tuthang =" + tungay.Month;
            tt423 = tt423 + " set @denthang=" + denngay.Month;
            tt423 = tt423 + " set @nam=" + denngay.Year;
            tt423 = tt423 + " set @tungay ='" + tungay.ToString("MM/dd/yyyy") + "'";
            tt423 = tt423 + " set @DENNGAY ='" + denngay.ToString("MM/dd/yyyy") + "'";

            tt423 = tt423 + " DECLARE @TBL_IN_0 TABLE(";
            tt423 = tt423 + " MAKH VARCHAR(20)";
            tt423 = tt423 + " ,TENKH NVARCHAR(200)";
            tt423 = tt423 + " ,DAUNAM_NO FLOAT";
            tt423 = tt423 + " ,DAUNAM_CO FLOAT";
            tt423 = tt423 + " ,PSNO_0 FLOAT";
            tt423 = tt423 + " ,PSCO_0 FLOAT";
            tt423 = tt423 + " ,DKNO FLOAT";
            tt423 = tt423 + " ,DKCO FLOAT";
            tt423 = tt423 + " ,PSNO FLOAT";
            tt423 = tt423 + " ,PSCO FLOAT";
            tt423 = tt423 + " ,CKNO FLOAT";
            tt423 = tt423 + " ,CKCO FLOAT";
            tt423 = tt423 + " ,MAKH1 VARCHAR(20) )";

            // DẦU KỲ NƠ
            tt423 = tt423 + " insert into @TBL_IN_0(makh,daunam_no)";
            tt423 = tt423 + " select dta_daukytaikhoan.MAKH,isnull(TIEN,0) ";
            tt423 = tt423 + " FROM congno_dauky_2 dta_daukytaikhoan ,TBL_DANHMUCKHACHHANG ";
            tt423 = tt423 + " WHERE dta_daukytaikhoan. nam=@NAM -1";
            tt423 = tt423 + " AND dta_daukytaikhoan.MAKH=TBL_DANHMUCKHACHHANG.MAKH";
            tt423 = tt423 + " AND TIEN>0";

            tt423 = tt423 + " insert into @TBL_IN_0(makh,daunam_co)";
            tt423 = tt423 + " select dta_daukytaikhoan.MAKH ,ABS(isnull(TIEN,0))";
            tt423 = tt423 + " FROM congno_dauky_2 dta_daukytaikhoan ,TBL_DANHMUCKHACHHANG";
            tt423 = tt423 + " WHERE dta_daukytaikhoan. nam=@NAM -1";
            tt423 = tt423 + " AND dta_daukytaikhoan.MAKH=TBL_DANHMUCKHACHHANG.MAKH";
            tt423 = tt423 + "  AND TIEN <0  ";

            // phát sinh nợ trước kỳ
            tt423 = tt423 + " insert into @TBL_IN_0(makh,psno_0)";
            tt423 = tt423 + " select HOADON.makh,sum(round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0))";
            tt423 = tt423 + " from DTA_CT_HOADON_XUAT CT,DTA_HOADON_XUAT HOADON,TBL_DANHMUCKHACHHANG dm_khachhang";
            tt423 = tt423 + " where  HOADON.NGAYLAPHD BETWEEN CAST( '01/01/'+CAST(YEAR(@TUNGAY) AS VARCHAR) AS SMALLDATETIME) ";
            tt423 = tt423 + " and dbo.funNgaycuoiThang (@tungay)";
            tt423 = tt423 + " AND HOADON.SOHD=CT.SOHD";
            tt423 = tt423 + " AND HOADON.NGAYLAPHD=CT.NGAYLAPHD";
            tt423 = tt423 + " AND HOADON.MACH=CT.MACH";
            tt423 = tt423 + " AND CT.KT=1";
            tt423 = tt423 + " AND HOADON.MAKH=DM_KHACHHANG.MAKH";
            tt423 = tt423 + " AND HOADON.CTGS='BAN_DL'";
            tt423 = tt423 + " AND HOADON.MAPL='BAN'";
            tt423 = tt423 + " GROUP BY  HOADON.makh";

            tt423 = tt423 + " insert into @TBL_IN_0(makh,psno_0)";
            tt423 = tt423 + " select HOADON.makh,sum(round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0) - round((round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0)*ct.tyleck*0.01),0))";
            tt423 = tt423 + " from DTA_CT_HOADON_XUAT CT,DTA_HOADON_XUAT HOADON,TBL_DANHMUCKHACHHANG dm_khachhang";
            tt423 = tt423 + " where  HOADON.NGAYLAPHD BETWEEN CAST( '01/01/'+CAST(YEAR(@TUNGAY) AS VARCHAR) AS SMALLDATETIME) ";
            tt423 = tt423 + " and dbo.funNgaycuoiThang (@tungay)";
            tt423 = tt423 + " AND HOADON.SOHD=CT.SOHD";
            tt423 = tt423 + " AND HOADON.NGAYLAPHD=CT.NGAYLAPHD";
            tt423 = tt423 + " AND HOADON.MACH=CT.MACH";
            tt423 = tt423 + " AND CT.KT=1";
            tt423 = tt423 + " AND HOADON.MAKH=DM_KHACHHANG.MAKH";
            tt423 = tt423 + " AND HOADON.CTGS='BAN_KHAC'";
            tt423 = tt423 + " AND HOADON.MAPL='BAN'";
            tt423 = tt423 + " GROUP BY  HOADON.makh";
            //trả tiền trước kỳ
            tt423 = tt423 + " insert into @TBL_IN_0(makh,psco_0)";
            tt423 = tt423 + " select congno.makh,sum(congno.tien)";
            tt423 = tt423 + " from CONGNO_KHACHHANG_TRATIEN congno,TBL_DANHMUCKHACHHANG dm_khachhang";
            tt423 = tt423 + " where NGAY BETWEEN CAST( '01/01/'+CAST(YEAR(@TUNGAY) AS VARCHAR) AS SMALLDATETIME) ";
            tt423 = tt423 + " and dbo.funNgaycuoiThang (@tungay)";
            tt423 = tt423 + " and congno.makh=dm_khachhang.makh";
            tt423 = tt423 + " AND congno.KT IS NULL ";
            tt423 = tt423 + " group by  congno.makh ";

            // phát sinh nợ trong kỳ
            tt423 = tt423 + " insert into @TBL_IN_0(makh,psno)";
            tt423 = tt423 + " select HOADON.makh,sum(round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0))";
            tt423 = tt423 + " from DTA_CT_HOADON_XUAT CT,DTA_HOADON_XUAT HOADON,TBL_DANHMUCKHACHHANG dm_khachhang";
            tt423 = tt423 + " where  HOADON.NGAYLAPHD   BETWEEN  @TUNGAY AND @DENNGAY";
            tt423 = tt423 + " AND HOADON.SOHD=CT.SOHD";
            tt423 = tt423 + " AND HOADON.NGAYLAPHD=CT.NGAYLAPHD";
            tt423 = tt423 + " AND HOADON.MACH=CT.MACH";
            tt423 = tt423 + " AND CT.KT=1";
            tt423 = tt423 + " AND HOADON.MAKH=DM_KHACHHANG.MAKH";
            tt423 = tt423 + " AND HOADON.CTGS='BAN_DL'";
            tt423 = tt423 + " AND HOADON.MAPL='BAN'";
            tt423 = tt423 + " GROUP BY  HOADON.makh";

            tt423 = tt423 + " insert into @TBL_IN_0(makh,psno)";
            tt423 = tt423 + " select HOADON.makh,sum(round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0) - round((round((cast(ct.dongia_vat as money)* cast(ct.soluong as money)),0)*ct.tyleck*0.01),0))";
            tt423 = tt423 + " from DTA_CT_HOADON_XUAT CT,DTA_HOADON_XUAT HOADON,TBL_DANHMUCKHACHHANG dm_khachhang";
            tt423 = tt423 + " where  HOADON.NGAYLAPHD   BETWEEN  @TUNGAY AND @DENNGAY";
            tt423 = tt423 + " AND HOADON.SOHD=CT.SOHD";
            tt423 = tt423 + " AND HOADON.NGAYLAPHD=CT.NGAYLAPHD";
            tt423 = tt423 + " AND HOADON.MACH=CT.MACH";
            tt423 = tt423 + " AND CT.KT=1";
            tt423 = tt423 + " AND HOADON.MAKH=DM_KHACHHANG.MAKH";
            tt423 = tt423 + " AND HOADON.CTGS='BAN_KHAC'";
            tt423 = tt423 + " AND HOADON.MAPL='BAN'";
            tt423 = tt423 + " GROUP BY  HOADON.makh";

            tt423 = tt423 + " insert into @TBL_IN_0(makh,psno)";
            tt423 = tt423 + " select congno.makh,sum(congno.tien)";
            tt423 = tt423 + " from CONGNO_KHACHHANG_TRATIEN congno,TBL_DANHMUCKHACHHANG dm_khachhang";
            tt423 = tt423 + " where NGAY BETWEEN  @TUNGAY AND @DENNGAY";
            tt423 = tt423 + " and congno.makh=dm_khachhang.makh";
            tt423 = tt423 + " AND congno.KT IS NULL ";
            tt423 = tt423 + " and tien<0";
            tt423 = tt423 + " group by  congno.makh ";

            // trả tiền trong kỳ
            tt423 = tt423 + " insert into @TBL_IN_0(makh,psco)";
            tt423 = tt423 + " select congno.makh,sum(congno.tien)";
            tt423 = tt423 + " from CONGNO_KHACHHANG_TRATIEN congno,TBL_DANHMUCKHACHHANG dm_khachhang";
            tt423 = tt423 + " where NGAY BETWEEN  @TUNGAY AND @DENNGAY";
            tt423 = tt423 + " and congno.makh=dm_khachhang.makh";
            tt423 = tt423 + " AND congno.KT IS NULL ";
            tt423 = tt423 + " and tien > 0";
            tt423 = tt423 + " group by  congno.makh ";

            tt423 = tt423 + " DECLARE @TBL_IN_CONGNOTH TABLE( ";
            tt423 = tt423 + " MAKH VARCHAR(20)";
            tt423 = tt423 + " ,DAUNAM_NO MONEY";
            tt423 = tt423 + " ,TENKH NVARCHAR(200) ";
            tt423 = tt423 + " ,DAUNAM_CO MONEY";
            tt423 = tt423 + " ,PSNO_0 MONEY ";
            tt423 = tt423 + " ,PSCO_0 MONEY ";
            tt423 = tt423 + " ,DKNO MONEY";
            tt423 = tt423 + " ,DKCO MONEY";
            tt423 = tt423 + " ,PSNO MONEY";
            tt423 = tt423 + " ,PSCO MONEY";
            tt423 = tt423 + " ,CKNO MONEY ";
            tt423 = tt423 + " ,CKCO MONEY";
            tt423 = tt423 + " ) ";

            tt423 = tt423 + " insert into @TBL_IN_CONGNOTH(makh,daunam_no,daunam_co,psno_0,psco_0,dkno,dkco,psno,psco,ckno,ckco)";
            tt423 = tt423 + " select makh,sum(ISNULL(daunam_no,0)),sum(ISNULL(daunam_co,0)),sum(ISNULL(psno_0,0))";
            tt423 = tt423 + " ,sum(ISNULL(psco_0,0)),sum(ISNULL(dkno,0)),sum(ISNULL(dkco,0)),sum(ISNULL(psno,0)),sum(ISNULL(psco,0))";
            tt423 = tt423 + " ,sum(ISNULL(ckno,0)),sum(ISNULL(ckco,0))";
            tt423 = tt423 + " from @TBL_IN_0";
            tt423 = tt423 + " group by makh";

            tt423 = tt423 + " update @TBL_IN_CONGNOTH";
            tt423 = tt423 + " set dkno= daunam_no - daunam_co + psno_0 - psco_0 ";

            tt423 = tt423 + " update @TBL_IN_CONGNOTH";
            tt423 = tt423 + " set ckno= dkno +  psno - psco ";

            tt423 = tt423 + " update @TBL_IN_CONGNOTH";
            tt423 = tt423 + " set dkco=-dkno,dkno=0";
            tt423 = tt423 + " where dkno<0";

            tt423 = tt423 + " update @TBL_IN_CONGNOTH";
            tt423 = tt423 + " set ckco=-ckno,ckno=0";
            tt423 = tt423 + " where ckno<0";

            tt423 = tt423 + " delete @TBL_IN_CONGNOTH ";
            tt423 = tt423 + " where (isnull(dkno,0) + isnull(dkco,0) +isnull(psno,0) +isnull(psco,0) +isnull(Ckno,0)  + isnull(Ckco,0) )=0";

            tt423 = tt423 + "  Select 'ABC' AS MACN, TBL_IN_CONGNOTH.makh ";
            tt423 = tt423 + "  ,CAST(TBL_IN_CONGNOTH.dkno AS FLOAT) As nodauky ";
            tt423 = tt423 + "  ,CAST(TBL_IN_CONGNOTH.dkco AS FLOAT)  As codauky ";
            tt423 = tt423 + "  ,CAST(TBL_IN_CONGNOTH.psno AS FLOAT) As psno ";
            tt423 = tt423 + "   ,CAST(TBL_IN_CONGNOTH.psco AS FLOAT) As psco";
            tt423 = tt423 + "  ,CAST(TBL_IN_CONGNOTH.ckno AS FLOAT) As nocuoiky ";
            tt423 = tt423 + "  ,CAST(TBL_IN_CONGNOTH.ckco AS FLOAT) As cocuoiky ";
            tt423 = tt423 + "  ,TBL_DANHMUCKHACHHANG.donvi As noidung ";

            tt423 = tt423 + "  ,TBL_DANHMUCTIEUDEBAOCAO.tendvbc,TBL_DANHMUCTIEUDEBAOCAO.tinh, ";
            tt423 = tt423 + "  '' AS chuky1, ";
            tt423 = tt423 + "  '' AS chuky3,'' AS chuky2b ";
            tt423 = tt423 + "   ,cast('" + tungay.ToString("MM/dd/yyyy") + "' as smalldatetime)   AS TUNGAY ";
            tt423 = tt423 + "   ,cast('" + denngay.ToString("MM/dd/yyyy") + "' as smalldatetime) AS DENNGAY ";
            tt423 = tt423 + "   ,cast('" + DateTime.Now.ToString("MM/dd/yyyy") + "' as smalldatetime)  AS ngayin ";
            tt423 = tt423 + "   ," + denngay.Year + " as nam";
            tt423 = tt423 + "  , TBL_DANHMUCKHACHHANG.PHANLOAI ";
            tt423 = tt423 + "  , TBL_DANHMUCKHACHHANG.matdv ";
            tt423 = tt423 + "   , TBL_DANHMUCKHACHHANG.matinh";
            tt423 = tt423 + "  FROM @TBL_IN_CONGNOTH TBL_IN_CONGNOTH ,TBL_DANHMUCKHACHHANG TBL_DANHMUCKHACHHANG,TBL_DANHMUCTIEUDEBAOCAO";
            tt423 = tt423 + "  where TBL_IN_CONGNOTH.makh=TBL_DANHMUCKHACHHANG.makh ";
            //
            //CUAHANG
            string strch = "";
            strch = strch + " DECLARE @TBL_IN TABLE ( ";
            strch = strch + "   makh1 VARCHAR(20)   ";
            strch = strch + " ,DONVI NVARCHAR(200) ";
            strch = strch + "  ,DK_NO float";
            strch = strch + " ,DK_CO float ";

            strch = strch + "  ,PS_NO float ";
            strch = strch + " ,PS_CO float ";
            strch = strch + " ,CK_NO float ";
            strch = strch + " ,CK_CO float )   ";

            strch = strch + " DECLARE @TABLE TABLE ( ";
            strch = strch + "   makh VARCHAR(20)   ";
            strch = strch + " ,nodauky float ";
            strch = strch + "  ,codauky float";
            strch = strch + ",psno float ";

            strch = strch + " ,psco float ";
            strch = strch + ",nocuoiky float ";
            strch = strch + ",cocuoiky float ";
            strch = strch + "  ,noidung NVARCHAR(200) )   ";
            strch = strch + "    INSERT INTO  @TBL_IN";
            strch = strch + " seleCT congno.makh,'',sum(congno.tien),0,0,0,0,0 ";
            strch = strch + "  from congno_dauky_2 congno   ";
            strch = strch + "  where congno.thang=" + tungay.Month;
            strch = strch + "  and congno.nam=" + tungay.Year;
            strch = strch + " AND TIEN >0 ";
            strch = strch + "  group by congno.makh ";

            strch = strch + "    INSERT INTO  @TBL_IN";
            strch = strch + " seleCT congno.makh,'',0,sum(ABS(congno.tien)),0,0,0,0 ";
            strch = strch + "  from congno_dauky_2 congno   ";
            strch = strch + "  where congno.thang=" + tungay.Month;
            strch = strch + "  and congno.nam=" + tungay.Year;
            strch = strch + " AND TIEN < 0 ";
            strch = strch + "  group by congno.makh ";
            // Phat sinh nợ
            strch = strch + "  insert into  @TBL_IN ";
            strch = strch + "  SELECT HOADON.MAKH,'',0,0,ROUND(sum( ROUND((ROUND(CAST(CT_HOADON.SOLUONG AS MONEY)*CAST(CT_HOADON.DONGIA AS MONEY),0)-ROUND(ROUND(CAST(CT_HOADON.SOLUONG AS MONEY)*CAST(CT_HOADON.DONGIA AS MONEY),0)*TYLECK/100,0)),0))*THUESUAT/100,0)+SUM(ROUND(CAST(CT_HOADON.SOLUONG AS MONEY)*CAST(CT_HOADON.DONGIA AS MONEY),0)-ROUND(ROUND(CAST(CT_HOADON.SOLUONG AS MONEY)*CAST(CT_HOADON.DONGIA AS MONEY),0)*TYLECK/100,0)),0,0,0  ";
            strch = strch + "  FROM HOADON_XUAT HOADON,ct_hoadon_XUAT CT_HOADON  ";
            strch = strch + "  where  HOADON.MAPL='BAN'  AND hoadon.sohd=ct_hoadon.sohd and hoadon.NGAYLAPHD=ct_hoadon.NGAYLAPHD and ct_hoadon.kt=1  ";
            strch = strch + "  and   month(HOADON.NGAYLAPHD) BETWEEN   " + tungay.Month + " and " + denngay.Month + " and year(HOADON.NGAYLAPHD)=" + denngay.Year;
            strch = strch + "  and hoadon.mach=ct_hoadon.mach ";
            strch = strch + "  group by  HOADON.MAKH,HOADON.THUESUAT,hoadon.sohd,hoadon.ngaylaphd ";

            // phat sinh có
            strch = strch + " insert into @TBL_IN ";
            strch = strch + "  select MAKH,'',0,0,0, sum( CN.tien) ,0,0 ";
            strch = strch + " from congno_khachhang_tratien  CN ";
            strch = strch + " where  month(CN.ngaylaphd)  BETWEEN  " + tungay.Month + " and " + denngay.Month + " and year(CN.ngaylaphd)=" + denngay.Year;
            strch = strch + " AND KT IS NULL  GROUP BY MAKH  ";
            strch = strch + "  update @TBL_IN ";
            strch = strch + " set DONVI=(SELECT DONVI FROM DM_KHACHHANG_PTTT WHERE MAKH=MAKH1) ";
            strch = strch + " INSERT INTO @TABLE  ";
            strch = strch + " SELECT MAKH1,SUM(ISNULL(DK_NO,0)),SUM(ISNULL(DK_CO,0)) ";
            strch = strch + " ,SUM(ISNULL(PS_NO,0)),SUM(ISNULL(PS_CO,0))";
            strch = strch + " ,SUM(ISNULL(CK_NO,0)),SUM(ISNULL(CK_CO,0))";
            strch = strch + " ,DONVI";
            strch = strch + " FROM  @TBL_IN";
            strch = strch + " group by  MAKH1,DONVI ";
            strch = strch + " update @TABLE ";
            strch = strch + " set noCUOIKY=   ISNULL( noDAUKY,0) + ISNULL( psno,0) - ISNULL(  psco,0) - ISNULL( CODAUKY,0)";
            strch = strch + " update  @TABLE  ";
            strch = strch + " set  coCUOIKY=- NoCUOIKY,NoCUOIKY=0";
            strch = strch + " where NoCUOIKY<0";
            strch = strch + "  delete @TABLE";
            strch = strch + " where  ABS(nodauky)+ABS(codauky)+ABS( psno)  +ABS(psco)+ABS(nocuoiky) +ABS(cocuoiky) =0";

            // khai báo table mới
            strch = strch + " DECLARE @TBL_IN_CONGNOTH TABLE( ";
            strch = strch + " MAKH VARCHAR(20)   ";
            strch = strch + " ,DAUNAM_NO FLOAT DEFAULT  NULL ,TENKH NVARCHAR(200) ";
            strch = strch + "  ,DAUNAM_CO FLOAT DEFAULT  NULL ";
            strch = strch + "  ,PSNO_0 FLOAT DEFAULT  NULL ";

            strch = strch + "  ,PSCO_0 FLOAT DEFAULT  NULL ";
            strch = strch + "  ,DKNO FLOAT DEFAULT  NULL ";
            strch = strch + "  ,DKCO FLOAT DEFAULT  NULL ";
            strch = strch + " ,PSNO FLOAT DEFAULT  NULL  ";
            strch = strch + "   ,PSCO FLOAT DEFAULT  NULL";
            strch = strch + "  ,CKNO FLOAT DEFAULT  NULL ";
            strch = strch + "   ,CKCO FLOAT DEFAULT  NULL";
            strch = strch + "   ,DONVI NVARCHAR(300)";
            strch = strch + "   ,DIACHI NVARCHAR(300)";
            strch = strch + "  ,PHANLOAI VARCHAR(20)";
            strch = strch + ",PHANLOAIKHACHHANG VARCHAR(20)";
            strch = strch + " ,MATINH1 VARCHAR(20)";
            strch = strch + " ,TENTINH NVARCHAR(100)";
            strch = strch + ",MATDV1 VARCHAR(20) ";
            strch = strch + ",TENTDV NVARCHAR(100) ";
            strch = strch + ",TENDVBC NVARCHAR(200) ";
            strch = strch + ",MACH VARCHAR(20),MIEN NVARCHAR(50)  ) ";

            strch = strch + " INSERT INTO @TBL_IN_CONGNOTH( MAKH,TENKH,CKNO,CKCO,PSNO,PSCO,DKNO,DKCO)";
            strch = strch + " SELECT MAKH,NOIDUNG,nocuoiky,cocuoiky,PSNO,PSCO,NODAUKY,CODAUKY";
            strch = strch + " FROM @TABLE ";
            strch = strch + "  SELECT 'ABC' AS MACN, TBL_IN_CONGNOTH.makh ";
            strch = strch + "  ,TBL_IN_CONGNOTH.dkno as nodauky ";
            strch = strch + "  ,TBL_IN_CONGNOTH.dkco  as codauky ";
            strch = strch + "  ,TBL_IN_CONGNOTH.psno as psno ";
            strch = strch + "   ,TBL_IN_CONGNOTH.psco as psco";
            strch = strch + "  ,TBL_IN_CONGNOTH.ckno as nocuoiky ";
            strch = strch + "  ,TBL_IN_CONGNOTH.ckco as cocuoiky ";
            strch = strch + "  ,TBL_DANHMUCKHACHHANG.donvi as noidung ";
            strch = strch + "  ,TIEUDE.tendvbc,TIEUDE.tinh, ";
            strch = strch + "  '' AS chuky1, ";
            strch = strch + "  '' AS chuky3,'' AS NGANHANG,'' AS chuky2b  ";
            strch = strch + "   ,cast('" + tungay.ToString("MM/dd/yyyy") + "' as smalldatetime)   AS TUNGAY ";
            strch = strch + "   ,cast('" + denngay.ToString("MM/dd/yyyy") + "' as smalldatetime) AS DENNGAY ";

            strch = strch + "   ,cast('" + DateTime.Now.ToString("MM/dd/yyyy") + "' as smalldatetime)  AS ngayin ";

            strch = strch + "  , TBL_DANHMUCKHACHHANG.PHANLOAI ";
            strch = strch + "  , TBL_DANHMUCKHACHHANG.matdv ";
            strch = strch + "   , TBL_DANHMUCKHACHHANG.matinh";
            strch = strch + "  FROM  @TBL_IN_CONGNOTH TBL_IN_CONGNOTH ,dm_khachhang_pttt TBL_DANHMUCKHACHHANG,TIEUDE ";
            strch = strch + "  where TBL_IN_CONGNOTH.makh=TBL_DANHMUCKHACHHANG.makh ";

            //
            if (khuvuc != null)
            {
                strcn = (strcn + (" AND TBL_DANHMUCKHACHHANG.MATINH IN (select val from  fun_CATCHUOI(\'"
                            + (String.Join(",", khuvuc.ToArray()).Trim() + "\'))")));
                tt423 = (tt423 + (" AND TBL_DANHMUCKHACHHANG.MATINH IN (select val from  fun_CATCHUOI(\'"
                            + (String.Join(",", khuvuc.ToArray()).Trim() + "\'))")));
            }

            if (phanloai != "ALL")
            {
                strcn = (strcn + (" AND TBL_DANHMUCKHACHHANG.phanloai IN (select val from  fun_CATCHUOI(\'"
                            + phanloai + "\'))"));
                tt423 = (tt423 + (" AND TBL_DANHMUCKHACHHANG.phanloai IN (select val from  fun_CATCHUOI(\'"
                           + phanloai + "\'))"));
                strch = (strch + (" AND TBL_DANHMUCKHACHHANG.phanloai IN (select val from  fun_CATCHUOI(\'"
                           + phanloai + "\'))"));
            }
            if (trinhduocvien != null)
            {
                strcn = (strcn + (" AND TBL_DANHMUCKHACHHANG.matdv IN (select val from  fun_CATCHUOI(\'"
                            + (String.Join(",", trinhduocvien.ToArray()).Trim() + "\'))")));
                tt423 = (tt423 + (" AND TBL_DANHMUCKHACHHANG.matdv IN (select val from  fun_CATCHUOI(\'"
                         + (String.Join(",", trinhduocvien.ToArray()).Trim() + "\'))")));
                strch = (strch + (" AND TBL_DANHMUCKHACHHANG.matdv IN (select val from  fun_CATCHUOI(\'"
                           + (String.Join(",", trinhduocvien.ToArray()).Trim() + "\'))")));
            }
            if (phanloaikhachhang != null)
            {
                strcn = (strcn + (" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN (select val from  fun_CATCHUOI(\'"
                            + (String.Join(",", phanloaikhachhang.ToArray()).Trim() + "\'))")));
                tt423 = (tt423 + (" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN (select val from  fun_CATCHUOI(\'"
                         + (String.Join(",", phanloaikhachhang.ToArray()).Trim() + "\'))")));
                strch = (strch + (" AND TBL_DANHMUCKHACHHANG.phanloaikhachhang IN (select val from  fun_CATCHUOI(\'"
                          + (String.Join(",", phanloaikhachhang.ToArray()).Trim() + "\'))")));
            }
            if (quanhuyen != null)
            {
                strcn = (strcn + (" AND TBL_DANHMUCKHACHHANG.quanhuyen IN (select val from  fun_CATCHUOI(\'"
                           + (String.Join(",", quanhuyen.ToArray()).Trim() + "\'))")));
                tt423 = (tt423 + (" AND TBL_DANHMUCKHACHHANG.quanhuyen IN (select val from  fun_CATCHUOI(\'"
                          + (String.Join(",", quanhuyen.ToArray()).Trim() + "\'))")));
                strch = (strch + (" AND TBL_DANHMUCKHACHHANG.quanhuyen IN (select val from  fun_CATCHUOI(\'"
                           + (String.Join(",", quanhuyen.ToArray()).Trim() + "\'))")));
            }
            strcn = (strcn + "  order by TBL_IN_CONGNOTH.makh ");
            tt423 = (tt423 + "  order by TBL_IN_CONGNOTH.makh ");
            strch = strch + "  order by TBL_IN_CONGNOTH.makh ";
            //
            var DATAX = new List<sp_IN_TONGHOP_CONGNO_IN_Result>();
            foreach (var x in soso)
            {
                if (queryCN.SingleOrDefault(n => n.macn == x) != null)
                {
                    if (x == "TT423")
                    {
                        DATAX.AddRange(BAOCAOCHINHANH3(queryCN.SingleOrDefault(n => n.macn == x).data, tt423.Replace("ABC", x)));
                    }
                    else
                    {
                        DATAX.AddRange(BAOCAOCHINHANH3(queryCN.SingleOrDefault(n => n.macn == x).data, strcn.Replace("ABC", x)));
                    }
                }
                else if (queryCH.SingleOrDefault(n => n.macn == x) != null)
                {
                    DATAX.AddRange(BAOCAOCUAHANG3(queryCH.SingleOrDefault(n => n.macn == x).data, strch.Replace("ABC", x)));
                }
            }
            return DATAX;
        }
        public List<sp_IN_TONGHOP_CONGNO_IN_Result> BAOCAOCHINHANH3(Entities data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<sp_IN_TONGHOP_CONGNO_IN_Result>(str).ToList();
            return All;
        }
        public List<sp_IN_TONGHOP_CONGNO_IN_Result> BAOCAOCUAHANG3(CHQ10Entities1 data, string str)
        {
            data.Database.CommandTimeout = 320;
            var All = data.Database.SqlQuery<sp_IN_TONGHOP_CONGNO_IN_Result>(str).ToList();
            return All;
        }
    }
    public class ScheduleJob6 : IJob
    {
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
        POWERBIEntities PBIDATA = new POWERBIEntities();
        //KT_THEntities1 DATATH2 = new KT_THEntities1("KT_THEntities2");

        public void Execute(IJobExecutionContext context)
        {
            //var tungay = DateTime.Today.ToString("01/01/yyyy");

            //var soso = "AG".Split(',').ToList();
            var soso = "HN,PT,TB,TNG,HP,PTTT,HCM,CHQ10,CT,AG,CM,DN,LD,TG,TN,VL,BDG,BT,PY,QN,TT423,BD,DNA,GL,HUE,NA,NT,THO,SC".Split(',').ToList();
            var messagle = "";
            //Bước 1
            var chunhat = DateTime.Today;
            var chunhattuantruoc = DateTime.Today.AddDays(-7);
            var str1 = "EXEC sp_kyhan_capnhap_DENNGAY_2 '131','" + chunhat.ToString("MM/dd/yyyy") + "'";
            foreach (var i in soso)
            {
                try
                {
                    if (queryCN.SingleOrDefault(n => n.macn == i) != null)
                    {
                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320;
                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(str1);
                        //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                    else if (queryCH.SingleOrDefault(n => n.macn == i) != null)
                    {
                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320;
                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(str1);
                        //PBIDATA.DTA_TONKHO.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").GroupBy(n => n.mahh).Select(cl => new DTA_TONKHO() { macn = i, mahh = cl.Key, nam = nam, thang = thang, slton = cl.Sum(z => z.slton) }));
                        //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                }
                catch (Exception ex)
                {
                    messagle = messagle + ". Bước 1 :" + i + " Lỗi : " + ex;
                }
            }
            //Bước 2
            var data2 = new List<DTA_KYHANCONGNO_SQL>();
            foreach (var i in soso)
            {

                try
                {
                    if (queryCN.SingleOrDefault(n => n.macn == i) != null)
                    {
                        var str2 = "";
                        if (i == "PY")
                        {
                            str2 = KYHANNO_CHINHANH_2_STADA_NGAYNO("131", chunhat.Month, chunhat.Year, chunhat);
                        }

                        else
                        {
                            str2 = KYHANNO_CHINHANH_2_STADA("131", chunhat.Month, chunhat.Year, chunhat);
                        }

                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320000;
                        data2.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.Database.SqlQuery<DTA_KYHANCONGNO_SQL>(str2).ToList());
                        //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                    else if (queryCH.SingleOrDefault(n => n.macn == i) != null)
                    {
                        var str2 = KYHANNO_CUAHANG_2_STADA("131", chunhat.Month, chunhat.Year, chunhat);
                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320000;
                        data2.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.Database.SqlQuery<DTA_KYHANCONGNO_SQL>(str2).ToList());
                        //PBIDATA.DTA_TONKHO.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").GroupBy(n => n.mahh).Select(cl => new DTA_TONKHO() { macn = i, mahh = cl.Key, nam = nam, thang = thang, slton = cl.Sum(z => z.slton) }));
                        //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                }
                catch (Exception ex)
                {
                    messagle = messagle + ". Bước 2 :" + i + " Lỗi : " + ex;
                }

            }
            if (data2.Count() > 0)
            {
                var str2pbi = " delete DTA_KYHANCONGNO";
                PBIDATA.Database.ExecuteSqlCommand(str2pbi);
                foreach (var row in data2)
                {
                    var str = " insert into DTA_KYHANCONGNO ( ";
                    str = str + "NGAY, ";
                    str = str + "MACH, ";
                    str = str + "MAKH, ";
                    str = str + "DONVI, ";
                    str = str + "MATINH, ";
                    str = str + "PHANLOAI, ";
                    str = str + "PHANLOAIKHACHHANG, ";

                    str = str + "OI_balance, ";
                    str = str + "D_0_6, ";
                    str = str + "D_7_14, ";
                    str = str + "D_15_30, ";
                    str = str + "D_31_60, ";
                    str = str + "D_61_90, ";
                    str = str + "D_91_120, ";
                    str = str + "D_121_180, ";
                    str = str + "D_OVER_180, ";
                    str = str + "OI_Balance_Overdue, ";
                    str = str + "QUAHAN_1_6, ";
                    str = str + "QUAHAN_7_14, ";
                    str = str + "QUAHAN_15_30, ";
                    str = str + "QUAHAN_31_60, ";
                    str = str + "QUAHAN_61_90, ";
                    str = str + "QUAHAN_91_120, ";
                    str = str + "QUAHAN_121_180, ";
                    str = str + "QUAHAN_181_360, ";
                    str = str + "QUAHAN_361_720, ";
                    str = str + "QUAHAN_LON_720,  ";

                    str = str + "FORECAST_TUAN_1,  ";
                    str = str + "FORECAST_TUAN_2, ";
                    str = str + "T1, ";
                    str = str + "T2, ";
                    str = str + "T3, ";
                    str = str + "T4, ";
                    str = str + "T5, ";
                    str = str + "T6, ";
                    str = str + "T7, ";
                    str = str + "T8, ";
                    str = str + "T9, ";
                    str = str + "T10, ";
                    str = str + "T11, ";

                    str = str + "T12 ";

                    str = str + " ) ";

                    // ' row 
                    str = str + " select  ";
                    str = str + "'" + chunhat.ToString("MM/dd/yyyy") + "'" + ", ";
                    str = str + "'" + row.MACH + "'" + ", ";
                    str = str + "'" + row.MAKH1.Replace("'", "") + "'" + ", ";
                    str = str + "N'" + row.DONVI.Replace("'", "") + "'" + ", ";
                    str = str + "'" + row.MATINH.Replace("'", "") + "'" + ", ";
                    str = str + "'" + row.PHANLOAI.Replace("'", "") + "'" + ", ";
                    str = str + "'" + row.PHANLOAIKHACHHANG.Replace("'", "") + "'" + ", ";

                    str = str + row.OI_balance + ", ";
                    str = str + row.D_0_6 + ", ";
                    str = str + row.D_7_14 + ", ";
                    str = str + row.D_15_30 + ", ";
                    str = str + row.D_31_60 + ", ";
                    str = str + row.D_61_90 + ", ";
                    str = str + row.D_91_120 + ", ";
                    str = str + row.D_121_180 + ", ";
                    str = str + row.D_OVER_180 + ", ";
                    str = str + row.OI_Balance_Overdue + ", ";
                    str = str + row.QUAHAN_1_6 + ", ";
                    str = str + row.QUAHAN_7_14 + ", ";
                    str = str + row.QUAHAN_15_30 + ", ";
                    str = str + row.QUAHAN_31_60 + ", ";
                    str = str + row.QUAHAN_61_90 + ", ";
                    str = str + row.QUAHAN_91_120 + ", ";
                    str = str + row.QUAHAN_121_180 + ", ";
                    str = str + row.QUAHAN_181_360 + ", ";
                    str = str + row.QUAHAN_361_720 + ", ";
                    str = str + row.QUAHAN_LON_720 + ", ";

                    str = str + row.FORECAST_TUAN_1 + ", ";
                    str = str + row.FORECAST_TUAN_2 + ", ";
                    str = str + row.T1 + ", ";
                    str = str + row.T2 + ", ";
                    str = str + row.T3 + ", ";
                    str = str + row.T4 + ", ";
                    str = str + row.T5 + ", ";
                    str = str + row.T6 + ", ";
                    str = str + row.T7 + ", ";
                    str = str + row.T8 + ", ";
                    str = str + row.T9 + ", ";
                    str = str + row.T10 + ", ";
                    str = str + row.T11 + ", ";
                    str = str + row.T12;

                    PBIDATA.Database.ExecuteSqlCommand(str);
                }
            }

            ////Bước 3

            // var str31 = "EXEC sp_kyhan_capnhap_DENNGAY_2_1 '131','" + DateTime.Today.AddDays(-8).ToString("MM/dd/yyyy") + "'";
            // var str32 = "EXEC sp_kyhan_capnhap_DENNGAY_2 '131','" + DateTime.Today.AddDays(-1).ToString("MM/dd/yyyy")+ "'";
            // //abc
            // //
            // foreach (var i in soso)
            // {
            //     try
            //     {
            //         if (queryCN.SingleOrDefault(n => n.macn == i) != null)
            //         {

            //             queryCN.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320000;

            //             //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
            //         }
            //         else if (queryCH.SingleOrDefault(n => n.macn == i) != null)
            //         {

            //             queryCH.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320000;
            //             queryCH.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(str31);
            //             queryCH.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(str32);
            //             //PBIDATA.DTA_TONKHO.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").GroupBy(n => n.mahh).Select(cl => new DTA_TONKHO() { macn = i, mahh = cl.Key, nam = nam, thang = thang, slton = cl.Sum(z => z.slton) }));
            //             //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
            //         }
            //     }
            //     catch (Exception ex)
            //     {
            //         messagle = messagle + ". Bước 3 :" + i + " Lỗi : " + ex;
            //     }
            // }
            // Bước 4

            var str4pbi = " delete DTA_KYHANCONGNO_FI WHERE LAN='F'";
            PBIDATA.Database.ExecuteSqlCommand(str4pbi);
            var data4 = new List<DTA_KYHANCONGNO_FI_SQL>();
            var strSQL1 = "EXEC sp_kyhan_inth_theodoi_7_NGAY '131',1,2022,'','02/01/2023','" + chunhat.ToString("MM/dd/yyyy") + "','' ";
            var str31 = "EXEC sp_kyhan_capnhap_DENNGAY_2_1 '131','" + "02/01/2023" + "'";
            var str32 = "EXEC sp_kyhan_capnhap_DENNGAY_2 '131','" + chunhat.ToString("MM/dd/yyyy") + "'";
            foreach (var i in soso)
            {
                try
                {
                    if (queryCN.SingleOrDefault(n => n.macn == i) != null)
                    {

                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320000;
                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(str31);
                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(str32);
                        data4.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.Database.SqlQuery<DTA_KYHANCONGNO_FI_SQL>(strSQL1).ToList());

                        //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                    else if (queryCH.SingleOrDefault(n => n.macn == i) != null)
                    {

                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320000;
                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(str31);
                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(str32);
                        data4.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.Database.SqlQuery<DTA_KYHANCONGNO_FI_SQL>(strSQL1).ToList());

                        //PBIDATA.DTA_TONKHO.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").GroupBy(n => n.mahh).Select(cl => new DTA_TONKHO() { macn = i, mahh = cl.Key, nam = nam, thang = thang, slton = cl.Sum(z => z.slton) }));
                        //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                }
                catch (Exception ex)
                {
                    messagle = messagle + ". Bước 4 :" + i + " Lỗi : " + ex;
                }
            }
            if (data4.Count() > 0)
            {
                foreach (var row in data4)
                {
                    var str = " insert into DTA_KYHANCONGNO_FI (LAN, ";
                    str = str + "tungay, ";
                    str = str + "denngay, ";
                    str = str + "mach, ";
                    str = str + "phanloai, ";
                    str = str + "phanloaikhachhang, ";
                    str = str + "matinh, ";
                    str = str + "makh, ";
                    str = str + "donvi, ";
                    str = str + "tien, ";
                    str = str + "etc_quahan, ";
                    str = str + "thu_tuan_1, ";
                    str = str + "tongthu_quahan, ";
                    str = str + "quahan_ps, ";
                    str = str + "tien_sau, ";
                    str = str + "etc_quahan_sau ";

                    // str = str + "thu_tuan_2,  "
                    // str = str + "quahan_ps_2,  "
                    // str = str + "tien_2   "

                    str = str + " ) ";

                    // ' row 
                    str = str + " select 'F', ";
                    str = str + "'" + "02/01/2023" + "'" + ", ";
                    str = str + "'" + chunhat.ToString("MM/dd/yyyy") + "'" + ", ";
                    str = str + "'" + row.mach + "'" + ", ";
                    str = str + "'" + row.phanloai.Replace("'", "") + "'" + ", ";
                    str = str + "'" + row.phanloaikhachhang.Replace("'", "") + "'" + ", ";
                    str = str + "'" + row.matinh.Replace("'", "") + "'" + ", ";
                    str = str + "'" + row.makh.Replace("'", "") + "'" + ", ";
                    str = str + "N'" + row.donvi.Replace("'", "") + "'" + ", ";
                    str = str + row.tien + ", ";
                    str = str + row.etc_quahan + ", ";
                    str = str + row.thu_tuan_1 + ", ";
                    str = str + row.thu_quahan + ", ";

                    // str = str & row("tongthu_quahan") & ", "
                    str = str + row.quahan_ps + ", ";
                    str = str + row.tien_sau + ", ";
                    str = str + row.etc_quahan_sau; // & ", "

                    // str = str & row("thu_tuan_2") & ", "
                    // str = str & row("quahan_ps_2") & ", "
                    // str = str & row("tien_2")
                    PBIDATA.Database.ExecuteSqlCommand(str);
                }

            }
            var str42pbi = " delete DTA_KYHANCONGNO_FI WHERE LAN='F' and TIEN_DK is not null ";
            PBIDATA.Database.ExecuteSqlCommand(str42pbi);
            var data43 = new List<DTA_KYHANCONGNO_FI_SQL2>();

            var str4pr = "EXEC SP_TONGHOPCONGNO_3 " + 2 + "," + 2 + "," + 2023 + ",'" + "02/01/2023" + "','" + "02/01/2023" + "','131','','" + chunhat.ToString("MM/dd/yyyy") + "',0,'',''";
            //SqlParameter para;

            foreach (var i in soso)
            {
                try
                {
                    if (queryCN.SingleOrDefault(n => n.macn == i) != null)
                    {

                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320000;
                        data43.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.Database.SqlQuery<DTA_KYHANCONGNO_FI_SQL2>(str4pr));

                        //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                    else if (queryCH.SingleOrDefault(n => n.macn == i) != null)
                    {

                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320000;
                        data43.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.Database.SqlQuery<DTA_KYHANCONGNO_FI_SQL2>(str4pr));

                        //PBIDATA.DTA_TONKHO.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").GroupBy(n => n.mahh).Select(cl => new DTA_TONKHO() { macn = i, mahh = cl.Key, nam = nam, thang = thang, slton = cl.Sum(z => z.slton) }));
                        //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                }
                catch (Exception ex)
                {
                    messagle = messagle + ". Bước 4-2 :" + i + " Lỗi : " + ex;
                }
            }
            if (data43.Count() > 0)
            {
                foreach (var row in data43)
                {

                    var str = " insert into DTA_KYHANCONGNO_FI (LAN, ";
                    str = str + "tungay, ";
                    str = str + "denngay, ";
                    str = str + "mach, ";
                    str = str + "phanloai, ";
                    str = str + "phanloaikhachhang, ";
                    str = str + "matinh, ";
                    str = str + "makh, ";
                    str = str + "donvi, ";
                    str = str + "tien_dk  ";

                    str = str + " ) ";

                    // ' row 
                    str = str + " select 'F', ";
                    str = str + "'" + "02/01/2023" + "'" + ", ";
                    str = str + "'" + chunhat.ToString("MM/dd/yyyy") + "'" + ", ";
                    str = str + "'" + row.mach + "'" + ", ";
                    str = str + "'" + row.phanloai.Replace("'", "") + "'" + ", ";
                    str = str + "'" + row.phanloaikhachhang.Replace("'", "") + "'" + ", ";
                    str = str + "'" + row.matinh.Replace("'", "") + "'" + ", ";
                    str = str + "'" + row.makh.Replace("'", "") + "'" + ", ";
                    str = str + "N'" + row.noidung.Replace("'", "") + "'" + ", ";
                    str = str + row.nodauky;
                    PBIDATA.Database.ExecuteSqlCommand(str);
                }

            }
            var str44 = " a_capnhat_dauky_no 'F' ";
            PBIDATA.Database.ExecuteSqlCommand(str44);
            // Bước 5
            var str5pbi = " delete DTA_KYHANCONGNO_FI WHERE LAN='W'";
            PBIDATA.Database.ExecuteSqlCommand(str5pbi);
            var data5 = new List<DTA_KYHANCONGNO_FI_SQL>();
            var strSQL5 = "EXEC sp_kyhan_inth_theodoi_7_NGAY '131',1,2022,'','" + chunhattuantruoc.ToString("MM/dd/yyyy") + "','" + chunhat.ToString("MM/dd/yyyy") + "','' ";
            var str51 = "EXEC sp_kyhan_capnhap_DENNGAY_2_1 '131','" + chunhattuantruoc.ToString("MM/dd/yyyy") + "'";
            var str52 = "EXEC sp_kyhan_capnhap_DENNGAY_2 '131','" + chunhat.ToString("MM/dd/yyyy") + "'";
            foreach (var i in soso)
            {
                try
                {
                    if (queryCN.SingleOrDefault(n => n.macn == i) != null)
                    {

                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320000;
                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(str51);
                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(str52);
                        data5.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.Database.SqlQuery<DTA_KYHANCONGNO_FI_SQL>(strSQL5).ToList());

                        //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                    else if (queryCH.SingleOrDefault(n => n.macn == i) != null)
                    {

                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320000;
                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(str51);
                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.ExecuteSqlCommand(str52);
                        data5.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.Database.SqlQuery<DTA_KYHANCONGNO_FI_SQL>(strSQL5).ToList());

                        //PBIDATA.DTA_TONKHO.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").GroupBy(n => n.mahh).Select(cl => new DTA_TONKHO() { macn = i, mahh = cl.Key, nam = nam, thang = thang, slton = cl.Sum(z => z.slton) }));
                        //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                }
                catch (Exception ex)
                {
                    messagle = messagle + ". Bước 5 :" + i + " Lỗi : " + ex;
                }
            }
            if (data5.Count() > 0)
            {
                foreach (var row in data5)
                {
                    var str = " insert into DTA_KYHANCONGNO_FI (LAN, ";
                    str = str + "tungay, ";
                    str = str + "denngay, ";
                    str = str + "mach, ";
                    str = str + "phanloai, ";
                    str = str + "phanloaikhachhang, ";
                    str = str + "matinh, ";
                    str = str + "makh, ";
                    str = str + "donvi, ";
                    str = str + "tien, ";
                    str = str + "etc_quahan, ";
                    str = str + "thu_tuan_1, ";
                    str = str + "tongthu_quahan, ";
                    str = str + "quahan_ps, ";
                    str = str + "tien_sau, ";
                    str = str + "etc_quahan_sau ";

                    // str = str + "thu_tuan_2,  "
                    // str = str + "quahan_ps_2,  "
                    // str = str + "tien_2   "

                    str = str + " ) ";

                    // ' row 
                    str = str + " select 'W', ";
                    str = str + "'" + chunhattuantruoc.ToString("MM/dd/yyyy") + "'" + ", ";
                    str = str + "'" + chunhat.ToString("MM/dd/yyyy") + "'" + ", ";
                    str = str + "'" + row.mach + "'" + ", ";
                    str = str + "'" + row.phanloai.Replace("'", "") + "'" + ", ";
                    str = str + "'" + row.phanloaikhachhang.Replace("'", "") + "'" + ", ";
                    str = str + "'" + row.matinh.Replace("'", "") + "'" + ", ";
                    str = str + "'" + row.makh.Replace("'", "") + "'" + ", ";
                    str = str + "N'" + row.donvi.Replace("'", "") + "'" + ", ";
                    str = str + row.tien + ", ";
                    str = str + row.etc_quahan + ", ";
                    str = str + row.thu_tuan_1 + ", ";
                    str = str + row.thu_quahan + ", ";

                    // str = str & row("tongthu_quahan") & ", "
                    str = str + row.quahan_ps + ", ";
                    str = str + row.tien_sau + ", ";
                    str = str + row.etc_quahan_sau; // & ", "

                    // str = str & row("thu_tuan_2") & ", "
                    // str = str & row("quahan_ps_2") & ", "
                    // str = str & row("tien_2")
                    PBIDATA.Database.ExecuteSqlCommand(str);
                }

            }
            var str52pbi = " delete DTA_KYHANCONGNO_FI WHERE LAN='W' and TIEN_DK is not null ";
            PBIDATA.Database.ExecuteSqlCommand(str52pbi);
            var data53 = new List<DTA_KYHANCONGNO_FI_SQL2>();

            var str5pr = "EXEC SP_TONGHOPCONGNO_3 " + chunhattuantruoc.Month + "," + chunhattuantruoc.Month + "," + chunhattuantruoc.Year + ",'" + chunhattuantruoc.ToString("MM/dd/yyyy") + "','" + chunhattuantruoc.ToString("MM/dd/yyyy") + "','131','','" + chunhat.ToString("MM/dd/yyyy") + "',0,'',''";
            //SqlParameter para;

            foreach (var i in soso)
            {
                try
                {
                    if (queryCN.SingleOrDefault(n => n.macn == i) != null)
                    {

                        queryCN.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320000;
                        data53.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.Database.SqlQuery<DTA_KYHANCONGNO_FI_SQL2>(str5pr));

                        //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                    else if (queryCH.SingleOrDefault(n => n.macn == i) != null)
                    {

                        queryCH.SingleOrDefault(n => n.macn == i).data.Database.CommandTimeout = 320000;
                        data53.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.Database.SqlQuery<DTA_KYHANCONGNO_FI_SQL2>(str5pr));

                        //PBIDATA.DTA_TONKHO.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").GroupBy(n => n.mahh).Select(cl => new DTA_TONKHO() { macn = i, mahh = cl.Key, nam = nam, thang = thang, slton = cl.Sum(z => z.slton) }));
                        //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCH.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                    }
                }
                catch (Exception ex)
                {
                    messagle = messagle + ". Bước 5-2 :" + i + " Lỗi : " + ex;
                }
            }
            if (data53.Count() > 0)
            {
                foreach (var row in data53)
                {

                    var str = " insert into DTA_KYHANCONGNO_FI (LAN, ";
                    str = str + "tungay, ";
                    str = str + "denngay, ";
                    str = str + "mach, ";
                    str = str + "phanloai, ";
                    str = str + "phanloaikhachhang, ";
                    str = str + "matinh, ";
                    str = str + "makh, ";
                    str = str + "donvi, ";
                    str = str + "tien_dk  ";

                    str = str + " ) ";

                    // ' row 
                    str = str + " select 'W', ";
                    str = str + "'" + chunhattuantruoc.ToString("MM/dd/yyyy") + "'" + ", ";
                    str = str + "'" + chunhat.ToString("MM/dd/yyyy") + "'" + ", ";
                    str = str + "'" + row.mach + "'" + ", ";
                    str = str + "'" + row.phanloai.Replace("'", "") + "'" + ", ";
                    str = str + "'" + row.phanloaikhachhang.Replace("'", "") + "'" + ", ";
                    str = str + "'" + row.matinh.Replace("'", "") + "'" + ", ";
                    str = str + "'" + row.makh.Replace("'", "") + "'" + ", ";
                    str = str + "N'" + row.noidung.Replace("'", "") + "'" + ", ";
                    str = str + row.nodauky;
                    PBIDATA.Database.ExecuteSqlCommand(str);
                }

            }
            var str55 = " a_capnhat_dauky_no 'W' ";
            PBIDATA.Database.ExecuteSqlCommand(str55);
            PBIDATA.TBL_THOIGIAN_KYHANNO.Add(new TBL_THOIGIAN_KYHANNO() { ngay = DateTime.Now, status = "Thành công", message = messagle });
            PBIDATA.SaveChanges();

        }


        public string KYHANNO_CHINHANH_2_STADA_NGAYNO(string tk, int thang, int nam, DateTime ngay)
        {


            string str = "";

            str = str + " DECLARE @TBL_IN TABLE(";
            str = str + " MACH VARCHAR(100)";
            str = str + " ,SCT VARCHAR(100)";
            str = str + " ,NGAY SMALLDATETIME";
            str = str + " ,MAKH1 VARCHAR(100)";
            str = str + " ,DONVI NVARCHAR(500)";
            str = str + " ,MATINH NVARCHAR(500)";
            str = str + " ,PHANLOAI VARCHAR(20)";
            str = str + " ,PHANLOAIKHACHHANG VARCHAR(20)";
            str = str + " ,TIEN MONEY";
            str = str + " ,NGAYDENHAN SMALLDATETIME";
            str = str + " ,SONGAY FLOAT";
            str = str + " ,QUAHAN_SONGAY FLOAT";

            str = str + " ,D_0_6 FLOAT";
            str = str + " ,D_7_14 FLOAT";
            str = str + " ,D_15_30 FLOAT";
            str = str + " ,D_31_60 FLOAT";
            str = str + " ,D_61_90 FLOAT";
            str = str + " ,D_91_120 FLOAT";
            str = str + " ,D_121_180 FLOAT";
            str = str + " ,D_OVER_180 FLOAT";

            str = str + " ,QUAHAN_1_6 FLOAT";

            str = str + " ,QUAHAN_7_14 FLOAT";
            str = str + " ,QUAHAN_15_30 FLOAT";
            str = str + " ,QUAHAN_31_60 FLOAT";
            str = str + " ,QUAHAN_61_90 FLOAT ";
            str = str + ",QUAHAN_91_120 FLOAT   ";
            str = str + ",QUAHAN_121_180 FLOAT  ";
            str = str + ",QUAHAN_181_360 FLOAT   ";
            str = str + ",QUAHAN_361_720 FLOAT  ";
            str = str + ",QUAHAN_LON_720 FLOAT  ";


            str = str + ",SONGAY_FORECAST_1 FLOAT ";
            str = str + ",SONGAY_FORECAST_2 FLOAT ";
            str = str + ",FORECAST_TUAN_1 FLOAT ";
            str = str + ",FORECAST_TUAN_2 FLOAT ";
            str = str + ",T1 FLOAT ";
            str = str + ",T2 FLOAT ";
            str = str + ",T3 FLOAT ";
            str = str + ",T4 FLOAT ";
            str = str + ",T5 FLOAT ";
            str = str + ",T6 FLOAT ";
            str = str + ",T7 FLOAT ";
            str = str + ",T8 FLOAT ";
            str = str + ",T9 FLOAT ";
            str = str + ",T10 FLOAT ";
            str = str + ",T11 FLOAT ";
            str = str + ",T12 FLOAT ";
            str = str + " )";
            str = str + " insert into @TBL_IN(sct,ngay,makh1,tien)";
            str = str + " select sct,ngay,makh,tien";
            str = str + " FROM DTA_KYHANCONGNO_TEMP";
            // str = str + " FROM dta_kyhancongno"
            // str = str + " where thang=" & thang
            // str = str + " and nam=" & nam
            // str = str + " and tk='" & tk & "'"

            str = str + " UPDATE @TBL_IN SET DONVI =( SELECT DONVI FROM TBL_DANHMUCKHACHHANG  WHERE MAKH=MAKH1) ";
            str = str + " UPDATE @TBL_IN SET MATINH =( SELECT MATINH FROM TBL_DANHMUCKHACHHANG  WHERE MAKH=MAKH1) ";
            str = str + " UPDATE @TBL_IN SET PHANLOAI =( SELECT PHANLOAI FROM TBL_DANHMUCKHACHHANG  WHERE MAKH=MAKH1) ";
            str = str + " UPDATE @TBL_IN SET PHANLOAIKHACHHANG =( SELECT PHANLOAIKHACHHANG FROM TBL_DANHMUCKHACHHANG  WHERE MAKH=MAKH1) ";
            str = str + " UPDATE @TBL_IN SET PHANLOAI='OTC' WHERE PHANLOAI NOT IN('OTC','ETC')";
            str = str + " UPDATE @TBL_IN SET MACH =( SELECT MACH FROM TBL_DANHMUCCUAHANG)";

            str = str + " DECLARE @ngayno_10 int ";

            str = str + " DECLARE contro_tiennhap CURSOR";
            str = str + " FOR  SELECT MAKH1 ";
            str = str + " FROM @TBL_IN";
            str = str + " OPEN contro_tiennhap";
            str = str + " DECLARE @MAKH_10  varchar(20) ";
            str = str + " FETCH NEXT FROM contro_tiennhap";
            str = str + " INTO   @MAKH_10";
            str = str + " WHILE @@FETCH_STATUS=0";

            str = str + " BEGIN";

            str = str + " set @ngayno_10= (select isnull(ngayno,0) from tbl_danhmuckhachhang where makh=@MAKH_10) ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET NGAYDENHAN=DATEADD(day,@ngayno_10,ngay)";
            str = str + " WHERE makh1=@MAKH_10";


            str = str + " FETCH NEXT FROM contro_tiennhap";
            str = str + " INTO  @MAKH_10";
            str = str + " END";
            str = str + " CLOSE contro_tiennhap";

            str = str + " DEALLOCATE contro_tiennhap";


            // ' cập nhật số ngày 21.04.2022
            str = str + " update @TBL_IN";
            str = str + " set songay= DATEDIFF(dd, NGAYDENHAN,'" + ngay.ToString("MM/dd/yyyy") + "')";


            str = str + " update @TBL_IN set SONGAY_FORECAST_1= DATEDIFF(dd, NGAYDENHAN- 7,'" + ngay.ToString("MM/dd/yyyy") + "')";
            str = str + " update @TBL_IN  set SONGAY_FORECAST_2= DATEDIFF(dd, NGAYDENHAN-14,'" + ngay.ToString("MM/dd/yyyy") + "')";


            str = str + " update @TBL_IN set D_0_6=tien where songay <=0 and songay>=-6";
            str = str + " update @TBL_IN set D_7_14=tien where songay<-6 and songay>=-14";
            str = str + " update @TBL_IN set D_15_30=tien where songay<-14 and songay>=-30";
            str = str + " update @TBL_IN set D_31_60=tien where songay<-30 and songay>=-60";
            str = str + " update @TBL_IN set D_61_90=tien where songay<-60 and songay>=-90";
            str = str + " update @TBL_IN set D_91_120=tien where songay<-90 and songay>=-120 "; // and PHANLOAI='ETC'"
            str = str + " update @TBL_IN Set D_121_180=tien where songay<-120 And songay>=-180 "; // And PHANLOAI='ETC'"
            str = str + " update @TBL_IN Set D_OVER_180=tien where songay<-180 "; // And PHANLOAI='ETC'"


            // ' str = str + " update @TBL_IN"
            // str = str + " set songay=DATEDIFF ( dd , ngay ,'" & Format(ngay, "MM/dd/yyyy") & "')"
            // str = str + " update @TBL_IN set H_0_30=tien where songay<=30"
            // str = str + " update @TBL_IN set H_31_60=tien where songay>30 and songay<=60"
            // str = str + " update @TBL_IN set H_61_90=tien where songay>60 and songay<=90"
            // str = str + " update @TBL_IN set H_91_120=tien where songay>90 and songay<=120 and PHANLOAI='ETC'"
            // str = str + " update @TBL_IN Set H_121_150=tien where songay>120 And songay<=150 And PHANLOAI='ETC'"
            // str = str + " update @TBL_IN set H_151_180=tien where songay>150 and songay<=180 and PHANLOAI='ETC'"
            // 'str = str + " update @TBL_IN set Balance_Overdue=tien where songay>180  where PHANLOAI='ETC'"

            // ' cập nhật số ngày QUÁ HẠN
            // ' 21.04.2022
            str = str + " update @TBL_IN";
            str = str + " set QUAHAN_songay=DATEDIFF ( dd , NGAYDENHAN ,'" + ngay.ToString("MM/dd/yyyy") + "')";
            str = str + " update @TBL_IN set QUAHAN_1_6=tien where QUAHAN_songay>0 and QUAHAN_songay<=6";
            str = str + " update @TBL_IN set QUAHAN_7_14=tien where QUAHAN_songay>6 and QUAHAN_songay<=14";
            str = str + " update @TBL_IN set QUAHAN_15_30=tien where QUAHAN_songay>14 and QUAHAN_songay<=30";
            str = str + " update @TBL_IN set QUAHAN_31_60=tien where QUAHAN_songay>30 and QUAHAN_songay<=60";
            str = str + " update @TBL_IN set QUAHAN_61_90=tien where QUAHAN_songay>60 and QUAHAN_songay<=90";
            str = str + " update @TBL_IN set QUAHAN_91_120=tien where QUAHAN_songay>90 and QUAHAN_songay<=120";
            str = str + " update @TBL_IN set QUAHAN_121_180=tien where QUAHAN_songay>120 and QUAHAN_songay<=180";
            str = str + " update @TBL_IN set QUAHAN_181_360=tien where QUAHAN_songay>180 and QUAHAN_songay<=360";
            str = str + " update @TBL_IN set QUAHAN_361_720=tien where QUAHAN_songay>360 and QUAHAN_songay<=720";
            str = str + " update @TBL_IN set QUAHAN_LON_720=tien where QUAHAN_songay>720 ";


            // str = str + " update @TBL_IN"
            // str = str + " set QUAHAN_songay=DATEDIFF ( dd , NGAYDENHAN ,'" & Format(ngay, "MM/dd/yyyy") & "')"
            // str = str + " update @TBL_IN set QUAHAN_0_30=tien where QUAHAN_songay>0 and QUAHAN_songay<=30"
            // str = str + " update @TBL_IN set QUAHAN_31_60=tien where QUAHAN_songay>30 and QUAHAN_songay<=60"
            // str = str + " update @TBL_IN set QUAHAN_61_90=tien where QUAHAN_songay>60 and QUAHAN_songay<=90"
            // str = str + " update @TBL_IN set QUAHAN_91_120=tien where QUAHAN_songay>90 and QUAHAN_songay<=120"
            // str = str + " update @TBL_IN set QUAHAN_121_180=tien where QUAHAN_songay>120 and QUAHAN_songay<=180"
            // str = str + " update @TBL_IN set QUAHAN_181_360=tien where QUAHAN_songay>180 and QUAHAN_songay<=360"
            // str = str + " update @TBL_IN set QUAHAN_361_720=tien where QUAHAN_songay>360 and QUAHAN_songay<=720"
            // str = str + " update @TBL_IN set QUAHAN_LON_720=tien where QUAHAN_songay>720 "

            str = str + " update @TBL_IN set FORECAST_TUAN_1=tien where SONGAY_FORECAST_1>0 and SONGAY_FORECAST_1<=6 ";
            str = str + " update @TBL_IN set FORECAST_TUAN_2=tien where SONGAY_FORECAST_2>0 and SONGAY_FORECAST_2<=14 ";
            str = str + " declare @ngay_T1 smalldatetime, @ngay_T2 smalldatetime, @ngay_T3 smalldatetime, @ngay_T4 smalldatetime, @ngay_T5 smalldatetime, @ngay_T6 smalldatetime, @ngay_T7 smalldatetime, @ngay_T8 smalldatetime, @ngay_T9 smalldatetime, @ngay_T10 smalldatetime, @ngay_T11 smalldatetime, @ngay_T12 smalldatetime set @ngay_T1='" + ngay.ToString("MM/dd/yyyy") + "' set @ngay_T2=(SELECT DATEADD(MONTH, 1, @ngay_T1)) set @ngay_T3=(SELECT DATEADD(MONTH, 2,@ngay_T1)) set @ngay_T4=(SELECT DATEADD(MONTH, 3, @ngay_T1)) set @ngay_T5=(SELECT DATEADD(MONTH, 4, @ngay_T1)) set @ngay_T6=(SELECT DATEADD(MONTH, 5, @ngay_T1)) set @ngay_T7=(SELECT DATEADD(MONTH, 6, @ngay_T1)) set @ngay_T8=(SELECT DATEADD(MONTH, 7, @ngay_T1)) set @ngay_T9=(SELECT DATEADD(MONTH, 8, @ngay_T1)) set @ngay_T10=(SELECT DATEADD(MONTH, 9, @ngay_T1)) set @ngay_T11=(SELECT DATEADD(MONTH, 10, @ngay_T1)) set @ngay_T12=(SELECT DATEADD(MONTH, 11, @ngay_T1)) set @ngay_T1 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T1)+1, 0)) set @ngay_T2 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T2)+1, 0)) set @ngay_T3 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T3)+1, 0)) set @ngay_T4 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T4)+1, 0)) set @ngay_T5 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T5)+1, 0)) set @ngay_T6 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T6)+1, 0)) set @ngay_T7 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T7)+1, 0)) set @ngay_T8 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T8)+1, 0)) set @ngay_T9 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T9)+1, 0)) set @ngay_T10 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T10)+1, 0)) set @ngay_T11 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T11)+1, 0)) set @ngay_T12 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T12)+1, 0)) update @TBL_IN set T1=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T1)>0 update @TBL_IN set T2=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T2)>0 update @TBL_IN set T3=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T3)>0 update @TBL_IN set T4=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T4)>0 update @TBL_IN set T5=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T5)>0 update @TBL_IN set T6=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T6)>0 update @TBL_IN set T7=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T7)>0 update @TBL_IN set T8=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T8)>0 update @TBL_IN set T9=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T9)>0 update @TBL_IN set T10=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T10)>0 update @TBL_IN set T11=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T11)>0 update @TBL_IN set T12=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T12)>0 ";
            //str = str + " update @TBL_IN set T1=tien where  songay <=0 and songay>=-30 ";
            //str = str + " update @TBL_IN set T2=tien where  songay<-30 and songay>=-60 ";
            //str = str + " update @TBL_IN set T3=tien where  songay<-60 and songay>=-90 ";
            //str = str + " update @TBL_IN set T4=tien where  songay<-90 and songay>=-120 ";

            //str = str + " update @TBL_IN set T5=tien where  songay<-120 and songay>=-150 ";
            //str = str + " update @TBL_IN set T6=tien where  songay<-150 and songay>=-180";
            //str = str + " update @TBL_IN set T7=tien where songay<-180 and songay>=-210 ";
            //str = str + " update @TBL_IN set T8=tien where songay<-210 and songay>=-240 ";

            //str = str + " update @TBL_IN set T9=tien where songay<-240 and songay>=-270 ";
            //str = str + " update @TBL_IN set T10=tien where songay<-270 and songay>=-330 ";
            //str = str + " update @TBL_IN set T11=tien where  songay<-330 and songay>=-360 ";
            //str = str + " update @TBL_IN set T12=tien where  songay<-360";
            //str = str + " update @TBL_IN set T1=tien where DATEDIFF(dd, NGAYDENHAN- 7,'" + ngay.ToString("MM/dd/yyyy") + "' <"  and SONGAY_FORECAST_2<=14 ";


            str = str + " SELECT MACH,MAKH1,DONVI,MATINH,PHANLOAI,PHANLOAIKHACHHANG";

            str = str + ",SUM(ISNULL(D_0_6,0)) +SUM(ISNULL(D_7_14 ,0)) ";
            str = str + "+SUM(ISNULL(D_15_30 ,0)) ";
            str = str + "+SUM(ISNULL(D_31_60 ,0)) ";
            str = str + "+SUM(ISNULL(D_61_90 ,0)) ";
            str = str + "+SUM(ISNULL(D_91_120,0)) ";
            str = str + "+SUM(ISNULL(D_121_180,0)) ";
            str = str + "+SUM(ISNULL(D_OVER_180,0)) ";

            str = str + "+SUM(ISNULL(QUAHAN_1_6,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_7_14,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_15_30,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_31_60,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_61_90,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_91_120,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_121_180,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_181_360,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_361_720 ,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_LON_720,0)) ";
            str = str + " AS OI_balance";

            str = str + ",SUM(ISNULL(D_0_6 ,0)) AS D_0_6";
            str = str + ",SUM(ISNULL(D_7_14 ,0)) AS D_7_14";
            str = str + ",SUM(ISNULL(D_15_30  ,0)) AS D_15_30 ";
            str = str + ",SUM(ISNULL(D_31_60,0)) AS D_31_60 ";
            str = str + ",SUM(ISNULL(D_61_90,0)) AS D_61_90 ";
            str = str + ",SUM(ISNULL(D_91_120,0)) AS D_91_120 ";
            str = str + ",SUM(ISNULL(D_121_180,0)) AS D_121_180 ";
            str = str + ",SUM(ISNULL(D_OVER_180,0)) AS D_OVER_180";


            str = str + ",SUM(ISNULL(QUAHAN_1_6,0)) + SUM(ISNULL(QUAHAN_7_14,0)) +SUM(ISNULL(QUAHAN_15_30,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_31_60,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_61_90,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_91_120,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_121_180,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_181_360,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_361_720 ,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_LON_720,0)) ";
            str = str + " AS OI_Balance_Overdue ";

            str = str + ",SUM(ISNULL(QUAHAN_1_6,0)) AS QUAHAN_1_6";
            str = str + ",SUM(ISNULL(QUAHAN_7_14,0)) AS QUAHAN_7_14";
            str = str + ",SUM(ISNULL(QUAHAN_15_30,0)) AS QUAHAN_15_30";
            str = str + ",SUM(ISNULL(QUAHAN_31_60,0)) AS QUAHAN_31_60";
            str = str + ",SUM(ISNULL(QUAHAN_61_90,0)) AS QUAHAN_61_90";
            str = str + ",SUM(ISNULL(QUAHAN_91_120,0)) AS QUAHAN_91_120";
            str = str + ",SUM(ISNULL(QUAHAN_121_180,0)) AS QUAHAN_121_180";
            str = str + ",SUM(ISNULL(QUAHAN_181_360,0)) AS QUAHAN_181_360";
            str = str + ",SUM(ISNULL(QUAHAN_361_720 ,0)) AS QUAHAN_361_720";
            str = str + ",SUM(ISNULL(QUAHAN_LON_720,0)) AS QUAHAN_LON_720";


            str = str + ",SUM(ISNULL(FORECAST_TUAN_1 ,0)) FORECAST_TUAN_1";
            str = str + ",SUM(ISNULL(FORECAST_TUAN_2 ,0)) FORECAST_TUAN_2";
            str = str + ",SUM(ISNULL(T1 ,0)) T1";
            str = str + ",SUM(ISNULL(T2 ,0)) T2";
            str = str + ",SUM(ISNULL(T3 ,0)) T3";
            str = str + ",SUM(ISNULL(T4 ,0)) T4";
            str = str + ",SUM(ISNULL(T5 ,0)) T5";
            str = str + ",SUM(ISNULL(T6 ,0)) T6";
            str = str + ",SUM(ISNULL(T7 ,0)) T7";
            str = str + ",SUM(ISNULL(T8 ,0)) T8";
            str = str + ",SUM(ISNULL(T9 ,0)) T9";
            str = str + ",SUM(ISNULL(T10 ,0)) T10";
            str = str + ",SUM(ISNULL(T11 ,0)) T11";
            str = str + ",SUM(ISNULL(T12 ,0)) T12";
            str = str + " FROM @TBL_IN";
            str = str + " GROUP BY  MACH,MAKH1,DONVI,MATINH,PHANLOAI,PHANLOAIKHACHHANG";

            // str = str + " SELECT *,DATEDIFF ( dd , NGAYDENHAN ,'" & Format(ngay, "MM/dd/yyyy") & "') AS SONGAYQUAHAN FROM @TBL_IN"


            return str;


        }
        public string KYHANNO_CHINHANH_2_STADA(string tk, int thang, int nam, DateTime ngay)
        {



            string str = "";

            str = str + " declare @ngay_etc int,";
            str = str + " @ngay_otc int,";
            str = str + " @ngay_etc_cu int,";
            str = str + " @ngay_otc_cu int";

            str = str + " set @ngay_etc =(select ngay from KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='ETC')";
            str = str + " set @ngay_otc =(select ngay from KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='OTC')";

            str = str + " set @ngay_etc_cu =(select ngay_cu from KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='ETC')";
            str = str + " set @ngay_otc_cu =(select ngay_cu from KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='OTC')";


            str = str + " DECLARE @TBL_IN TABLE(";
            str = str + " MACH VARCHAR(100)";
            str = str + " ,SCT VARCHAR(100)";
            str = str + " ,NGAY SMALLDATETIME";
            str = str + " ,MAKH1 VARCHAR(100)";
            str = str + " ,DONVI NVARCHAR(500)";
            str = str + " ,MATINH NVARCHAR(500)";
            str = str + " ,PHANLOAI VARCHAR(20)";
            str = str + " ,PHANLOAIKHACHHANG VARCHAR(20)";
            str = str + " ,TIEN MONEY";
            str = str + " ,NGAYDENHAN SMALLDATETIME";
            str = str + " ,SONGAY FLOAT";
            str = str + " ,QUAHAN_SONGAY FLOAT";

            str = str + " ,D_0_6 FLOAT";
            str = str + " ,D_7_14 FLOAT";
            str = str + " ,D_15_30 FLOAT";
            str = str + " ,D_31_60 FLOAT";
            str = str + " ,D_61_90 FLOAT";
            str = str + " ,D_91_120 FLOAT";
            str = str + " ,D_121_180 FLOAT";
            str = str + " ,D_OVER_180 FLOAT";

            str = str + " ,QUAHAN_1_6 FLOAT";

            str = str + " ,QUAHAN_7_14 FLOAT";
            str = str + " ,QUAHAN_15_30 FLOAT";
            str = str + " ,QUAHAN_31_60 FLOAT";
            str = str + " ,QUAHAN_61_90 FLOAT ";
            str = str + ",QUAHAN_91_120 FLOAT   ";
            str = str + ",QUAHAN_121_180 FLOAT  ";
            str = str + ",QUAHAN_181_360 FLOAT   ";
            str = str + ",QUAHAN_361_720 FLOAT  ";
            str = str + ",QUAHAN_LON_720 FLOAT  ";

            str = str + ",SONGAY_FORECAST_1 FLOAT ";
            str = str + ",SONGAY_FORECAST_2 FLOAT ";
            str = str + ",FORECAST_TUAN_1 FLOAT ";
            str = str + ",FORECAST_TUAN_2 FLOAT ";
            str = str + ",T1 FLOAT ";
            str = str + ",T2 FLOAT ";
            str = str + ",T3 FLOAT ";
            str = str + ",T4 FLOAT ";
            str = str + ",T5 FLOAT ";
            str = str + ",T6 FLOAT ";
            str = str + ",T7 FLOAT ";
            str = str + ",T8 FLOAT ";
            str = str + ",T9 FLOAT ";
            str = str + ",T10 FLOAT ";
            str = str + ",T11 FLOAT ";
            str = str + ",T12 FLOAT ";
            str = str + " )";

            str = str + " insert into @TBL_IN(sct,ngay,makh1,tien)";
            str = str + " select sct,ngay,makh,tien";
            str = str + " FROM DTA_KYHANCONGNO_TEMP";
            // str = str + " FROM dta_kyhancongno"
            // str = str + " where thang=" & thang
            // str = str + " and nam=" & nam
            // str = str + " and tk='" & tk & "'"

            str = str + " UPDATE @TBL_IN SET DONVI =( SELECT DONVI FROM TBL_DANHMUCKHACHHANG  WHERE MAKH=MAKH1) ";
            str = str + " UPDATE @TBL_IN SET MATINH =( SELECT MATINH FROM TBL_DANHMUCKHACHHANG  WHERE MAKH=MAKH1) ";
            str = str + " UPDATE @TBL_IN SET PHANLOAI =( SELECT PHANLOAI FROM TBL_DANHMUCKHACHHANG  WHERE MAKH=MAKH1) ";
            str = str + " UPDATE @TBL_IN SET PHANLOAIKHACHHANG =( SELECT PHANLOAIKHACHHANG FROM TBL_DANHMUCKHACHHANG  WHERE MAKH=MAKH1) ";
            str = str + " UPDATE @TBL_IN SET PHANLOAI='OTC' WHERE PHANLOAI NOT IN('OTC','ETC')";
            str = str + " UPDATE @TBL_IN SET MACH =( SELECT MACH FROM TBL_DANHMUCCUAHANG)";


            str = str + " DECLARE contro_tiennhap CURSOR";
            str = str + " FOR  SELECT  distinct PHANLOAI";
            str = str + " FROM @TBL_IN";
            str = str + " OPEN contro_tiennhap";
            str = str + " DECLARE @PHANLOAI  varchar(20) ";
            str = str + " FETCH NEXT FROM contro_tiennhap";
            str = str + " INTO   @PHANLOAI";
            str = str + " WHILE @@FETCH_STATUS=0";

            str = str + " BEGIN";
            str = str + " if @PHANLOAI='OTC'";
            str = str + " begin";
            str = str + " UPDATE @TBL_IN";
            str = str + " SET NGAYDENHAN=DATEADD(day,@ngay_otc,ngay)"; // DATEADD(day,90,ngay)"
                                                                       // str = str + " SET NGAYDENHAN=DATEADD(month,3,ngay)"
            str = str + " WHERE PHANLOAI=@PHANLOAI and ngay>'03/31/2023'";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET NGAYDENHAN=DATEADD(day,@ngay_otc_cu,ngay)"; // DATEADD(day,90,ngay)"
                                                                          // str = str + " SET NGAYDENHAN=DATEADD(month,3,ngay)"
            str = str + " WHERE PHANLOAI=@PHANLOAI and ngay<='03/31/2023'";

            str = str + " end";
            str = str + " else";
            str = str + " begin";
            str = str + " UPDATE @TBL_IN";
            str = str + " SET NGAYDENHAN=DATEADD(day,@ngay_etc,ngay)"; // DATEADD(day,180,ngay)"
                                                                       // str = str + " SET NGAYDENHAN=DATEADD(month,6,ngay)"
            str = str + " WHERE PHANLOAI=@PHANLOAI  and ngay>'03/31/2023' ";


            str = str + " UPDATE @TBL_IN";
            str = str + " SET NGAYDENHAN=DATEADD(day,@ngay_etc_cu,ngay)"; // DATEADD(day,180,ngay)"
                                                                          // str = str + " SET NGAYDENHAN=DATEADD(month,6,ngay)"
            str = str + " WHERE PHANLOAI=@PHANLOAI  and ngay<='03/31/2023' ";


            str = str + " end";

            str = str + " FETCH NEXT FROM contro_tiennhap";
            str = str + " INTO   @PHANLOAI";
            str = str + " END";
            str = str + " CLOSE contro_tiennhap";

            str = str + " DEALLOCATE contro_tiennhap";


            // ' bổ sung mới
            str = str + " update @TBL_IN";
            str = str + " SET NGAYDENHAN=DATEADD(day,60,ngay) where MAKH1 in ('50CT90')";

            // ' bổ sung mới 30.12.2021
            str = str + " update @TBL_IN";
            str = str + " SET NGAYDENHAN=DATEADD(day,90,ngay) where MAKH1 in ('78CT13')";

            // ' bổ sung mới 30.12.2021
            str = str + " update @TBL_IN";
            str = str + " SET NGAYDENHAN=DATEADD(day,150,ngay) where MAKH1 in ('78CT13_E')";



            // ' cập nhật số ngày 21.04.2022
            str = str + " update @TBL_IN";
            str = str + " set songay= DATEDIFF(dd, NGAYDENHAN,'" + ngay.ToString("MM/dd/yyyy") + "')";

            str = str + " update @TBL_IN set SONGAY_FORECAST_1= DATEDIFF(dd, NGAYDENHAN- 7,'" + ngay.ToString("MM/dd/yyyy") + "')";
            str = str + " update @TBL_IN set SONGAY_FORECAST_2= DATEDIFF(dd, NGAYDENHAN-14,'" + ngay.ToString("MM/dd/yyyy") + "')";


            str = str + " update @TBL_IN set D_0_6=tien where songay <=0 and songay>=-6";
            str = str + " update @TBL_IN set D_7_14=tien where songay<-6 and songay>=-14";
            str = str + " update @TBL_IN set D_15_30=tien where songay<-14 and songay>=-30";
            str = str + " update @TBL_IN set D_31_60=tien where songay<-30 and songay>=-60";
            str = str + " update @TBL_IN set D_61_90=tien where songay<-60 and songay>=-90";
            str = str + " update @TBL_IN set D_91_120=tien where songay<-90 and songay>=-120"; // and PHANLOAI='ETC'"
            str = str + " update @TBL_IN Set D_121_180=tien where songay<-120 And songay>=-180 "; // And PHANLOAI='ETC'"
            str = str + " update @TBL_IN Set D_OVER_180=tien where songay<-180  "; // And PHANLOAI='ETC'"

            // ' str = str + " update @TBL_IN"
            // str = str + " set songay=DATEDIFF ( dd , ngay ,'" & Format(ngay, "MM/dd/yyyy") & "')"
            // str = str + " update @TBL_IN set H_0_30=tien where songay<=30"
            // str = str + " update @TBL_IN set H_31_60=tien where songay>30 and songay<=60"
            // str = str + " update @TBL_IN set H_61_90=tien where songay>60 and songay<=90"
            // str = str + " update @TBL_IN set H_91_120=tien where songay>90 and songay<=120 and PHANLOAI='ETC'"
            // str = str + " update @TBL_IN Set H_121_150=tien where songay>120 And songay<=150 And PHANLOAI='ETC'"
            // str = str + " update @TBL_IN set H_151_180=tien where songay>150 and songay<=180 and PHANLOAI='ETC'"
            // 'str = str + " update @TBL_IN set Balance_Overdue=tien where songay>180  where PHANLOAI='ETC'"

            // ' cập nhật số ngày QUÁ HẠN
            // ' 21.04.2022
            str = str + " update @TBL_IN";
            str = str + " set QUAHAN_songay=DATEDIFF ( dd , NGAYDENHAN ,'" + ngay.ToString("MM/dd/yyyy") + "')";
            str = str + " update @TBL_IN set QUAHAN_1_6=tien where QUAHAN_songay>0 and QUAHAN_songay<=6";
            str = str + " update @TBL_IN set QUAHAN_7_14=tien where QUAHAN_songay>6 and QUAHAN_songay<=14";
            str = str + " update @TBL_IN set QUAHAN_15_30=tien where QUAHAN_songay>14 and QUAHAN_songay<=30";
            str = str + " update @TBL_IN set QUAHAN_31_60=tien where QUAHAN_songay>30 and QUAHAN_songay<=60";
            str = str + " update @TBL_IN set QUAHAN_61_90=tien where QUAHAN_songay>60 and QUAHAN_songay<=90";
            str = str + " update @TBL_IN set QUAHAN_91_120=tien where QUAHAN_songay>90 and QUAHAN_songay<=120";
            str = str + " update @TBL_IN set QUAHAN_121_180=tien where QUAHAN_songay>120 and QUAHAN_songay<=180";
            str = str + " update @TBL_IN set QUAHAN_181_360=tien where QUAHAN_songay>180 and QUAHAN_songay<=360";
            str = str + " update @TBL_IN set QUAHAN_361_720=tien where QUAHAN_songay>360 and QUAHAN_songay<=720";
            str = str + " update @TBL_IN set QUAHAN_LON_720=tien where QUAHAN_songay>720 ";


            // str = str + " update @TBL_IN"
            // str = str + " set QUAHAN_songay=DATEDIFF ( dd , NGAYDENHAN ,'" & Format(ngay, "MM/dd/yyyy") & "')"
            // str = str + " update @TBL_IN set QUAHAN_0_30=tien where QUAHAN_songay>0 and QUAHAN_songay<=30"
            // str = str + " update @TBL_IN set QUAHAN_31_60=tien where QUAHAN_songay>30 and QUAHAN_songay<=60"
            // str = str + " update @TBL_IN set QUAHAN_61_90=tien where QUAHAN_songay>60 and QUAHAN_songay<=90"
            // str = str + " update @TBL_IN set QUAHAN_91_120=tien where QUAHAN_songay>90 and QUAHAN_songay<=120"
            // str = str + " update @TBL_IN set QUAHAN_121_180=tien where QUAHAN_songay>120 and QUAHAN_songay<=180"
            // str = str + " update @TBL_IN set QUAHAN_181_360=tien where QUAHAN_songay>180 and QUAHAN_songay<=360"
            // str = str + " update @TBL_IN set QUAHAN_361_720=tien where QUAHAN_songay>360 and QUAHAN_songay<=720"
            // str = str + " update @TBL_IN set QUAHAN_LON_720=tien where QUAHAN_songay>720 "



            str = str + " update @TBL_IN set FORECAST_TUAN_1=tien where SONGAY_FORECAST_1>0 and SONGAY_FORECAST_1<=6 ";
            str = str + " update @TBL_IN set FORECAST_TUAN_2=tien where SONGAY_FORECAST_2>0 and SONGAY_FORECAST_2<=14 ";
            str = str + " declare @ngay_T1 smalldatetime, @ngay_T2 smalldatetime, @ngay_T3 smalldatetime, @ngay_T4 smalldatetime, @ngay_T5 smalldatetime, @ngay_T6 smalldatetime, @ngay_T7 smalldatetime, @ngay_T8 smalldatetime, @ngay_T9 smalldatetime, @ngay_T10 smalldatetime, @ngay_T11 smalldatetime, @ngay_T12 smalldatetime set @ngay_T1='" +ngay.ToString("MM/dd/yyyy") +"' set @ngay_T2=(SELECT DATEADD(MONTH, 1, @ngay_T1)) set @ngay_T3=(SELECT DATEADD(MONTH, 2,@ngay_T1)) set @ngay_T4=(SELECT DATEADD(MONTH, 3, @ngay_T1)) set @ngay_T5=(SELECT DATEADD(MONTH, 4, @ngay_T1)) set @ngay_T6=(SELECT DATEADD(MONTH, 5, @ngay_T1)) set @ngay_T7=(SELECT DATEADD(MONTH, 6, @ngay_T1)) set @ngay_T8=(SELECT DATEADD(MONTH, 7, @ngay_T1)) set @ngay_T9=(SELECT DATEADD(MONTH, 8, @ngay_T1)) set @ngay_T10=(SELECT DATEADD(MONTH, 9, @ngay_T1)) set @ngay_T11=(SELECT DATEADD(MONTH, 10, @ngay_T1)) set @ngay_T12=(SELECT DATEADD(MONTH, 11, @ngay_T1)) set @ngay_T1 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T1)+1, 0)) set @ngay_T2 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T2)+1, 0)) set @ngay_T3 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T3)+1, 0)) set @ngay_T4 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T4)+1, 0)) set @ngay_T5 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T5)+1, 0)) set @ngay_T6 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T6)+1, 0)) set @ngay_T7 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T7)+1, 0)) set @ngay_T8 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T8)+1, 0)) set @ngay_T9 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T9)+1, 0)) set @ngay_T10 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T10)+1, 0)) set @ngay_T11 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T11)+1, 0)) set @ngay_T12 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T12)+1, 0)) update @TBL_IN set T1=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T1)>0 update @TBL_IN set T2=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T2)>0 update @TBL_IN set T3=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T3)>0 update @TBL_IN set T4=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T4)>0 update @TBL_IN set T5=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T5)>0 update @TBL_IN set T6=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T6)>0 update @TBL_IN set T7=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T7)>0 update @TBL_IN set T8=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T8)>0 update @TBL_IN set T9=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T9)>0 update @TBL_IN set T10=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T10)>0 update @TBL_IN set T11=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T11)>0 update @TBL_IN set T12=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T12)>0 ";
            //str = str + " update @TBL_IN set T1=tien where  songay <=0 and songay>=-30 ";
            //str = str + " update @TBL_IN set T2=tien where  songay<-30 and songay>=-60 ";
            //str = str + " update @TBL_IN set T3=tien where  songay<-60 and songay>=-90 ";
            //str = str + " update @TBL_IN set T4=tien where  songay<-90 and songay>=-120 ";

            //str = str + " update @TBL_IN set T5=tien where  songay<-120 and songay>=-150 ";
            //str = str + " update @TBL_IN set T6=tien where  songay<-150 and songay>=-180";
            //str = str + " update @TBL_IN set T7=tien where songay<-180 and songay>=-210 ";
            //str = str + " update @TBL_IN set T8=tien where songay<-210 and songay>=-240 ";

            //str = str + " update @TBL_IN set T9=tien where songay<-240 and songay>=-270 ";
            //str = str + " update @TBL_IN set T10=tien where songay<-270 and songay>=-330 ";
            //str = str + " update @TBL_IN set T11=tien where  songay<-330 and songay>=-360 ";
            //str = str + " update @TBL_IN set T12=tien where  songay<-360";


            str = str + " SELECT MACH,MAKH1,DONVI,MATINH,PHANLOAI,PHANLOAIKHACHHANG";

            str = str + ",SUM(ISNULL(D_0_6,0)) +SUM(ISNULL(D_7_14 ,0)) ";
            str = str + "+SUM(ISNULL(D_15_30 ,0)) ";
            str = str + "+SUM(ISNULL(D_31_60 ,0)) ";
            str = str + "+SUM(ISNULL(D_61_90 ,0)) ";
            str = str + "+SUM(ISNULL(D_91_120,0)) ";
            str = str + "+SUM(ISNULL(D_121_180,0)) ";
            str = str + "+SUM(ISNULL(D_OVER_180,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_1_6,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_7_14,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_15_30,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_31_60,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_61_90,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_91_120,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_121_180,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_181_360,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_361_720 ,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_LON_720,0)) ";
            str = str + " AS OI_balance";

            str = str + ",SUM(ISNULL(D_0_6 ,0)) AS D_0_6";
            str = str + ",SUM(ISNULL(D_7_14 ,0)) AS D_7_14";
            str = str + ",SUM(ISNULL(D_15_30  ,0)) AS D_15_30 ";
            str = str + ",SUM(ISNULL(D_31_60,0)) AS D_31_60 ";
            str = str + ",SUM(ISNULL(D_61_90,0)) AS D_61_90 ";
            str = str + ",SUM(ISNULL(D_91_120,0)) AS D_91_120 ";
            str = str + ",SUM(ISNULL(D_121_180,0)) AS D_121_180 ";
            str = str + ",SUM(ISNULL(D_OVER_180,0)) AS D_OVER_180";


            str = str + ",SUM(ISNULL(QUAHAN_1_6,0)) + SUM(ISNULL(QUAHAN_7_14,0)) +SUM(ISNULL(QUAHAN_15_30,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_31_60,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_61_90,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_91_120,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_121_180,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_181_360,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_361_720 ,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_LON_720,0)) ";
            str = str + " AS OI_Balance_Overdue ";

            str = str + ",SUM(ISNULL(QUAHAN_1_6,0)) AS QUAHAN_1_6";
            str = str + ",SUM(ISNULL(QUAHAN_7_14,0)) AS QUAHAN_7_14";
            str = str + ",SUM(ISNULL(QUAHAN_15_30,0)) AS QUAHAN_15_30";
            str = str + ",SUM(ISNULL(QUAHAN_31_60,0)) AS QUAHAN_31_60";
            str = str + ",SUM(ISNULL(QUAHAN_61_90,0)) AS QUAHAN_61_90";
            str = str + ",SUM(ISNULL(QUAHAN_91_120,0)) AS QUAHAN_91_120";
            str = str + ",SUM(ISNULL(QUAHAN_121_180,0)) AS QUAHAN_121_180";
            str = str + ",SUM(ISNULL(QUAHAN_181_360,0)) AS QUAHAN_181_360";
            str = str + ",SUM(ISNULL(QUAHAN_361_720 ,0)) AS QUAHAN_361_720";
            str = str + ",SUM(ISNULL(QUAHAN_LON_720,0)) AS QUAHAN_LON_720";


            str = str + ",SUM(ISNULL(FORECAST_TUAN_1 ,0)) FORECAST_TUAN_1";
            str = str + ",SUM(ISNULL(FORECAST_TUAN_2 ,0)) FORECAST_TUAN_2";
            str = str + ",SUM(ISNULL(T1 ,0)) T1";
            str = str + ",SUM(ISNULL(T2 ,0)) T2";
            str = str + ",SUM(ISNULL(T3 ,0)) T3";
            str = str + ",SUM(ISNULL(T4 ,0)) T4";
            str = str + ",SUM(ISNULL(T5 ,0)) T5";
            str = str + ",SUM(ISNULL(T6 ,0)) T6";
            str = str + ",SUM(ISNULL(T7 ,0)) T7";
            str = str + ",SUM(ISNULL(T8 ,0)) T8";
            str = str + ",SUM(ISNULL(T9 ,0)) T9";
            str = str + ",SUM(ISNULL(T10 ,0)) T10";
            str = str + ",SUM(ISNULL(T11 ,0)) T11";
            str = str + ",SUM(ISNULL(T12 ,0)) T12";
            str = str + " FROM @TBL_IN";
            str = str + " GROUP BY  MACH,MAKH1,DONVI,MATINH,PHANLOAI,PHANLOAIKHACHHANG";

            // str = str + " SELECT *,DATEDIFF ( dd , NGAYDENHAN ,'" & Format(ngay, "MM/dd/yyyy") & "') AS SONGAYQUAHAN FROM @TBL_IN"

            return str;


        }


        public string KYHANNO_CUAHANG_2_STADA(string tk, int thang, int nam, DateTime ngay)
        {


            string str = "";

            str = str + " declare @ngay_etc int,";
            str = str + " @ngay_otc int,";
            str = str + " @ngay_etc_cu int,";
            str = str + " @ngay_otc_cu int";


            str = str + " set @ngay_etc =(select ngay from KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='ETC')";
            str = str + " set @ngay_otc =(select ngay from KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='OTC')";

            str = str + " set @ngay_etc_cu =(select ngay_cu from KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='ETC')";
            str = str + " set @ngay_otc_cu =(select ngay_cu from KT_TH.DBO.TBL_DANHMUCNGAY WHERE PHANLOAI='OTC')";


            str = str + " DECLARE @TBL_IN TABLE(";
            str = str + " MACH VARCHAR(100)";
            str = str + " ,SCT VARCHAR(100)";
            str = str + " ,NGAY SMALLDATETIME";
            str = str + " ,MAKH1 VARCHAR(100)";
            str = str + " ,DONVI NVARCHAR(500)";
            str = str + " ,MATINH NVARCHAR(500)";
            str = str + " ,PHANLOAI VARCHAR(20)";
            str = str + " ,PHANLOAIKHACHHANG VARCHAR(20)";
            str = str + " ,TIEN MONEY";
            str = str + " ,NGAYDENHAN SMALLDATETIME";
            str = str + " ,SONGAY FLOAT";
            str = str + " ,QUAHAN_SONGAY FLOAT";

            str = str + " ,D_0_6 FLOAT";
            str = str + " ,D_7_14 FLOAT";
            str = str + " ,D_15_30 FLOAT";
            str = str + " ,D_31_60 FLOAT";
            str = str + " ,D_61_90 FLOAT";
            str = str + " ,D_91_120 FLOAT";
            str = str + " ,D_121_180 FLOAT";
            str = str + " ,D_OVER_180 FLOAT";

            str = str + " ,QUAHAN_1_6 FLOAT";

            str = str + " ,QUAHAN_7_14 FLOAT";
            str = str + " ,QUAHAN_15_30 FLOAT";
            str = str + " ,QUAHAN_31_60 FLOAT";
            str = str + " ,QUAHAN_61_90 FLOAT ";
            str = str + ",QUAHAN_91_120 FLOAT   ";
            str = str + ",QUAHAN_121_180 FLOAT  ";
            str = str + ",QUAHAN_181_360 FLOAT   ";
            str = str + ",QUAHAN_361_720 FLOAT  ";
            str = str + ",QUAHAN_LON_720 FLOAT  ";

            str = str + ",SONGAY_FORECAST_1 FLOAT ";
            str = str + ",SONGAY_FORECAST_2 FLOAT ";
            str = str + ",FORECAST_TUAN_1 FLOAT ";
            str = str + ",FORECAST_TUAN_2 FLOAT ";
            str = str + ",T1 FLOAT ";
            str = str + ",T2 FLOAT ";
            str = str + ",T3 FLOAT ";
            str = str + ",T4 FLOAT ";
            str = str + ",T5 FLOAT ";
            str = str + ",T6 FLOAT ";
            str = str + ",T7 FLOAT ";
            str = str + ",T8 FLOAT ";
            str = str + ",T9 FLOAT ";
            str = str + ",T10 FLOAT ";
            str = str + ",T11 FLOAT ";
            str = str + ",T12 FLOAT ";

            str = str + " )";

            str = str + " insert into @TBL_IN(sct,ngay,makh1,tien)";
            str = str + " select sct,ngay,makh,tien";
            str = str + " FROM DTA_KYHANCONGNO_TEMP";

            // str = str + " FROM dta_kyhancongno"
            // str = str + " where thang=" & thang
            // str = str + " and nam=" & nam
            // str = str + " and tk='" & tk & "'"

            str = str + " UPDATE @TBL_IN SET DONVI =( SELECT DONVI FROM DM_KHACHHANG_PTTT  WHERE MAKH=MAKH1) ";
            str = str + " UPDATE @TBL_IN SET MATINH =( SELECT MATINH FROM DM_KHACHHANG_PTTT  WHERE MAKH=MAKH1) ";
            str = str + " UPDATE @TBL_IN SET PHANLOAI =( SELECT PHANLOAI FROM DM_KHACHHANG_PTTT  WHERE MAKH=MAKH1) ";
            str = str + " UPDATE @TBL_IN SET PHANLOAIKHACHHANG =( SELECT PHANLOAIKHACHHANG FROM DM_KHACHHANG_PTTT  WHERE MAKH=MAKH1) ";
            str = str + " UPDATE @TBL_IN SET PHANLOAI='OTC' WHERE PHANLOAI NOT IN('OTC','ETC')";
            str = str + " UPDATE @TBL_IN SET MACH =( SELECT MACH FROM TBL_DANHMUCCUAHANG)";


            str = str + " DECLARE contro_tiennhap CURSOR";
            str = str + " FOR  SELECT  distinct PHANLOAI";
            str = str + " FROM @TBL_IN";
            str = str + " OPEN contro_tiennhap";
            str = str + " DECLARE @PHANLOAI  varchar(20) ";
            str = str + " FETCH NEXT FROM contro_tiennhap";
            str = str + " INTO   @PHANLOAI";
            str = str + " WHILE @@FETCH_STATUS=0";

            str = str + " BEGIN";
            str = str + " if @PHANLOAI='OTC'";
            str = str + " begin";
            str = str + " UPDATE @TBL_IN";
            str = str + " SET NGAYDENHAN=DATEADD(day,@ngay_otc,ngay)"; // DATEADD(day,90,ngay)"
                                                                       // str = str + " SET NGAYDENHAN=DATEADD(month,3,ngay)"
            str = str + " WHERE PHANLOAI=@PHANLOAI and ngay>'03/31/2023'";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET NGAYDENHAN=DATEADD(day,@ngay_otc_cu,ngay)"; // DATEADD(day,90,ngay)"
                                                                          // str = str + " SET NGAYDENHAN=DATEADD(month,3,ngay)"
            str = str + " WHERE PHANLOAI=@PHANLOAI and ngay<='03/31/2023'";


            str = str + " end";
            str = str + " else";
            str = str + " begin";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET NGAYDENHAN=DATEADD(day,@ngay_etc,ngay)"; // DATEADD(day,180,ngay)"
                                                                       // str = str + " SET NGAYDENHAN=DATEADD(month,6,ngay)"
            str = str + " WHERE PHANLOAI=@PHANLOAI  and ngay>'03/31/2023' ";


            str = str + " UPDATE @TBL_IN";
            str = str + " SET NGAYDENHAN=DATEADD(day,@ngay_etc_cu,ngay)"; // DATEADD(day,180,ngay)"
                                                                          // str = str + " SET NGAYDENHAN=DATEADD(month,6,ngay)"
            str = str + " WHERE PHANLOAI=@PHANLOAI  and ngay<='03/31/2023' ";

            str = str + " end";

            str = str + " FETCH NEXT FROM contro_tiennhap";
            str = str + " INTO   @PHANLOAI";
            str = str + " END";
            str = str + " CLOSE contro_tiennhap";
            str = str + " DEALLOCATE contro_tiennhap";



            // ' cập nhật số ngày 21.04.2022
            str = str + " update @TBL_IN";
            str = str + " set songay= DATEDIFF(dd, NGAYDENHAN,'" + ngay.ToString("MM/dd/yyyy") + "')";

            str = str + " update @TBL_IN set SONGAY_FORECAST_1= DATEDIFF(dd, NGAYDENHAN- 7,'" + ngay.ToString("MM/dd/yyyy") + "')";
            str = str + " update @TBL_IN  set SONGAY_FORECAST_2= DATEDIFF(dd, NGAYDENHAN-14,'" + ngay.ToString("MM/dd/yyyy") + "')";


            str = str + " update @TBL_IN set D_0_6=tien where songay <=0 and songay>=-6";
            str = str + " update @TBL_IN set D_7_14=tien where songay<-6 and songay>=-14";
            str = str + " update @TBL_IN set D_15_30=tien where songay<-14 and songay>=-30";
            str = str + " update @TBL_IN set D_31_60=tien where songay<-30 and songay>=-60";
            str = str + " update @TBL_IN set D_61_90=tien where songay<-60 and songay>=-90";
            str = str + " update @TBL_IN set D_91_120=tien where songay<-90 and songay>=-120"; // and PHANLOAI='ETC'"
            str = str + " update @TBL_IN Set D_121_180=tien where songay<-120 And songay>=-180"; // And PHANLOAI='ETC'"
            str = str + " update @TBL_IN Set D_OVER_180=tien where songay<-180"; // And PHANLOAI='ETC'"

            // ' str = str + " update @TBL_IN"
            // str = str + " set songay=DATEDIFF ( dd , ngay ,'" & Format(ngay, "MM/dd/yyyy") & "')"
            // str = str + " update @TBL_IN set H_0_30=tien where songay<=30"
            // str = str + " update @TBL_IN set H_31_60=tien where songay>30 and songay<=60"
            // str = str + " update @TBL_IN set H_61_90=tien where songay>60 and songay<=90"
            // str = str + " update @TBL_IN set H_91_120=tien where songay>90 and songay<=120 and PHANLOAI='ETC'"
            // str = str + " update @TBL_IN Set H_121_150=tien where songay>120 And songay<=150 And PHANLOAI='ETC'"
            // str = str + " update @TBL_IN set H_151_180=tien where songay>150 and songay<=180 and PHANLOAI='ETC'"
            // 'str = str + " update @TBL_IN set Balance_Overdue=tien where songay>180  where PHANLOAI='ETC'"

            // ' cập nhật số ngày QUÁ HẠN
            // ' 21.04.2022
            str = str + " update @TBL_IN";
            str = str + " set QUAHAN_songay=DATEDIFF ( dd , NGAYDENHAN ,'" + ngay.ToString("MM/dd/yyyy") + "')";
            str = str + " update @TBL_IN set QUAHAN_1_6=tien where QUAHAN_songay>0 and QUAHAN_songay<=6";
            str = str + " update @TBL_IN set QUAHAN_7_14=tien where QUAHAN_songay>6 and QUAHAN_songay<=14";
            str = str + " update @TBL_IN set QUAHAN_15_30=tien where QUAHAN_songay>14 and QUAHAN_songay<=30";
            str = str + " update @TBL_IN set QUAHAN_31_60=tien where QUAHAN_songay>30 and QUAHAN_songay<=60";
            str = str + " update @TBL_IN set QUAHAN_61_90=tien where QUAHAN_songay>60 and QUAHAN_songay<=90";
            str = str + " update @TBL_IN set QUAHAN_91_120=tien where QUAHAN_songay>90 and QUAHAN_songay<=120";
            str = str + " update @TBL_IN set QUAHAN_121_180=tien where QUAHAN_songay>120 and QUAHAN_songay<=180";
            str = str + " update @TBL_IN set QUAHAN_181_360=tien where QUAHAN_songay>180 and QUAHAN_songay<=360";
            str = str + " update @TBL_IN set QUAHAN_361_720=tien where QUAHAN_songay>360 and QUAHAN_songay<=720";
            str = str + " update @TBL_IN set QUAHAN_LON_720=tien where QUAHAN_songay>720 ";


            // str = str + " update @TBL_IN"
            // str = str + " set QUAHAN_songay=DATEDIFF ( dd , NGAYDENHAN ,'" & Format(ngay, "MM/dd/yyyy") & "')"
            // str = str + " update @TBL_IN set QUAHAN_0_30=tien where QUAHAN_songay>0 and QUAHAN_songay<=30"
            // str = str + " update @TBL_IN set QUAHAN_31_60=tien where QUAHAN_songay>30 and QUAHAN_songay<=60"
            // str = str + " update @TBL_IN set QUAHAN_61_90=tien where QUAHAN_songay>60 and QUAHAN_songay<=90"
            // str = str + " update @TBL_IN set QUAHAN_91_120=tien where QUAHAN_songay>90 and QUAHAN_songay<=120"
            // str = str + " update @TBL_IN set QUAHAN_121_180=tien where QUAHAN_songay>120 and QUAHAN_songay<=180"
            // str = str + " update @TBL_IN set QUAHAN_181_360=tien where QUAHAN_songay>180 and QUAHAN_songay<=360"
            // str = str + " update @TBL_IN set QUAHAN_361_720=tien where QUAHAN_songay>360 and QUAHAN_songay<=720"
            // str = str + " update @TBL_IN set QUAHAN_LON_720=tien where QUAHAN_songay>720 "


            str = str + " update @TBL_IN set FORECAST_TUAN_1=tien where SONGAY_FORECAST_1>0 and SONGAY_FORECAST_1<=6 ";
            str = str + " update @TBL_IN set FORECAST_TUAN_2=tien where SONGAY_FORECAST_2>0 and SONGAY_FORECAST_2<=14 ";
            str = str + " declare @ngay_T1 smalldatetime, @ngay_T2 smalldatetime, @ngay_T3 smalldatetime, @ngay_T4 smalldatetime, @ngay_T5 smalldatetime, @ngay_T6 smalldatetime, @ngay_T7 smalldatetime, @ngay_T8 smalldatetime, @ngay_T9 smalldatetime, @ngay_T10 smalldatetime, @ngay_T11 smalldatetime, @ngay_T12 smalldatetime set @ngay_T1='" + ngay.ToString("MM/dd/yyyy") + "' set @ngay_T2=(SELECT DATEADD(MONTH, 1, @ngay_T1)) set @ngay_T3=(SELECT DATEADD(MONTH, 2,@ngay_T1)) set @ngay_T4=(SELECT DATEADD(MONTH, 3, @ngay_T1)) set @ngay_T5=(SELECT DATEADD(MONTH, 4, @ngay_T1)) set @ngay_T6=(SELECT DATEADD(MONTH, 5, @ngay_T1)) set @ngay_T7=(SELECT DATEADD(MONTH, 6, @ngay_T1)) set @ngay_T8=(SELECT DATEADD(MONTH, 7, @ngay_T1)) set @ngay_T9=(SELECT DATEADD(MONTH, 8, @ngay_T1)) set @ngay_T10=(SELECT DATEADD(MONTH, 9, @ngay_T1)) set @ngay_T11=(SELECT DATEADD(MONTH, 10, @ngay_T1)) set @ngay_T12=(SELECT DATEADD(MONTH, 11, @ngay_T1)) set @ngay_T1 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T1)+1, 0)) set @ngay_T2 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T2)+1, 0)) set @ngay_T3 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T3)+1, 0)) set @ngay_T4 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T4)+1, 0)) set @ngay_T5 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T5)+1, 0)) set @ngay_T6 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T6)+1, 0)) set @ngay_T7 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T7)+1, 0)) set @ngay_T8 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T8)+1, 0)) set @ngay_T9 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T9)+1, 0)) set @ngay_T10 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T10)+1, 0)) set @ngay_T11 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T11)+1, 0)) set @ngay_T12 = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@ngay_T12)+1, 0)) update @TBL_IN set T1=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T1)>0 update @TBL_IN set T2=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T2)>0 update @TBL_IN set T3=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T3)>0 update @TBL_IN set T4=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T4)>0 update @TBL_IN set T5=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T5)>0 update @TBL_IN set T6=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T6)>0 update @TBL_IN set T7=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T7)>0 update @TBL_IN set T8=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T8)>0 update @TBL_IN set T9=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T9)>0 update @TBL_IN set T10=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T10)>0 update @TBL_IN set T11=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T11)>0 update @TBL_IN set T12=tien where DATEDIFF ( dd , NGAYDENHAN ,@ngay_T12)>0 ";
            //str = str + " update @TBL_IN set T1=tien where  songay <=0 and songay>=-30 ";
            //str = str + " update @TBL_IN set T2=tien where  songay<-30 and songay>=-60 ";
            //str = str + " update @TBL_IN set T3=tien where  songay<-60 and songay>=-90 ";
            //str = str + " update @TBL_IN set T4=tien where  songay<-90 and songay>=-120 ";

            //str = str + " update @TBL_IN set T5=tien where  songay<-120 and songay>=-150 ";
            //str = str + " update @TBL_IN set T6=tien where  songay<-150 and songay>=-180";
            //str = str + " update @TBL_IN set T7=tien where songay<-180 and songay>=-210 ";
            //str = str + " update @TBL_IN set T8=tien where songay<-210 and songay>=-240 ";

            //str = str + " update @TBL_IN set T9=tien where songay<-240 and songay>=-270 ";
            //str = str + " update @TBL_IN set T10=tien where songay<-270 and songay>=-330 ";
            //str = str + " update @TBL_IN set T11=tien where  songay<-330 and songay>=-360 ";
            //str = str + " update @TBL_IN set T12=tien where  songay<-360";

            str = str + " SELECT MACH,MAKH1,DONVI,MATINH,PHANLOAI,PHANLOAIKHACHHANG";

            str = str + ",SUM(ISNULL(D_0_6,0)) +SUM(ISNULL(D_7_14 ,0)) ";
            str = str + "+SUM(ISNULL(D_15_30 ,0)) ";
            str = str + "+SUM(ISNULL(D_31_60 ,0)) ";
            str = str + "+SUM(ISNULL(D_61_90 ,0)) ";
            str = str + "+SUM(ISNULL(D_91_120,0)) ";
            str = str + "+SUM(ISNULL(D_121_180,0)) ";
            str = str + "+SUM(ISNULL(D_OVER_180,0)) ";

            str = str + "+SUM(ISNULL(QUAHAN_1_6,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_7_14,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_15_30,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_31_60,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_61_90,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_91_120,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_121_180,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_181_360,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_361_720 ,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_LON_720,0)) ";
            str = str + " AS OI_balance";

            str = str + ",SUM(ISNULL(D_0_6 ,0)) AS D_0_6";
            str = str + ",SUM(ISNULL(D_7_14 ,0)) AS D_7_14";
            str = str + ",SUM(ISNULL(D_15_30  ,0)) AS D_15_30 ";
            str = str + ",SUM(ISNULL(D_31_60,0)) AS D_31_60 ";
            str = str + ",SUM(ISNULL(D_61_90,0)) AS D_61_90 ";
            str = str + ",SUM(ISNULL(D_91_120,0)) AS D_91_120 ";
            str = str + ",SUM(ISNULL(D_121_180,0)) AS D_121_180 ";
            str = str + ",SUM(ISNULL(D_OVER_180,0)) AS D_OVER_180";


            str = str + ",SUM(ISNULL(QUAHAN_1_6,0)) + SUM(ISNULL(QUAHAN_7_14,0)) +SUM(ISNULL(QUAHAN_15_30,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_31_60,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_61_90,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_91_120,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_121_180,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_181_360,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_361_720 ,0)) ";
            str = str + "+SUM(ISNULL(QUAHAN_LON_720,0)) ";
            str = str + " AS OI_Balance_Overdue ";

            str = str + ",SUM(ISNULL(QUAHAN_1_6,0)) AS QUAHAN_1_6";
            str = str + ",SUM(ISNULL(QUAHAN_7_14,0)) AS QUAHAN_7_14";
            str = str + ",SUM(ISNULL(QUAHAN_15_30,0)) AS QUAHAN_15_30";
            str = str + ",SUM(ISNULL(QUAHAN_31_60,0)) AS QUAHAN_31_60";
            str = str + ",SUM(ISNULL(QUAHAN_61_90,0)) AS QUAHAN_61_90";
            str = str + ",SUM(ISNULL(QUAHAN_91_120,0)) AS QUAHAN_91_120";
            str = str + ",SUM(ISNULL(QUAHAN_121_180,0)) AS QUAHAN_121_180";
            str = str + ",SUM(ISNULL(QUAHAN_181_360,0)) AS QUAHAN_181_360";
            str = str + ",SUM(ISNULL(QUAHAN_361_720 ,0)) AS QUAHAN_361_720";
            str = str + ",SUM(ISNULL(QUAHAN_LON_720,0)) AS QUAHAN_LON_720";


            str = str + ",SUM(ISNULL(FORECAST_TUAN_1 ,0)) FORECAST_TUAN_1";
            str = str + ",SUM(ISNULL(FORECAST_TUAN_2 ,0)) FORECAST_TUAN_2";
            str = str + ",SUM(ISNULL(T1 ,0)) T1";
            str = str + ",SUM(ISNULL(T2 ,0)) T2";
            str = str + ",SUM(ISNULL(T3 ,0)) T3";
            str = str + ",SUM(ISNULL(T4 ,0)) T4";
            str = str + ",SUM(ISNULL(T5 ,0)) T5";
            str = str + ",SUM(ISNULL(T6 ,0)) T6";
            str = str + ",SUM(ISNULL(T7 ,0)) T7";
            str = str + ",SUM(ISNULL(T8 ,0)) T8";
            str = str + ",SUM(ISNULL(T9 ,0)) T9";
            str = str + ",SUM(ISNULL(T10 ,0)) T10";
            str = str + ",SUM(ISNULL(T11 ,0)) T11";
            str = str + ",SUM(ISNULL(T12 ,0)) T12";
            str = str + " FROM @TBL_IN";
            str = str + " GROUP BY  MACH,MAKH1,DONVI,MATINH,PHANLOAI,PHANLOAIKHACHHANG";

            // str = str + " SELECT *,DATEDIFF ( dd , NGAYDENHAN ,'" & Format(ngay, "MM/dd/yyyy") & "') AS SONGAYQUAHAN FROM @TBL_IN"

            return str;
        }

        public string KYHANNO_MIENBAC_2(string tk, int thang, int nam, DateTime ngay)
        {
            string str = "";

            str = str + " DECLARE @TBL_IN TABLE(";
            str = str + " MACH VARCHAR(100)";
            str = str + " ,SCT VARCHAR(100)";
            str = str + " ,NGAY SMALLDATETIME";
            str = str + " ,MAKH1 VARCHAR(100)";
            str = str + " ,DONVI NVARCHAR(500)";
            str = str + " ,PHANLOAI VARCHAR(20)";
            str = str + " ,PHANLOAIKHACHHANG VARCHAR(20)";
            str = str + " ,TIEN MONEY";
            str = str + " ,NGAYDENHAN SMALLDATETIME";
            str = str + " ,SONGAY FLOAT";
            str = str + " ,t1 FLOAT";
            str = str + " ,t2 FLOAT";
            str = str + " ,t3 FLOAT";
            str = str + " ,t4 FLOAT";
            str = str + " ,t5 FLOAT";
            str = str + " ,t6 FLOAT";
            str = str + " ,t7 FLOAT";
            str = str + " ,t8 FLOAT";
            str = str + " ,t9 FLOAT ";
            str = str + " ,t10 FLOAT";
            str = str + " ,t11 FLOAT";
            str = str + " ,t12 FLOAT";
            str = str + ",t13 FLOAT  ";
            str = str + ",t14 FLOAT   ";
            str = str + ",t15 FLOAT  ";
            str = str + ",t16 FLOAT   ";
            str = str + ",t17 FLOAT  ";
            str = str + ",t18 FLOAT  ";
            str = str + ",t19 FLOAT  ";
            str = str + ",t20 FLOAT  ";
            str = str + ",t21 FLOAT  ";
            str = str + ",t22 FLOAT  ";
            str = str + ",t23 FLOAT  ";
            str = str + ",t24 FLOAT  ";

            str = str + ",t25 FLOAT  ";
            str = str + ",t26 FLOAT  ";
            str = str + ",t27 FLOAT  ";
            str = str + ",t28 FLOAT  ";
            str = str + ",t29 FLOAT  ";
            str = str + ",t30 FLOAT  ";
            str = str + ",t31 FLOAT  ";
            str = str + ",t32 FLOAT  ";
            str = str + ",t33 FLOAT   ";
            str = str + ",t34 FLOAT  ";
            str = str + ",t35 FLOAT   ";
            str = str + ",t36 FLOAT  ";
            str = str + ",t37 FLOAT  ";

            str = str + ",t38 FLOAT  ";
            str = str + ",t39 FLOAT   ";
            str = str + ",t40 FLOAT  ";




            str = str + " )";

            str = str + " insert into @TBL_IN(sct,ngay,makh1,tien)";
            str = str + " select sct,ngay,makh,tien";
            str = str + " FROM dta_kyhancongno";
            str = str + " where thang=" + thang;
            str = str + " and nam=" + nam;
            str = str + " and tk='" + tk + "'";

            str = str + " declare @mach varchar(20)";
            str = str + " set @mach =(SELECT TOP 1 MACH FROM TBL_DANHMUCCUAHANG WHERE ISNULL(MACH,'')<>'' )";


            str = str + " UPDATE @TBL_IN SET DONVI =( SELECT DONVI FROM KT_TH.DBO.TBL_DANHMUCKHACHHANG  WHERE MAKH=MAKH1 AND MACH= @mach) ";
            str = str + " UPDATE @TBL_IN SET PHANLOAI =( SELECT PHANLOAI FROM KT_TH.DBO.TBL_DANHMUCKHACHHANG  WHERE MAKH=MAKH1 AND MACH= @mach) ";
            str = str + " UPDATE @TBL_IN SET PHANLOAIKHACHHANG =( SELECT PHANLOAIKHACHHANG FROM KT_TH.DBO.TBL_DANHMUCKHACHHANG  WHERE MAKH=MAKH1 AND MACH= @mach) ";
            str = str + " UPDATE @TBL_IN SET PHANLOAI='OTC' WHERE PHANLOAI NOT IN('OTC','ETC')";
            str = str + " UPDATE @TBL_IN SET MACH =( SELECT MACH FROM TBL_DANHMUCCUAHANG)";


            str = str + " UPDATE @TBL_IN";
            str = str + " SET NGAYDENHAN='" + ngay.ToString("MM/dd/yyyy") + "'";

            // ' cập nhật số ngày
            str = str + " update @TBL_IN";
            str = str + " set songay=DATEDIFF ( dd , ngay ,'" + ngay.ToString("MM/dd/yyyy") + "')";

            str = str + " update @TBL_IN set t1=tien where  songay<=30";


            str = str + " update @TBL_IN set t2=tien where songay>30 and songay<=60";
            str = str + " update @TBL_IN set t3=tien where songay>60 and songay<=90";
            str = str + " update @TBL_IN set t4=tien where songay>90 and songay<=120";
            str = str + " update @TBL_IN set t5=tien where songay>120 and songay<=150";
            str = str + " update @TBL_IN set t6=tien where songay>150 and songay<=180";
            str = str + " update @TBL_IN set t7=tien where songay>180 and songay<=210";
            str = str + " update @TBL_IN set t8=tien where songay>210 and songay<=240";
            str = str + " update @TBL_IN set t9=tien where songay>240 and songay<=270";
            str = str + " update @TBL_IN set t10=tien where songay>270 and songay<=300";
            str = str + " update @TBL_IN set t11=tien where songay>300 and songay<=330";
            str = str + " update @TBL_IN set t12=tien where songay>330 and songay<=360";
            // str = str + " update @TBL_IN set t13=tien where songay>360 "

            str = str + " update @TBL_IN set t13=tien where songay>360 and songay<=390";
            str = str + " update @TBL_IN set t14=tien where songay>390 and songay<=420";
            str = str + " update @TBL_IN set t15=tien where songay>420 and songay<=450";
            str = str + " update @TBL_IN set t16=tien where songay>450 and songay<=480";
            str = str + " update @TBL_IN set t17=tien where songay>480 and songay<=510";
            str = str + " update @TBL_IN set t18=tien where songay>510 and songay<=540";
            str = str + " update @TBL_IN set t19=tien where songay>540 and songay<=570";
            str = str + " update @TBL_IN set t20=tien where songay>570 and songay<=600";
            str = str + " update @TBL_IN set t21=tien where songay>600 and songay<=630";
            str = str + " update @TBL_IN set t22=tien where songay>630 and songay<=660";
            str = str + " update @TBL_IN set t23=tien where songay>660 and songay<=690";
            str = str + " update @TBL_IN set t24=tien where songay>690 and songay<=720";

            str = str + " update @TBL_IN set t25=tien where songay>720 and songay<=750";
            str = str + " update @TBL_IN set t26=tien where songay>750 and songay<=780";
            str = str + " update @TBL_IN set t27=tien where songay>780 and songay<=810";
            str = str + " update @TBL_IN set t28=tien where songay>810 and songay<=840";
            str = str + " update @TBL_IN set t29=tien where songay>840 and songay<=870";
            str = str + " update @TBL_IN set t30=tien where songay>870 and songay<=900";
            str = str + " update @TBL_IN set t31=tien where songay>900 and songay<=930";
            str = str + " update @TBL_IN set t32=tien where songay>930 and songay<=960";
            str = str + " update @TBL_IN set t33=tien where songay>960 and songay<=990";
            str = str + " update @TBL_IN set t34=tien where songay>990 and songay<=1020";
            str = str + " update @TBL_IN set t35=tien where songay>1020 and songay<=1050";
            str = str + " update @TBL_IN set t36=tien where songay>1050 and songay<=1080";


            str = str + " update @TBL_IN set t37=tien where songay>1080 and songay<=1110";
            str = str + " update @TBL_IN set t38=tien where songay>1110 and songay<=1140";
            str = str + " update @TBL_IN set t39=tien where songay>1140 and songay<=1170";
            str = str + " update @TBL_IN set t40=tien where songay>1170 ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t1=0";
            str = str + " WHERE T1 IS NULL ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t2=0";
            str = str + " WHERE T2 IS NULL";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t3=0";
            str = str + " WHERE T3 IS NULL ";


            str = str + " UPDATE @TBL_IN";
            str = str + " SET t4=0";
            str = str + " WHERE T4 IS NULL ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t5=0";
            str = str + " WHERE T5 IS NULL";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t6=0";
            str = str + " WHERE T6 IS NULL ";


            str = str + " UPDATE @TBL_IN";
            str = str + " SET t7=0";
            str = str + " WHERE T7 IS NULL ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t8=0";
            str = str + " WHERE T8 IS NULL";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t9=0";
            str = str + " WHERE T9 IS NULL ";


            str = str + " UPDATE @TBL_IN";
            str = str + " SET t10=0";
            str = str + " WHERE T10 IS NULL ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t11=0";
            str = str + " WHERE T11 IS NULL";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t12=0";
            str = str + " WHERE T12 IS NULL ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t13=0";
            str = str + " WHERE T13 IS NULL ";


            str = str + " UPDATE @TBL_IN";
            str = str + " SET t14=0";
            str = str + " WHERE T14 IS NULL ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t15=0";
            str = str + " WHERE T15 IS NULL";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t16=0";
            str = str + " WHERE T16 IS NULL ";


            str = str + " UPDATE @TBL_IN";
            str = str + " SET t17=0";
            str = str + " WHERE T17 IS NULL ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t18=0";
            str = str + " WHERE T18 IS NULL";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t19=0";
            str = str + " WHERE T19 IS NULL ";


            str = str + " UPDATE @TBL_IN";
            str = str + " SET t20=0";
            str = str + " WHERE t20 IS NULL ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t21=0";
            str = str + " WHERE T21 IS NULL ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t22=0";
            str = str + " WHERE T22 IS NULL";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t23=0";
            str = str + " WHERE T23 IS NULL ";


            str = str + " UPDATE @TBL_IN";
            str = str + " SET t24=0";
            str = str + " WHERE T24 IS NULL ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t25=0";
            str = str + " WHERE T25 IS NULL";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t26=0";
            str = str + " WHERE T26 IS NULL ";


            str = str + " UPDATE @TBL_IN";
            str = str + " SET t27=0";
            str = str + " WHERE T27 IS NULL ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t28=0";
            str = str + " WHERE T28 IS NULL";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t29=0";
            str = str + " WHERE T29 IS NULL ";


            str = str + " UPDATE @TBL_IN";
            str = str + " SET t30=0";
            str = str + " WHERE t30 IS NULL ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t31=0";
            str = str + " WHERE T31 IS NULL ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t32=0";
            str = str + " WHERE T32 IS NULL";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t33=0";
            str = str + " WHERE T33 IS NULL ";


            str = str + " UPDATE @TBL_IN";
            str = str + " SET t34=0";
            str = str + " WHERE T34 IS NULL ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t35=0";
            str = str + " WHERE T35 IS NULL";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t36=0";
            str = str + " WHERE T36 IS NULL ";


            str = str + " UPDATE @TBL_IN";
            str = str + " SET t37=0";
            str = str + " WHERE T37 IS NULL ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t38=0";
            str = str + " WHERE T38 IS NULL";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t39=0";
            str = str + " WHERE T39 IS NULL ";

            str = str + " UPDATE @TBL_IN";
            str = str + " SET t40=0";
            str = str + " WHERE t40 IS NULL ";


            str = str + " SELECT * FROM @TBL_IN";
            // str = str + " SELECT *,DATEDIFF ( dd , NGAYDENHAN ,'" & Format(ngay, "MM/dd/yyyy") & "') AS SONGAYQUAHAN FROM @TBL_IN"



            return str;



        }

    }
    public class ScheduleJob8 : IJob
    {
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
        POWERBIEntities PBIDATA = new POWERBIEntities();

        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();
        public void Execute(IJobExecutionContext context)
        {

            var tungay = DateTime.Today.AddMonths(-3).ToString("01/MM/yyyy");
            var denngay = DateTime.Today.ToString("dd/MM/yyyy");
            DateTime tungay1 = DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DateTime denngay1 = DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var str = "SELECT 'ABC' as macn, N'CDE' as tencn, [sct] ,[ngay]  as ngayct,[nd] as noidung,[tkn] ,[tkc] ,[makhc] ,CAST(Sum([tien]) as money) as tien,TBL_DANHMUCKHACHHANG.phanloaikhachhang,TBL_DANHMUCKHACHHANG.phanloai as phanloaiotcetc FROM dta_dinhkhoan  left join TBL_DANHMUCKHACHHANG on dta_dinhkhoan.makhc = TBL_DANHMUCKHACHHANG.makh WHERE NGAY BETWEEN '" + tungay1.ToString("MM/dd/yyyy") + "' AND '" + denngay1.ToString("MM/dd/yyyy") + "' AND makhc<>'' AND kt=1 and tkc = '131' group by sct,ngay,tkn,makhc,nd,tkc,TBL_DANHMUCKHACHHANG.phanloaikhachhang,TBL_DANHMUCKHACHHANG.phanloai";
            var macn = "HN,PT,TB,TNG,HP,HCM,CT,AG,CM,DN,LD,TG,TN,VL,BDG,BT,PY,QN,BD,DNA,GL,HUE,NA,NT,THO".Split(',').ToList();
            var data = new List<DTA_PHATSINHCO131>();
            PBIDATA.DTA_PHATSINHCO131.RemoveRange(PBIDATA.DTA_PHATSINHCO131.Where(n => n.ngayct >= tungay1 && n.ngayct <= denngay1));
            foreach (var i in macn)
            {
                //try
                //{
                if (queryCN.SingleOrDefault(n => n.macn == i) != null)
                {
                    var tencn = db2.TBL_DANHSACHCHINHANH.SingleOrDefault(n => n.macn == i).Tencn;
                    var z = queryCN.SingleOrDefault(n => n.macn == i).data.Database.SqlQuery<DTA_PHATSINHCO131>(str.Replace("ABC", i).Replace("CDE", tencn)).ToList();
                    data.AddRange(z);
                    //PBIDATA.DTA_TONKHO_CHITIET.AddRange(queryCN.SingleOrDefault(n => n.macn == i).data.DTA_TONKHO_NHAP.Where(n => n.nam == nam && n.thang == thang && n.kho != "OH").Select(n => new DTA_TONKHO_CHITIET() { macn = i, mahh = n.mahh, nam = nam, thang = thang, slton = n.slton, makho = n.kho, handung = n.handung, solo = n.malo }));
                }
                //else if (queryCH.SingleOrDefault(n => n.macn == i) != null)
                //{
                //    queryCH.SingleOrDefault(n => n.macn == i).data.Database.SqlQuery<DATAKYHANNO2>(str).ToList();
                //}
                //}
                //catch (Exception ex)
                //{

                //}
            }
            foreach (var i in data)
            {
                if (i.tkn.Substring(0, 3) == "111")
                {
                    i.phanloai = "Tiền mặt";
                }
                else if (i.tkn.Substring(0, 3) == "112")
                {
                    i.phanloai = "Ngân hàng";
                }
                else
                {
                    i.phanloai = "Khác";
                }
                i.ngayupdate = DateTime.Now;
            }
            PBIDATA.DTA_PHATSINHCO131.AddRange(data);
            PBIDATA.SaveChanges();
        }
    }
    public class ScheduleJob1 : IJob
    {
        ApplicationChartEntities1 db2 = new ApplicationChartEntities1();
        KT_THEntities1 DATATH1 = new KT_THEntities1("KT_THEntities1");
        KT_THEntities1 DATATH2 = new KT_THEntities1("KT_THEntities2");
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                var data = db2.TBL_DANHMUCSODANGKY.ToList();
                var data1 = DATATH1.TBL_DANHMUCSODANGKY.ToList();
                DATATH1.TBL_DANHMUCSODANGKY.RemoveRange(data1);
                DATATH1.TBL_DANHMUCSODANGKY.AddRange(data);
                DATATH1.SaveChanges();
                var datakm = DATATH1.TBL_DANHMUCKM.ToList();
                var dataht = DATATH1.TBL_DANHMUCCHUONGTRINHHOTRO.ToList();
                var datachitiet = DATATH1.TBL_DANHMUCKM_CHITIET.ToList();
                var datakmtam = DATATH2.TBL_DANHMUCKM.ToList();
                DATATH2.TBL_DANHMUCKM.RemoveRange(datakmtam);
                DATATH2.TBL_DANHMUCKM.AddRange(datakm);
                var datahttam = DATATH2.TBL_DANHMUCCHUONGTRINHHOTRO.ToList();
                DATATH2.TBL_DANHMUCCHUONGTRINHHOTRO.RemoveRange(datahttam);
                DATATH2.TBL_DANHMUCCHUONGTRINHHOTRO.AddRange(dataht);
                var datachitiettam = DATATH2.TBL_DANHMUCKM_CHITIET.ToList();
                DATATH2.TBL_DANHMUCKM_CHITIET.RemoveRange(datachitiettam);
                DATATH2.TBL_DANHMUCKM_CHITIET.AddRange(datachitiet);
                DATATH2.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
    }
    public class JobScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<ScheduleJob>().Build();
            IJobDetail job1 = JobBuilder.Create<ScheduleJob1>().Build();
            IJobDetail job2 = JobBuilder.Create<ScheduleJob2>().Build();
            IJobDetail job3 = JobBuilder.Create<ScheduleJob3>().Build();
            IJobDetail job4 = JobBuilder.Create<ScheduleJob4>().Build();
        
            IJobDetail job6 = JobBuilder.Create<ScheduleJob6>().Build();
            IJobDetail job7 = JobBuilder.Create<ScheduleJob7>().Build();
            IJobDetail job8 = JobBuilder.Create<ScheduleJob8>().Build();
            ITrigger trigger2 = TriggerBuilder.Create()
                .WithDescription("XUATHOPDONGCHINHANH")
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(19, 00))
                .Build();
            ITrigger trigger3 = TriggerBuilder.Create()
                 .WithDescription("XUATDATACHITIETHOADON")
                 .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(0, 0))
                 .Build();
            ITrigger trigger4 = TriggerBuilder.Create()
                .WithDescription("XUATDATACHITIET")
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(2, 00))
                .Build();
            ITrigger trigger5 = TriggerBuilder.Create()
                .WithDescription("XUATDATACHITIET1")
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(17, 30))
                .Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithDescription("Checklock")
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(7, 30))
                .Build();
            ITrigger trigger1 = TriggerBuilder.Create()
                .WithDescription("AsyncSDK")
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(10, 15))
                .Build();
                var triggerSet = new Quartz.Collection.HashSet<ITrigger>();
                var triggerSet1 = new Quartz.Collection.HashSet<ITrigger>();
            ITrigger trigger6 = TriggerBuilder.Create()
        .WithDescription("kyhancongno")
        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(5, 00))
        .Build();
                    ITrigger trigger61 = TriggerBuilder.Create()
        .WithDescription("KYHANCONGNO1")
        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(18, 30))
        .Build();
                    ITrigger trigger7 = TriggerBuilder.Create()
        .WithDescription("congnohangngay")
        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(07, 00))
        .Build();
                    ITrigger trigger71 = TriggerBuilder.Create()
        .WithDescription("congnohangngay")
        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(12, 00))
        .Build();
            ITrigger trigger8 = TriggerBuilder.Create()
                 .WithDescription("PHATSINHCO131")
                 .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(12, 30))
                 .Build();
            //            ITrigger trigger62 = TriggerBuilder.Create()
            //.WithDescription("KYHANCONGNO2")
            //.WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(17, 0))
            //.Build();
            //            ITrigger trigger63 = TriggerBuilder.Create()
            //.WithDescription("KYHANCONGNO3")
            //.WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(18, 0))
            //.Build();


            //triggerSet.Add(trigger62);
            //scheduler.ScheduleJob(job5, trigger5);
            //từ đây
            triggerSet.Add(trigger6);
            triggerSet.Add(trigger61);
            triggerSet1.Add(trigger7);
            triggerSet1.Add(trigger71);
            scheduler.ScheduleJob(job, trigger);
            scheduler.ScheduleJob(job1, trigger1);
            scheduler.ScheduleJob(job2, trigger2);
            scheduler.ScheduleJob(job3, trigger3);
            scheduler.ScheduleJob(job4, trigger4);

            scheduler.ScheduleJob(job6, triggerSet, false);
            scheduler.ScheduleJob(job7, triggerSet1, false);
            scheduler.ScheduleJob(job8, trigger8);
        }
    }
}