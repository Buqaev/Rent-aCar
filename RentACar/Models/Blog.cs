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
    
    public partial class Blog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Blog()
        {
            this.BlogComments = new HashSet<BlogComment>();
            this.CloudBlogAndTags = new HashSet<CloudBlogAndTag>();
        }
    
        public int Id { get; set; }
        public string Baslig { get; set; }
        public string Metn { get; set; }
        public System.DateTime Tarix { get; set; }
        public string Sekil { get; set; }
        public bool Status { get; set; }
        public int BlogCategorysId { get; set; }
    
        public virtual BlogCategory BlogCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlogComment> BlogComments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CloudBlogAndTag> CloudBlogAndTags { get; set; }
    }
}
