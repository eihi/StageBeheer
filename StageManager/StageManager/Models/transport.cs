//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StageManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class transport
    {
        public transport()
        {
            this.teachers = new HashSet<teachers>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<teachers> teachers { get; set; }
    }
}
