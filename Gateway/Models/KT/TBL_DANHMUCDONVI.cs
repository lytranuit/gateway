using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace it_report.Models
{
    [Table("TBL_DANHMUCDONVI")]
    public class TBL_DANHMUCDONVI
    {
        [Key]
        public string MaTinh { get; set; }
        public string TenTinh { get; set; }
        

    }
}
