//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAN_XLIII.Service
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblManager
    {
        public Nullable<int> managerId { get; set; }
        public string sector { get; set; }
        public string access { get; set; }
    
        public virtual tblEmployee tblEmployee { get; set; }
    }
}