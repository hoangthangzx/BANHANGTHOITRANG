using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopProject.Areas.Administrator.Models
{
    [Table("Customers")]
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [StringLength(20)]
        public string cusPhone { get; set; }

        [StringLength(200)]
        public string cusFullName { get; set; }

        [StringLength(100)]
        public string cusEmail { get; set; }

        [StringLength(500)]
        public string cusAddress { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        public int? role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
