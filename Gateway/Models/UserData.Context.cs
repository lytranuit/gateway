﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicationChart.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ApplicationChartEntities1 : DbContext
    {
        public ApplicationChartEntities1()
            : base("name=ApplicationChartEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DANHMUCPHANLOAIHD> DANHMUCPHANLOAIHDs { get; set; }
        public virtual DbSet<DIEUHUONG> DIEUHUONGs { get; set; }
        public virtual DbSet<TBL_DANGNHAPTHATBAI> TBL_DANGNHAPTHATBAI { get; set; }
        public virtual DbSet<TBL_DANHMUCKEHOACH> TBL_DANHMUCKEHOACH { get; set; }
        public virtual DbSet<TBL_DANHMUCNHOMHANG> TBL_DANHMUCNHOMHANG { get; set; }
        public virtual DbSet<TBL_DANHMUCPHANLOAIKHACHHANG> TBL_DANHMUCPHANLOAIKHACHHANG { get; set; }
        public virtual DbSet<TBL_DANHMUCSODANGKY> TBL_DANHMUCSODANGKY { get; set; }
        public virtual DbSet<TBL_NGAYDOIMATKHAU> TBL_NGAYDOIMATKHAU { get; set; }
        public virtual DbSet<TBL_NGAYKHOATK> TBL_NGAYKHOATK { get; set; }
        public virtual DbSet<TBL_QUANLYDANGNHAP> TBL_QUANLYDANGNHAP { get; set; }
        public virtual DbSet<KhuVuc> KhuVucs { get; set; }
        public virtual DbSet<TBL_DANHMUCKHACHHANGPHANPHOI> TBL_DANHMUCKHACHHANGPHANPHOI { get; set; }
        public virtual DbSet<TBL_DANHMUCPHANQUYENKD> TBL_DANHMUCPHANQUYENKD { get; set; }
        public virtual DbSet<TBL_DANHMUCCHUKY> TBL_DANHMUCCHUKY { get; set; }
        public virtual DbSet<TBL_DANHMUCCHUKYCN> TBL_DANHMUCCHUKYCN { get; set; }
        public virtual DbSet<TBL_DANHMUCHOPDONGCHUNG> TBL_DANHMUCHOPDONGCHUNG { get; set; }
        public virtual DbSet<DTA_TOADOKHACHHANG> DTA_TOADOKHACHHANG { get; set; }
        public virtual DbSet<TBL_PHANQUYENCRM> TBL_PHANQUYENCRM { get; set; }
        public virtual DbSet<TBL_APPVERSION> TBL_APPVERSION { get; set; }
        public virtual DbSet<TBL_BAOTRIAPP> TBL_BAOTRIAPP { get; set; }
        public virtual DbSet<TBL_DANHMUCTPCN> TBL_DANHMUCTPCN { get; set; }
        public virtual DbSet<TBL_DANHMUCMIEN> TBL_DANHMUCMIEN { get; set; }
        public virtual DbSet<DTA_GIAOHANG> DTA_GIAOHANG { get; set; }
        public virtual DbSet<TBL_DANHMUCLOAIBAOCAO> TBL_DANHMUCLOAIBAOCAO { get; set; }
        public virtual DbSet<TBL_DANHMUCSODANGKY_AUDIT> TBL_DANHMUCSODANGKY_AUDIT { get; set; }
        public virtual DbSet<TBL_DANHMUCPHANQUYENHCM> TBL_DANHMUCPHANQUYENHCM { get; set; }
        public virtual DbSet<TBL_DANHMUCPHANQUYENSC> TBL_DANHMUCPHANQUYENSC { get; set; }
        public virtual DbSet<TBL_DSKHOAN> TBL_DSKHOAN { get; set; }
        public virtual DbSet<TBL_DANHMUCHANGHOAPHANPHOI> TBL_DANHMUCHANGHOAPHANPHOI { get; set; }
        public virtual DbSet<DTA_SOTHE> DTA_SOTHE { get; set; }
        public virtual DbSet<TBL_DANHSACHCHINHANH> TBL_DANHSACHCHINHANH { get; set; }
        public virtual DbSet<DTA_CONGTACTRINHDUOC> DTA_CONGTACTRINHDUOC { get; set; }
        public virtual DbSet<TBL_DANHMUCCTHT_QUATANG> TBL_DANHMUCCTHT_QUATANG { get; set; }
        public virtual DbSet<TBL_DANHMUCKM_QUATANG> TBL_DANHMUCKM_QUATANG { get; set; }
        public virtual DbSet<TBL_DANHMUCPHUPHI> TBL_DANHMUCPHUPHI { get; set; }
        public virtual DbSet<TBL_UPDATE_PROGRAM> TBL_UPDATE_PROGRAM { get; set; }
        public virtual DbSet<TBL_DANHMUCPHANQUYENWS> TBL_DANHMUCPHANQUYENWS { get; set; }
        public virtual DbSet<TBL_DANHMUCNGUOIDUNG> TBL_DANHMUCNGUOIDUNG { get; set; }
    }
}