using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;

namespace it_report.Models
{
    public partial class KTContext : DbContext
    {

        public KTContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<TBL_DANHMUCKHACHHANG> TBL_DANHMUCKHACHHANG { get; set; }
        public DbSet<TBL_DANHMUCDONVI> TBL_DANHMUCDONVI { get; set; }
        public DbSet<TBL_DANHMUCQUAN> TBL_DANHMUCQUAN { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
