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
    
    public partial class TBL_DANHMUCCHUKY
    {
        public string taikhoan { get; set; }
        public string hoten { get; set; }
        public string macn { get; set; }
        public string url { get; set; }
    
        public virtual TBL_DANHMUCCHUKYCN TBL_DANHMUCCHUKYCN { get; set; }
    }
}
