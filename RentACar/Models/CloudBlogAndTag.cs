//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentACar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CloudBlogAndTag
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int TegId { get; set; }
    
        public virtual Blog Blog { get; set; }
        public virtual Teg Teg { get; set; }
    }
}
