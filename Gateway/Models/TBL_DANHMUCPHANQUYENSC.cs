//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class TBL_DANHMUCPHANQUYENSC
    {
        public string taikhoan { get; set; }
        public string macn { get; set; }
        public string quyen { get; set; }
        public string makh { get; set; }
    
        public virtual TBL_DANHMUCNGUOIDUNG TBL_DANHMUCNGUOIDUNG { get; set; }
    }
}
