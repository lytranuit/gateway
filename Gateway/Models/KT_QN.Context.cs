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
    
    public partial class Entities : DbContext
    {
        public Entities(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_DANHMUCBIENBANTHOATHUAN> TBL_DANHMUCBIENBANTHOATHUAN { get; set; }
        public virtual DbSet<DTA_DONDATHANG> DTA_DONDATHANG { get; set; }
        public virtual DbSet<TBL_DANHMUCKHOANTDV> TBL_DANHMUCKHOANTDV { get; set; }
        public virtual DbSet<TBL_DANHMUCKHOANTDV_PHI> TBL_DANHMUCKHOANTDV_PHI { get; set; }
        public virtual DbSet<TBL_DANHMUCTDV> TBL_DANHMUCTDV { get; set; }
        public virtual DbSet<DTA_TONKHO_NHAP> DTA_TONKHO_NHAP { get; set; }
        public virtual DbSet<DTA_DONDATHANG_KD> DTA_DONDATHANG_KD { get; set; }
        public virtual DbSet<TBL_DANHMUCHANGHOA> TBL_DANHMUCHANGHOA { get; set; }
        public virtual DbSet<TBL_DANHMUCHOPDONGCHUNG> TBL_DANHMUCHOPDONGCHUNG { get; set; }
        public virtual DbSet<TBL_DANHMUCHOPDONG_WS> TBL_DANHMUCHOPDONG_WS { get; set; }
        public virtual DbSet<DTA_DONDATHANG_WS> DTA_DONDATHANG_WS { get; set; }
        public virtual DbSet<TBL_CT_DANHMUCHOPDONG_WS> TBL_CT_DANHMUCHOPDONG_WS { get; set; }
        public virtual DbSet<DTA_CT_HOADON_XUAT> DTA_CT_HOADON_XUAT { get; set; }
        public virtual DbSet<DTA_HOADON_XUAT> DTA_HOADON_XUAT { get; set; }
    }
}
