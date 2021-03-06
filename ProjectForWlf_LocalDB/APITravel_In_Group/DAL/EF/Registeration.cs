//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Registeration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Registeration()
        {
            this.Payments = new HashSet<Payment>();
            this.RegistrationDateRanges = new HashSet<RegistrationDateRange>();
        }
    
        public int Id { get; set; }
        public int TravelingIdDriver { get; set; }
        public System.DateTime Date { get; set; }
        public int TravelingIdPassenger { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistrationDateRange> RegistrationDateRanges { get; set; }
        public virtual TravelingPassenger TravelingPassenger { get; set; }
        public virtual TravelingDriver TravelingDriver { get; set; }
    }
}
