namespace ShopProject.Areas.Shopper.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customers()
        {
            Orders = new HashSet<Orders>();
            ShoppingCartItems = new HashSet<ShoppingCartItems>();
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
        public virtual ICollection<Orders> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCartItems> ShoppingCartItems { get; set; }
    }
}
