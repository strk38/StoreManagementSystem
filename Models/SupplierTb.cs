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
    
    public partial class SupplierTb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SupplierTb()
        {
            this.SupInvoiceTbs = new HashSet<SupInvoiceTb>();
        }
    
        public int SId { get; set; }
        public string SName { get; set; }
        public string SNo { get; set; }
        public Nullable<decimal> SDue { get; set; }
        public Nullable<int> User { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupInvoiceTb> SupInvoiceTbs { get; set; }
        public virtual UserTb UserTb { get; set; }
    }
}
