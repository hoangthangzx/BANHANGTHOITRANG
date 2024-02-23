namespace ShopProject.Areas.Shopper.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShippingDetails
    {
        [Key]
        [StringLength(20)]
        public string orderID { get; set; }

        [Required]
        [StringLength(500)]
        public string shippingAddress { get; set; }

        public DateTime? estimatedDeliveryDate { get; set; }

        [StringLength(100)]
        public string courier { get; set; }

        public virtual Orders Orders { get; set; }
    }
}
