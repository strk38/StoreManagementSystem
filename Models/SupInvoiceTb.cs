//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TallyBook_Store_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SupInvoiceTb
    {
        public int SI { get; set; }
        public string SProductName { get; set; }
        public Nullable<int> SQuantity { get; set; }
        public Nullable<decimal> Bill { get; set; }
        public Nullable<int> SName { get; set; }
    
        public virtual SupplierTb SupplierTb { get; set; }
    }
}
