//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hakim.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Insurance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Insurance()
        {
            this.VisitReceptions = new HashSet<VisitReception>();
        }
    
        public int InsuranceId { get; set; }
        public string InsuranceTitle { get; set; }
        public int InsurancePrice { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VisitReception> VisitReceptions { get; set; }
    }
}
