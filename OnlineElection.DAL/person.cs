//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineElection.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public person()
        {
            this.candidates = new HashSet<candidate>();
            this.votes_person = new HashSet<votes_person>();
        }
    
        public System.Guid Person_ID { get; set; }
        public Nullable<int> Phone { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string SID { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Nullable<bool> AdminApproved { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<candidate> candidates { get; set; }
        public virtual staff staff { get; set; }
        public virtual student student { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<votes_person> votes_person { get; set; }
    }
}
