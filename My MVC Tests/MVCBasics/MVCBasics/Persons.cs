//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCBasics
{
    using System;
    using System.Collections.Generic;
    
    public partial class Persons
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public Nullable<int> CountryId { get; set; }
    
        public virtual Countries Countries { get; set; }
    }
}
