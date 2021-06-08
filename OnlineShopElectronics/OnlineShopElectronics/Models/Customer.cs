//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineShopElectronics.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public long ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CustomerName { get; set; }
        public string ContactPerson { get; set; }
        public string EmailContactPerson { get; set; }
        public string FaxNumber { get; set; }
        public string MobileContactPerson { get; set; }
        public string Address1 { get; set; }
        public string Addrees2 { get; set; }
        public string PhoneContactPerson { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public bool Status { get; set; }
        public Nullable<bool> IsAdmin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}