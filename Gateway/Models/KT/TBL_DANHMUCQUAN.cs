using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace it_report.Models
{
    [Table("TBL_DANHMUCQUAN")]
    public class TBL_DANHMUCQUAN
    {
        [Key]
        public string maquan { get; set; }
        public string tenquan { get; set; }
        public string matinh { get; set; }


    }
}
