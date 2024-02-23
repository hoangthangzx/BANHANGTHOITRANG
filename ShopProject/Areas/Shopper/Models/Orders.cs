namespace ShopProject.Areas.Shopper.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
            Payments = new HashSet<Payments>();
        }

        [Key]
        [StringLength(20)]
        public string orderID { get; set; }

        [StringLength(20)]
        public string cusPhone { get; set; }

        public string orderMessage { get; set; }

        [StringLength(50)]
        public string orderDateTime { get; set; }

        [StringLength(50)]
        public string orderStatus { get; set; }

        [StringLength(50)]
        public string cusPhonegiao { get; set; }

        [StringLength(50)]
        public string cusEmailgiao { get; set; }

        [StringLength(50)]
        public string cusAddressgiao { get; set; }

        [StringLength(50)]
        public string cusFullNamegiao { get; set; }

        public virtual Customers Customers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payments> Payments { get; set; }

        public virtual ShippingDetails ShippingDetails { get; set; }
    }
}
